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
    /// <a href="https://docs.aws.amazon.com/location/latest/developerguide/calculate-route-matrix.html">
    /// Calculates a route matrix</a> given the following required parameters: <c>DeparturePositions</c>
    /// and <c>DestinationPositions</c>. <c>CalculateRouteMatrix</c> calculates routes and
    /// returns the travel time and travel distance from each departure position to each destination
    /// position in the request. For example, given departure positions A and B, and destination
    /// positions X and Y, <c>CalculateRouteMatrix</c> will return time and distance for routes
    /// from A to X, A to Y, B to X, and B to Y (in that order). The number of results returned
    /// (and routes calculated) will be the number of <c>DeparturePositions</c> times the
    /// number of <c>DestinationPositions</c>.
    /// 
    ///  <note><para>
    /// Your account is charged for each route calculated, not the number of requests.
    /// </para></note><para>
    /// Requires that you first <a href="https://docs.aws.amazon.com/location-routes/latest/APIReference/API_CreateRouteCalculator.html">create
    /// a route calculator resource</a>.
    /// </para><para>
    /// By default, a request that doesn't specify a departure time uses the best time of
    /// day to travel with the best traffic conditions when calculating routes.
    /// </para><para>
    /// Additional options include:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/location/latest/developerguide/departure-time.html">
    /// Specifying a departure time</a> using either <c>DepartureTime</c> or <c>DepartNow</c>.
    /// This calculates routes based on predictive traffic data at the given time. 
    /// </para><note><para>
    /// You can't specify both <c>DepartureTime</c> and <c>DepartNow</c> in a single request.
    /// Specifying both parameters returns a validation error.
    /// </para></note></li><li><para><a href="https://docs.aws.amazon.com/location/latest/developerguide/travel-mode.html">Specifying
    /// a travel mode</a> using TravelMode sets the transportation mode used to calculate
    /// the routes. This also lets you specify additional route preferences in <c>CarModeOptions</c>
    /// if traveling by <c>Car</c>, or <c>TruckModeOptions</c> if traveling by <c>Truck</c>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "LOCRouteMatrix")]
    [OutputType("Amazon.LocationService.Model.CalculateRouteMatrixResponse")]
    [AWSCmdlet("Calls the Amazon Location Service CalculateRouteMatrix API operation.", Operation = new[] {"CalculateRouteMatrix"}, SelectReturnType = typeof(Amazon.LocationService.Model.CalculateRouteMatrixResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.CalculateRouteMatrixResponse",
        "This cmdlet returns an Amazon.LocationService.Model.CalculateRouteMatrixResponse object containing multiple properties."
    )]
    public partial class GetLOCRouteMatrixCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CarModeOptions_AvoidFerry
        /// <summary>
        /// <para>
        /// <para>Avoids ferries when calculating routes.</para><para>Default Value: <c>false</c></para><para>Valid Values: <c>false</c> | <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CarModeOptions_AvoidFerries")]
        public System.Boolean? CarModeOptions_AvoidFerry { get; set; }
        #endregion
        
        #region Parameter TruckModeOptions_AvoidFerry
        /// <summary>
        /// <para>
        /// <para>Avoids ferries when calculating routes.</para><para>Default Value: <c>false</c></para><para>Valid Values: <c>false</c> | <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TruckModeOptions_AvoidFerries")]
        public System.Boolean? TruckModeOptions_AvoidFerry { get; set; }
        #endregion
        
        #region Parameter CarModeOptions_AvoidToll
        /// <summary>
        /// <para>
        /// <para>Avoids tolls when calculating routes.</para><para>Default Value: <c>false</c></para><para>Valid Values: <c>false</c> | <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CarModeOptions_AvoidTolls")]
        public System.Boolean? CarModeOptions_AvoidToll { get; set; }
        #endregion
        
        #region Parameter TruckModeOptions_AvoidToll
        /// <summary>
        /// <para>
        /// <para>Avoids tolls when calculating routes.</para><para>Default Value: <c>false</c></para><para>Valid Values: <c>false</c> | <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TruckModeOptions_AvoidTolls")]
        public System.Boolean? TruckModeOptions_AvoidToll { get; set; }
        #endregion
        
        #region Parameter CalculatorName
        /// <summary>
        /// <para>
        /// <para>The name of the route calculator resource that you want to use to calculate the route
        /// matrix. </para>
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
        public System.String CalculatorName { get; set; }
        #endregion
        
        #region Parameter DepartNow
        /// <summary>
        /// <para>
        /// <para>Sets the time of departure as the current time. Uses the current time to calculate
        /// the route matrix. You can't set both <c>DepartureTime</c> and <c>DepartNow</c>. If
        /// neither is set, the best time of day to travel with the best traffic conditions is
        /// used to calculate the route matrix.</para><para>Default Value: <c>false</c></para><para>Valid Values: <c>false</c> | <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DepartNow { get; set; }
        #endregion
        
        #region Parameter DeparturePosition
        /// <summary>
        /// <para>
        /// <para>The list of departure (origin) positions for the route matrix. An array of points,
        /// each of which is itself a 2-value array defined in <a href="https://earth-info.nga.mil/GandG/wgs84/index.html">WGS
        /// 84</a> format: <c>[longitude, latitude]</c>. For example, <c>[-123.115, 49.285]</c>.</para><important><para>Depending on the data provider selected in the route calculator resource there may
        /// be additional restrictions on the inputs you can choose. See <a href="https://docs.aws.amazon.com/location/latest/developerguide/calculate-route-matrix.html#matrix-routing-position-limits">
        /// Position restrictions</a> in the <i>Amazon Location Service Developer Guide</i>.</para></important><note><para>For route calculators that use Esri as the data provider, if you specify a departure
        /// that's not located on a road, Amazon Location <a href="https://docs.aws.amazon.com/location/latest/developerguide/snap-to-nearby-road.html">
        /// moves the position to the nearest road</a>. The snapped value is available in the
        /// result in <c>SnappedDeparturePositions</c>.</para></note><para>Valid Values: <c>[-180 to 180,-90 to 90]</c></para>
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
        [Alias("DeparturePositions")]
        public System.Double[][] DeparturePosition { get; set; }
        #endregion
        
        #region Parameter DepartureTime
        /// <summary>
        /// <para>
        /// <para>Specifies the desired time of departure. Uses the given time to calculate the route
        /// matrix. You can't set both <c>DepartureTime</c> and <c>DepartNow</c>. If neither is
        /// set, the best time of day to travel with the best traffic conditions is used to calculate
        /// the route matrix.</para><note><para>Setting a departure time in the past returns a <c>400 ValidationException</c> error.</para></note><ul><li><para>In <a href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO 8601</a> format:
        /// <c>YYYY-MM-DDThh:mm:ss.sssZ</c>. For example, <c>2020–07-2T12:15:20.000Z+01:00</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DepartureTime { get; set; }
        #endregion
        
        #region Parameter DestinationPosition
        /// <summary>
        /// <para>
        /// <para>The list of destination positions for the route matrix. An array of points, each of
        /// which is itself a 2-value array defined in <a href="https://earth-info.nga.mil/GandG/wgs84/index.html">WGS
        /// 84</a> format: <c>[longitude, latitude]</c>. For example, <c>[-122.339, 47.615]</c></para><important><para>Depending on the data provider selected in the route calculator resource there may
        /// be additional restrictions on the inputs you can choose. See <a href="https://docs.aws.amazon.com/location/latest/developerguide/calculate-route-matrix.html#matrix-routing-position-limits">
        /// Position restrictions</a> in the <i>Amazon Location Service Developer Guide</i>.</para></important><note><para>For route calculators that use Esri as the data provider, if you specify a destination
        /// that's not located on a road, Amazon Location <a href="https://docs.aws.amazon.com/location/latest/developerguide/snap-to-nearby-road.html">
        /// moves the position to the nearest road</a>. The snapped value is available in the
        /// result in <c>SnappedDestinationPositions</c>.</para></note><para>Valid Values: <c>[-180 to 180,-90 to 90]</c></para>
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
        [Alias("DestinationPositions")]
        public System.Double[][] DestinationPosition { get; set; }
        #endregion
        
        #region Parameter DistanceUnit
        /// <summary>
        /// <para>
        /// <para>Set the unit system to specify the distance.</para><para>Default Value: <c>Kilometers</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LocationService.DistanceUnit")]
        public Amazon.LocationService.DistanceUnit DistanceUnit { get; set; }
        #endregion
        
        #region Parameter Dimensions_Height
        /// <summary>
        /// <para>
        /// <para>The height of the truck.</para><ul><li><para>For example, <c>4.5</c>.</para></li></ul><note><para> For routes calculated with a HERE resource, this value must be between 0 and 50 meters.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TruckModeOptions_Dimensions_Height")]
        public System.Double? Dimensions_Height { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The optional <a href="https://docs.aws.amazon.com/location/latest/developerguide/using-apikeys.html">API
        /// key</a> to authorize the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter Dimensions_Length
        /// <summary>
        /// <para>
        /// <para>The length of the truck.</para><ul><li><para>For example, <c>15.5</c>.</para></li></ul><note><para> For routes calculated with a HERE resource, this value must be between 0 and 300
        /// meters. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TruckModeOptions_Dimensions_Length")]
        public System.Double? Dimensions_Length { get; set; }
        #endregion
        
        #region Parameter Weight_Total
        /// <summary>
        /// <para>
        /// <para>The total weight of the truck. </para><ul><li><para>For example, <c>3500</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TruckModeOptions_Weight_Total")]
        public System.Double? Weight_Total { get; set; }
        #endregion
        
        #region Parameter TravelMode
        /// <summary>
        /// <para>
        /// <para>Specifies the mode of transport when calculating a route. Used in estimating the speed
        /// of travel and road compatibility.</para><para>The <c>TravelMode</c> you specify also determines how you specify route preferences:
        /// </para><ul><li><para>If traveling by <c>Car</c> use the <c>CarModeOptions</c> parameter.</para></li><li><para>If traveling by <c>Truck</c> use the <c>TruckModeOptions</c> parameter.</para></li></ul><note><para><c>Bicycle</c> or <c>Motorcycle</c> are only valid when using <c>Grab</c> as a data
        /// provider, and only within Southeast Asia.</para><para><c>Truck</c> is not available for Grab.</para><para>For more information about using Grab as a data provider, see <a href="https://docs.aws.amazon.com/location/latest/developerguide/grab.html">GrabMaps</a>
        /// in the <i>Amazon Location Service Developer Guide</i>.</para></note><para>Default Value: <c>Car</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LocationService.TravelMode")]
        public Amazon.LocationService.TravelMode TravelMode { get; set; }
        #endregion
        
        #region Parameter Dimensions_Unit
        /// <summary>
        /// <para>
        /// <para> Specifies the unit of measurement for the truck dimensions.</para><para>Default Value: <c>Meters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TruckModeOptions_Dimensions_Unit")]
        [AWSConstantClassSource("Amazon.LocationService.DimensionUnit")]
        public Amazon.LocationService.DimensionUnit Dimensions_Unit { get; set; }
        #endregion
        
        #region Parameter Weight_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of measurement to use for the truck weight.</para><para>Default Value: <c>Kilograms</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TruckModeOptions_Weight_Unit")]
        [AWSConstantClassSource("Amazon.LocationService.VehicleWeightUnit")]
        public Amazon.LocationService.VehicleWeightUnit Weight_Unit { get; set; }
        #endregion
        
        #region Parameter Dimensions_Width
        /// <summary>
        /// <para>
        /// <para>The width of the truck.</para><ul><li><para>For example, <c>4.5</c>.</para></li></ul><note><para> For routes calculated with a HERE resource, this value must be between 0 and 50 meters.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TruckModeOptions_Dimensions_Width")]
        public System.Double? Dimensions_Width { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.CalculateRouteMatrixResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.CalculateRouteMatrixResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.CalculateRouteMatrixResponse, GetLOCRouteMatrixCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CalculatorName = this.CalculatorName;
            #if MODULAR
            if (this.CalculatorName == null && ParameterWasBound(nameof(this.CalculatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter CalculatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CarModeOptions_AvoidFerry = this.CarModeOptions_AvoidFerry;
            context.CarModeOptions_AvoidToll = this.CarModeOptions_AvoidToll;
            context.DepartNow = this.DepartNow;
            if (this.DeparturePosition != null)
            {
                context.DeparturePosition = new List<List<System.Double>>();
                foreach (var innerList in this.DeparturePosition)
                {
                    context.DeparturePosition.Add(new List<System.Double>(innerList));
                }
            }
            #if MODULAR
            if (this.DeparturePosition == null && ParameterWasBound(nameof(this.DeparturePosition)))
            {
                WriteWarning("You are passing $null as a value for parameter DeparturePosition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DepartureTime = this.DepartureTime;
            if (this.DestinationPosition != null)
            {
                context.DestinationPosition = new List<List<System.Double>>();
                foreach (var innerList in this.DestinationPosition)
                {
                    context.DestinationPosition.Add(new List<System.Double>(innerList));
                }
            }
            #if MODULAR
            if (this.DestinationPosition == null && ParameterWasBound(nameof(this.DestinationPosition)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationPosition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistanceUnit = this.DistanceUnit;
            context.Key = this.Key;
            context.TravelMode = this.TravelMode;
            context.TruckModeOptions_AvoidFerry = this.TruckModeOptions_AvoidFerry;
            context.TruckModeOptions_AvoidToll = this.TruckModeOptions_AvoidToll;
            context.Dimensions_Height = this.Dimensions_Height;
            context.Dimensions_Length = this.Dimensions_Length;
            context.Dimensions_Unit = this.Dimensions_Unit;
            context.Dimensions_Width = this.Dimensions_Width;
            context.Weight_Total = this.Weight_Total;
            context.Weight_Unit = this.Weight_Unit;
            
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
            var request = new Amazon.LocationService.Model.CalculateRouteMatrixRequest();
            
            if (cmdletContext.CalculatorName != null)
            {
                request.CalculatorName = cmdletContext.CalculatorName;
            }
            
             // populate CarModeOptions
            var requestCarModeOptionsIsNull = true;
            request.CarModeOptions = new Amazon.LocationService.Model.CalculateRouteCarModeOptions();
            System.Boolean? requestCarModeOptions_carModeOptions_AvoidFerry = null;
            if (cmdletContext.CarModeOptions_AvoidFerry != null)
            {
                requestCarModeOptions_carModeOptions_AvoidFerry = cmdletContext.CarModeOptions_AvoidFerry.Value;
            }
            if (requestCarModeOptions_carModeOptions_AvoidFerry != null)
            {
                request.CarModeOptions.AvoidFerries = requestCarModeOptions_carModeOptions_AvoidFerry.Value;
                requestCarModeOptionsIsNull = false;
            }
            System.Boolean? requestCarModeOptions_carModeOptions_AvoidToll = null;
            if (cmdletContext.CarModeOptions_AvoidToll != null)
            {
                requestCarModeOptions_carModeOptions_AvoidToll = cmdletContext.CarModeOptions_AvoidToll.Value;
            }
            if (requestCarModeOptions_carModeOptions_AvoidToll != null)
            {
                request.CarModeOptions.AvoidTolls = requestCarModeOptions_carModeOptions_AvoidToll.Value;
                requestCarModeOptionsIsNull = false;
            }
             // determine if request.CarModeOptions should be set to null
            if (requestCarModeOptionsIsNull)
            {
                request.CarModeOptions = null;
            }
            if (cmdletContext.DepartNow != null)
            {
                request.DepartNow = cmdletContext.DepartNow.Value;
            }
            if (cmdletContext.DeparturePosition != null)
            {
                request.DeparturePositions = cmdletContext.DeparturePosition;
            }
            if (cmdletContext.DepartureTime != null)
            {
                request.DepartureTime = cmdletContext.DepartureTime.Value;
            }
            if (cmdletContext.DestinationPosition != null)
            {
                request.DestinationPositions = cmdletContext.DestinationPosition;
            }
            if (cmdletContext.DistanceUnit != null)
            {
                request.DistanceUnit = cmdletContext.DistanceUnit;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.TravelMode != null)
            {
                request.TravelMode = cmdletContext.TravelMode;
            }
            
             // populate TruckModeOptions
            var requestTruckModeOptionsIsNull = true;
            request.TruckModeOptions = new Amazon.LocationService.Model.CalculateRouteTruckModeOptions();
            System.Boolean? requestTruckModeOptions_truckModeOptions_AvoidFerry = null;
            if (cmdletContext.TruckModeOptions_AvoidFerry != null)
            {
                requestTruckModeOptions_truckModeOptions_AvoidFerry = cmdletContext.TruckModeOptions_AvoidFerry.Value;
            }
            if (requestTruckModeOptions_truckModeOptions_AvoidFerry != null)
            {
                request.TruckModeOptions.AvoidFerries = requestTruckModeOptions_truckModeOptions_AvoidFerry.Value;
                requestTruckModeOptionsIsNull = false;
            }
            System.Boolean? requestTruckModeOptions_truckModeOptions_AvoidToll = null;
            if (cmdletContext.TruckModeOptions_AvoidToll != null)
            {
                requestTruckModeOptions_truckModeOptions_AvoidToll = cmdletContext.TruckModeOptions_AvoidToll.Value;
            }
            if (requestTruckModeOptions_truckModeOptions_AvoidToll != null)
            {
                request.TruckModeOptions.AvoidTolls = requestTruckModeOptions_truckModeOptions_AvoidToll.Value;
                requestTruckModeOptionsIsNull = false;
            }
            Amazon.LocationService.Model.TruckWeight requestTruckModeOptions_truckModeOptions_Weight = null;
            
             // populate Weight
            var requestTruckModeOptions_truckModeOptions_WeightIsNull = true;
            requestTruckModeOptions_truckModeOptions_Weight = new Amazon.LocationService.Model.TruckWeight();
            System.Double? requestTruckModeOptions_truckModeOptions_Weight_weight_Total = null;
            if (cmdletContext.Weight_Total != null)
            {
                requestTruckModeOptions_truckModeOptions_Weight_weight_Total = cmdletContext.Weight_Total.Value;
            }
            if (requestTruckModeOptions_truckModeOptions_Weight_weight_Total != null)
            {
                requestTruckModeOptions_truckModeOptions_Weight.Total = requestTruckModeOptions_truckModeOptions_Weight_weight_Total.Value;
                requestTruckModeOptions_truckModeOptions_WeightIsNull = false;
            }
            Amazon.LocationService.VehicleWeightUnit requestTruckModeOptions_truckModeOptions_Weight_weight_Unit = null;
            if (cmdletContext.Weight_Unit != null)
            {
                requestTruckModeOptions_truckModeOptions_Weight_weight_Unit = cmdletContext.Weight_Unit;
            }
            if (requestTruckModeOptions_truckModeOptions_Weight_weight_Unit != null)
            {
                requestTruckModeOptions_truckModeOptions_Weight.Unit = requestTruckModeOptions_truckModeOptions_Weight_weight_Unit;
                requestTruckModeOptions_truckModeOptions_WeightIsNull = false;
            }
             // determine if requestTruckModeOptions_truckModeOptions_Weight should be set to null
            if (requestTruckModeOptions_truckModeOptions_WeightIsNull)
            {
                requestTruckModeOptions_truckModeOptions_Weight = null;
            }
            if (requestTruckModeOptions_truckModeOptions_Weight != null)
            {
                request.TruckModeOptions.Weight = requestTruckModeOptions_truckModeOptions_Weight;
                requestTruckModeOptionsIsNull = false;
            }
            Amazon.LocationService.Model.TruckDimensions requestTruckModeOptions_truckModeOptions_Dimensions = null;
            
             // populate Dimensions
            var requestTruckModeOptions_truckModeOptions_DimensionsIsNull = true;
            requestTruckModeOptions_truckModeOptions_Dimensions = new Amazon.LocationService.Model.TruckDimensions();
            System.Double? requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Height = null;
            if (cmdletContext.Dimensions_Height != null)
            {
                requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Height = cmdletContext.Dimensions_Height.Value;
            }
            if (requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Height != null)
            {
                requestTruckModeOptions_truckModeOptions_Dimensions.Height = requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Height.Value;
                requestTruckModeOptions_truckModeOptions_DimensionsIsNull = false;
            }
            System.Double? requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Length = null;
            if (cmdletContext.Dimensions_Length != null)
            {
                requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Length = cmdletContext.Dimensions_Length.Value;
            }
            if (requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Length != null)
            {
                requestTruckModeOptions_truckModeOptions_Dimensions.Length = requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Length.Value;
                requestTruckModeOptions_truckModeOptions_DimensionsIsNull = false;
            }
            Amazon.LocationService.DimensionUnit requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Unit = null;
            if (cmdletContext.Dimensions_Unit != null)
            {
                requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Unit = cmdletContext.Dimensions_Unit;
            }
            if (requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Unit != null)
            {
                requestTruckModeOptions_truckModeOptions_Dimensions.Unit = requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Unit;
                requestTruckModeOptions_truckModeOptions_DimensionsIsNull = false;
            }
            System.Double? requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Width = null;
            if (cmdletContext.Dimensions_Width != null)
            {
                requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Width = cmdletContext.Dimensions_Width.Value;
            }
            if (requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Width != null)
            {
                requestTruckModeOptions_truckModeOptions_Dimensions.Width = requestTruckModeOptions_truckModeOptions_Dimensions_dimensions_Width.Value;
                requestTruckModeOptions_truckModeOptions_DimensionsIsNull = false;
            }
             // determine if requestTruckModeOptions_truckModeOptions_Dimensions should be set to null
            if (requestTruckModeOptions_truckModeOptions_DimensionsIsNull)
            {
                requestTruckModeOptions_truckModeOptions_Dimensions = null;
            }
            if (requestTruckModeOptions_truckModeOptions_Dimensions != null)
            {
                request.TruckModeOptions.Dimensions = requestTruckModeOptions_truckModeOptions_Dimensions;
                requestTruckModeOptionsIsNull = false;
            }
             // determine if request.TruckModeOptions should be set to null
            if (requestTruckModeOptionsIsNull)
            {
                request.TruckModeOptions = null;
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
        
        private Amazon.LocationService.Model.CalculateRouteMatrixResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.CalculateRouteMatrixRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "CalculateRouteMatrix");
            try
            {
                return client.CalculateRouteMatrixAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CalculatorName { get; set; }
            public System.Boolean? CarModeOptions_AvoidFerry { get; set; }
            public System.Boolean? CarModeOptions_AvoidToll { get; set; }
            public System.Boolean? DepartNow { get; set; }
            public List<List<System.Double>> DeparturePosition { get; set; }
            public System.DateTime? DepartureTime { get; set; }
            public List<List<System.Double>> DestinationPosition { get; set; }
            public Amazon.LocationService.DistanceUnit DistanceUnit { get; set; }
            public System.String Key { get; set; }
            public Amazon.LocationService.TravelMode TravelMode { get; set; }
            public System.Boolean? TruckModeOptions_AvoidFerry { get; set; }
            public System.Boolean? TruckModeOptions_AvoidToll { get; set; }
            public System.Double? Dimensions_Height { get; set; }
            public System.Double? Dimensions_Length { get; set; }
            public Amazon.LocationService.DimensionUnit Dimensions_Unit { get; set; }
            public System.Double? Dimensions_Width { get; set; }
            public System.Double? Weight_Total { get; set; }
            public Amazon.LocationService.VehicleWeightUnit Weight_Unit { get; set; }
            public System.Func<Amazon.LocationService.Model.CalculateRouteMatrixResponse, GetLOCRouteMatrixCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
