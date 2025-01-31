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
using Amazon.GeoRoutes;
using Amazon.GeoRoutes.Model;

namespace Amazon.PowerShell.Cmdlets.GEOR
{
    /// <summary>
    /// Use <c>CalculateRouteMatrix</c> to compute results for all pairs of Origins to Destinations.
    /// Each row corresponds to one entry in Origins. Each entry in the row corresponds to
    /// the route from that entry in Origins to an entry in Destinations positions.
    /// </summary>
    [Cmdlet("Get", "GEORRouteMatrix")]
    [OutputType("Amazon.GeoRoutes.Model.CalculateRouteMatrixResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Routes V2 CalculateRouteMatrix API operation.", Operation = new[] {"CalculateRouteMatrix"}, SelectReturnType = typeof(Amazon.GeoRoutes.Model.CalculateRouteMatrixResponse))]
    [AWSCmdletOutput("Amazon.GeoRoutes.Model.CalculateRouteMatrixResponse",
        "This cmdlet returns an Amazon.GeoRoutes.Model.CalculateRouteMatrixResponse object containing multiple properties."
    )]
    public partial class GetGEORRouteMatrixCmdlet : AmazonGeoRoutesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Avoid_Area
        /// <summary>
        /// <para>
        /// <para>Areas to be avoided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_Areas")]
        public Amazon.GeoRoutes.Model.RouteMatrixAvoidanceArea[] Avoid_Area { get; set; }
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
        
        #region Parameter Geometry_BoundingBox
        /// <summary>
        /// <para>
        /// <para>Geometry defined as a bounding box. The first pair represents the X and Y coordinates
        /// (longitude and latitude,) of the southwest corner of the bounding box; the second
        /// pair represents the X and Y coordinates (longitude and latitude) of the northeast
        /// corner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoutingBoundary_Geometry_BoundingBox")]
        public System.Double[] Geometry_BoundingBox { get; set; }
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
        
        #region Parameter Circle_Center
        /// <summary>
        /// <para>
        /// <para>Center of the Circle defined in longitude and latitude coordinates.</para><para>Example: <c>[-123.1174, 49.2847]</c> represents the position with longitude <c>-123.1174</c>
        /// and latitude <c>49.2847</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoutingBoundary_Geometry_Circle_Center")]
        public System.Double[] Circle_Center { get; set; }
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
        /// <para>List of destinations for the route.</para><note><para>Route calculations are billed for each origin and destination pair. If you use a large
        /// matrix of origins and destinations, your costs will increase accordingly. See <a href="https://docs.aws.amazon.com/location/latest/developerguide/routes-pricing.html`">
        /// Amazon Location's pricing page</a> for more information.</para></note>
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
        [Alias("Destinations")]
        public Amazon.GeoRoutes.Model.RouteMatrixDestination[] Destination { get; set; }
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
        /// <para>Kingpin to rear axle length of the vehicle</para><para><b>Unit</b>: <c>centimeters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_KpraLength")]
        public System.Int64? Truck_KpraLength { get; set; }
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
        
        #region Parameter AutoCircle_Margin
        /// <summary>
        /// <para>
        /// <para>The margin provided for the calculation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoutingBoundary_Geometry_AutoCircle_Margin")]
        public System.Int64? AutoCircle_Margin { get; set; }
        #endregion
        
        #region Parameter AutoCircle_MaxRadius
        /// <summary>
        /// <para>
        /// <para>The maximum size of the radius provided for the calculation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoutingBoundary_Geometry_AutoCircle_MaxRadius")]
        public System.Int64? AutoCircle_MaxRadius { get; set; }
        #endregion
        
        #region Parameter Car_MaxSpeed
        /// <summary>
        /// <para>
        /// <para>Maximum speed</para><para><b>Unit</b>: <c>KilometersPerHour</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Car_MaxSpeed")]
        public System.Double? Car_MaxSpeed { get; set; }
        #endregion
        
