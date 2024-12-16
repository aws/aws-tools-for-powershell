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
    /// Modifies the target On-Demand and target Spot capacities for the instance fleet with
    /// the specified InstanceFleetID within the cluster specified using ClusterID. The call
    /// either succeeds or fails atomically.
    /// 
    ///  <note><para>
    /// The instance fleet configuration is available only in Amazon EMR releases 4.8.0 and
    /// later, excluding 5.0.x versions.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "EMRInstanceFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce ModifyInstanceFleet API operation.", Operation = new[] {"ModifyInstanceFleet"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditEMRInstanceFleetCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OnDemandResizeSpecification_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the allocation strategy to use to launch On-Demand instances during a resize.
        /// The default is <c>lowest-price</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_ResizeSpecifications_OnDemandResizeSpecification_AllocationStrategy")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.OnDemandProvisioningAllocationStrategy")]
        public Amazon.ElasticMapReduce.OnDemandProvisioningAllocationStrategy OnDemandResizeSpecification_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter SpotResizeSpecification_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the allocation strategy to use to launch Spot instances during a resize.
        /// If you run Amazon EMR releases 6.9.0 or higher, the default is <c>price-capacity-optimized</c>.
        /// If you run Amazon EMR releases 6.8.0 or lower, the default is <c>capacity-optimized</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_ResizeSpecifications_SpotResizeSpecification_AllocationStrategy")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.SpotProvisioningAllocationStrategy")]
        public Amazon.ElasticMapReduce.SpotProvisioningAllocationStrategy SpotResizeSpecification_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter CapacityReservationOptions_CapacityReservationPreference
        /// <summary>
        /// <para>
        /// <para>Indicates the instance's Capacity Reservation preferences. Possible preferences include:</para><ul><li><para><c>open</c> - The instance can run in any open Capacity Reservation that has matching
        /// attributes (instance type, platform, Availability Zone).</para></li><li><para><c>none</c> - The instance avoids running in a Capacity Reservation even if one is
        /// available. The instance runs as an On-Demand Instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_CapacityReservationPreference")]
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
        [Alias("InstanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_CapacityReservationResourceGroupArn")]
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
        
        #region Parameter InstanceFleet_Context
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceFleet_Context { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_InstanceFleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the instance fleet.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InstanceFleet_InstanceFleetId { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_InstanceTypeConfig
        /// <summary>
        /// <para>
        /// <para>An array of InstanceTypeConfig objects that specify how Amazon EMR provisions Amazon
        /// EC2 instances when it fulfills On-Demand and Spot capacities. For more information,
        /// see <a href="https://docs.aws.amazon.com/emr/latest/APIReference/API_InstanceTypeConfig.html">InstanceTypeConfig</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_InstanceTypeConfigs")]
        public Amazon.ElasticMapReduce.Model.InstanceTypeConfig[] InstanceFleet_InstanceTypeConfig { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_TargetOnDemandCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity of On-Demand units for the instance fleet. For more information
        /// see <a>InstanceFleetConfig$TargetOnDemandCapacity</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceFleet_TargetOnDemandCapacity { get; set; }
        #endregion
        
        #region Parameter InstanceFleet_TargetSpotCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity of Spot units for the instance fleet. For more information, see
        /// <a>InstanceFleetConfig$TargetSpotCapacity</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceFleet_TargetSpotCapacity { get; set; }
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
        /// <para>Indicates whether to use unused Capacity Reservations for fulfilling On-Demand capacity.</para><para>If you specify <c>use-capacity-reservations-first</c>, the fleet uses unused Capacity
        /// Reservations to fulfill On-Demand capacity up to the target On-Demand capacity. If
        /// multiple instance pools have unused Capacity Reservations, the On-Demand allocation
        /// strategy (<c>lowest-price</c>) is applied. If the number of unused Capacity Reservations
        /// is less than the On-Demand target capacity, the remaining On-Demand target capacity
        /// is launched according to the On-Demand allocation strategy (<c>lowest-price</c>).</para><para>If you do not specify a value, the fleet fulfills the On-Demand capacity according
        /// to the chosen On-Demand allocation strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_UsageStrategy")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.OnDemandCapacityReservationUsageStrategy")]
        public Amazon.ElasticMapReduce.OnDemandCapacityReservationUsageStrategy CapacityReservationOptions_UsageStrategy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EMRInstanceFleet (ModifyInstanceFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse, EditEMRInstanceFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceFleet_Context = this.InstanceFleet_Context;
            context.InstanceFleet_InstanceFleetId = this.InstanceFleet_InstanceFleetId;
            #if MODULAR
            if (this.InstanceFleet_InstanceFleetId == null && ParameterWasBound(nameof(this.InstanceFleet_InstanceFleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceFleet_InstanceFleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InstanceFleet_InstanceTypeConfig != null)
            {
                context.InstanceFleet_InstanceTypeConfig = new List<Amazon.ElasticMapReduce.Model.InstanceTypeConfig>(this.InstanceFleet_InstanceTypeConfig);
            }
            context.OnDemandResizeSpecification_AllocationStrategy = this.OnDemandResizeSpecification_AllocationStrategy;
            context.CapacityReservationOptions_CapacityReservationPreference = this.CapacityReservationOptions_CapacityReservationPreference;
            context.CapacityReservationOptions_CapacityReservationResourceGroupArn = this.CapacityReservationOptions_CapacityReservationResourceGroupArn;
            context.CapacityReservationOptions_UsageStrategy = this.CapacityReservationOptions_UsageStrategy;
            context.OnDemandResizeSpecification_TimeoutDurationMinute = this.OnDemandResizeSpecification_TimeoutDurationMinute;
            context.SpotResizeSpecification_AllocationStrategy = this.SpotResizeSpecification_AllocationStrategy;
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
            var request = new Amazon.ElasticMapReduce.Model.ModifyInstanceFleetRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            
             // populate InstanceFleet
            var requestInstanceFleetIsNull = true;
            request.InstanceFleet = new Amazon.ElasticMapReduce.Model.InstanceFleetModifyConfig();
            System.String requestInstanceFleet_instanceFleet_Context = null;
            if (cmdletContext.InstanceFleet_Context != null)
            {
                requestInstanceFleet_instanceFleet_Context = cmdletContext.InstanceFleet_Context;
            }
            if (requestInstanceFleet_instanceFleet_Context != null)
            {
                request.InstanceFleet.Context = requestInstanceFleet_instanceFleet_Context;
                requestInstanceFleetIsNull = false;
            }
            System.String requestInstanceFleet_instanceFleet_InstanceFleetId = null;
            if (cmdletContext.InstanceFleet_InstanceFleetId != null)
            {
                requestInstanceFleet_instanceFleet_InstanceFleetId = cmdletContext.InstanceFleet_InstanceFleetId;
            }
            if (requestInstanceFleet_instanceFleet_InstanceFleetId != null)
            {
                request.InstanceFleet.InstanceFleetId = requestInstanceFleet_instanceFleet_InstanceFleetId;
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
            Amazon.ElasticMapReduce.Model.InstanceFleetResizingSpecifications requestInstanceFleet_instanceFleet_ResizeSpecifications = null;
            
             // populate ResizeSpecifications
            var requestInstanceFleet_instanceFleet_ResizeSpecificationsIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications = new Amazon.ElasticMapReduce.Model.InstanceFleetResizingSpecifications();
            Amazon.ElasticMapReduce.Model.SpotResizingSpecification requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification = null;
            
             // populate SpotResizeSpecification
            var requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecificationIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification = new Amazon.ElasticMapReduce.Model.SpotResizingSpecification();
            Amazon.ElasticMapReduce.SpotProvisioningAllocationStrategy requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_AllocationStrategy = null;
            if (cmdletContext.SpotResizeSpecification_AllocationStrategy != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_AllocationStrategy = cmdletContext.SpotResizeSpecification_AllocationStrategy;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_AllocationStrategy != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification.AllocationStrategy = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecification_spotResizeSpecification_AllocationStrategy;
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_SpotResizeSpecificationIsNull = false;
            }
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
            Amazon.ElasticMapReduce.Model.OnDemandResizingSpecification requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification = null;
            
             // populate OnDemandResizeSpecification
            var requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecificationIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification = new Amazon.ElasticMapReduce.Model.OnDemandResizingSpecification();
            Amazon.ElasticMapReduce.OnDemandProvisioningAllocationStrategy requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_AllocationStrategy = null;
            if (cmdletContext.OnDemandResizeSpecification_AllocationStrategy != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_AllocationStrategy = cmdletContext.OnDemandResizeSpecification_AllocationStrategy;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_AllocationStrategy != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification.AllocationStrategy = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_onDemandResizeSpecification_AllocationStrategy;
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecificationIsNull = false;
            }
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
            Amazon.ElasticMapReduce.Model.OnDemandCapacityReservationOptions requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions = null;
            
             // populate CapacityReservationOptions
            var requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptionsIsNull = true;
            requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions = new Amazon.ElasticMapReduce.Model.OnDemandCapacityReservationOptions();
            Amazon.ElasticMapReduce.OnDemandCapacityReservationPreference requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationPreference = null;
            if (cmdletContext.CapacityReservationOptions_CapacityReservationPreference != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationPreference = cmdletContext.CapacityReservationOptions_CapacityReservationPreference;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationPreference != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions.CapacityReservationPreference = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationPreference;
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptionsIsNull = false;
            }
            System.String requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationResourceGroupArn = null;
            if (cmdletContext.CapacityReservationOptions_CapacityReservationResourceGroupArn != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationResourceGroupArn = cmdletContext.CapacityReservationOptions_CapacityReservationResourceGroupArn;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationResourceGroupArn != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions.CapacityReservationResourceGroupArn = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_CapacityReservationResourceGroupArn;
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptionsIsNull = false;
            }
            Amazon.ElasticMapReduce.OnDemandCapacityReservationUsageStrategy requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_UsageStrategy = null;
            if (cmdletContext.CapacityReservationOptions_UsageStrategy != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_UsageStrategy = cmdletContext.CapacityReservationOptions_UsageStrategy;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_UsageStrategy != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions.UsageStrategy = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_capacityReservationOptions_UsageStrategy;
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptionsIsNull = false;
            }
             // determine if requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions should be set to null
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptionsIsNull)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions = null;
            }
            if (requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions != null)
            {
                requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification.CapacityReservationOptions = requestInstanceFleet_instanceFleet_ResizeSpecifications_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_instanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions;
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
        
        private Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.ModifyInstanceFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "ModifyInstanceFleet");
            try
            {
                #if DESKTOP
                return client.ModifyInstanceFleet(request);
                #elif CORECLR
                return client.ModifyInstanceFleetAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceFleet_Context { get; set; }
            public System.String InstanceFleet_InstanceFleetId { get; set; }
            public List<Amazon.ElasticMapReduce.Model.InstanceTypeConfig> InstanceFleet_InstanceTypeConfig { get; set; }
            public Amazon.ElasticMapReduce.OnDemandProvisioningAllocationStrategy OnDemandResizeSpecification_AllocationStrategy { get; set; }
            public Amazon.ElasticMapReduce.OnDemandCapacityReservationPreference CapacityReservationOptions_CapacityReservationPreference { get; set; }
            public System.String CapacityReservationOptions_CapacityReservationResourceGroupArn { get; set; }
            public Amazon.ElasticMapReduce.OnDemandCapacityReservationUsageStrategy CapacityReservationOptions_UsageStrategy { get; set; }
            public System.Int32? OnDemandResizeSpecification_TimeoutDurationMinute { get; set; }
            public Amazon.ElasticMapReduce.SpotProvisioningAllocationStrategy SpotResizeSpecification_AllocationStrategy { get; set; }
            public System.Int32? SpotResizeSpecification_TimeoutDurationMinute { get; set; }
            public System.Int32? InstanceFleet_TargetOnDemandCapacity { get; set; }
            public System.Int32? InstanceFleet_TargetSpotCapacity { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.ModifyInstanceFleetResponse, EditEMRInstanceFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
