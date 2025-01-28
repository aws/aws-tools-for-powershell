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
    /// Returns a list of instance types with the specified instance attributes. You can use
    /// the response to preview the instance types without launching instances. Note that
    /// the response does not consider capacity.
    /// 
    ///  
    /// <para>
    /// When you specify multiple parameters, you get instance types that satisfy all of the
    /// specified parameters. If you specify multiple values for a parameter, you get instance
    /// types that satisfy any of the specified values.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-fleet-attribute-based-instance-type-selection.html#ec2fleet-get-instance-types-from-instance-requirements">Preview
    /// instance types with specified attributes</a>, <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-fleet-attribute-based-instance-type-selection.html">Specify
    /// attributes for instance type selection for EC2 Fleet or Spot Fleet</a>, and <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-placement-score.html">Spot
    /// placement score</a> in the <i>Amazon EC2 User Guide</i>, and <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/create-asg-instance-type-requirements.html">Creating
    /// mixed instance groups using attribute-based instance type selection</a> in the <i>Amazon
    /// EC2 Auto Scaling User Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2InstanceTypesFromInstanceRequirement")]
    [OutputType("Amazon.EC2.Model.InstanceTypeInfoFromInstanceRequirements")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) GetInstanceTypesFromInstanceRequirements API operation.", Operation = new[] {"GetInstanceTypesFromInstanceRequirements"}, SelectReturnType = typeof(Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceTypeInfoFromInstanceRequirements or Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.InstanceTypeInfoFromInstanceRequirements objects.",
        "The service call response (type Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2InstanceTypesFromInstanceRequirementCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceRequirements_AcceleratorManufacturer
        /// <summary>
        /// <para>
        /// <para>Indicates whether instance types must have accelerators by specific manufacturers.</para><ul><li><para>For instance types with Amazon Web Services devices, specify <c>amazon-web-services</c>.</para></li><li><para>For instance types with AMD devices, specify <c>amd</c>.</para></li><li><para>For instance types with Habana devices, specify <c>habana</c>.</para></li><li><para>For instance types with NVIDIA devices, specify <c>nvidia</c>.</para></li><li><para>For instance types with Xilinx devices, specify <c>xilinx</c>.</para></li></ul><para>Default: Any manufacturer</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AcceleratorManufacturers")]
        public System.String[] InstanceRequirements_AcceleratorManufacturer { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorName
        /// <summary>
        /// <para>
        /// <para>The accelerators that must be on the instance type.</para><ul><li><para>For instance types with NVIDIA A10G GPUs, specify <c>a10g</c>.</para></li><li><para>For instance types with NVIDIA A100 GPUs, specify <c>a100</c>.</para></li><li><para>For instance types with NVIDIA H100 GPUs, specify <c>h100</c>.</para></li><li><para>For instance types with Amazon Web Services Inferentia chips, specify <c>inferentia</c>.</para></li><li><para>For instance types with NVIDIA GRID K520 GPUs, specify <c>k520</c>.</para></li><li><para>For instance types with NVIDIA K80 GPUs, specify <c>k80</c>.</para></li><li><para>For instance types with NVIDIA M60 GPUs, specify <c>m60</c>.</para></li><li><para>For instance types with AMD Radeon Pro V520 GPUs, specify <c>radeon-pro-v520</c>.</para></li><li><para>For instance types with NVIDIA T4 GPUs, specify <c>t4</c>.</para></li><li><para>For instance types with NVIDIA T4G GPUs, specify <c>t4g</c>.</para></li><li><para>For instance types with Xilinx VU9P FPGAs, specify <c>vu9p</c>.</para></li><li><para>For instance types with NVIDIA V100 GPUs, specify <c>v100</c>.</para></li></ul><para>Default: Any accelerator</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AcceleratorNames")]
        public System.String[] InstanceRequirements_AcceleratorName { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorType
        /// <summary>
        /// <para>
        /// <para>The accelerator types that must be on the instance type.</para><ul><li><para>For instance types with FPGA accelerators, specify <c>fpga</c>.</para></li><li><para>For instance types with GPU accelerators, specify <c>gpu</c>.</para></li><li><para>For instance types with Inference accelerators, specify <c>inference</c>.</para></li></ul><para>Default: Any accelerator type</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AcceleratorTypes")]
        public System.String[] InstanceRequirements_AcceleratorType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AllowedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types to apply your specified attributes against. All other instance
        /// types are ignored, even if they match your specified attributes.</para><para>You can use strings with one or more wild cards, represented by an asterisk (<c>*</c>),
        /// to allow an instance type, size, or generation. The following are examples: <c>m5.8xlarge</c>,
        /// <c>c5*.*</c>, <c>m5a.*</c>, <c>r*</c>, <c>*3*</c>.</para><para>For example, if you specify <c>c5*</c>,Amazon EC2 will allow the entire C5 instance
        /// family, which includes all C5a and C5n instance types. If you specify <c>m5a.*</c>,
        /// Amazon EC2 will allow all the M5a instance types, but not the M5n instance types.</para><note><para>If you specify <c>AllowedInstanceTypes</c>, you can't specify <c>ExcludedInstanceTypes</c>.</para></note><para>Default: All instance types</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AllowedInstanceTypes")]
        public System.String[] InstanceRequirements_AllowedInstanceType { get; set; }
        #endregion
        
        #region Parameter ArchitectureType
        /// <summary>
        /// <para>
        /// <para>The processor architecture type.</para>
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
        [Alias("ArchitectureTypes")]
        public System.String[] ArchitectureType { get; set; }
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
        /// specify in your launch template.</para></note><para>Default: Any manufacturer</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_CpuManufacturers")]
        public System.String[] InstanceRequirements_CpuManufacturer { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_ExcludedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types to exclude.</para><para>You can use strings with one or more wild cards, represented by an asterisk (<c>*</c>),
        /// to exclude an instance family, type, size, or generation. The following are examples:
        /// <c>m5.8xlarge</c>, <c>c5*.*</c>, <c>m5a.*</c>, <c>r*</c>, <c>*3*</c>.</para><para>For example, if you specify <c>c5*</c>,Amazon EC2 will exclude the entire C5 instance
        /// family, which includes all C5a and C5n instance types. If you specify <c>m5a.*</c>,
        /// Amazon EC2 will exclude all the M5a instance types, but not the M5n instance types.</para><note><para>If you specify <c>ExcludedInstanceTypes</c>, you can't specify <c>AllowedInstanceTypes</c>.</para></note><para>Default: No excluded instance types</para>
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
        /// types</a> in the <i>Amazon EC2 User Guide</i>.</para><para>For current generation instance types, specify <c>current</c>.</para><para>For previous generation instance types, specify <c>previous</c>.</para><para>Default: Current and previous generation instance types</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_InstanceGenerations")]
        public System.String[] InstanceRequirements_InstanceGeneration { get; set; }
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
        /// <para>The type of local storage that is required.</para><ul><li><para>For instance types with hard disk drive (HDD) storage, specify <c>hdd</c>.</para></li><li><para>For instance types with solid state drive (SSD) storage, specify <c>ssd</c>.</para></li></ul><para>Default: <c>hdd</c> and <c>ssd</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_LocalStorageTypes")]
        public System.String[] InstanceRequirements_LocalStorageType { get; set; }
        #endregion
        
        #region Parameter AcceleratorCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of accelerators. To specify no maximum limit, omit this parameter.
        /// To exclude accelerator-enabled instance types, set <c>Max</c> to <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AcceleratorCount_Max")]
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
        [Alias("InstanceRequirements_AcceleratorTotalMemoryMiB_Max")]
        public System.Int32? AcceleratorTotalMemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter BaselineEbsBandwidthMbps_Max
        /// <summary>
        /// <para>
        /// <para>The maximum baseline bandwidth, in Mbps. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_BaselineEbsBandwidthMbps_Max")]
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
        [Alias("InstanceRequirements_MemoryGiBPerVCpu_Max")]
        public System.Double? MemoryGiBPerVCpu_Max { get; set; }
        #endregion
        
        #region Parameter MemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory, in MiB. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_MemoryMiB_Max")]
        public System.Int32? MemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter NetworkBandwidthGbps_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of network bandwidth, in Gbps. To specify no maximum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_NetworkBandwidthGbps_Max")]
        public System.Double? NetworkBandwidthGbps_Max { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of network interfaces. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_NetworkInterfaceCount_Max")]
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
        [Alias("InstanceRequirements_TotalLocalStorageGB_Max")]
        public System.Double? TotalLocalStorageGB_Max { get; set; }
        #endregion
        
        #region Parameter VCpuCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs. To specify no maximum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_VCpuCount_Max")]
        public System.Int32? VCpuCount_Max { get; set; }
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
        
        #region Parameter AcceleratorCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of accelerators. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_AcceleratorCount_Min")]
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
        [Alias("InstanceRequirements_AcceleratorTotalMemoryMiB_Min")]
        public System.Int32? AcceleratorTotalMemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter BaselineEbsBandwidthMbps_Min
        /// <summary>
        /// <para>
        /// <para>The minimum baseline bandwidth, in Mbps. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_BaselineEbsBandwidthMbps_Min")]
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
        [Alias("InstanceRequirements_MemoryGiBPerVCpu_Min")]
        public System.Double? MemoryGiBPerVCpu_Min { get; set; }
        #endregion
        
        #region Parameter MemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory, in MiB. To specify no minimum limit, specify <c>0</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InstanceRequirements_MemoryMiB_Min")]
        public System.Int32? MemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter NetworkBandwidthGbps_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of network bandwidth, in Gbps. To specify no minimum limit, omit
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_NetworkBandwidthGbps_Min")]
        public System.Double? NetworkBandwidthGbps_Min { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of network interfaces. To specify no minimum limit, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_NetworkInterfaceCount_Min")]
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
        [Alias("InstanceRequirements_TotalLocalStorageGB_Min")]
        public System.Double? TotalLocalStorageGB_Min { get; set; }
        #endregion
        
        #region Parameter VCpuCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of vCPUs. To specify no minimum limit, specify <c>0</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InstanceRequirements_VCpuCount_Min")]
        public System.Int32? VCpuCount_Min { get; set; }
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
        
        #region Parameter Cpu_Reference
        /// <summary>
        /// <para>
        /// <para>Specify an instance family to use as the baseline reference for CPU performance. All
        /// instance types that match your specified attributes will be compared against the CPU
        /// performance of the referenced instance family, regardless of CPU manufacturer or architecture
        /// differences.</para><note><para>Currently, only one instance family can be specified in the list.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceRequirements_BaselinePerformanceFactors_Cpu_References")]
        public Amazon.EC2.Model.PerformanceFactorReferenceRequest[] Cpu_Reference { get; set; }
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
        
        #region Parameter VirtualizationType
        /// <summary>
        /// <para>
        /// <para>The virtualization type.</para>
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
        [Alias("VirtualizationTypes")]
        public System.String[] VirtualizationType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Query-Requests.html#api-pagination">Pagination</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned from a previous paginated request. Pagination continues from the
        /// end of the items returned by the previous request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceTypes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceTypes";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsResponse, GetEC2InstanceTypesFromInstanceRequirementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ArchitectureType != null)
            {
                context.ArchitectureType = new List<System.String>(this.ArchitectureType);
            }
            #if MODULAR
            if (this.ArchitectureType == null && ParameterWasBound(nameof(this.ArchitectureType)))
            {
                WriteWarning("You are passing $null as a value for parameter ArchitectureType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.InstanceRequirements_AllowedInstanceType != null)
            {
                context.InstanceRequirements_AllowedInstanceType = new List<System.String>(this.InstanceRequirements_AllowedInstanceType);
            }
            context.InstanceRequirements_BareMetal = this.InstanceRequirements_BareMetal;
            context.BaselineEbsBandwidthMbps_Max = this.BaselineEbsBandwidthMbps_Max;
            context.BaselineEbsBandwidthMbps_Min = this.BaselineEbsBandwidthMbps_Min;
            if (this.Cpu_Reference != null)
            {
                context.Cpu_Reference = new List<Amazon.EC2.Model.PerformanceFactorReferenceRequest>(this.Cpu_Reference);
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
            context.MemoryGiBPerVCpu_Max = this.MemoryGiBPerVCpu_Max;
            context.MemoryGiBPerVCpu_Min = this.MemoryGiBPerVCpu_Min;
            context.MemoryMiB_Max = this.MemoryMiB_Max;
            context.MemoryMiB_Min = this.MemoryMiB_Min;
            #if MODULAR
            if (this.MemoryMiB_Min == null && ParameterWasBound(nameof(this.MemoryMiB_Min)))
            {
                WriteWarning("You are passing $null as a value for parameter MemoryMiB_Min which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkBandwidthGbps_Max = this.NetworkBandwidthGbps_Max;
            context.NetworkBandwidthGbps_Min = this.NetworkBandwidthGbps_Min;
            context.NetworkInterfaceCount_Max = this.NetworkInterfaceCount_Max;
            context.NetworkInterfaceCount_Min = this.NetworkInterfaceCount_Min;
            context.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = this.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice;
            context.InstanceRequirements_RequireHibernateSupport = this.InstanceRequirements_RequireHibernateSupport;
            context.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice = this.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice;
            context.TotalLocalStorageGB_Max = this.TotalLocalStorageGB_Max;
            context.TotalLocalStorageGB_Min = this.TotalLocalStorageGB_Min;
            context.VCpuCount_Max = this.VCpuCount_Max;
            context.VCpuCount_Min = this.VCpuCount_Min;
            #if MODULAR
            if (this.VCpuCount_Min == null && ParameterWasBound(nameof(this.VCpuCount_Min)))
            {
                WriteWarning("You are passing $null as a value for parameter VCpuCount_Min which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.VirtualizationType != null)
            {
                context.VirtualizationType = new List<System.String>(this.VirtualizationType);
            }
            #if MODULAR
            if (this.VirtualizationType == null && ParameterWasBound(nameof(this.VirtualizationType)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualizationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsRequest();
            
            if (cmdletContext.ArchitectureType != null)
            {
                request.ArchitectureTypes = cmdletContext.ArchitectureType;
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
            List<Amazon.EC2.Model.PerformanceFactorReferenceRequest> requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu_cpu_Reference = null;
            if (cmdletContext.Cpu_Reference != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu_cpu_Reference = cmdletContext.Cpu_Reference;
            }
            if (requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu_cpu_Reference != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu.References = requestInstanceRequirements_instanceRequirements_BaselinePerformanceFactors_instanceRequirements_BaselinePerformanceFactors_Cpu_cpu_Reference;
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
            System.Int32? requestInstanceRequirements_instanceRequirements_AcceleratorCount_acceleratorCount_Max = null;
            if (cmdletContext.AcceleratorCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorCount_acceleratorCount_Max = cmdletContext.AcceleratorCount_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorCount_acceleratorCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorCount.Max = requestInstanceRequirements_instanceRequirements_AcceleratorCount_acceleratorCount_Max.Value;
                requestInstanceRequirements_instanceRequirements_AcceleratorCountIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_AcceleratorCount_acceleratorCount_Min = null;
            if (cmdletContext.AcceleratorCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorCount_acceleratorCount_Min = cmdletContext.AcceleratorCount_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorCount_acceleratorCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorCount.Min = requestInstanceRequirements_instanceRequirements_AcceleratorCount_acceleratorCount_Min.Value;
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
            System.Int32? requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max = null;
            if (cmdletContext.AcceleratorTotalMemoryMiB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max = cmdletContext.AcceleratorTotalMemoryMiB_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB.Max = requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max.Value;
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiBIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min = null;
            if (cmdletContext.AcceleratorTotalMemoryMiB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min = cmdletContext.AcceleratorTotalMemoryMiB_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB.Min = requestInstanceRequirements_instanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min.Value;
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
            System.Int32? requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max = null;
            if (cmdletContext.BaselineEbsBandwidthMbps_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max = cmdletContext.BaselineEbsBandwidthMbps_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps.Max = requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max.Value;
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbpsIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min = null;
            if (cmdletContext.BaselineEbsBandwidthMbps_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min = cmdletContext.BaselineEbsBandwidthMbps_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps.Min = requestInstanceRequirements_instanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min.Value;
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
            System.Double? requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max = null;
            if (cmdletContext.MemoryGiBPerVCpu_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max = cmdletContext.MemoryGiBPerVCpu_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu.Max = requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max.Value;
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpuIsNull = false;
            }
            System.Double? requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min = null;
            if (cmdletContext.MemoryGiBPerVCpu_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min = cmdletContext.MemoryGiBPerVCpu_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu.Min = requestInstanceRequirements_instanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min.Value;
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
            System.Int32? requestInstanceRequirements_instanceRequirements_MemoryMiB_memoryMiB_Max = null;
            if (cmdletContext.MemoryMiB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryMiB_memoryMiB_Max = cmdletContext.MemoryMiB_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryMiB_memoryMiB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryMiB.Max = requestInstanceRequirements_instanceRequirements_MemoryMiB_memoryMiB_Max.Value;
                requestInstanceRequirements_instanceRequirements_MemoryMiBIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_MemoryMiB_memoryMiB_Min = null;
            if (cmdletContext.MemoryMiB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryMiB_memoryMiB_Min = cmdletContext.MemoryMiB_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_MemoryMiB_memoryMiB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_MemoryMiB.Min = requestInstanceRequirements_instanceRequirements_MemoryMiB_memoryMiB_Min.Value;
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
            System.Double? requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Max = null;
            if (cmdletContext.NetworkBandwidthGbps_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Max = cmdletContext.NetworkBandwidthGbps_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps.Max = requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Max.Value;
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbpsIsNull = false;
            }
            System.Double? requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Min = null;
            if (cmdletContext.NetworkBandwidthGbps_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Min = cmdletContext.NetworkBandwidthGbps_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps.Min = requestInstanceRequirements_instanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Min.Value;
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
            System.Int32? requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max = null;
            if (cmdletContext.NetworkInterfaceCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max = cmdletContext.NetworkInterfaceCount_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount.Max = requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max.Value;
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCountIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min = null;
            if (cmdletContext.NetworkInterfaceCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min = cmdletContext.NetworkInterfaceCount_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount.Min = requestInstanceRequirements_instanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min.Value;
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
            System.Double? requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max = null;
            if (cmdletContext.TotalLocalStorageGB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max = cmdletContext.TotalLocalStorageGB_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB.Max = requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max.Value;
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGBIsNull = false;
            }
            System.Double? requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min = null;
            if (cmdletContext.TotalLocalStorageGB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min = cmdletContext.TotalLocalStorageGB_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB.Min = requestInstanceRequirements_instanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min.Value;
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
            System.Int32? requestInstanceRequirements_instanceRequirements_VCpuCount_vCpuCount_Max = null;
            if (cmdletContext.VCpuCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_VCpuCount_vCpuCount_Max = cmdletContext.VCpuCount_Max.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_VCpuCount_vCpuCount_Max != null)
            {
                requestInstanceRequirements_instanceRequirements_VCpuCount.Max = requestInstanceRequirements_instanceRequirements_VCpuCount_vCpuCount_Max.Value;
                requestInstanceRequirements_instanceRequirements_VCpuCountIsNull = false;
            }
            System.Int32? requestInstanceRequirements_instanceRequirements_VCpuCount_vCpuCount_Min = null;
            if (cmdletContext.VCpuCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_VCpuCount_vCpuCount_Min = cmdletContext.VCpuCount_Min.Value;
            }
            if (requestInstanceRequirements_instanceRequirements_VCpuCount_vCpuCount_Min != null)
            {
                requestInstanceRequirements_instanceRequirements_VCpuCount.Min = requestInstanceRequirements_instanceRequirements_VCpuCount_vCpuCount_Min.Value;
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
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.VirtualizationType != null)
            {
                request.VirtualizationTypes = cmdletContext.VirtualizationType;
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
        
        private Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "GetInstanceTypesFromInstanceRequirements");
            try
            {
                #if DESKTOP
                return client.GetInstanceTypesFromInstanceRequirements(request);
                #elif CORECLR
                return client.GetInstanceTypesFromInstanceRequirementsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ArchitectureType { get; set; }
            public System.Int32? AcceleratorCount_Max { get; set; }
            public System.Int32? AcceleratorCount_Min { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorManufacturer { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorName { get; set; }
            public System.Int32? AcceleratorTotalMemoryMiB_Max { get; set; }
            public System.Int32? AcceleratorTotalMemoryMiB_Min { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorType { get; set; }
            public List<System.String> InstanceRequirements_AllowedInstanceType { get; set; }
            public Amazon.EC2.BareMetal InstanceRequirements_BareMetal { get; set; }
            public System.Int32? BaselineEbsBandwidthMbps_Max { get; set; }
            public System.Int32? BaselineEbsBandwidthMbps_Min { get; set; }
            public List<Amazon.EC2.Model.PerformanceFactorReferenceRequest> Cpu_Reference { get; set; }
            public Amazon.EC2.BurstablePerformance InstanceRequirements_BurstablePerformance { get; set; }
            public List<System.String> InstanceRequirements_CpuManufacturer { get; set; }
            public List<System.String> InstanceRequirements_ExcludedInstanceType { get; set; }
            public List<System.String> InstanceRequirements_InstanceGeneration { get; set; }
            public Amazon.EC2.LocalStorage InstanceRequirements_LocalStorage { get; set; }
            public List<System.String> InstanceRequirements_LocalStorageType { get; set; }
            public System.Int32? InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice { get; set; }
            public System.Double? MemoryGiBPerVCpu_Max { get; set; }
            public System.Double? MemoryGiBPerVCpu_Min { get; set; }
            public System.Int32? MemoryMiB_Max { get; set; }
            public System.Int32? MemoryMiB_Min { get; set; }
            public System.Double? NetworkBandwidthGbps_Max { get; set; }
            public System.Double? NetworkBandwidthGbps_Min { get; set; }
            public System.Int32? NetworkInterfaceCount_Max { get; set; }
            public System.Int32? NetworkInterfaceCount_Min { get; set; }
            public System.Int32? InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice { get; set; }
            public System.Boolean? InstanceRequirements_RequireHibernateSupport { get; set; }
            public System.Int32? InstanceRequirements_SpotMaxPricePercentageOverLowestPrice { get; set; }
            public System.Double? TotalLocalStorageGB_Max { get; set; }
            public System.Double? TotalLocalStorageGB_Min { get; set; }
            public System.Int32? VCpuCount_Max { get; set; }
            public System.Int32? VCpuCount_Min { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> VirtualizationType { get; set; }
            public System.Func<Amazon.EC2.Model.GetInstanceTypesFromInstanceRequirementsResponse, GetEC2InstanceTypesFromInstanceRequirementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceTypes;
        }
        
    }
}
