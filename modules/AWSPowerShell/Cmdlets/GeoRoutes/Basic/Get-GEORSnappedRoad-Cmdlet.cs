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
using Amazon.GeoRoutes;
using Amazon.GeoRoutes.Model;

namespace Amazon.PowerShell.Cmdlets.GEOR
{
    /// <summary>
    /// <c>SnapToRoads</c> matches GPS trace to roads most likely traveled on.
    /// </summary>
    [Cmdlet("Get", "GEORSnappedRoad")]
    [OutputType("Amazon.GeoRoutes.Model.SnapToRoadsResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Routes V2 SnapToRoads API operation.", Operation = new[] {"SnapToRoads"}, SelectReturnType = typeof(Amazon.GeoRoutes.Model.SnapToRoadsResponse))]
    [AWSCmdletOutput("Amazon.GeoRoutes.Model.SnapToRoadsResponse",
        "This cmdlet returns an Amazon.GeoRoutes.Model.SnapToRoadsResponse object containing multiple properties."
    )]
    public partial class GetGEORSnappedRoadCmdlet : AmazonGeoRoutesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Truck_GrossWeight
        /// <summary>
        /// <para>
        /// <para>Gross weight of the vehicle including trailers, and goods at capacity.</para><para><b>Unit</b>: <c>Kilograms</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_GrossWeight")]
        public System.Int64? Truck_GrossWeight { get; set; }
        #endregion
        
        #region Parameter Truck_HazardousCargo
        /// <summary>
        /// <para>
        /// <para>List of Hazardous cargos contained in the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_HazardousCargos")]
        public System.String[] Truck_HazardousCargo { get; set; }
        #endregion
        
