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
using Amazon.GeoRoutes;
using Amazon.GeoRoutes.Model;

namespace Amazon.PowerShell.Cmdlets.GEOR
{
    /// <summary>
    /// Calculates the optimal order to travel between a set of waypoints to minimize either
    /// the travel time or the distance travelled during the journey, based on road network
    /// restrictions and the traffic pattern data.
    /// </summary>
    [Cmdlet("Get", "GEOROptimizedWaypoint")]
    [OutputType("Amazon.GeoRoutes.Model.OptimizeWaypointsResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Routes V2 OptimizeWaypoints API operation.", Operation = new[] {"OptimizeWaypoints"}, SelectReturnType = typeof(Amazon.GeoRoutes.Model.OptimizeWaypointsResponse))]
    [AWSCmdletOutput("Amazon.GeoRoutes.Model.OptimizeWaypointsResponse",
        "This cmdlet returns an Amazon.GeoRoutes.Model.OptimizeWaypointsResponse object containing multiple properties."
    )]
    public partial class GetGEOROptimizedWaypointCmdlet : AmazonGeoRoutesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationOptions_AppointmentTime
        /// <summary>
        /// <para>
        /// <para>Appointment time at the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationOptions_AppointmentTime { get; set; }
        #endregion
        
        #region Parameter Avoid_Area
        /// <summary>
        /// <para>
        /// <para>Areas to be avoided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_Areas")]
        public Amazon.GeoRoutes.Model.WaypointOptimizationAvoidanceArea[] Avoid_Area { get; set; }
        #endregion
        
        #region Parameter Avoid_CarShuttleTrain
        /// <summary>
        /// <para>
        /// <para>Avoidance options for cars-shuttles-trains.</para>
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
        
        #region Parameter From_DayOfWeek
        /// <summary>
        /// <para>
        /// <para>Day of the week.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationOptions_AccessHours_From_DayOfWeek")]
        [AWSConstantClassSource("Amazon.GeoRoutes.DayOfWeek")]
        public Amazon.GeoRoutes.DayOfWeek From_DayOfWeek { get; set; }
        #endregion
        
        #region Parameter To_DayOfWeek
        /// <summary>
        /// <para>
        /// <para>Day of the week.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationOptions_AccessHours_To_DayOfWeek")]
        [AWSConstantClassSource("Amazon.GeoRoutes.DayOfWeek")]
        public Amazon.GeoRoutes.DayOfWeek To_DayOfWeek { get; set; }
        #endregion
        
        #region Parameter DepartureTime
        /// <summary>
        /// <para>
        /// <para>Departure time from the waypoint.</para><para>Time format:<c>YYYY-MM-DDThh:mm:ss.sssZ | YYYY-MM-DDThh:mm:ss.sss+hh:mm</c></para><para>Examples:</para><para><c>2020-04-22T17:57:24Z</c></para><para><c>2020-04-22T17:57:24+02:00</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DepartureTime { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The final position for the route in the World Geodetic System (WGS 84) format: <c>[longitude,
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
        
        #region Parameter Avoid_Ferry
        /// <summary>
        /// <para>
        /// <para>Avoidance options for ferries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Avoid_Ferries")]
        public System.Boolean? Avoid_Ferry { get; set; }
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
        
        #region Parameter DestinationOptions_Id
        /// <summary>
        /// <para>
        /// <para>The waypoint Id.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationOptions_Id { get; set; }
        #endregion
        
        #region Parameter OriginOptions_Id
        /// <summary>
        /// <para>
        /// <para>The Origin Id.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OriginOptions_Id { get; set; }
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
        
        #region Parameter OptimizeSequencingFor
        /// <summary>
        /// <para>
        /// <para>Specifies the optimization criteria for the calculated sequence.</para><para>Default Value: <c>FastestRoute</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.WaypointOptimizationSequencingObjective")]
        public Amazon.GeoRoutes.WaypointOptimizationSequencingObjective OptimizeSequencingFor { get; set; }
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
        
        #region Parameter SideOfStreet_Position
        /// <summary>
        /// <para>
        /// <para>Position defined as <c>[longitude, latitude]</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationOptions_SideOfStreet_Position")]
        public System.Double[] SideOfStreet_Position { get; set; }
        #endregion
        
