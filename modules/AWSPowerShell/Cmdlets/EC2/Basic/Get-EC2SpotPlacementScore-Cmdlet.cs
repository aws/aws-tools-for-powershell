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
    /// Calculates the Spot placement score for a Region or Availability Zone based on the
    /// specified target capacity and compute requirements.
    /// 
    ///  
    /// <para>
    /// You can specify your compute requirements either by using <code>InstanceRequirementsWithMetadata</code>
    /// and letting Amazon EC2 choose the optimal instance types to fulfill your Spot request,
    /// or you can specify the instance types by using <code>InstanceTypes</code>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-placement-score.html">Spot
    /// placement score</a> in the Amazon EC2 User Guide.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2SpotPlacementScore")]
    [OutputType("Amazon.EC2.Model.SpotPlacementScore")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetSpotPlacementScores API operation.", Operation = new[] {"GetSpotPlacementScores"}, SelectReturnType = typeof(Amazon.EC2.Model.GetSpotPlacementScoresResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.SpotPlacementScore or Amazon.EC2.Model.GetSpotPlacementScoresResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.SpotPlacementScore objects.",
        "The service call response (type Amazon.EC2.Model.GetSpotPlacementScoresResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2SpotPlacementScoreCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter InstanceRequirements_AcceleratorManufacturer
        /// <summary>
        /// <para>
        /// <para>Indicates whether instance types must have accelerators by specific manufacturers.</para><ul><li><para>For instance types with NVIDIA devices, specify <code>nvidia</code>.</para></li><li><para>For instance types with AMD devices, specify <code>amd</code>.</para></li><li><para>For instance types with Amazon Web Services devices, specify <code>amazon-web-services</code>.</para></li><li><para>For instance types with Xilinx devices, specify <code>xilinx</code>.</para></li></ul><para>Default: Any manufacturer</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorManufacturers")]
        public System.String[] InstanceRequirements_AcceleratorManufacturer { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorName
        /// <summary>
        /// <para>
        /// <para>The accelerators that must be on the instance type.</para><ul><li><para>For instance types with NVIDIA A100 GPUs, specify <code>a100</code>.</para></li><li><para>For instance types with NVIDIA V100 GPUs, specify <code>v100</code>.</para></li><li><para>For instance types with NVIDIA K80 GPUs, specify <code>k80</code>.</para></li><li><para>For instance types with NVIDIA T4 GPUs, specify <code>t4</code>.</para></li><li><para>For instance types with NVIDIA M60 GPUs, specify <code>m60</code>.</para></li><li><para>For instance types with AMD Radeon Pro V520 GPUs, specify <code>radeon-pro-v520</code>.</para></li><li><para>For instance types with Xilinx VU9P FPGAs, specify <code> vu9p</code>.</para></li><li><para>For instance types with Amazon Web Services Inferentia GPUs, specify <code>inferentia</code>.</para></li><li><para>For instance types with NVIDIA GRID K520 GPUs, specify <code>k520</code>.</para></li></ul><para>Default: Any accelerator</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorNames")]
        public System.String[] InstanceRequirements_AcceleratorName { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorType
        /// <summary>
        /// <para>
        /// <para>The accelerator types that must be on the instance type.</para><ul><li><para>To include instance types with GPU hardware, specify <code>gpu</code>.</para></li><li><para>To include instance types with FPGA hardware, specify <code>fpga</code>.</para></li><li><para>To include instance types with inference hardware, specify <code>inference</code>.</para></li></ul><para>Default: Any accelerator type</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTypes")]
        public System.String[] InstanceRequirements_AcceleratorType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_ArchitectureType
        /// <summary>
        /// <para>
        /// <para>The architecture type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_ArchitectureTypes")]
        public System.String[] InstanceRequirementsWithMetadata_ArchitectureType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_BareMetal
        /// <summary>
        /// <para>
        /// <para>Indicates whether bare metal instance types must be included, excluded, or required.</para><ul><li><para>To include bare metal instance types, specify <code>included</code>.</para></li><li><para>To require only bare metal instance types, specify <code>required</code>.</para></li><li><para>To exclude bare metal instance types, specify <code>excluded</code>.</para></li></ul><para>Default: <code>excluded</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_BareMetal")]
        [AWSConstantClassSource("Amazon.EC2.BareMetal")]
        public Amazon.EC2.BareMetal InstanceRequirements_BareMetal { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_BurstablePerformance
        /// <summary>
        /// <para>
        /// <para>Indicates whether burstable performance T instance types are included, excluded, or
        /// required. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/burstable-performance-instances.html">Burstable
        /// performance instances</a>.</para><ul><li><para>To include burstable performance instance types, specify <code>included</code>.</para></li><li><para>To require only burstable performance instance types, specify <code>required</code>.</para></li><li><para>To exclude burstable performance instance types, specify <code>excluded</code>.</para></li></ul><para>Default: <code>excluded</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_BurstablePerformance")]
        [AWSConstantClassSource("Amazon.EC2.BurstablePerformance")]
        public Amazon.EC2.BurstablePerformance InstanceRequirements_BurstablePerformance { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_CpuManufacturer
        /// <summary>
        /// <para>
        /// <para>The CPU manufacturers to include.</para><ul><li><para>For instance types with Intel CPUs, specify <code>intel</code>.</para></li><li><para>For instance types with AMD CPUs, specify <code>amd</code>.</para></li><li><para>For instance types with Amazon Web Services CPUs, specify <code>amazon-web-services</code>.</para></li></ul><note><para>Don't confuse the CPU manufacturer with the CPU architecture. Instances will be launched
        /// with a compatible CPU architecture based on the Amazon Machine Image (AMI) that you
        /// specify in your launch template.</para></note><para>Default: Any manufacturer</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_CpuManufacturers")]
        public System.String[] InstanceRequirements_CpuManufacturer { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_ExcludedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types to exclude.</para><para>You can use strings with one or more wild cards, represented by an asterisk (<code>*</code>),
        /// to exclude an instance family, type, size, or generation. The following are examples:
        /// <code>m5.8xlarge</code>, <code>c5*.*</code>, <code>m5a.*</code>, <code>r*</code>,
        /// <code>*3*</code>.</para><para>For example, if you specify <code>c5*</code>,Amazon EC2 will exclude the entire C5
        /// instance family, which includes all C5a and C5n instance types. If you specify <code>m5a.*</code>,
        /// Amazon EC2 will exclude all the M5a instance types, but not the M5n instance types.</para><para>Default: No excluded instance types</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_ExcludedInstanceTypes")]
        public System.String[] InstanceRequirements_ExcludedInstanceType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_InstanceGeneration
        /// <summary>
        /// <para>
        /// <para>Indicates whether current or previous generation instance types are included. The
        /// current generation instance types are recommended for use. Current generation instance
        /// types are typically the latest two to three generations in each instance family. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// types</a> in the <i>Amazon EC2 User Guide</i>.</para><para>For current generation instance types, specify <code>current</code>.</para><para>For previous generation instance types, specify <code>previous</code>.</para><para>Default: Current and previous generation instance types</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_InstanceGenerations")]
        public System.String[] InstanceRequirements_InstanceGeneration { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types. We recommend that you specify at least three instance types. If
        /// you specify one or two instance types, or specify variations of a single instance
        /// type (for example, an <code>m3.xlarge</code> with and without instance storage), the
        /// returned placement score will always be low. </para><para>If you specify <code>InstanceTypes</code>, you can't specify <code>InstanceRequirementsWithMetadata</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypes")]
        public System.String[] InstanceType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_LocalStorage
        /// <summary>
        /// <para>
        /// <para>Indicates whether instance types with instance store volumes are included, excluded,
        /// or required. For more information, <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/InstanceStorage.html">Amazon
        /// EC2 instance store</a> in the <i>Amazon EC2 User Guide</i>.</para><ul><li><para>To include instance types with instance store volumes, specify <code>included</code>.</para></li><li><para>To require only instance types with instance store volumes, specify <code>required</code>.</para></li><li><para>To exclude instance types with instance store volumes, specify <code>excluded</code>.</para></li></ul><para>Default: <code>included</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorage")]
        [AWSConstantClassSource("Amazon.EC2.LocalStorage")]
        public Amazon.EC2.LocalStorage InstanceRequirements_LocalStorage { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_LocalStorageType
        /// <summary>
        /// <para>
        /// <para>The type of local storage that is required.</para><ul><li><para>For instance types with hard disk drive (HDD) storage, specify <code>hdd</code>.</para></li><li><para>For instance types with solid state drive (SSD) storage, specify <code>ssd</code>.</para></li></ul><para>Default: <code>hdd</code> and <code>ssd</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_LocalStorageTypes")]
        public System.String[] InstanceRequirements_LocalStorageType { get; set; }
        #endregion
        
        #region Parameter AcceleratorCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of accelerators. To specify no maximum limit, omit this parameter.
        /// To exclude accelerator-enabled instance types, set <code>Max</code> to <code>0</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Max")]
        public System.Int32? AcceleratorCount_Max { get; set; }
        #endregion
        
        #region Parameter AcceleratorTotalMemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of accelerator memory, in MiB. To specify no maximum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Max")]
        public System.Int32? AcceleratorTotalMemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter BaselineEbsBandwidthMbps_Max
        /// <summary>
        /// <para>
        /// <para>The maximum baseline bandwidth, in Mbps. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Max")]
        public System.Int32? BaselineEbsBandwidthMbps_Max { get; set; }
        #endregion
        
        #region Parameter MemoryGiBPerVCpu_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory per vCPU, in GiB. To specify no maximum limit, omit this
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Max")]
        public System.Double? MemoryGiBPerVCpu_Max { get; set; }
        #endregion
        
        #region Parameter MemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory, in MiB. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Max")]
        public System.Int32? MemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of network interfaces. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Max")]
        public System.Int32? NetworkInterfaceCount_Max { get; set; }
        #endregion
        
        #region Parameter TotalLocalStorageGB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of total local storage, in GB. To specify no maximum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Max")]
        public System.Double? TotalLocalStorageGB_Max { get; set; }
        #endregion
        
        #region Parameter VCpuCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Max")]
        public System.Int32? VCpuCount_Max { get; set; }
        #endregion
        
        #region Parameter AcceleratorCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of accelerators. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_Min")]
        public System.Int32? AcceleratorCount_Min { get; set; }
        #endregion
        
        #region Parameter AcceleratorTotalMemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of accelerator memory, in MiB. To specify no minimum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_Min")]
        public System.Int32? AcceleratorTotalMemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter BaselineEbsBandwidthMbps_Min
        /// <summary>
        /// <para>
        /// <para>The minimum baseline bandwidth, in Mbps. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_Min")]
        public System.Int32? BaselineEbsBandwidthMbps_Min { get; set; }
        #endregion
        
        #region Parameter MemoryGiBPerVCpu_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory per vCPU, in GiB. To specify no minimum limit, omit this
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_Min")]
        public System.Double? MemoryGiBPerVCpu_Min { get; set; }
        #endregion
        
        #region Parameter MemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory, in MiB. To specify no minimum limit, specify <code>0</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_Min")]
        public System.Int32? MemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of network interfaces. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_Min")]
        public System.Int32? NetworkInterfaceCount_Min { get; set; }
        #endregion
        
        #region Parameter TotalLocalStorageGB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of total local storage, in GB. To specify no minimum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_Min")]
        public System.Double? TotalLocalStorageGB_Min { get; set; }
        #endregion
        
        #region Parameter VCpuCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of vCPUs. To specify no minimum limit, specify <code>0</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_Min")]
        public System.Int32? VCpuCount_Min { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice
        /// <summary>
        /// <para>
        /// <para>The price protection threshold for On-Demand Instances. This is the maximum you’ll
        /// pay for an On-Demand Instance, expressed as a percentage above the least expensive
        /// current generation M, C, or R instance type with your specified attributes. When Amazon
        /// EC2 selects instance types with your attributes, it excludes instance types priced
        /// above your threshold.</para><para>The parameter accepts an integer, which Amazon EC2 interprets as a percentage.</para><para>To turn off price protection, specify a high value, such as <code>999999</code>.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetSpotPlacementScores.html">GetSpotPlacementScores</a>
        /// and <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetInstanceTypesFromInstanceRequirements.html">GetInstanceTypesFromInstanceRequirements</a>.</para><note><para>If you set <code>TargetCapacityUnitType</code> to <code>vcpu</code> or <code>memory-mib</code>,
        /// the price protection threshold is applied based on the per-vCPU or per-memory price
        /// instead of the per-instance price.</para></note><para>Default: <code>20</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice")]
        public System.Int32? InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice { get; set; }
        #endregion
        
        #region Parameter RegionName
        /// <summary>
        /// <para>
        /// <para>The Regions used to narrow down the list of Regions to be scored. Enter the Region
        /// code, for example, <code>us-east-1</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RegionNames")]
        public System.String[] RegionName { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_RequireHibernateSupport
        /// <summary>
        /// <para>
        /// <para>Indicates whether instance types must support hibernation for On-Demand Instances.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetSpotPlacementScores.html">GetSpotPlacementScores</a>.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_RequireHibernateSupport")]
        public System.Boolean? InstanceRequirements_RequireHibernateSupport { get; set; }
        #endregion
        
        #region Parameter SingleAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Specify <code>true</code> so that the response returns a list of scored Availability
        /// Zones. Otherwise, the response returns a list of scored Regions.</para><para>A list of scored Availability Zones is useful if you want to launch all of your Spot
        /// capacity into a single Availability Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SingleAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_SpotMaxPricePercentageOverLowestPrice
        /// <summary>
        /// <para>
        /// <para>The price protection threshold for Spot Instance. This is the maximum you’ll pay for
        /// an Spot Instance, expressed as a percentage above the least expensive current generation
        /// M, C, or R instance type with your specified attributes. When Amazon EC2 selects instance
        /// types with your attributes, it excludes instance types priced above your threshold.</para><para>The parameter accepts an integer, which Amazon EC2 interprets as a percentage.</para><para>To turn off price protection, specify a high value, such as <code>999999</code>.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetSpotPlacementScores.html">GetSpotPlacementScores</a>
        /// and <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetInstanceTypesFromInstanceRequirements.html">GetInstanceTypesFromInstanceRequirements</a>.</para><note><para>If you set <code>TargetCapacityUnitType</code> to <code>vcpu</code> or <code>memory-mib</code>,
        /// the price protection threshold is applied based on the per-vCPU or per-memory price
        /// instead of the per-instance price.</para></note><para>Default: <code>100</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice")]
        public System.Int32? InstanceRequirements_SpotMaxPricePercentageOverLowestPrice { get; set; }
        #endregion
        
        #region Parameter TargetCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TargetCapacity { get; set; }
        #endregion
        
        #region Parameter TargetCapacityUnitType
        /// <summary>
        /// <para>
        /// <para>The unit for the target capacity.</para><para>Default: <code>units</code> (translates to number of instances)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TargetCapacityUnitType")]
        public Amazon.EC2.TargetCapacityUnitType TargetCapacityUnitType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirementsWithMetadata_VirtualizationType
        /// <summary>
        /// <para>
        /// <para>The virtualization type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirementsWithMetadata_VirtualizationTypes")]
        public System.String[] InstanceRequirementsWithMetadata_VirtualizationType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. Specify a value between
        /// 1 and  1000. The default value is 1000. To retrieve the remaining results,
        /// make another call with  the returned <code>NextToken</code> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SpotPlacementScores'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetSpotPlacementScoresResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetSpotPlacementScoresResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SpotPlacementScores";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetCapacity parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetCapacity' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetCapacity' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetSpotPlacementScoresResponse, GetEC2SpotPlacementScoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetCapacity;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.InstanceRequirementsWithMetadata_ArchitectureType != null)
            {
                context.InstanceRequirementsWithMetadata_ArchitectureType = new List<System.String>(this.InstanceRequirementsWithMetadata_ArchitectureType);
            }
            context.AcceleratorCount_Max = this.AcceleratorCount_Max;
            context.AcceleratorCount_Min = this.AcceleratorCount_Min;
            if (this.InstanceRequirements_AcceleratorManufacturer != null)
            {
                context.InstanceRequirements_AcceleratorManufacturer = new List<System.String>(this.InstanceRequirements_AcceleratorManufacturer);
            }
            if (this.InstanceRequirements_AcceleratorName != null)
            {
                context.InstanceRequirements_AcceleratorName = new List<System.String>(this.InstanceRequirements_AcceleratorName);
            }
            context.AcceleratorTotalMemoryMiB_Max = this.AcceleratorTotalMemoryMiB_Max;
            context.AcceleratorTotalMemoryMiB_Min = this.AcceleratorTotalMemoryMiB_Min;
            if (this.InstanceRequirements_AcceleratorType != null)
            {
                context.InstanceRequirements_AcceleratorType = new List<System.String>(this.InstanceRequirements_AcceleratorType);
            }
            context.InstanceRequirements_BareMetal = this.InstanceRequirements_BareMetal;
            context.BaselineEbsBandwidthMbps_Max = this.BaselineEbsBandwidthMbps_Max;
            context.BaselineEbsBandwidthMbps_Min = this.BaselineEbsBandwidthMbps_Min;
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
            context.MemoryGiBPerVCpu_Max = this.MemoryGiBPerVCpu_Max;
            context.MemoryGiBPerVCpu_Min = this.MemoryGiBPerVCpu_Min;
            context.MemoryMiB_Max = this.MemoryMiB_Max;
            context.MemoryMiB_Min = this.MemoryMiB_Min;
            context.NetworkInterfaceCount_Max = this.NetworkInterfaceCount_Max;
            context.NetworkInterfaceCount_Min = this.NetworkInterfaceCount_Min;
            context.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = this.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice;
            context.InstanceRequirements_RequireHibernateSupport = this.InstanceRequirements_RequireHibernateSupport;
            context.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice = this.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice;
            context.TotalLocalStorageGB_Max = this.TotalLocalStorageGB_Max;
            context.TotalLocalStorageGB_Min = this.TotalLocalStorageGB_Min;
            context.VCpuCount_Max = this.VCpuCount_Max;
            context.VCpuCount_Min = this.VCpuCount_Min;
            if (this.InstanceRequirementsWithMetadata_VirtualizationType != null)
            {
                context.InstanceRequirementsWithMetadata_VirtualizationType = new List<System.String>(this.InstanceRequirementsWithMetadata_VirtualizationType);
            }
            if (this.InstanceType != null)
            {
                context.InstanceType = new List<System.String>(this.InstanceType);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.RegionName != null)
            {
                context.RegionName = new List<System.String>(this.RegionName);
            }
            context.SingleAvailabilityZone = this.SingleAvailabilityZone;
            context.TargetCapacity = this.TargetCapacity;
            #if MODULAR
            if (this.TargetCapacity == null && ParameterWasBound(nameof(this.TargetCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetCapacityUnitType = this.TargetCapacityUnitType;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.GetSpotPlacementScoresRequest();
            
            
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
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorManufacturer = null;
            if (cmdletContext.InstanceRequirements_AcceleratorManufacturer != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorManufacturer = cmdletContext.InstanceRequirements_AcceleratorManufacturer;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorManufacturer != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.AcceleratorManufacturers = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorManufacturer;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorName = null;
            if (cmdletContext.InstanceRequirements_AcceleratorName != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorName = cmdletContext.InstanceRequirements_AcceleratorName;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorName != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.AcceleratorNames = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorName;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorType = null;
            if (cmdletContext.InstanceRequirements_AcceleratorType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorType = cmdletContext.InstanceRequirements_AcceleratorType;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.AcceleratorTypes = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_AcceleratorType;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.BareMetal requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_BareMetal = null;
            if (cmdletContext.InstanceRequirements_BareMetal != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_BareMetal = cmdletContext.InstanceRequirements_BareMetal;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_BareMetal != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.BareMetal = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_BareMetal;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.BurstablePerformance requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_BurstablePerformance = null;
            if (cmdletContext.InstanceRequirements_BurstablePerformance != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_BurstablePerformance = cmdletContext.InstanceRequirements_BurstablePerformance;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_BurstablePerformance != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.BurstablePerformance = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_BurstablePerformance;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_CpuManufacturer = null;
            if (cmdletContext.InstanceRequirements_CpuManufacturer != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_CpuManufacturer = cmdletContext.InstanceRequirements_CpuManufacturer;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_CpuManufacturer != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.CpuManufacturers = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_CpuManufacturer;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_ExcludedInstanceType = null;
            if (cmdletContext.InstanceRequirements_ExcludedInstanceType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_ExcludedInstanceType = cmdletContext.InstanceRequirements_ExcludedInstanceType;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_ExcludedInstanceType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.ExcludedInstanceTypes = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_ExcludedInstanceType;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_InstanceGeneration = null;
            if (cmdletContext.InstanceRequirements_InstanceGeneration != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_InstanceGeneration = cmdletContext.InstanceRequirements_InstanceGeneration;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_InstanceGeneration != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.InstanceGenerations = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_InstanceGeneration;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.LocalStorage requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_LocalStorage = null;
            if (cmdletContext.InstanceRequirements_LocalStorage != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_LocalStorage = cmdletContext.InstanceRequirements_LocalStorage;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_LocalStorage != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.LocalStorage = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_LocalStorage;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_LocalStorageType = null;
            if (cmdletContext.InstanceRequirements_LocalStorageType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_LocalStorageType = cmdletContext.InstanceRequirements_LocalStorageType;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_LocalStorageType != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.LocalStorageTypes = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_LocalStorageType;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = null;
            if (cmdletContext.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = cmdletContext.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.OnDemandMaxPricePercentageOverLowestPrice = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            System.Boolean? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_RequireHibernateSupport = null;
            if (cmdletContext.InstanceRequirements_RequireHibernateSupport != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_RequireHibernateSupport = cmdletContext.InstanceRequirements_RequireHibernateSupport.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_RequireHibernateSupport != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.RequireHibernateSupport = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_RequireHibernateSupport.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice = null;
            if (cmdletContext.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice = cmdletContext.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements.SpotMaxPricePercentageOverLowestPrice = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirementsIsNull = false;
            }
            Amazon.EC2.Model.AcceleratorCountRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount = null;
            
             // populate AcceleratorCount
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCountIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount = new Amazon.EC2.Model.AcceleratorCountRequest();
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_acceleratorCount_Max = null;
            if (cmdletContext.AcceleratorCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_acceleratorCount_Max = cmdletContext.AcceleratorCount_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_acceleratorCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_acceleratorCount_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCountIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_acceleratorCount_Min = null;
            if (cmdletContext.AcceleratorCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_acceleratorCount_Min = cmdletContext.AcceleratorCount_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_acceleratorCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorCount_acceleratorCount_Min.Value;
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
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max = null;
            if (cmdletContext.AcceleratorTotalMemoryMiB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max = cmdletContext.AcceleratorTotalMemoryMiB_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiBIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min = null;
            if (cmdletContext.AcceleratorTotalMemoryMiB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min = cmdletContext.AcceleratorTotalMemoryMiB_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min.Value;
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
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max = null;
            if (cmdletContext.BaselineEbsBandwidthMbps_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max = cmdletContext.BaselineEbsBandwidthMbps_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbpsIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min = null;
            if (cmdletContext.BaselineEbsBandwidthMbps_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min = cmdletContext.BaselineEbsBandwidthMbps_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min.Value;
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
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max = null;
            if (cmdletContext.MemoryGiBPerVCpu_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max = cmdletContext.MemoryGiBPerVCpu_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpuIsNull = false;
            }
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min = null;
            if (cmdletContext.MemoryGiBPerVCpu_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min = cmdletContext.MemoryGiBPerVCpu_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min.Value;
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
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_memoryMiB_Max = null;
            if (cmdletContext.MemoryMiB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_memoryMiB_Max = cmdletContext.MemoryMiB_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_memoryMiB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_memoryMiB_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiBIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_memoryMiB_Min = null;
            if (cmdletContext.MemoryMiB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_memoryMiB_Min = cmdletContext.MemoryMiB_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_memoryMiB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_MemoryMiB_memoryMiB_Min.Value;
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
            Amazon.EC2.Model.NetworkInterfaceCountRequest requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount = null;
            
             // populate NetworkInterfaceCount
            var requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCountIsNull = true;
            requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount = new Amazon.EC2.Model.NetworkInterfaceCountRequest();
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max = null;
            if (cmdletContext.NetworkInterfaceCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max = cmdletContext.NetworkInterfaceCount_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCountIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min = null;
            if (cmdletContext.NetworkInterfaceCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min = cmdletContext.NetworkInterfaceCount_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min.Value;
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
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max = null;
            if (cmdletContext.TotalLocalStorageGB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max = cmdletContext.TotalLocalStorageGB_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGBIsNull = false;
            }
            System.Double? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min = null;
            if (cmdletContext.TotalLocalStorageGB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min = cmdletContext.TotalLocalStorageGB_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min.Value;
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
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_vCpuCount_Max = null;
            if (cmdletContext.VCpuCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_vCpuCount_Max = cmdletContext.VCpuCount_Max.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_vCpuCount_Max != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount.Max = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_vCpuCount_Max.Value;
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCountIsNull = false;
            }
            System.Int32? requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_vCpuCount_Min = null;
            if (cmdletContext.VCpuCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_vCpuCount_Min = cmdletContext.VCpuCount_Min.Value;
            }
            if (requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_vCpuCount_Min != null)
            {
                requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount.Min = requestInstanceRequirementsWithMetadata_instanceRequirementsWithMetadata_InstanceRequirements_instanceRequirementsWithMetadata_InstanceRequirements_VCpuCount_vCpuCount_Min.Value;
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
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.RegionName != null)
            {
                request.RegionNames = cmdletContext.RegionName;
            }
            if (cmdletContext.SingleAvailabilityZone != null)
            {
                request.SingleAvailabilityZone = cmdletContext.SingleAvailabilityZone.Value;
            }
            if (cmdletContext.TargetCapacity != null)
            {
                request.TargetCapacity = cmdletContext.TargetCapacity.Value;
            }
            if (cmdletContext.TargetCapacityUnitType != null)
            {
                request.TargetCapacityUnitType = cmdletContext.TargetCapacityUnitType;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.GetSpotPlacementScoresResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetSpotPlacementScoresRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetSpotPlacementScores");
            try
            {
                #if DESKTOP
                return client.GetSpotPlacementScores(request);
                #elif CORECLR
                return client.GetSpotPlacementScoresAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> InstanceRequirementsWithMetadata_ArchitectureType { get; set; }
            public System.Int32? AcceleratorCount_Max { get; set; }
            public System.Int32? AcceleratorCount_Min { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorManufacturer { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorName { get; set; }
            public System.Int32? AcceleratorTotalMemoryMiB_Max { get; set; }
            public System.Int32? AcceleratorTotalMemoryMiB_Min { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorType { get; set; }
            public Amazon.EC2.BareMetal InstanceRequirements_BareMetal { get; set; }
            public System.Int32? BaselineEbsBandwidthMbps_Max { get; set; }
            public System.Int32? BaselineEbsBandwidthMbps_Min { get; set; }
            public Amazon.EC2.BurstablePerformance InstanceRequirements_BurstablePerformance { get; set; }
            public List<System.String> InstanceRequirements_CpuManufacturer { get; set; }
            public List<System.String> InstanceRequirements_ExcludedInstanceType { get; set; }
            public List<System.String> InstanceRequirements_InstanceGeneration { get; set; }
            public Amazon.EC2.LocalStorage InstanceRequirements_LocalStorage { get; set; }
            public List<System.String> InstanceRequirements_LocalStorageType { get; set; }
            public System.Double? MemoryGiBPerVCpu_Max { get; set; }
            public System.Double? MemoryGiBPerVCpu_Min { get; set; }
            public System.Int32? MemoryMiB_Max { get; set; }
            public System.Int32? MemoryMiB_Min { get; set; }
            public System.Int32? NetworkInterfaceCount_Max { get; set; }
            public System.Int32? NetworkInterfaceCount_Min { get; set; }
            public System.Int32? InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice { get; set; }
            public System.Boolean? InstanceRequirements_RequireHibernateSupport { get; set; }
            public System.Int32? InstanceRequirements_SpotMaxPricePercentageOverLowestPrice { get; set; }
            public System.Double? TotalLocalStorageGB_Max { get; set; }
            public System.Double? TotalLocalStorageGB_Min { get; set; }
            public System.Int32? VCpuCount_Max { get; set; }
            public System.Int32? VCpuCount_Min { get; set; }
            public List<System.String> InstanceRequirementsWithMetadata_VirtualizationType { get; set; }
            public List<System.String> InstanceType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> RegionName { get; set; }
            public System.Boolean? SingleAvailabilityZone { get; set; }
            public System.Int32? TargetCapacity { get; set; }
            public Amazon.EC2.TargetCapacityUnitType TargetCapacityUnitType { get; set; }
            public System.Func<Amazon.EC2.Model.GetSpotPlacementScoresResponse, GetEC2SpotPlacementScoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SpotPlacementScores;
        }
        
    }
}
