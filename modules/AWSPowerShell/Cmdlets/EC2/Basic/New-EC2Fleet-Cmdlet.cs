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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Launches an EC2 Fleet.
    /// 
    ///  
    /// <para>
    /// You can create a single EC2 Fleet that includes multiple launch specifications that
    /// vary by instance type, AMI, Availability Zone, or subnet.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-fleet.html">Launching
    /// an EC2 Fleet</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Fleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateFleetResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateFleet API operation.", Operation = new[] {"CreateFleet"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateFleetResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateFleetResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateFleetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2FleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter OnDemandOptions_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>The order of the launch template overrides to use in fulfilling On-Demand capacity.
        /// If you specify <code>lowest-price</code>, EC2 Fleet uses price to determine the order,
        /// launching the lowest price first. If you specify <code>prioritized</code>, EC2 Fleet
        /// uses the priority that you assigned to each launch template override, launching the
        /// highest priority first. If you do not specify a value, EC2 Fleet defaults to <code>lowest-price</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.FleetOnDemandAllocationStrategy")]
        public Amazon.EC2.FleetOnDemandAllocationStrategy OnDemandOptions_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter SpotOptions_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how to allocate the target Spot Instance capacity across the Spot Instance
        /// pools specified by the EC2 Fleet.</para><para>If the allocation strategy is <code>lowest-price</code>, EC2 Fleet launches instances
        /// from the Spot Instance pools with the lowest price. This is the default allocation
        /// strategy.</para><para>If the allocation strategy is <code>diversified</code>, EC2 Fleet launches instances
        /// from all of the Spot Instance pools that you specify.</para><para>If the allocation strategy is <code>capacity-optimized</code>, EC2 Fleet launches
        /// instances from Spot Instance pools with optimal capacity for the number of instances
        /// that are launching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.SpotAllocationStrategy")]
        public Amazon.EC2.SpotAllocationStrategy SpotOptions_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_DefaultTargetCapacityType
        /// <summary>
        /// <para>
        /// <para>The default <code>TotalTargetCapacity</code>, which is either <code>Spot</code> or
        /// <code>On-Demand</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DefaultTargetCapacityType")]
        public Amazon.EC2.DefaultTargetCapacityType TargetCapacitySpecification_DefaultTargetCapacityType { get; set; }
        #endregion
        
        #region Parameter ExcessCapacityTerminationPolicy
        /// <summary>
        /// <para>
        /// <para>Indicates whether running instances should be terminated if the total target capacity
        /// of the EC2 Fleet is decreased below the current size of the EC2 Fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.FleetExcessCapacityTerminationPolicy")]
        public Amazon.EC2.FleetExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
        #endregion
        
        #region Parameter SpotOptions_InstanceInterruptionBehavior
        /// <summary>
        /// <para>
        /// <para>The behavior when a Spot Instance is interrupted. The default is <code>terminate</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.SpotInstanceInterruptionBehavior")]
        public Amazon.EC2.SpotInstanceInterruptionBehavior SpotOptions_InstanceInterruptionBehavior { get; set; }
        #endregion
        
        #region Parameter SpotOptions_InstancePoolsToUseCount
        /// <summary>
        /// <para>
        /// <para>The number of Spot pools across which to allocate your target Spot capacity. Valid
        /// only when Spot <b>AllocationStrategy</b> is set to <code>lowest-price</code>. EC2
        /// Fleet selects the cheapest Spot pools and evenly allocates your target Spot capacity
        /// across the number of Spot pools that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SpotOptions_InstancePoolsToUseCount { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateConfig
        /// <summary>
        /// <para>
        /// <para>The configuration for the EC2 Fleet.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LaunchTemplateConfigs")]
        public Amazon.EC2.Model.FleetLaunchTemplateConfigRequest[] LaunchTemplateConfig { get; set; }
        #endregion
        
        #region Parameter OnDemandOptions_MaxTotalPrice
        /// <summary>
        /// <para>
        /// <para>The maximum amount per hour for On-Demand Instances that you're willing to pay.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OnDemandOptions_MaxTotalPrice { get; set; }
        #endregion
        
        #region Parameter SpotOptions_MaxTotalPrice
        /// <summary>
        /// <para>
        /// <para>The maximum amount per hour for Spot Instances that you're willing to pay.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SpotOptions_MaxTotalPrice { get; set; }
        #endregion
        
        #region Parameter OnDemandOptions_MinTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum target capacity for On-Demand Instances in the fleet. If the minimum target
        /// capacity is not reached, the fleet launches no instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OnDemandOptions_MinTargetCapacity { get; set; }
        #endregion
        
        #region Parameter SpotOptions_MinTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum target capacity for Spot Instances in the fleet. If the minimum target
        /// capacity is not reached, the fleet launches no instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SpotOptions_MinTargetCapacity { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_OnDemandTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of On-Demand units to request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetCapacitySpecification_OnDemandTargetCapacity { get; set; }
        #endregion
        
        #region Parameter CapacityRebalance_ReplacementStrategy
        /// <summary>
        /// <para>
        /// <para>The replacement strategy to use. Only available for fleets of type <code>maintain</code>.</para><para>To allow EC2 Fleet to launch a replacement Spot Instance when an instance rebalance
        /// notification is emitted for an existing Spot Instance in the fleet, specify <code>launch</code>.
        /// You must specify a value, otherwise you get an error.</para><note><para>When a replacement instance is launched, the instance marked for rebalance is not
        /// automatically terminated. You can terminate it, or you can wait until Amazon EC2 interrupts
        /// it. You are charged for all instances while they are running.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpotOptions_MaintenanceStrategies_CapacityRebalance_ReplacementStrategy")]
        [AWSConstantClassSource("Amazon.EC2.FleetReplacementStrategy")]
        public Amazon.EC2.FleetReplacementStrategy CapacityRebalance_ReplacementStrategy { get; set; }
        #endregion
        
        #region Parameter ReplaceUnhealthyInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether EC2 Fleet should replace unhealthy instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplaceUnhealthyInstances")]
        public System.Boolean? ReplaceUnhealthyInstance { get; set; }
        #endregion
        
        #region Parameter OnDemandOptions_SingleAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Indicates that the fleet launches all On-Demand Instances into a single Availability
        /// Zone. Supported only for fleets of type <code>instant</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OnDemandOptions_SingleAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter SpotOptions_SingleAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Indicates that the fleet launches all Spot Instances into a single Availability Zone.
        /// Supported only for fleets of type <code>instant</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SpotOptions_SingleAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter OnDemandOptions_SingleInstanceType
        /// <summary>
        /// <para>
        /// <para>Indicates that the fleet uses a single instance type to launch all On-Demand Instances
        /// in the fleet. Supported only for fleets of type <code>instant</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OnDemandOptions_SingleInstanceType { get; set; }
        #endregion
        
        #region Parameter SpotOptions_SingleInstanceType
        /// <summary>
        /// <para>
        /// <para>Indicates that the fleet uses a single instance type to launch all Spot Instances
        /// in the fleet. Supported only for fleets of type <code>instant</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SpotOptions_SingleInstanceType { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_SpotTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of Spot units to request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetCapacitySpecification_SpotTargetCapacity { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The key-value pair for tagging the EC2 Fleet request on creation. The value for <code>ResourceType</code>
        /// must be <code>fleet</code>, otherwise the fleet request fails. To tag instances at
        /// launch, specify the tags in the <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html#create-launch-template">launch
        /// template</a>. For information about tagging after launch, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html#tag-resources">Tagging
        /// your resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TerminateInstancesWithExpiration
        /// <summary>
        /// <para>
        /// <para>Indicates whether running instances should be terminated when the EC2 Fleet expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TerminateInstancesWithExpiration { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_TotalTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of units to request, filled using <code>DefaultTargetCapacityType</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TargetCapacitySpecification_TotalTargetCapacity { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of request. The default value is <code>maintain</code>.</para><ul><li><para><code>maintain</code> - The EC2 Fleet plaees an asynchronous request for your desired
        /// capacity, and continues to maintain your desired Spot capacity by replenishing interrupted
        /// Spot Instances.</para></li><li><para><code>request</code> - The EC2 Fleet places an asynchronous one-time request for
        /// your desired capacity, but does submit Spot requests in alternative capacity pools
        /// if Spot capacity is unavailable, and does not maintain Spot capacity if Spot Instances
        /// are interrupted.</para></li><li><para><code>instant</code> - The EC2 Fleet places a synchronous one-time request for your
        /// desired capacity, and returns errors for any instances that could not be launched.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-fleet-configuration-strategies.html#ec2-fleet-request-type">EC2
        /// Fleet request types</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.FleetType")]
        public Amazon.EC2.FleetType Type { get; set; }
        #endregion
        
        #region Parameter CapacityReservationOptions_UsageStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates whether to use unused Capacity Reservations for fulfilling On-Demand capacity.</para><para>If you specify <code>use-capacity-reservations-first</code>, the fleet uses unused
        /// Capacity Reservations to fulfill On-Demand capacity up to the target On-Demand capacity.
        /// If multiple instance pools have unused Capacity Reservations, the On-Demand allocation
        /// strategy (<code>lowest-price</code> or <code>prioritized</code>) is applied. If the
        /// number of unused Capacity Reservations is less than the On-Demand target capacity,
        /// the remaining On-Demand target capacity is launched according to the On-Demand allocation
        /// strategy (<code>lowest-price</code> or <code>prioritized</code>).</para><para>If you do not specify a value, the fleet fulfils the On-Demand capacity according
        /// to the chosen On-Demand allocation strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnDemandOptions_CapacityReservationOptions_UsageStrategy")]
        [AWSConstantClassSource("Amazon.EC2.FleetCapacityReservationUsageStrategy")]
        public Amazon.EC2.FleetCapacityReservationUsageStrategy CapacityReservationOptions_UsageStrategy { get; set; }
        #endregion
        
        #region Parameter UtcValidFrom
        /// <summary>
        /// <para>
        /// <para>The start date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// The default is to start fulfilling the request immediately.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcValidFrom { get; set; }
        #endregion
        
        #region Parameter UtcValidUntil
        /// <summary>
        /// <para>
        /// <para>The end date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// At this point, no new EC2 Fleet requests are placed or able to fulfill the request.
        /// If no value is specified, the request remains until you cancel it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcValidUntil { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter ValidFrom
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use ValidFromUtc instead. Setting either ValidFrom or
        /// ValidFromUtc results in both ValidFrom and ValidFromUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. ValidFrom
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The start date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// The default is to start fulfilling the request immediately.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcValidFrom instead.")]
        public System.DateTime? ValidFrom { get; set; }
        #endregion
        
        #region Parameter ValidUntil
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use ValidUntilUtc instead. Setting either ValidUntil or
        /// ValidUntilUtc results in both ValidUntil and ValidUntilUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. ValidUntil
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The end date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// At this point, no new EC2 Fleet requests are placed or able to fulfill the request.
        /// If no value is specified, the request remains until you cancel it.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcValidUntil instead.")]
        public System.DateTime? ValidUntil { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateFleetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LaunchTemplateConfig parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LaunchTemplateConfig' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LaunchTemplateConfig' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LaunchTemplateConfig), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Fleet (CreateFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateFleetResponse, NewEC2FleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LaunchTemplateConfig;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ExcessCapacityTerminationPolicy = this.ExcessCapacityTerminationPolicy;
            if (this.LaunchTemplateConfig != null)
            {
                context.LaunchTemplateConfig = new List<Amazon.EC2.Model.FleetLaunchTemplateConfigRequest>(this.LaunchTemplateConfig);
            }
            #if MODULAR
            if (this.LaunchTemplateConfig == null && ParameterWasBound(nameof(this.LaunchTemplateConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchTemplateConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OnDemandOptions_AllocationStrategy = this.OnDemandOptions_AllocationStrategy;
            context.CapacityReservationOptions_UsageStrategy = this.CapacityReservationOptions_UsageStrategy;
            context.OnDemandOptions_MaxTotalPrice = this.OnDemandOptions_MaxTotalPrice;
            context.OnDemandOptions_MinTargetCapacity = this.OnDemandOptions_MinTargetCapacity;
            context.OnDemandOptions_SingleAvailabilityZone = this.OnDemandOptions_SingleAvailabilityZone;
            context.OnDemandOptions_SingleInstanceType = this.OnDemandOptions_SingleInstanceType;
            context.ReplaceUnhealthyInstance = this.ReplaceUnhealthyInstance;
            context.SpotOptions_AllocationStrategy = this.SpotOptions_AllocationStrategy;
            context.SpotOptions_InstanceInterruptionBehavior = this.SpotOptions_InstanceInterruptionBehavior;
            context.SpotOptions_InstancePoolsToUseCount = this.SpotOptions_InstancePoolsToUseCount;
            context.CapacityRebalance_ReplacementStrategy = this.CapacityRebalance_ReplacementStrategy;
            context.SpotOptions_MaxTotalPrice = this.SpotOptions_MaxTotalPrice;
            context.SpotOptions_MinTargetCapacity = this.SpotOptions_MinTargetCapacity;
            context.SpotOptions_SingleAvailabilityZone = this.SpotOptions_SingleAvailabilityZone;
            context.SpotOptions_SingleInstanceType = this.SpotOptions_SingleInstanceType;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TargetCapacitySpecification_DefaultTargetCapacityType = this.TargetCapacitySpecification_DefaultTargetCapacityType;
            context.TargetCapacitySpecification_OnDemandTargetCapacity = this.TargetCapacitySpecification_OnDemandTargetCapacity;
            context.TargetCapacitySpecification_SpotTargetCapacity = this.TargetCapacitySpecification_SpotTargetCapacity;
            context.TargetCapacitySpecification_TotalTargetCapacity = this.TargetCapacitySpecification_TotalTargetCapacity;
            #if MODULAR
            if (this.TargetCapacitySpecification_TotalTargetCapacity == null && ParameterWasBound(nameof(this.TargetCapacitySpecification_TotalTargetCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetCapacitySpecification_TotalTargetCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TerminateInstancesWithExpiration = this.TerminateInstancesWithExpiration;
            context.Type = this.Type;
            context.UtcValidFrom = this.UtcValidFrom;
            context.UtcValidUntil = this.UtcValidUntil;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ValidFrom = this.ValidFrom;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ValidUntil = this.ValidUntil;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.EC2.Model.CreateFleetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExcessCapacityTerminationPolicy != null)
            {
                request.ExcessCapacityTerminationPolicy = cmdletContext.ExcessCapacityTerminationPolicy;
            }
            if (cmdletContext.LaunchTemplateConfig != null)
            {
                request.LaunchTemplateConfigs = cmdletContext.LaunchTemplateConfig;
            }
            
             // populate OnDemandOptions
            var requestOnDemandOptionsIsNull = true;
            request.OnDemandOptions = new Amazon.EC2.Model.OnDemandOptionsRequest();
            Amazon.EC2.FleetOnDemandAllocationStrategy requestOnDemandOptions_onDemandOptions_AllocationStrategy = null;
            if (cmdletContext.OnDemandOptions_AllocationStrategy != null)
            {
                requestOnDemandOptions_onDemandOptions_AllocationStrategy = cmdletContext.OnDemandOptions_AllocationStrategy;
            }
            if (requestOnDemandOptions_onDemandOptions_AllocationStrategy != null)
            {
                request.OnDemandOptions.AllocationStrategy = requestOnDemandOptions_onDemandOptions_AllocationStrategy;
                requestOnDemandOptionsIsNull = false;
            }
            System.String requestOnDemandOptions_onDemandOptions_MaxTotalPrice = null;
            if (cmdletContext.OnDemandOptions_MaxTotalPrice != null)
            {
                requestOnDemandOptions_onDemandOptions_MaxTotalPrice = cmdletContext.OnDemandOptions_MaxTotalPrice;
            }
            if (requestOnDemandOptions_onDemandOptions_MaxTotalPrice != null)
            {
                request.OnDemandOptions.MaxTotalPrice = requestOnDemandOptions_onDemandOptions_MaxTotalPrice;
                requestOnDemandOptionsIsNull = false;
            }
            System.Int32? requestOnDemandOptions_onDemandOptions_MinTargetCapacity = null;
            if (cmdletContext.OnDemandOptions_MinTargetCapacity != null)
            {
                requestOnDemandOptions_onDemandOptions_MinTargetCapacity = cmdletContext.OnDemandOptions_MinTargetCapacity.Value;
            }
            if (requestOnDemandOptions_onDemandOptions_MinTargetCapacity != null)
            {
                request.OnDemandOptions.MinTargetCapacity = requestOnDemandOptions_onDemandOptions_MinTargetCapacity.Value;
                requestOnDemandOptionsIsNull = false;
            }
            System.Boolean? requestOnDemandOptions_onDemandOptions_SingleAvailabilityZone = null;
            if (cmdletContext.OnDemandOptions_SingleAvailabilityZone != null)
            {
                requestOnDemandOptions_onDemandOptions_SingleAvailabilityZone = cmdletContext.OnDemandOptions_SingleAvailabilityZone.Value;
            }
            if (requestOnDemandOptions_onDemandOptions_SingleAvailabilityZone != null)
            {
                request.OnDemandOptions.SingleAvailabilityZone = requestOnDemandOptions_onDemandOptions_SingleAvailabilityZone.Value;
                requestOnDemandOptionsIsNull = false;
            }
            System.Boolean? requestOnDemandOptions_onDemandOptions_SingleInstanceType = null;
            if (cmdletContext.OnDemandOptions_SingleInstanceType != null)
            {
                requestOnDemandOptions_onDemandOptions_SingleInstanceType = cmdletContext.OnDemandOptions_SingleInstanceType.Value;
            }
            if (requestOnDemandOptions_onDemandOptions_SingleInstanceType != null)
            {
                request.OnDemandOptions.SingleInstanceType = requestOnDemandOptions_onDemandOptions_SingleInstanceType.Value;
                requestOnDemandOptionsIsNull = false;
            }
            Amazon.EC2.Model.CapacityReservationOptionsRequest requestOnDemandOptions_onDemandOptions_CapacityReservationOptions = null;
            
             // populate CapacityReservationOptions
            var requestOnDemandOptions_onDemandOptions_CapacityReservationOptionsIsNull = true;
            requestOnDemandOptions_onDemandOptions_CapacityReservationOptions = new Amazon.EC2.Model.CapacityReservationOptionsRequest();
            Amazon.EC2.FleetCapacityReservationUsageStrategy requestOnDemandOptions_onDemandOptions_CapacityReservationOptions_capacityReservationOptions_UsageStrategy = null;
            if (cmdletContext.CapacityReservationOptions_UsageStrategy != null)
            {
                requestOnDemandOptions_onDemandOptions_CapacityReservationOptions_capacityReservationOptions_UsageStrategy = cmdletContext.CapacityReservationOptions_UsageStrategy;
            }
            if (requestOnDemandOptions_onDemandOptions_CapacityReservationOptions_capacityReservationOptions_UsageStrategy != null)
            {
                requestOnDemandOptions_onDemandOptions_CapacityReservationOptions.UsageStrategy = requestOnDemandOptions_onDemandOptions_CapacityReservationOptions_capacityReservationOptions_UsageStrategy;
                requestOnDemandOptions_onDemandOptions_CapacityReservationOptionsIsNull = false;
            }
             // determine if requestOnDemandOptions_onDemandOptions_CapacityReservationOptions should be set to null
            if (requestOnDemandOptions_onDemandOptions_CapacityReservationOptionsIsNull)
            {
                requestOnDemandOptions_onDemandOptions_CapacityReservationOptions = null;
            }
            if (requestOnDemandOptions_onDemandOptions_CapacityReservationOptions != null)
            {
                request.OnDemandOptions.CapacityReservationOptions = requestOnDemandOptions_onDemandOptions_CapacityReservationOptions;
                requestOnDemandOptionsIsNull = false;
            }
             // determine if request.OnDemandOptions should be set to null
            if (requestOnDemandOptionsIsNull)
            {
                request.OnDemandOptions = null;
            }
            if (cmdletContext.ReplaceUnhealthyInstance != null)
            {
                request.ReplaceUnhealthyInstances = cmdletContext.ReplaceUnhealthyInstance.Value;
            }
            
             // populate SpotOptions
            var requestSpotOptionsIsNull = true;
            request.SpotOptions = new Amazon.EC2.Model.SpotOptionsRequest();
            Amazon.EC2.SpotAllocationStrategy requestSpotOptions_spotOptions_AllocationStrategy = null;
            if (cmdletContext.SpotOptions_AllocationStrategy != null)
            {
                requestSpotOptions_spotOptions_AllocationStrategy = cmdletContext.SpotOptions_AllocationStrategy;
            }
            if (requestSpotOptions_spotOptions_AllocationStrategy != null)
            {
                request.SpotOptions.AllocationStrategy = requestSpotOptions_spotOptions_AllocationStrategy;
                requestSpotOptionsIsNull = false;
            }
            Amazon.EC2.SpotInstanceInterruptionBehavior requestSpotOptions_spotOptions_InstanceInterruptionBehavior = null;
            if (cmdletContext.SpotOptions_InstanceInterruptionBehavior != null)
            {
                requestSpotOptions_spotOptions_InstanceInterruptionBehavior = cmdletContext.SpotOptions_InstanceInterruptionBehavior;
            }
            if (requestSpotOptions_spotOptions_InstanceInterruptionBehavior != null)
            {
                request.SpotOptions.InstanceInterruptionBehavior = requestSpotOptions_spotOptions_InstanceInterruptionBehavior;
                requestSpotOptionsIsNull = false;
            }
            System.Int32? requestSpotOptions_spotOptions_InstancePoolsToUseCount = null;
            if (cmdletContext.SpotOptions_InstancePoolsToUseCount != null)
            {
                requestSpotOptions_spotOptions_InstancePoolsToUseCount = cmdletContext.SpotOptions_InstancePoolsToUseCount.Value;
            }
            if (requestSpotOptions_spotOptions_InstancePoolsToUseCount != null)
            {
                request.SpotOptions.InstancePoolsToUseCount = requestSpotOptions_spotOptions_InstancePoolsToUseCount.Value;
                requestSpotOptionsIsNull = false;
            }
            System.String requestSpotOptions_spotOptions_MaxTotalPrice = null;
            if (cmdletContext.SpotOptions_MaxTotalPrice != null)
            {
                requestSpotOptions_spotOptions_MaxTotalPrice = cmdletContext.SpotOptions_MaxTotalPrice;
            }
            if (requestSpotOptions_spotOptions_MaxTotalPrice != null)
            {
                request.SpotOptions.MaxTotalPrice = requestSpotOptions_spotOptions_MaxTotalPrice;
                requestSpotOptionsIsNull = false;
            }
            System.Int32? requestSpotOptions_spotOptions_MinTargetCapacity = null;
            if (cmdletContext.SpotOptions_MinTargetCapacity != null)
            {
                requestSpotOptions_spotOptions_MinTargetCapacity = cmdletContext.SpotOptions_MinTargetCapacity.Value;
            }
            if (requestSpotOptions_spotOptions_MinTargetCapacity != null)
            {
                request.SpotOptions.MinTargetCapacity = requestSpotOptions_spotOptions_MinTargetCapacity.Value;
                requestSpotOptionsIsNull = false;
            }
            System.Boolean? requestSpotOptions_spotOptions_SingleAvailabilityZone = null;
            if (cmdletContext.SpotOptions_SingleAvailabilityZone != null)
            {
                requestSpotOptions_spotOptions_SingleAvailabilityZone = cmdletContext.SpotOptions_SingleAvailabilityZone.Value;
            }
            if (requestSpotOptions_spotOptions_SingleAvailabilityZone != null)
            {
                request.SpotOptions.SingleAvailabilityZone = requestSpotOptions_spotOptions_SingleAvailabilityZone.Value;
                requestSpotOptionsIsNull = false;
            }
            System.Boolean? requestSpotOptions_spotOptions_SingleInstanceType = null;
            if (cmdletContext.SpotOptions_SingleInstanceType != null)
            {
                requestSpotOptions_spotOptions_SingleInstanceType = cmdletContext.SpotOptions_SingleInstanceType.Value;
            }
            if (requestSpotOptions_spotOptions_SingleInstanceType != null)
            {
                request.SpotOptions.SingleInstanceType = requestSpotOptions_spotOptions_SingleInstanceType.Value;
                requestSpotOptionsIsNull = false;
            }
            Amazon.EC2.Model.FleetSpotMaintenanceStrategiesRequest requestSpotOptions_spotOptions_MaintenanceStrategies = null;
            
             // populate MaintenanceStrategies
            var requestSpotOptions_spotOptions_MaintenanceStrategiesIsNull = true;
            requestSpotOptions_spotOptions_MaintenanceStrategies = new Amazon.EC2.Model.FleetSpotMaintenanceStrategiesRequest();
            Amazon.EC2.Model.FleetSpotCapacityRebalanceRequest requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance = null;
            
             // populate CapacityRebalance
            var requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalanceIsNull = true;
            requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance = new Amazon.EC2.Model.FleetSpotCapacityRebalanceRequest();
            Amazon.EC2.FleetReplacementStrategy requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance_capacityRebalance_ReplacementStrategy = null;
            if (cmdletContext.CapacityRebalance_ReplacementStrategy != null)
            {
                requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance_capacityRebalance_ReplacementStrategy = cmdletContext.CapacityRebalance_ReplacementStrategy;
            }
            if (requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance_capacityRebalance_ReplacementStrategy != null)
            {
                requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance.ReplacementStrategy = requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance_capacityRebalance_ReplacementStrategy;
                requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalanceIsNull = false;
            }
             // determine if requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance should be set to null
            if (requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalanceIsNull)
            {
                requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance = null;
            }
            if (requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance != null)
            {
                requestSpotOptions_spotOptions_MaintenanceStrategies.CapacityRebalance = requestSpotOptions_spotOptions_MaintenanceStrategies_spotOptions_MaintenanceStrategies_CapacityRebalance;
                requestSpotOptions_spotOptions_MaintenanceStrategiesIsNull = false;
            }
             // determine if requestSpotOptions_spotOptions_MaintenanceStrategies should be set to null
            if (requestSpotOptions_spotOptions_MaintenanceStrategiesIsNull)
            {
                requestSpotOptions_spotOptions_MaintenanceStrategies = null;
            }
            if (requestSpotOptions_spotOptions_MaintenanceStrategies != null)
            {
                request.SpotOptions.MaintenanceStrategies = requestSpotOptions_spotOptions_MaintenanceStrategies;
                requestSpotOptionsIsNull = false;
            }
             // determine if request.SpotOptions should be set to null
            if (requestSpotOptionsIsNull)
            {
                request.SpotOptions = null;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            
             // populate TargetCapacitySpecification
            var requestTargetCapacitySpecificationIsNull = true;
            request.TargetCapacitySpecification = new Amazon.EC2.Model.TargetCapacitySpecificationRequest();
            Amazon.EC2.DefaultTargetCapacityType requestTargetCapacitySpecification_targetCapacitySpecification_DefaultTargetCapacityType = null;
            if (cmdletContext.TargetCapacitySpecification_DefaultTargetCapacityType != null)
            {
                requestTargetCapacitySpecification_targetCapacitySpecification_DefaultTargetCapacityType = cmdletContext.TargetCapacitySpecification_DefaultTargetCapacityType;
            }
            if (requestTargetCapacitySpecification_targetCapacitySpecification_DefaultTargetCapacityType != null)
            {
                request.TargetCapacitySpecification.DefaultTargetCapacityType = requestTargetCapacitySpecification_targetCapacitySpecification_DefaultTargetCapacityType;
                requestTargetCapacitySpecificationIsNull = false;
            }
            System.Int32? requestTargetCapacitySpecification_targetCapacitySpecification_OnDemandTargetCapacity = null;
            if (cmdletContext.TargetCapacitySpecification_OnDemandTargetCapacity != null)
            {
                requestTargetCapacitySpecification_targetCapacitySpecification_OnDemandTargetCapacity = cmdletContext.TargetCapacitySpecification_OnDemandTargetCapacity.Value;
            }
            if (requestTargetCapacitySpecification_targetCapacitySpecification_OnDemandTargetCapacity != null)
            {
                request.TargetCapacitySpecification.OnDemandTargetCapacity = requestTargetCapacitySpecification_targetCapacitySpecification_OnDemandTargetCapacity.Value;
                requestTargetCapacitySpecificationIsNull = false;
            }
            System.Int32? requestTargetCapacitySpecification_targetCapacitySpecification_SpotTargetCapacity = null;
            if (cmdletContext.TargetCapacitySpecification_SpotTargetCapacity != null)
            {
                requestTargetCapacitySpecification_targetCapacitySpecification_SpotTargetCapacity = cmdletContext.TargetCapacitySpecification_SpotTargetCapacity.Value;
            }
            if (requestTargetCapacitySpecification_targetCapacitySpecification_SpotTargetCapacity != null)
            {
                request.TargetCapacitySpecification.SpotTargetCapacity = requestTargetCapacitySpecification_targetCapacitySpecification_SpotTargetCapacity.Value;
                requestTargetCapacitySpecificationIsNull = false;
            }
            System.Int32? requestTargetCapacitySpecification_targetCapacitySpecification_TotalTargetCapacity = null;
            if (cmdletContext.TargetCapacitySpecification_TotalTargetCapacity != null)
            {
                requestTargetCapacitySpecification_targetCapacitySpecification_TotalTargetCapacity = cmdletContext.TargetCapacitySpecification_TotalTargetCapacity.Value;
            }
            if (requestTargetCapacitySpecification_targetCapacitySpecification_TotalTargetCapacity != null)
            {
                request.TargetCapacitySpecification.TotalTargetCapacity = requestTargetCapacitySpecification_targetCapacitySpecification_TotalTargetCapacity.Value;
                requestTargetCapacitySpecificationIsNull = false;
            }
             // determine if request.TargetCapacitySpecification should be set to null
            if (requestTargetCapacitySpecificationIsNull)
            {
                request.TargetCapacitySpecification = null;
            }
            if (cmdletContext.TerminateInstancesWithExpiration != null)
            {
                request.TerminateInstancesWithExpiration = cmdletContext.TerminateInstancesWithExpiration.Value;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.UtcValidFrom != null)
            {
                request.ValidFromUtc = cmdletContext.UtcValidFrom.Value;
            }
            if (cmdletContext.UtcValidUntil != null)
            {
                request.ValidUntilUtc = cmdletContext.UtcValidUntil.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ValidFrom != null)
            {
                if (cmdletContext.UtcValidFrom != null)
                {
                    throw new System.ArgumentException("Parameters ValidFrom and UtcValidFrom are mutually exclusive.", nameof(this.ValidFrom));
                }
                request.ValidFrom = cmdletContext.ValidFrom.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ValidUntil != null)
            {
                if (cmdletContext.UtcValidUntil != null)
                {
                    throw new System.ArgumentException("Parameters ValidUntil and UtcValidUntil are mutually exclusive.", nameof(this.ValidUntil));
                }
                request.ValidUntil = cmdletContext.ValidUntil.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.EC2.Model.CreateFleetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateFleet");
            try
            {
                #if DESKTOP
                return client.CreateFleet(request);
                #elif CORECLR
                return client.CreateFleetAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.EC2.FleetExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
            public List<Amazon.EC2.Model.FleetLaunchTemplateConfigRequest> LaunchTemplateConfig { get; set; }
            public Amazon.EC2.FleetOnDemandAllocationStrategy OnDemandOptions_AllocationStrategy { get; set; }
            public Amazon.EC2.FleetCapacityReservationUsageStrategy CapacityReservationOptions_UsageStrategy { get; set; }
            public System.String OnDemandOptions_MaxTotalPrice { get; set; }
            public System.Int32? OnDemandOptions_MinTargetCapacity { get; set; }
            public System.Boolean? OnDemandOptions_SingleAvailabilityZone { get; set; }
            public System.Boolean? OnDemandOptions_SingleInstanceType { get; set; }
            public System.Boolean? ReplaceUnhealthyInstance { get; set; }
            public Amazon.EC2.SpotAllocationStrategy SpotOptions_AllocationStrategy { get; set; }
            public Amazon.EC2.SpotInstanceInterruptionBehavior SpotOptions_InstanceInterruptionBehavior { get; set; }
            public System.Int32? SpotOptions_InstancePoolsToUseCount { get; set; }
            public Amazon.EC2.FleetReplacementStrategy CapacityRebalance_ReplacementStrategy { get; set; }
            public System.String SpotOptions_MaxTotalPrice { get; set; }
            public System.Int32? SpotOptions_MinTargetCapacity { get; set; }
            public System.Boolean? SpotOptions_SingleAvailabilityZone { get; set; }
            public System.Boolean? SpotOptions_SingleInstanceType { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.DefaultTargetCapacityType TargetCapacitySpecification_DefaultTargetCapacityType { get; set; }
            public System.Int32? TargetCapacitySpecification_OnDemandTargetCapacity { get; set; }
            public System.Int32? TargetCapacitySpecification_SpotTargetCapacity { get; set; }
            public System.Int32? TargetCapacitySpecification_TotalTargetCapacity { get; set; }
            public System.Boolean? TerminateInstancesWithExpiration { get; set; }
            public Amazon.EC2.FleetType Type { get; set; }
            public System.DateTime? UtcValidFrom { get; set; }
            public System.DateTime? UtcValidUntil { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ValidFrom { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ValidUntil { get; set; }
            public System.Func<Amazon.EC2.Model.CreateFleetResponse, NewEC2FleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
