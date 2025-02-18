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
    /// <c>CalculateRoutes</c> computes routes given the following required parameters: <c>Origin</c>
    /// and <c>Destination</c>.
    /// </summary>
    [Cmdlet("Get", "GEORRoute")]
    [OutputType("Amazon.GeoRoutes.Model.CalculateRoutesResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Routes V2 CalculateRoutes API operation.", Operation = new[] {"CalculateRoutes"}, SelectReturnType = typeof(Amazon.GeoRoutes.Model.CalculateRoutesResponse))]
    [AWSCmdletOutput("Amazon.GeoRoutes.Model.CalculateRoutesResponse",
        "This cmdlet returns an Amazon.GeoRoutes.Model.CalculateRoutesResponse object containing multiple properties."
    )]
    public partial class GetGEORRouteCmdlet : AmazonGeoRoutesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Tolls_AllTransponder
        /// <summary>
        /// <para>
        /// <para>Specifies if the user has valid transponder with access to all toll systems. This
        /// impacts toll calculation, and if true the price with transponders is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tolls_AllTransponders")]
        public System.Boolean? Tolls_AllTransponder { get; set; }
        #endregion
        
        #region Parameter Tolls_AllVignette
        /// <summary>
        /// <para>
        /// <para>Specifies if the user has valid vignettes with access for all toll roads. If a user
        /// has a vignette for a toll road, then toll cost for that road is omitted since no further
        /// payment is necessary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tolls_AllVignettes")]
        public System.Boolean? Tolls_AllVignette { get; set; }
        #endregion
        
        #region Parameter Avoid_Area
        /// <summary>
        /// <para>
        /// <para>Areas to be avoided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_Areas")]
        public Amazon.GeoRoutes.Model.RouteAvoidanceArea[] Avoid_Area { get; set; }
        #endregion
        
        #region Parameter ArrivalTime
        /// <summary>
        /// <para>
        /// <para>Time of arrival at the destination.</para><para>Time format:<c>YYYY-MM-DDThh:mm:ss.sssZ | YYYY-MM-DDThh:mm:ss.sss+hh:mm</c></para><para>Examples:</para><para><c>2020-04-22T17:57:24Z</c></para><para><c>2020-04-22T17:57:24+02:00</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArrivalTime { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_AvoidActionsForDistance
        /// <summary>
        /// <para>
        /// <para>Avoids actions for the provided distance. This is typically to consider for users
        /// in moving vehicles who may not have sufficient time to make an action at an origin
        /// or a destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DestinationOptions_AvoidActionsForDistance { get; set; }
        #endregion
        
        #region Parameter OriginOptions_AvoidActionsForDistance
        /// <summary>
        /// <para>
        /// <para>Avoids actions for the provided distance. This is typically to consider for users
        /// in moving vehicles who may not have sufficient time to make an action at an origin
        /// or a destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OriginOptions_AvoidActionsForDistance { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_AvoidUTurn
        /// <summary>
        /// <para>
        /// <para>Avoid U-turns for calculation on highways and motorways.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationOptions_AvoidUTurns")]
        public System.Boolean? DestinationOptions_AvoidUTurn { get; set; }
        #endregion
        
        #region Parameter OriginOptions_AvoidUTurn
        /// <summary>
        /// <para>
        /// <para>Avoid U-turns for calculation on highways and motorways.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OriginOptions_AvoidUTurns")]
        public System.Boolean? OriginOptions_AvoidUTurn { get; set; }
        #endregion
        
        #region Parameter Truck_AxleCount
        /// <summary>
        /// <para>
        /// <para>Total number of axles of the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_AxleCount")]
        public System.Int32? Truck_AxleCount { get; set; }
        #endregion
        
        #region Parameter Trailer_AxleCount
        /// <summary>
        /// <para>
        /// <para>Total number of axles of the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_Trailer_AxleCount")]
        public System.Int32? Trailer_AxleCount { get; set; }
        #endregion
        
        #region Parameter Avoid_CarShuttleTrain
        /// <summary>
        /// <para>
        /// <para>Avoid car-shuttle-trains while calculating the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_CarShuttleTrains")]
        public System.Boolean? Avoid_CarShuttleTrain { get; set; }
        #endregion
        
        #region Parameter EmissionType_Co2EmissionClass
        /// <summary>
        /// <para>
        /// <para>The CO 2 emission classes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tolls_EmissionType_Co2EmissionClass")]
        public System.String EmissionType_Co2EmissionClass { get; set; }
        #endregion
        
        #region Parameter Avoid_ControlledAccessHighway
        /// <summary>
        /// <para>
        /// <para>Avoid controlled access highways while calculating the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_ControlledAccessHighways")]
        public System.Boolean? Avoid_ControlledAccessHighway { get; set; }
        #endregion
        
        #region Parameter Exclude_Country
        /// <summary>
        /// <para>
        /// <para>List of countries to be avoided defined by two-letter or three-letter country codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Exclude_Countries")]
        public System.String[] Exclude_Country { get; set; }
        #endregion
        
        #region Parameter Tolls_Currency
        /// <summary>
        /// <para>
        /// <para>Currency code corresponding to the price. This is the same as Currency specified in
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Tolls_Currency { get; set; }
        #endregion
        
        #region Parameter DepartNow
        /// <summary>
        /// <para>
        /// <para>Uses the current time as the time of departure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DepartNow { get; set; }
        #endregion
        
        #region Parameter DepartureTime
        /// <summary>
        /// <para>
        /// <para>Time of departure from thr origin.</para><para>Time format:<c>YYYY-MM-DDThh:mm:ss.sssZ | YYYY-MM-DDThh:mm:ss.sss+hh:mm</c></para><para>Examples:</para><para><c>2020-04-22T17:57:24Z</c></para><para><c>2020-04-22T17:57:24+02:00</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DepartureTime { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The final position for the route. In the World Geodetic System (WGS 84) format: <c>[longitude,
        /// latitude]</c>.</para>
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
        public System.Double[] Destination { get; set; }
        #endregion
        
        #region Parameter Avoid_DirtRoad
        /// <summary>
        /// <para>
        /// <para>Avoid dirt roads while calculating the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_DirtRoads")]
        public System.Boolean? Avoid_DirtRoad { get; set; }
        #endregion
        
        #region Parameter Car_EngineType
        /// <summary>
        /// <para>
        /// <para>Engine type of the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Car_EngineType")]
        [AWSConstantClassSource("Amazon.GeoRoutes.RouteEngineType")]
        public Amazon.GeoRoutes.RouteEngineType Car_EngineType { get; set; }
        #endregion
        
        #region Parameter Scooter_EngineType
        /// <summary>
        /// <para>
        /// <para>Engine type of the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Scooter_EngineType")]
        [AWSConstantClassSource("Amazon.GeoRoutes.RouteEngineType")]
        public Amazon.GeoRoutes.RouteEngineType Scooter_EngineType { get; set; }
        #endregion
        
        #region Parameter Truck_EngineType
        /// <summary>
        /// <para>
        /// <para>Engine type of the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_EngineType")]
        [AWSConstantClassSource("Amazon.GeoRoutes.RouteEngineType")]
        public Amazon.GeoRoutes.RouteEngineType Truck_EngineType { get; set; }
        #endregion
        
        #region Parameter Avoid_Ferry
        /// <summary>
        /// <para>
        /// <para>Avoid ferries while calculating the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_Ferries")]
        public System.Boolean? Avoid_Ferry { get; set; }
        #endregion
        
        #region Parameter Traffic_FlowEventThresholdOverride
        /// <summary>
        /// <para>
        /// <para>Duration for which flow traffic is considered valid. For this period, the flow traffic
        /// is used over historical traffic data. Flow traffic refers to congestion, which changes
        /// very quickly. Duration in seconds for which flow traffic event would be considered
        /// valid. While flow traffic event is valid it will be used over the historical traffic
        /// data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Traffic_FlowEventThresholdOverride { get; set; }
        #endregion
        
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
        /// <para>List of Hazardous cargo contained in the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_HazardousCargos")]
        public System.String[] Truck_HazardousCargo { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_Heading
        /// <summary>
        /// <para>
        /// <para>GPS Heading at the position.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? DestinationOptions_Heading { get; set; }
        #endregion
        
        #region Parameter OriginOptions_Heading
        /// <summary>
        /// <para>
        /// <para>GPS Heading at the position.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? OriginOptions_Heading { get; set; }
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
        
        #region Parameter Truck_HeightAboveFirstAxle
        /// <summary>
        /// <para>
        /// <para>Height of the vehicle above its first axle.</para><para><b>Unit</b>: <c>centimeters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_HeightAboveFirstAxle")]
        public System.Int64? Truck_HeightAboveFirstAxle { get; set; }
        #endregion
        
        #region Parameter Allow_Hot
        /// <summary>
        /// <para>
        /// <para>Allow Hot (High Occupancy Toll) lanes while calculating the route.</para><para>Default value: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Allow_Hot { get; set; }
        #endregion
        
        #region Parameter Allow_Hov
        /// <summary>
        /// <para>
        /// <para>Allow Hov (High Occupancy vehicle) lanes while calculating the route.</para><para>Default value: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Allow_Hov { get; set; }
        #endregion
        
        #region Parameter InstructionsMeasurementSystem
        /// <summary>
        /// <para>
        /// <para>Measurement system to be used for instructions within steps in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.MeasurementSystem")]
        public Amazon.GeoRoutes.MeasurementSystem InstructionsMeasurementSystem { get; set; }
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
        
        #region Parameter Truck_KpraLength
        /// <summary>
        /// <para>
        /// <para>Kingpin to rear axle length of the vehicle.</para><para><b>Unit</b>: <c>centimeters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_KpraLength")]
        public System.Int64? Truck_KpraLength { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>List of languages for instructions within steps in the response.</para><note><para>Instructions in the requested language are returned only if they are available.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Languages")]
        public System.String[] Language { get; set; }
        #endregion
        
        #region Parameter TravelModeOptions_Car_LicensePlate_LastCharacter
        /// <summary>
        /// <para>
        /// <para>The last character of the License Plate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TravelModeOptions_Car_LicensePlate_LastCharacter { get; set; }
        #endregion
        
        #region Parameter TravelModeOptions_Scooter_LicensePlate_LastCharacter
        /// <summary>
        /// <para>
        /// <para>The last character of the License Plate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TravelModeOptions_Scooter_LicensePlate_LastCharacter { get; set; }
        #endregion
        
        #region Parameter TravelModeOptions_Truck_LicensePlate_LastCharacter
        /// <summary>
        /// <para>
        /// <para>The last character of the License Plate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TravelModeOptions_Truck_LicensePlate_LastCharacter { get; set; }
        #endregion
        
        #region Parameter LegAdditionalFeature
        /// <summary>
        /// <para>
        /// <para>A list of optional additional parameters such as timezone that can be requested for
        /// each result.</para><ul><li><para><c>Elevation</c>: Retrieves the elevation information for each location.</para></li><li><para><c>Incidents</c>: Provides information on traffic incidents along the route.</para></li><li><para><c>PassThroughWaypoints</c>: Indicates waypoints that are passed through without
        /// stopping.</para></li><li><para><c>Summary</c>: Returns a summary of the route, including distance and duration.</para></li><li><para><c>Tolls</c>: Supplies toll cost information along the route.</para></li><li><para><c>TravelStepInstructions</c>: Provides step-by-step instructions for travel along
        /// the route.</para></li><li><para><c>TruckRoadTypes</c>: Returns information about road types suitable for trucks.</para></li><li><para><c>TypicalDuration</c>: Gives typical travel duration based on historical data.</para></li><li><para><c>Zones</c>: Specifies the time zone information for each waypoint.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LegAdditionalFeatures")]
        public System.String[] LegAdditionalFeature { get; set; }
        #endregion
        
        #region Parameter LegGeometryFormat
        /// <summary>
        /// <para>
        /// <para>Specifies the format of the geometry returned for each leg of the route. You can choose
        /// between two different geometry encoding formats.</para><para><c>FlexiblePolyline</c>: A compact and precise encoding format for the leg geometry.
        /// For more information on the format, see the GitHub repository for <a href="https://github.com/heremaps/flexible-polyline"><c>FlexiblePolyline</c></a>.</para><para><c>Simple</c>: A less compact encoding, which is easier to decode but may be less
        /// precise and result in larger payloads.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.GeometryFormat")]
        public Amazon.GeoRoutes.GeometryFormat LegGeometryFormat { get; set; }
        #endregion
        
        #region Parameter Truck_Length
        /// <summary>
        /// <para>
        /// <para>Length of the vehicle.</para><para><b>Unit</b>: <c>c</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_Length")]
        public System.Int64? Truck_Length { get; set; }
        #endregion
        
        #region Parameter MaxAlternative
        /// <summary>
        /// <para>
        /// <para>Maximum number of alternative routes to be provided in the response, if available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxAlternatives")]
        public System.Int32? MaxAlternative { get; set; }
        #endregion
        
        #region Parameter Car_MaxSpeed
        /// <summary>
        /// <para>
        /// <para>Maximum speed specified.</para><para><b>Unit</b>: <c>KilometersPerHour</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Car_MaxSpeed")]
        public System.Double? Car_MaxSpeed { get; set; }
        #endregion
        
        #region Parameter Scooter_MaxSpeed
        /// <summary>
        /// <para>
        /// <para>Maximum speed</para><para><b>Unit</b>: <c>KilometersPerHour</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Scooter_MaxSpeed")]
        public System.Double? Scooter_MaxSpeed { get; set; }
        #endregion
        
        #region Parameter Truck_MaxSpeed
        /// <summary>
        /// <para>
        /// <para>Maximum speed</para><para><b>Unit</b>: <c>KilometersPerHour</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_MaxSpeed")]
        public System.Double? Truck_MaxSpeed { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_Matching_NameHint
        /// <summary>
        /// <para>
        /// <para>Attempts to match the provided position to a road similar to the provided name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationOptions_Matching_NameHint { get; set; }
        #endregion
        
        #region Parameter OriginOptions_Matching_NameHint
        /// <summary>
        /// <para>
        /// <para>Attempts to match the provided position to a road similar to the provided name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OriginOptions_Matching_NameHint { get; set; }
        #endregion
        
        #region Parameter Car_Occupancy
        /// <summary>
        /// <para>
        /// <para>The number of occupants in the vehicle.</para><para>Default Value: <c>1</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Car_Occupancy")]
        public System.Int32? Car_Occupancy { get; set; }
        #endregion
        
        #region Parameter Scooter_Occupancy
        /// <summary>
        /// <para>
        /// <para>The number of occupants in the vehicle.</para><para>Default Value: <c>1</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Scooter_Occupancy")]
        public System.Int32? Scooter_Occupancy { get; set; }
        #endregion
        
        #region Parameter Truck_Occupancy
        /// <summary>
        /// <para>
        /// <para>The number of occupants in the vehicle.</para><para>Default Value: <c>1</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_Occupancy")]
        public System.Int32? Truck_Occupancy { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_Matching_OnRoadThreshold
        /// <summary>
        /// <para>
        /// <para>If the distance to a highway/bridge/tunnel/sliproad is within threshold, the waypoint
        /// will be snapped to the highway/bridge/tunnel/sliproad.</para><para><b>Unit</b>: <c>meters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DestinationOptions_Matching_OnRoadThreshold { get; set; }
        #endregion
        
        #region Parameter OriginOptions_Matching_OnRoadThreshold
        /// <summary>
        /// <para>
        /// <para>If the distance to a highway/bridge/tunnel/sliproad is within threshold, the waypoint
        /// will be snapped to the highway/bridge/tunnel/sliproad.</para><para><b>Unit</b>: <c>meters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OriginOptions_Matching_OnRoadThreshold { get; set; }
        #endregion
        
        #region Parameter OptimizeRoutingFor
        /// <summary>
        /// <para>
        /// <para>Specifies the optimization criteria for calculating a route.</para><para>Default Value: <c>FastestRoute</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.RoutingObjective")]
        public Amazon.GeoRoutes.RoutingObjective OptimizeRoutingFor { get; set; }
        #endregion
        
        #region Parameter Origin
        /// <summary>
        /// <para>
        /// <para>The start position for the route.</para>
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
        public System.Double[] Origin { get; set; }
        #endregion
        
        #region Parameter Truck_PayloadCapacity
        /// <summary>
        /// <para>
        /// <para>Payload capacity of the vehicle and trailers attached.</para><para><b>Unit</b>: <c>kilograms</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_PayloadCapacity")]
        public System.Int64? Truck_PayloadCapacity { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_SideOfStreet_Position
        /// <summary>
        /// <para>
        /// <para>Position defined as <c>[longitude, latitude]</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] DestinationOptions_SideOfStreet_Position { get; set; }
        #endregion
        
        #region Parameter OriginOptions_SideOfStreet_Position
        /// <summary>
        /// <para>
        /// <para>Position defined as <c>[longitude, latitude]</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] OriginOptions_SideOfStreet_Position { get; set; }
        #endregion
        
        #region Parameter WeightPerAxleGroup_Quad
        /// <summary>
        /// <para>
        /// <para>Weight for quad axle group.</para><para><b>Unit</b>: <c>Kilograms</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_WeightPerAxleGroup_Quad")]
        public System.Int64? WeightPerAxleGroup_Quad { get; set; }
        #endregion
        
        #region Parameter WeightPerAxleGroup_Quint
        /// <summary>
        /// <para>
        /// <para>Weight for quad quint group.</para><para><b>Unit</b>: <c>Kilograms</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_WeightPerAxleGroup_Quint")]
        public System.Int64? WeightPerAxleGroup_Quint { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_Matching_Radius
        /// <summary>
        /// <para>
        /// <para>Considers all roads within the provided radius to match the provided destination to.
        /// The roads that are considered are determined by the provided Strategy.</para><para><b>Unit</b>: <c>Meters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DestinationOptions_Matching_Radius { get; set; }
        #endregion
        
        #region Parameter OriginOptions_Matching_Radius
        /// <summary>
        /// <para>
        /// <para>Considers all roads within the provided radius to match the provided destination to.
        /// The roads that are considered are determined by the provided Strategy.</para><para><b>Unit</b>: <c>Meters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OriginOptions_Matching_Radius { get; set; }
        #endregion
        
        #region Parameter Driver_Schedule
        /// <summary>
        /// <para>
        /// <para>Driver work-rest schedule. Stops are added to fulfil the provided rest schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GeoRoutes.Model.RouteDriverScheduleInterval[] Driver_Schedule { get; set; }
        #endregion
        
        #region Parameter Avoid_SeasonalClosure
        /// <summary>
        /// <para>
        /// <para>Avoid roads that have seasonal closure while calculating the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Avoid_SeasonalClosure { get; set; }
        #endregion
        
        #region Parameter WeightPerAxleGroup_Single
        /// <summary>
        /// <para>
        /// <para>Weight for single axle group.</para><para><b>Unit</b>: <c>Kilograms</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_WeightPerAxleGroup_Single")]
        public System.Int64? WeightPerAxleGroup_Single { get; set; }
        #endregion
        
        #region Parameter SpanAdditionalFeature
        /// <summary>
        /// <para>
        /// <para>A list of optional features such as SpeedLimit that can be requested for a Span. A
        /// span is a section of a Leg for which the requested features have the same values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpanAdditionalFeatures")]
        public System.String[] SpanAdditionalFeature { get; set; }
        #endregion
        
        #region Parameter Pedestrian_Speed
        /// <summary>
        /// <para>
        /// <para>Walking speed in Kilometers per hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Pedestrian_Speed")]
        public System.Double? Pedestrian_Speed { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_StopDuration
        /// <summary>
        /// <para>
        /// <para>Duration of the stop.</para><para><b>Unit</b>: <c>seconds</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DestinationOptions_StopDuration { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_Matching_Strategy
        /// <summary>
        /// <para>
        /// <para>Strategy that defines matching of the position onto the road network. MatchAny considers
        /// all roads possible, whereas MatchMostSignificantRoad matches to the most significant
        /// road.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.MatchingStrategy")]
        public Amazon.GeoRoutes.MatchingStrategy DestinationOptions_Matching_Strategy { get; set; }
        #endregion
        
        #region Parameter OriginOptions_Matching_Strategy
        /// <summary>
        /// <para>
        /// <para>Strategy that defines matching of the position onto the road network. MatchAny considers
        /// all roads possible, whereas MatchMostSignificantRoad matches to the most significant
        /// road.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.MatchingStrategy")]
        public Amazon.GeoRoutes.MatchingStrategy OriginOptions_Matching_Strategy { get; set; }
        #endregion
        
        #region Parameter WeightPerAxleGroup_Tandem
        /// <summary>
        /// <para>
        /// <para>Weight for tandem axle group.</para><para><b>Unit</b>: <c>Kilograms</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_WeightPerAxleGroup_Tandem")]
        public System.Int64? WeightPerAxleGroup_Tandem { get; set; }
        #endregion
        
        #region Parameter Truck_TireCount
        /// <summary>
        /// <para>
        /// <para>Number of tires on the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_TireCount")]
        public System.Int32? Truck_TireCount { get; set; }
        #endregion
        
        #region Parameter Avoid_TollRoad
        /// <summary>
        /// <para>
        /// <para>Avoids roads where the specified toll transponders are the only mode of payment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_TollRoads")]
        public System.Boolean? Avoid_TollRoad { get; set; }
        #endregion
        
        #region Parameter Avoid_TollTransponder
        /// <summary>
        /// <para>
        /// <para>Avoids roads where the specified toll transponders are the only mode of payment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_TollTransponders")]
        public System.Boolean? Avoid_TollTransponder { get; set; }
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
        [AWSConstantClassSource("Amazon.GeoRoutes.RouteTravelMode")]
        public Amazon.GeoRoutes.RouteTravelMode TravelMode { get; set; }
        #endregion
        
        #region Parameter TravelStepType
        /// <summary>
        /// <para>
        /// <para>Type of step returned by the response. Default provides basic steps intended for web
        /// based applications. TurnByTurn provides detailed instructions with more granularity
        /// intended for a turn based navigation system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.RouteTravelStepType")]
        public Amazon.GeoRoutes.RouteTravelStepType TravelStepType { get; set; }
        #endregion
        
        #region Parameter WeightPerAxleGroup_Triple
        /// <summary>
        /// <para>
        /// <para>Weight for triple axle group.</para><para><b>Unit</b>: <c>Kilograms</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_WeightPerAxleGroup_Triple")]
        public System.Int64? WeightPerAxleGroup_Triple { get; set; }
        #endregion
        
        #region Parameter Avoid_TruckRoadType
        /// <summary>
        /// <para>
        /// <para>Truck road type identifiers. <c>BK1</c> through <c>BK4</c> apply only to Sweden. <c>A2,A4,B2,B4,C,D,ET2,ET4</c>
        /// apply only to Mexico.</para><note><para>There are currently no other supported values as of 26th April 2024.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_TruckRoadTypes")]
        public System.String[] Avoid_TruckRoadType { get; set; }
        #endregion
        
        #region Parameter Truck_TruckType
        /// <summary>
        /// <para>
        /// <para>Type of the truck.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_TruckType")]
        [AWSConstantClassSource("Amazon.GeoRoutes.RouteTruckType")]
        public Amazon.GeoRoutes.RouteTruckType Truck_TruckType { get; set; }
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
        
        #region Parameter Avoid_Tunnel
        /// <summary>
        /// <para>
        /// <para>Avoid tunnels while calculating the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_Tunnels")]
        public System.Boolean? Avoid_Tunnel { get; set; }
        #endregion
        
        #region Parameter EmissionType_Type
        /// <summary>
        /// <para>
        /// <para>Type of the emission.</para><para><b>Valid values</b>: <c>Euro1, Euro2, Euro3, Euro4, Euro5, Euro6, EuroEev</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tolls_EmissionType_Type")]
        public System.String EmissionType_Type { get; set; }
        #endregion
        
        #region Parameter Traffic_Usage
        /// <summary>
        /// <para>
        /// <para>Determines if traffic should be used or ignored while calculating the route.</para><para>Default Value: <c>UseTrafficData</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.TrafficUsage")]
        public Amazon.GeoRoutes.TrafficUsage Traffic_Usage { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_SideOfStreet_UseWith
        /// <summary>
        /// <para>
        /// <para>Strategy that defines when the side of street position should be used.</para><para>Default Value: <c>DividedStreetOnly</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.SideOfStreetMatchingStrategy")]
        public Amazon.GeoRoutes.SideOfStreetMatchingStrategy DestinationOptions_SideOfStreet_UseWith { get; set; }
        #endregion
        
        #region Parameter OriginOptions_SideOfStreet_UseWith
        /// <summary>
        /// <para>
        /// <para>Strategy that defines when the side of street position should be used.</para><para>Default Value: <c>DividedStreetOnly</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.SideOfStreetMatchingStrategy")]
        public Amazon.GeoRoutes.SideOfStreetMatchingStrategy OriginOptions_SideOfStreet_UseWith { get; set; }
        #endregion
        
        #region Parameter Avoid_UTurn
        /// <summary>
        /// <para>
        /// <para>Avoid U-turns for calculation on highways and motorways.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_UTurns")]
        public System.Boolean? Avoid_UTurn { get; set; }
        #endregion
        
        #region Parameter Tolls_VehicleCategory
        /// <summary>
        /// <para>
        /// <para>Vehicle category for toll cost calculation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.RouteTollVehicleCategory")]
        public Amazon.GeoRoutes.RouteTollVehicleCategory Tolls_VehicleCategory { get; set; }
        #endregion
        
        #region Parameter Waypoint
        /// <summary>
        /// <para>
        /// <para>List of waypoints between the Origin and Destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Waypoints")]
        public Amazon.GeoRoutes.Model.RouteWaypoint[] Waypoint { get; set; }
        #endregion
        
        #region Parameter Truck_WeightPerAxle
        /// <summary>
        /// <para>
        /// <para>Heaviest weight per axle irrespective of the axle type or the axle group. Meant for
        /// usage in countries where the differences in axle types or axle groups are not distinguished.</para><para><b>Unit</b>: <c>Kilograms</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_WeightPerAxle")]
        public System.Int64? Truck_WeightPerAxle { get; set; }
        #endregion
        
        #region Parameter Truck_Width
        /// <summary>
        /// <para>
        /// <para>Width of the vehicle.</para><para><b>Unit</b>: <c>centimeters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_Width")]
        public System.Int64? Truck_Width { get; set; }
        #endregion
        
        #region Parameter Avoid_ZoneCategory
        /// <summary>
        /// <para>
        /// <para>Zone categories to be avoided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_ZoneCategories")]
        public Amazon.GeoRoutes.Model.RouteAvoidanceZoneCategory[] Avoid_ZoneCategory { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoRoutes.Model.CalculateRoutesResponse).
        /// Specifying the name of a property of type Amazon.GeoRoutes.Model.CalculateRoutesResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.GeoRoutes.Model.CalculateRoutesResponse, GetGEORRouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Allow_Hot = this.Allow_Hot;
            context.Allow_Hov = this.Allow_Hov;
            context.ArrivalTime = this.ArrivalTime;
            if (this.Avoid_Area != null)
            {
                context.Avoid_Area = new List<Amazon.GeoRoutes.Model.RouteAvoidanceArea>(this.Avoid_Area);
            }
            context.Avoid_CarShuttleTrain = this.Avoid_CarShuttleTrain;
            context.Avoid_ControlledAccessHighway = this.Avoid_ControlledAccessHighway;
            context.Avoid_DirtRoad = this.Avoid_DirtRoad;
            context.Avoid_Ferry = this.Avoid_Ferry;
            context.Avoid_SeasonalClosure = this.Avoid_SeasonalClosure;
            context.Avoid_TollRoad = this.Avoid_TollRoad;
            context.Avoid_TollTransponder = this.Avoid_TollTransponder;
            if (this.Avoid_TruckRoadType != null)
            {
                context.Avoid_TruckRoadType = new List<System.String>(this.Avoid_TruckRoadType);
            }
            context.Avoid_Tunnel = this.Avoid_Tunnel;
            context.Avoid_UTurn = this.Avoid_UTurn;
            if (this.Avoid_ZoneCategory != null)
            {
                context.Avoid_ZoneCategory = new List<Amazon.GeoRoutes.Model.RouteAvoidanceZoneCategory>(this.Avoid_ZoneCategory);
            }
            context.DepartNow = this.DepartNow;
            context.DepartureTime = this.DepartureTime;
            if (this.Destination != null)
            {
                context.Destination = new List<System.Double>(this.Destination);
            }
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationOptions_AvoidActionsForDistance = this.DestinationOptions_AvoidActionsForDistance;
            context.DestinationOptions_AvoidUTurn = this.DestinationOptions_AvoidUTurn;
            context.DestinationOptions_Heading = this.DestinationOptions_Heading;
            context.DestinationOptions_Matching_NameHint = this.DestinationOptions_Matching_NameHint;
            context.DestinationOptions_Matching_OnRoadThreshold = this.DestinationOptions_Matching_OnRoadThreshold;
            context.DestinationOptions_Matching_Radius = this.DestinationOptions_Matching_Radius;
            context.DestinationOptions_Matching_Strategy = this.DestinationOptions_Matching_Strategy;
            if (this.DestinationOptions_SideOfStreet_Position != null)
            {
                context.DestinationOptions_SideOfStreet_Position = new List<System.Double>(this.DestinationOptions_SideOfStreet_Position);
            }
            context.DestinationOptions_SideOfStreet_UseWith = this.DestinationOptions_SideOfStreet_UseWith;
            context.DestinationOptions_StopDuration = this.DestinationOptions_StopDuration;
            if (this.Driver_Schedule != null)
            {
                context.Driver_Schedule = new List<Amazon.GeoRoutes.Model.RouteDriverScheduleInterval>(this.Driver_Schedule);
            }
            if (this.Exclude_Country != null)
            {
                context.Exclude_Country = new List<System.String>(this.Exclude_Country);
            }
            context.InstructionsMeasurementSystem = this.InstructionsMeasurementSystem;
            context.Key = this.Key;
            if (this.Language != null)
            {
                context.Language = new List<System.String>(this.Language);
            }
            if (this.LegAdditionalFeature != null)
            {
                context.LegAdditionalFeature = new List<System.String>(this.LegAdditionalFeature);
            }
            context.LegGeometryFormat = this.LegGeometryFormat;
            context.MaxAlternative = this.MaxAlternative;
            context.OptimizeRoutingFor = this.OptimizeRoutingFor;
            if (this.Origin != null)
            {
                context.Origin = new List<System.Double>(this.Origin);
            }
            #if MODULAR
            if (this.Origin == null && ParameterWasBound(nameof(this.Origin)))
            {
                WriteWarning("You are passing $null as a value for parameter Origin which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OriginOptions_AvoidActionsForDistance = this.OriginOptions_AvoidActionsForDistance;
            context.OriginOptions_AvoidUTurn = this.OriginOptions_AvoidUTurn;
            context.OriginOptions_Heading = this.OriginOptions_Heading;
            context.OriginOptions_Matching_NameHint = this.OriginOptions_Matching_NameHint;
            context.OriginOptions_Matching_OnRoadThreshold = this.OriginOptions_Matching_OnRoadThreshold;
            context.OriginOptions_Matching_Radius = this.OriginOptions_Matching_Radius;
            context.OriginOptions_Matching_Strategy = this.OriginOptions_Matching_Strategy;
            if (this.OriginOptions_SideOfStreet_Position != null)
            {
                context.OriginOptions_SideOfStreet_Position = new List<System.Double>(this.OriginOptions_SideOfStreet_Position);
            }
            context.OriginOptions_SideOfStreet_UseWith = this.OriginOptions_SideOfStreet_UseWith;
            if (this.SpanAdditionalFeature != null)
            {
                context.SpanAdditionalFeature = new List<System.String>(this.SpanAdditionalFeature);
            }
            context.Tolls_AllTransponder = this.Tolls_AllTransponder;
            context.Tolls_AllVignette = this.Tolls_AllVignette;
            context.Tolls_Currency = this.Tolls_Currency;
            context.EmissionType_Co2EmissionClass = this.EmissionType_Co2EmissionClass;
            context.EmissionType_Type = this.EmissionType_Type;
            context.Tolls_VehicleCategory = this.Tolls_VehicleCategory;
            context.Traffic_FlowEventThresholdOverride = this.Traffic_FlowEventThresholdOverride;
            context.Traffic_Usage = this.Traffic_Usage;
            context.TravelMode = this.TravelMode;
            context.Car_EngineType = this.Car_EngineType;
            context.TravelModeOptions_Car_LicensePlate_LastCharacter = this.TravelModeOptions_Car_LicensePlate_LastCharacter;
            context.Car_MaxSpeed = this.Car_MaxSpeed;
            context.Car_Occupancy = this.Car_Occupancy;
            context.Pedestrian_Speed = this.Pedestrian_Speed;
            context.Scooter_EngineType = this.Scooter_EngineType;
            context.TravelModeOptions_Scooter_LicensePlate_LastCharacter = this.TravelModeOptions_Scooter_LicensePlate_LastCharacter;
            context.Scooter_MaxSpeed = this.Scooter_MaxSpeed;
            context.Scooter_Occupancy = this.Scooter_Occupancy;
            context.Truck_AxleCount = this.Truck_AxleCount;
            context.Truck_EngineType = this.Truck_EngineType;
            context.Truck_GrossWeight = this.Truck_GrossWeight;
            if (this.Truck_HazardousCargo != null)
            {
                context.Truck_HazardousCargo = new List<System.String>(this.Truck_HazardousCargo);
            }
            context.Truck_Height = this.Truck_Height;
            context.Truck_HeightAboveFirstAxle = this.Truck_HeightAboveFirstAxle;
            context.Truck_KpraLength = this.Truck_KpraLength;
            context.Truck_Length = this.Truck_Length;
            context.TravelModeOptions_Truck_LicensePlate_LastCharacter = this.TravelModeOptions_Truck_LicensePlate_LastCharacter;
            context.Truck_MaxSpeed = this.Truck_MaxSpeed;
            context.Truck_Occupancy = this.Truck_Occupancy;
            context.Truck_PayloadCapacity = this.Truck_PayloadCapacity;
            context.Truck_TireCount = this.Truck_TireCount;
            context.Trailer_AxleCount = this.Trailer_AxleCount;
            context.Trailer_TrailerCount = this.Trailer_TrailerCount;
            context.Truck_TruckType = this.Truck_TruckType;
            context.Truck_TunnelRestrictionCode = this.Truck_TunnelRestrictionCode;
            context.Truck_WeightPerAxle = this.Truck_WeightPerAxle;
            context.WeightPerAxleGroup_Quad = this.WeightPerAxleGroup_Quad;
            context.WeightPerAxleGroup_Quint = this.WeightPerAxleGroup_Quint;
            context.WeightPerAxleGroup_Single = this.WeightPerAxleGroup_Single;
            context.WeightPerAxleGroup_Tandem = this.WeightPerAxleGroup_Tandem;
            context.WeightPerAxleGroup_Triple = this.WeightPerAxleGroup_Triple;
            context.Truck_Width = this.Truck_Width;
            context.TravelStepType = this.TravelStepType;
            if (this.Waypoint != null)
            {
                context.Waypoint = new List<Amazon.GeoRoutes.Model.RouteWaypoint>(this.Waypoint);
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
            var request = new Amazon.GeoRoutes.Model.CalculateRoutesRequest();
            
            
             // populate Allow
            var requestAllowIsNull = true;
            request.Allow = new Amazon.GeoRoutes.Model.RouteAllowOptions();
            System.Boolean? requestAllow_allow_Hot = null;
            if (cmdletContext.Allow_Hot != null)
            {
                requestAllow_allow_Hot = cmdletContext.Allow_Hot.Value;
            }
            if (requestAllow_allow_Hot != null)
            {
                request.Allow.Hot = requestAllow_allow_Hot.Value;
                requestAllowIsNull = false;
            }
            System.Boolean? requestAllow_allow_Hov = null;
            if (cmdletContext.Allow_Hov != null)
            {
                requestAllow_allow_Hov = cmdletContext.Allow_Hov.Value;
            }
            if (requestAllow_allow_Hov != null)
            {
                request.Allow.Hov = requestAllow_allow_Hov.Value;
                requestAllowIsNull = false;
            }
             // determine if request.Allow should be set to null
            if (requestAllowIsNull)
            {
                request.Allow = null;
            }
            if (cmdletContext.ArrivalTime != null)
            {
                request.ArrivalTime = cmdletContext.ArrivalTime;
            }
            
             // populate Avoid
            var requestAvoidIsNull = true;
            request.Avoid = new Amazon.GeoRoutes.Model.RouteAvoidanceOptions();
            List<Amazon.GeoRoutes.Model.RouteAvoidanceArea> requestAvoid_avoid_Area = null;
            if (cmdletContext.Avoid_Area != null)
            {
                requestAvoid_avoid_Area = cmdletContext.Avoid_Area;
            }
            if (requestAvoid_avoid_Area != null)
            {
                request.Avoid.Areas = requestAvoid_avoid_Area;
                requestAvoidIsNull = false;
            }
            System.Boolean? requestAvoid_avoid_CarShuttleTrain = null;
            if (cmdletContext.Avoid_CarShuttleTrain != null)
            {
                requestAvoid_avoid_CarShuttleTrain = cmdletContext.Avoid_CarShuttleTrain.Value;
            }
            if (requestAvoid_avoid_CarShuttleTrain != null)
            {
                request.Avoid.CarShuttleTrains = requestAvoid_avoid_CarShuttleTrain.Value;
                requestAvoidIsNull = false;
            }
            System.Boolean? requestAvoid_avoid_ControlledAccessHighway = null;
            if (cmdletContext.Avoid_ControlledAccessHighway != null)
            {
                requestAvoid_avoid_ControlledAccessHighway = cmdletContext.Avoid_ControlledAccessHighway.Value;
            }
            if (requestAvoid_avoid_ControlledAccessHighway != null)
            {
                request.Avoid.ControlledAccessHighways = requestAvoid_avoid_ControlledAccessHighway.Value;
                requestAvoidIsNull = false;
            }
            System.Boolean? requestAvoid_avoid_DirtRoad = null;
            if (cmdletContext.Avoid_DirtRoad != null)
            {
                requestAvoid_avoid_DirtRoad = cmdletContext.Avoid_DirtRoad.Value;
            }
            if (requestAvoid_avoid_DirtRoad != null)
            {
                request.Avoid.DirtRoads = requestAvoid_avoid_DirtRoad.Value;
                requestAvoidIsNull = false;
            }
            System.Boolean? requestAvoid_avoid_Ferry = null;
            if (cmdletContext.Avoid_Ferry != null)
            {
                requestAvoid_avoid_Ferry = cmdletContext.Avoid_Ferry.Value;
            }
            if (requestAvoid_avoid_Ferry != null)
            {
                request.Avoid.Ferries = requestAvoid_avoid_Ferry.Value;
                requestAvoidIsNull = false;
            }
            System.Boolean? requestAvoid_avoid_SeasonalClosure = null;
            if (cmdletContext.Avoid_SeasonalClosure != null)
            {
                requestAvoid_avoid_SeasonalClosure = cmdletContext.Avoid_SeasonalClosure.Value;
            }
            if (requestAvoid_avoid_SeasonalClosure != null)
            {
                request.Avoid.SeasonalClosure = requestAvoid_avoid_SeasonalClosure.Value;
                requestAvoidIsNull = false;
            }
            System.Boolean? requestAvoid_avoid_TollRoad = null;
            if (cmdletContext.Avoid_TollRoad != null)
            {
                requestAvoid_avoid_TollRoad = cmdletContext.Avoid_TollRoad.Value;
            }
            if (requestAvoid_avoid_TollRoad != null)
            {
                request.Avoid.TollRoads = requestAvoid_avoid_TollRoad.Value;
                requestAvoidIsNull = false;
            }
            System.Boolean? requestAvoid_avoid_TollTransponder = null;
            if (cmdletContext.Avoid_TollTransponder != null)
            {
                requestAvoid_avoid_TollTransponder = cmdletContext.Avoid_TollTransponder.Value;
            }
            if (requestAvoid_avoid_TollTransponder != null)
            {
                request.Avoid.TollTransponders = requestAvoid_avoid_TollTransponder.Value;
                requestAvoidIsNull = false;
            }
            List<System.String> requestAvoid_avoid_TruckRoadType = null;
            if (cmdletContext.Avoid_TruckRoadType != null)
            {
                requestAvoid_avoid_TruckRoadType = cmdletContext.Avoid_TruckRoadType;
            }
            if (requestAvoid_avoid_TruckRoadType != null)
            {
                request.Avoid.TruckRoadTypes = requestAvoid_avoid_TruckRoadType;
                requestAvoidIsNull = false;
            }
            System.Boolean? requestAvoid_avoid_Tunnel = null;
            if (cmdletContext.Avoid_Tunnel != null)
            {
                requestAvoid_avoid_Tunnel = cmdletContext.Avoid_Tunnel.Value;
            }
            if (requestAvoid_avoid_Tunnel != null)
            {
                request.Avoid.Tunnels = requestAvoid_avoid_Tunnel.Value;
                requestAvoidIsNull = false;
            }
            System.Boolean? requestAvoid_avoid_UTurn = null;
            if (cmdletContext.Avoid_UTurn != null)
            {
                requestAvoid_avoid_UTurn = cmdletContext.Avoid_UTurn.Value;
            }
            if (requestAvoid_avoid_UTurn != null)
            {
                request.Avoid.UTurns = requestAvoid_avoid_UTurn.Value;
                requestAvoidIsNull = false;
            }
            List<Amazon.GeoRoutes.Model.RouteAvoidanceZoneCategory> requestAvoid_avoid_ZoneCategory = null;
            if (cmdletContext.Avoid_ZoneCategory != null)
            {
                requestAvoid_avoid_ZoneCategory = cmdletContext.Avoid_ZoneCategory;
            }
            if (requestAvoid_avoid_ZoneCategory != null)
            {
                request.Avoid.ZoneCategories = requestAvoid_avoid_ZoneCategory;
                requestAvoidIsNull = false;
            }
             // determine if request.Avoid should be set to null
            if (requestAvoidIsNull)
            {
                request.Avoid = null;
            }
            if (cmdletContext.DepartNow != null)
            {
                request.DepartNow = cmdletContext.DepartNow.Value;
            }
            if (cmdletContext.DepartureTime != null)
            {
                request.DepartureTime = cmdletContext.DepartureTime;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            
             // populate DestinationOptions
            var requestDestinationOptionsIsNull = true;
            request.DestinationOptions = new Amazon.GeoRoutes.Model.RouteDestinationOptions();
            System.Int64? requestDestinationOptions_destinationOptions_AvoidActionsForDistance = null;
            if (cmdletContext.DestinationOptions_AvoidActionsForDistance != null)
            {
                requestDestinationOptions_destinationOptions_AvoidActionsForDistance = cmdletContext.DestinationOptions_AvoidActionsForDistance.Value;
            }
            if (requestDestinationOptions_destinationOptions_AvoidActionsForDistance != null)
            {
                request.DestinationOptions.AvoidActionsForDistance = requestDestinationOptions_destinationOptions_AvoidActionsForDistance.Value;
                requestDestinationOptionsIsNull = false;
            }
            System.Boolean? requestDestinationOptions_destinationOptions_AvoidUTurn = null;
            if (cmdletContext.DestinationOptions_AvoidUTurn != null)
            {
                requestDestinationOptions_destinationOptions_AvoidUTurn = cmdletContext.DestinationOptions_AvoidUTurn.Value;
            }
            if (requestDestinationOptions_destinationOptions_AvoidUTurn != null)
            {
                request.DestinationOptions.AvoidUTurns = requestDestinationOptions_destinationOptions_AvoidUTurn.Value;
                requestDestinationOptionsIsNull = false;
            }
            System.Double? requestDestinationOptions_destinationOptions_Heading = null;
            if (cmdletContext.DestinationOptions_Heading != null)
            {
                requestDestinationOptions_destinationOptions_Heading = cmdletContext.DestinationOptions_Heading.Value;
            }
            if (requestDestinationOptions_destinationOptions_Heading != null)
            {
                request.DestinationOptions.Heading = requestDestinationOptions_destinationOptions_Heading.Value;
                requestDestinationOptionsIsNull = false;
            }
            System.Int64? requestDestinationOptions_destinationOptions_StopDuration = null;
            if (cmdletContext.DestinationOptions_StopDuration != null)
            {
                requestDestinationOptions_destinationOptions_StopDuration = cmdletContext.DestinationOptions_StopDuration.Value;
            }
            if (requestDestinationOptions_destinationOptions_StopDuration != null)
            {
                request.DestinationOptions.StopDuration = requestDestinationOptions_destinationOptions_StopDuration.Value;
                requestDestinationOptionsIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteSideOfStreetOptions requestDestinationOptions_destinationOptions_SideOfStreet = null;
            
             // populate SideOfStreet
            var requestDestinationOptions_destinationOptions_SideOfStreetIsNull = true;
            requestDestinationOptions_destinationOptions_SideOfStreet = new Amazon.GeoRoutes.Model.RouteSideOfStreetOptions();
            List<System.Double> requestDestinationOptions_destinationOptions_SideOfStreet_destinationOptions_SideOfStreet_Position = null;
            if (cmdletContext.DestinationOptions_SideOfStreet_Position != null)
            {
                requestDestinationOptions_destinationOptions_SideOfStreet_destinationOptions_SideOfStreet_Position = cmdletContext.DestinationOptions_SideOfStreet_Position;
            }
            if (requestDestinationOptions_destinationOptions_SideOfStreet_destinationOptions_SideOfStreet_Position != null)
            {
                requestDestinationOptions_destinationOptions_SideOfStreet.Position = requestDestinationOptions_destinationOptions_SideOfStreet_destinationOptions_SideOfStreet_Position;
                requestDestinationOptions_destinationOptions_SideOfStreetIsNull = false;
            }
            Amazon.GeoRoutes.SideOfStreetMatchingStrategy requestDestinationOptions_destinationOptions_SideOfStreet_destinationOptions_SideOfStreet_UseWith = null;
            if (cmdletContext.DestinationOptions_SideOfStreet_UseWith != null)
            {
                requestDestinationOptions_destinationOptions_SideOfStreet_destinationOptions_SideOfStreet_UseWith = cmdletContext.DestinationOptions_SideOfStreet_UseWith;
            }
            if (requestDestinationOptions_destinationOptions_SideOfStreet_destinationOptions_SideOfStreet_UseWith != null)
            {
                requestDestinationOptions_destinationOptions_SideOfStreet.UseWith = requestDestinationOptions_destinationOptions_SideOfStreet_destinationOptions_SideOfStreet_UseWith;
                requestDestinationOptions_destinationOptions_SideOfStreetIsNull = false;
            }
             // determine if requestDestinationOptions_destinationOptions_SideOfStreet should be set to null
            if (requestDestinationOptions_destinationOptions_SideOfStreetIsNull)
            {
                requestDestinationOptions_destinationOptions_SideOfStreet = null;
            }
            if (requestDestinationOptions_destinationOptions_SideOfStreet != null)
            {
                request.DestinationOptions.SideOfStreet = requestDestinationOptions_destinationOptions_SideOfStreet;
                requestDestinationOptionsIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteMatchingOptions requestDestinationOptions_destinationOptions_Matching = null;
            
             // populate Matching
            var requestDestinationOptions_destinationOptions_MatchingIsNull = true;
            requestDestinationOptions_destinationOptions_Matching = new Amazon.GeoRoutes.Model.RouteMatchingOptions();
            System.String requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_NameHint = null;
            if (cmdletContext.DestinationOptions_Matching_NameHint != null)
            {
                requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_NameHint = cmdletContext.DestinationOptions_Matching_NameHint;
            }
            if (requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_NameHint != null)
            {
                requestDestinationOptions_destinationOptions_Matching.NameHint = requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_NameHint;
                requestDestinationOptions_destinationOptions_MatchingIsNull = false;
            }
            System.Int64? requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_OnRoadThreshold = null;
            if (cmdletContext.DestinationOptions_Matching_OnRoadThreshold != null)
            {
                requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_OnRoadThreshold = cmdletContext.DestinationOptions_Matching_OnRoadThreshold.Value;
            }
            if (requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_OnRoadThreshold != null)
            {
                requestDestinationOptions_destinationOptions_Matching.OnRoadThreshold = requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_OnRoadThreshold.Value;
                requestDestinationOptions_destinationOptions_MatchingIsNull = false;
            }
            System.Int64? requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_Radius = null;
            if (cmdletContext.DestinationOptions_Matching_Radius != null)
            {
                requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_Radius = cmdletContext.DestinationOptions_Matching_Radius.Value;
            }
            if (requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_Radius != null)
            {
                requestDestinationOptions_destinationOptions_Matching.Radius = requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_Radius.Value;
                requestDestinationOptions_destinationOptions_MatchingIsNull = false;
            }
            Amazon.GeoRoutes.MatchingStrategy requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_Strategy = null;
            if (cmdletContext.DestinationOptions_Matching_Strategy != null)
            {
                requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_Strategy = cmdletContext.DestinationOptions_Matching_Strategy;
            }
            if (requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_Strategy != null)
            {
                requestDestinationOptions_destinationOptions_Matching.Strategy = requestDestinationOptions_destinationOptions_Matching_destinationOptions_Matching_Strategy;
                requestDestinationOptions_destinationOptions_MatchingIsNull = false;
            }
             // determine if requestDestinationOptions_destinationOptions_Matching should be set to null
            if (requestDestinationOptions_destinationOptions_MatchingIsNull)
            {
                requestDestinationOptions_destinationOptions_Matching = null;
            }
            if (requestDestinationOptions_destinationOptions_Matching != null)
            {
                request.DestinationOptions.Matching = requestDestinationOptions_destinationOptions_Matching;
                requestDestinationOptionsIsNull = false;
            }
             // determine if request.DestinationOptions should be set to null
            if (requestDestinationOptionsIsNull)
            {
                request.DestinationOptions = null;
            }
            
             // populate Driver
            var requestDriverIsNull = true;
            request.Driver = new Amazon.GeoRoutes.Model.RouteDriverOptions();
            List<Amazon.GeoRoutes.Model.RouteDriverScheduleInterval> requestDriver_driver_Schedule = null;
            if (cmdletContext.Driver_Schedule != null)
            {
                requestDriver_driver_Schedule = cmdletContext.Driver_Schedule;
            }
            if (requestDriver_driver_Schedule != null)
            {
                request.Driver.Schedule = requestDriver_driver_Schedule;
                requestDriverIsNull = false;
            }
             // determine if request.Driver should be set to null
            if (requestDriverIsNull)
            {
                request.Driver = null;
            }
            
             // populate Exclude
            var requestExcludeIsNull = true;
            request.Exclude = new Amazon.GeoRoutes.Model.RouteExclusionOptions();
            List<System.String> requestExclude_exclude_Country = null;
            if (cmdletContext.Exclude_Country != null)
            {
                requestExclude_exclude_Country = cmdletContext.Exclude_Country;
            }
            if (requestExclude_exclude_Country != null)
            {
                request.Exclude.Countries = requestExclude_exclude_Country;
                requestExcludeIsNull = false;
            }
             // determine if request.Exclude should be set to null
            if (requestExcludeIsNull)
            {
                request.Exclude = null;
            }
            if (cmdletContext.InstructionsMeasurementSystem != null)
            {
                request.InstructionsMeasurementSystem = cmdletContext.InstructionsMeasurementSystem;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.Language != null)
            {
                request.Languages = cmdletContext.Language;
            }
            if (cmdletContext.LegAdditionalFeature != null)
            {
                request.LegAdditionalFeatures = cmdletContext.LegAdditionalFeature;
            }
            if (cmdletContext.LegGeometryFormat != null)
            {
                request.LegGeometryFormat = cmdletContext.LegGeometryFormat;
            }
            if (cmdletContext.MaxAlternative != null)
            {
                request.MaxAlternatives = cmdletContext.MaxAlternative.Value;
            }
            if (cmdletContext.OptimizeRoutingFor != null)
            {
                request.OptimizeRoutingFor = cmdletContext.OptimizeRoutingFor;
            }
            if (cmdletContext.Origin != null)
            {
                request.Origin = cmdletContext.Origin;
            }
            
             // populate OriginOptions
            var requestOriginOptionsIsNull = true;
            request.OriginOptions = new Amazon.GeoRoutes.Model.RouteOriginOptions();
            System.Int64? requestOriginOptions_originOptions_AvoidActionsForDistance = null;
            if (cmdletContext.OriginOptions_AvoidActionsForDistance != null)
            {
                requestOriginOptions_originOptions_AvoidActionsForDistance = cmdletContext.OriginOptions_AvoidActionsForDistance.Value;
            }
            if (requestOriginOptions_originOptions_AvoidActionsForDistance != null)
            {
                request.OriginOptions.AvoidActionsForDistance = requestOriginOptions_originOptions_AvoidActionsForDistance.Value;
                requestOriginOptionsIsNull = false;
            }
            System.Boolean? requestOriginOptions_originOptions_AvoidUTurn = null;
            if (cmdletContext.OriginOptions_AvoidUTurn != null)
            {
                requestOriginOptions_originOptions_AvoidUTurn = cmdletContext.OriginOptions_AvoidUTurn.Value;
            }
            if (requestOriginOptions_originOptions_AvoidUTurn != null)
            {
                request.OriginOptions.AvoidUTurns = requestOriginOptions_originOptions_AvoidUTurn.Value;
                requestOriginOptionsIsNull = false;
            }
            System.Double? requestOriginOptions_originOptions_Heading = null;
            if (cmdletContext.OriginOptions_Heading != null)
            {
                requestOriginOptions_originOptions_Heading = cmdletContext.OriginOptions_Heading.Value;
            }
            if (requestOriginOptions_originOptions_Heading != null)
            {
                request.OriginOptions.Heading = requestOriginOptions_originOptions_Heading.Value;
                requestOriginOptionsIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteSideOfStreetOptions requestOriginOptions_originOptions_SideOfStreet = null;
            
             // populate SideOfStreet
            var requestOriginOptions_originOptions_SideOfStreetIsNull = true;
            requestOriginOptions_originOptions_SideOfStreet = new Amazon.GeoRoutes.Model.RouteSideOfStreetOptions();
            List<System.Double> requestOriginOptions_originOptions_SideOfStreet_originOptions_SideOfStreet_Position = null;
            if (cmdletContext.OriginOptions_SideOfStreet_Position != null)
            {
                requestOriginOptions_originOptions_SideOfStreet_originOptions_SideOfStreet_Position = cmdletContext.OriginOptions_SideOfStreet_Position;
            }
            if (requestOriginOptions_originOptions_SideOfStreet_originOptions_SideOfStreet_Position != null)
            {
                requestOriginOptions_originOptions_SideOfStreet.Position = requestOriginOptions_originOptions_SideOfStreet_originOptions_SideOfStreet_Position;
                requestOriginOptions_originOptions_SideOfStreetIsNull = false;
            }
            Amazon.GeoRoutes.SideOfStreetMatchingStrategy requestOriginOptions_originOptions_SideOfStreet_originOptions_SideOfStreet_UseWith = null;
            if (cmdletContext.OriginOptions_SideOfStreet_UseWith != null)
            {
                requestOriginOptions_originOptions_SideOfStreet_originOptions_SideOfStreet_UseWith = cmdletContext.OriginOptions_SideOfStreet_UseWith;
            }
            if (requestOriginOptions_originOptions_SideOfStreet_originOptions_SideOfStreet_UseWith != null)
            {
                requestOriginOptions_originOptions_SideOfStreet.UseWith = requestOriginOptions_originOptions_SideOfStreet_originOptions_SideOfStreet_UseWith;
                requestOriginOptions_originOptions_SideOfStreetIsNull = false;
            }
             // determine if requestOriginOptions_originOptions_SideOfStreet should be set to null
            if (requestOriginOptions_originOptions_SideOfStreetIsNull)
            {
                requestOriginOptions_originOptions_SideOfStreet = null;
            }
            if (requestOriginOptions_originOptions_SideOfStreet != null)
            {
                request.OriginOptions.SideOfStreet = requestOriginOptions_originOptions_SideOfStreet;
                requestOriginOptionsIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteMatchingOptions requestOriginOptions_originOptions_Matching = null;
            
             // populate Matching
            var requestOriginOptions_originOptions_MatchingIsNull = true;
            requestOriginOptions_originOptions_Matching = new Amazon.GeoRoutes.Model.RouteMatchingOptions();
            System.String requestOriginOptions_originOptions_Matching_originOptions_Matching_NameHint = null;
            if (cmdletContext.OriginOptions_Matching_NameHint != null)
            {
                requestOriginOptions_originOptions_Matching_originOptions_Matching_NameHint = cmdletContext.OriginOptions_Matching_NameHint;
            }
            if (requestOriginOptions_originOptions_Matching_originOptions_Matching_NameHint != null)
            {
                requestOriginOptions_originOptions_Matching.NameHint = requestOriginOptions_originOptions_Matching_originOptions_Matching_NameHint;
                requestOriginOptions_originOptions_MatchingIsNull = false;
            }
            System.Int64? requestOriginOptions_originOptions_Matching_originOptions_Matching_OnRoadThreshold = null;
            if (cmdletContext.OriginOptions_Matching_OnRoadThreshold != null)
            {
                requestOriginOptions_originOptions_Matching_originOptions_Matching_OnRoadThreshold = cmdletContext.OriginOptions_Matching_OnRoadThreshold.Value;
            }
            if (requestOriginOptions_originOptions_Matching_originOptions_Matching_OnRoadThreshold != null)
            {
                requestOriginOptions_originOptions_Matching.OnRoadThreshold = requestOriginOptions_originOptions_Matching_originOptions_Matching_OnRoadThreshold.Value;
                requestOriginOptions_originOptions_MatchingIsNull = false;
            }
            System.Int64? requestOriginOptions_originOptions_Matching_originOptions_Matching_Radius = null;
            if (cmdletContext.OriginOptions_Matching_Radius != null)
            {
                requestOriginOptions_originOptions_Matching_originOptions_Matching_Radius = cmdletContext.OriginOptions_Matching_Radius.Value;
            }
            if (requestOriginOptions_originOptions_Matching_originOptions_Matching_Radius != null)
            {
                requestOriginOptions_originOptions_Matching.Radius = requestOriginOptions_originOptions_Matching_originOptions_Matching_Radius.Value;
                requestOriginOptions_originOptions_MatchingIsNull = false;
            }
            Amazon.GeoRoutes.MatchingStrategy requestOriginOptions_originOptions_Matching_originOptions_Matching_Strategy = null;
            if (cmdletContext.OriginOptions_Matching_Strategy != null)
            {
                requestOriginOptions_originOptions_Matching_originOptions_Matching_Strategy = cmdletContext.OriginOptions_Matching_Strategy;
            }
            if (requestOriginOptions_originOptions_Matching_originOptions_Matching_Strategy != null)
            {
                requestOriginOptions_originOptions_Matching.Strategy = requestOriginOptions_originOptions_Matching_originOptions_Matching_Strategy;
                requestOriginOptions_originOptions_MatchingIsNull = false;
            }
             // determine if requestOriginOptions_originOptions_Matching should be set to null
            if (requestOriginOptions_originOptions_MatchingIsNull)
            {
                requestOriginOptions_originOptions_Matching = null;
            }
            if (requestOriginOptions_originOptions_Matching != null)
            {
                request.OriginOptions.Matching = requestOriginOptions_originOptions_Matching;
                requestOriginOptionsIsNull = false;
            }
             // determine if request.OriginOptions should be set to null
            if (requestOriginOptionsIsNull)
            {
                request.OriginOptions = null;
            }
            if (cmdletContext.SpanAdditionalFeature != null)
            {
                request.SpanAdditionalFeatures = cmdletContext.SpanAdditionalFeature;
            }
            
             // populate Tolls
            var requestTollsIsNull = true;
            request.Tolls = new Amazon.GeoRoutes.Model.RouteTollOptions();
            System.Boolean? requestTolls_tolls_AllTransponder = null;
            if (cmdletContext.Tolls_AllTransponder != null)
            {
                requestTolls_tolls_AllTransponder = cmdletContext.Tolls_AllTransponder.Value;
            }
            if (requestTolls_tolls_AllTransponder != null)
            {
                request.Tolls.AllTransponders = requestTolls_tolls_AllTransponder.Value;
                requestTollsIsNull = false;
            }
            System.Boolean? requestTolls_tolls_AllVignette = null;
            if (cmdletContext.Tolls_AllVignette != null)
            {
                requestTolls_tolls_AllVignette = cmdletContext.Tolls_AllVignette.Value;
            }
            if (requestTolls_tolls_AllVignette != null)
            {
                request.Tolls.AllVignettes = requestTolls_tolls_AllVignette.Value;
                requestTollsIsNull = false;
            }
            System.String requestTolls_tolls_Currency = null;
            if (cmdletContext.Tolls_Currency != null)
            {
                requestTolls_tolls_Currency = cmdletContext.Tolls_Currency;
            }
            if (requestTolls_tolls_Currency != null)
            {
                request.Tolls.Currency = requestTolls_tolls_Currency;
                requestTollsIsNull = false;
            }
            Amazon.GeoRoutes.RouteTollVehicleCategory requestTolls_tolls_VehicleCategory = null;
            if (cmdletContext.Tolls_VehicleCategory != null)
            {
                requestTolls_tolls_VehicleCategory = cmdletContext.Tolls_VehicleCategory;
            }
            if (requestTolls_tolls_VehicleCategory != null)
            {
                request.Tolls.VehicleCategory = requestTolls_tolls_VehicleCategory;
                requestTollsIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteEmissionType requestTolls_tolls_EmissionType = null;
            
             // populate EmissionType
            var requestTolls_tolls_EmissionTypeIsNull = true;
            requestTolls_tolls_EmissionType = new Amazon.GeoRoutes.Model.RouteEmissionType();
            System.String requestTolls_tolls_EmissionType_emissionType_Co2EmissionClass = null;
            if (cmdletContext.EmissionType_Co2EmissionClass != null)
            {
                requestTolls_tolls_EmissionType_emissionType_Co2EmissionClass = cmdletContext.EmissionType_Co2EmissionClass;
            }
            if (requestTolls_tolls_EmissionType_emissionType_Co2EmissionClass != null)
            {
                requestTolls_tolls_EmissionType.Co2EmissionClass = requestTolls_tolls_EmissionType_emissionType_Co2EmissionClass;
                requestTolls_tolls_EmissionTypeIsNull = false;
            }
            System.String requestTolls_tolls_EmissionType_emissionType_Type = null;
            if (cmdletContext.EmissionType_Type != null)
            {
                requestTolls_tolls_EmissionType_emissionType_Type = cmdletContext.EmissionType_Type;
            }
            if (requestTolls_tolls_EmissionType_emissionType_Type != null)
            {
                requestTolls_tolls_EmissionType.Type = requestTolls_tolls_EmissionType_emissionType_Type;
                requestTolls_tolls_EmissionTypeIsNull = false;
            }
             // determine if requestTolls_tolls_EmissionType should be set to null
            if (requestTolls_tolls_EmissionTypeIsNull)
            {
                requestTolls_tolls_EmissionType = null;
            }
            if (requestTolls_tolls_EmissionType != null)
            {
                request.Tolls.EmissionType = requestTolls_tolls_EmissionType;
                requestTollsIsNull = false;
            }
             // determine if request.Tolls should be set to null
            if (requestTollsIsNull)
            {
                request.Tolls = null;
            }
            
             // populate Traffic
            var requestTrafficIsNull = true;
            request.Traffic = new Amazon.GeoRoutes.Model.RouteTrafficOptions();
            System.Int64? requestTraffic_traffic_FlowEventThresholdOverride = null;
            if (cmdletContext.Traffic_FlowEventThresholdOverride != null)
            {
                requestTraffic_traffic_FlowEventThresholdOverride = cmdletContext.Traffic_FlowEventThresholdOverride.Value;
            }
            if (requestTraffic_traffic_FlowEventThresholdOverride != null)
            {
                request.Traffic.FlowEventThresholdOverride = requestTraffic_traffic_FlowEventThresholdOverride.Value;
                requestTrafficIsNull = false;
            }
            Amazon.GeoRoutes.TrafficUsage requestTraffic_traffic_Usage = null;
            if (cmdletContext.Traffic_Usage != null)
            {
                requestTraffic_traffic_Usage = cmdletContext.Traffic_Usage;
            }
            if (requestTraffic_traffic_Usage != null)
            {
                request.Traffic.Usage = requestTraffic_traffic_Usage;
                requestTrafficIsNull = false;
            }
             // determine if request.Traffic should be set to null
            if (requestTrafficIsNull)
            {
                request.Traffic = null;
            }
            if (cmdletContext.TravelMode != null)
            {
                request.TravelMode = cmdletContext.TravelMode;
            }
            
             // populate TravelModeOptions
            var requestTravelModeOptionsIsNull = true;
            request.TravelModeOptions = new Amazon.GeoRoutes.Model.RouteTravelModeOptions();
            Amazon.GeoRoutes.Model.RoutePedestrianOptions requestTravelModeOptions_travelModeOptions_Pedestrian = null;
            
             // populate Pedestrian
            var requestTravelModeOptions_travelModeOptions_PedestrianIsNull = true;
            requestTravelModeOptions_travelModeOptions_Pedestrian = new Amazon.GeoRoutes.Model.RoutePedestrianOptions();
            System.Double? requestTravelModeOptions_travelModeOptions_Pedestrian_pedestrian_Speed = null;
            if (cmdletContext.Pedestrian_Speed != null)
            {
                requestTravelModeOptions_travelModeOptions_Pedestrian_pedestrian_Speed = cmdletContext.Pedestrian_Speed.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Pedestrian_pedestrian_Speed != null)
            {
                requestTravelModeOptions_travelModeOptions_Pedestrian.Speed = requestTravelModeOptions_travelModeOptions_Pedestrian_pedestrian_Speed.Value;
                requestTravelModeOptions_travelModeOptions_PedestrianIsNull = false;
            }
             // determine if requestTravelModeOptions_travelModeOptions_Pedestrian should be set to null
            if (requestTravelModeOptions_travelModeOptions_PedestrianIsNull)
            {
                requestTravelModeOptions_travelModeOptions_Pedestrian = null;
            }
            if (requestTravelModeOptions_travelModeOptions_Pedestrian != null)
            {
                request.TravelModeOptions.Pedestrian = requestTravelModeOptions_travelModeOptions_Pedestrian;
                requestTravelModeOptionsIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteCarOptions requestTravelModeOptions_travelModeOptions_Car = null;
            
             // populate Car
            var requestTravelModeOptions_travelModeOptions_CarIsNull = true;
            requestTravelModeOptions_travelModeOptions_Car = new Amazon.GeoRoutes.Model.RouteCarOptions();
            Amazon.GeoRoutes.RouteEngineType requestTravelModeOptions_travelModeOptions_Car_car_EngineType = null;
            if (cmdletContext.Car_EngineType != null)
            {
                requestTravelModeOptions_travelModeOptions_Car_car_EngineType = cmdletContext.Car_EngineType;
            }
            if (requestTravelModeOptions_travelModeOptions_Car_car_EngineType != null)
            {
                requestTravelModeOptions_travelModeOptions_Car.EngineType = requestTravelModeOptions_travelModeOptions_Car_car_EngineType;
                requestTravelModeOptions_travelModeOptions_CarIsNull = false;
            }
            System.Double? requestTravelModeOptions_travelModeOptions_Car_car_MaxSpeed = null;
            if (cmdletContext.Car_MaxSpeed != null)
            {
                requestTravelModeOptions_travelModeOptions_Car_car_MaxSpeed = cmdletContext.Car_MaxSpeed.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Car_car_MaxSpeed != null)
            {
                requestTravelModeOptions_travelModeOptions_Car.MaxSpeed = requestTravelModeOptions_travelModeOptions_Car_car_MaxSpeed.Value;
                requestTravelModeOptions_travelModeOptions_CarIsNull = false;
            }
            System.Int32? requestTravelModeOptions_travelModeOptions_Car_car_Occupancy = null;
            if (cmdletContext.Car_Occupancy != null)
            {
                requestTravelModeOptions_travelModeOptions_Car_car_Occupancy = cmdletContext.Car_Occupancy.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Car_car_Occupancy != null)
            {
                requestTravelModeOptions_travelModeOptions_Car.Occupancy = requestTravelModeOptions_travelModeOptions_Car_car_Occupancy.Value;
                requestTravelModeOptions_travelModeOptions_CarIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteVehicleLicensePlate requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate = null;
            
             // populate LicensePlate
            var requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlateIsNull = true;
            requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate = new Amazon.GeoRoutes.Model.RouteVehicleLicensePlate();
            System.String requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate_travelModeOptions_Car_LicensePlate_LastCharacter = null;
            if (cmdletContext.TravelModeOptions_Car_LicensePlate_LastCharacter != null)
            {
                requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate_travelModeOptions_Car_LicensePlate_LastCharacter = cmdletContext.TravelModeOptions_Car_LicensePlate_LastCharacter;
            }
            if (requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate_travelModeOptions_Car_LicensePlate_LastCharacter != null)
            {
                requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate.LastCharacter = requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate_travelModeOptions_Car_LicensePlate_LastCharacter;
                requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlateIsNull = false;
            }
             // determine if requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate should be set to null
            if (requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlateIsNull)
            {
                requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate = null;
            }
            if (requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate != null)
            {
                requestTravelModeOptions_travelModeOptions_Car.LicensePlate = requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate;
                requestTravelModeOptions_travelModeOptions_CarIsNull = false;
            }
             // determine if requestTravelModeOptions_travelModeOptions_Car should be set to null
            if (requestTravelModeOptions_travelModeOptions_CarIsNull)
            {
                requestTravelModeOptions_travelModeOptions_Car = null;
            }
            if (requestTravelModeOptions_travelModeOptions_Car != null)
            {
                request.TravelModeOptions.Car = requestTravelModeOptions_travelModeOptions_Car;
                requestTravelModeOptionsIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteScooterOptions requestTravelModeOptions_travelModeOptions_Scooter = null;
            
             // populate Scooter
            var requestTravelModeOptions_travelModeOptions_ScooterIsNull = true;
            requestTravelModeOptions_travelModeOptions_Scooter = new Amazon.GeoRoutes.Model.RouteScooterOptions();
            Amazon.GeoRoutes.RouteEngineType requestTravelModeOptions_travelModeOptions_Scooter_scooter_EngineType = null;
            if (cmdletContext.Scooter_EngineType != null)
            {
                requestTravelModeOptions_travelModeOptions_Scooter_scooter_EngineType = cmdletContext.Scooter_EngineType;
            }
            if (requestTravelModeOptions_travelModeOptions_Scooter_scooter_EngineType != null)
            {
                requestTravelModeOptions_travelModeOptions_Scooter.EngineType = requestTravelModeOptions_travelModeOptions_Scooter_scooter_EngineType;
                requestTravelModeOptions_travelModeOptions_ScooterIsNull = false;
            }
            System.Double? requestTravelModeOptions_travelModeOptions_Scooter_scooter_MaxSpeed = null;
            if (cmdletContext.Scooter_MaxSpeed != null)
            {
                requestTravelModeOptions_travelModeOptions_Scooter_scooter_MaxSpeed = cmdletContext.Scooter_MaxSpeed.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Scooter_scooter_MaxSpeed != null)
            {
                requestTravelModeOptions_travelModeOptions_Scooter.MaxSpeed = requestTravelModeOptions_travelModeOptions_Scooter_scooter_MaxSpeed.Value;
                requestTravelModeOptions_travelModeOptions_ScooterIsNull = false;
            }
            System.Int32? requestTravelModeOptions_travelModeOptions_Scooter_scooter_Occupancy = null;
            if (cmdletContext.Scooter_Occupancy != null)
            {
                requestTravelModeOptions_travelModeOptions_Scooter_scooter_Occupancy = cmdletContext.Scooter_Occupancy.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Scooter_scooter_Occupancy != null)
            {
                requestTravelModeOptions_travelModeOptions_Scooter.Occupancy = requestTravelModeOptions_travelModeOptions_Scooter_scooter_Occupancy.Value;
                requestTravelModeOptions_travelModeOptions_ScooterIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteVehicleLicensePlate requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate = null;
            
             // populate LicensePlate
            var requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlateIsNull = true;
            requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate = new Amazon.GeoRoutes.Model.RouteVehicleLicensePlate();
            System.String requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate_travelModeOptions_Scooter_LicensePlate_LastCharacter = null;
            if (cmdletContext.TravelModeOptions_Scooter_LicensePlate_LastCharacter != null)
            {
                requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate_travelModeOptions_Scooter_LicensePlate_LastCharacter = cmdletContext.TravelModeOptions_Scooter_LicensePlate_LastCharacter;
            }
            if (requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate_travelModeOptions_Scooter_LicensePlate_LastCharacter != null)
            {
                requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate.LastCharacter = requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate_travelModeOptions_Scooter_LicensePlate_LastCharacter;
                requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlateIsNull = false;
            }
             // determine if requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate should be set to null
            if (requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlateIsNull)
            {
                requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate = null;
            }
            if (requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate != null)
            {
                requestTravelModeOptions_travelModeOptions_Scooter.LicensePlate = requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate;
                requestTravelModeOptions_travelModeOptions_ScooterIsNull = false;
            }
             // determine if requestTravelModeOptions_travelModeOptions_Scooter should be set to null
            if (requestTravelModeOptions_travelModeOptions_ScooterIsNull)
            {
                requestTravelModeOptions_travelModeOptions_Scooter = null;
            }
            if (requestTravelModeOptions_travelModeOptions_Scooter != null)
            {
                request.TravelModeOptions.Scooter = requestTravelModeOptions_travelModeOptions_Scooter;
                requestTravelModeOptionsIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteTruckOptions requestTravelModeOptions_travelModeOptions_Truck = null;
            
             // populate Truck
            var requestTravelModeOptions_travelModeOptions_TruckIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck = new Amazon.GeoRoutes.Model.RouteTruckOptions();
            System.Int32? requestTravelModeOptions_travelModeOptions_Truck_truck_AxleCount = null;
            if (cmdletContext.Truck_AxleCount != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_AxleCount = cmdletContext.Truck_AxleCount.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_AxleCount != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.AxleCount = requestTravelModeOptions_travelModeOptions_Truck_truck_AxleCount.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            Amazon.GeoRoutes.RouteEngineType requestTravelModeOptions_travelModeOptions_Truck_truck_EngineType = null;
            if (cmdletContext.Truck_EngineType != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_EngineType = cmdletContext.Truck_EngineType;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_EngineType != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.EngineType = requestTravelModeOptions_travelModeOptions_Truck_truck_EngineType;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
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
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_truck_HeightAboveFirstAxle = null;
            if (cmdletContext.Truck_HeightAboveFirstAxle != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_HeightAboveFirstAxle = cmdletContext.Truck_HeightAboveFirstAxle.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_HeightAboveFirstAxle != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.HeightAboveFirstAxle = requestTravelModeOptions_travelModeOptions_Truck_truck_HeightAboveFirstAxle.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_truck_KpraLength = null;
            if (cmdletContext.Truck_KpraLength != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_KpraLength = cmdletContext.Truck_KpraLength.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_KpraLength != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.KpraLength = requestTravelModeOptions_travelModeOptions_Truck_truck_KpraLength.Value;
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
            System.Double? requestTravelModeOptions_travelModeOptions_Truck_truck_MaxSpeed = null;
            if (cmdletContext.Truck_MaxSpeed != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_MaxSpeed = cmdletContext.Truck_MaxSpeed.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_MaxSpeed != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.MaxSpeed = requestTravelModeOptions_travelModeOptions_Truck_truck_MaxSpeed.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            System.Int32? requestTravelModeOptions_travelModeOptions_Truck_truck_Occupancy = null;
            if (cmdletContext.Truck_Occupancy != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_Occupancy = cmdletContext.Truck_Occupancy.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_Occupancy != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.Occupancy = requestTravelModeOptions_travelModeOptions_Truck_truck_Occupancy.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_truck_PayloadCapacity = null;
            if (cmdletContext.Truck_PayloadCapacity != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_PayloadCapacity = cmdletContext.Truck_PayloadCapacity.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_PayloadCapacity != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.PayloadCapacity = requestTravelModeOptions_travelModeOptions_Truck_truck_PayloadCapacity.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            System.Int32? requestTravelModeOptions_travelModeOptions_Truck_truck_TireCount = null;
            if (cmdletContext.Truck_TireCount != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_TireCount = cmdletContext.Truck_TireCount.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_TireCount != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.TireCount = requestTravelModeOptions_travelModeOptions_Truck_truck_TireCount.Value;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            Amazon.GeoRoutes.RouteTruckType requestTravelModeOptions_travelModeOptions_Truck_truck_TruckType = null;
            if (cmdletContext.Truck_TruckType != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_TruckType = cmdletContext.Truck_TruckType;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_TruckType != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.TruckType = requestTravelModeOptions_travelModeOptions_Truck_truck_TruckType;
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
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_truck_WeightPerAxle = null;
            if (cmdletContext.Truck_WeightPerAxle != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_truck_WeightPerAxle = cmdletContext.Truck_WeightPerAxle.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_truck_WeightPerAxle != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.WeightPerAxle = requestTravelModeOptions_travelModeOptions_Truck_truck_WeightPerAxle.Value;
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
            Amazon.GeoRoutes.Model.RouteVehicleLicensePlate requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate = null;
            
             // populate LicensePlate
            var requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlateIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate = new Amazon.GeoRoutes.Model.RouteVehicleLicensePlate();
            System.String requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate_travelModeOptions_Truck_LicensePlate_LastCharacter = null;
            if (cmdletContext.TravelModeOptions_Truck_LicensePlate_LastCharacter != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate_travelModeOptions_Truck_LicensePlate_LastCharacter = cmdletContext.TravelModeOptions_Truck_LicensePlate_LastCharacter;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate_travelModeOptions_Truck_LicensePlate_LastCharacter != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate.LastCharacter = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate_travelModeOptions_Truck_LicensePlate_LastCharacter;
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlateIsNull = false;
            }
             // determine if requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate should be set to null
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlateIsNull)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate = null;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.LicensePlate = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate;
                requestTravelModeOptions_travelModeOptions_TruckIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteTrailerOptions requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = null;
            
             // populate Trailer
            var requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_TrailerIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = new Amazon.GeoRoutes.Model.RouteTrailerOptions();
            System.Int32? requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer_trailer_AxleCount = null;
            if (cmdletContext.Trailer_AxleCount != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer_trailer_AxleCount = cmdletContext.Trailer_AxleCount.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer_trailer_AxleCount != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer.AxleCount = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer_trailer_AxleCount.Value;
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_TrailerIsNull = false;
            }
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
            Amazon.GeoRoutes.Model.WeightPerAxleGroup requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup = null;
            
             // populate WeightPerAxleGroup
            var requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroupIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup = new Amazon.GeoRoutes.Model.WeightPerAxleGroup();
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Quad = null;
            if (cmdletContext.WeightPerAxleGroup_Quad != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Quad = cmdletContext.WeightPerAxleGroup_Quad.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Quad != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup.Quad = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Quad.Value;
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroupIsNull = false;
            }
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Quint = null;
            if (cmdletContext.WeightPerAxleGroup_Quint != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Quint = cmdletContext.WeightPerAxleGroup_Quint.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Quint != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup.Quint = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Quint.Value;
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroupIsNull = false;
            }
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Single = null;
            if (cmdletContext.WeightPerAxleGroup_Single != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Single = cmdletContext.WeightPerAxleGroup_Single.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Single != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup.Single = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Single.Value;
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroupIsNull = false;
            }
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Tandem = null;
            if (cmdletContext.WeightPerAxleGroup_Tandem != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Tandem = cmdletContext.WeightPerAxleGroup_Tandem.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Tandem != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup.Tandem = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Tandem.Value;
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroupIsNull = false;
            }
            System.Int64? requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Triple = null;
            if (cmdletContext.WeightPerAxleGroup_Triple != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Triple = cmdletContext.WeightPerAxleGroup_Triple.Value;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Triple != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup.Triple = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup_weightPerAxleGroup_Triple.Value;
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroupIsNull = false;
            }
             // determine if requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup should be set to null
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroupIsNull)
            {
                requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup = null;
            }
            if (requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup != null)
            {
                requestTravelModeOptions_travelModeOptions_Truck.WeightPerAxleGroup = requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_WeightPerAxleGroup;
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
            if (cmdletContext.TravelStepType != null)
            {
                request.TravelStepType = cmdletContext.TravelStepType;
            }
            if (cmdletContext.Waypoint != null)
            {
                request.Waypoints = cmdletContext.Waypoint;
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
        
        private Amazon.GeoRoutes.Model.CalculateRoutesResponse CallAWSServiceOperation(IAmazonGeoRoutes client, Amazon.GeoRoutes.Model.CalculateRoutesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Routes V2", "CalculateRoutes");
            try
            {
                return client.CalculateRoutesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Allow_Hot { get; set; }
            public System.Boolean? Allow_Hov { get; set; }
            public System.String ArrivalTime { get; set; }
            public List<Amazon.GeoRoutes.Model.RouteAvoidanceArea> Avoid_Area { get; set; }
            public System.Boolean? Avoid_CarShuttleTrain { get; set; }
            public System.Boolean? Avoid_ControlledAccessHighway { get; set; }
            public System.Boolean? Avoid_DirtRoad { get; set; }
            public System.Boolean? Avoid_Ferry { get; set; }
            public System.Boolean? Avoid_SeasonalClosure { get; set; }
            public System.Boolean? Avoid_TollRoad { get; set; }
            public System.Boolean? Avoid_TollTransponder { get; set; }
            public List<System.String> Avoid_TruckRoadType { get; set; }
            public System.Boolean? Avoid_Tunnel { get; set; }
            public System.Boolean? Avoid_UTurn { get; set; }
            public List<Amazon.GeoRoutes.Model.RouteAvoidanceZoneCategory> Avoid_ZoneCategory { get; set; }
            public System.Boolean? DepartNow { get; set; }
            public System.String DepartureTime { get; set; }
            public List<System.Double> Destination { get; set; }
            public System.Int64? DestinationOptions_AvoidActionsForDistance { get; set; }
            public System.Boolean? DestinationOptions_AvoidUTurn { get; set; }
            public System.Double? DestinationOptions_Heading { get; set; }
            public System.String DestinationOptions_Matching_NameHint { get; set; }
            public System.Int64? DestinationOptions_Matching_OnRoadThreshold { get; set; }
            public System.Int64? DestinationOptions_Matching_Radius { get; set; }
            public Amazon.GeoRoutes.MatchingStrategy DestinationOptions_Matching_Strategy { get; set; }
            public List<System.Double> DestinationOptions_SideOfStreet_Position { get; set; }
            public Amazon.GeoRoutes.SideOfStreetMatchingStrategy DestinationOptions_SideOfStreet_UseWith { get; set; }
            public System.Int64? DestinationOptions_StopDuration { get; set; }
            public List<Amazon.GeoRoutes.Model.RouteDriverScheduleInterval> Driver_Schedule { get; set; }
            public List<System.String> Exclude_Country { get; set; }
            public Amazon.GeoRoutes.MeasurementSystem InstructionsMeasurementSystem { get; set; }
            public System.String Key { get; set; }
            public List<System.String> Language { get; set; }
            public List<System.String> LegAdditionalFeature { get; set; }
            public Amazon.GeoRoutes.GeometryFormat LegGeometryFormat { get; set; }
            public System.Int32? MaxAlternative { get; set; }
            public Amazon.GeoRoutes.RoutingObjective OptimizeRoutingFor { get; set; }
            public List<System.Double> Origin { get; set; }
            public System.Int64? OriginOptions_AvoidActionsForDistance { get; set; }
            public System.Boolean? OriginOptions_AvoidUTurn { get; set; }
            public System.Double? OriginOptions_Heading { get; set; }
            public System.String OriginOptions_Matching_NameHint { get; set; }
            public System.Int64? OriginOptions_Matching_OnRoadThreshold { get; set; }
            public System.Int64? OriginOptions_Matching_Radius { get; set; }
            public Amazon.GeoRoutes.MatchingStrategy OriginOptions_Matching_Strategy { get; set; }
            public List<System.Double> OriginOptions_SideOfStreet_Position { get; set; }
            public Amazon.GeoRoutes.SideOfStreetMatchingStrategy OriginOptions_SideOfStreet_UseWith { get; set; }
            public List<System.String> SpanAdditionalFeature { get; set; }
            public System.Boolean? Tolls_AllTransponder { get; set; }
            public System.Boolean? Tolls_AllVignette { get; set; }
            public System.String Tolls_Currency { get; set; }
            public System.String EmissionType_Co2EmissionClass { get; set; }
            public System.String EmissionType_Type { get; set; }
            public Amazon.GeoRoutes.RouteTollVehicleCategory Tolls_VehicleCategory { get; set; }
            public System.Int64? Traffic_FlowEventThresholdOverride { get; set; }
            public Amazon.GeoRoutes.TrafficUsage Traffic_Usage { get; set; }
            public Amazon.GeoRoutes.RouteTravelMode TravelMode { get; set; }
            public Amazon.GeoRoutes.RouteEngineType Car_EngineType { get; set; }
            public System.String TravelModeOptions_Car_LicensePlate_LastCharacter { get; set; }
            public System.Double? Car_MaxSpeed { get; set; }
            public System.Int32? Car_Occupancy { get; set; }
            public System.Double? Pedestrian_Speed { get; set; }
            public Amazon.GeoRoutes.RouteEngineType Scooter_EngineType { get; set; }
            public System.String TravelModeOptions_Scooter_LicensePlate_LastCharacter { get; set; }
            public System.Double? Scooter_MaxSpeed { get; set; }
            public System.Int32? Scooter_Occupancy { get; set; }
            public System.Int32? Truck_AxleCount { get; set; }
            public Amazon.GeoRoutes.RouteEngineType Truck_EngineType { get; set; }
            public System.Int64? Truck_GrossWeight { get; set; }
            public List<System.String> Truck_HazardousCargo { get; set; }
            public System.Int64? Truck_Height { get; set; }
            public System.Int64? Truck_HeightAboveFirstAxle { get; set; }
            public System.Int64? Truck_KpraLength { get; set; }
            public System.Int64? Truck_Length { get; set; }
            public System.String TravelModeOptions_Truck_LicensePlate_LastCharacter { get; set; }
            public System.Double? Truck_MaxSpeed { get; set; }
            public System.Int32? Truck_Occupancy { get; set; }
            public System.Int64? Truck_PayloadCapacity { get; set; }
            public System.Int32? Truck_TireCount { get; set; }
            public System.Int32? Trailer_AxleCount { get; set; }
            public System.Int32? Trailer_TrailerCount { get; set; }
            public Amazon.GeoRoutes.RouteTruckType Truck_TruckType { get; set; }
            public System.String Truck_TunnelRestrictionCode { get; set; }
            public System.Int64? Truck_WeightPerAxle { get; set; }
            public System.Int64? WeightPerAxleGroup_Quad { get; set; }
            public System.Int64? WeightPerAxleGroup_Quint { get; set; }
            public System.Int64? WeightPerAxleGroup_Single { get; set; }
            public System.Int64? WeightPerAxleGroup_Tandem { get; set; }
            public System.Int64? WeightPerAxleGroup_Triple { get; set; }
            public System.Int64? Truck_Width { get; set; }
            public Amazon.GeoRoutes.RouteTravelStepType TravelStepType { get; set; }
            public List<Amazon.GeoRoutes.Model.RouteWaypoint> Waypoint { get; set; }
            public System.Func<Amazon.GeoRoutes.Model.CalculateRoutesResponse, GetGEORRouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