        #region Parameter RestProfile_Profile
        /// <summary>
        /// <para>
        /// <para>Pre defined rest profiles for a driver schedule. The only currently supported profile
        /// is EU.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Driver_RestProfile_Profile")]
        public System.String RestProfile_Profile { get; set; }
        #endregion
        
        #region Parameter LongCycle_RestDuration
        /// <summary>
        /// <para>
        /// <para>Resting phase of the cycle.</para><para><b>Unit</b>: <c>seconds</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Driver_RestCycles_LongCycle_RestDuration")]
        public System.Int64? LongCycle_RestDuration { get; set; }
        #endregion
        
        #region Parameter ShortCycle_RestDuration
        /// <summary>
        /// <para>
        /// <para>Resting phase of the cycle.</para><para><b>Unit</b>: <c>seconds</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Driver_RestCycles_ShortCycle_RestDuration")]
        public System.Int64? ShortCycle_RestDuration { get; set; }
        #endregion
        
        #region Parameter DestinationOptions_ServiceDuration
        /// <summary>
        /// <para>
        /// <para>Service time spent at the destination. At an appointment, the service time should
        /// be the appointment duration.</para><para><b>Unit</b>: <c>seconds</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? DestinationOptions_ServiceDuration { get; set; }
        #endregion
        
        #region Parameter Pedestrian_Speed
        /// <summary>
        /// <para>
        /// <para>Walking speed.</para><para><b>Unit</b>: <c>KilometersPerHour</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Pedestrian_Speed")]
        public System.Double? Pedestrian_Speed { get; set; }
        #endregion
        
        #region Parameter From_TimeOfDay
        /// <summary>
        /// <para>
        /// <para>Time of the day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationOptions_AccessHours_From_TimeOfDay")]
        public System.String From_TimeOfDay { get; set; }
        #endregion
        
        #region Parameter To_TimeOfDay
        /// <summary>
        /// <para>
        /// <para>Time of the day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationOptions_AccessHours_To_TimeOfDay")]
        public System.String To_TimeOfDay { get; set; }
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
        [AWSConstantClassSource("Amazon.GeoRoutes.WaypointOptimizationTravelMode")]
        public Amazon.GeoRoutes.WaypointOptimizationTravelMode TravelMode { get; set; }
        #endregion
        
        #region Parameter Driver_TreatServiceTimeAs
        /// <summary>
        /// <para>
        /// <para>If the service time provided at a waypoint/destination should be considered as rest
        /// or work. This contributes to the total time breakdown returned within the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoRoutes.WaypointOptimizationServiceTimeTreatment")]
        public Amazon.GeoRoutes.WaypointOptimizationServiceTimeTreatment Driver_TreatServiceTimeAs { get; set; }
        #endregion
        
        #region Parameter Truck_TruckType
        /// <summary>
        /// <para>
        /// <para>Type of the truck.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TravelModeOptions_Truck_TruckType")]
        [AWSConstantClassSource("Amazon.GeoRoutes.WaypointOptimizationTruckType")]
        public Amazon.GeoRoutes.WaypointOptimizationTruckType Truck_TruckType { get; set; }
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
        
        #region Parameter SideOfStreet_UseWith
        /// <summary>
        /// <para>
        /// <para>Strategy that defines when the side of street position should be used. AnyStreet will
        /// always use the provided position.</para><para>Default Value: <c>DividedStreetOnly</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationOptions_SideOfStreet_UseWith")]
        [AWSConstantClassSource("Amazon.GeoRoutes.SideOfStreetMatchingStrategy")]
        public Amazon.GeoRoutes.SideOfStreetMatchingStrategy SideOfStreet_UseWith { get; set; }
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
        
        #region Parameter Waypoint
        /// <summary>
        /// <para>
        /// <para>List of waypoints between the <c>Origin</c> and <c>Destination</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Waypoints")]
        public Amazon.GeoRoutes.Model.WaypointOptimizationWaypoint[] Waypoint { get; set; }
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
        
        #region Parameter LongCycle_WorkDuration
        /// <summary>
        /// <para>
        /// <para>Working phase of the cycle.</para><para><b>Unit</b>: <c>seconds</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Driver_RestCycles_LongCycle_WorkDuration")]
        public System.Int64? LongCycle_WorkDuration { get; set; }
        #endregion
        
