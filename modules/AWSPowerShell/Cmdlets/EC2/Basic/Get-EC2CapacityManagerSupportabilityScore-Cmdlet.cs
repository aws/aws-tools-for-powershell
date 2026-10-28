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
    /// Scores how well each instance type and Availability Zone combination can support
    /// a capacity request, based on current Amazon EC2 capacity. The response includes a
    /// score for each combination and an aggregate score for all combinations in the request.
    /// This action doesn't launch or reserve instances, and a score doesn't guarantee that
    /// a later launch will succeed. 
    /// 
    ///  
    /// <para>
    ///  Call this action in the Region where you turned on Capacity Manager. A single request
    /// can include Availability Zones in any Region. Real-time supportability checks are
    /// available only to Amazon Web Services Support customers on the Unified Operations
    /// plan. 
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/capacity-manager-supportability.html">Check
    /// supportability</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2CapacityManagerSupportabilityScore")]
    [OutputType("Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetCapacityManagerSupportabilityScores API operation.", Operation = new[] {"GetCapacityManagerSupportabilityScores"}, SelectReturnType = typeof(Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresResponse",
        "This cmdlet returns an Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresResponse object containing multiple properties."
    )]
    public partial class GetEC2CapacityManagerSupportabilityScoreCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer
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
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturers")]
        public System.String[] InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName
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
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorNames")]
        public System.String[] InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType
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
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTypes")]
        public System.String[] InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType
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
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceTypes")]
        public System.String[] InstanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_ArchitectureType
        /// <summary>
        /// <para>
        /// <para>The architecture type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_ArchitectureTypes")]
        public System.String[] InstanceRequirementsWithMetadata_ArchitectureType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_BareMetal
        /// <summary>
        /// <para>
        /// <para>Indicates whether bare metal instance types must be included, excluded, or required.</para><ul><li><para>To include bare metal instance types, specify <c>included</c>.</para></li><li><para>To require only bare metal instance types, specify <c>required</c>.</para></li><li><para>To exclude bare metal instance types, specify <c>excluded</c>.</para></li></ul><para>Default: <c>excluded</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.BareMetal")]
        public Amazon.EC2.BareMetal InstanceRequirementsWithMetadata_InstanceRequirements_BareMetal { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance
        /// <summary>
        /// <para>
        /// <para>Indicates whether burstable performance T instance types are included, excluded, or
        /// required. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/burstable-performance-instances.html">Burstable
        /// performance instances</a>.</para><ul><li><para>To include burstable performance instance types, specify <c>included</c>.</para></li><li><para>To require only burstable performance instance types, specify <c>required</c>.</para></li><li><para>To exclude burstable performance instance types, specify <c>excluded</c>.</para></li></ul><para>Default: <c>excluded</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.BurstablePerformance")]
        public Amazon.EC2.BurstablePerformance InstanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance { get; set; }
        #endregion
        
        #region Parameter CapacityAmount
        /// <summary>
        /// <para>
        /// <para> The amount of capacity that you need, in the unit that you specify for <c>CapacityUnit</c>.
        /// Each score is relative to this amount. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? CapacityAmount { get; set; }
        #endregion
        
        #region Parameter CapacityAvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para> The IDs of the Availability Zones to score, such as <c>use1-az1</c>. You can specify
        /// Availability Zones in different Regions. You can specify up to 10 Availability Zones.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("CapacityAvailabilityZoneIds")]
        public System.String[] CapacityAvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter CapacityUnit
        /// <summary>
        /// <para>
        /// <para> The unit for <c>CapacityAmount</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.CapacityUnit")]
        public Amazon.EC2.CapacityUnit CapacityUnit { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer
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
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturers")]
        public System.String[] InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para> Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType
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
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceTypes")]
        public System.String[] InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration
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
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGenerations")]
        public System.String[] InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para> The instance types to score. You can specify up to 50 instance types. </para><para> Specify either <c>InstanceTypes</c> or <c>InstanceRequirementsWithMetadata</c>, but
        /// not both. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypes")]
        public System.String[] InstanceType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorage
        /// <summary>
        /// <para>
        /// <para>Indicates whether instance types with instance store volumes are included, excluded,
        /// or required. For more information, <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/InstanceStorage.html">Amazon
        /// EC2 instance store</a> in the <i>Amazon EC2 User Guide</i>.</para><ul><li><para>To include instance types with instance store volumes, specify <c>included</c>.</para></li><li><para>To require only instance types with instance store volumes, specify <c>required</c>.</para></li><li><para>To exclude instance types with instance store volumes, specify <c>excluded</c>.</para></li></ul><para>Default: <c>included</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.LocalStorage")]
        public Amazon.EC2.LocalStorage InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorage { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType
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
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageTypes")]
        public System.String[] InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType { get; set; }
        #endregion
        
        #region Parameter MarketType
        /// <summary>
        /// <para>
        /// <para> The capacity market to score. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.SupportabilityMarketType")]
        public Amazon.EC2.SupportabilityMarketType MarketType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of accelerators. To specify no maximum limit, omit this parameter.
        /// To exclude accelerator-enabled instance types, set <c>Max</c> to <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of accelerator memory, in MiB. To specify no maximum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max
        /// <summary>
        /// <para>
        /// <para>The maximum baseline bandwidth, in Mbps. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory per vCPU, in GiB. To specify no maximum limit, omit this
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory, in MiB. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of network bandwidth, in Gbps. To specify no maximum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of network interfaces. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of total local storage, in GB. To specify no maximum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice
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
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of accelerators. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of accelerator memory, in MiB. To specify no minimum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min
        /// <summary>
        /// <para>
        /// <para>The minimum baseline bandwidth, in Mbps. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory per vCPU, in GiB. To specify no minimum limit, omit this
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory, in MiB. To specify no minimum limit, specify <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of network bandwidth, in Gbps. To specify no minimum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of network interfaces. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of total local storage, in GB. To specify no minimum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of vCPUs. To specify no minimum limit, specify <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice
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
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference
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
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_References")]
        public Amazon.EC2.Model.PerformanceFactorReferenceRequest[] InstanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit
        /// <summary>
        /// <para>
        /// <para>Specifies whether instance types must support encrypting in-transit traffic between
        /// instances. For more information, including the supported instance types, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/data-protection.html#encryption-transit">Encryption
        /// in transit</a> in the <i>Amazon EC2 User Guide</i>.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport
        /// <summary>
        /// <para>
        /// <para>Indicates whether instance types must support hibernation for On-Demand Instances.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetSpotPlacementScores.html">GetSpotPlacementScores</a>.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice
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
        public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_VirtualizationType
        /// <summary>
        /// <para>
        /// <para>The virtualization type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_VirtualizationTypes")]
        public System.String[] InstanceRequirementsWithMetadata_VirtualizationType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresResponse, GetEC2CapacityManagerSupportabilityScoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityAmount = this.CapacityAmount;
            #if MODULAR
            if (this.CapacityAmount == null && ParameterWasBound(nameof(this.CapacityAmount)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityAmount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CapacityAvailabilityZoneId != null)
            {
                context.CapacityAvailabilityZoneId = new List<System.String>(this.CapacityAvailabilityZoneId);
            }
            #if MODULAR
            if (this.CapacityAvailabilityZoneId == null && ParameterWasBound(nameof(this.CapacityAvailabilityZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityAvailabilityZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CapacityUnit = this.CapacityUnit;
            #if MODULAR
            if (this.CapacityUnit == null && ParameterWasBound(nameof(this.CapacityUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            if (this.InstanceRequirementsWithMetadata_ArchitectureType != null)
            {
                context.InstanceRequirementsWithMetadata_ArchitectureType = new List<System.String>(this.InstanceRequirementsWithMetadata_ArchitectureType);
            }
            context.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max = this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min = this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min;
            if (this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer != null)
            {
                context.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer = new List<System.String>(this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer);
            }
            if (this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName != null)
            {
                context.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName = new List<System.String>(this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName);
            }
            context.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max = this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min = this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min;
            if (this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType != null)
            {
                context.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType = new List<System.String>(this.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType);
            }
            if (this.InstanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType != null)
            {
                context.InstanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType = new List<System.String>(this.InstanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType);
            }
            context.InstanceRequirementsWithMetadata_InstanceRequirements_BareMetal = this.InstanceRequirementsWithMetadata_InstanceRequirements_BareMetal;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max = this.InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min = this.InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min;
            if (this.InstanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference != null)
            {
                context.InstanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference = new List<Amazon.EC2.Model.PerformanceFactorReferenceRequest>(this.InstanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference);
            }
            context.InstanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance = this.InstanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance;
            if (this.InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer != null)
            {
                context.InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer = new List<System.String>(this.InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer);
            }
            if (this.InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType != null)
            {
                context.InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType = new List<System.String>(this.InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType);
            }
            if (this.InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration != null)
            {
                context.InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration = new List<System.String>(this.InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration);
            }
            context.InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorage = this.InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorage;
            if (this.InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType != null)
            {
                context.InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType = new List<System.String>(this.InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType);
            }
            context.InstanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = this.InstanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max = this.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min = this.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max = this.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min = this.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max = this.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min = this.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max = this.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min = this.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = this.InstanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit = this.InstanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport = this.InstanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice = this.InstanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max = this.InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min = this.InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max = this.InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max;
            context.InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min = this.InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min;
            if (this.InstanceRequirementsWithMetadata_VirtualizationType != null)
            {
                context.InstanceRequirementsWithMetadata_VirtualizationType = new List<System.String>(this.InstanceRequirementsWithMetadata_VirtualizationType);
            }
            if (this.InstanceType != null)
            {
                context.InstanceType = new List<System.String>(this.InstanceType);
            }
            context.MarketType = this.MarketType;
            #if MODULAR
            if (this.MarketType == null && ParameterWasBound(nameof(this.MarketType)))
            {
                WriteWarning("You are passing $null as a value for parameter MarketType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresRequest();
            
            if (cmdletContext.CapacityAmount != null)
            {
                request.CapacityAmount = cmdletContext.CapacityAmount.Value;
            }
            if (cmdletContext.CapacityAvailabilityZoneId != null)
            {
                request.CapacityAvailabilityZoneIds = cmdletContext.CapacityAvailabilityZoneId;
            }
            if (cmdletContext.CapacityUnit != null)
            {
                request.CapacityUnit = cmdletContext.CapacityUnit;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate InstanceRequirementsWithMetadata
            var requestInstanceRequirementsWithMetadataIsNull = true;
            request.InstanceRequirementsWithMetadata = new Amazon.EC2.Model.InstanceRequirementsWithMetadataRequest();
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_ArchitectureType = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_ArchitectureType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_ArchitectureType = cmdletContext.InstanceRequirementsWithMetadata_ArchitectureType;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_ArchitectureType != null)
            {
                request.InstanceRequirementsWithMetadata.ArchitectureTypes = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_ArchitectureType;
                requestInstanceRequirementsWithMetadataIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_VirtualizationType = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_VirtualizationType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_VirtualizationType = cmdletContext.InstanceRequirementsWithMetadata_VirtualizationType;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_VirtualizationType != null)
            {
                request.InstanceRequirementsWithMetadata.VirtualizationTypes = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_VirtualizationType;
                requestInstanceRequirementsWithMetadataIsNull = false;
            }
            Amazon.EC2.Model.InstanceRequirementsRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements = null;
            
             // populate InstanceRequirements
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements = new Amazon.EC2.Model.InstanceRequirementsRequest();
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.AcceleratorManufacturers = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.AcceleratorNames = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.AcceleratorTypes = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.AllowedInstanceTypes = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.BareMetal requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BareMetal = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BareMetal != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BareMetal = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BareMetal;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BareMetal != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.BareMetal = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BareMetal;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.BurstablePerformance requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.BurstablePerformance = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.CpuManufacturers = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.ExcludedInstanceTypes = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.InstanceGenerations = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.LocalStorage requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_LocalStorage = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorage != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_LocalStorage = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorage;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_LocalStorage != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.LocalStorage = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_LocalStorage;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.LocalStorageTypes = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.OnDemandMaxPricePercentageOverLowestPrice = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            System.Boolean? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.RequireEncryptionInTransit = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            System.Boolean? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.RequireHibernateSupport = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.SpotMaxPricePercentageOverLowestPrice = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.BaselinePerformanceFactorsRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors = null;
            
             // populate BaselinePerformanceFactors
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactorsIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors = new Amazon.EC2.Model.BaselinePerformanceFactorsRequest();
            Amazon.EC2.Model.CpuPerformanceFactorRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu = null;
            
             // populate Cpu
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_CpuIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu = new Amazon.EC2.Model.CpuPerformanceFactorRequest();
            List<Amazon.EC2.Model.PerformanceFactorReferenceRequest> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu.References = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_CpuIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_CpuIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors.Cpu = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactorsIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactorsIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.BaselinePerformanceFactors = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.AcceleratorCountRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount = null;
            
             // populate AcceleratorCount
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCountIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount = new Amazon.EC2.Model.AcceleratorCountRequest();
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCountIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCountIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCountIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.AcceleratorCount = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.AcceleratorTotalMemoryMiBRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB = null;
            
             // populate AcceleratorTotalMemoryMiB
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiBIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB = new Amazon.EC2.Model.AcceleratorTotalMemoryMiBRequest();
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiBIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiBIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiBIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.AcceleratorTotalMemoryMiB = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.BaselineEbsBandwidthMbpsRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps = null;
            
             // populate BaselineEbsBandwidthMbps
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbpsIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps = new Amazon.EC2.Model.BaselineEbsBandwidthMbpsRequest();
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbpsIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbpsIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbpsIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.BaselineEbsBandwidthMbps = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.MemoryGiBPerVCpuRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu = null;
            
             // populate MemoryGiBPerVCpu
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpuIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu = new Amazon.EC2.Model.MemoryGiBPerVCpuRequest();
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpuIsNull = false;
            }
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpuIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpuIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.MemoryGiBPerVCpu = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.MemoryMiBRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB = null;
            
             // populate MemoryMiB
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiBIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB = new Amazon.EC2.Model.MemoryMiBRequest();
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiBIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiBIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiBIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.MemoryMiB = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.NetworkBandwidthGbpsRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps = null;
            
             // populate NetworkBandwidthGbps
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbpsIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps = new Amazon.EC2.Model.NetworkBandwidthGbpsRequest();
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbpsIsNull = false;
            }
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbpsIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbpsIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.NetworkBandwidthGbps = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.NetworkInterfaceCountRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount = null;
            
             // populate NetworkInterfaceCount
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCountIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount = new Amazon.EC2.Model.NetworkInterfaceCountRequest();
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCountIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCountIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCountIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.NetworkInterfaceCount = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.TotalLocalStorageGBRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB = null;
            
             // populate TotalLocalStorageGB
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGBIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB = new Amazon.EC2.Model.TotalLocalStorageGBRequest();
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGBIsNull = false;
            }
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGBIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGBIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.TotalLocalStorageGB = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.VCpuCountRangeRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount = null;
            
             // populate VCpuCount
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCountIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount = new Amazon.EC2.Model.VCpuCountRangeRequest();
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCountIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min = null;
            if (cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min = cmdletContext.InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCountIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCountIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.VCpuCount = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
             // determine if requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements should be set to null
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements = null;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements != null)
            {
                request.InstanceRequirementsWithMetadata.InstanceRequirements = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements;
                requestInstanceRequirementsWithMetadataIsNull = false;
            }
             // determine if request.InstanceRequirementsWithMetadata should be set to null
            if (requestInstanceRequirementsWithMetadataIsNull)
            {
                request.InstanceRequirementsWithMetadata = null;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceTypes = cmdletContext.InstanceType;
            }
            if (cmdletContext.MarketType != null)
            {
                request.MarketType = cmdletContext.MarketType;
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
        
        private Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetCapacityManagerSupportabilityScores");
            try
            {
                return client.GetCapacityManagerSupportabilityScoresAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? CapacityAmount { get; set; }
            public List<System.String> CapacityAvailabilityZoneId { get; set; }
            public Amazon.EC2.CapacityUnit CapacityUnit { get; set; }
            public System.Boolean? DryRun { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_ArchitectureType { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturer { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorName { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorType { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_InstanceRequirements_AllowedInstanceType { get; set; }
            public Amazon.EC2.BareMetal InstanceRequirementsWithMetadata_InstanceRequirements_BareMetal { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min { get; set; }
            public List<Amazon.EC2.Model.PerformanceFactorReferenceRequest> InstanceRequirementsWithMetadata_InstanceRequirements_BaselinePerformanceFactors_Cpu_Reference { get; set; }
            public Amazon.EC2.BurstablePerformance InstanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturer { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceType { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGeneration { get; set; }
            public Amazon.EC2.LocalStorage InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorage { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageType { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice { get; set; }
            public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max { get; set; }
            public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min { get; set; }
            public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Max { get; set; }
            public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_NetworkBandwidthGbps_Min { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice { get; set; }
            public System.Boolean? InstanceRequirementsWithMetadata_InstanceRequirements_RequireEncryptionInTransit { get; set; }
            public System.Boolean? InstanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice { get; set; }
            public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max { get; set; }
            public System.Double? InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max { get; set; }
            public System.Int32? InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_VirtualizationType { get; set; }
            public List<System.String> InstanceType { get; set; }
            public Amazon.EC2.SupportabilityMarketType MarketType { get; set; }
            public System.Func<Amazon.EC2.Model.GetCapacityManagerSupportabilityScoresResponse, GetEC2CapacityManagerSupportabilityScoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