        #region Parameter Scooter_MaxSpeed
        /// <summary>
        /// <para>
        /// <para>Maximum speed.</para><para><b>Unit</b>: <c>KilometersPerHour</c></para>
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
        /// <para>The position in longitude and latitude for the origin.</para><note><para>Route calculations are billed for each origin and destination pair. Using a large
        /// amount of Origins in a request can lead you to incur unexpected charges. See <a href="https://docs.aws.amazon.com/location/latest/developerguide/routes-pricing.html`">
        /// Amazon Location's pricing page</a> for more information.</para></note>
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
        [Alias("Origins")]
        public Amazon.GeoRoutes.Model.RouteMatrixOrigin[] Origin { get; set; }
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
        
        #region Parameter Geometry_Polygon
        /// <summary>
        /// <para>
        /// <para>Geometry defined as a polygon with only one linear ring.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoutingBoundary_Geometry_Polygon")]
        public System.Double[][][] Geometry_Polygon { get; set; }
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
        
        #region Parameter Circle_Radius
        /// <summary>
        /// <para>
        /// <para>Radius of the Circle.</para><para><b>Unit</b>: <c>meters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoutingBoundary_Geometry_Circle_Radius")]
        public System.Double? Circle_Radius { get; set; }
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
        [AWSConstantClassSource("Amazon.GeoRoutes.RouteMatrixTravelMode")]
        public Amazon.GeoRoutes.RouteMatrixTravelMode TravelMode { get; set; }
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
        [AWSConstantClassSource("Amazon.GeoRoutes.RouteMatrixTruckType")]
        public Amazon.GeoRoutes.RouteMatrixTruckType Truck_TruckType { get; set; }
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
        
