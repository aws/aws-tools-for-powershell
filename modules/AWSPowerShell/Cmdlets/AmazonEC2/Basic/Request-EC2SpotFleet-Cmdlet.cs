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
    /// Creates a Spot Fleet request.
    /// 
    ///  
    /// <para>
    /// The Spot Fleet request specifies the total target capacity and the On-Demand target
    /// capacity. Amazon EC2 calculates the difference between the total capacity and On-Demand
    /// capacity, and launches the difference as Spot capacity.
    /// </para><para>
    /// You can submit a single request that includes multiple launch specifications that
    /// vary by instance type, AMI, Availability Zone, or subnet.
    /// </para><para>
    /// By default, the Spot Fleet requests Spot Instances in the Spot pool where the price
    /// per unit is the lowest. Each launch specification can include its own instance weighting
    /// that reflects the value of the instance type to your application workload.
    /// </para><para>
    /// Alternatively, you can specify that the Spot Fleet distribute the target capacity
    /// across the Spot pools included in its launch specifications. By ensuring that the
    /// Spot Instances in your Spot Fleet are in different Spot pools, you can improve the
    /// availability of your fleet.
    /// </para><para>
    /// You can specify tags for the Spot Instances. You cannot tag other resource types in
    /// a Spot Fleet request because only the <code>instance</code> resource type is supported.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-fleet-requests.html">Spot
    /// Fleet Requests</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "EC2SpotFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud RequestSpotFleet API operation.", Operation = new[] {"RequestSpotFleet"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.EC2.Model.RequestSpotFleetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestEC2SpotFleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter SpotFleetRequestConfig_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how to allocate the target capacity across the Spot pools specified by the
        /// Spot Fleet request. The default is <code>lowestPrice</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.AllocationStrategy")]
        public Amazon.EC2.AllocationStrategy SpotFleetRequestConfig_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter ClassicLoadBalancersConfig_ClassicLoadBalancer
        /// <summary>
        /// <para>
        /// <para>One or more Classic Load Balancers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SpotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig_ClassicLoadBalancers")]
        public Amazon.EC2.Model.ClassicLoadBalancer[] ClassicLoadBalancersConfig_ClassicLoadBalancer { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// your listings. This helps to avoid duplicate listings. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SpotFleetRequestConfig_ClientToken { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_ExcessCapacityTerminationPolicy
        /// <summary>
        /// <para>
        /// <para>Indicates whether running Spot Instances should be terminated if the target capacity
        /// of the Spot Fleet request is decreased below the current size of the Spot Fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.ExcessCapacityTerminationPolicy")]
        public Amazon.EC2.ExcessCapacityTerminationPolicy SpotFleetRequestConfig_ExcessCapacityTerminationPolicy { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_FulfilledCapacity
        /// <summary>
        /// <para>
        /// <para>The number of units fulfilled by this request compared to the set target capacity.
        /// You cannot set this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double SpotFleetRequestConfig_FulfilledCapacity { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_IamFleetRole
        /// <summary>
        /// <para>
        /// <para>Grants the Spot Fleet permission to terminate Spot Instances on your behalf when you
        /// cancel its Spot Fleet request using <a>CancelSpotFleetRequests</a> or when the Spot
        /// Fleet request expires, if you set <code>terminateInstancesWithExpiration</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SpotFleetRequestConfig_IamFleetRole { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_InstanceInterruptionBehavior
        /// <summary>
        /// <para>
        /// <para>The behavior when a Spot Instance is interrupted. The default is <code>terminate</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.InstanceInterruptionBehavior")]
        public Amazon.EC2.InstanceInterruptionBehavior SpotFleetRequestConfig_InstanceInterruptionBehavior { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_InstancePoolsToUseCount
        /// <summary>
        /// <para>
        /// <para>The number of Spot pools across which to allocate your target Spot capacity. Valid
        /// only when Spot <b>AllocationStrategy</b> is set to <code>lowest-price</code>. Spot
        /// Fleet selects the cheapest Spot pools and evenly allocates your target Spot capacity
        /// across the number of Spot pools that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SpotFleetRequestConfig_InstancePoolsToUseCount { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_LaunchSpecification
        /// <summary>
        /// <para>
        /// <para>The launch specifications for the Spot Fleet request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SpotFleetRequestConfig_LaunchSpecifications")]
        public Amazon.EC2.Model.SpotFleetLaunchSpecification[] SpotFleetRequestConfig_LaunchSpecification { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_LaunchTemplateConfig
        /// <summary>
        /// <para>
        /// <para>The launch template and overrides.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SpotFleetRequestConfig_LaunchTemplateConfigs")]
        public Amazon.EC2.Model.LaunchTemplateConfig[] SpotFleetRequestConfig_LaunchTemplateConfig { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_OnDemandAllocationStrategy
        /// <summary>
        /// <para>
        /// <para>The order of the launch template overrides to use in fulfilling On-Demand capacity.
        /// If you specify <code>lowestPrice</code>, Spot Fleet uses price to determine the order,
        /// launching the lowest price first. If you specify <code>prioritized</code>, Spot Fleet
        /// uses the priority that you assign to each Spot Fleet launch template override, launching
        /// the highest priority first. If you do not specify a value, Spot Fleet defaults to
        /// <code>lowestPrice</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.OnDemandAllocationStrategy")]
        public Amazon.EC2.OnDemandAllocationStrategy SpotFleetRequestConfig_OnDemandAllocationStrategy { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_OnDemandFulfilledCapacity
        /// <summary>
        /// <para>
        /// <para>The number of On-Demand units fulfilled by this request compared to the set target
        /// On-Demand capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double SpotFleetRequestConfig_OnDemandFulfilledCapacity { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_OnDemandTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of On-Demand units to request. You can choose to set the target capacity
        /// in terms of instances or a performance characteristic that is important to your application
        /// workload, such as vCPUs, memory, or I/O. If the request type is <code>maintain</code>,
        /// you can specify a target capacity of 0 and add capacity later.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SpotFleetRequestConfig_OnDemandTargetCapacity { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_ReplaceUnhealthyInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether Spot Fleet should replace unhealthy instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SpotFleetRequestConfig_ReplaceUnhealthyInstances")]
        public System.Boolean SpotFleetRequestConfig_ReplaceUnhealthyInstance { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_SpotPrice
        /// <summary>
        /// <para>
        /// <para>The maximum price per unit hour that you are willing to pay for a Spot Instance. The
        /// default is the On-Demand price.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SpotFleetRequestConfig_SpotPrice { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_TargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of units to request. You can choose to set the target capacity in terms
        /// of instances or a performance characteristic that is important to your application
        /// workload, such as vCPUs, memory, or I/O. If the request type is <code>maintain</code>,
        /// you can specify a target capacity of 0 and add capacity later.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SpotFleetRequestConfig_TargetCapacity { get; set; }
        #endregion
        
        #region Parameter TargetGroupsConfig_TargetGroup
        /// <summary>
        /// <para>
        /// <para>One or more target groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SpotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig_TargetGroups")]
        public Amazon.EC2.Model.TargetGroup[] TargetGroupsConfig_TargetGroup { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_TerminateInstancesWithExpiration
        /// <summary>
        /// <para>
        /// <para>Indicates whether running Spot Instances should be terminated when the Spot Fleet
        /// request expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SpotFleetRequestConfig_TerminateInstancesWithExpiration { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_Type
        /// <summary>
        /// <para>
        /// <para>The type of request. Indicates whether the Spot Fleet only requests the target capacity
        /// or also attempts to maintain it. When this value is <code>request</code>, the Spot
        /// Fleet only places the required requests. It does not attempt to replenish Spot Instances
        /// if capacity is diminished, nor does it submit requests in alternative Spot pools if
        /// capacity is not available. To maintain a certain target capacity, the Spot Fleet places
        /// the required requests to meet capacity and automatically replenishes any interrupted
        /// instances. Default: <code>maintain</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.FleetType")]
        public Amazon.EC2.FleetType SpotFleetRequestConfig_Type { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_ValidFrom
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
            "o the service, use SpotFleetRequestConfig_UtcValidFrom instead.")]
        public System.DateTime SpotFleetRequestConfig_ValidFrom { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_UtcValidFrom
        /// <summary>
        /// <para>
        /// <para>The start date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// The default is to start fulfilling the request immediately.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime SpotFleetRequestConfig_UtcValidFrom { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_ValidUntil
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use ValidUntilUtc instead. Setting either ValidUntil or
        /// ValidUntilUtc results in both ValidUntil and ValidUntilUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. ValidUntil
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The end date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// At this point, no new Spot Instance requests are placed or able to fulfill the request.
        /// The default end date is 7 days from the current date.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use SpotFleetRequestConfig_UtcValidUntil instead.")]
        public System.DateTime SpotFleetRequestConfig_ValidUntil { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestConfig_UtcValidUntil
        /// <summary>
        /// <para>
        /// <para>The end date and time of the request, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).
        /// At this point, no new Spot Instance requests are placed or able to fulfill the request.
        /// The default end date is 7 days from the current date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime SpotFleetRequestConfig_UtcValidUntil { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SpotFleetRequestConfig_SpotPrice", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-EC2SpotFleet (RequestSpotFleet)"))
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
            
            context.SpotFleetRequestConfig_AllocationStrategy = this.SpotFleetRequestConfig_AllocationStrategy;
            context.SpotFleetRequestConfig_ClientToken = this.SpotFleetRequestConfig_ClientToken;
            context.SpotFleetRequestConfig_ExcessCapacityTerminationPolicy = this.SpotFleetRequestConfig_ExcessCapacityTerminationPolicy;
            if (ParameterWasBound("SpotFleetRequestConfig_FulfilledCapacity"))
                context.SpotFleetRequestConfig_FulfilledCapacity = this.SpotFleetRequestConfig_FulfilledCapacity;
            context.SpotFleetRequestConfig_IamFleetRole = this.SpotFleetRequestConfig_IamFleetRole;
            context.SpotFleetRequestConfig_InstanceInterruptionBehavior = this.SpotFleetRequestConfig_InstanceInterruptionBehavior;
            if (ParameterWasBound("SpotFleetRequestConfig_InstancePoolsToUseCount"))
                context.SpotFleetRequestConfig_InstancePoolsToUseCount = this.SpotFleetRequestConfig_InstancePoolsToUseCount;
            if (this.SpotFleetRequestConfig_LaunchSpecification != null)
            {
                context.SpotFleetRequestConfig_LaunchSpecifications = new List<Amazon.EC2.Model.SpotFleetLaunchSpecification>(this.SpotFleetRequestConfig_LaunchSpecification);
            }
            if (this.SpotFleetRequestConfig_LaunchTemplateConfig != null)
            {
                context.SpotFleetRequestConfig_LaunchTemplateConfigs = new List<Amazon.EC2.Model.LaunchTemplateConfig>(this.SpotFleetRequestConfig_LaunchTemplateConfig);
            }
            if (this.ClassicLoadBalancersConfig_ClassicLoadBalancer != null)
            {
                context.SpotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig_ClassicLoadBalancers = new List<Amazon.EC2.Model.ClassicLoadBalancer>(this.ClassicLoadBalancersConfig_ClassicLoadBalancer);
            }
            if (this.TargetGroupsConfig_TargetGroup != null)
            {
                context.SpotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig_TargetGroups = new List<Amazon.EC2.Model.TargetGroup>(this.TargetGroupsConfig_TargetGroup);
            }
            context.SpotFleetRequestConfig_OnDemandAllocationStrategy = this.SpotFleetRequestConfig_OnDemandAllocationStrategy;
            if (ParameterWasBound("SpotFleetRequestConfig_OnDemandFulfilledCapacity"))
                context.SpotFleetRequestConfig_OnDemandFulfilledCapacity = this.SpotFleetRequestConfig_OnDemandFulfilledCapacity;
            if (ParameterWasBound("SpotFleetRequestConfig_OnDemandTargetCapacity"))
                context.SpotFleetRequestConfig_OnDemandTargetCapacity = this.SpotFleetRequestConfig_OnDemandTargetCapacity;
            if (ParameterWasBound("SpotFleetRequestConfig_ReplaceUnhealthyInstance"))
                context.SpotFleetRequestConfig_ReplaceUnhealthyInstances = this.SpotFleetRequestConfig_ReplaceUnhealthyInstance;
            context.SpotFleetRequestConfig_SpotPrice = this.SpotFleetRequestConfig_SpotPrice;
            if (ParameterWasBound("SpotFleetRequestConfig_TargetCapacity"))
                context.SpotFleetRequestConfig_TargetCapacity = this.SpotFleetRequestConfig_TargetCapacity;
            if (ParameterWasBound("SpotFleetRequestConfig_TerminateInstancesWithExpiration"))
                context.SpotFleetRequestConfig_TerminateInstancesWithExpiration = this.SpotFleetRequestConfig_TerminateInstancesWithExpiration;
            context.SpotFleetRequestConfig_Type = this.SpotFleetRequestConfig_Type;
            if (ParameterWasBound("SpotFleetRequestConfig_UtcValidFrom"))
                context.SpotFleetRequestConfig_UtcValidFrom = this.SpotFleetRequestConfig_UtcValidFrom;
            if (ParameterWasBound("SpotFleetRequestConfig_UtcValidUntil"))
                context.SpotFleetRequestConfig_UtcValidUntil = this.SpotFleetRequestConfig_UtcValidUntil;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("SpotFleetRequestConfig_ValidFrom"))
                context.SpotFleetRequestConfig_ValidFrom = this.SpotFleetRequestConfig_ValidFrom;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("SpotFleetRequestConfig_ValidUntil"))
                context.SpotFleetRequestConfig_ValidUntil = this.SpotFleetRequestConfig_ValidUntil;
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
            var request = new Amazon.EC2.Model.RequestSpotFleetRequest();
            
            
             // populate SpotFleetRequestConfig
            bool requestSpotFleetRequestConfigIsNull = true;
            request.SpotFleetRequestConfig = new Amazon.EC2.Model.SpotFleetRequestConfigData();
            Amazon.EC2.AllocationStrategy requestSpotFleetRequestConfig_spotFleetRequestConfig_AllocationStrategy = null;
            if (cmdletContext.SpotFleetRequestConfig_AllocationStrategy != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_AllocationStrategy = cmdletContext.SpotFleetRequestConfig_AllocationStrategy;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_AllocationStrategy != null)
            {
                request.SpotFleetRequestConfig.AllocationStrategy = requestSpotFleetRequestConfig_spotFleetRequestConfig_AllocationStrategy;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.String requestSpotFleetRequestConfig_spotFleetRequestConfig_ClientToken = null;
            if (cmdletContext.SpotFleetRequestConfig_ClientToken != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_ClientToken = cmdletContext.SpotFleetRequestConfig_ClientToken;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_ClientToken != null)
            {
                request.SpotFleetRequestConfig.ClientToken = requestSpotFleetRequestConfig_spotFleetRequestConfig_ClientToken;
                requestSpotFleetRequestConfigIsNull = false;
            }
            Amazon.EC2.ExcessCapacityTerminationPolicy requestSpotFleetRequestConfig_spotFleetRequestConfig_ExcessCapacityTerminationPolicy = null;
            if (cmdletContext.SpotFleetRequestConfig_ExcessCapacityTerminationPolicy != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_ExcessCapacityTerminationPolicy = cmdletContext.SpotFleetRequestConfig_ExcessCapacityTerminationPolicy;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_ExcessCapacityTerminationPolicy != null)
            {
                request.SpotFleetRequestConfig.ExcessCapacityTerminationPolicy = requestSpotFleetRequestConfig_spotFleetRequestConfig_ExcessCapacityTerminationPolicy;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.Double? requestSpotFleetRequestConfig_spotFleetRequestConfig_FulfilledCapacity = null;
            if (cmdletContext.SpotFleetRequestConfig_FulfilledCapacity != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_FulfilledCapacity = cmdletContext.SpotFleetRequestConfig_FulfilledCapacity.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_FulfilledCapacity != null)
            {
                request.SpotFleetRequestConfig.FulfilledCapacity = requestSpotFleetRequestConfig_spotFleetRequestConfig_FulfilledCapacity.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.String requestSpotFleetRequestConfig_spotFleetRequestConfig_IamFleetRole = null;
            if (cmdletContext.SpotFleetRequestConfig_IamFleetRole != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_IamFleetRole = cmdletContext.SpotFleetRequestConfig_IamFleetRole;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_IamFleetRole != null)
            {
                request.SpotFleetRequestConfig.IamFleetRole = requestSpotFleetRequestConfig_spotFleetRequestConfig_IamFleetRole;
                requestSpotFleetRequestConfigIsNull = false;
            }
            Amazon.EC2.InstanceInterruptionBehavior requestSpotFleetRequestConfig_spotFleetRequestConfig_InstanceInterruptionBehavior = null;
            if (cmdletContext.SpotFleetRequestConfig_InstanceInterruptionBehavior != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_InstanceInterruptionBehavior = cmdletContext.SpotFleetRequestConfig_InstanceInterruptionBehavior;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_InstanceInterruptionBehavior != null)
            {
                request.SpotFleetRequestConfig.InstanceInterruptionBehavior = requestSpotFleetRequestConfig_spotFleetRequestConfig_InstanceInterruptionBehavior;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.Int32? requestSpotFleetRequestConfig_spotFleetRequestConfig_InstancePoolsToUseCount = null;
            if (cmdletContext.SpotFleetRequestConfig_InstancePoolsToUseCount != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_InstancePoolsToUseCount = cmdletContext.SpotFleetRequestConfig_InstancePoolsToUseCount.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_InstancePoolsToUseCount != null)
            {
                request.SpotFleetRequestConfig.InstancePoolsToUseCount = requestSpotFleetRequestConfig_spotFleetRequestConfig_InstancePoolsToUseCount.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            List<Amazon.EC2.Model.SpotFleetLaunchSpecification> requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchSpecification = null;
            if (cmdletContext.SpotFleetRequestConfig_LaunchSpecifications != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchSpecification = cmdletContext.SpotFleetRequestConfig_LaunchSpecifications;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchSpecification != null)
            {
                request.SpotFleetRequestConfig.LaunchSpecifications = requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchSpecification;
                requestSpotFleetRequestConfigIsNull = false;
            }
            List<Amazon.EC2.Model.LaunchTemplateConfig> requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchTemplateConfig = null;
            if (cmdletContext.SpotFleetRequestConfig_LaunchTemplateConfigs != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchTemplateConfig = cmdletContext.SpotFleetRequestConfig_LaunchTemplateConfigs;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchTemplateConfig != null)
            {
                request.SpotFleetRequestConfig.LaunchTemplateConfigs = requestSpotFleetRequestConfig_spotFleetRequestConfig_LaunchTemplateConfig;
                requestSpotFleetRequestConfigIsNull = false;
            }
            Amazon.EC2.OnDemandAllocationStrategy requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandAllocationStrategy = null;
            if (cmdletContext.SpotFleetRequestConfig_OnDemandAllocationStrategy != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandAllocationStrategy = cmdletContext.SpotFleetRequestConfig_OnDemandAllocationStrategy;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandAllocationStrategy != null)
            {
                request.SpotFleetRequestConfig.OnDemandAllocationStrategy = requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandAllocationStrategy;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.Double? requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandFulfilledCapacity = null;
            if (cmdletContext.SpotFleetRequestConfig_OnDemandFulfilledCapacity != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandFulfilledCapacity = cmdletContext.SpotFleetRequestConfig_OnDemandFulfilledCapacity.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandFulfilledCapacity != null)
            {
                request.SpotFleetRequestConfig.OnDemandFulfilledCapacity = requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandFulfilledCapacity.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.Int32? requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandTargetCapacity = null;
            if (cmdletContext.SpotFleetRequestConfig_OnDemandTargetCapacity != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandTargetCapacity = cmdletContext.SpotFleetRequestConfig_OnDemandTargetCapacity.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandTargetCapacity != null)
            {
                request.SpotFleetRequestConfig.OnDemandTargetCapacity = requestSpotFleetRequestConfig_spotFleetRequestConfig_OnDemandTargetCapacity.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.Boolean? requestSpotFleetRequestConfig_spotFleetRequestConfig_ReplaceUnhealthyInstance = null;
            if (cmdletContext.SpotFleetRequestConfig_ReplaceUnhealthyInstances != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_ReplaceUnhealthyInstance = cmdletContext.SpotFleetRequestConfig_ReplaceUnhealthyInstances.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_ReplaceUnhealthyInstance != null)
            {
                request.SpotFleetRequestConfig.ReplaceUnhealthyInstances = requestSpotFleetRequestConfig_spotFleetRequestConfig_ReplaceUnhealthyInstance.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.String requestSpotFleetRequestConfig_spotFleetRequestConfig_SpotPrice = null;
            if (cmdletContext.SpotFleetRequestConfig_SpotPrice != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_SpotPrice = cmdletContext.SpotFleetRequestConfig_SpotPrice;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_SpotPrice != null)
            {
                request.SpotFleetRequestConfig.SpotPrice = requestSpotFleetRequestConfig_spotFleetRequestConfig_SpotPrice;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.Int32? requestSpotFleetRequestConfig_spotFleetRequestConfig_TargetCapacity = null;
            if (cmdletContext.SpotFleetRequestConfig_TargetCapacity != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_TargetCapacity = cmdletContext.SpotFleetRequestConfig_TargetCapacity.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_TargetCapacity != null)
            {
                request.SpotFleetRequestConfig.TargetCapacity = requestSpotFleetRequestConfig_spotFleetRequestConfig_TargetCapacity.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.Boolean? requestSpotFleetRequestConfig_spotFleetRequestConfig_TerminateInstancesWithExpiration = null;
            if (cmdletContext.SpotFleetRequestConfig_TerminateInstancesWithExpiration != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_TerminateInstancesWithExpiration = cmdletContext.SpotFleetRequestConfig_TerminateInstancesWithExpiration.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_TerminateInstancesWithExpiration != null)
            {
                request.SpotFleetRequestConfig.TerminateInstancesWithExpiration = requestSpotFleetRequestConfig_spotFleetRequestConfig_TerminateInstancesWithExpiration.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            Amazon.EC2.FleetType requestSpotFleetRequestConfig_spotFleetRequestConfig_Type = null;
            if (cmdletContext.SpotFleetRequestConfig_Type != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_Type = cmdletContext.SpotFleetRequestConfig_Type;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_Type != null)
            {
                request.SpotFleetRequestConfig.Type = requestSpotFleetRequestConfig_spotFleetRequestConfig_Type;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.DateTime? requestSpotFleetRequestConfig_spotFleetRequestConfig_UtcValidFrom = null;
            if (cmdletContext.SpotFleetRequestConfig_UtcValidFrom != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_UtcValidFrom = cmdletContext.SpotFleetRequestConfig_UtcValidFrom.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_UtcValidFrom != null)
            {
                request.SpotFleetRequestConfig.ValidFromUtc = requestSpotFleetRequestConfig_spotFleetRequestConfig_UtcValidFrom.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            System.DateTime? requestSpotFleetRequestConfig_spotFleetRequestConfig_UtcValidUntil = null;
            if (cmdletContext.SpotFleetRequestConfig_UtcValidUntil != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_UtcValidUntil = cmdletContext.SpotFleetRequestConfig_UtcValidUntil.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_UtcValidUntil != null)
            {
                request.SpotFleetRequestConfig.ValidUntilUtc = requestSpotFleetRequestConfig_spotFleetRequestConfig_UtcValidUntil.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidFrom = null;
            if (cmdletContext.SpotFleetRequestConfig_ValidFrom != null)
            {
                if (cmdletContext.SpotFleetRequestConfig_UtcValidFrom != null)
                {
                    throw new ArgumentException("Parameters SpotFleetRequestConfig_ValidFrom and SpotFleetRequestConfig_UtcValidFrom are mutually exclusive.");
                }
                requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidFrom = cmdletContext.SpotFleetRequestConfig_ValidFrom.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidFrom != null)
            {
                request.SpotFleetRequestConfig.ValidFrom = requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidFrom.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidUntil = null;
            if (cmdletContext.SpotFleetRequestConfig_ValidUntil != null)
            {
                if (cmdletContext.SpotFleetRequestConfig_UtcValidUntil != null)
                {
                    throw new ArgumentException("Parameters SpotFleetRequestConfig_ValidUntil and SpotFleetRequestConfig_UtcValidUntil are mutually exclusive.");
                }
                requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidUntil = cmdletContext.SpotFleetRequestConfig_ValidUntil.Value;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidUntil != null)
            {
                request.SpotFleetRequestConfig.ValidUntil = requestSpotFleetRequestConfig_spotFleetRequestConfig_ValidUntil.Value;
                requestSpotFleetRequestConfigIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Amazon.EC2.Model.LoadBalancersConfig requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig = null;
            
             // populate LoadBalancersConfig
            bool requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfigIsNull = true;
            requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig = new Amazon.EC2.Model.LoadBalancersConfig();
            Amazon.EC2.Model.ClassicLoadBalancersConfig requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig = null;
            
             // populate ClassicLoadBalancersConfig
            bool requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfigIsNull = true;
            requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig = new Amazon.EC2.Model.ClassicLoadBalancersConfig();
            List<Amazon.EC2.Model.ClassicLoadBalancer> requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig_classicLoadBalancersConfig_ClassicLoadBalancer = null;
            if (cmdletContext.SpotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig_ClassicLoadBalancers != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig_classicLoadBalancersConfig_ClassicLoadBalancer = cmdletContext.SpotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig_ClassicLoadBalancers;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig_classicLoadBalancersConfig_ClassicLoadBalancer != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig.ClassicLoadBalancers = requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig_classicLoadBalancersConfig_ClassicLoadBalancer;
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfigIsNull = false;
            }
             // determine if requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig should be set to null
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfigIsNull)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig = null;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig.ClassicLoadBalancersConfig = requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig;
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfigIsNull = false;
            }
            Amazon.EC2.Model.TargetGroupsConfig requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig = null;
            
             // populate TargetGroupsConfig
            bool requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfigIsNull = true;
            requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig = new Amazon.EC2.Model.TargetGroupsConfig();
            List<Amazon.EC2.Model.TargetGroup> requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig_targetGroupsConfig_TargetGroup = null;
            if (cmdletContext.SpotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig_TargetGroups != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig_targetGroupsConfig_TargetGroup = cmdletContext.SpotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig_TargetGroups;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig_targetGroupsConfig_TargetGroup != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig.TargetGroups = requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig_targetGroupsConfig_TargetGroup;
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfigIsNull = false;
            }
             // determine if requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig should be set to null
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfigIsNull)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig = null;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig != null)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig.TargetGroupsConfig = requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig_spotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig;
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfigIsNull = false;
            }
             // determine if requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig should be set to null
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfigIsNull)
            {
                requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig = null;
            }
            if (requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig != null)
            {
                request.SpotFleetRequestConfig.LoadBalancersConfig = requestSpotFleetRequestConfig_spotFleetRequestConfig_LoadBalancersConfig;
                requestSpotFleetRequestConfigIsNull = false;
            }
             // determine if request.SpotFleetRequestConfig should be set to null
            if (requestSpotFleetRequestConfigIsNull)
            {
                request.SpotFleetRequestConfig = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.EC2.Model.RequestSpotFleetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RequestSpotFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "RequestSpotFleet");
            try
            {
                #if DESKTOP
                return client.RequestSpotFleet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RequestSpotFleetAsync(request);
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
            public Amazon.EC2.AllocationStrategy SpotFleetRequestConfig_AllocationStrategy { get; set; }
            public System.String SpotFleetRequestConfig_ClientToken { get; set; }
            public Amazon.EC2.ExcessCapacityTerminationPolicy SpotFleetRequestConfig_ExcessCapacityTerminationPolicy { get; set; }
            public System.Double? SpotFleetRequestConfig_FulfilledCapacity { get; set; }
            public System.String SpotFleetRequestConfig_IamFleetRole { get; set; }
            public Amazon.EC2.InstanceInterruptionBehavior SpotFleetRequestConfig_InstanceInterruptionBehavior { get; set; }
            public System.Int32? SpotFleetRequestConfig_InstancePoolsToUseCount { get; set; }
            public List<Amazon.EC2.Model.SpotFleetLaunchSpecification> SpotFleetRequestConfig_LaunchSpecifications { get; set; }
            public List<Amazon.EC2.Model.LaunchTemplateConfig> SpotFleetRequestConfig_LaunchTemplateConfigs { get; set; }
            public List<Amazon.EC2.Model.ClassicLoadBalancer> SpotFleetRequestConfig_LoadBalancersConfig_ClassicLoadBalancersConfig_ClassicLoadBalancers { get; set; }
            public List<Amazon.EC2.Model.TargetGroup> SpotFleetRequestConfig_LoadBalancersConfig_TargetGroupsConfig_TargetGroups { get; set; }
            public Amazon.EC2.OnDemandAllocationStrategy SpotFleetRequestConfig_OnDemandAllocationStrategy { get; set; }
            public System.Double? SpotFleetRequestConfig_OnDemandFulfilledCapacity { get; set; }
            public System.Int32? SpotFleetRequestConfig_OnDemandTargetCapacity { get; set; }
            public System.Boolean? SpotFleetRequestConfig_ReplaceUnhealthyInstances { get; set; }
            public System.String SpotFleetRequestConfig_SpotPrice { get; set; }
            public System.Int32? SpotFleetRequestConfig_TargetCapacity { get; set; }
            public System.Boolean? SpotFleetRequestConfig_TerminateInstancesWithExpiration { get; set; }
            public Amazon.EC2.FleetType SpotFleetRequestConfig_Type { get; set; }
            public System.DateTime? SpotFleetRequestConfig_UtcValidFrom { get; set; }
            public System.DateTime? SpotFleetRequestConfig_UtcValidUntil { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? SpotFleetRequestConfig_ValidFrom { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? SpotFleetRequestConfig_ValidUntil { get; set; }
        }
        
    }
}
