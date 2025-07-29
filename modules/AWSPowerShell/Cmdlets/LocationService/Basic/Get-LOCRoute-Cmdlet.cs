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
    /// <a href="https://docs.aws.amazon.com/location/previous/developerguide/calculate-route.html">Calculates
    /// a route</a> given the following required parameters: <c>DeparturePosition</c> and
    /// <c>DestinationPosition</c>. Requires that you first <a href="https://docs.aws.amazon.com/location-routes/latest/APIReference/API_CreateRouteCalculator.html">create
    /// a route calculator resource</a>.
    /// 
    ///  
    /// <para>
    /// By default, a request that doesn't specify a departure time uses the best time of
    /// day to travel with the best traffic conditions when calculating the route.
    /// </para><para>
    /// Additional options include:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/location/previous/developerguide/departure-time.html">Specifying
    /// a departure time</a> using either <c>DepartureTime</c> or <c>DepartNow</c>. This calculates
    /// a route based on predictive traffic data at the given time. 
    /// </para><note><para>
    /// You can't specify both <c>DepartureTime</c> and <c>DepartNow</c> in a single request.
    /// Specifying both parameters returns a validation error.
    /// </para></note></li><li><para><a href="https://docs.aws.amazon.com/location/previous/developerguide/travel-mode.html">Specifying
    /// a travel mode</a> using TravelMode sets the transportation mode used to calculate
    /// the routes. This also lets you specify additional route preferences in <c>CarModeOptions</c>
    /// if traveling by <c>Car</c>, or <c>TruckModeOptions</c> if traveling by <c>Truck</c>.
    /// </para><note><para>
    /// If you specify <c>walking</c> for the travel mode and your data provider is Esri,
    /// the start and destination must be within 40km.
    /// </para></note></li></ul>
    /// </summary>
    [Cmdlet("Get", "LOCRoute")]
    [OutputType("Amazon.LocationService.Model.CalculateRouteResponse")]
    [AWSCmdlet("Calls the Amazon Location Service CalculateRoute API operation.", Operation = new[] {"CalculateRoute"}, SelectReturnType = typeof(Amazon.LocationService.Model.CalculateRouteResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.CalculateRouteResponse",
        "This cmdlet returns an Amazon.LocationService.Model.CalculateRouteResponse object containing multiple properties."
    )]
    public partial class GetLOCRouteCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ArrivalTime
        /// <summary>
        /// <para>
        /// <para>Specifies the desired time of arrival. Uses the given time to calculate the route.
        /// Otherwise, the best time of day to travel with the best traffic conditions is used
        /// to calculate the route.</para><note><para>ArrivalTime is not supported Esri.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ArrivalTime { get; set; }
        #endregion
        
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
        /// <para>The name of the route calculator resource that you want to use to calculate the route.
        /// </para>
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
        /// a route. Otherwise, the best time of day to travel with the best traffic conditions
        /// is used to calculate the route.</para><para>Default Value: <c>false</c></para><para>Valid Values: <c>false</c> | <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DepartNow { get; set; }
        #endregion
        
        #region Parameter DeparturePosition
        /// <summary>
        /// <para>
        /// <para>The start position for the route. Defined in <a href="https://earth-info.nga.mil/index.php?dir=wgs84&amp;action=wgs84">World
        /// Geodetic System (WGS 84)</a> format: <c>[longitude, latitude]</c>.</para><ul><li><para>For example, <c>[-123.115, 49.285]</c></para></li></ul><note><para>If you specify a departure that's not located on a road, Amazon Location <a href="https://docs.aws.amazon.com/location/previous/developerguide/snap-to-nearby-road.html">moves
        /// the position to the nearest road</a>. If Esri is the provider for your route calculator,
        /// specifying a route that is longer than 400 km returns a <c>400 RoutesValidationException</c>
        /// error.</para></note><para>Valid Values: <c>[-180 to 180,-90 to 90]</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        public System.Double[] DeparturePosition { get; set; }
        #endregion
        
        #region Parameter DepartureTime
        /// <summary>
        /// <para>
        /// <para>Specifies the desired time of departure. Uses the given time to calculate the route.
        /// Otherwise, the best time of day to travel with the best traffic conditions is used
        /// to calculate the route.</para><ul><li><para>In <a href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO 8601</a> format:
        /// <c>YYYY-MM-DDThh:mm:ss.sssZ</c>. For example, <c>2020–07-2T12:15:20.000Z+01:00</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DepartureTime { get; set; }
        #endregion
        
        #region Parameter DestinationPosition
        /// <summary>
        /// <para>
        /// <para>The finish position for the route. Defined in <a href="https://earth-info.nga.mil/index.php?dir=wgs84&amp;action=wgs84">World
        /// Geodetic System (WGS 84)</a> format: <c>[longitude, latitude]</c>.</para><ul><li><para> For example, <c>[-122.339, 47.615]</c></para></li></ul><note><para>If you specify a destination that's not located on a road, Amazon Location <a href="https://docs.aws.amazon.com/location/previous/developerguide/snap-to-nearby-road.html">moves
        /// the position to the nearest road</a>. </para></note><para>Valid Values: <c>[-180 to 180,-90 to 90]</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        public System.Double[] DestinationPosition { get; set; }
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
        
        #region Parameter IncludeLegGeometry
        /// <summary>
        /// <para>
        /// <para>Set to include the geometry details in the result for each path between a pair of
        /// positions.</para><para>Default Value: <c>false</c></para><para>Valid Values: <c>false</c> | <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeLegGeometry { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The optional <a href="https://docs.aws.amazon.com/location/previous/developerguide/using-apikeys.html">API
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
        
        #region Parameter OptimizeFor
        /// <summary>
        /// <para>
        /// <para>Specifies the distance to optimize for when calculating a route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LocationService.OptimizationMode")]
        public Amazon.LocationService.OptimizationMode OptimizeFor { get; set; }
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
        /// of travel and road compatibility. You can choose <c>Car</c>, <c>Truck</c>, <c>Walking</c>,
        /// <c>Bicycle</c> or <c>Motorcycle</c> as options for the <c>TravelMode</c>.</para><note><para><c>Bicycle</c> and <c>Motorcycle</c> are only valid when using Grab as a data provider,
        /// and only within Southeast Asia.</para><para><c>Truck</c> is not available for Grab.</para><para>For more details on the using Grab for routing, including areas of coverage, see <a href="https://docs.aws.amazon.com/location/previous/developerguide/grab.html">GrabMaps</a>
        /// in the <i>Amazon Location Service Developer Guide</i>.</para></note><para>The <c>TravelMode</c> you specify also determines how you specify route preferences:
        /// </para><ul><li><para>If traveling by <c>Car</c> use the <c>CarModeOptions</c> parameter.</para></li><li><para>If traveling by <c>Truck</c> use the <c>TruckModeOptions</c> parameter.</para></li></ul><para>Default Value: <c>Car</c></para>
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
        
        #region Parameter WaypointPosition
        /// <summary>
        /// <para>
        /// <para>Specifies an ordered list of up to 23 intermediate positions to include along a route
        /// between the departure position and destination position. </para><ul><li><para>For example, from the <c>DeparturePosition</c><c>[-123.115, 49.285]</c>, the route
        /// follows the order that the waypoint positions are given <c>[[-122.757, 49.0021],[-122.349,
        /// 47.620]]</c></para></li></ul><note><para>If you specify a waypoint position that's not located on a road, Amazon Location <a href="https://docs.aws.amazon.com/location/previous/developerguide/snap-to-nearby-road.html">moves
        /// the position to the nearest road</a>. </para><para>Specifying more than 23 waypoints returns a <c>400 ValidationException</c> error.</para><para>If Esri is the provider for your route calculator, specifying a route that is longer
        /// than 400 km returns a <c>400 RoutesValidationException</c> error.</para></note><para>Valid Values: <c>[-180 to 180,-90 to 90]</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WaypointPositions")]
        public System.Double[][] WaypointPosition { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.CalculateRouteResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.CalculateRouteResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.CalculateRouteResponse, GetLOCRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArrivalTime = this.ArrivalTime;
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
                context.DeparturePosition = new List<System.Double>(this.DeparturePosition);
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
                context.DestinationPosition = new List<System.Double>(this.DestinationPosition);
            }
            #if MODULAR
            if (this.DestinationPosition == null && ParameterWasBound(nameof(this.DestinationPosition)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationPosition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistanceUnit = this.DistanceUnit;
            context.IncludeLegGeometry = this.IncludeLegGeometry;
            context.Key = this.Key;
            context.OptimizeFor = this.OptimizeFor;
            context.TravelMode = this.TravelMode;
            context.TruckModeOptions_AvoidFerry = this.TruckModeOptions_AvoidFerry;
            context.TruckModeOptions_AvoidToll = this.TruckModeOptions_AvoidToll;
            context.Dimensions_Height = this.Dimensions_Height;
            context.Dimensions_Length = this.Dimensions_Length;
            context.Dimensions_Unit = this.Dimensions_Unit;
            context.Dimensions_Width = this.Dimensions_Width;
            context.Weight_Total = this.Weight_Total;
            context.Weight_Unit = this.Weight_Unit;
            if (this.WaypointPosition != null)
            {
                context.WaypointPosition = new List<List<System.Double>>();
                foreach (var innerList in this.WaypointPosition)
                {
                    context.WaypointPosition.Add(new List<System.Double>(innerList));
                }
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
            var request = new Amazon.LocationService.Model.CalculateRouteRequest();
            
            if (cmdletContext.ArrivalTime != null)
            {
                request.ArrivalTime = cmdletContext.ArrivalTime.Value;
            }
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
                request.DeparturePosition = cmdletContext.DeparturePosition;
            }
            if (cmdletContext.DepartureTime != null)
            {
                request.DepartureTime = cmdletContext.DepartureTime.Value;
            }
            if (cmdletContext.DestinationPosition != null)
            {
                request.DestinationPosition = cmdletContext.DestinationPosition;
            }
            if (cmdletContext.DistanceUnit != null)
            {
                request.DistanceUnit = cmdletContext.DistanceUnit;
            }
            if (cmdletContext.IncludeLegGeometry != null)
            {
                request.IncludeLegGeometry = cmdletContext.IncludeLegGeometry.Value;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.OptimizeFor != null)
            {
                request.OptimizeFor = cmdletContext.OptimizeFor;
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
            if (cmdletContext.WaypointPosition != null)
            {
                request.WaypointPositions = cmdletContext.WaypointPosition;
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
        
        private Amazon.LocationService.Model.CalculateRouteResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.CalculateRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "CalculateRoute");
            try
            {
                return client.CalculateRouteAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? ArrivalTime { get; set; }
            public System.String CalculatorName { get; set; }
            public System.Boolean? CarModeOptions_AvoidFerry { get; set; }
            public System.Boolean? CarModeOptions_AvoidToll { get; set; }
            public System.Boolean? DepartNow { get; set; }
            public List<System.Double> DeparturePosition { get; set; }
            public System.DateTime? DepartureTime { get; set; }
            public List<System.Double> DestinationPosition { get; set; }
            public Amazon.LocationService.DistanceUnit DistanceUnit { get; set; }
            public System.Boolean? IncludeLegGeometry { get; set; }
            public System.String Key { get; set; }
            public Amazon.LocationService.OptimizationMode OptimizeFor { get; set; }
            public Amazon.LocationService.TravelMode TravelMode { get; set; }
            public System.Boolean? TruckModeOptions_AvoidFerry { get; set; }
            public System.Boolean? TruckModeOptions_AvoidToll { get; set; }
            public System.Double? Dimensions_Height { get; set; }
            public System.Double? Dimensions_Length { get; set; }
            public Amazon.LocationService.DimensionUnit Dimensions_Unit { get; set; }
            public System.Double? Dimensions_Width { get; set; }
            public System.Double? Weight_Total { get; set; }
            public Amazon.LocationService.VehicleWeightUnit Weight_Unit { get; set; }
            public List<List<System.Double>> WaypointPosition { get; set; }
            public System.Func<Amazon.LocationService.Model.CalculateRouteResponse, GetLOCRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
