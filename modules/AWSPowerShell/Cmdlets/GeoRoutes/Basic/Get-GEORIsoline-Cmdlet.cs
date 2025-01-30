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
    /// Use the <c>CalculateIsolines</c> action to find service areas that can be reached
    /// in a given threshold of time, distance.
    /// </summary>
    [Cmdlet("Get", "GEORIsoline")]
    [OutputType("Amazon.GeoRoutes.Model.CalculateIsolinesResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Routes V2 CalculateIsolines API operation.", Operation = new[] {"CalculateIsolines"}, SelectReturnType = typeof(Amazon.GeoRoutes.Model.CalculateIsolinesResponse))]
    [AWSCmdletOutput("Amazon.GeoRoutes.Model.CalculateIsolinesResponse",
        "This cmdlet returns an Amazon.GeoRoutes.Model.CalculateIsolinesResponse object containing multiple properties."
    )]
    public partial class GetGEORIsolineCmdlet : AmazonGeoRoutesClientCmdlet, IExecutor
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
        public Amazon.GeoRoutes.Model.IsolineAvoidanceArea[] Avoid_Area { get; set; }
        #endregion
        
        #region Parameter ArrivalTime
        /// <summary>
        /// <para>
        /// <para>Time of arrival at the destination.</para><para>Time format: <c>YYYY-MM-DDThh:mm:ss.sssZ | YYYY-MM-DDThh:mm:ss.sss+hh:mm</c></para><para>Examples:</para><para><c>2020-04-22T17:57:24Z</c></para><para><c>2020-04-22T17:57:24+02:00</c></para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter Thresholds_Distance
        /// <summary>
        /// <para>
        /// <para>Distance to be used for the isoline calculation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64[] Thresholds_Distance { get; set; }
        #endregion
        
        #region Parameter Car_EngineType
        /// <summary>
        /// <para>
        /// <para>Engine type of the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Car_EngineType")]
        [AWSConstantClassSource("Amazon.GeoRoutes.IsolineEngineType")]
        public Amazon.GeoRoutes.IsolineEngineType Car_EngineType { get; set; }
        #endregion
        
        #region Parameter Scooter_EngineType
        /// <summary>
        /// <para>
        /// <para>Engine type of the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Scooter_EngineType")]
        [AWSConstantClassSource("Amazon.GeoRoutes.IsolineEngineType")]
        public Amazon.GeoRoutes.IsolineEngineType Scooter_EngineType { get; set; }
        #endregion
        
        #region Parameter Truck_EngineType
        /// <summary>
        /// <para>
        /// <para>Engine type of the vehicle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_EngineType")]
        [AWSConstantClassSource("Amazon.GeoRoutes.IsolineEngineType")]
        public Amazon.GeoRoutes.IsolineEngineType Truck_EngineType { get; set; }
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
        /// data. </para><para><b>Unit</b>: <c>seconds</c></para>
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
        /// <para>Allow Hot (High Occupancy Toll) lanes while calculating the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Allow_Hot { get; set; }
        #endregion
        
        #region Parameter Allow_Hov
        /// <summary>
        /// <para>
        /// <para>Allow Hov (High Occupancy vehicle) lanes while calculating the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Allow_Hov { get; set; }
        #endregion
        
        #region Parameter IsolineGeometryFormat
        /// <summary>
        /// <para>
        /// <para>The format of the returned IsolineGeometry. </para><para>Default Value:<c>FlexiblePolyline</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.GeometryFormat")]
        public Amazon.GeoRoutes.GeometryFormat IsolineGeometryFormat { get; set; }
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
        
        #region Parameter IsolineGranularity_MaxPoint
        /// <summary>
        /// <para>
        /// <para>Maximum number of points of returned Isoline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IsolineGranularity_MaxPoints")]
        public System.Int32? IsolineGranularity_MaxPoint { get; set; }
        #endregion
        
        #region Parameter IsolineGranularity_MaxResolution
        /// <summary>
        /// <para>
        /// <para>Maximum resolution of the returned isoline.</para><para><b>Unit</b>: <c>centimeters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? IsolineGranularity_MaxResolution { get; set; }
        #endregion
        
        #region Parameter Car_MaxSpeed
        /// <summary>
        /// <para>
        /// <para>Maximum speed.</para><para><b>Unit</b>: <c>KilometersPerHour</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Car_MaxSpeed")]
        public System.Double? Car_MaxSpeed { get; set; }
        #endregion
        
        #region Parameter Scooter_MaxSpeed
        /// <summary>
        /// <para>
        /// <para>Maximum speed specified.</para><para><b>Unit</b>: <c>KilometersPerHour</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Scooter_MaxSpeed")]
        public System.Double? Scooter_MaxSpeed { get; set; }
        #endregion
        
        #region Parameter Truck_MaxSpeed
        /// <summary>
        /// <para>
        /// <para>Maximum speed specified.</para><para><b>Unit</b>: <c>KilometersPerHour</c></para>
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
        
        #region Parameter OptimizeIsolineFor
        /// <summary>
        /// <para>
        /// <para>Specifies the optimization criteria for when calculating an isoline. AccurateCalculation
        /// generates an isoline of higher granularity that is more precise. FastCalculation generates
        /// an isoline faster by reducing the granularity, and in turn the quality of the isoline.
        /// BalancedCalculation generates an isoline by balancing between quality and performance.
        /// </para><para>Default Value: <c>BalancedCalculation</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.IsolineOptimizationObjective")]
        public Amazon.GeoRoutes.IsolineOptimizationObjective OptimizeIsolineFor { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter Thresholds_Time
        /// <summary>
        /// <para>
        /// <para>Time to be used for the isoline calculation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64[] Thresholds_Time { get; set; }
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
        /// of travel and road compatibility.</para><note><para> The mode <c>Scooter</c> also applies to motorcycles, set to <c>Scooter</c> when wanted
        /// to calculate options for motorcycles.</para></note><para>Default Value: <c>Car</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.IsolineTravelMode")]
        public Amazon.GeoRoutes.IsolineTravelMode TravelMode { get; set; }
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
        [AWSConstantClassSource("Amazon.GeoRoutes.IsolineTruckType")]
        public Amazon.GeoRoutes.IsolineTruckType Truck_TruckType { get; set; }
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
        /// <para>Strategy that defines when the side of street position should be used. AnyStreet will
        /// always use the provided position.</para><para>Default Value: <c>DividedStreetOnly</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.SideOfStreetMatchingStrategy")]
        public Amazon.GeoRoutes.SideOfStreetMatchingStrategy DestinationOptions_SideOfStreet_UseWith { get; set; }
        #endregion
        
        #region Parameter OriginOptions_SideOfStreet_UseWith
        /// <summary>
        /// <para>
        /// <para>Strategy that defines when the side of street position should be used. AnyStreet will
        /// always use the provided position.</para><para>Default Value: <c>DividedStreetOnly</c></para>
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
        public Amazon.GeoRoutes.Model.IsolineAvoidanceZoneCategory[] Avoid_ZoneCategory { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoRoutes.Model.CalculateIsolinesResponse).
        /// Specifying the name of a property of type Amazon.GeoRoutes.Model.CalculateIsolinesResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.GeoRoutes.Model.CalculateIsolinesResponse, GetGEORIsolineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Allow_Hot = this.Allow_Hot;
            context.Allow_Hov = this.Allow_Hov;
            context.ArrivalTime = this.ArrivalTime;
            if (this.Avoid_Area != null)
            {
                context.Avoid_Area = new List<Amazon.GeoRoutes.Model.IsolineAvoidanceArea>(this.Avoid_Area);
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
                context.Avoid_ZoneCategory = new List<Amazon.GeoRoutes.Model.IsolineAvoidanceZoneCategory>(this.Avoid_ZoneCategory);
            }
            context.DepartNow = this.DepartNow;
            context.DepartureTime = this.DepartureTime;
            if (this.Destination != null)
            {
                context.Destination = new List<System.Double>(this.Destination);
            }
            context.DestinationOptions_AvoidActionsForDistance = this.DestinationOptions_AvoidActionsForDistance;
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
            context.IsolineGeometryFormat = this.IsolineGeometryFormat;
            context.IsolineGranularity_MaxPoint = this.IsolineGranularity_MaxPoint;
            context.IsolineGranularity_MaxResolution = this.IsolineGranularity_MaxResolution;
            context.Key = this.Key;
            context.OptimizeIsolineFor = this.OptimizeIsolineFor;
            context.OptimizeRoutingFor = this.OptimizeRoutingFor;
            if (this.Origin != null)
            {
                context.Origin = new List<System.Double>(this.Origin);
            }
            context.OriginOptions_AvoidActionsForDistance = this.OriginOptions_AvoidActionsForDistance;
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
            if (this.Thresholds_Distance != null)
            {
                context.Thresholds_Distance = new List<System.Int64>(this.Thresholds_Distance);
            }
            if (this.Thresholds_Time != null)
            {
                context.Thresholds_Time = new List<System.Int64>(this.Thresholds_Time);
            }
            context.Traffic_FlowEventThresholdOverride = this.Traffic_FlowEventThresholdOverride;
            context.Traffic_Usage = this.Traffic_Usage;
            context.TravelMode = this.TravelMode;
            context.Car_EngineType = this.Car_EngineType;
            context.TravelModeOptions_Car_LicensePlate_LastCharacter = this.TravelModeOptions_Car_LicensePlate_LastCharacter;
            context.Car_MaxSpeed = this.Car_MaxSpeed;
            context.Car_Occupancy = this.Car_Occupancy;
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
            var request = new Amazon.GeoRoutes.Model.CalculateIsolinesRequest();
            
            
             // populate Allow
            var requestAllowIsNull = true;
            request.Allow = new Amazon.GeoRoutes.Model.IsolineAllowOptions();
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
            request.Avoid = new Amazon.GeoRoutes.Model.IsolineAvoidanceOptions();
            List<Amazon.GeoRoutes.Model.IsolineAvoidanceArea> requestAvoid_avoid_Area = null;
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
            List<Amazon.GeoRoutes.Model.IsolineAvoidanceZoneCategory> requestAvoid_avoid_ZoneCategory = null;
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
            request.DestinationOptions = new Amazon.GeoRoutes.Model.IsolineDestinationOptions();
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
            Amazon.GeoRoutes.Model.IsolineSideOfStreetOptions requestDestinationOptions_destinationOptions_SideOfStreet = null;
            
             // populate SideOfStreet
            var requestDestinationOptions_destinationOptions_SideOfStreetIsNull = true;
            requestDestinationOptions_destinationOptions_SideOfStreet = new Amazon.GeoRoutes.Model.IsolineSideOfStreetOptions();
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
            Amazon.GeoRoutes.Model.IsolineMatchingOptions requestDestinationOptions_destinationOptions_Matching = null;
            
             // populate Matching
            var requestDestinationOptions_destinationOptions_MatchingIsNull = true;
            requestDestinationOptions_destinationOptions_Matching = new Amazon.GeoRoutes.Model.IsolineMatchingOptions();
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
            if (cmdletContext.IsolineGeometryFormat != null)
            {
                request.IsolineGeometryFormat = cmdletContext.IsolineGeometryFormat;
            }
            
             // populate IsolineGranularity
            var requestIsolineGranularityIsNull = true;
            request.IsolineGranularity = new Amazon.GeoRoutes.Model.IsolineGranularityOptions();
            System.Int32? requestIsolineGranularity_isolineGranularity_MaxPoint = null;
            if (cmdletContext.IsolineGranularity_MaxPoint != null)
            {
                requestIsolineGranularity_isolineGranularity_MaxPoint = cmdletContext.IsolineGranularity_MaxPoint.Value;
            }
            if (requestIsolineGranularity_isolineGranularity_MaxPoint != null)
            {
                request.IsolineGranularity.MaxPoints = requestIsolineGranularity_isolineGranularity_MaxPoint.Value;
                requestIsolineGranularityIsNull = false;
            }
            System.Int64? requestIsolineGranularity_isolineGranularity_MaxResolution = null;
            if (cmdletContext.IsolineGranularity_MaxResolution != null)
            {
                requestIsolineGranularity_isolineGranularity_MaxResolution = cmdletContext.IsolineGranularity_MaxResolution.Value;
            }
            if (requestIsolineGranularity_isolineGranularity_MaxResolution != null)
            {
                request.IsolineGranularity.MaxResolution = requestIsolineGranularity_isolineGranularity_MaxResolution.Value;
                requestIsolineGranularityIsNull = false;
            }
             // determine if request.IsolineGranularity should be set to null
            if (requestIsolineGranularityIsNull)
            {
                request.IsolineGranularity = null;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.OptimizeIsolineFor != null)
            {
                request.OptimizeIsolineFor = cmdletContext.OptimizeIsolineFor;
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
            request.OriginOptions = new Amazon.GeoRoutes.Model.IsolineOriginOptions();
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
            Amazon.GeoRoutes.Model.IsolineSideOfStreetOptions requestOriginOptions_originOptions_SideOfStreet = null;
            
             // populate SideOfStreet
            var requestOriginOptions_originOptions_SideOfStreetIsNull = true;
            requestOriginOptions_originOptions_SideOfStreet = new Amazon.GeoRoutes.Model.IsolineSideOfStreetOptions();
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
            Amazon.GeoRoutes.Model.IsolineMatchingOptions requestOriginOptions_originOptions_Matching = null;
            
             // populate Matching
            var requestOriginOptions_originOptions_MatchingIsNull = true;
            requestOriginOptions_originOptions_Matching = new Amazon.GeoRoutes.Model.IsolineMatchingOptions();
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
            
             // populate Thresholds
            var requestThresholdsIsNull = true;
            request.Thresholds = new Amazon.GeoRoutes.Model.IsolineThresholds();
            List<System.Int64> requestThresholds_thresholds_Distance = null;
            if (cmdletContext.Thresholds_Distance != null)
            {
                requestThresholds_thresholds_Distance = cmdletContext.Thresholds_Distance;
            }
            if (requestThresholds_thresholds_Distance != null)
            {
                request.Thresholds.Distance = requestThresholds_thresholds_Distance;
                requestThresholdsIsNull = false;
            }
            List<System.Int64> requestThresholds_thresholds_Time = null;
            if (cmdletContext.Thresholds_Time != null)
            {
                requestThresholds_thresholds_Time = cmdletContext.Thresholds_Time;
            }
            if (requestThresholds_thresholds_Time != null)
            {
                request.Thresholds.Time = requestThresholds_thresholds_Time;
                requestThresholdsIsNull = false;
            }
             // determine if request.Thresholds should be set to null
            if (requestThresholdsIsNull)
            {
                request.Thresholds = null;
            }
            
             // populate Traffic
            var requestTrafficIsNull = true;
            request.Traffic = new Amazon.GeoRoutes.Model.IsolineTrafficOptions();
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
            request.TravelModeOptions = new Amazon.GeoRoutes.Model.IsolineTravelModeOptions();
            Amazon.GeoRoutes.Model.IsolineCarOptions requestTravelModeOptions_travelModeOptions_Car = null;
            
             // populate Car
            var requestTravelModeOptions_travelModeOptions_CarIsNull = true;
            requestTravelModeOptions_travelModeOptions_Car = new Amazon.GeoRoutes.Model.IsolineCarOptions();
            Amazon.GeoRoutes.IsolineEngineType requestTravelModeOptions_travelModeOptions_Car_car_EngineType = null;
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
            Amazon.GeoRoutes.Model.IsolineVehicleLicensePlate requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate = null;
            
             // populate LicensePlate
            var requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlateIsNull = true;
            requestTravelModeOptions_travelModeOptions_Car_travelModeOptions_Car_LicensePlate = new Amazon.GeoRoutes.Model.IsolineVehicleLicensePlate();
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
            Amazon.GeoRoutes.Model.IsolineScooterOptions requestTravelModeOptions_travelModeOptions_Scooter = null;
            
             // populate Scooter
            var requestTravelModeOptions_travelModeOptions_ScooterIsNull = true;
            requestTravelModeOptions_travelModeOptions_Scooter = new Amazon.GeoRoutes.Model.IsolineScooterOptions();
            Amazon.GeoRoutes.IsolineEngineType requestTravelModeOptions_travelModeOptions_Scooter_scooter_EngineType = null;
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
            Amazon.GeoRoutes.Model.IsolineVehicleLicensePlate requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate = null;
            
             // populate LicensePlate
            var requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlateIsNull = true;
            requestTravelModeOptions_travelModeOptions_Scooter_travelModeOptions_Scooter_LicensePlate = new Amazon.GeoRoutes.Model.IsolineVehicleLicensePlate();
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
            Amazon.GeoRoutes.Model.IsolineTruckOptions requestTravelModeOptions_travelModeOptions_Truck = null;
            
             // populate Truck
            var requestTravelModeOptions_travelModeOptions_TruckIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck = new Amazon.GeoRoutes.Model.IsolineTruckOptions();
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
            Amazon.GeoRoutes.IsolineEngineType requestTravelModeOptions_travelModeOptions_Truck_truck_EngineType = null;
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
            Amazon.GeoRoutes.IsolineTruckType requestTravelModeOptions_travelModeOptions_Truck_truck_TruckType = null;
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
            Amazon.GeoRoutes.Model.IsolineVehicleLicensePlate requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate = null;
            
             // populate LicensePlate
            var requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlateIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_LicensePlate = new Amazon.GeoRoutes.Model.IsolineVehicleLicensePlate();
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
            Amazon.GeoRoutes.Model.IsolineTrailerOptions requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = null;
            
             // populate Trailer
            var requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_TrailerIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = new Amazon.GeoRoutes.Model.IsolineTrailerOptions();
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
        
        private Amazon.GeoRoutes.Model.CalculateIsolinesResponse CallAWSServiceOperation(IAmazonGeoRoutes client, Amazon.GeoRoutes.Model.CalculateIsolinesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Routes V2", "CalculateIsolines");
            try
            {
                #if DESKTOP
                return client.CalculateIsolines(request);
                #elif CORECLR
                return client.CalculateIsolinesAsync(request).GetAwaiter().GetResult();
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
            public System.String ArrivalTime { get; set; }
            public List<Amazon.GeoRoutes.Model.IsolineAvoidanceArea> Avoid_Area { get; set; }
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
            public List<Amazon.GeoRoutes.Model.IsolineAvoidanceZoneCategory> Avoid_ZoneCategory { get; set; }
            public System.Boolean? DepartNow { get; set; }
            public System.String DepartureTime { get; set; }
            public List<System.Double> Destination { get; set; }
            public System.Int64? DestinationOptions_AvoidActionsForDistance { get; set; }
            public System.Double? DestinationOptions_Heading { get; set; }
            public System.String DestinationOptions_Matching_NameHint { get; set; }
            public System.Int64? DestinationOptions_Matching_OnRoadThreshold { get; set; }
            public System.Int64? DestinationOptions_Matching_Radius { get; set; }
            public Amazon.GeoRoutes.MatchingStrategy DestinationOptions_Matching_Strategy { get; set; }
            public List<System.Double> DestinationOptions_SideOfStreet_Position { get; set; }
            public Amazon.GeoRoutes.SideOfStreetMatchingStrategy DestinationOptions_SideOfStreet_UseWith { get; set; }
            public Amazon.GeoRoutes.GeometryFormat IsolineGeometryFormat { get; set; }
            public System.Int32? IsolineGranularity_MaxPoint { get; set; }
            public System.Int64? IsolineGranularity_MaxResolution { get; set; }
            public System.String Key { get; set; }
            public Amazon.GeoRoutes.IsolineOptimizationObjective OptimizeIsolineFor { get; set; }
            public Amazon.GeoRoutes.RoutingObjective OptimizeRoutingFor { get; set; }
            public List<System.Double> Origin { get; set; }
            public System.Int64? OriginOptions_AvoidActionsForDistance { get; set; }
            public System.Double? OriginOptions_Heading { get; set; }
            public System.String OriginOptions_Matching_NameHint { get; set; }
            public System.Int64? OriginOptions_Matching_OnRoadThreshold { get; set; }
            public System.Int64? OriginOptions_Matching_Radius { get; set; }
            public Amazon.GeoRoutes.MatchingStrategy OriginOptions_Matching_Strategy { get; set; }
            public List<System.Double> OriginOptions_SideOfStreet_Position { get; set; }
            public Amazon.GeoRoutes.SideOfStreetMatchingStrategy OriginOptions_SideOfStreet_UseWith { get; set; }
            public List<System.Int64> Thresholds_Distance { get; set; }
            public List<System.Int64> Thresholds_Time { get; set; }
            public System.Int64? Traffic_FlowEventThresholdOverride { get; set; }
            public Amazon.GeoRoutes.TrafficUsage Traffic_Usage { get; set; }
            public Amazon.GeoRoutes.IsolineTravelMode TravelMode { get; set; }
            public Amazon.GeoRoutes.IsolineEngineType Car_EngineType { get; set; }
            public System.String TravelModeOptions_Car_LicensePlate_LastCharacter { get; set; }
            public System.Double? Car_MaxSpeed { get; set; }
            public System.Int32? Car_Occupancy { get; set; }
            public Amazon.GeoRoutes.IsolineEngineType Scooter_EngineType { get; set; }
            public System.String TravelModeOptions_Scooter_LicensePlate_LastCharacter { get; set; }
            public System.Double? Scooter_MaxSpeed { get; set; }
            public System.Int32? Scooter_Occupancy { get; set; }
            public System.Int32? Truck_AxleCount { get; set; }
            public Amazon.GeoRoutes.IsolineEngineType Truck_EngineType { get; set; }
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
            public Amazon.GeoRoutes.IsolineTruckType Truck_TruckType { get; set; }
            public System.String Truck_TunnelRestrictionCode { get; set; }
            public System.Int64? Truck_WeightPerAxle { get; set; }
            public System.Int64? WeightPerAxleGroup_Quad { get; set; }
            public System.Int64? WeightPerAxleGroup_Quint { get; set; }
            public System.Int64? WeightPerAxleGroup_Single { get; set; }
            public System.Int64? WeightPerAxleGroup_Tandem { get; set; }
            public System.Int64? WeightPerAxleGroup_Triple { get; set; }
            public System.Int64? Truck_Width { get; set; }
            public System.Func<Amazon.GeoRoutes.Model.CalculateIsolinesResponse, GetGEORIsolineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
