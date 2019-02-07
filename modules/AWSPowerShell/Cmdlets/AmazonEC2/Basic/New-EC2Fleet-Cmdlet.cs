/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateFleet API operation.", Operation = new[] {"CreateFleet"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateFleetResponse",
        "This cmdlet returns a Amazon.EC2.Model.CreateFleetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.FleetOnDemandAllocationStrategy")]
        public Amazon.EC2.FleetOnDemandAllocationStrategy OnDemandOptions_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter SpotOptions_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how to allocate the target capacity across the Spot pools specified by the
        /// Spot Fleet request. The default is <code>lowestPrice</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.SpotAllocationStrategy")]
        public Amazon.EC2.SpotAllocationStrategy SpotOptions_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_DefaultTargetCapacityType
        /// <summary>
        /// <para>
        /// <para>The default <code>TotalTargetCapacity</code>, which is either <code>Spot</code> or
        /// <code>On-Demand</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.FleetExcessCapacityTerminationPolicy")]
        public Amazon.EC2.FleetExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
        #endregion
        
        #region Parameter SpotOptions_InstanceInterruptionBehavior
        /// <summary>
        /// <para>
        /// <para>The behavior when a Spot Instance is interrupted. The default is <code>terminate</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.Int32 SpotOptions_InstancePoolsToUseCount { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateConfig
        /// <summary>
        /// <para>
        /// <para>The configuration for the EC2 Fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("LaunchTemplateConfigs")]
        public Amazon.EC2.Model.FleetLaunchTemplateConfigRequest[] LaunchTemplateConfig { get; set; }
        #endregion
        
        #region Parameter OnDemandOptions_MinTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum target capacity for On-Demand Instances in the fleet. If the minimum target
        /// capacity is not reached, the fleet launches no instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 OnDemandOptions_MinTargetCapacity { get; set; }
        #endregion
        
        #region Parameter SpotOptions_MinTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum target capacity for Spot Instances in the fleet. If the minimum target
        /// capacity is not reached, the fleet launches no instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SpotOptions_MinTargetCapacity { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_OnDemandTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of On-Demand units to request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TargetCapacitySpecification_OnDemandTargetCapacity { get; set; }
        #endregion
        
        #region Parameter ReplaceUnhealthyInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether EC2 Fleet should replace unhealthy instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReplaceUnhealthyInstances")]
        public System.Boolean ReplaceUnhealthyInstance { get; set; }
        #endregion
        
        #region Parameter OnDemandOptions_SingleAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Indicates that the fleet launches all On-Demand Instances into a single Availability
        /// Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean OnDemandOptions_SingleAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter SpotOptions_SingleAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Indicates that the fleet launches all Spot Instances into a single Availability Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SpotOptions_SingleAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter OnDemandOptions_SingleInstanceType
        /// <summary>
        /// <para>
        /// <para>Indicates that the fleet uses a single instance type to launch all On-Demand Instances
        /// in the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean OnDemandOptions_SingleInstanceType { get; set; }
        #endregion
        
        #region Parameter SpotOptions_SingleInstanceType
        /// <summary>
        /// <para>
        /// <para>Indicates that the fleet uses a single instance type to launch all Spot Instances
        /// in the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SpotOptions_SingleInstanceType { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_SpotTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of Spot units to request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TargetCapacitySpecification_SpotTargetCapacity { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The key-value pair for tagging the EC2 Fleet request on creation. The value for <code>ResourceType</code>
        /// must be <code>fleet</code>, otherwise the fleet request fails. To tag instances at
        /// launch, specify the tags in the <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html#create-launch-template">launch
        /// template</a>. For information about tagging after launch, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html#tag-resources">Tagging
        /// Your Resources</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TerminateInstancesWithExpiration
        /// <summary>
        /// <para>
        /// <para>Indicates whether running instances should be terminated when the EC2 Fleet expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean TerminateInstancesWithExpiration { get; set; }
        #endregion
        
        #region Parameter TargetCapacitySpecification_TotalTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of units to request, filled using <code>DefaultTargetCapacityType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TargetCapacitySpecification_TotalTargetCapacity { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the request. By default, the EC2 Fleet places an asynchronous request
        /// for your desired capacity, and maintains it by replenishing interrupted Spot Instances
        /// (<code>maintain</code>). A value of <code>instant</code> places a synchronous one-time
        /// request, and returns errors for any instances that could not be launched. A value
        /// of <code>request</code> places an asynchronous one-time request without maintaining
        /// capacity or submitting requests in alternative capacity pools if capacity is unavailable.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-fleet-configuration-strategies.html#ec2-fleet-request-type">EC2
        /// Fleet Request Types</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.FleetType")]
        public Amazon.EC2.FleetType Type { get; set; }
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
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use UtcValidFrom instead.")]
        public System.DateTime ValidFrom { get; set; }
        #endregion
        
        #region Parameter UtcValidFrom
        /// <summary>
        /// <para>
        /// <para>The start date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// The default is to start fulfilling the request immediately.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime UtcValidFrom { get; set; }
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
        /// The default end date is 7 days from the current date.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use UtcValidUntil instead.")]
        public System.DateTime ValidUntil { get; set; }
        #endregion
        
        #region Parameter UtcValidUntil
        /// <summary>
        /// <para>
        /// <para>The end date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// At this point, no new EC2 Fleet requests are placed or able to fulfill the request.
        /// The default end date is 7 days from the current date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime UtcValidUntil { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LaunchTemplateConfig", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Fleet (CreateFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientToken = this.ClientToken;
            context.ExcessCapacityTerminationPolicy = this.ExcessCapacityTerminationPolicy;
            if (this.LaunchTemplateConfig != null)
            {
                context.LaunchTemplateConfigs = new List<Amazon.EC2.Model.FleetLaunchTemplateConfigRequest>(this.LaunchTemplateConfig);
            }
            context.OnDemandOptions_AllocationStrategy = this.OnDemandOptions_AllocationStrategy;
            if (ParameterWasBound("OnDemandOptions_MinTargetCapacity"))
                context.OnDemandOptions_MinTargetCapacity = this.OnDemandOptions_MinTargetCapacity;
            if (ParameterWasBound("OnDemandOptions_SingleAvailabilityZone"))
                context.OnDemandOptions_SingleAvailabilityZone = this.OnDemandOptions_SingleAvailabilityZone;
            if (ParameterWasBound("OnDemandOptions_SingleInstanceType"))
                context.OnDemandOptions_SingleInstanceType = this.OnDemandOptions_SingleInstanceType;
            if (ParameterWasBound("ReplaceUnhealthyInstance"))
                context.ReplaceUnhealthyInstances = this.ReplaceUnhealthyInstance;
            context.SpotOptions_AllocationStrategy = this.SpotOptions_AllocationStrategy;
            context.SpotOptions_InstanceInterruptionBehavior = this.SpotOptions_InstanceInterruptionBehavior;
            if (ParameterWasBound("SpotOptions_InstancePoolsToUseCount"))
                context.SpotOptions_InstancePoolsToUseCount = this.SpotOptions_InstancePoolsToUseCount;
            if (ParameterWasBound("SpotOptions_MinTargetCapacity"))
                context.SpotOptions_MinTargetCapacity = this.SpotOptions_MinTargetCapacity;
            if (ParameterWasBound("SpotOptions_SingleAvailabilityZone"))
                context.SpotOptions_SingleAvailabilityZone = this.SpotOptions_SingleAvailabilityZone;
            if (ParameterWasBound("SpotOptions_SingleInstanceType"))
                context.SpotOptions_SingleInstanceType = this.SpotOptions_SingleInstanceType;
            if (this.TagSpecification != null)
            {
                context.TagSpecifications = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TargetCapacitySpecification_DefaultTargetCapacityType = this.TargetCapacitySpecification_DefaultTargetCapacityType;
            if (ParameterWasBound("TargetCapacitySpecification_OnDemandTargetCapacity"))
                context.TargetCapacitySpecification_OnDemandTargetCapacity = this.TargetCapacitySpecification_OnDemandTargetCapacity;
            if (ParameterWasBound("TargetCapacitySpecification_SpotTargetCapacity"))
                context.TargetCapacitySpecification_SpotTargetCapacity = this.TargetCapacitySpecification_SpotTargetCapacity;
            if (ParameterWasBound("TargetCapacitySpecification_TotalTargetCapacity"))
                context.TargetCapacitySpecification_TotalTargetCapacity = this.TargetCapacitySpecification_TotalTargetCapacity;
            if (ParameterWasBound("TerminateInstancesWithExpiration"))
                context.TerminateInstancesWithExpiration = this.TerminateInstancesWithExpiration;
            context.Type = this.Type;
            if (ParameterWasBound("UtcValidFrom"))
                context.UtcValidFrom = this.UtcValidFrom;
            if (ParameterWasBound("UtcValidUntil"))
                context.UtcValidUntil = this.UtcValidUntil;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("ValidFrom"))
                context.ValidFrom = this.ValidFrom;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("ValidUntil"))
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
            if (cmdletContext.LaunchTemplateConfigs != null)
            {
                request.LaunchTemplateConfigs = cmdletContext.LaunchTemplateConfigs;
            }
            
             // populate OnDemandOptions
            bool requestOnDemandOptionsIsNull = true;
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
             // determine if request.OnDemandOptions should be set to null
            if (requestOnDemandOptionsIsNull)
            {
                request.OnDemandOptions = null;
            }
            if (cmdletContext.ReplaceUnhealthyInstances != null)
            {
                request.ReplaceUnhealthyInstances = cmdletContext.ReplaceUnhealthyInstances.Value;
            }
            
             // populate SpotOptions
            bool requestSpotOptionsIsNull = true;
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
             // determine if request.SpotOptions should be set to null
            if (requestSpotOptionsIsNull)
            {
                request.SpotOptions = null;
            }
            if (cmdletContext.TagSpecifications != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecifications;
            }
            
             // populate TargetCapacitySpecification
            bool requestTargetCapacitySpecificationIsNull = true;
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
                    throw new ArgumentException("Parameters ValidFrom and UtcValidFrom are mutually exclusive.");
                }
                request.ValidFrom = cmdletContext.ValidFrom.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ValidUntil != null)
            {
                if (cmdletContext.UtcValidUntil != null)
                {
                    throw new ArgumentException("Parameters ValidUntil and UtcValidUntil are mutually exclusive.");
                }
                request.ValidUntil = cmdletContext.ValidUntil.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateFleet");
            try
            {
                #if DESKTOP
                return client.CreateFleet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateFleetAsync(request);
                return task.Result;
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
            public List<Amazon.EC2.Model.FleetLaunchTemplateConfigRequest> LaunchTemplateConfigs { get; set; }
            public Amazon.EC2.FleetOnDemandAllocationStrategy OnDemandOptions_AllocationStrategy { get; set; }
            public System.Int32? OnDemandOptions_MinTargetCapacity { get; set; }
            public System.Boolean? OnDemandOptions_SingleAvailabilityZone { get; set; }
            public System.Boolean? OnDemandOptions_SingleInstanceType { get; set; }
            public System.Boolean? ReplaceUnhealthyInstances { get; set; }
            public Amazon.EC2.SpotAllocationStrategy SpotOptions_AllocationStrategy { get; set; }
            public Amazon.EC2.SpotInstanceInterruptionBehavior SpotOptions_InstanceInterruptionBehavior { get; set; }
            public System.Int32? SpotOptions_InstancePoolsToUseCount { get; set; }
            public System.Int32? SpotOptions_MinTargetCapacity { get; set; }
            public System.Boolean? SpotOptions_SingleAvailabilityZone { get; set; }
            public System.Boolean? SpotOptions_SingleInstanceType { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecifications { get; set; }
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
        }
        
    }
}
