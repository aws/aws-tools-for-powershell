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
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Creates a capacity provider. Capacity providers are associated with a cluster and
    /// are used in capacity provider strategies to facilitate cluster auto scaling. You can
    /// create capacity providers for Amazon ECS Managed Instances and EC2 instances. Fargate
    /// has the predefined <c>FARGATE</c> and <c>FARGATE_SPOT</c> capacity providers.
    /// </summary>
    [Cmdlet("New", "ECSCapacityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.CapacityProvider")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service CreateCapacityProvider API operation.", Operation = new[] {"CreateCapacityProvider"}, SelectReturnType = typeof(Amazon.ECS.Model.CreateCapacityProviderResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.CapacityProvider or Amazon.ECS.Model.CreateCapacityProviderResponse",
        "This cmdlet returns an Amazon.ECS.Model.CapacityProvider object.",
        "The service call response (type Amazon.ECS.Model.CreateCapacityProviderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewECSCapacityProviderCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceRequirements_AcceleratorManufacturer
        /// <summary>
        /// <para>
        /// <para>The accelerator manufacturers to include. You can specify <c>nvidia</c>, <c>amd</c>,
        /// <c>amazon-web-services</c>, or <c>xilinx</c> depending on your accelerator requirements.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorManufacturers")]
        public System.String[] InstanceRequirements_AcceleratorManufacturer { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorName
        /// <summary>
        /// <para>
        /// <para>The specific accelerator names to include. For example, you can specify <c>a100</c>,
        /// <c>v100</c>, <c>k80</c>, or other specific accelerator models.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorNames")]
        public System.String[] InstanceRequirements_AcceleratorName { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AcceleratorType
        /// <summary>
        /// <para>
        /// <para>The accelerator types to include. You can specify <c>gpu</c> for graphics processing
        /// units, <c>fpga</c> for field programmable gate arrays, or <c>inference</c> for machine
        /// learning inference accelerators.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTypes")]
        public System.String[] InstanceRequirements_AcceleratorType { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_AllowedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types to include in the selection. When specified, Amazon ECS only considers
        /// these instance types, subject to the other requirements specified.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceTypes")]
        public System.String[] InstanceRequirements_AllowedInstanceType { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroupProvider_AutoScalingGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that identifies the Auto Scaling group, or the Auto
        /// Scaling group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoScalingGroupProvider_AutoScalingGroupArn { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_BareMetal
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include bare metal instance types. Set to <c>included</c> to
        /// allow bare metal instances, <c>excluded</c> to exclude them, or <c>required</c> to
        /// use only bare metal instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BareMetal")]
        [AWSConstantClassSource("Amazon.ECS.BareMetal")]
        public Amazon.ECS.BareMetal InstanceRequirements_BareMetal { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_BurstablePerformance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include burstable performance instance types (T2, T3, T3a, T4g).
        /// Set to <c>included</c> to allow burstable instances, <c>excluded</c> to exclude them,
        /// or <c>required</c> to use only burstable instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BurstablePerformance")]
        [AWSConstantClassSource("Amazon.ECS.BurstablePerformance")]
        public Amazon.ECS.BurstablePerformance InstanceRequirements_BurstablePerformance { get; set; }
        #endregion
        
        #region Parameter ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType
        /// <summary>
        /// <para>
        /// <para>The capacity option type. This determines whether Amazon ECS launches On-Demand or
        /// Spot Instances for your managed instance capacity provider.</para><para>Valid values are:</para><ul><li><para><c>ON_DEMAND</c> - Launches standard On-Demand Instances. On-Demand Instances provide
        /// predictable pricing and availability.</para></li><li><para><c>SPOT</c> - Launches Spot Instances that use spare Amazon EC2 capacity at reduced
        /// cost. Spot Instances can be interrupted by Amazon EC2 with a two-minute notification
        /// when the capacity is needed back.</para></li></ul><para>The default is On-Demand</para><para>For more information about Amazon EC2 capacity options, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-purchasing-options.html">Instance
        /// purchasing options</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.CapacityOptionType")]
        public Amazon.ECS.CapacityOptionType ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The name of the cluster to associate with the capacity provider. When you create a
        /// capacity provider with Amazon ECS Managed Instances, it becomes available only within
        /// the specified cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_CpuManufacturer
        /// <summary>
        /// <para>
        /// <para>The CPU manufacturers to include or exclude. You can specify <c>intel</c>, <c>amd</c>,
        /// or <c>amazon-web-services</c> to control which CPU types are used for your workloads.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_CpuManufacturers")]
        public System.String[] InstanceRequirements_CpuManufacturer { get; set; }
        #endregion
        
        #region Parameter InstanceLaunchTemplate_Ec2InstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the instance profile that Amazon ECS applies to
        /// Amazon ECS Managed Instances. This instance profile must include the necessary permissions
        /// for your tasks to access Amazon Web Services services and resources.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/managed-instances-instance-profile.html">Amazon
        /// ECS instance profile for Managed Instances</a> in the <i>Amazon ECS Developer Guide</i>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn")]
        public System.String InstanceLaunchTemplate_Ec2InstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_ExcludedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types to exclude from selection. Use this to prevent Amazon ECS from
        /// selecting specific instance types that may not be suitable for your workloads.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_ExcludedInstanceTypes")]
        public System.String[] InstanceRequirements_ExcludedInstanceType { get; set; }
        #endregion
        
        #region Parameter ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled
        /// <summary>
        /// <para>
        /// <para>Determines whether to enable FIPS 140-2 validated cryptographic modules on EC2 instances
        /// launched by the capacity provider. If <c>true</c>, instances use FIPS-compliant cryptographic
        /// algorithms and modules for enhanced security compliance. If <c>false</c>, instances
        /// use standard cryptographic implementations.</para><para>If not specified, instances are launched with FIPS enabled in AWS GovCloud (US) regions
        /// and FIPS disabled in other regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled { get; set; }
        #endregion
        
        #region Parameter ManagedInstancesProvider_InfrastructureRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the infrastructure role that Amazon ECS uses to
        /// manage instances on your behalf. This role must have permissions to launch, terminate,
        /// and manage Amazon EC2 instances, as well as access to other Amazon Web Services services
        /// required for Amazon ECS Managed Instances functionality.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/infrastructure_IAM_role.html">Amazon
        /// ECS infrastructure IAM role</a> in the <i>Amazon ECS Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedInstancesProvider_InfrastructureRoleArn { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_InstanceGeneration
        /// <summary>
        /// <para>
        /// <para>The instance generations to include. You can specify <c>current</c> to use the latest
        /// generation instances, or <c>previous</c> to include previous generation instances
        /// for cost optimization.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_InstanceGenerations")]
        public System.String[] InstanceRequirements_InstanceGeneration { get; set; }
        #endregion
        
        #region Parameter ManagedScaling_InstanceWarmupPeriod
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, after a newly launched Amazon EC2 instance can contribute
        /// to CloudWatch metrics for Auto Scaling group. If this parameter is omitted, the default
        /// value of <c>300</c> seconds is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_InstanceWarmupPeriod")]
        public System.Int32? ManagedScaling_InstanceWarmupPeriod { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_LocalStorage
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include instance types with local storage. Set to <c>included</c>
        /// to allow local storage, <c>excluded</c> to exclude it, or <c>required</c> to use only
        /// instances with local storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_LocalStorage")]
        [AWSConstantClassSource("Amazon.ECS.LocalStorage")]
        public Amazon.ECS.LocalStorage InstanceRequirements_LocalStorage { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_LocalStorageType
        /// <summary>
        /// <para>
        /// <para>The local storage types to include. You can specify <c>hdd</c> for hard disk drives,
        /// <c>ssd</c> for solid state drives, or both.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_LocalStorageTypes")]
        public System.String[] InstanceRequirements_LocalStorageType { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroupProvider_ManagedDraining
        /// <summary>
        /// <para>
        /// <para>The managed draining option for the Auto Scaling group capacity provider. When you
        /// enable this, Amazon ECS manages and gracefully drains the EC2 container instances
        /// that are in the Auto Scaling group capacity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.ManagedDraining")]
        public Amazon.ECS.ManagedDraining AutoScalingGroupProvider_ManagedDraining { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroupProvider_ManagedTerminationProtection
        /// <summary>
        /// <para>
        /// <para>The managed termination protection setting to use for the Auto Scaling group capacity
        /// provider. This determines whether the Auto Scaling group has managed termination protection.
        /// The default is off.</para><important><para>When using managed termination protection, managed scaling must also be used otherwise
        /// managed termination protection doesn't work.</para></important><para>When managed termination protection is on, Amazon ECS prevents the Amazon EC2 instances
        /// in an Auto Scaling group that contain tasks from being terminated during a scale-in
        /// action. The Auto Scaling group and each instance in the Auto Scaling group must have
        /// instance protection from scale-in actions on as well. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-instance-termination.html#instance-protection">Instance
        /// Protection</a> in the <i>Auto Scaling User Guide</i>.</para><para>When managed termination protection is off, your Amazon EC2 instances aren't protected
        /// from termination when the Auto Scaling group scales in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.ManagedTerminationProtection")]
        public Amazon.ECS.ManagedTerminationProtection AutoScalingGroupProvider_ManagedTerminationProtection { get; set; }
        #endregion
        
        #region Parameter AcceleratorCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of accelerators. Instance types with more accelerators are excluded
        /// from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_Max")]
        public System.Int32? AcceleratorCount_Max { get; set; }
        #endregion
        
        #region Parameter AcceleratorTotalMemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum total accelerator memory in MiB. Instance types with more accelerator
        /// memory are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_Max")]
        public System.Int32? AcceleratorTotalMemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter BaselineEbsBandwidthMbps_Max
        /// <summary>
        /// <para>
        /// <para>The maximum baseline Amazon EBS bandwidth in Mbps. Instance types with higher Amazon
        /// EBS bandwidth are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_Max")]
        public System.Int32? BaselineEbsBandwidthMbps_Max { get; set; }
        #endregion
        
        #region Parameter MemoryGiBPerVCpu_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory per vCPU in GiB. Instance types with a higher memory-to-vCPU
        /// ratio are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_Max")]
        public System.Double? MemoryGiBPerVCpu_Max { get; set; }
        #endregion
        
        #region Parameter MemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory in MiB. Instance types with more memory than this value
        /// are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_Max")]
        public System.Int32? MemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter NetworkBandwidthGbps_Max
        /// <summary>
        /// <para>
        /// <para>The maximum network bandwidth in Gbps. Instance types with higher network bandwidth
        /// are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_Max")]
        public System.Double? NetworkBandwidthGbps_Max { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of network interfaces. Instance types that support more network
        /// interfaces are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_Max")]
        public System.Int32? NetworkInterfaceCount_Max { get; set; }
        #endregion
        
        #region Parameter TotalLocalStorageGB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum total local storage in GB. Instance types with more local storage are
        /// excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_Max")]
        public System.Double? TotalLocalStorageGB_Max { get; set; }
        #endregion
        
        #region Parameter VCpuCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs. Instance types with more vCPUs than this value are excluded
        /// from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_Max")]
        public System.Int32? VCpuCount_Max { get; set; }
        #endregion
        
        #region Parameter ManagedScaling_MaximumScalingStepSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of Amazon EC2 instances that Amazon ECS will scale out at one time.
        /// If this parameter is omitted, the default value of <c>10000</c> is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_MaximumScalingStepSize")]
        public System.Int32? ManagedScaling_MaximumScalingStepSize { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice
        /// <summary>
        /// <para>
        /// <para>The maximum price for Spot instances as a percentage of the optimal On-Demand price.
        /// This provides more precise cost control for Spot instance selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice")]
        public System.Int32? InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice { get; set; }
        #endregion
        
        #region Parameter AcceleratorCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of accelerators. Instance types with fewer accelerators are excluded
        /// from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_Min")]
        public System.Int32? AcceleratorCount_Min { get; set; }
        #endregion
        
        #region Parameter AcceleratorTotalMemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum total accelerator memory in MiB. Instance types with less accelerator
        /// memory are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_Min")]
        public System.Int32? AcceleratorTotalMemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter BaselineEbsBandwidthMbps_Min
        /// <summary>
        /// <para>
        /// <para>The minimum baseline Amazon EBS bandwidth in Mbps. Instance types with lower Amazon
        /// EBS bandwidth are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_Min")]
        public System.Int32? BaselineEbsBandwidthMbps_Min { get; set; }
        #endregion
        
        #region Parameter MemoryGiBPerVCpu_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory per vCPU in GiB. Instance types with a lower memory-to-vCPU
        /// ratio are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_Min")]
        public System.Double? MemoryGiBPerVCpu_Min { get; set; }
        #endregion
        
        #region Parameter MemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory in MiB. Instance types with less memory than this value
        /// are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_Min")]
        public System.Int32? MemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter NetworkBandwidthGbps_Min
        /// <summary>
        /// <para>
        /// <para>The minimum network bandwidth in Gbps. Instance types with lower network bandwidth
        /// are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_Min")]
        public System.Double? NetworkBandwidthGbps_Min { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of network interfaces. Instance types that support fewer network
        /// interfaces are excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_Min")]
        public System.Int32? NetworkInterfaceCount_Min { get; set; }
        #endregion
        
        #region Parameter TotalLocalStorageGB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum total local storage in GB. Instance types with less local storage are
        /// excluded from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_Min")]
        public System.Double? TotalLocalStorageGB_Min { get; set; }
        #endregion
        
        #region Parameter VCpuCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of vCPUs. Instance types with fewer vCPUs than this value are excluded
        /// from selection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_Min")]
        public System.Int32? VCpuCount_Min { get; set; }
        #endregion
        
        #region Parameter ManagedScaling_MinimumScalingStepSize
        /// <summary>
        /// <para>
        /// <para>The minimum number of Amazon EC2 instances that Amazon ECS will scale out at one time.
        /// The scale in process is not affected by this parameter If this parameter is omitted,
        /// the default value of <c>1</c> is used.</para><para>When additional capacity is required, Amazon ECS will scale up the minimum scaling
        /// step size even if the actual demand is less than the minimum scaling step size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_MinimumScalingStepSize")]
        public System.Int32? ManagedScaling_MinimumScalingStepSize { get; set; }
        #endregion
        
        #region Parameter InstanceLaunchTemplate_Monitoring
        /// <summary>
        /// <para>
        /// <para>CloudWatch provides two categories of monitoring: basic monitoring and detailed monitoring.
        /// By default, your managed instance is configured for basic monitoring. You can optionally
        /// enable detailed monitoring to help you more quickly identify and act on operational
        /// issues. You can enable or turn off detailed monitoring at launch or when the managed
        /// instance is running or stopped. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/detailed-monitoring-managed-instances.html">Detailed
        /// monitoring for Amazon ECS Managed Instances</a> in the Amazon ECS Developer Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring")]
        [AWSConstantClassSource("Amazon.ECS.ManagedInstancesMonitoringOptions")]
        public Amazon.ECS.ManagedInstancesMonitoringOptions InstanceLaunchTemplate_Monitoring { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the capacity provider. Up to 255 characters are allowed. They include
        /// letters (both upper and lowercase letters), numbers, underscores (_), and hyphens
        /// (-). The name can't be prefixed with "<c>aws</c>", "<c>ecs</c>", or "<c>fargate</c>".</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice
        /// <summary>
        /// <para>
        /// <para>The price protection threshold for On-Demand Instances, as a percentage higher than
        /// an identified On-Demand price. The identified On-Demand price is the price of the
        /// lowest priced current generation C, M, or R instance type with your specified attributes.
        /// If no current generation C, M, or R instance type matches your attributes, then the
        /// identified price is from either the lowest priced current generation instance types
        /// or, failing that, the lowest priced previous generation instance types that match
        /// your attributes. When Amazon ECS selects instance types with your attributes, we will
        /// exclude instance types whose price exceeds your specified threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice")]
        public System.Int32? InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice { get; set; }
        #endregion
        
        #region Parameter ManagedInstancesProvider_PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate tags from the capacity provider to the Amazon ECS Managed
        /// Instances. When enabled, tags applied to the capacity provider are automatically applied
        /// to all instances launched by this provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.PropagateMITags")]
        public Amazon.ECS.PropagateMITags ManagedInstancesProvider_PropagateTag { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_RequireHibernateSupport
        /// <summary>
        /// <para>
        /// <para>Indicates whether the instance types must support hibernation. When set to <c>true</c>,
        /// only instance types that support hibernation are selected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_RequireHibernateSupport")]
        public System.Boolean? InstanceRequirements_RequireHibernateSupport { get; set; }
        #endregion
        
        #region Parameter InfrastructureOptimization_ScaleInAfter
        /// <summary>
        /// <para>
        /// <para>This parameter defines the number of seconds Amazon ECS Managed Instances waits before
        /// optimizing EC2 instances that have become idle or underutilized. A longer delay increases
        /// the likelihood of placing new tasks on idle or underutilized instances instances,
        /// reducing startup time. A shorter delay helps reduce infrastructure costs by optimizing
        /// idle or underutilized instances,instances more quickly.</para><para>Valid values are:</para><ul><li><para><c>null</c> - Uses the default optimization behavior.</para></li><li><para><c>-1</c> - Disables automatic infrastructure optimization.</para></li><li><para>A value between <c>0</c> and <c>3600</c> (inclusive) - Specifies the number of seconds
        /// to wait before optimizing instances.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter")]
        public System.Int32? InfrastructureOptimization_ScaleInAfter { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The list of security group IDs to apply to Amazon ECS Managed Instances. These security
        /// groups control the network traffic allowed to and from the instances.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroups")]
        public System.String[] NetworkConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter InstanceRequirements_SpotMaxPricePercentageOverLowestPrice
        /// <summary>
        /// <para>
        /// <para>The maximum price for Spot instances as a percentage over the lowest priced On-Demand
        /// instance. This helps control Spot instance costs while maintaining access to capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_SpotMaxPricePercentageOverLowestPrice")]
        public System.Int32? InstanceRequirements_SpotMaxPricePercentageOverLowestPrice { get; set; }
        #endregion
        
        #region Parameter ManagedScaling_Status
        /// <summary>
        /// <para>
        /// <para>Determines whether to use managed scaling for the capacity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_Status")]
        [AWSConstantClassSource("Amazon.ECS.ManagedScalingStatus")]
        public Amazon.ECS.ManagedScalingStatus ManagedScaling_Status { get; set; }
        #endregion
        
        #region Parameter StorageConfiguration_StorageSizeGiB
        /// <summary>
        /// <para>
        /// <para>The size of the tasks volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB")]
        public System.Int32? StorageConfiguration_StorageSizeGiB { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The list of subnet IDs where Amazon ECS can launch Amazon ECS Managed Instances. Instances
        /// are distributed across the specified subnets for high availability. All subnets must
        /// be in the same VPC.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnets")]
        public System.String[] NetworkConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the capacity provider to categorize and organize them
        /// more conveniently. Each tag consists of a key and an optional value. You define both
        /// of them.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case-sensitive.</para></li><li><para>Do not use <c>aws:</c>, <c>AWS:</c>, or any upper or lowercase combination of such
        /// as a prefix for either keys or values as it is reserved for Amazon Web Services use.
        /// You cannot edit or delete tag keys or values with this prefix. Tags with this prefix
        /// do not count against your tags per resource limit.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ECS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ManagedScaling_TargetCapacity
        /// <summary>
        /// <para>
        /// <para>The target capacity utilization as a percentage for the capacity provider. The specified
        /// value must be greater than <c>0</c> and less than or equal to <c>100</c>. For example,
        /// if you want the capacity provider to maintain 10% spare capacity, then that means
        /// the utilization is 90%, so use a <c>targetCapacity</c> of <c>90</c>. The default value
        /// of <c>100</c> percent results in the Amazon EC2 instances in your Auto Scaling group
        /// being completely used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingGroupProvider_ManagedScaling_TargetCapacity")]
        public System.Int32? ManagedScaling_TargetCapacity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.CreateCapacityProviderResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.CreateCapacityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityProvider";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSCapacityProvider (CreateCapacityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.CreateCapacityProviderResponse, NewECSCapacityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingGroupProvider_AutoScalingGroupArn = this.AutoScalingGroupProvider_AutoScalingGroupArn;
            context.AutoScalingGroupProvider_ManagedDraining = this.AutoScalingGroupProvider_ManagedDraining;
            context.ManagedScaling_InstanceWarmupPeriod = this.ManagedScaling_InstanceWarmupPeriod;
            context.ManagedScaling_MaximumScalingStepSize = this.ManagedScaling_MaximumScalingStepSize;
            context.ManagedScaling_MinimumScalingStepSize = this.ManagedScaling_MinimumScalingStepSize;
            context.ManagedScaling_Status = this.ManagedScaling_Status;
            context.ManagedScaling_TargetCapacity = this.ManagedScaling_TargetCapacity;
            context.AutoScalingGroupProvider_ManagedTerminationProtection = this.AutoScalingGroupProvider_ManagedTerminationProtection;
            context.Cluster = this.Cluster;
            context.InfrastructureOptimization_ScaleInAfter = this.InfrastructureOptimization_ScaleInAfter;
            context.ManagedInstancesProvider_InfrastructureRoleArn = this.ManagedInstancesProvider_InfrastructureRoleArn;
            context.ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType = this.ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType;
            context.InstanceLaunchTemplate_Ec2InstanceProfileArn = this.InstanceLaunchTemplate_Ec2InstanceProfileArn;
            context.ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled = this.ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled;
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
            context.InstanceLaunchTemplate_Monitoring = this.InstanceLaunchTemplate_Monitoring;
            if (this.NetworkConfiguration_SecurityGroup != null)
            {
                context.NetworkConfiguration_SecurityGroup = new List<System.String>(this.NetworkConfiguration_SecurityGroup);
            }
            if (this.NetworkConfiguration_Subnet != null)
            {
                context.NetworkConfiguration_Subnet = new List<System.String>(this.NetworkConfiguration_Subnet);
            }
            context.StorageConfiguration_StorageSizeGiB = this.StorageConfiguration_StorageSizeGiB;
            context.ManagedInstancesProvider_PropagateTag = this.ManagedInstancesProvider_PropagateTag;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ECS.Model.Tag>(this.Tag);
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
            var request = new Amazon.ECS.Model.CreateCapacityProviderRequest();
            
            
             // populate AutoScalingGroupProvider
            var requestAutoScalingGroupProviderIsNull = true;
            request.AutoScalingGroupProvider = new Amazon.ECS.Model.AutoScalingGroupProvider();
            System.String requestAutoScalingGroupProvider_autoScalingGroupProvider_AutoScalingGroupArn = null;
            if (cmdletContext.AutoScalingGroupProvider_AutoScalingGroupArn != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_AutoScalingGroupArn = cmdletContext.AutoScalingGroupProvider_AutoScalingGroupArn;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_AutoScalingGroupArn != null)
            {
                request.AutoScalingGroupProvider.AutoScalingGroupArn = requestAutoScalingGroupProvider_autoScalingGroupProvider_AutoScalingGroupArn;
                requestAutoScalingGroupProviderIsNull = false;
            }
            Amazon.ECS.ManagedDraining requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedDraining = null;
            if (cmdletContext.AutoScalingGroupProvider_ManagedDraining != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedDraining = cmdletContext.AutoScalingGroupProvider_ManagedDraining;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedDraining != null)
            {
                request.AutoScalingGroupProvider.ManagedDraining = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedDraining;
                requestAutoScalingGroupProviderIsNull = false;
            }
            Amazon.ECS.ManagedTerminationProtection requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedTerminationProtection = null;
            if (cmdletContext.AutoScalingGroupProvider_ManagedTerminationProtection != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedTerminationProtection = cmdletContext.AutoScalingGroupProvider_ManagedTerminationProtection;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedTerminationProtection != null)
            {
                request.AutoScalingGroupProvider.ManagedTerminationProtection = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedTerminationProtection;
                requestAutoScalingGroupProviderIsNull = false;
            }
            Amazon.ECS.Model.ManagedScaling requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling = null;
            
             // populate ManagedScaling
            var requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = true;
            requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling = new Amazon.ECS.Model.ManagedScaling();
            System.Int32? requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_InstanceWarmupPeriod = null;
            if (cmdletContext.ManagedScaling_InstanceWarmupPeriod != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_InstanceWarmupPeriod = cmdletContext.ManagedScaling_InstanceWarmupPeriod.Value;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_InstanceWarmupPeriod != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.InstanceWarmupPeriod = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_InstanceWarmupPeriod.Value;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
            System.Int32? requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MaximumScalingStepSize = null;
            if (cmdletContext.ManagedScaling_MaximumScalingStepSize != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MaximumScalingStepSize = cmdletContext.ManagedScaling_MaximumScalingStepSize.Value;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MaximumScalingStepSize != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.MaximumScalingStepSize = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MaximumScalingStepSize.Value;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
            System.Int32? requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MinimumScalingStepSize = null;
            if (cmdletContext.ManagedScaling_MinimumScalingStepSize != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MinimumScalingStepSize = cmdletContext.ManagedScaling_MinimumScalingStepSize.Value;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MinimumScalingStepSize != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.MinimumScalingStepSize = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_MinimumScalingStepSize.Value;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
            Amazon.ECS.ManagedScalingStatus requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_Status = null;
            if (cmdletContext.ManagedScaling_Status != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_Status = cmdletContext.ManagedScaling_Status;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_Status != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.Status = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_Status;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
            System.Int32? requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_TargetCapacity = null;
            if (cmdletContext.ManagedScaling_TargetCapacity != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_TargetCapacity = cmdletContext.ManagedScaling_TargetCapacity.Value;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_TargetCapacity != null)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling.TargetCapacity = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling_managedScaling_TargetCapacity.Value;
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull = false;
            }
             // determine if requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling should be set to null
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScalingIsNull)
            {
                requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling = null;
            }
            if (requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling != null)
            {
                request.AutoScalingGroupProvider.ManagedScaling = requestAutoScalingGroupProvider_autoScalingGroupProvider_ManagedScaling;
                requestAutoScalingGroupProviderIsNull = false;
            }
             // determine if request.AutoScalingGroupProvider should be set to null
            if (requestAutoScalingGroupProviderIsNull)
            {
                request.AutoScalingGroupProvider = null;
            }
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            
             // populate ManagedInstancesProvider
            var requestManagedInstancesProviderIsNull = true;
            request.ManagedInstancesProvider = new Amazon.ECS.Model.CreateManagedInstancesProviderConfiguration();
            System.String requestManagedInstancesProvider_managedInstancesProvider_InfrastructureRoleArn = null;
            if (cmdletContext.ManagedInstancesProvider_InfrastructureRoleArn != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InfrastructureRoleArn = cmdletContext.ManagedInstancesProvider_InfrastructureRoleArn;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InfrastructureRoleArn != null)
            {
                request.ManagedInstancesProvider.InfrastructureRoleArn = requestManagedInstancesProvider_managedInstancesProvider_InfrastructureRoleArn;
                requestManagedInstancesProviderIsNull = false;
            }
            Amazon.ECS.PropagateMITags requestManagedInstancesProvider_managedInstancesProvider_PropagateTag = null;
            if (cmdletContext.ManagedInstancesProvider_PropagateTag != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_PropagateTag = cmdletContext.ManagedInstancesProvider_PropagateTag;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_PropagateTag != null)
            {
                request.ManagedInstancesProvider.PropagateTags = requestManagedInstancesProvider_managedInstancesProvider_PropagateTag;
                requestManagedInstancesProviderIsNull = false;
            }
            Amazon.ECS.Model.InfrastructureOptimization requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization = null;
            
             // populate InfrastructureOptimization
            var requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimizationIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization = new Amazon.ECS.Model.InfrastructureOptimization();
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization_infrastructureOptimization_ScaleInAfter = null;
            if (cmdletContext.InfrastructureOptimization_ScaleInAfter != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization_infrastructureOptimization_ScaleInAfter = cmdletContext.InfrastructureOptimization_ScaleInAfter.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization_infrastructureOptimization_ScaleInAfter != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization.ScaleInAfter = requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization_infrastructureOptimization_ScaleInAfter.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimizationIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimizationIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization != null)
            {
                request.ManagedInstancesProvider.InfrastructureOptimization = requestManagedInstancesProvider_managedInstancesProvider_InfrastructureOptimization;
                requestManagedInstancesProviderIsNull = false;
            }
            Amazon.ECS.Model.InstanceLaunchTemplate requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate = null;
            
             // populate InstanceLaunchTemplate
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplateIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate = new Amazon.ECS.Model.InstanceLaunchTemplate();
            Amazon.ECS.CapacityOptionType requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType = null;
            if (cmdletContext.ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType = cmdletContext.ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate.CapacityOptionType = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            System.String requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_instanceLaunchTemplate_Ec2InstanceProfileArn = null;
            if (cmdletContext.InstanceLaunchTemplate_Ec2InstanceProfileArn != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_instanceLaunchTemplate_Ec2InstanceProfileArn = cmdletContext.InstanceLaunchTemplate_Ec2InstanceProfileArn;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_instanceLaunchTemplate_Ec2InstanceProfileArn != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate.Ec2InstanceProfileArn = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_instanceLaunchTemplate_Ec2InstanceProfileArn;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            System.Boolean? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_FipsEnabled = null;
            if (cmdletContext.ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_FipsEnabled = cmdletContext.ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_FipsEnabled != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate.FipsEnabled = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_FipsEnabled.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            Amazon.ECS.ManagedInstancesMonitoringOptions requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_instanceLaunchTemplate_Monitoring = null;
            if (cmdletContext.InstanceLaunchTemplate_Monitoring != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_instanceLaunchTemplate_Monitoring = cmdletContext.InstanceLaunchTemplate_Monitoring;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_instanceLaunchTemplate_Monitoring != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate.Monitoring = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_instanceLaunchTemplate_Monitoring;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            Amazon.ECS.Model.ManagedInstancesStorageConfiguration requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration = null;
            
             // populate StorageConfiguration
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfigurationIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration = new Amazon.ECS.Model.ManagedInstancesStorageConfiguration();
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_storageConfiguration_StorageSizeGiB = null;
            if (cmdletContext.StorageConfiguration_StorageSizeGiB != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_storageConfiguration_StorageSizeGiB = cmdletContext.StorageConfiguration_StorageSizeGiB.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_storageConfiguration_StorageSizeGiB != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration.StorageSizeGiB = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_storageConfiguration_StorageSizeGiB.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfigurationIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfigurationIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate.StorageConfiguration = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            Amazon.ECS.Model.ManagedInstancesNetworkConfiguration requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration = null;
            
             // populate NetworkConfiguration
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfigurationIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration = new Amazon.ECS.Model.ManagedInstancesNetworkConfiguration();
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_networkConfiguration_SecurityGroup = null;
            if (cmdletContext.NetworkConfiguration_SecurityGroup != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_networkConfiguration_SecurityGroup = cmdletContext.NetworkConfiguration_SecurityGroup;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_networkConfiguration_SecurityGroup != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration.SecurityGroups = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_networkConfiguration_SecurityGroup;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfigurationIsNull = false;
            }
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_networkConfiguration_Subnet = null;
            if (cmdletContext.NetworkConfiguration_Subnet != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_networkConfiguration_Subnet = cmdletContext.NetworkConfiguration_Subnet;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_networkConfiguration_Subnet != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration.Subnets = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_networkConfiguration_Subnet;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfigurationIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfigurationIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate.NetworkConfiguration = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            Amazon.ECS.Model.InstanceRequirementsRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements = null;
            
             // populate InstanceRequirements
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements = new Amazon.ECS.Model.InstanceRequirementsRequest();
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorManufacturer = null;
            if (cmdletContext.InstanceRequirements_AcceleratorManufacturer != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorManufacturer = cmdletContext.InstanceRequirements_AcceleratorManufacturer;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorManufacturer != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.AcceleratorManufacturers = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorManufacturer;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorName = null;
            if (cmdletContext.InstanceRequirements_AcceleratorName != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorName = cmdletContext.InstanceRequirements_AcceleratorName;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorName != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.AcceleratorNames = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorName;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorType = null;
            if (cmdletContext.InstanceRequirements_AcceleratorType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorType = cmdletContext.InstanceRequirements_AcceleratorType;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.AcceleratorTypes = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AcceleratorType;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AllowedInstanceType = null;
            if (cmdletContext.InstanceRequirements_AllowedInstanceType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AllowedInstanceType = cmdletContext.InstanceRequirements_AllowedInstanceType;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AllowedInstanceType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.AllowedInstanceTypes = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_AllowedInstanceType;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.BareMetal requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_BareMetal = null;
            if (cmdletContext.InstanceRequirements_BareMetal != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_BareMetal = cmdletContext.InstanceRequirements_BareMetal;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_BareMetal != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.BareMetal = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_BareMetal;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.BurstablePerformance requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_BurstablePerformance = null;
            if (cmdletContext.InstanceRequirements_BurstablePerformance != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_BurstablePerformance = cmdletContext.InstanceRequirements_BurstablePerformance;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_BurstablePerformance != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.BurstablePerformance = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_BurstablePerformance;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_CpuManufacturer = null;
            if (cmdletContext.InstanceRequirements_CpuManufacturer != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_CpuManufacturer = cmdletContext.InstanceRequirements_CpuManufacturer;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_CpuManufacturer != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.CpuManufacturers = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_CpuManufacturer;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_ExcludedInstanceType = null;
            if (cmdletContext.InstanceRequirements_ExcludedInstanceType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_ExcludedInstanceType = cmdletContext.InstanceRequirements_ExcludedInstanceType;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_ExcludedInstanceType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.ExcludedInstanceTypes = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_ExcludedInstanceType;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_InstanceGeneration = null;
            if (cmdletContext.InstanceRequirements_InstanceGeneration != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_InstanceGeneration = cmdletContext.InstanceRequirements_InstanceGeneration;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_InstanceGeneration != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.InstanceGenerations = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_InstanceGeneration;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.LocalStorage requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_LocalStorage = null;
            if (cmdletContext.InstanceRequirements_LocalStorage != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_LocalStorage = cmdletContext.InstanceRequirements_LocalStorage;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_LocalStorage != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.LocalStorage = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_LocalStorage;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            List<System.String> requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_LocalStorageType = null;
            if (cmdletContext.InstanceRequirements_LocalStorageType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_LocalStorageType = cmdletContext.InstanceRequirements_LocalStorageType;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_LocalStorageType != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.LocalStorageTypes = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_LocalStorageType;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = null;
            if (cmdletContext.InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = cmdletContext.InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.MaxSpotPriceAsPercentageOfOptimalOnDemandPrice = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = null;
            if (cmdletContext.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice = cmdletContext.InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.OnDemandMaxPricePercentageOverLowestPrice = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_OnDemandMaxPricePercentageOverLowestPrice.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            System.Boolean? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_RequireHibernateSupport = null;
            if (cmdletContext.InstanceRequirements_RequireHibernateSupport != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_RequireHibernateSupport = cmdletContext.InstanceRequirements_RequireHibernateSupport.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_RequireHibernateSupport != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.RequireHibernateSupport = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_RequireHibernateSupport.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice = null;
            if (cmdletContext.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice = cmdletContext.InstanceRequirements_SpotMaxPricePercentageOverLowestPrice.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.SpotMaxPricePercentageOverLowestPrice = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_instanceRequirements_SpotMaxPricePercentageOverLowestPrice.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.Model.AcceleratorCountRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount = null;
            
             // populate AcceleratorCount
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCountIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount = new Amazon.ECS.Model.AcceleratorCountRequest();
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_acceleratorCount_Max = null;
            if (cmdletContext.AcceleratorCount_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_acceleratorCount_Max = cmdletContext.AcceleratorCount_Max.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_acceleratorCount_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount.Max = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_acceleratorCount_Max.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCountIsNull = false;
            }
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_acceleratorCount_Min = null;
            if (cmdletContext.AcceleratorCount_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_acceleratorCount_Min = cmdletContext.AcceleratorCount_Min.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_acceleratorCount_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount.Min = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount_acceleratorCount_Min.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCountIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCountIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.AcceleratorCount = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorCount;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.Model.AcceleratorTotalMemoryMiBRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB = null;
            
             // populate AcceleratorTotalMemoryMiB
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiBIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB = new Amazon.ECS.Model.AcceleratorTotalMemoryMiBRequest();
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max = null;
            if (cmdletContext.AcceleratorTotalMemoryMiB_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max = cmdletContext.AcceleratorTotalMemoryMiB_Max.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB.Max = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiBIsNull = false;
            }
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min = null;
            if (cmdletContext.AcceleratorTotalMemoryMiB_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min = cmdletContext.AcceleratorTotalMemoryMiB_Min.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB.Min = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiBIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiBIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.AcceleratorTotalMemoryMiB = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AcceleratorTotalMemoryMiB;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.Model.BaselineEbsBandwidthMbpsRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps = null;
            
             // populate BaselineEbsBandwidthMbps
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbpsIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps = new Amazon.ECS.Model.BaselineEbsBandwidthMbpsRequest();
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max = null;
            if (cmdletContext.BaselineEbsBandwidthMbps_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max = cmdletContext.BaselineEbsBandwidthMbps_Max.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps.Max = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Max.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbpsIsNull = false;
            }
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min = null;
            if (cmdletContext.BaselineEbsBandwidthMbps_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min = cmdletContext.BaselineEbsBandwidthMbps_Min.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps.Min = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps_baselineEbsBandwidthMbps_Min.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbpsIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbpsIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.BaselineEbsBandwidthMbps = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_BaselineEbsBandwidthMbps;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.Model.MemoryGiBPerVCpuRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu = null;
            
             // populate MemoryGiBPerVCpu
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpuIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu = new Amazon.ECS.Model.MemoryGiBPerVCpuRequest();
            System.Double? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max = null;
            if (cmdletContext.MemoryGiBPerVCpu_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max = cmdletContext.MemoryGiBPerVCpu_Max.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu.Max = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Max.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpuIsNull = false;
            }
            System.Double? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min = null;
            if (cmdletContext.MemoryGiBPerVCpu_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min = cmdletContext.MemoryGiBPerVCpu_Min.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu.Min = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu_memoryGiBPerVCpu_Min.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpuIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpuIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.MemoryGiBPerVCpu = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryGiBPerVCpu;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.Model.MemoryMiBRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB = null;
            
             // populate MemoryMiB
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiBIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB = new Amazon.ECS.Model.MemoryMiBRequest();
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_memoryMiB_Max = null;
            if (cmdletContext.MemoryMiB_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_memoryMiB_Max = cmdletContext.MemoryMiB_Max.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_memoryMiB_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB.Max = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_memoryMiB_Max.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiBIsNull = false;
            }
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_memoryMiB_Min = null;
            if (cmdletContext.MemoryMiB_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_memoryMiB_Min = cmdletContext.MemoryMiB_Min.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_memoryMiB_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB.Min = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB_memoryMiB_Min.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiBIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiBIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.MemoryMiB = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_MemoryMiB;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.Model.NetworkBandwidthGbpsRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps = null;
            
             // populate NetworkBandwidthGbps
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbpsIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps = new Amazon.ECS.Model.NetworkBandwidthGbpsRequest();
            System.Double? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Max = null;
            if (cmdletContext.NetworkBandwidthGbps_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Max = cmdletContext.NetworkBandwidthGbps_Max.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps.Max = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Max.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbpsIsNull = false;
            }
            System.Double? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Min = null;
            if (cmdletContext.NetworkBandwidthGbps_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Min = cmdletContext.NetworkBandwidthGbps_Min.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps.Min = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps_networkBandwidthGbps_Min.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbpsIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbpsIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.NetworkBandwidthGbps = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkBandwidthGbps;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.Model.NetworkInterfaceCountRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount = null;
            
             // populate NetworkInterfaceCount
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCountIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount = new Amazon.ECS.Model.NetworkInterfaceCountRequest();
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max = null;
            if (cmdletContext.NetworkInterfaceCount_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max = cmdletContext.NetworkInterfaceCount_Max.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount.Max = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Max.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCountIsNull = false;
            }
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min = null;
            if (cmdletContext.NetworkInterfaceCount_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min = cmdletContext.NetworkInterfaceCount_Min.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount.Min = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount_networkInterfaceCount_Min.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCountIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCountIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.NetworkInterfaceCount = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_NetworkInterfaceCount;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.Model.TotalLocalStorageGBRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB = null;
            
             // populate TotalLocalStorageGB
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGBIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB = new Amazon.ECS.Model.TotalLocalStorageGBRequest();
            System.Double? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max = null;
            if (cmdletContext.TotalLocalStorageGB_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max = cmdletContext.TotalLocalStorageGB_Max.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB.Max = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Max.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGBIsNull = false;
            }
            System.Double? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min = null;
            if (cmdletContext.TotalLocalStorageGB_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min = cmdletContext.TotalLocalStorageGB_Min.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB.Min = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB_totalLocalStorageGB_Min.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGBIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGBIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.TotalLocalStorageGB = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_TotalLocalStorageGB;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
            Amazon.ECS.Model.VCpuCountRangeRequest requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount = null;
            
             // populate VCpuCount
            var requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCountIsNull = true;
            requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount = new Amazon.ECS.Model.VCpuCountRangeRequest();
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_vCpuCount_Max = null;
            if (cmdletContext.VCpuCount_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_vCpuCount_Max = cmdletContext.VCpuCount_Max.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_vCpuCount_Max != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount.Max = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_vCpuCount_Max.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCountIsNull = false;
            }
            System.Int32? requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_vCpuCount_Min = null;
            if (cmdletContext.VCpuCount_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_vCpuCount_Min = cmdletContext.VCpuCount_Min.Value;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_vCpuCount_Min != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount.Min = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount_vCpuCount_Min.Value;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCountIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCountIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.VCpuCount = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_VCpuCount;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements != null)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate.InstanceRequirements = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate_managedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements;
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
             // determine if requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate should be set to null
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplateIsNull)
            {
                requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate = null;
            }
            if (requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate != null)
            {
                request.ManagedInstancesProvider.InstanceLaunchTemplate = requestManagedInstancesProvider_managedInstancesProvider_InstanceLaunchTemplate;
                requestManagedInstancesProviderIsNull = false;
            }
             // determine if request.ManagedInstancesProvider should be set to null
            if (requestManagedInstancesProviderIsNull)
            {
                request.ManagedInstancesProvider = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ECS.Model.CreateCapacityProviderResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.CreateCapacityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "CreateCapacityProvider");
            try
            {
                return client.CreateCapacityProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AutoScalingGroupProvider_AutoScalingGroupArn { get; set; }
            public Amazon.ECS.ManagedDraining AutoScalingGroupProvider_ManagedDraining { get; set; }
            public System.Int32? ManagedScaling_InstanceWarmupPeriod { get; set; }
            public System.Int32? ManagedScaling_MaximumScalingStepSize { get; set; }
            public System.Int32? ManagedScaling_MinimumScalingStepSize { get; set; }
            public Amazon.ECS.ManagedScalingStatus ManagedScaling_Status { get; set; }
            public System.Int32? ManagedScaling_TargetCapacity { get; set; }
            public Amazon.ECS.ManagedTerminationProtection AutoScalingGroupProvider_ManagedTerminationProtection { get; set; }
            public System.String Cluster { get; set; }
            public System.Int32? InfrastructureOptimization_ScaleInAfter { get; set; }
            public System.String ManagedInstancesProvider_InfrastructureRoleArn { get; set; }
            public Amazon.ECS.CapacityOptionType ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType { get; set; }
            public System.String InstanceLaunchTemplate_Ec2InstanceProfileArn { get; set; }
            public System.Boolean? ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled { get; set; }
            public System.Int32? AcceleratorCount_Max { get; set; }
            public System.Int32? AcceleratorCount_Min { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorManufacturer { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorName { get; set; }
            public System.Int32? AcceleratorTotalMemoryMiB_Max { get; set; }
            public System.Int32? AcceleratorTotalMemoryMiB_Min { get; set; }
            public List<System.String> InstanceRequirements_AcceleratorType { get; set; }
            public List<System.String> InstanceRequirements_AllowedInstanceType { get; set; }
            public Amazon.ECS.BareMetal InstanceRequirements_BareMetal { get; set; }
            public System.Int32? BaselineEbsBandwidthMbps_Max { get; set; }
            public System.Int32? BaselineEbsBandwidthMbps_Min { get; set; }
            public Amazon.ECS.BurstablePerformance InstanceRequirements_BurstablePerformance { get; set; }
            public List<System.String> InstanceRequirements_CpuManufacturer { get; set; }
            public List<System.String> InstanceRequirements_ExcludedInstanceType { get; set; }
            public List<System.String> InstanceRequirements_InstanceGeneration { get; set; }
            public Amazon.ECS.LocalStorage InstanceRequirements_LocalStorage { get; set; }
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
            public Amazon.ECS.ManagedInstancesMonitoringOptions InstanceLaunchTemplate_Monitoring { get; set; }
            public List<System.String> NetworkConfiguration_SecurityGroup { get; set; }
            public List<System.String> NetworkConfiguration_Subnet { get; set; }
            public System.Int32? StorageConfiguration_StorageSizeGiB { get; set; }
            public Amazon.ECS.PropagateMITags ManagedInstancesProvider_PropagateTag { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ECS.Model.CreateCapacityProviderResponse, NewECSCapacityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityProvider;
        }
        
    }
}
