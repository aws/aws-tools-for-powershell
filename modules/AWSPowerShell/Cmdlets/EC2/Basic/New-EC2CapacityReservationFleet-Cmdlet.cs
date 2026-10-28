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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a Capacity Reservation Fleet. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/work-with-cr-fleets.html#create-crfleet">Create
    /// a Capacity Reservation Fleet</a> in the <i>Amazon EC2 User Guide</i>.
    /// </summary>
    [Cmdlet("New", "EC2CapacityReservationFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateCapacityReservationFleetResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateCapacityReservationFleet API operation.", Operation = new[] {"CreateCapacityReservationFleet"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateCapacityReservationFleetResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateCapacityReservationFleetResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateCapacityReservationFleetResponse object containing multiple properties."
    )]
    public partial class NewEC2CapacityReservationFleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceRequirements_AcceleratorManufacturer
        /// <summary>
        /// <para>
        /// <para>Indicates whether instance types must have accelerators by specific manufacturers.</para><ul><li><para>For instance types with Amazon Web Services devices, specify <c>amazon-web-services</c>.</para></li><li><para>For instance types with AMD devices, specify <c>amd</c>.</para></li><li><para>For instance types with Habana devices, specify <c>habana</c>.</para></li><li><para>For instance types with NVIDIA devices, specify <c>nvidia</c>.</para></li><li><para>For instance types with Xilinx devices, specify <c>xilinx</c>.</para></li></ul><para>Default: Any manufacturer</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AcceleratorManufacturers")]
        public System.String[] InstanceRequirements_AcceleratorManufacturer { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorName
        /// <summary>
        /// <para>
        /// <para>The accelerators that must be on the instance type.</para><ul><li><para>For instance types with NVIDIA A10G GPUs, specify <c>a10g</c>.</para></li><li><para>For instance types with NVIDIA A100 GPUs, specify <c>a100</c>.</para></li><li><para>For instance types with NVIDIA H100 GPUs, specify <c>h100</c>.</para></li><li><para>For instance types with Amazon Web Services Inferentia chips, specify <c>inferentia</c>.</para></li><li><para>For instance types with Amazon Web Services Inferentia2 chips, specify <c>inferentia2</c>.</para></li><li><para>For instance types with Habana Gaudi HL-205 GPUs, specify <c>gaudi-hl-205</c>.</para></li><li><para>For instance types with NVIDIA GRID K520 GPUs, specify <c>k520</c>.</para></li><li><para>For instance types with NVIDIA K80 GPUs, specify <c>k80</c>.</para></li><li><para>For instance types with NVIDIA L4 GPUs, specify <c>l4</c>.</para></li><li><para>For instance types with NVIDIA L40S GPUs, specify <c>l40s</c>.</para></li><li><para>For instance types with NVIDIA M60 GPUs, specify <c>m60</c>.</para></li><li><para>For instance types with AMD Radeon Pro V520 GPUs, specify <c>radeon-pro-v520</c>.</para></li><li><para>For instance types with Amazon Web Services Trainium chips, specify <c>trainium</c>.</para></li><li><para>For instance types with Amazon Web Services Trainium2 chips, specify <c>trainium2</c>.</para></li><li><para>For instance types with NVIDIA T4 GPUs, specify <c>t4</c>.</para></li><li><para>For instance types with NVIDIA T4G GPUs, specify <c>t4g</c>.</para></li><li><para>For instance types with Xilinx U30 cards, specify <c>u30</c>.</para></li><li><para>For instance types with Xilinx VU9P FPGAs, specify <c>vu9p</c>.</para></li><li><para>For instance types with NVIDIA V100 GPUs, specify <c>v100</c>.</para></li></ul><para>Default: Any accelerator</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AcceleratorNames")]
        public System.String[] InstanceRequirements_AcceleratorName { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorType
        /// <summary>
        /// <para>
        /// <para>The accelerator types that must be on the instance type.</para><ul><li><para>For instance types with FPGA accelerators, specify <c>fpga</c>.</para></li><li><para>For instance types with GPU accelerators, specify <c>gpu</c>.</para></li><li><para>For instance types with Inference accelerators, specify <c>inference</c>.</para></li><li><para>For instance types with Media accelerators, specify <c>media</c>.</para></li></ul><para>Default: Any accelerator type</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AcceleratorTypes")]
        public System.String[] InstanceRequirements_AcceleratorType { get; set; }
        #endregion
        
        #region Parameter AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>The strategy used by the Capacity Reservation Fleet to determine which of the specified
        /// instance types to use. Currently, only the <c>prioritized</c> allocation strategy
        /// is supported. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/crfleet-concepts.html#allocation-strategy">
        /// Allocation strategy</a> in the <i>Amazon EC2 User Guide</i>.</para><para>Valid values: <c>prioritized</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AllowedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types to apply your specified attributes against. All other instance
        /// types are ignored, even if they match your specified attributes.</para><para>You can use strings with one or more wild cards, represented by an asterisk (<c>*</c>),
        /// to allow an instance type, size, or generation. The following are examples: <c>m5.8xlarge</c>,
        /// <c>c5*.*</c>, <c>m5a.*</c>, <c>r*</c>, <c>*3*</c>.</para><para>For example, if you specify <c>c5*</c>,Amazon EC2 will allow the entire C5 instance
        /// family, which includes all C5a and C5n instance types. If you specify <c>m5a.*</c>,
        /// Amazon EC2 will allow all the M5a instance types, but not the M5n instance types.</para><note><para>If you specify <c>AllowedInstanceTypes</c>, you can't specify <c>ExcludedInstanceTypes</c>.</para></note><para>Default: All instance types</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AllowedInstanceTypes")]
        public System.String[] InstanceRequirements_AllowedInstanceType { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Reserved for internal use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>Reserved for internal use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_BareMetal
        /// <summary>
        /// <para>
        /// <para>Indicates whether bare metal instance types must be included, excluded, or required.</para><ul><li><para>To include bare metal instance types, specify <c>included</c>.</para></li><li><para>To require only bare metal instance types, specify <c>required</c>.</para></li><li><para>To exclude bare metal instance types, specify <c>excluded</c>.</para></li></ul><para>Default: <c>excluded</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.BareMetal")]
        public Amazon.EC2.BareMetal InstanceRequirements_BareMetal { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_BurstablePerformance
        /// <summary>
        /// <para>
        /// <para>Indicates whether burstable performance T instance types are included, excluded, or
        /// required. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/burstable-performance-instances.html">Burstable
        /// performance instances</a>.</para><ul><li><para>To include burstable performance instance types, specify <c>included</c>.</para></li><li><para>To require only burstable performance instance types, specify <c>required</c>.</para></li><li><para>To exclude burstable performance instance types, specify <c>excluded</c>.</para></li></ul><para>Default: <c>excluded</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.BurstablePerformance")]
        public Amazon.EC2.BurstablePerformance InstanceRequirements_BurstablePerformance { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_CpuManufacturer
        /// <summary>
        /// <para>
        /// <para>The CPU manufacturers to include.</para><ul><li><para>For instance types with Intel CPUs, specify <c>intel</c>.</para></li><li><para>For instance types with AMD CPUs, specify <c>amd</c>.</para></li><li><para>For instance types with Amazon Web Services CPUs, specify <c>amazon-web-services</c>.</para></li><li><para>For instance types with Apple CPUs, specify <c>apple</c>.</para></li></ul><note><para>Don't confuse the CPU manufacturer with the CPU architecture. Instances will be launched
        /// with a compatible CPU architecture based on the Amazon Machine Image (AMI) that you
        /// specify in your launch template.</para></note><para>Default: Any manufacturer</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_CpuManufacturers")]
        public System.String[] InstanceRequirements_CpuManufacturer { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The date and time at which the Capacity Reservation Fleet expires. When the Capacity
        /// Reservation Fleet expires, its state changes to <c>expired</c> and all of the Capacity
        /// Reservations in the Fleet expire.</para><para>The Capacity Reservation Fleet expires within an hour after the specified time. For
        /// example, if you specify <c>5/31/2019</c>, <c>13:30:55</c>, the Capacity Reservation
        /// Fleet is guaranteed to expire between <c>13:30:55</c> and <c>14:30:55</c> on <c>5/31/2019</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_ExcludedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types to exclude.</para><para>You can use strings with one or more wild cards, represented by an asterisk (<c>*</c>),
        /// to exclude an instance family, type, size, or generation. The following are examples:
        /// <c>m5.8xlarge</c>, <c>c5*.*</c>, <c>m5a.*</c>, <c>r*</c>, <c>*3*</c>.</para><para>For example, if you specify <c>c5*</c>,Amazon EC2 will exclude the entire C5 instance
        /// family, which includes all C5a and C5n instance types. If you specify <c>m5a.*</c>,
        /// Amazon EC2 will exclude all the M5a instance types, but not the M5n instance types.</para><note><para>If you specify <c>ExcludedInstanceTypes</c>, you can't specify <c>AllowedInstanceTypes</c>.</para></note><para>Default: No excluded instance types</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_ExcludedInstanceTypes")]
        public System.String[] InstanceRequirements_ExcludedInstanceType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_InstanceGeneration
        /// <summary>
        /// <para>
        /// <para>Indicates whether current or previous generation instance types are included. The
        /// current generation instance types are recommended for use. Current generation instance
        /// types are typically the latest two to three generations in each instance family. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// types</a> in the <i>Amazon EC2 User Guide</i>.</para><para>For current generation instance types, specify <c>current</c>.</para><para>For previous generation instance types, specify <c>previous</c>.</para><para>Default: Current and previous generation instance types</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_InstanceGenerations")]
        public System.String[] InstanceRequirements_InstanceGeneration { get; set; }
        #endregion
        
        #region Parameter InstanceMatchCriterion
        /// <summary>
        /// <para>
        /// <para>Indicates the type of instance launches that the Capacity Reservation Fleet accepts.
        /// All Capacity Reservations in the Fleet inherit this instance matching criteria.</para><para>Currently, Capacity Reservation Fleets support <c>open</c> instance matching criteria
        /// only. This means that instances that have matching attributes (instance type, platform,
        /// and Availability Zone) run in the Capacity Reservations automatically. Instances do
        /// not need to explicitly target a Capacity Reservation Fleet to use its reserved capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceMatchCriteria")]
        [AWSConstantClassSource("Amazon.EC2.FleetInstanceMatchCriteria")]
        public Amazon.EC2.FleetInstanceMatchCriteria InstanceMatchCriterion { get; set; }
        #endregion
        
        #region Parameter InstanceTypeSpecification
        /// <summary>
        /// <para>
        /// <para>Information about the instance types for which to reserve the capacity.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypeSpecifications")]
        public Amazon.EC2.Model.ReservationFleetInstanceSpecification[] InstanceTypeSpecification { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_LocalStorage
        /// <summary>
        /// <para>
        /// <para>Indicates whether instance types with instance store volumes are included, excluded,
        /// or required. For more information, <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/InstanceStorage.html">Amazon
        /// EC2 instance store</a> in the <i>Amazon EC2 User Guide</i>.</para><ul><li><para>To include instance types with instance store volumes, specify <c>included</c>.</para></li><li><para>To require only instance types with instance store volumes, specify <c>required</c>.</para></li><li><para>To exclude instance types with instance store volumes, specify <c>excluded</c>.</para></li></ul><para>Default: <c>included</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.LocalStorage")]
        public Amazon.EC2.LocalStorage InstanceRequirements_LocalStorage { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_LocalStorageType
        /// <summary>
        /// <para>
        /// <para>The type of local storage that is required.</para><ul><li><para>For instance types with hard disk drive (HDD) storage, specify <c>hdd</c>.</para></li><li><para>For instance types with solid state drive (SSD) storage, specify <c>ssd</c>.</para></li></ul><para>Default: <c>hdd</c> and <c>ssd</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_LocalStorageTypes")]
        public System.String[] InstanceRequirements_LocalStorageType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of accelerators. To specify no maximum limit, omit this parameter.
        /// To exclude accelerator-enabled instance types, set <c>Max</c> to <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_AcceleratorCount_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorTotalMemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of accelerator memory, in MiB. To specify no maximum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_AcceleratorTotalMemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_BaselineEbsBandwidthMbps_Max
        /// <summary>
        /// <para>
        /// <para>The maximum baseline bandwidth, in Mbps. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_BaselineEbsBandwidthMbps_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_MemoryGiBPerVCpu_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory per vCPU, in GiB. To specify no maximum limit, omit this
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirements_MemoryGiBPerVCpu_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_MemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory, in MiB. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_MemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_NetworkBandwidthGbps_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of network bandwidth, in Gbps. To specify no maximum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirements_NetworkBandwidthGbps_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_NetworkInterfaceCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of network interfaces. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_NetworkInterfaceCount_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_TotalLocalStorageGB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of total local storage, in GB. To specify no maximum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirements_TotalLocalStorageGB_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_VCpuCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_VCpuCount_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice
        /// <summary>
        /// <para>
        /// <para>[Price protection] The price protection threshold for Spot Instances, as a percentage
        /// of an identified On-Demand price. The identified On-Demand price is the price of the
        /// lowest priced current generation C, M, or R instance type with your specified attributes.
        /// If no current generation C, M, or R instance type matches your attributes, then the
        /// identified price is from the lowest priced current generation instance types, and
        /// failing that, from the lowest priced previous generation instance types that match
        /// your attributes. When Amazon EC2 selects instance types with your attributes, it will
        /// exclude instance types whose price exceeds your specified threshold.</para><para>The parameter accepts an integer, which Amazon EC2 interprets as a percentage.</para><para>If you set <c>TargetCapacityUnitType</c> to <c>vcpu</c> or <c>memory-mib</c>, the
        /// price protection threshold is based on the per vCPU or per memory price instead of
        /// the per instance price.</para><note><para>Only one of <c>SpotMaxPricePercentageOverLowestPrice</c> or <c>MaxSpotPriceAsPercentageOfOptimalOnDemandPrice</c>
        /// can be specified. If you don't specify either, Amazon EC2 will automatically apply
        /// optimal price protection to consistently select from a wide range of instance types.
        /// To indicate no price protection threshold for Spot Instances, meaning you want to
        /// consider all instance types that match your attributes, include one of these parameters
        /// and specify a high value, such as <c>999999</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of accelerators. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_AcceleratorCount_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorTotalMemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of accelerator memory, in MiB. To specify no minimum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_AcceleratorTotalMemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_BaselineEbsBandwidthMbps_Min
        /// <summary>
        /// <para>
        /// <para>The minimum baseline bandwidth, in Mbps. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_BaselineEbsBandwidthMbps_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_MemoryGiBPerVCpu_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory per vCPU, in GiB. To specify no minimum limit, omit this
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirements_MemoryGiBPerVCpu_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_MemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory, in MiB. To specify no minimum limit, specify <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_MemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_NetworkBandwidthGbps_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of network bandwidth, in Gbps. To specify no minimum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirements_NetworkBandwidthGbps_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_NetworkInterfaceCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of network interfaces. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_NetworkInterfaceCount_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_TotalLocalStorageGB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of total local storage, in GB. To specify no minimum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirements_TotalLocalStorageGB_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_VCpuCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of vCPUs. To specify no minimum limit, specify <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_VCpuCount_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice
        /// <summary>
        /// <para>
        /// <para>[Price protection] The price protection threshold for On-Demand Instances, as a percentage
        /// higher than an identified On-Demand price. The identified On-Demand price is the price
        /// of the lowest priced current generation C, M, or R instance type with your specified
        /// attributes. When Amazon EC2 selects instance types with your attributes, it will exclude
        /// instance types whose price exceeds your specified threshold.</para><para>The parameter accepts an integer, which Amazon EC2 interprets as a percentage.</para><para>To indicate no price protection threshold, specify a high value, such as <c>999999</c>.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetSpotPlacementScores.html">GetSpotPlacementScores</a>
        /// and <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetInstanceTypesFromInstanceRequirements.html">GetInstanceTypesFromInstanceRequirements</a>.</para><note><para>If you set <c>TargetCapacityUnitType</c> to <c>vcpu</c> or <c>memory-mib</c>, the
        /// price protection threshold is applied based on the per-vCPU or per-memory price instead
        /// of the per-instance price.</para></note><para>Default: <c>20</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference
        /// <summary>
        /// <para>
        /// <para>Specify an instance family to use as the baseline reference for CPU performance. All
        /// instance types that match your specified attributes will be compared against the CPU
        /// performance of the referenced instance family, regardless of CPU manufacturer or architecture
        /// differences.</para><note><para>Currently, only one instance family can be specified in the list.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_BaselinePerformanceFactors_Cpu_References")]
        public Amazon.EC2.Model.PerformanceFactorReferenceRequest[] InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_RequireEncryptionInTransit
        /// <summary>
        /// <para>
        /// <para>Specifies whether instance types must support encrypting in-transit traffic between
        /// instances. For more information, including the supported instance types, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/data-protection.html#encryption-transit">Encryption
        /// in transit</a> in the <i>Amazon EC2 User Guide</i>.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstanceRequirements_RequireEncryptionInTransit { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_RequireHibernateSupport
        /// <summary>
        /// <para>
        /// <para>Indicates whether instance types must support hibernation for On-Demand Instances.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetSpotPlacementScores.html">GetSpotPlacementScores</a>.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstanceRequirements_RequireHibernateSupport { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_SpotMaxPricePercentageOverLowestPrice
        /// <summary>
        /// <para>
        /// <para>[Price protection] The price protection threshold for Spot Instances, as a percentage
        /// higher than an identified Spot price. The identified Spot price is the Spot price
        /// of the lowest priced current generation C, M, or R instance type with your specified
        /// attributes. If no current generation C, M, or R instance type matches your attributes,
        /// then the identified Spot price is from the lowest priced current generation instance
        /// types, and failing that, from the lowest priced previous generation instance types
        /// that match your attributes. When Amazon EC2 selects instance types with your attributes,
        /// it will exclude instance types whose Spot price exceeds your specified threshold.</para><para>The parameter accepts an integer, which Amazon EC2 interprets as a percentage.</para><para>If you set <c>TargetCapacityUnitType</c> to <c>vcpu</c> or <c>memory-mib</c>, the
        /// price protection threshold is applied based on the per-vCPU or per-memory price instead
        /// of the per-instance price.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetSpotPlacementScores.html">GetSpotPlacementScores</a>
        /// and <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetInstanceTypesFromInstanceRequirements.html">GetInstanceTypesFromInstanceRequirements</a>.</para><note><para>Only one of <c>SpotMaxPricePercentageOverLowestPrice</c> or <c>MaxSpotPriceAsPercentageOfOptimalOnDemandPrice</c>
        /// can be specified. If you don't specify either, Amazon EC2 will automatically apply
        /// optimal price protection to consistently select from a wide range of instance types.
        /// To indicate no price protection threshold for Spot Instances, meaning you want to
        /// consider all instance types that match your attributes, include one of these parameters
        /// and specify a high value, such as <c>999999</c>.</para></note><para>Default: <c>100</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirements_SpotMaxPricePercentageOverLowestPrice { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the Capacity Reservation Fleet. The tags are automatically assigned
        /// to the Capacity Reservations in the Fleet.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Tenancy
        /// <summary>
        /// <para>
        /// <para>Indicates the tenancy of the Capacity Reservation Fleet. All Capacity Reservations
        /// in the Fleet inherit this tenancy. The Capacity Reservation Fleet can have one of
        /// the following tenancy settings:</para><ul><li><para><c>default</c> - The Capacity Reservation Fleet is created on hardware that is shared
        /// with other Amazon Web Services accounts.</para></li><li><para><c>dedicated</c> - The Capacity Reservations are created on single-tenant hardware
        /// that is dedicated to a single Amazon Web Services account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.FleetCapacityReservationTenancy")]
        public Amazon.EC2.FleetCapacityReservationTenancy Tenancy { get; set; }
        #endregion
        
        #region Parameter TotalTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The total number of capacity units to be reserved by the Capacity Reservation Fleet.
        /// This value, together with the instance type weights that you assign to each instance
        /// type used by the Fleet determine the number of instances for which the Fleet reserves
        /// capacity. Both values are based on units that make sense for your workload. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/crfleet-concepts.html#target-capacity">Total
        /// target capacity</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TotalTargetCapacity { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensure
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateCapacityReservationFleetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateCapacityReservationFleetResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TotalTargetCapacity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2CapacityReservationFleet (CreateCapacityReservationFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateCapacityReservationFleetResponse, NewEC2CapacityReservationFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllocationStrategy = this.AllocationStrategy;
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.ClientToken = this.ClientToken;
            context.DryRun = this.DryRun;
            context.EndDate = this.EndDate;
            context.InstanceMatchCriterion = this.InstanceMatchCriterion;
            context.InstanceRequirements_AcceleratorCount_Max = this.InstanceRequirements_AcceleratorCount_Max;
            context.InstanceRequirements_AcceleratorCount_Min = this.InstanceRequirements_AcceleratorCount_Min;
            if (this.InstanceRequirements_AcceleratorManufacturer != null)
            {
                context.InstanceRequirements_AcceleratorManufacturer = new List<System.String>(this.InstanceRequirements_AcceleratorManufacturer);
            }
            if (this.InstanceRequirements_AcceleratorName != null)
            {
                context.InstanceRequirements_AcceleratorName = new List<System.String>(this.InstanceRequirements_AcceleratorName);
            }
            context.InstanceRequirements_AcceleratorTotalMemoryMiB_Max = this.InstanceRequirements_AcceleratorTotalMemoryMiB_Max;
            context.InstanceRequirements_AcceleratorTotalMemoryMiB_Min = this.InstanceRequirements_AcceleratorTotalMemoryMiB_Min;
            if (this.InstanceRequirements_AcceleratorType != null)
            {
                context.InstanceRequirements_AcceleratorType = new List<System.String>(this.InstanceRequirements_AcceleratorType);
            }
            if (this.InstanceRequirements_AllowedInstanceType != null)
            {
                context.InstanceRequirements_AllowedInstanceType = new List<System.String>(this.InstanceRequirements_AllowedInstanceType);
            }
            context.InstanceRequirements_BareMetal = this.InstanceRequirements_BareMetal;
            context.InstanceRequirements_BaselineEbsBandwidthMbps_Max = this.InstanceRequirements_BaselineEbsBandwidthMbps_Max;
            context.InstanceRequirements_BaselineEbsBandwidthMbps_Min = this.InstanceRequirements_BaselineEbsBandwidthMbps_Min;
            if (this.InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference != null)
            {
                context.InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference = new List<Amazon.EC2.Model.PerformanceFactorReferenceRequest>(this.InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference);
            }
            context.InstanceRequirements_BurstablePerformance = this.InstanceRequirements_BurstablePerformance;
            if (this.InstanceRequirements_CpuManufacturer != null)
            {
                context.InstanceRequirements_CpuManufacturer = new List<System.String>(this.InstanceRequirements_CpuManufacturer);
            }
            if (this.InstanceRequirements_ExcludedInstanceType != null)
            {
                context.InstanceRequirements_ExcludedInstanceType = new List<System.String>(this.InstanceRequirements_ExcludedInstanceType);
            }
            if (this.InstanceRequirements_InstanceGeneration != null)
            {
                context.InstanceRequirements_InstanceGeneration = new List<System.String>(this.InstanceRequirements_InstanceGeneration);
            }
            context.InstanceRequirements_LocalStorage = this.InstanceRequirements_LocalStorage;
            if (this.InstanceRequirements_LocalStorageType != null)
            {
                context.InstanceRequirements_LocalStorageType = new List<System.String>(this.InstanceRequirements_LocalStorageType);
            }
            context.InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = this.InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice;
            context.InstanceRequirements_MemoryGiBPerVCpu_Max = this.InstanceRequirements_MemoryGiBPerVCpu_Max;
            context.InstanceRequirements_MemoryGiBPerVCpu_Min = this.InstanceRequirements_MemoryGiBPerVCpu_Min;
            context.InstanceRequirements_MemoryMiB_Max = this.InstanceRequirements_MemoryMiB_Max;
            context.InstanceRequirements_MemoryMiB_Min = this.InstanceRequirements_MemoryMiB_Min;
            context.InstanceRequirements_NetworkBandwidthGbps_Max = this.InstanceRequirements_NetworkBandwidthGbps_Max;
            context.InstanceRequirements_NetworkBandwidthGbps_Min = this.InstanceRequirements_NetworkBandwidthGbps_Min;
            context.InstanceRequirements_NetworkInterfaceCount_Max = this.InstanceRequirements_NetworkInterfaceCount_Max;
            context.InstanceRequirements_NetworkInterfaceCount_Min = this.InstanceRequirements_NetworkInterfaceCount_Min;
            context.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = this.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice;
            context.InstanceRequirements_RequireEncryptionInTransit = this.InstanceRequirements_RequireEncryptionInTransit;
            context.InstanceRequirements_RequireHibernateSupport = this.InstanceRequirements_RequireHibernateSupport;
            context.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice = this.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice;
            context.InstanceRequirements_TotalLocalStorageGB_Max = this.InstanceRequirements_TotalLocalStorageGB_Max;
            context.InstanceRequirements_TotalLocalStorageGB_Min = this.InstanceRequirements_TotalLocalStorageGB_Min;
            context.InstanceRequirements_VCpuCount_Max = this.InstanceRequirements_VCpuCount_Max;
            context.InstanceRequirements_VCpuCount_Min = this.InstanceRequirements_VCpuCount_Min;
            if (this.InstanceTypeSpecification != null)
            {
                context.InstanceTypeSpecification = new List<Amazon.EC2.Model.ReservationFleetInstanceSpecification>(this.InstanceTypeSpecification);
            }
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.Tenancy = this.Tenancy;
            context.TotalTargetCapacity = this.TotalTargetCapacity;
            #if MODULAR
            if (this.TotalTargetCapacity == null && ParameterWasBound(nameof(this.TotalTargetCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter TotalTargetCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.EC2.Model.CreateCapacityReservationFleetRequest();
            
            if (cmdletContext.AllocationStrategy != null)
            {
                request.AllocationStrategy = cmdletContext.AllocationStrategy;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.InstanceMatchCriterion != null)
            {
                request.InstanceMatchCriteria = cmdletContext.InstanceMatchCriterion;
            }
            
             // populate InstanceRequirements
            var requestInstanceRequirementsIsNull = true;
            request.InstanceRequirements = new Amazon.EC2.Model.InstanceRequirementsRequest();
            List<System.String> requestInstanceRequirements_instanceRequirements_AcceleratorManufacturer = null;
            if (cmdletContext.InstanceRequirements_AcceleratorManufacturer != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorManufacturer = cmdletContext.InstanceRequirements_AcceleratorManufacturer;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorManufacturer != null)
            {
                request.InstanceRequirements.AcceleratorManufacturers = requestInstanceRequirements_instanceRequirements_AcceleratorManufacturer;
                requestInstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirements_instanceRequirements_AcceleratorName = null;
            if (cmdletContext.InstanceRequirements_AcceleratorName != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorName = cmdletContext.InstanceRequirements_AcceleratorName;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorName != null)
            {
                request.InstanceRequirements.AcceleratorNames = requestInstanceRequirements_instanceRequirements_AcceleratorName;
                requestInstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirements_instanceRequirements_AcceleratorType = null;
            if (cmdletContext.InstanceRequirements_AcceleratorType != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorType = cmdletContext.InstanceRequirements_AcceleratorType;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorType != null)
            {
                request.InstanceRequirements.AcceleratorTypes = requestInstanceRequirements_instanceRequirements_AcceleratorType;
                requestInstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirements_instanceRequirements_AllowedInstanceType = null;
            if (cmdletContext.InstanceRequirements_AllowedInstanceType != null)
            {
                requestInstanceRequirements_instanceRequirements_AllowedInstanceType = cmdletContext.InstanceRequirements_AllowedInstanceType;
            }
            if (requestInstanceRequirements_instanceRequirements_AllowedInstanceType != null)
            {
                request.InstanceRequirements.AllowedInstanceTypes = requestInstanceRequirements_instanceRequirements_AllowedInstanceType;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.BareMetal requestInstanceRequirements_instanceRequirements_BareMetal = null;
            if (cmdletContext.InstanceRequirements_BareMetal != null)
            {
                requestInstanceRequirements_instanceRequirements_BareMetal = cmdletContext.InstanceRequirements_BareMetal;
            }
            if (requestInstanceRequirements_instanceRequirements_BareMetal != null)
            {
                request.InstanceRequirements.BareMetal = requestInstanceRequirements_instanceRequirements_BareMetal;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.BurstablePerformance requestInstanceRequirements_instanceRequirements_BurstablePerformance = null;
            if (cmdletContext.InstanceRequirements_BurstablePerformance != null)
            {
                requestInstanceRequirements_instanceRequirements_BurstablePerformance = cmdletContext.InstanceRequirements_BurstablePerformance;
            }
            if (requestInstanceRequirements_instanceRequirements_BurstablePerformance != null)
            {
                request.InstanceRequirements.BurstablePerformance = requestInstanceRequirements_instanceRequirements_BurstablePerformance;
                requestInstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirements_instanceRequirements_CpuManufacturer = null;
            if (cmdletContext.InstanceRequirements_CpuManufacturer != null)
            {
                requestInstanceRequirements_instanceRequirements_CpuManufacturer = cmdletContext.InstanceRequirements_CpuManufacturer;
            }
            if (requestInstanceRequirements_instanceRequirements_CpuManufacturer != null)
            {
                request.InstanceRequirements.CpuManufacturers = requestInstanceRequirements_instanceRequirements_CpuManufacturer;
                requestInstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirements_instanceRequirements_ExcludedInstanceType = null;
            if (cmdletContext.InstanceRequirements_ExcludedInstanceType != null)
            {
                requestInstanceRequirements_instanceRequirements_ExcludedInstanceType = cmdletContext.InstanceRequirements_ExcludedInstanceType;
            }
            if (requestInstanceRequirements_instanceRequirements_ExcludedInstanceType != null)
            {
                request.InstanceRequirements.ExcludedInstanceTypes = requestInstanceRequirements_instanceRequirements_ExcludedInstanceType;
                requestInstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirements_instanceRequirements_InstanceGeneration = null;
            if (cmdletContext.InstanceRequirements_InstanceGeneration != null)
            {
                requestInstanceRequirements_instanceRequirements_InstanceGeneration = cmdletContext.InstanceRequirements_InstanceGeneration;
            }
            if (requestInstanceRequirements_instanceRequirements_InstanceGeneration != null)
            {
                request.InstanceRequirements.InstanceGenerations = requestInstanceRequirements_instanceRequirements_InstanceGeneration;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.LocalStorage requestInstanceRequirements_instanceRequirements_LocalStorage = null;
            if (cmdletContext.InstanceRequirements_LocalStorage != null)
            {
                requestInstanceRequirements_instanceRequirements_LocalStorage = cmdletContext.InstanceRequirements_LocalStorage;
            }
            if (requestInstanceRequirements_instanceRequirements_LocalStorage != null)
            {
                request.InstanceRequirements.LocalStorage = requestInstanceRequirements_instanceRequirements_LocalStorage;
                requestInstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirements_instanceRequirements_LocalStorageType = null;
            if (cmdletContext.InstanceRequirements_LocalStorageType != null)
            {
                requestInstanceRequirements_instanceRequirements_LocalStorageType = cmdletContext.InstanceRequirements_LocalStorageType;
            }
            if (requestInstanceRequirements_instanceRequirements_LocalStorageType != null)
            {
                request.InstanceRequirements.LocalStorageTypes = requestInstanceRequirements_instanceRequirements_LocalStorageType;
                requestInstanceRequirementsIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = null;
            if (cmdletContext.InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice != null)
            {
                requestInstanceRequirements_instanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = cmdletContext.InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice != null)
            {
                request.InstanceRequirements.MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = requestInstanceRequirements_instanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice.Value;
                requestInstanceRequirementsIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = null;
            if (cmdletContext.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = cmdletContext.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice != null)
            {
                request.InstanceRequirements.OnDemandMaxPricePercentageOverLowestPrice = requestInstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice.Value;
                requestInstanceRequirementsIsNull = false;
            }
            System.Boolean? requestInstanceRequirements_instanceRequirements_RequireEncryptionInTransit = null;
            if (cmdletContext.InstanceRequirements_RequireEncryptionInTransit != null)
            {
                requestInstanceRequirements_instanceRequirements_RequireEncryptionInTransit = cmdletContext.InstanceRequirements_RequireEncryptionInTransit.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_RequireEncryptionInTransit != null)
            {
                request.InstanceRequirements.RequireEncryptionInTransit = requestInstanceRequirements_instanceRequirements_RequireEncryptionInTransit.Value;
                requestInstanceRequirementsIsNull = false;
            }
            System.Boolean? requestInstanceRequirements_instanceRequirements_RequireHibernateSupport = null;
            if (cmdletContext.InstanceRequirements_RequireHibernateSupport != null)
            {
                requestInstanceRequirements_instanceRequirements_RequireHibernateSupport = cmdletContext.InstanceRequirements_RequireHibernateSupport.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_RequireHibernateSupport != null)
            {
                request.InstanceRequirements.RequireHibernateSupport = requestInstanceRequirements_instanceRequirements_RequireHibernateSupport.Value;
                requestInstanceRequirementsIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice = null;
            if (cmdletContext.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice = cmdletContext.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice != null)
            {
                request.InstanceRequirements.SpotMaxPricePercentageOverLowestPrice = requestInstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice.Value;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.BaselinePerformanceFactorsRequest requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors = null;
            
             // populate BaselinePerformanceFactors
            var requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactorsIsNull = true;
            requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors = new Amazon.EC2.Model.BaselinePerformanceFactorsRequest();
            Amazon.EC2.Model.CpuPerformanceFactorRequest requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu = null;
            
             // populate Cpu
            var requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_CpuIsNull = true;
            requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu = new Amazon.EC2.Model.CpuPerformanceFactorRequest();
            List<Amazon.EC2.Model.PerformanceFactorReferenceRequest> requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu_instanceRequirements_BaselinePerformanceFactors_Cpu_Reference = null;
            if (cmdletContext.InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu_instanceRequirements_BaselinePerformanceFactors_Cpu_Reference = cmdletContext.InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference;
            }
            if (requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu_instanceRequirements_BaselinePerformanceFactors_Cpu_Reference != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu.References = requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu_instanceRequirements_BaselinePerformanceFactors_Cpu_Reference;
                requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_CpuIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu should be set to null
            if (requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_CpuIsNull)
            {
                requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu = null;
            }
            if (requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors.Cpu = requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu;
                requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactorsIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors should be set to null
            if (requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactorsIsNull)
            {
                requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors = null;
            }
            if (requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors != null)
            {
                request.InstanceRequirements.BaselinePerformanceFactors = requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.AcceleratorCountRequest requestInstanceRequirements_instanceRequirements_AcceleratorCount = null;
            
             // populate AcceleratorCount
            var requestInstanceRequirements_instanceRequirements_AcceleratorCountIsNull = true;
            requestInstanceRequirements_instanceRequirements_AcceleratorCount = new Amazon.EC2.Model.AcceleratorCountRequest();
            System.Int32? requestInstanceRequirements_instanceRequirements_AcceleratorCount_instanceRequirements_AcceleratorCount_Max = null;
            if (cmdletContext.InstanceRequirements_AcceleratorCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorCount_instanceRequirements_AcceleratorCount_Max = cmdletContext.InstanceRequirements_AcceleratorCount_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorCount_instanceRequirements_AcceleratorCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorCount.Max = requestInstanceRequirements_instanceRequirements_AcceleratorCount_instanceRequirements_AcceleratorCount_Max.Value;
                requestInstanceRequirements_instanceRequirements_AcceleratorCountIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_AcceleratorCount_instanceRequirements_AcceleratorCount_Min = null;
            if (cmdletContext.InstanceRequirements_AcceleratorCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorCount_instanceRequirements_AcceleratorCount_Min = cmdletContext.InstanceRequirements_AcceleratorCount_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorCount_instanceRequirements_AcceleratorCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorCount.Min = requestInstanceRequirements_instanceRequirements_AcceleratorCount_instanceRequirements_AcceleratorCount_Min.Value;
                requestInstanceRequirements_instanceRequirements_AcceleratorCountIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_AcceleratorCount should be set to null
            if (requestInstanceRequirements_instanceRequirements_AcceleratorCountIsNull)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorCount = null;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorCount != null)
            {
                request.InstanceRequirements.AcceleratorCount = requestInstanceRequirements_instanceRequirements_AcceleratorCount;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.AcceleratorTotalMemoryMiBRequest requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB = null;
            
             // populate AcceleratorTotalMemoryMiB
            var requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiBIsNull = true;
            requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB = new Amazon.EC2.Model.AcceleratorTotalMemoryMiBRequest();
            System.Int32? requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirements_AcceleratorTotalMemoryMiB_Max = null;
            if (cmdletContext.InstanceRequirements_AcceleratorTotalMemoryMiB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirements_AcceleratorTotalMemoryMiB_Max = cmdletContext.InstanceRequirements_AcceleratorTotalMemoryMiB_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirements_AcceleratorTotalMemoryMiB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB.Max = requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirements_AcceleratorTotalMemoryMiB_Max.Value;
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiBIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirements_AcceleratorTotalMemoryMiB_Min = null;
            if (cmdletContext.InstanceRequirements_AcceleratorTotalMemoryMiB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirements_AcceleratorTotalMemoryMiB_Min = cmdletContext.InstanceRequirements_AcceleratorTotalMemoryMiB_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirements_AcceleratorTotalMemoryMiB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB.Min = requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirements_AcceleratorTotalMemoryMiB_Min.Value;
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiBIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB should be set to null
            if (requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiBIsNull)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB = null;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB != null)
            {
                request.InstanceRequirements.AcceleratorTotalMemoryMiB = requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.BaselineEbsBandwidthMbpsRequest requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps = null;
            
             // populate BaselineEbsBandwidthMbps
            var requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbpsIsNull = true;
            requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps = new Amazon.EC2.Model.BaselineEbsBandwidthMbpsRequest();
            System.Int32? requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_instanceRequirements_BaselineEbsBandwidthMbps_Max = null;
            if (cmdletContext.InstanceRequirements_BaselineEbsBandwidthMbps_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_instanceRequirements_BaselineEbsBandwidthMbps_Max = cmdletContext.InstanceRequirements_BaselineEbsBandwidthMbps_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_instanceRequirements_BaselineEbsBandwidthMbps_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps.Max = requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_instanceRequirements_BaselineEbsBandwidthMbps_Max.Value;
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbpsIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_instanceRequirements_BaselineEbsBandwidthMbps_Min = null;
            if (cmdletContext.InstanceRequirements_BaselineEbsBandwidthMbps_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_instanceRequirements_BaselineEbsBandwidthMbps_Min = cmdletContext.InstanceRequirements_BaselineEbsBandwidthMbps_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_instanceRequirements_BaselineEbsBandwidthMbps_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps.Min = requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_instanceRequirements_BaselineEbsBandwidthMbps_Min.Value;
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbpsIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps should be set to null
            if (requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbpsIsNull)
            {
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps = null;
            }
            if (requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps != null)
            {
                request.InstanceRequirements.BaselineEbsBandwidthMbps = requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.MemoryGiBPerVCpuRequest requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu = null;
            
             // populate MemoryGiBPerVCpu
            var requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpuIsNull = true;
            requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu = new Amazon.EC2.Model.MemoryGiBPerVCpuRequest();
            System.Double? requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_instanceRequirements_MemoryGiBPerVCpu_Max = null;
            if (cmdletContext.InstanceRequirements_MemoryGiBPerVCpu_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_instanceRequirements_MemoryGiBPerVCpu_Max = cmdletContext.InstanceRequirements_MemoryGiBPerVCpu_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_instanceRequirements_MemoryGiBPerVCpu_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu.Max = requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_instanceRequirements_MemoryGiBPerVCpu_Max.Value;
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpuIsNull = false;
            }
            System.Double? requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_instanceRequirements_MemoryGiBPerVCpu_Min = null;
            if (cmdletContext.InstanceRequirements_MemoryGiBPerVCpu_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_instanceRequirements_MemoryGiBPerVCpu_Min = cmdletContext.InstanceRequirements_MemoryGiBPerVCpu_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_instanceRequirements_MemoryGiBPerVCpu_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu.Min = requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_instanceRequirements_MemoryGiBPerVCpu_Min.Value;
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpuIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu should be set to null
            if (requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpuIsNull)
            {
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu = null;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu != null)
            {
                request.InstanceRequirements.MemoryGiBPerVCpu = requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.MemoryMiBRequest requestInstanceRequirements_instanceRequirements_MemoryMiB = null;
            
             // populate MemoryMiB
            var requestInstanceRequirements_instanceRequirements_MemoryMiBIsNull = true;
            requestInstanceRequirements_instanceRequirements_MemoryMiB = new Amazon.EC2.Model.MemoryMiBRequest();
            System.Int32? requestInstanceRequirements_instanceRequirements_MemoryMiB_instanceRequirements_MemoryMiB_Max = null;
            if (cmdletContext.InstanceRequirements_MemoryMiB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryMiB_instanceRequirements_MemoryMiB_Max = cmdletContext.InstanceRequirements_MemoryMiB_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryMiB_instanceRequirements_MemoryMiB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryMiB.Max = requestInstanceRequirements_instanceRequirements_MemoryMiB_instanceRequirements_MemoryMiB_Max.Value;
                requestInstanceRequirements_instanceRequirements_MemoryMiBIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_MemoryMiB_instanceRequirements_MemoryMiB_Min = null;
            if (cmdletContext.InstanceRequirements_MemoryMiB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryMiB_instanceRequirements_MemoryMiB_Min = cmdletContext.InstanceRequirements_MemoryMiB_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryMiB_instanceRequirements_MemoryMiB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryMiB.Min = requestInstanceRequirements_instanceRequirements_MemoryMiB_instanceRequirements_MemoryMiB_Min.Value;
                requestInstanceRequirements_instanceRequirements_MemoryMiBIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_MemoryMiB should be set to null
            if (requestInstanceRequirements_instanceRequirements_MemoryMiBIsNull)
            {
                requestInstanceRequirements_instanceRequirements_MemoryMiB = null;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryMiB != null)
            {
                request.InstanceRequirements.MemoryMiB = requestInstanceRequirements_instanceRequirements_MemoryMiB;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.NetworkBandwidthGbpsRequest requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps = null;
            
             // populate NetworkBandwidthGbps
            var requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbpsIsNull = true;
            requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps = new Amazon.EC2.Model.NetworkBandwidthGbpsRequest();
            System.Double? requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_instanceRequirements_NetworkBandwidthGbps_Max = null;
            if (cmdletContext.InstanceRequirements_NetworkBandwidthGbps_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_instanceRequirements_NetworkBandwidthGbps_Max = cmdletContext.InstanceRequirements_NetworkBandwidthGbps_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_instanceRequirements_NetworkBandwidthGbps_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps.Max = requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_instanceRequirements_NetworkBandwidthGbps_Max.Value;
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbpsIsNull = false;
            }
            System.Double? requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_instanceRequirements_NetworkBandwidthGbps_Min = null;
            if (cmdletContext.InstanceRequirements_NetworkBandwidthGbps_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_instanceRequirements_NetworkBandwidthGbps_Min = cmdletContext.InstanceRequirements_NetworkBandwidthGbps_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_instanceRequirements_NetworkBandwidthGbps_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps.Min = requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_instanceRequirements_NetworkBandwidthGbps_Min.Value;
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbpsIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps should be set to null
            if (requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbpsIsNull)
            {
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps = null;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps != null)
            {
                request.InstanceRequirements.NetworkBandwidthGbps = requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.NetworkInterfaceCountRequest requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount = null;
            
             // populate NetworkInterfaceCount
            var requestInstanceRequirements_instanceRequirements_NetworkInterfaceCountIsNull = true;
            requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount = new Amazon.EC2.Model.NetworkInterfaceCountRequest();
            System.Int32? requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_instanceRequirements_NetworkInterfaceCount_Max = null;
            if (cmdletContext.InstanceRequirements_NetworkInterfaceCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_instanceRequirements_NetworkInterfaceCount_Max = cmdletContext.InstanceRequirements_NetworkInterfaceCount_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_instanceRequirements_NetworkInterfaceCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount.Max = requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_instanceRequirements_NetworkInterfaceCount_Max.Value;
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCountIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_instanceRequirements_NetworkInterfaceCount_Min = null;
            if (cmdletContext.InstanceRequirements_NetworkInterfaceCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_instanceRequirements_NetworkInterfaceCount_Min = cmdletContext.InstanceRequirements_NetworkInterfaceCount_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_instanceRequirements_NetworkInterfaceCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount.Min = requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_instanceRequirements_NetworkInterfaceCount_Min.Value;
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCountIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount should be set to null
            if (requestInstanceRequirements_instanceRequirements_NetworkInterfaceCountIsNull)
            {
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount = null;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount != null)
            {
                request.InstanceRequirements.NetworkInterfaceCount = requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.TotalLocalStorageGBRequest requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB = null;
            
             // populate TotalLocalStorageGB
            var requestInstanceRequirements_instanceRequirements_TotalLocalStorageGBIsNull = true;
            requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB = new Amazon.EC2.Model.TotalLocalStorageGBRequest();
            System.Double? requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_instanceRequirements_TotalLocalStorageGB_Max = null;
            if (cmdletContext.InstanceRequirements_TotalLocalStorageGB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_instanceRequirements_TotalLocalStorageGB_Max = cmdletContext.InstanceRequirements_TotalLocalStorageGB_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_instanceRequirements_TotalLocalStorageGB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB.Max = requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_instanceRequirements_TotalLocalStorageGB_Max.Value;
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGBIsNull = false;
            }
            System.Double? requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_instanceRequirements_TotalLocalStorageGB_Min = null;
            if (cmdletContext.InstanceRequirements_TotalLocalStorageGB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_instanceRequirements_TotalLocalStorageGB_Min = cmdletContext.InstanceRequirements_TotalLocalStorageGB_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_instanceRequirements_TotalLocalStorageGB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB.Min = requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_instanceRequirements_TotalLocalStorageGB_Min.Value;
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGBIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB should be set to null
            if (requestInstanceRequirements_instanceRequirements_TotalLocalStorageGBIsNull)
            {
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB = null;
            }
            if (requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB != null)
            {
                request.InstanceRequirements.TotalLocalStorageGB = requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB;
                requestInstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.VCpuCountRangeRequest requestInstanceRequirements_instanceRequirements_VCpuCount = null;
            
             // populate VCpuCount
            var requestInstanceRequirements_instanceRequirements_VCpuCountIsNull = true;
            requestInstanceRequirements_instanceRequirements_VCpuCount = new Amazon.EC2.Model.VCpuCountRangeRequest();
            System.Int32? requestInstanceRequirements_instanceRequirements_VCpuCount_instanceRequirements_VCpuCount_Max = null;
            if (cmdletContext.InstanceRequirements_VCpuCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_VCpuCount_instanceRequirements_VCpuCount_Max = cmdletContext.InstanceRequirements_VCpuCount_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_VCpuCount_instanceRequirements_VCpuCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_VCpuCount.Max = requestInstanceRequirements_instanceRequirements_VCpuCount_instanceRequirements_VCpuCount_Max.Value;
                requestInstanceRequirements_instanceRequirements_VCpuCountIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_VCpuCount_instanceRequirements_VCpuCount_Min = null;
            if (cmdletContext.InstanceRequirements_VCpuCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_VCpuCount_instanceRequirements_VCpuCount_Min = cmdletContext.InstanceRequirements_VCpuCount_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_VCpuCount_instanceRequirements_VCpuCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_VCpuCount.Min = requestInstanceRequirements_instanceRequirements_VCpuCount_instanceRequirements_VCpuCount_Min.Value;
                requestInstanceRequirements_instanceRequirements_VCpuCountIsNull = false;
            }
             // determine if requestInstanceRequirements_instanceRequirements_VCpuCount should be set to null
            if (requestInstanceRequirements_instanceRequirements_VCpuCountIsNull)
            {
                requestInstanceRequirements_instanceRequirements_VCpuCount = null;
            }
            if (requestInstanceRequirements_instanceRequirements_VCpuCount != null)
            {
                request.InstanceRequirements.VCpuCount = requestInstanceRequirements_instanceRequirements_VCpuCount;
                requestInstanceRequirementsIsNull = false;
            }
             // determine if request.InstanceRequirements should be set to null
            if (requestInstanceRequirementsIsNull)
            {
                request.InstanceRequirements = null;
            }
            if (cmdletContext.InstanceTypeSpecification != null)
            {
                request.InstanceTypeSpecifications = cmdletContext.InstanceTypeSpecification;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.Tenancy != null)
            {
                request.Tenancy = cmdletContext.Tenancy;
            }
            if (cmdletContext.TotalTargetCapacity != null)
            {
                request.TotalTargetCapacity = cmdletContext.TotalTargetCapacity.Value;
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
        
        private Amazon.EC2.Model.CreateCapacityReservationFleetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateCapacityReservationFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateCapacityReservationFleet");
            try
            {
                return client.CreateCapacityReservationFleetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AllocationStrategy { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.String AvailabilityZoneId { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.DateTime? EndDate { get; set; }
            public Amazon.EC2.FleetInstanceMatchCriteria InstanceMatchCriterion { get; set; }
            public System.Int32? InstanceRequirements_AcceleratorCount_Max { get; set; }
            public System.Int32? InstanceRequirements_AcceleratorCount_Min { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorManufacturer { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorName { get; set; }
            public System.Int32? InstanceRequirements_AcceleratorTotalMemoryMiB_Max { get; set; }
            public System.Int32? InstanceRequirements_AcceleratorTotalMemoryMiB_Min { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorType { get; set; }
            public List<System.String> InstanceRequirements_AllowedInstanceType { get; set; }
            public Amazon.EC2.BareMetal InstanceRequirements_BareMetal { get; set; }
            public System.Int32? InstanceRequirements_BaselineEbsBandwidthMbps_Max { get; set; }
            public System.Int32? InstanceRequirements_BaselineEbsBandwidthMbps_Min { get; set; }
            public List<Amazon.EC2.Model.PerformanceFactorReferenceRequest> InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference { get; set; }
            public Amazon.EC2.BurstablePerformance InstanceRequirements_BurstablePerformance { get; set; }
            public List<System.String> InstanceRequirements_CpuManufacturer { get; set; }
            public List<System.String> InstanceRequirements_ExcludedInstanceType { get; set; }
            public List<System.String> InstanceRequirements_InstanceGeneration { get; set; }
            public Amazon.EC2.LocalStorage InstanceRequirements_LocalStorage { get; set; }
            public List<System.String> InstanceRequirements_LocalStorageType { get; set; }
            public System.Int32? InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice { get; set; }
            public System.Double? InstanceRequirements_MemoryGiBPerVCpu_Max { get; set; }
            public System.Double? InstanceRequirements_MemoryGiBPerVCpu_Min { get; set; }
            public System.Int32? InstanceRequirements_MemoryMiB_Max { get; set; }
            public System.Int32? InstanceRequirements_MemoryMiB_Min { get; set; }
            public System.Double? InstanceRequirements_NetworkBandwidthGbps_Max { get; set; }
            public System.Double? InstanceRequirements_NetworkBandwidthGbps_Min { get; set; }
            public System.Int32? InstanceRequirements_NetworkInterfaceCount_Max { get; set; }
            public System.Int32? InstanceRequirements_NetworkInterfaceCount_Min { get; set; }
            public System.Int32? InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice { get; set; }
            public System.Boolean? InstanceRequirements_RequireEncryptionInTransit { get; set; }
            public System.Boolean? InstanceRequirements_RequireHibernateSupport { get; set; }
            public System.Int32? InstanceRequirements_SpotMaxPricePercentageOverLowestPrice { get; set; }
            public System.Double? InstanceRequirements_TotalLocalStorageGB_Max { get; set; }
            public System.Double? InstanceRequirements_TotalLocalStorageGB_Min { get; set; }
            public System.Int32? InstanceRequirements_VCpuCount_Max { get; set; }
            public System.Int32? InstanceRequirements_VCpuCount_Min { get; set; }
            public List<Amazon.EC2.Model.ReservationFleetInstanceSpecification> InstanceTypeSpecification { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.FleetCapacityReservationTenancy Tenancy { get; set; }
            public System.Int32? TotalTargetCapacity { get; set; }
            public System.Func<Amazon.EC2.Model.CreateCapacityReservationFleetResponse, NewEC2CapacityReservationFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