        #region Parameter ShortCycle_WorkDuration
        /// <summary>
        /// <para>
        /// <para>Working phase of the cycle.</para><para><b>Unit</b>: <c>seconds</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Driver_RestCycles_ShortCycle_WorkDuration")]
        public System.Int64? ShortCycle_WorkDuration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoRoutes.Model.OptimizeWaypointsResponse).
        /// Specifying the name of a property of type Amazon.GeoRoutes.Model.OptimizeWaypointsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.GeoRoutes.Model.OptimizeWaypointsResponse, GetGEOROptimizedWaypointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Avoid_Area != null)
            {
                context.Avoid_Area = new List<Amazon.GeoRoutes.Model.WaypointOptimizationAvoidanceArea>(this.Avoid_Area);
            }
            context.Avoid_CarShuttleTrain = this.Avoid_CarShuttleTrain;
            context.Avoid_ControlledAccessHighway = this.Avoid_ControlledAccessHighway;
            context.Avoid_DirtRoad = this.Avoid_DirtRoad;
            context.Avoid_Ferry = this.Avoid_Ferry;
            context.Avoid_TollRoad = this.Avoid_TollRoad;
            context.Avoid_Tunnel = this.Avoid_Tunnel;
            context.Avoid_UTurn = this.Avoid_UTurn;
            context.DepartureTime = this.DepartureTime;
            if (this.Destination != null)
            {
                context.Destination = new List<System.Double>(this.Destination);
            }
            context.From_DayOfWeek = this.From_DayOfWeek;
            context.From_TimeOfDay = this.From_TimeOfDay;
            context.To_DayOfWeek = this.To_DayOfWeek;
            context.To_TimeOfDay = this.To_TimeOfDay;
            context.DestinationOptions_AppointmentTime = this.DestinationOptions_AppointmentTime;
            context.DestinationOptions_Heading = this.DestinationOptions_Heading;
            context.DestinationOptions_Id = this.DestinationOptions_Id;
            context.DestinationOptions_ServiceDuration = this.DestinationOptions_ServiceDuration;
            if (this.SideOfStreet_Position != null)
            {
                context.SideOfStreet_Position = new List<System.Double>(this.SideOfStreet_Position);
            }
            context.SideOfStreet_UseWith = this.SideOfStreet_UseWith;
            context.LongCycle_RestDuration = this.LongCycle_RestDuration;
            context.LongCycle_WorkDuration = this.LongCycle_WorkDuration;
            context.ShortCycle_RestDuration = this.ShortCycle_RestDuration;
            context.ShortCycle_WorkDuration = this.ShortCycle_WorkDuration;
            context.RestProfile_Profile = this.RestProfile_Profile;
            context.Driver_TreatServiceTimeAs = this.Driver_TreatServiceTimeAs;
            if (this.Exclude_Country != null)
            {
                context.Exclude_Country = new List<System.String>(this.Exclude_Country);
            }
            context.Key = this.Key;
            context.OptimizeSequencingFor = this.OptimizeSequencingFor;
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
            context.OriginOptions_Id = this.OriginOptions_Id;
            context.Traffic_Usage = this.Traffic_Usage;
            context.TravelMode = this.TravelMode;
            context.Pedestrian_Speed = this.Pedestrian_Speed;
            context.Truck_GrossWeight = this.Truck_GrossWeight;
            if (this.Truck_HazardousCargo != null)
            {
                context.Truck_HazardousCargo = new List<System.String>(this.Truck_HazardousCargo);
            }
            context.Truck_Height = this.Truck_Height;
            context.Truck_Length = this.Truck_Length;
            context.Trailer_TrailerCount = this.Trailer_TrailerCount;
            context.Truck_TruckType = this.Truck_TruckType;
            context.Truck_TunnelRestrictionCode = this.Truck_TunnelRestrictionCode;
            context.Truck_WeightPerAxle = this.Truck_WeightPerAxle;
            context.Truck_Width = this.Truck_Width;
            if (this.Waypoint != null)
            {
                context.Waypoint = new List<Amazon.GeoRoutes.Model.WaypointOptimizationWaypoint>(this.Waypoint);
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
            var request = new Amazon.GeoRoutes.Model.OptimizeWaypointsRequest();
            
            
             // populate Avoid
            var requestAvoidIsNull = true;
            request.Avoid = new Amazon.GeoRoutes.Model.WaypointOptimizationAvoidanceOptions();
            List<Amazon.GeoRoutes.Model.WaypointOptimizationAvoidanceArea> requestAvoid_avoid_Area = null;
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
             // determine if request.Avoid should be set to null
            if (requestAvoidIsNull)
            {
                request.Avoid = null;
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
            request.DestinationOptions = new Amazon.GeoRoutes.Model.WaypointOptimizationDestinationOptions();
            System.String requestDestinationOptions_destinationOptions_AppointmentTime = null;
            if (cmdletContext.DestinationOptions_AppointmentTime != null)
            {
                requestDestinationOptions_destinationOptions_AppointmentTime = cmdletContext.DestinationOptions_AppointmentTime;
            }
            if (requestDestinationOptions_destinationOptions_AppointmentTime != null)
            {
                request.DestinationOptions.AppointmentTime = requestDestinationOptions_destinationOptions_AppointmentTime;
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
            System.String requestDestinationOptions_destinationOptions_Id = null;
            if (cmdletContext.DestinationOptions_Id != null)
            {
                requestDestinationOptions_destinationOptions_Id = cmdletContext.DestinationOptions_Id;
            }
            if (requestDestinationOptions_destinationOptions_Id != null)
            {
                request.DestinationOptions.Id = requestDestinationOptions_destinationOptions_Id;
                requestDestinationOptionsIsNull = false;
            }
            System.Int64? requestDestinationOptions_destinationOptions_ServiceDuration = null;
            if (cmdletContext.DestinationOptions_ServiceDuration != null)
            {
                requestDestinationOptions_destinationOptions_ServiceDuration = cmdletContext.DestinationOptions_ServiceDuration.Value;
            }
            if (requestDestinationOptions_destinationOptions_ServiceDuration != null)
            {
                request.DestinationOptions.ServiceDuration = requestDestinationOptions_destinationOptions_ServiceDuration.Value;
                requestDestinationOptionsIsNull = false;
            }
            Amazon.GeoRoutes.Model.WaypointOptimizationAccessHours requestDestinationOptions_destinationOptions_AccessHours = null;
            
             // populate AccessHours
            var requestDestinationOptions_destinationOptions_AccessHoursIsNull = true;
            requestDestinationOptions_destinationOptions_AccessHours = new Amazon.GeoRoutes.Model.WaypointOptimizationAccessHours();
            Amazon.GeoRoutes.Model.WaypointOptimizationAccessHoursEntry requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From = null;
            
             // populate From
            var requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_FromIsNull = true;
            requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From = new Amazon.GeoRoutes.Model.WaypointOptimizationAccessHoursEntry();
            Amazon.GeoRoutes.DayOfWeek requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From_from_DayOfWeek = null;
            if (cmdletContext.From_DayOfWeek != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From_from_DayOfWeek = cmdletContext.From_DayOfWeek;
            }
            if (requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From_from_DayOfWeek != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From.DayOfWeek = requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From_from_DayOfWeek;
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_FromIsNull = false;
            }
            System.String requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From_from_TimeOfDay = null;
            if (cmdletContext.From_TimeOfDay != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From_from_TimeOfDay = cmdletContext.From_TimeOfDay;
            }
            if (requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From_from_TimeOfDay != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From.TimeOfDay = requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From_from_TimeOfDay;
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_FromIsNull = false;
            }
             // determine if requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From should be set to null
            if (requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_FromIsNull)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From = null;
            }
            if (requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours.From = requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_From;
                requestDestinationOptions_destinationOptions_AccessHoursIsNull = false;
            }
            Amazon.GeoRoutes.Model.WaypointOptimizationAccessHoursEntry requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To = null;
            
             // populate To
            var requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_ToIsNull = true;
            requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To = new Amazon.GeoRoutes.Model.WaypointOptimizationAccessHoursEntry();
            Amazon.GeoRoutes.DayOfWeek requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To_to_DayOfWeek = null;
            if (cmdletContext.To_DayOfWeek != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To_to_DayOfWeek = cmdletContext.To_DayOfWeek;
            }
            if (requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To_to_DayOfWeek != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To.DayOfWeek = requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To_to_DayOfWeek;
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_ToIsNull = false;
            }
            System.String requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To_to_TimeOfDay = null;
            if (cmdletContext.To_TimeOfDay != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To_to_TimeOfDay = cmdletContext.To_TimeOfDay;
            }
            if (requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To_to_TimeOfDay != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To.TimeOfDay = requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To_to_TimeOfDay;
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_ToIsNull = false;
            }
             // determine if requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To should be set to null
            if (requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_ToIsNull)
            {
                requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To = null;
            }
            if (requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To != null)
            {
                requestDestinationOptions_destinationOptions_AccessHours.To = requestDestinationOptions_destinationOptions_AccessHours_destinationOptions_AccessHours_To;
                requestDestinationOptions_destinationOptions_AccessHoursIsNull = false;
            }
             // determine if requestDestinationOptions_destinationOptions_AccessHours should be set to null
            if (requestDestinationOptions_destinationOptions_AccessHoursIsNull)
            {
                requestDestinationOptions_destinationOptions_AccessHours = null;
            }
            if (requestDestinationOptions_destinationOptions_AccessHours != null)
            {
                request.DestinationOptions.AccessHours = requestDestinationOptions_destinationOptions_AccessHours;
                requestDestinationOptionsIsNull = false;
            }
            Amazon.GeoRoutes.Model.WaypointOptimizationSideOfStreetOptions requestDestinationOptions_destinationOptions_SideOfStreet = null;
            
             // populate SideOfStreet
            var requestDestinationOptions_destinationOptions_SideOfStreetIsNull = true;
            requestDestinationOptions_destinationOptions_SideOfStreet = new Amazon.GeoRoutes.Model.WaypointOptimizationSideOfStreetOptions();
            List<System.Double> requestDestinationOptions_destinationOptions_SideOfStreet_sideOfStreet_Position = null;
            if (cmdletContext.SideOfStreet_Position != null)
            {
                requestDestinationOptions_destinationOptions_SideOfStreet_sideOfStreet_Position = cmdletContext.SideOfStreet_Position;
            }
            if (requestDestinationOptions_destinationOptions_SideOfStreet_sideOfStreet_Position != null)
            {
                requestDestinationOptions_destinationOptions_SideOfStreet.Position = requestDestinationOptions_destinationOptions_SideOfStreet_sideOfStreet_Position;
                requestDestinationOptions_destinationOptions_SideOfStreetIsNull = false;
            }
            Amazon.GeoRoutes.SideOfStreetMatchingStrategy requestDestinationOptions_destinationOptions_SideOfStreet_sideOfStreet_UseWith = null;
            if (cmdletContext.SideOfStreet_UseWith != null)
            {
                requestDestinationOptions_destinationOptions_SideOfStreet_sideOfStreet_UseWith = cmdletContext.SideOfStreet_UseWith;
            }
            if (requestDestinationOptions_destinationOptions_SideOfStreet_sideOfStreet_UseWith != null)
            {
                requestDestinationOptions_destinationOptions_SideOfStreet.UseWith = requestDestinationOptions_destinationOptions_SideOfStreet_sideOfStreet_UseWith;
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
             // determine if request.DestinationOptions should be set to null
            if (requestDestinationOptionsIsNull)
            {
                request.DestinationOptions = null;
            }
            
             // populate Driver
            var requestDriverIsNull = true;
            request.Driver = new Amazon.GeoRoutes.Model.WaypointOptimizationDriverOptions();
            Amazon.GeoRoutes.WaypointOptimizationServiceTimeTreatment requestDriver_driver_TreatServiceTimeAs = null;
            if (cmdletContext.Driver_TreatServiceTimeAs != null)
            {
                requestDriver_driver_TreatServiceTimeAs = cmdletContext.Driver_TreatServiceTimeAs;
            }
            if (requestDriver_driver_TreatServiceTimeAs != null)
            {
                request.Driver.TreatServiceTimeAs = requestDriver_driver_TreatServiceTimeAs;
                requestDriverIsNull = false;
            }
            Amazon.GeoRoutes.Model.WaypointOptimizationRestProfile requestDriver_driver_RestProfile = null;
            
             // populate RestProfile
            var requestDriver_driver_RestProfileIsNull = true;
            requestDriver_driver_RestProfile = new Amazon.GeoRoutes.Model.WaypointOptimizationRestProfile();
            System.String requestDriver_driver_RestProfile_restProfile_Profile = null;
            if (cmdletContext.RestProfile_Profile != null)
            {
                requestDriver_driver_RestProfile_restProfile_Profile = cmdletContext.RestProfile_Profile;
            }
            if (requestDriver_driver_RestProfile_restProfile_Profile != null)
            {
                requestDriver_driver_RestProfile.Profile = requestDriver_driver_RestProfile_restProfile_Profile;
                requestDriver_driver_RestProfileIsNull = false;
            }
             // determine if requestDriver_driver_RestProfile should be set to null
            if (requestDriver_driver_RestProfileIsNull)
            {
                requestDriver_driver_RestProfile = null;
            }
            if (requestDriver_driver_RestProfile != null)
            {
                request.Driver.RestProfile = requestDriver_driver_RestProfile;
                requestDriverIsNull = false;
            }
            Amazon.GeoRoutes.Model.WaypointOptimizationRestCycles requestDriver_driver_RestCycles = null;
            
             // populate RestCycles
            var requestDriver_driver_RestCyclesIsNull = true;
            requestDriver_driver_RestCycles = new Amazon.GeoRoutes.Model.WaypointOptimizationRestCycles();
            Amazon.GeoRoutes.Model.WaypointOptimizationRestCycleDurations requestDriver_driver_RestCycles_driver_RestCycles_LongCycle = null;
            
             // populate LongCycle
            var requestDriver_driver_RestCycles_driver_RestCycles_LongCycleIsNull = true;
            requestDriver_driver_RestCycles_driver_RestCycles_LongCycle = new Amazon.GeoRoutes.Model.WaypointOptimizationRestCycleDurations();
            System.Int64? requestDriver_driver_RestCycles_driver_RestCycles_LongCycle_longCycle_RestDuration = null;
            if (cmdletContext.LongCycle_RestDuration != null)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_LongCycle_longCycle_RestDuration = cmdletContext.LongCycle_RestDuration.Value;
            }
            if (requestDriver_driver_RestCycles_driver_RestCycles_LongCycle_longCycle_RestDuration != null)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_LongCycle.RestDuration = requestDriver_driver_RestCycles_driver_RestCycles_LongCycle_longCycle_RestDuration.Value;
                requestDriver_driver_RestCycles_driver_RestCycles_LongCycleIsNull = false;
            }
            System.Int64? requestDriver_driver_RestCycles_driver_RestCycles_LongCycle_longCycle_WorkDuration = null;
            if (cmdletContext.LongCycle_WorkDuration != null)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_LongCycle_longCycle_WorkDuration = cmdletContext.LongCycle_WorkDuration.Value;
            }
            if (requestDriver_driver_RestCycles_driver_RestCycles_LongCycle_longCycle_WorkDuration != null)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_LongCycle.WorkDuration = requestDriver_driver_RestCycles_driver_RestCycles_LongCycle_longCycle_WorkDuration.Value;
                requestDriver_driver_RestCycles_driver_RestCycles_LongCycleIsNull = false;
            }
             // determine if requestDriver_driver_RestCycles_driver_RestCycles_LongCycle should be set to null
            if (requestDriver_driver_RestCycles_driver_RestCycles_LongCycleIsNull)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_LongCycle = null;
            }
            if (requestDriver_driver_RestCycles_driver_RestCycles_LongCycle != null)
            {
                requestDriver_driver_RestCycles.LongCycle = requestDriver_driver_RestCycles_driver_RestCycles_LongCycle;
                requestDriver_driver_RestCyclesIsNull = false;
            }
            Amazon.GeoRoutes.Model.WaypointOptimizationRestCycleDurations requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle = null;
            
             // populate ShortCycle
            var requestDriver_driver_RestCycles_driver_RestCycles_ShortCycleIsNull = true;
            requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle = new Amazon.GeoRoutes.Model.WaypointOptimizationRestCycleDurations();
            System.Int64? requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle_shortCycle_RestDuration = null;
            if (cmdletContext.ShortCycle_RestDuration != null)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle_shortCycle_RestDuration = cmdletContext.ShortCycle_RestDuration.Value;
            }
            if (requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle_shortCycle_RestDuration != null)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle.RestDuration = requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle_shortCycle_RestDuration.Value;
                requestDriver_driver_RestCycles_driver_RestCycles_ShortCycleIsNull = false;
            }
            System.Int64? requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle_shortCycle_WorkDuration = null;
            if (cmdletContext.ShortCycle_WorkDuration != null)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle_shortCycle_WorkDuration = cmdletContext.ShortCycle_WorkDuration.Value;
            }
            if (requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle_shortCycle_WorkDuration != null)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle.WorkDuration = requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle_shortCycle_WorkDuration.Value;
                requestDriver_driver_RestCycles_driver_RestCycles_ShortCycleIsNull = false;
            }
             // determine if requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle should be set to null
            if (requestDriver_driver_RestCycles_driver_RestCycles_ShortCycleIsNull)
            {
                requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle = null;
            }
            if (requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle != null)
            {
                requestDriver_driver_RestCycles.ShortCycle = requestDriver_driver_RestCycles_driver_RestCycles_ShortCycle;
                requestDriver_driver_RestCyclesIsNull = false;
            }
             // determine if requestDriver_driver_RestCycles should be set to null
            if (requestDriver_driver_RestCyclesIsNull)
            {
                requestDriver_driver_RestCycles = null;
            }
            if (requestDriver_driver_RestCycles != null)
            {
                request.Driver.RestCycles = requestDriver_driver_RestCycles;
                requestDriverIsNull = false;
            }
             // determine if request.Driver should be set to null
            if (requestDriverIsNull)
            {
                request.Driver = null;
            }
            
             // populate Exclude
            var requestExcludeIsNull = true;
            request.Exclude = new Amazon.GeoRoutes.Model.WaypointOptimizationExclusionOptions();
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
            if (cmdletContext.OptimizeSequencingFor != null)
            {
                request.OptimizeSequencingFor = cmdletContext.OptimizeSequencingFor;
            }
            if (cmdletContext.Origin != null)
            {
                request.Origin = cmdletContext.Origin;
            }
            
             // populate OriginOptions
            var requestOriginOptionsIsNull = true;
            request.OriginOptions = new Amazon.GeoRoutes.Model.WaypointOptimizationOriginOptions();
            System.String requestOriginOptions_originOptions_Id = null;
            if (cmdletContext.OriginOptions_Id != null)
            {
                requestOriginOptions_originOptions_Id = cmdletContext.OriginOptions_Id;
            }
            if (requestOriginOptions_originOptions_Id != null)
            {
                request.OriginOptions.Id = requestOriginOptions_originOptions_Id;
                requestOriginOptionsIsNull = false;
            }
             // determine if request.OriginOptions should be set to null
            if (requestOriginOptionsIsNull)
            {
                request.OriginOptions = null;
            }
            
             // populate Traffic
            var requestTrafficIsNull = true;
            request.Traffic = new Amazon.GeoRoutes.Model.WaypointOptimizationTrafficOptions();
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
            request.TravelModeOptions = new Amazon.GeoRoutes.Model.WaypointOptimizationTravelModeOptions();
            Amazon.GeoRoutes.Model.WaypointOptimizationPedestrianOptions requestTravelModeOptions_travelModeOptions_Pedestrian = null;
            
             // populate Pedestrian
            var requestTravelModeOptions_travelModeOptions_PedestrianIsNull = true;
            requestTravelModeOptions_travelModeOptions_Pedestrian = new Amazon.GeoRoutes.Model.WaypointOptimizationPedestrianOptions();
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
            Amazon.GeoRoutes.Model.WaypointOptimizationTruckOptions requestTravelModeOptions_travelModeOptions_Truck = null;
            
             // populate Truck
            var requestTravelModeOptions_travelModeOptions_TruckIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck = new Amazon.GeoRoutes.Model.WaypointOptimizationTruckOptions();
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
            Amazon.GeoRoutes.WaypointOptimizationTruckType requestTravelModeOptions_travelModeOptions_Truck_truck_TruckType = null;
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
            Amazon.GeoRoutes.Model.WaypointOptimizationTrailerOptions requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = null;
            
             // populate Trailer
            var requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_TrailerIsNull = true;
            requestTravelModeOptions_travelModeOptions_Truck_travelModeOptions_Truck_Trailer = new Amazon.GeoRoutes.Model.WaypointOptimizationTrailerOptions();
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
        
        private Amazon.GeoRoutes.Model.OptimizeWaypointsResponse CallAWSServiceOperation(IAmazonGeoRoutes client, Amazon.GeoRoutes.Model.OptimizeWaypointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Routes V2", "OptimizeWaypoints");
            try
            {
                #if DESKTOP
                return client.OptimizeWaypoints(request);
                #elif CORECLR
                return client.OptimizeWaypointsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.GeoRoutes.Model.WaypointOptimizationAvoidanceArea> Avoid_Area { get; set; }
            public System.Boolean? Avoid_CarShuttleTrain { get; set; }
            public System.Boolean? Avoid_ControlledAccessHighway { get; set; }
            public System.Boolean? Avoid_DirtRoad { get; set; }
            public System.Boolean? Avoid_Ferry { get; set; }
            public System.Boolean? Avoid_TollRoad { get; set; }
            public System.Boolean? Avoid_Tunnel { get; set; }
            public System.Boolean? Avoid_UTurn { get; set; }
            public System.String DepartureTime { get; set; }
            public List<System.Double> Destination { get; set; }
            public Amazon.GeoRoutes.DayOfWeek From_DayOfWeek { get; set; }
            public System.String From_TimeOfDay { get; set; }
            public Amazon.GeoRoutes.DayOfWeek To_DayOfWeek { get; set; }
            public System.String To_TimeOfDay { get; set; }
            public System.String DestinationOptions_AppointmentTime { get; set; }
            public System.Double? DestinationOptions_Heading { get; set; }
            public System.String DestinationOptions_Id { get; set; }
            public System.Int64? DestinationOptions_ServiceDuration { get; set; }
            public List<System.Double> SideOfStreet_Position { get; set; }
            public Amazon.GeoRoutes.SideOfStreetMatchingStrategy SideOfStreet_UseWith { get; set; }
            public System.Int64? LongCycle_RestDuration { get; set; }
            public System.Int64? LongCycle_WorkDuration { get; set; }
            public System.Int64? ShortCycle_RestDuration { get; set; }
            public System.Int64? ShortCycle_WorkDuration { get; set; }
            public System.String RestProfile_Profile { get; set; }
            public Amazon.GeoRoutes.WaypointOptimizationServiceTimeTreatment Driver_TreatServiceTimeAs { get; set; }
            public List<System.String> Exclude_Country { get; set; }
            public System.String Key { get; set; }
            public Amazon.GeoRoutes.WaypointOptimizationSequencingObjective OptimizeSequencingFor { get; set; }
            public List<System.Double> Origin { get; set; }
            public System.String OriginOptions_Id { get; set; }
            public Amazon.GeoRoutes.TrafficUsage Traffic_Usage { get; set; }
            public Amazon.GeoRoutes.WaypointOptimizationTravelMode TravelMode { get; set; }
            public System.Double? Pedestrian_Speed { get; set; }
            public System.Int64? Truck_GrossWeight { get; set; }
            public List<System.String> Truck_HazardousCargo { get; set; }
            public System.Int64? Truck_Height { get; set; }
            public System.Int64? Truck_Length { get; set; }
            public System.Int32? Trailer_TrailerCount { get; set; }
            public Amazon.GeoRoutes.WaypointOptimizationTruckType Truck_TruckType { get; set; }
            public System.String Truck_TunnelRestrictionCode { get; set; }
            public System.Int64? Truck_WeightPerAxle { get; set; }
            public System.Int64? Truck_Width { get; set; }
            public List<Amazon.GeoRoutes.Model.WaypointOptimizationWaypoint> Waypoint { get; set; }
            public System.Func<Amazon.GeoRoutes.Model.OptimizeWaypointsResponse, GetGEOROptimizedWaypointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