        #region Parameter RoutingBoundary_Unbounded
        /// <summary>
        /// <para>
        /// <para>No restrictions in terms of a routing boundary, and is typically used for longer routes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RoutingBoundary_Unbounded { get; set; }
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
        public Amazon.GeoRoutes.Model.RouteMatrixAvoidanceZoneCategory[] Avoid_ZoneCategory { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoRoutes.Model.CalculateRouteMatrixResponse).
        /// Specifying the name of a property of type Amazon.GeoRoutes.Model.CalculateRouteMatrixResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GeoRoutes.Model.CalculateRouteMatrixResponse, GetGEORRouteMatrixCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Allow_Hot = this.Allow_Hot;
            context.Allow_Hov = this.Allow_Hov;
            if (this.Avoid_Area != null)
            {
                context.Avoid_Area = new List<Amazon.GeoRoutes.Model.RouteMatrixAvoidanceArea>(this.Avoid_Area);
            }
            context.Avoid_CarShuttleTrain = this.Avoid_CarShuttleTrain;
            context.Avoid_ControlledAccessHighway = this.Avoid_ControlledAccessHighway;
            context.Avoid_DirtRoad = this.Avoid_DirtRoad;
            context.Avoid_Ferry = this.Avoid_Ferry;
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
                context.Avoid_ZoneCategory = new List<Amazon.GeoRoutes.Model.RouteMatrixAvoidanceZoneCategory>(this.Avoid_ZoneCategory);
            }
            context.DepartNow = this.DepartNow;
            context.DepartureTime = this.DepartureTime;
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.GeoRoutes.Model.RouteMatrixDestination>(this.Destination);
            }
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Exclude_Country != null)
            {
                context.Exclude_Country = new List<System.String>(this.Exclude_Country);
            }
            context.Key = this.Key;
            context.OptimizeRoutingFor = this.OptimizeRoutingFor;
            if (this.Origin != null)
            {
                context.Origin = new List<Amazon.GeoRoutes.Model.RouteMatrixOrigin>(this.Origin);
            }
            #if MODULAR
            if (this.Origin == null && ParameterWasBound(nameof(this.Origin)))
            {
                WriteWarning("You are passing $null as a value for parameter Origin which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoCircle_Margin = this.AutoCircle_Margin;
            context.AutoCircle_MaxRadius = this.AutoCircle_MaxRadius;
            if (this.Geometry_BoundingBox != null)
            {
                context.Geometry_BoundingBox = new List<System.Double>(this.Geometry_BoundingBox);
            }
            if (this.Circle_Center != null)
            {
                context.Circle_Center = new List<System.Double>(this.Circle_Center);
            }
            context.Circle_Radius = this.Circle_Radius;
            if (this.Geometry_Polygon != null)
            {
                context.Geometry_Polygon = new List<List<List<System.Double>>>();
                foreach (var innerList in this.Geometry_Polygon)
                {
                    var innerListCopy = new List<List<System.Double>>();
                    context.Geometry_Polygon.Add(innerListCopy);
                    foreach (var innermostList in innerList)
                    {
                        var innermostListCopy = new List<System.Double>(innermostList);
                        innerListCopy.Add(innermostListCopy);
                    }
                }
            }
            context.RoutingBoundary_Unbounded = this.RoutingBoundary_Unbounded;
            context.Traffic_FlowEventThresholdOverride = this.Traffic_FlowEventThresholdOverride;
            context.Traffic_Usage = this.Traffic_Usage;
            context.TravelMode = this.TravelMode;
            context.TravelModeOptions_Car_LicensePlate_LastCharacter = this.TravelModeOptions_Car_LicensePlate_LastCharacter;
            context.Car_MaxSpeed = this.Car_MaxSpeed;
            context.Car_Occupancy = this.Car_Occupancy;
            context.TravelModeOptions_Scooter_LicensePlate_LastCharacter = this.TravelModeOptions_Scooter_LicensePlate_LastCharacter;
            context.Scooter_MaxSpeed = this.Scooter_MaxSpeed;
            context.Scooter_Occupancy = this.Scooter_Occupancy;
            context.Truck_AxleCount = this.Truck_AxleCount;
            context.Truck_GrossWeight = this.Truck_GrossWeight;
            if (this.Truck_HazardousCargo != null)
            {
                context.Truck_HazardousCargo = new List<System.String>(this.Truck_HazardousCargo);
            }
            context.Truck_Height = this.Truck_Height;
            context.Truck_KpraLength = this.Truck_KpraLength;
            context.Truck_Length = this.Truck_Length;
            context.TravelModeOptions_Truck_LicensePlate_LastCharacter = this.TravelModeOptions_Truck_LicensePlate_LastCharacter;
            context.Truck_MaxSpeed = this.Truck_MaxSpeed;
            context.Truck_Occupancy = this.Truck_Occupancy;
            context.Truck_PayloadCapacity = this.Truck_PayloadCapacity;
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
            var request = new Amazon.GeoRoutes.Model.CalculateRouteMatrixRequest();
            
            
             // populate Allow
            var requestAllowIsNull = true;
            request.Allow = new Amazon.GeoRoutes.Model.RouteMatrixAllowOptions();
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
            
             // populate Avoid
            var requestAvoidIsNull = true;
            request.Avoid = new Amazon.GeoRoutes.Model.RouteMatrixAvoidanceOptions();
            List<Amazon.GeoRoutes.Model.RouteMatrixAvoidanceArea> requestAvoid_avoid_Area = null;
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
            List<Amazon.GeoRoutes.Model.RouteMatrixAvoidanceZoneCategory> requestAvoid_avoid_ZoneCategory = null;
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
                request.Destinations = cmdletContext.Destination;
            }
            
             // populate Exclude
            var requestExcludeIsNull = true;
            request.Exclude = new Amazon.GeoRoutes.Model.RouteMatrixExclusionOptions();
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
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.OptimizeRoutingFor != null)
            {
                request.OptimizeRoutingFor = cmdletContext.OptimizeRoutingFor;
            }
            if (cmdletContext.Origin != null)
            {
                request.Origins = cmdletContext.Origin;
            }
            
             // populate RoutingBoundary
            var requestRoutingBoundaryIsNull = true;
            request.RoutingBoundary = new Amazon.GeoRoutes.Model.RouteMatrixBoundary();
            System.Boolean? requestRoutingBoundary_routingBoundary_Unbounded = null;
            if (cmdletContext.RoutingBoundary_Unbounded != null)
            {
                requestRoutingBoundary_routingBoundary_Unbounded = cmdletContext.RoutingBoundary_Unbounded.Value;
            }
            if (requestRoutingBoundary_routingBoundary_Unbounded != null)
            {
                request.RoutingBoundary.Unbounded = requestRoutingBoundary_routingBoundary_Unbounded.Value;
                requestRoutingBoundaryIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteMatrixBoundaryGeometry requestRoutingBoundary_routingBoundary_Geometry = null;
            
             // populate Geometry
            var requestRoutingBoundary_routingBoundary_GeometryIsNull = true;
            requestRoutingBoundary_routingBoundary_Geometry = new Amazon.GeoRoutes.Model.RouteMatrixBoundaryGeometry();
            List<System.Double> requestRoutingBoundary_routingBoundary_Geometry_geometry_BoundingBox = null;
            if (cmdletContext.Geometry_BoundingBox != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_geometry_BoundingBox = cmdletContext.Geometry_BoundingBox;
            }
            if (requestRoutingBoundary_routingBoundary_Geometry_geometry_BoundingBox != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry.BoundingBox = requestRoutingBoundary_routingBoundary_Geometry_geometry_BoundingBox;
                requestRoutingBoundary_routingBoundary_GeometryIsNull = false;
            }
            List<List<List<System.Double>>> requestRoutingBoundary_routingBoundary_Geometry_geometry_Polygon = null;
            if (cmdletContext.Geometry_Polygon != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_geometry_Polygon = cmdletContext.Geometry_Polygon;
            }
            if (requestRoutingBoundary_routingBoundary_Geometry_geometry_Polygon != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry.Polygon = requestRoutingBoundary_routingBoundary_Geometry_geometry_Polygon;
                requestRoutingBoundary_routingBoundary_GeometryIsNull = false;
            }
            Amazon.GeoRoutes.Model.RouteMatrixAutoCircle requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle = null;
            
             // populate AutoCircle
            var requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircleIsNull = true;
            requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle = new Amazon.GeoRoutes.Model.RouteMatrixAutoCircle();
            System.Int64? requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle_autoCircle_Margin = null;
            if (cmdletContext.AutoCircle_Margin != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle_autoCircle_Margin = cmdletContext.AutoCircle_Margin.Value;
            }
            if (requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle_autoCircle_Margin != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle.Margin = requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle_autoCircle_Margin.Value;
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircleIsNull = false;
            }
            System.Int64? requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle_autoCircle_MaxRadius = null;
            if (cmdletContext.AutoCircle_MaxRadius != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle_autoCircle_MaxRadius = cmdletContext.AutoCircle_MaxRadius.Value;
            }
            if (requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle_autoCircle_MaxRadius != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle.MaxRadius = requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle_autoCircle_MaxRadius.Value;
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircleIsNull = false;
            }
             // determine if requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle should be set to null
            if (requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircleIsNull)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle = null;
            }
            if (requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry.AutoCircle = requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_AutoCircle;
                requestRoutingBoundary_routingBoundary_GeometryIsNull = false;
            }
            Amazon.GeoRoutes.Model.Circle requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle = null;
            
             // populate Circle
            var requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_CircleIsNull = true;
            requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle = new Amazon.GeoRoutes.Model.Circle();
            List<System.Double> requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle_circle_Center = null;
            if (cmdletContext.Circle_Center != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle_circle_Center = cmdletContext.Circle_Center;
            }
            if (requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle_circle_Center != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle.Center = requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle_circle_Center;
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_CircleIsNull = false;
            }
            System.Double? requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle_circle_Radius = null;
            if (cmdletContext.Circle_Radius != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle_circle_Radius = cmdletContext.Circle_Radius.Value;
            }
            if (requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle_circle_Radius != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle.Radius = requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle_circle_Radius.Value;
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_CircleIsNull = false;
            }
             // determine if requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle should be set to null
            if (requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_CircleIsNull)
            {
                requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle = null;
            }
            if (requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle != null)
            {
                requestRoutingBoundary_routingBoundary_Geometry.Circle = requestRoutingBoundary_routingBoundary_Geometry_routingBoundary_Geometry_Circle;
                requestRoutingBoundary_routingBoundary_GeometryIsNull = false;
            }
             // determine if requestRoutingBoundary_routingBoundary_Geometry should be set to null
            if (requestRoutingBoundary_routingBoundary_GeometryIsNull)
            {
                requestRoutingBoundary_routingBoundary_Geometry = null;
            }
            if (requestRoutingBoundary_routingBoundary_Geometry != null)
            {
                request.RoutingBoundary.Geometry = requestRoutingBoundary_routingBoundary_Geometry;
                requestRoutingBoundaryIsNull = false;
            }
             // determine if request.RoutingBoundary should be set to null
            if (requestRoutingBoundaryIsNull)
            {
                request.RoutingBoundary = null;
            }
            
             // populate Traffic
            var requestTrafficIsNull = true;
            request.Traffic = new Amazon.GeoRoutes.Model.RouteMatrixTrafficOptions();
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
            request.TravelModeOptions = new Amazon.GeoRoutes.Model.RouteMatrixTravelModeOptions();
            Amazon.GeoRoutes.Model.RouteMatrixCarOptions requestTravelModeOptions_travelModeOptions_Car = null;
            
             // populate Car
            var requestTravelModeOptions_travelModeOptions_CarIsNull = true;
            requestTravelModeOptions_travelModeOptions_Car = new Amazon.GeoRoutes.Model.RouteMatrixCarOptions();
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
            Amazon.GeoRoutes.Model.RouteMatrixVehicleLicensePlate requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate = null;
            
             // populate LicensePlate
            var requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlateIsNull = true;
            requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate = new Amazon.GeoRoutes.Model.RouteMatrixVehicleLicensePlate();
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
            Amazon.GeoRoutes.Model.RouteMatrixScooterOptions requestTravelModeOptions_travelModeOptions_Scooter = null;
            
             // populate Scooter
            var requestTravelModeOptions_travelModeOptions_ScooterIsNull = true;
            requestTravelModeOptions_travelModeOptions_Scooter = new Amazon.GeoRoutes.Model.RouteMatrixScooterOptions();
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
            Amazon.GeoRoutes.Model.RouteMatrixVehicleLicensePlate requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate = null;
            
             // populate LicensePlate
            var requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlateIsNull = true;
            requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate = new Amazon.GeoRoutes.Model.RouteMatrixVehicleLicensePlate();
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
            Amazon.GeoRoutes.Model.RouteMatrixTruckOptions requestTravelModeOptions_travelModeOptions_Truck = null;
            
             // populate Truck
            var requestTravelModeOptions_travelModeOptions_TruckIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck = new Amazon.GeoRoutes.Model.RouteMatrixTruckOptions();
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
            Amazon.GeoRoutes.RouteMatrixTruckType requestTravelModeOptions_travelModeOptions_Truck_truck_TruckType = null;
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
            Amazon.GeoRoutes.Model.RouteMatrixVehicleLicensePlate requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate = null;
            
             // populate LicensePlate
            var requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlateIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate = new Amazon.GeoRoutes.Model.RouteMatrixVehicleLicensePlate();
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
            Amazon.GeoRoutes.Model.RouteMatrixTrailerOptions requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = null;
            
             // populate Trailer
            var requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_TrailerIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = new Amazon.GeoRoutes.Model.RouteMatrixTrailerOptions();
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
        
        private Amazon.GeoRoutes.Model.CalculateRouteMatrixResponse CallAWSServiceOperation(IAmazonGeoRoutes client, Amazon.GeoRoutes.Model.CalculateRouteMatrixRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Routes V2", "CalculateRouteMatrix");
            try
            {
                #if DESKTOP
                return client.CalculateRouteMatrix(request);
                #elif CORECLR
                return client.CalculateRouteMatrixAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Allow_Hot { get; set; }
            public System.Boolean? Allow_Hov { get; set; }
            public List<Amazon.GeoRoutes.Model.RouteMatrixAvoidanceArea> Avoid_Area { get; set; }
            public System.Boolean? Avoid_CarShuttleTrain { get; set; }
            public System.Boolean? Avoid_ControlledAccessHighway { get; set; }
            public System.Boolean? Avoid_DirtRoad { get; set; }
            public System.Boolean? Avoid_Ferry { get; set; }
            public System.Boolean? Avoid_TollRoad { get; set; }
            public System.Boolean? Avoid_TollTransponder { get; set; }
            public List<System.String> Avoid_TruckRoadType { get; set; }
            public System.Boolean? Avoid_Tunnel { get; set; }
            public System.Boolean? Avoid_UTurn { get; set; }
            public List<Amazon.GeoRoutes.Model.RouteMatrixAvoidanceZoneCategory> Avoid_ZoneCategory { get; set; }
            public System.Boolean? DepartNow { get; set; }
            public System.String DepartureTime { get; set; }
            public List<Amazon.GeoRoutes.Model.RouteMatrixDestination> Destination { get; set; }
            public List<System.String> Exclude_Country { get; set; }
            public System.String Key { get; set; }
            public Amazon.GeoRoutes.RoutingObjective OptimizeRoutingFor { get; set; }
            public List<Amazon.GeoRoutes.Model.RouteMatrixOrigin> Origin { get; set; }
            public System.Int64? AutoCircle_Margin { get; set; }
            public System.Int64? AutoCircle_MaxRadius { get; set; }
            public List<System.Double> Geometry_BoundingBox { get; set; }
            public List<System.Double> Circle_Center { get; set; }
            public System.Double? Circle_Radius { get; set; }
            public List<List<List<System.Double>>> Geometry_Polygon { get; set; }
            public System.Boolean? RoutingBoundary_Unbounded { get; set; }
            public System.Int64? Traffic_FlowEventThresholdOverride { get; set; }
            public Amazon.GeoRoutes.TrafficUsage Traffic_Usage { get; set; }
            public Amazon.GeoRoutes.RouteMatrixTravelMode TravelMode { get; set; }
            public System.String TravelModeOptions_Car_LicensePlate_LastCharacter { get; set; }
            public System.Double? Car_MaxSpeed { get; set; }
            public System.Int32? Car_Occupancy { get; set; }
            public System.String TravelModeOptions_Scooter_LicensePlate_LastCharacter { get; set; }
            public System.Double? Scooter_MaxSpeed { get; set; }
            public System.Int32? Scooter_Occupancy { get; set; }
            public System.Int32? Truck_AxleCount { get; set; }
            public System.Int64? Truck_GrossWeight { get; set; }
            public List<System.String> Truck_HazardousCargo { get; set; }
            public System.Int64? Truck_Height { get; set; }
            public System.Int64? Truck_KpraLength { get; set; }
            public System.Int64? Truck_Length { get; set; }
            public System.String TravelModeOptions_Truck_LicensePlate_LastCharacter { get; set; }
            public System.Double? Truck_MaxSpeed { get; set; }
            public System.Int32? Truck_Occupancy { get; set; }
            public System.Int64? Truck_PayloadCapacity { get; set; }
            public System.Int32? Trailer_TrailerCount { get; set; }
            public Amazon.GeoRoutes.RouteMatrixTruckType Truck_TruckType { get; set; }
            public System.String Truck_TunnelRestrictionCode { get; set; }
            public System.Int64? Truck_WeightPerAxle { get; set; }
            public System.Int64? WeightPerAxleGroup_Quad { get; set; }
            public System.Int64? WeightPerAxleGroup_Quint { get; set; }
            public System.Int64? WeightPerAxleGroup_Single { get; set; }
            public System.Int64? WeightPerAxleGroup_Tandem { get; set; }
            public System.Int64? WeightPerAxleGroup_Triple { get; set; }
            public System.Int64? Truck_Width { get; set; }
            public System.Func<Amazon.GeoRoutes.Model.CalculateRouteMatrixResponse, GetGEORRouteMatrixCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
