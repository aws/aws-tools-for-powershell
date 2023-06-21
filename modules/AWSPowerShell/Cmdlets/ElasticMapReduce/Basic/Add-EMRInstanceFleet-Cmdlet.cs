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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Adds an instance fleet to a running cluster.
    /// 
    ///  <note><para>
    /// The instance fleet configuration is available only in Amazon EMR releases 4.8.0 and
    /// later, excluding 5.0.x.
    /// </para></note>
    /// </summary>
    [Cmdlet("Add", "EMRInstanceFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce AddInstanceFleet API operation.", Operation = new[] {"AddInstanceFleet"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse))]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse",
        "This cmdlet returns an Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddEMRInstanceFleetCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter OnDemandSpecification_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the strategy to use in launching On-Demand instance fleets. Currently, the
        /// only option is <code>lowest-price</code> (the default), which launches the lowest
        /// price first.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_LaunchSpecifications_OnDemandSpecification_AllocationStrategy")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.OnDemandProvisioningAllocationStrategy")]
        public Amazon.ElasticMapReduce.OnDemandProvisioningAllocationStrategy OnDemandSpecification_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter SpotSpecification_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para> Specifies the strategy to use in launching Spot Instance fleets. Currently, the only
        /// option is capacity-optimized (the default), which launches instances from Spot Instance
        /// pools with optimal capacity for the number of instances that are launching. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_LaunchSpecifications_SpotSpecification_AllocationStrategy")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.SpotProvisioningAllocationStrategy")]
        public Amazon.ElasticMapReduce.SpotProvisioningAllocationStrategy SpotSpecification_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter SpotSpecification_BlockDurationMinute
        /// <summary>
        /// <para>
        /// <para>The defined duration for Spot Instances (also known as Spot blocks) in minutes. When
        /// specified, the Spot Instance does not terminate before the defined duration expires,
        /// and defined duration pricing for Spot Instances applies. Valid values are 60, 120,
        /// 180, 240, 300, or 360. The duration period starts as soon as a Spot Instance receives
        /// its instance ID. At the end of the duration, Amazon EC2 marks the Spot Instance for
        /// termination and provides a Spot Instance termination notice, which gives the instance
        /// a two-minute warning before it terminates. </para><note><para>Spot Instances with a defined duration (also known as Spot blocks) are no longer available
        /// to new customers from July 1, 2021. For customers who have previously used the feature,
        /// we will continue to support Spot Instances with a defined duration until December
        /// 31, 2022. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_LaunchSpecifications_SpotSpecification_BlockDurationMinutes")]
        public System.Int32? SpotSpecification_BlockDurationMinute { get; set; }
        #endregion
        
        #region Parameter CapacityReservationOptions_CapacityReservationPreference
        /// <summary>
        /// <para>
        /// <para>Indicates the instance's Capacity Reservation preferences. Possible preferences include:</para><ul><li><para><code>open</code> - The instance can run in any open Capacity Reservation that has
        /// matching attributes (instance type, platform, Availability Zone).</para></li><li><para><code>none</code> - The instance avoids running in a Capacity Reservation even if
        /// one is available. The instance runs as an On-Demand Instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_CapacityReservationPreference")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.OnDemandCapacityReservationPreference")]
        public Amazon.ElasticMapReduce.OnDemandCapacityReservationPreference CapacityReservationOptions_CapacityReservationPreference { get; set; }
        #endregion
        
        #region Parameter CapacityReservationOptions_CapacityReservationResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Capacity Reservation resource group in which to run the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_CapacityReservationResourceGroupArn")]
        public System.String CapacityReservationOptions_CapacityReservationResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster.</para>
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_InstanceFleetType
        /// <summary>
        /// <para>
        /// <para>The node type that the instance fleet hosts. Valid values are MASTER, CORE, and TASK.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.InstanceFleetType")]
        public Amazon.ElasticMapReduce.InstanceFleetType InstanceFleet_InstanceFleetType { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_InstanceTypeConfig
        /// <summary>
        /// <para>
        /// <para>The instance type configurations that define the Amazon EC2 instances in the instance
        /// fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_InstanceTypeConfigs")]
        public Amazon.ElasticMapReduce.Model.InstanceTypeConfig[] InstanceFleet_InstanceTypeConfig { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_Name
        /// <summary>
        /// <para>
        /// <para>The friendly name of the instance fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceFleet_Name { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_TargetOnDemandCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity of On-Demand units for the instance fleet, which determines how
        /// many On-Demand Instances to provision. When the instance fleet launches, Amazon EMR
        /// tries to provision On-Demand Instances as specified by <a>InstanceTypeConfig</a>.
        /// Each instance configuration has a specified <code>WeightedCapacity</code>. When an
        /// On-Demand Instance is provisioned, the <code>WeightedCapacity</code> units count toward
        /// the target capacity. Amazon EMR provisions instances until the target capacity is
        /// totally fulfilled, even if this results in an overage. For example, if there are 2
        /// units remaining to fulfill capacity, and Amazon EMR can only provision an instance
        /// with a <code>WeightedCapacity</code> of 5 units, the instance is provisioned, and
        /// the target capacity is exceeded by 3 units.</para><note><para>If not specified or set to 0, only Spot Instances are provisioned for the instance
        /// fleet using <code>TargetSpotCapacity</code>. At least one of <code>TargetSpotCapacity</code>
        /// and <code>TargetOnDemandCapacity</code> should be greater than 0. For a master instance
        /// fleet, only one of <code>TargetSpotCapacity</code> and <code>TargetOnDemandCapacity</code>
        /// can be specified, and its value must be 1.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceFleet_TargetOnDemandCapacity { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_TargetSpotCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity of Spot units for the instance fleet, which determines how many
        /// Spot Instances to provision. When the instance fleet launches, Amazon EMR tries to
        /// provision Spot Instances as specified by <a>InstanceTypeConfig</a>. Each instance
        /// configuration has a specified <code>WeightedCapacity</code>. When a Spot Instance
        /// is provisioned, the <code>WeightedCapacity</code> units count toward the target capacity.
        /// Amazon EMR provisions instances until the target capacity is totally fulfilled, even
        /// if this results in an overage. For example, if there are 2 units remaining to fulfill
        /// capacity, and Amazon EMR can only provision an instance with a <code>WeightedCapacity</code>
        /// of 5 units, the instance is provisioned, and the target capacity is exceeded by 3
        /// units.</para><note><para>If not specified or set to 0, only On-Demand Instances are provisioned for the instance
        /// fleet. At least one of <code>TargetSpotCapacity</code> and <code>TargetOnDemandCapacity</code>
        /// should be greater than 0. For a master instance fleet, only one of <code>TargetSpotCapacity</code>
        /// and <code>TargetOnDemandCapacity</code> can be specified, and its value must be 1.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceFleet_TargetSpotCapacity { get; set; }
        #endregion
        
        #region Parameter SpotSpecification_TimeoutAction
        /// <summary>
        /// <para>
        /// <para>The action to take when <code>TargetSpotCapacity</code> has not been fulfilled when
        /// the <code>TimeoutDurationMinutes</code> has expired; that is, when all Spot Instances
        /// could not be provisioned within the Spot provisioning timeout. Valid values are <code>TERMINATE_CLUSTER</code>
        /// and <code>SWITCH_TO_ON_DEMAND</code>. SWITCH_TO_ON_DEMAND specifies that if no Spot
        /// Instances are available, On-Demand Instances should be provisioned to fulfill any
        /// remaining Spot capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutAction")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction")]
        public Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction SpotSpecification_TimeoutAction { get; set; }
        #endregion
        
        #region Parameter SpotSpecification_TimeoutDurationMinute
        /// <summary>
        /// <para>
        /// <para>The Spot provisioning timeout period in minutes. If Spot Instances are not provisioned
        /// within this time period, the <code>TimeOutAction</code> is taken. Minimum value is
        /// 5 and maximum value is 1440. The timeout applies only during initial provisioning,
        /// when the cluster is first created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutDurationMinutes")]
        public System.Int32? SpotSpecification_TimeoutDurationMinute { get; set; }
        #endregion
        
        #region Parameter OnDemandResizeSpecification_TimeoutDurationMinute
        /// <summary>
        /// <para>
        /// <para>On-Demand resize timeout in minutes. If On-Demand Instances are not provisioned within
        /// this time, the resize workflow stops. The minimum value is 5 minutes, and the maximum
        /// value is 10,080 minutes (7 days). The timeout applies to all resize workflows on the
        /// Instance Fleet. The resize could be triggered by Amazon EMR Managed Scaling or by
        /// the customer (via Amazon EMR Console, Amazon EMR CLI modify-instance-fleet or Amazon
        /// EMR SDK ModifyInstanceFleet API) or by Amazon EMR due to Amazon EC2 Spot Reclamation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_ResizeSpecifications_OnDemandResizeSpecification_TimeoutDurationMinutes")]
        public System.Int32? OnDemandResizeSpecification_TimeoutDurationMinute { get; set; }
        #endregion
        
        #region Parameter SpotResizeSpecification_TimeoutDurationMinute
        /// <summary>
        /// <para>
        /// <para>Spot resize timeout in minutes. If Spot Instances are not provisioned within this
        /// time, the resize workflow will stop provisioning of Spot instances. Minimum value
        /// is 5 minutes and maximum value is 10,080 minutes (7 days). The timeout applies to
        /// all resize workflows on the Instance Fleet. The resize could be triggered by Amazon
        /// EMR Managed Scaling or by the customer (via Amazon EMR Console, Amazon EMR CLI modify-instance-fleet
        /// or Amazon EMR SDK ModifyInstanceFleet API) or by Amazon EMR due to Amazon EC2 Spot
        /// Reclamation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_ResizeSpecifications_SpotResizeSpecification_TimeoutDurationMinutes")]
        public System.Int32? SpotResizeSpecification_TimeoutDurationMinute { get; set; }
        #endregion
        
        #region Parameter CapacityReservationOptions_UsageStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates whether to use unused Capacity Reservations for fulfilling On-Demand capacity.</para><para>If you specify <code>use-capacity-reservations-first</code>, the fleet uses unused
        /// Capacity Reservations to fulfill On-Demand capacity up to the target On-Demand capacity.
        /// If multiple instance pools have unused Capacity Reservations, the On-Demand allocation
        /// strategy (<code>lowest-price</code>) is applied. If the number of unused Capacity
        /// Reservations is less than the On-Demand target capacity, the remaining On-Demand target
        /// capacity is launched according to the On-Demand allocation strategy (<code>lowest-price</code>).</para><para>If you do not specify a value, the fleet fulfills the On-Demand capacity according
        /// to the chosen On-Demand allocation strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_UsageStrategy")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.OnDemandCapacityReservationUsageStrategy")]
        public Amazon.ElasticMapReduce.OnDemandCapacityReservationUsageStrategy CapacityReservationOptions_UsageStrategy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EMRInstanceFleet (AddInstanceFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse, AddEMRInstanceFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceFleet_InstanceFleetType = this.InstanceFleet_InstanceFleetType;
            #if MODULAR
            if (this.InstanceFleet_InstanceFleetType == null && ParameterWasBound(nameof(this.InstanceFleet_InstanceFleetType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceFleet_InstanceFleetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InstanceFleet_InstanceTypeConfig != null)
            {
                context.InstanceFleet_InstanceTypeConfig = new List<Amazon.ElasticMapReduce.Model.InstanceTypeConfig>(this.InstanceFleet_InstanceTypeConfig);
            }
            context.OnDemandSpecification_AllocationStrategy = this.OnDemandSpecification_AllocationStrategy;
            context.CapacityReservationOptions_CapacityReservationPreference = this.CapacityReservationOptions_CapacityReservationPreference;
            context.CapacityReservationOptions_CapacityReservationResourceGroupArn = this.CapacityReservationOptions_CapacityReservationResourceGroupArn;
            context.CapacityReservationOptions_UsageStrategy = this.CapacityReservationOptions_UsageStrategy;
            context.SpotSpecification_AllocationStrategy = this.SpotSpecification_AllocationStrategy;
            context.SpotSpecification_BlockDurationMinute = this.SpotSpecification_BlockDurationMinute;
            context.SpotSpecification_TimeoutAction = this.SpotSpecification_TimeoutAction;
            context.SpotSpecification_TimeoutDurationMinute = this.SpotSpecification_TimeoutDurationMinute;
            context.InstanceFleet_Name = this.InstanceFleet_Name;
            context.OnDemandResizeSpecification_TimeoutDurationMinute = this.OnDemandResizeSpecification_TimeoutDurationMinute;
            context.SpotResizeSpecification_TimeoutDurationMinute = this.SpotResizeSpecification_TimeoutDurationMinute;
            context.InstanceFleet_TargetOnDemandCapacity = this.InstanceFleet_TargetOnDemandCapacity;
            context.InstanceFleet_TargetSpotCapacity = this.InstanceFleet_TargetSpotCapacity;
            
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
            var request = new Amazon.ElasticMapReduce.Model.AddInstanceFleetRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            
             // populate InstanceFleet
            var requestInstanceFleetIsNull = true;
            request.InstanceFleet = new Amazon.ElasticMapReduce.Model.InstanceFleetConfig();
            Amazon.ElasticMapReduce.InstanceFleetType requestInstanceFleet_instanceFleet_InstanceFleetType = null;
            if (cmdletContext.InstanceFleet_InstanceFleetType != null)
            {
                requestInstanceFleet_instanceFleet_InstanceFleetType = cmdletContext.InstanceFleet_InstanceFleetType;
            }
            if (requestInstanceFleet_instanceFleet_InstanceFleetType != null)
            {
                request.InstanceFleet.InstanceFleetType = requestInstanceFleet_instanceFleet_InstanceFleetType;
                requestInstanceFleetIsNull = false;
            }
            List<Amazon.ElasticMapReduce.Model.InstanceTypeConfig> requestInstanceFleet_instanceFleet_InstanceTypeConfig = null;
            if (cmdletContext.InstanceFleet_InstanceTypeConfig != null)
            {
                requestInstanceFleet_instanceFleet_InstanceTypeConfig = cmdletContext.InstanceFleet_InstanceTypeConfig;
            }
            if (requestInstanceFleet_instanceFleet_InstanceTypeConfig != null)
            {
                request.InstanceFleet.InstanceTypeConfigs = requestInstanceFleet_instanceFleet_InstanceTypeConfig;
                requestInstanceFleetIsNull = false;
            }
            System.String requestInstanceFleet_instanceFleet_Name = null;
            if (cmdletContext.InstanceFleet_Name != null)
            {
                requestInstanceFleet_instanceFleet_Name = cmdletContext.InstanceFleet_Name;
            }
            if (requestInstanceFleet_instanceFleet_Name != null)
            {
                request.InstanceFleet.Name = requestInstanceFleet_instanceFleet_Name;
                requestInstanceFleetIsNull = false;
            }
            System.Int32? requestInstanceFleet_instanceFleet_TargetOnDemandCapacity = null;
            if (cmdletContext.InstanceFleet_TargetOnDemandCapacity != null)
            {
                requestInstanceFleet_instanceFleet_TargetOnDemandCapacity = cmdletContext.InstanceFleet_TargetOnDemandCapacity.Value;
            }
            if (requestInstanceFleet_instanceFleet_TargetOnDemandCapacity != null)
            {
                request.InstanceFleet.TargetOnDemandCapacity = requestInstanceFleet_instanceFleet_TargetOnDemandCapacity.Value;
                requestInstanceFleetIsNull = false;
            }
            System.Int32? requestInstanceFleet_instanceFleet_TargetSpotCapacity = null;
            if (cmdletContext.InstanceFleet_TargetSpotCapacity != null)
            {
                requestInstanceFleet_instanceFleet_TargetSpotCapacity = cmdletContext.InstanceFleet_TargetSpotCapacity.Value;
            }
            if (requestInstanceFleet_instanceFleet_TargetSpotCapacity != null)
            {
                request.InstanceFleet.TargetSpotCapacity = requestInstanceFleet_instanceFleet_TargetSpotCapacity.Value;
                requestInstanceFleetIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.InstanceFleetProvisioningSpecifications requestInstanceFleet_instanceFleet_LaunchSpecifications = null;
            
             // populate LaunchSpecifications
            var requestInstanceFleet_instanceFleet_LaunchSpecificationsIsNull = true;
            requestInstanceFleet_instanceFleet_LaunchSpecifications = new Amazon.ElasticMapReduce.Model.InstanceFleetProvisioningSpecifications();
            Amazon.ElasticMapReduce.Model.OnDemandProvisioningSpecification requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification = null;
            
             // populate OnDemandSpecification
            var requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecificationIsNull = true;
            requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification = new Amazon.ElasticMapReduce.Model.OnDemandProvisioningSpecification();
            Amazon.ElasticMapReduce.OnDemandProvisioningAllocationStrategy requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_onDemandSpecification_AllocationStrategy = null;
            if (cmdletContext.OnDemandSpecification_AllocationStrategy != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_onDemandSpecification_AllocationStrategy = cmdletContext.OnDemandSpecification_AllocationStrategy;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_onDemandSpecification_AllocationStrategy != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification.AllocationStrategy = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_onDemandSpecification_AllocationStrategy;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecificationIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.OnDemandCapacityReservationOptions requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions = null;
            
             // populate CapacityReservationOptions
            var requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptionsIsNull = true;
            requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions = new Amazon.ElasticMapReduce.Model.OnDemandCapacityReservationOptions();
            Amazon.ElasticMapReduce.OnDemandCapacityReservationPreference requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationPreference = null;
            if (cmdletContext.CapacityReservationOptions_CapacityReservationPreference != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationPreference = cmdletContext.CapacityReservationOptions_CapacityReservationPreference;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationPreference != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions.CapacityReservationPreference = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationPreference;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptionsIsNull = false;
            }
            System.String requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationResourceGroupArn = null;
            if (cmdletContext.CapacityReservationOptions_CapacityReservationResourceGroupArn != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationResourceGroupArn = cmdletContext.CapacityReservationOptions_CapacityReservationResourceGroupArn;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationResourceGroupArn != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions.CapacityReservationResourceGroupArn = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationResourceGroupArn;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptionsIsNull = false;
            }
            Amazon.ElasticMapReduce.OnDemandCapacityReservationUsageStrategy requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_UsageStrategy = null;
            if (cmdletContext.CapacityReservationOptions_UsageStrategy != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_UsageStrategy = cmdletContext.CapacityReservationOptions_UsageStrategy;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_UsageStrategy != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions.UsageStrategy = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions_capacityReservationOptions_UsageStrategy;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptionsIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions should be set to null
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptionsIsNull)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions = null;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification.CapacityReservationOptions = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification_instanceFleet_LaunchSpecifications_OnDemandSpecification_CapacityReservationOptions;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecificationIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification should be set to null
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecificationIsNull)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification = null;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications.OnDemandSpecification = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_OnDemandSpecification;
                requestInstanceFleet_instanceFleet_LaunchSpecificationsIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.SpotProvisioningSpecification requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification = null;
            
             // populate SpotSpecification
            var requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull = true;
            requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification = new Amazon.ElasticMapReduce.Model.SpotProvisioningSpecification();
            Amazon.ElasticMapReduce.SpotProvisioningAllocationStrategy requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_AllocationStrategy = null;
            if (cmdletContext.SpotSpecification_AllocationStrategy != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_AllocationStrategy = cmdletContext.SpotSpecification_AllocationStrategy;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_AllocationStrategy != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification.AllocationStrategy = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_AllocationStrategy;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull = false;
            }
            System.Int32? requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_BlockDurationMinute = null;
            if (cmdletContext.SpotSpecification_BlockDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_BlockDurationMinute = cmdletContext.SpotSpecification_BlockDurationMinute.Value;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_BlockDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification.BlockDurationMinutes = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_BlockDurationMinute.Value;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull = false;
            }
            Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutAction = null;
            if (cmdletContext.SpotSpecification_TimeoutAction != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutAction = cmdletContext.SpotSpecification_TimeoutAction;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutAction != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification.TimeoutAction = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutAction;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull = false;
            }
            System.Int32? requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutDurationMinute = null;
            if (cmdletContext.SpotSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutDurationMinute = cmdletContext.SpotSpecification_TimeoutDurationMinute.Value;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification.TimeoutDurationMinutes = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification_spotSpecification_TimeoutDurationMinute.Value;
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification should be set to null
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecificationIsNull)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification = null;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification != null)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications.SpotSpecification = requestInstanceFleet_instanceFleet_LaunchSpecifications_instanceFleet_LaunchSpecifications_SpotSpecification;
                requestInstanceFleet_instanceFleet_LaunchSpecificationsIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_LaunchSpecifications should be set to null
            if (requestInstanceFleet_instanceFleet_LaunchSpecificationsIsNull)
            {
                requestInstanceFleet_instanceFleet_LaunchSpecifications = null;
            }
            if (requestInstanceFleet_instanceFleet_LaunchSpecifications != null)
            {
                request.InstanceFleet.LaunchSpecifications = requestInstanceFleet_instanceFleet_LaunchSpecifications;
                requestInstanceFleetIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.InstanceFleetResizingSpecifications requestInstanceFleet_instanceFleet_ResizeSpecifications = null;
            
             // populate ResizeSpecifications
            var requestInstanceFleet_instanceFleet_ResizeSpecificationsIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications = new Amazon.ElasticMapReduce.Model.InstanceFleetResizingSpecifications();
            Amazon.ElasticMapReduce.Model.OnDemandResizingSpecification requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification = null;
            
             // populate OnDemandResizeSpecification
            var requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecificationIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification = new Amazon.ElasticMapReduce.Model.OnDemandResizingSpecification();
            System.Int32? requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_TimeoutDurationMinute = null;
            if (cmdletContext.OnDemandResizeSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_TimeoutDurationMinute = cmdletContext.OnDemandResizeSpecification_TimeoutDurationMinute.Value;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification.TimeoutDurationMinutes = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_TimeoutDurationMinute.Value;
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecificationIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification should be set to null
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecificationIsNull)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification = null;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications.OnDemandResizeSpecification = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification;
                requestInstanceFleet_instanceFleet_ResizeSpecificationsIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.SpotResizingSpecification requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification = null;
            
             // populate SpotResizeSpecification
            var requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecificationIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification = new Amazon.ElasticMapReduce.Model.SpotResizingSpecification();
            System.Int32? requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_TimeoutDurationMinute = null;
            if (cmdletContext.SpotResizeSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_TimeoutDurationMinute = cmdletContext.SpotResizeSpecification_TimeoutDurationMinute.Value;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_TimeoutDurationMinute != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification.TimeoutDurationMinutes = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_TimeoutDurationMinute.Value;
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecificationIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification should be set to null
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecificationIsNull)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification = null;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications.SpotResizeSpecification = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification;
                requestInstanceFleet_instanceFleet_ResizeSpecificationsIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_ResizeSpecifications should be set to null
            if (requestInstanceFleet_instanceFleet_ResizeSpecificationsIsNull)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications = null;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications != null)
            {
                request.InstanceFleet.ResizeSpecifications = requestInstanceFleet_instanceFleet_ResizeSpecifications;
                requestInstanceFleetIsNull = false;
            }
             // determine if request.InstanceFleet should be set to null
            if (requestInstanceFleetIsNull)
            {
                request.InstanceFleet = null;
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
        
        private Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.AddInstanceFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "AddInstanceFleet");
            try
            {
                #if DESKTOP
                return client.AddInstanceFleet(request);
                #elif CORECLR
                return client.AddInstanceFleetAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterId { get; set; }
            public Amazon.ElasticMapReduce.InstanceFleetType InstanceFleet_InstanceFleetType { get; set; }
            public List<Amazon.ElasticMapReduce.Model.InstanceTypeConfig> InstanceFleet_InstanceTypeConfig { get; set; }
            public Amazon.ElasticMapReduce.OnDemandProvisioningAllocationStrategy OnDemandSpecification_AllocationStrategy { get; set; }
            public Amazon.ElasticMapReduce.OnDemandCapacityReservationPreference CapacityReservationOptions_CapacityReservationPreference { get; set; }
            public System.String CapacityReservationOptions_CapacityReservationResourceGroupArn { get; set; }
            public Amazon.ElasticMapReduce.OnDemandCapacityReservationUsageStrategy CapacityReservationOptions_UsageStrategy { get; set; }
            public Amazon.ElasticMapReduce.SpotProvisioningAllocationStrategy SpotSpecification_AllocationStrategy { get; set; }
            public System.Int32? SpotSpecification_BlockDurationMinute { get; set; }
            public Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction SpotSpecification_TimeoutAction { get; set; }
            public System.Int32? SpotSpecification_TimeoutDurationMinute { get; set; }
            public System.String InstanceFleet_Name { get; set; }
            public System.Int32? OnDemandResizeSpecification_TimeoutDurationMinute { get; set; }
            public System.Int32? SpotResizeSpecification_TimeoutDurationMinute { get; set; }
            public System.Int32? InstanceFleet_TargetOnDemandCapacity { get; set; }
            public System.Int32? InstanceFleet_TargetSpotCapacity { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.AddInstanceFleetResponse, AddEMRInstanceFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