        #region Parameter Truck_Height
        /// <summary>
        /// <para>
        /// <para>Height of the vehicle.</para><para><b>Unit</b>: <c>centimeters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_Height")]
        public System.Int64? Truck_Height { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>Optional: The API key to be used for authorization. Either an API key or valid SigV4
        /// signature must be provided when making a request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter Truck_Length
        /// <summary>
        /// <para>
        /// <para>Length of the vehicle.</para><para><b>Unit</b>: <c>centimeters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_Length")]
        public System.Int64? Truck_Length { get; set; }
        #endregion
        
        #region Parameter SnappedGeometryFormat
        /// <summary>
        /// <para>
        /// <para>Chooses what the returned SnappedGeometry format should be.</para><para>Default Value: <c>FlexiblePolyline</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.GeometryFormat")]
        public Amazon.GeoRoutes.GeometryFormat SnappedGeometryFormat { get; set; }
        #endregion
        
        #region Parameter SnapRadius
        /// <summary>
        /// <para>
        /// <para>The radius around the provided tracepoint that is considered for snapping.</para><para><b>Unit</b>: <c>meters</c></para><para>Default value: <c>300</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? SnapRadius { get; set; }
        #endregion
        
        #region Parameter TracePoint
        /// <summary>
        /// <para>
        /// <para>List of trace points to be snapped onto the road network.</para>
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
        [Alias("TracePoints")]
        public Amazon.GeoRoutes.Model.RoadSnapTracePoint[] TracePoint { get; set; }
        #endregion
        
        #region Parameter Trailer_TrailerCount
        /// <summary>
        /// <para>
        /// <para>Number of trailers attached to the vehicle.</para><para>Default Value: <c>0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_Trailer_TrailerCount")]
        public System.Int32? Trailer_TrailerCount { get; set; }
        #endregion
        
        #region Parameter TravelMode
        /// <summary>
        /// <para>
        /// <para>Specifies the mode of transport when calculating a route. Used in estimating the speed
        /// of travel and road compatibility.</para><para>Default Value: <c>Car</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.RoadSnapTravelMode")]
        public Amazon.GeoRoutes.RoadSnapTravelMode TravelMode { get; set; }
        #endregion
        
        #region Parameter Truck_TunnelRestrictionCode
        /// <summary>
        /// <para>
        /// <para>The tunnel restriction code.</para><para>Tunnel categories in this list indicate the restrictions which apply to certain tunnels
        /// in Great Britain. They relate to the types of dangerous goods that can be transported
        /// through them.</para><ul><li><para><i>Tunnel Category B</i></para><ul><li><para><i>Risk Level</i>: Limited risk</para></li><li><para><i>Restrictions</i>: Few restrictions</para></li></ul></li><li><para><i>Tunnel Category C</i></para><ul><li><para><i>Risk Level</i>: Medium risk</para></li><li><para><i>Restrictions</i>: Some restrictions</para></li></ul></li><li><para><i>Tunnel Category D</i></para><ul><li><para><i>Risk Level</i>: High risk</para></li><li><para><i>Restrictions</i>: Many restrictions occur</para></li></ul></li><li><para><i>Tunnel Category E</i></para><ul><li><para><i>Risk Level</i>: Very high risk</para></li><li><para><i>Restrictions</i>: Restricted tunnel</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_TunnelRestrictionCode")]
        public System.String Truck_TunnelRestrictionCode { get; set; }
        #endregion
        
        #region Parameter Truck_Width
        /// <summary>
        /// <para>
        /// <para>Width of the vehicle in centimenters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_Width")]
        public System.Int64? Truck_Width { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoRoutes.Model.SnapToRoadsResponse).
        /// Specifying the name of a property of type Amazon.GeoRoutes.Model.SnapToRoadsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GeoRoutes.Model.SnapToRoadsResponse, GetGEORSnappedRoadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Key = this.Key;
            context.SnappedGeometryFormat = this.SnappedGeometryFormat;
            context.SnapRadius = this.SnapRadius;
            if (this.TracePoint != null)
            {
                context.TracePoint = new List<Amazon.GeoRoutes.Model.RoadSnapTracePoint>(this.TracePoint);
            }
            #if MODULAR
            if (this.TracePoint == null && ParameterWasBound(nameof(this.TracePoint)))
            {
                WriteWarning("You are passing $null as a value for parameter TracePoint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TravelMode = this.TravelMode;
            context.Truck_GrossWeight = this.Truck_GrossWeight;
            if (this.Truck_HazardousCargo != null)
            {
                context.Truck_HazardousCargo = new List<System.String>(this.Truck_HazardousCargo);
            }
            context.Truck_Height = this.Truck_Height;
            context.Truck_Length = this.Truck_Length;
            context.Trailer_TrailerCount = this.Trailer_TrailerCount;
            context.Truck_TunnelRestrictionCode = this.Truck_TunnelRestrictionCode;
            context.Truck_Width = this.Truck_Width;
            
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
            var request = new Amazon.GeoRoutes.Model.SnapToRoadsRequest();
            
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.SnappedGeometryFormat != null)
            {
                request.SnappedGeometryFormat = cmdletContext.SnappedGeometryFormat;
            }
            if (cmdletContext.SnapRadius != null)
            {
                request.SnapRadius = cmdletContext.SnapRadius.Value;
            }
            if (cmdletContext.TracePoint != null)
            {
                request.TracePoints = cmdletContext.TracePoint;
            }
            if (cmdletContext.TravelMode != null)
            {
                request.TravelMode = cmdletContext.TravelMode;
            }
            
             // populate TravelModeOptions
            var requestTravelModeOptionsIsNull = true;
            request.TravelModeOptions = new Amazon.GeoRoutes.Model.RoadSnapTravelModeOptions();
            Amazon.GeoRoutes.Model.RoadSnapTruckOptions requestTravelModeOptions_travelModeOptions_Truck = null;
            
             // populate Truck
            var requestTravelModeOptions_travelModeOptions_TruckIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck = new Amazon.GeoRoutes.Model.RoadSnapTruckOptions();
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_truck_GrossWeight = null;
            if (cmdletContext.Truck_GrossWeight != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_GrossWeight = cmdletContext.Truck_GrossWeight.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_GrossWeight != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.GrossWeight = requestTravelModeOptions_travelModeOptions_Truck_truck_GrossWeight.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            List<System.String> requestTravelModeOptions_travelModeOptions_Truck_truck_HazardousCargo = null;
            if (cmdletContext.Truck_HazardousCargo != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_HazardousCargo = cmdletContext.Truck_HazardousCargo;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_HazardousCargo != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.HazardousCargos = requestTravelModeOptions_travelModeOptions_Truck_truck_HazardousCargo;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_truck_Height = null;
            if (cmdletContext.Truck_Height != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_Height = cmdletContext.Truck_Height.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_Height != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.Height = requestTravelModeOptions_travelModeOptions_Truck_truck_Height.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_truck_Length = null;
            if (cmdletContext.Truck_Length != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_Length = cmdletContext.Truck_Length.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_Length != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.Length = requestTravelModeOptions_travelModeOptions_Truck_truck_Length.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            System.String requestTravelModeOptions_travelModeOptions_Truck_truck_TunnelRestrictionCode = null;
            if (cmdletContext.Truck_TunnelRestrictionCode != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_TunnelRestrictionCode = cmdletContext.Truck_TunnelRestrictionCode;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_TunnelRestrictionCode != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.TunnelRestrictionCode = requestTravelModeOptions_travelModeOptions_Truck_truck_TunnelRestrictionCode;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_truck_Width = null;
            if (cmdletContext.Truck_Width != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_Width = cmdletContext.Truck_Width.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_Width != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.Width = requestTravelModeOptions_travelModeOptions_Truck_truck_Width.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            Amazon.GeoRoutes.Model.RoadSnapTrailerOptions requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = null;
            
             // populate Trailer
            var requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_TrailerIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = new Amazon.GeoRoutes.Model.RoadSnapTrailerOptions();
            System.Int32? requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer_trailer_TrailerCount = null;
            if (cmdletContext.Trailer_TrailerCount != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer_trailer_TrailerCount = cmdletContext.Trailer_TrailerCount.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer_trailer_TrailerCount != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer.TrailerCount = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer_trailer_TrailerCount.Value;
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_TrailerIsNull = false;
            }
             // determine if requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer should be set to null
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_TrailerIsNull)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = null;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.Trailer = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
             // determine if requestTravelModeOptions_travelModeOptions_Truck should be set to null
            if (requestTravelModeOptions_travelModeOptions_TruckIsNull)
            {
                requestTravelModeOptions_travelModeOptions_Truck = null;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck != null)
            {
                request.TravelModeOptions.Truck = requestTravelModeOptions_travelModeOptions_Truck;
                requestTravelModeOptionsIsNull = false;
            }
             // determine if request.TravelModeOptions should be set to null
            if (requestTravelModeOptionsIsNull)
            {
                request.TravelModeOptions = null;
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
        
        private Amazon.GeoRoutes.Model.SnapToRoadsResponse CallAWSServiceOperation(IAmazonGeoRoutes client, Amazon.GeoRoutes.Model.SnapToRoadsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Routes V2", "SnapToRoads");
            try
            {
                return client.SnapToRoadsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Key { get; set; }
            public Amazon.GeoRoutes.GeometryFormat SnappedGeometryFormat { get; set; }
            public System.Int64? SnapRadius { get; set; }
            public List<Amazon.GeoRoutes.Model.RoadSnapTracePoint> TracePoint { get; set; }
            public Amazon.GeoRoutes.RoadSnapTravelMode TravelMode { get; set; }
            public System.Int64? Truck_GrossWeight { get; set; }
            public List<System.String> Truck_HazardousCargo { get; set; }
            public System.Int64? Truck_Height { get; set; }
            public System.Int64? Truck_Length { get; set; }
            public System.Int32? Trailer_TrailerCount { get; set; }
            public System.String Truck_TunnelRestrictionCode { get; set; }
            public System.Int64? Truck_Width { get; set; }
            public System.Func<Amazon.GeoRoutes.Model.SnapToRoadsResponse, GetGEORSnappedRoadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
