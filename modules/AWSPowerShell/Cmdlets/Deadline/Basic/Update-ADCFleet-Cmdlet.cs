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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Updates a fleet.
    /// </summary>
    [Cmdlet("Update", "ADCFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWSDeadlineCloud UpdateFleet API operation.", Operation = new[] {"UpdateFleet"}, SelectReturnType = typeof(Amazon.Deadline.Model.UpdateFleetResponse))]
    [AWSCmdletOutput("None or Amazon.Deadline.Model.UpdateFleetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Deadline.Model.UpdateFleetResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateADCFleetCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter WorkerCapabilities_AcceleratorType
        /// <summary>
        /// <para>
        /// <para>The accelerator types for the customer managed worker capabilities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_WorkerCapabilities_AcceleratorTypes")]
        public System.String[] WorkerCapabilities_AcceleratorType { get; set; }
        #endregion
        
        #region Parameter InstanceCapabilities_AllowedInstanceType
        /// <summary>
        /// <para>
        /// <para>The allowable Amazon EC2 instance types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_AllowedInstanceTypes")]
        public System.String[] InstanceCapabilities_AllowedInstanceType { get; set; }
        #endregion
        
        #region Parameter WorkerCapabilities_CpuArchitectureType
        /// <summary>
        /// <para>
        /// <para>The CPU architecture type for the customer managed worker capabilities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_WorkerCapabilities_CpuArchitectureType")]
        [AWSConstantClassSource("Amazon.Deadline.CpuArchitectureType")]
        public Amazon.Deadline.CpuArchitectureType WorkerCapabilities_CpuArchitectureType { get; set; }
        #endregion
        
        #region Parameter InstanceCapabilities_CpuArchitectureType
        /// <summary>
        /// <para>
        /// <para>The CPU architecture type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_CpuArchitectureType")]
        [AWSConstantClassSource("Amazon.Deadline.CpuArchitectureType")]
        public Amazon.Deadline.CpuArchitectureType InstanceCapabilities_CpuArchitectureType { get; set; }
        #endregion
        
        #region Parameter WorkerCapabilities_CustomAmount
        /// <summary>
        /// <para>
        /// <para>Custom requirement ranges for customer managed worker capabilities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_WorkerCapabilities_CustomAmounts")]
        public Amazon.Deadline.Model.FleetAmountCapability[] WorkerCapabilities_CustomAmount { get; set; }
        #endregion
        
        #region Parameter InstanceCapabilities_CustomAmount
        /// <summary>
        /// <para>
        /// <para>The custom capability amounts to require for instances in this fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_CustomAmounts")]
        public Amazon.Deadline.Model.FleetAmountCapability[] InstanceCapabilities_CustomAmount { get; set; }
        #endregion
        
        #region Parameter WorkerCapabilities_CustomAttribute
        /// <summary>
        /// <para>
        /// <para>Custom attributes for the customer manged worker capabilities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_WorkerCapabilities_CustomAttributes")]
        public Amazon.Deadline.Model.FleetAttributeCapability[] WorkerCapabilities_CustomAttribute { get; set; }
        #endregion
        
        #region Parameter InstanceCapabilities_CustomAttribute
        /// <summary>
        /// <para>
        /// <para>The custom capability attributes to require for instances in this fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_CustomAttributes")]
        public Amazon.Deadline.Model.FleetAttributeCapability[] InstanceCapabilities_CustomAttribute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the fleet to update.</para><important><para>This field can store any content. Escape or encode this content before displaying
        /// it on a webpage or any other system that might interpret the content of this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the fleet to update.</para><important><para>This field can store any content. Escape or encode this content before displaying
        /// it on a webpage or any other system that might interpret the content of this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter InstanceCapabilities_ExcludedInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types to exclude from the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_ExcludedInstanceTypes")]
        public System.String[] InstanceCapabilities_ExcludedInstanceType { get; set; }
        #endregion
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID to update.</para>
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
        public System.String FarmId { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>The fleet ID to update.</para>
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
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter RootEbsVolume_Iops
        /// <summary>
        /// <para>
        /// <para>The IOPS per volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_Iops")]
        public System.Int32? RootEbsVolume_Iops { get; set; }
        #endregion
        
        #region Parameter AcceleratorCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of GPU accelerators in the worker host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_Max")]
        public System.Int32? AcceleratorCount_Max { get; set; }
        #endregion
        
        #region Parameter AcceleratorTotalMemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory to use for the accelerator, measured in MiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_Max")]
        public System.Int32? AcceleratorTotalMemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory (in MiB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkerCapabilities_MemoryMiB_Max")]
        public System.Int32? Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of vCPU.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkerCapabilities_VCpuCount_Max")]
        public System.Int32? Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max { get; set; }
        #endregion
        
        #region Parameter Count_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of GPU accelerators in the worker host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_Max")]
        public System.Int32? Count_Max { get; set; }
        #endregion
        
        #region Parameter Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory (in MiB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceCapabilities_MemoryMiB_Max")]
        public System.Int32? Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max { get; set; }
        #endregion
        
        #region Parameter Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum amount of vCPU.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceCapabilities_VCpuCount_Max")]
        public System.Int32? Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max { get; set; }
        #endregion
        
        #region Parameter MaxWorkerCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of workers in the fleet.</para><para>Deadline Cloud limits the number of workers to less than or equal to the fleet's maximum
        /// worker count. The service maintains eventual consistency for the worker count. If
        /// you make multiple rapid calls to <c>CreateWorker</c> before the field updates, you
        /// might exceed your fleet's maximum worker count. For example, if your <c>maxWorkerCount</c>
        /// is 10 and you currently have 9 workers, making two quick <c>CreateWorker</c> calls
        /// might successfully create 2 workers instead of 1, resulting in 11 total workers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxWorkerCount { get; set; }
        #endregion
        
        #region Parameter AcceleratorCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of GPU accelerators in the worker host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_Min")]
        public System.Int32? AcceleratorCount_Min { get; set; }
        #endregion
        
        #region Parameter AcceleratorTotalMemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory to use for the accelerator, measured in MiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_Min")]
        public System.Int32? AcceleratorTotalMemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory (in MiB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkerCapabilities_MemoryMiB_Min")]
        public System.Int32? Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of vCPU.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkerCapabilities_VCpuCount_Min")]
        public System.Int32? Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min { get; set; }
        #endregion
        
        #region Parameter Count_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of GPU accelerators in the worker host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_Min")]
        public System.Int32? Count_Min { get; set; }
        #endregion
        
        #region Parameter Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of memory (in MiB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceCapabilities_MemoryMiB_Min")]
        public System.Int32? Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min { get; set; }
        #endregion
        
        #region Parameter Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum amount of vCPU.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceCapabilities_VCpuCount_Min")]
        public System.Int32? Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min { get; set; }
        #endregion
        
        #region Parameter MinWorkerCount
        /// <summary>
        /// <para>
        /// <para>The minimum number of workers in the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinWorkerCount { get; set; }
        #endregion
        
        #region Parameter CustomerManaged_Mode
        /// <summary>
        /// <para>
        /// <para>The Auto Scaling mode for the customer managed fleet configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_Mode")]
        [AWSConstantClassSource("Amazon.Deadline.AutoScalingMode")]
        public Amazon.Deadline.AutoScalingMode CustomerManaged_Mode { get; set; }
        #endregion
        
        #region Parameter WorkerCapabilities_OsFamily
        /// <summary>
        /// <para>
        /// <para>The operating system (OS) family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_WorkerCapabilities_OsFamily")]
        [AWSConstantClassSource("Amazon.Deadline.CustomerManagedFleetOperatingSystemFamily")]
        public Amazon.Deadline.CustomerManagedFleetOperatingSystemFamily WorkerCapabilities_OsFamily { get; set; }
        #endregion
        
        #region Parameter InstanceCapabilities_OsFamily
        /// <summary>
        /// <para>
        /// <para>The operating system (OS) family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_OsFamily")]
        [AWSConstantClassSource("Amazon.Deadline.ServiceManagedFleetOperatingSystemFamily")]
        public Amazon.Deadline.ServiceManagedFleetOperatingSystemFamily InstanceCapabilities_OsFamily { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_ResourceConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the VPC Lattice resource configurations attached to the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_VpcConfiguration_ResourceConfigurationArns")]
        public System.String[] VpcConfiguration_ResourceConfigurationArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role ARN that the fleet's workers assume while running jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter HostConfiguration_ScriptBody
        /// <summary>
        /// <para>
        /// <para>The text of the script that runs as a worker is starting up that you can use to provide
        /// additional configuration for workers in your fleet. The script runs after a worker
        /// enters the <c>STARTING</c> state and before the worker processes tasks.</para><para>For more information about using the script, see <a href="https://docs.aws.amazon.com/deadline-cloud/latest/developerguide/smf-admin.html">Run
        /// scripts as an administrator to configure workers</a> in the <i>Deadline Cloud Developer
        /// Guide</i>. </para><important><para>The script runs as an administrative user (<c>sudo root</c> on Linux, as an Administrator
        /// on Windows). </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostConfiguration_ScriptBody { get; set; }
        #endregion
        
        #region Parameter HostConfiguration_ScriptTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time that the host configuration can run. If the timeout expires, the
        /// worker enters the <c>NOT RESPONDING</c> state and shuts down. You are charged for
        /// the time that the worker is running the host configuration script.</para><note><para>You should configure your fleet for a maximum of one worker while testing your host
        /// configuration script to avoid starting additional workers.</para></note><para>The default is 300 seconds (5 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HostConfiguration_ScriptTimeoutSeconds")]
        public System.Int32? HostConfiguration_ScriptTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter AcceleratorCapabilities_Selection
        /// <summary>
        /// <para>
        /// <para>A list of accelerator capabilities requested for this fleet. Only Amazon Elastic Compute
        /// Cloud instances that provide these capabilities will be used. For example, if you
        /// specify both L4 and T4 chips, Deadline Cloud will use Amazon EC2 instances that have
        /// either the L4 or the T4 chip installed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Selections")]
        public Amazon.Deadline.Model.AcceleratorSelection[] AcceleratorCapabilities_Selection { get; set; }
        #endregion
        
        #region Parameter RootEbsVolume_SizeGiB
        /// <summary>
        /// <para>
        /// <para>The EBS volume size in GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_SizeGiB")]
        public System.Int32? RootEbsVolume_SizeGiB { get; set; }
        #endregion
        
        #region Parameter CustomerManaged_StorageProfileId
        /// <summary>
        /// <para>
        /// <para>The storage profile ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_StorageProfileId")]
        public System.String CustomerManaged_StorageProfileId { get; set; }
        #endregion
        
        #region Parameter ServiceManagedEc2_StorageProfileId
        /// <summary>
        /// <para>
        /// <para>The storage profile ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_StorageProfileId")]
        public System.String ServiceManagedEc2_StorageProfileId { get; set; }
        #endregion
        
        #region Parameter CustomerManaged_TagPropagationMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether tags associated with a fleet are attached to workers when the worker
        /// is launched. </para><para>When the <c>tagPropagationMode</c> is set to <c>PROPAGATE_TAGS_TO_WORKERS_AT_LAUNCH</c>
        /// any tag associated with a fleet is attached to workers when they launch. If the tags
        /// for a fleet change, the tags associated with running workers <b>do not</b> change.</para><para>If you don't specify <c>tagPropagationMode</c>, the default is <c>NO_PROPAGATION</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerManaged_TagPropagationMode")]
        [AWSConstantClassSource("Amazon.Deadline.TagPropagationMode")]
        public Amazon.Deadline.TagPropagationMode CustomerManaged_TagPropagationMode { get; set; }
        #endregion
        
        #region Parameter RootEbsVolume_ThroughputMiB
        /// <summary>
        /// <para>
        /// <para>The throughput per volume in MiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_ThroughputMiB")]
        public System.Int32? RootEbsVolume_ThroughputMiB { get; set; }
        #endregion
        
        #region Parameter InstanceMarketOptions_Type
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instance type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ServiceManagedEc2_InstanceMarketOptions_Type")]
        [AWSConstantClassSource("Amazon.Deadline.Ec2MarketType")]
        public Amazon.Deadline.Ec2MarketType InstanceMarketOptions_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The unique token which the server uses to recognize retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.UpdateFleetResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ADCFleet (UpdateFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.UpdateFleetResponse, UpdateADCFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CustomerManaged_Mode = this.CustomerManaged_Mode;
            context.CustomerManaged_StorageProfileId = this.CustomerManaged_StorageProfileId;
            context.CustomerManaged_TagPropagationMode = this.CustomerManaged_TagPropagationMode;
            context.AcceleratorCount_Max = this.AcceleratorCount_Max;
            context.AcceleratorCount_Min = this.AcceleratorCount_Min;
            context.AcceleratorTotalMemoryMiB_Max = this.AcceleratorTotalMemoryMiB_Max;
            context.AcceleratorTotalMemoryMiB_Min = this.AcceleratorTotalMemoryMiB_Min;
            if (this.WorkerCapabilities_AcceleratorType != null)
            {
                context.WorkerCapabilities_AcceleratorType = new List<System.String>(this.WorkerCapabilities_AcceleratorType);
            }
            context.WorkerCapabilities_CpuArchitectureType = this.WorkerCapabilities_CpuArchitectureType;
            if (this.WorkerCapabilities_CustomAmount != null)
            {
                context.WorkerCapabilities_CustomAmount = new List<Amazon.Deadline.Model.FleetAmountCapability>(this.WorkerCapabilities_CustomAmount);
            }
            if (this.WorkerCapabilities_CustomAttribute != null)
            {
                context.WorkerCapabilities_CustomAttribute = new List<Amazon.Deadline.Model.FleetAttributeCapability>(this.WorkerCapabilities_CustomAttribute);
            }
            context.Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max = this.Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max;
            context.Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min = this.Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min;
            context.WorkerCapabilities_OsFamily = this.WorkerCapabilities_OsFamily;
            context.Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max = this.Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max;
            context.Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min = this.Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min;
            context.Count_Max = this.Count_Max;
            context.Count_Min = this.Count_Min;
            if (this.AcceleratorCapabilities_Selection != null)
            {
                context.AcceleratorCapabilities_Selection = new List<Amazon.Deadline.Model.AcceleratorSelection>(this.AcceleratorCapabilities_Selection);
            }
            if (this.InstanceCapabilities_AllowedInstanceType != null)
            {
                context.InstanceCapabilities_AllowedInstanceType = new List<System.String>(this.InstanceCapabilities_AllowedInstanceType);
            }
            context.InstanceCapabilities_CpuArchitectureType = this.InstanceCapabilities_CpuArchitectureType;
            if (this.InstanceCapabilities_CustomAmount != null)
            {
                context.InstanceCapabilities_CustomAmount = new List<Amazon.Deadline.Model.FleetAmountCapability>(this.InstanceCapabilities_CustomAmount);
            }
            if (this.InstanceCapabilities_CustomAttribute != null)
            {
                context.InstanceCapabilities_CustomAttribute = new List<Amazon.Deadline.Model.FleetAttributeCapability>(this.InstanceCapabilities_CustomAttribute);
            }
            if (this.InstanceCapabilities_ExcludedInstanceType != null)
            {
                context.InstanceCapabilities_ExcludedInstanceType = new List<System.String>(this.InstanceCapabilities_ExcludedInstanceType);
            }
            context.Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max = this.Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max;
            context.Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min = this.Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min;
            context.InstanceCapabilities_OsFamily = this.InstanceCapabilities_OsFamily;
            context.RootEbsVolume_Iops = this.RootEbsVolume_Iops;
            context.RootEbsVolume_SizeGiB = this.RootEbsVolume_SizeGiB;
            context.RootEbsVolume_ThroughputMiB = this.RootEbsVolume_ThroughputMiB;
            context.Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max = this.Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max;
            context.Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min = this.Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min;
            context.InstanceMarketOptions_Type = this.InstanceMarketOptions_Type;
            context.ServiceManagedEc2_StorageProfileId = this.ServiceManagedEc2_StorageProfileId;
            if (this.VpcConfiguration_ResourceConfigurationArn != null)
            {
                context.VpcConfiguration_ResourceConfigurationArn = new List<System.String>(this.VpcConfiguration_ResourceConfigurationArn);
            }
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostConfiguration_ScriptBody = this.HostConfiguration_ScriptBody;
            context.HostConfiguration_ScriptTimeoutSecond = this.HostConfiguration_ScriptTimeoutSecond;
            context.MaxWorkerCount = this.MaxWorkerCount;
            context.MinWorkerCount = this.MinWorkerCount;
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.Deadline.Model.UpdateFleetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.Deadline.Model.FleetConfiguration();
            Amazon.Deadline.Model.CustomerManagedFleetConfiguration requestConfiguration_configuration_CustomerManaged = null;
            
             // populate CustomerManaged
            var requestConfiguration_configuration_CustomerManagedIsNull = true;
            requestConfiguration_configuration_CustomerManaged = new Amazon.Deadline.Model.CustomerManagedFleetConfiguration();
            Amazon.Deadline.AutoScalingMode requestConfiguration_configuration_CustomerManaged_customerManaged_Mode = null;
            if (cmdletContext.CustomerManaged_Mode != null)
            {
                requestConfiguration_configuration_CustomerManaged_customerManaged_Mode = cmdletContext.CustomerManaged_Mode;
            }
            if (requestConfiguration_configuration_CustomerManaged_customerManaged_Mode != null)
            {
                requestConfiguration_configuration_CustomerManaged.Mode = requestConfiguration_configuration_CustomerManaged_customerManaged_Mode;
                requestConfiguration_configuration_CustomerManagedIsNull = false;
            }
            System.String requestConfiguration_configuration_CustomerManaged_customerManaged_StorageProfileId = null;
            if (cmdletContext.CustomerManaged_StorageProfileId != null)
            {
                requestConfiguration_configuration_CustomerManaged_customerManaged_StorageProfileId = cmdletContext.CustomerManaged_StorageProfileId;
            }
            if (requestConfiguration_configuration_CustomerManaged_customerManaged_StorageProfileId != null)
            {
                requestConfiguration_configuration_CustomerManaged.StorageProfileId = requestConfiguration_configuration_CustomerManaged_customerManaged_StorageProfileId;
                requestConfiguration_configuration_CustomerManagedIsNull = false;
            }
            Amazon.Deadline.TagPropagationMode requestConfiguration_configuration_CustomerManaged_customerManaged_TagPropagationMode = null;
            if (cmdletContext.CustomerManaged_TagPropagationMode != null)
            {
                requestConfiguration_configuration_CustomerManaged_customerManaged_TagPropagationMode = cmdletContext.CustomerManaged_TagPropagationMode;
            }
            if (requestConfiguration_configuration_CustomerManaged_customerManaged_TagPropagationMode != null)
            {
                requestConfiguration_configuration_CustomerManaged.TagPropagationMode = requestConfiguration_configuration_CustomerManaged_customerManaged_TagPropagationMode;
                requestConfiguration_configuration_CustomerManagedIsNull = false;
            }
            Amazon.Deadline.Model.CustomerManagedWorkerCapabilities requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities = null;
            
             // populate WorkerCapabilities
            var requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = true;
            requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities = new Amazon.Deadline.Model.CustomerManagedWorkerCapabilities();
            List<System.String> requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_AcceleratorType = null;
            if (cmdletContext.WorkerCapabilities_AcceleratorType != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_AcceleratorType = cmdletContext.WorkerCapabilities_AcceleratorType;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_AcceleratorType != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities.AcceleratorTypes = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_AcceleratorType;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = false;
            }
            Amazon.Deadline.CpuArchitectureType requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CpuArchitectureType = null;
            if (cmdletContext.WorkerCapabilities_CpuArchitectureType != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CpuArchitectureType = cmdletContext.WorkerCapabilities_CpuArchitectureType;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CpuArchitectureType != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities.CpuArchitectureType = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CpuArchitectureType;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = false;
            }
            List<Amazon.Deadline.Model.FleetAmountCapability> requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CustomAmount = null;
            if (cmdletContext.WorkerCapabilities_CustomAmount != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CustomAmount = cmdletContext.WorkerCapabilities_CustomAmount;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CustomAmount != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities.CustomAmounts = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CustomAmount;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = false;
            }
            List<Amazon.Deadline.Model.FleetAttributeCapability> requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CustomAttribute = null;
            if (cmdletContext.WorkerCapabilities_CustomAttribute != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CustomAttribute = cmdletContext.WorkerCapabilities_CustomAttribute;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CustomAttribute != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities.CustomAttributes = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_CustomAttribute;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = false;
            }
            Amazon.Deadline.CustomerManagedFleetOperatingSystemFamily requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_OsFamily = null;
            if (cmdletContext.WorkerCapabilities_OsFamily != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_OsFamily = cmdletContext.WorkerCapabilities_OsFamily;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_OsFamily != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities.OsFamily = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_workerCapabilities_OsFamily;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = false;
            }
            Amazon.Deadline.Model.AcceleratorCountRange requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount = null;
            
             // populate AcceleratorCount
            var requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCountIsNull = true;
            requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount = new Amazon.Deadline.Model.AcceleratorCountRange();
            System.Int32? requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_acceleratorCount_Max = null;
            if (cmdletContext.AcceleratorCount_Max != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_acceleratorCount_Max = cmdletContext.AcceleratorCount_Max.Value;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_acceleratorCount_Max != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount.Max = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_acceleratorCount_Max.Value;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCountIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_acceleratorCount_Min = null;
            if (cmdletContext.AcceleratorCount_Min != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_acceleratorCount_Min = cmdletContext.AcceleratorCount_Min.Value;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_acceleratorCount_Min != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount.Min = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount_acceleratorCount_Min.Value;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCountIsNull = false;
            }
             // determine if requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount should be set to null
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCountIsNull)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount = null;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities.AcceleratorCount = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorCount;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = false;
            }
            Amazon.Deadline.Model.AcceleratorTotalMemoryMiBRange requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB = null;
            
             // populate AcceleratorTotalMemoryMiB
            var requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiBIsNull = true;
            requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB = new Amazon.Deadline.Model.AcceleratorTotalMemoryMiBRange();
            System.Int32? requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max = null;
            if (cmdletContext.AcceleratorTotalMemoryMiB_Max != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max = cmdletContext.AcceleratorTotalMemoryMiB_Max.Value;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB.Max = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Max.Value;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiBIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min = null;
            if (cmdletContext.AcceleratorTotalMemoryMiB_Min != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min = cmdletContext.AcceleratorTotalMemoryMiB_Min.Value;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB.Min = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB_acceleratorTotalMemoryMiB_Min.Value;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiBIsNull = false;
            }
             // determine if requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB should be set to null
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiBIsNull)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB = null;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities.AcceleratorTotalMemoryMiB = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_AcceleratorTotalMemoryMiB;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = false;
            }
            Amazon.Deadline.Model.MemoryMiBRange requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB = null;
            
             // populate MemoryMiB
            var requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiBIsNull = true;
            requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB = new Amazon.Deadline.Model.MemoryMiBRange();
            System.Int32? requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max = null;
            if (cmdletContext.Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max = cmdletContext.Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max.Value;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB.Max = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max.Value;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiBIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min = null;
            if (cmdletContext.Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min = cmdletContext.Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min.Value;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB.Min = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min.Value;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiBIsNull = false;
            }
             // determine if requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB should be set to null
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiBIsNull)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB = null;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities.MemoryMiB = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_MemoryMiB;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = false;
            }
            Amazon.Deadline.Model.VCpuCountRange requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount = null;
            
             // populate VCpuCount
            var requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCountIsNull = true;
            requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount = new Amazon.Deadline.Model.VCpuCountRange();
            System.Int32? requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max = null;
            if (cmdletContext.Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max = cmdletContext.Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max.Value;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount.Max = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max.Value;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCountIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min = null;
            if (cmdletContext.Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min = cmdletContext.Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min.Value;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount.Min = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min.Value;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCountIsNull = false;
            }
             // determine if requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount should be set to null
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCountIsNull)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount = null;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount != null)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities.VCpuCount = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities_configuration_CustomerManaged_WorkerCapabilities_VCpuCount;
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull = false;
            }
             // determine if requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities should be set to null
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilitiesIsNull)
            {
                requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities = null;
            }
            if (requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities != null)
            {
                requestConfiguration_configuration_CustomerManaged.WorkerCapabilities = requestConfiguration_configuration_CustomerManaged_configuration_CustomerManaged_WorkerCapabilities;
                requestConfiguration_configuration_CustomerManagedIsNull = false;
            }
             // determine if requestConfiguration_configuration_CustomerManaged should be set to null
            if (requestConfiguration_configuration_CustomerManagedIsNull)
            {
                requestConfiguration_configuration_CustomerManaged = null;
            }
            if (requestConfiguration_configuration_CustomerManaged != null)
            {
                request.Configuration.CustomerManaged = requestConfiguration_configuration_CustomerManaged;
                requestConfigurationIsNull = false;
            }
            Amazon.Deadline.Model.ServiceManagedEc2FleetConfiguration requestConfiguration_configuration_ServiceManagedEc2 = null;
            
             // populate ServiceManagedEc2
            var requestConfiguration_configuration_ServiceManagedEc2IsNull = true;
            requestConfiguration_configuration_ServiceManagedEc2 = new Amazon.Deadline.Model.ServiceManagedEc2FleetConfiguration();
            System.String requestConfiguration_configuration_ServiceManagedEc2_serviceManagedEc2_StorageProfileId = null;
            if (cmdletContext.ServiceManagedEc2_StorageProfileId != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_serviceManagedEc2_StorageProfileId = cmdletContext.ServiceManagedEc2_StorageProfileId;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_serviceManagedEc2_StorageProfileId != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2.StorageProfileId = requestConfiguration_configuration_ServiceManagedEc2_serviceManagedEc2_StorageProfileId;
                requestConfiguration_configuration_ServiceManagedEc2IsNull = false;
            }
            Amazon.Deadline.Model.ServiceManagedEc2InstanceMarketOptions requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions = null;
            
             // populate InstanceMarketOptions
            var requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptionsIsNull = true;
            requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions = new Amazon.Deadline.Model.ServiceManagedEc2InstanceMarketOptions();
            Amazon.Deadline.Ec2MarketType requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions_instanceMarketOptions_Type = null;
            if (cmdletContext.InstanceMarketOptions_Type != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions_instanceMarketOptions_Type = cmdletContext.InstanceMarketOptions_Type;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions_instanceMarketOptions_Type != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions.Type = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions_instanceMarketOptions_Type;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptionsIsNull = false;
            }
             // determine if requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions should be set to null
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptionsIsNull)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions = null;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2.InstanceMarketOptions = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceMarketOptions;
                requestConfiguration_configuration_ServiceManagedEc2IsNull = false;
            }
            Amazon.Deadline.Model.VpcConfiguration requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfigurationIsNull = true;
            requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration = new Amazon.Deadline.Model.VpcConfiguration();
            List<System.String> requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration_vpcConfiguration_ResourceConfigurationArn = null;
            if (cmdletContext.VpcConfiguration_ResourceConfigurationArn != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration_vpcConfiguration_ResourceConfigurationArn = cmdletContext.VpcConfiguration_ResourceConfigurationArn;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration_vpcConfiguration_ResourceConfigurationArn != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration.ResourceConfigurationArns = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration_vpcConfiguration_ResourceConfigurationArn;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration should be set to null
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfigurationIsNull)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration = null;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2.VpcConfiguration = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_VpcConfiguration;
                requestConfiguration_configuration_ServiceManagedEc2IsNull = false;
            }
            Amazon.Deadline.Model.ServiceManagedEc2InstanceCapabilities requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities = null;
            
             // populate InstanceCapabilities
            var requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = true;
            requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities = new Amazon.Deadline.Model.ServiceManagedEc2InstanceCapabilities();
            List<System.String> requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_AllowedInstanceType = null;
            if (cmdletContext.InstanceCapabilities_AllowedInstanceType != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_AllowedInstanceType = cmdletContext.InstanceCapabilities_AllowedInstanceType;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_AllowedInstanceType != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.AllowedInstanceTypes = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_AllowedInstanceType;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
            Amazon.Deadline.CpuArchitectureType requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CpuArchitectureType = null;
            if (cmdletContext.InstanceCapabilities_CpuArchitectureType != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CpuArchitectureType = cmdletContext.InstanceCapabilities_CpuArchitectureType;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CpuArchitectureType != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.CpuArchitectureType = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CpuArchitectureType;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
            List<Amazon.Deadline.Model.FleetAmountCapability> requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CustomAmount = null;
            if (cmdletContext.InstanceCapabilities_CustomAmount != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CustomAmount = cmdletContext.InstanceCapabilities_CustomAmount;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CustomAmount != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.CustomAmounts = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CustomAmount;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
            List<Amazon.Deadline.Model.FleetAttributeCapability> requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CustomAttribute = null;
            if (cmdletContext.InstanceCapabilities_CustomAttribute != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CustomAttribute = cmdletContext.InstanceCapabilities_CustomAttribute;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CustomAttribute != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.CustomAttributes = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_CustomAttribute;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_ExcludedInstanceType = null;
            if (cmdletContext.InstanceCapabilities_ExcludedInstanceType != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_ExcludedInstanceType = cmdletContext.InstanceCapabilities_ExcludedInstanceType;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_ExcludedInstanceType != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.ExcludedInstanceTypes = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_ExcludedInstanceType;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
            Amazon.Deadline.ServiceManagedFleetOperatingSystemFamily requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_OsFamily = null;
            if (cmdletContext.InstanceCapabilities_OsFamily != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_OsFamily = cmdletContext.InstanceCapabilities_OsFamily;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_OsFamily != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.OsFamily = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_instanceCapabilities_OsFamily;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
            Amazon.Deadline.Model.AcceleratorCapabilities requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities = null;
            
             // populate AcceleratorCapabilities
            var requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilitiesIsNull = true;
            requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities = new Amazon.Deadline.Model.AcceleratorCapabilities();
            List<Amazon.Deadline.Model.AcceleratorSelection> requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_acceleratorCapabilities_Selection = null;
            if (cmdletContext.AcceleratorCapabilities_Selection != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_acceleratorCapabilities_Selection = cmdletContext.AcceleratorCapabilities_Selection;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_acceleratorCapabilities_Selection != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities.Selections = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_acceleratorCapabilities_Selection;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilitiesIsNull = false;
            }
            Amazon.Deadline.Model.AcceleratorCountRange requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count = null;
            
             // populate Count
            var requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_CountIsNull = true;
            requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count = new Amazon.Deadline.Model.AcceleratorCountRange();
            System.Int32? requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_count_Max = null;
            if (cmdletContext.Count_Max != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_count_Max = cmdletContext.Count_Max.Value;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_count_Max != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count.Max = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_count_Max.Value;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_CountIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_count_Min = null;
            if (cmdletContext.Count_Min != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_count_Min = cmdletContext.Count_Min.Value;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_count_Min != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count.Min = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count_count_Min.Value;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_CountIsNull = false;
            }
             // determine if requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count should be set to null
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_CountIsNull)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count = null;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities.Count = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities_Count;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilitiesIsNull = false;
            }
             // determine if requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities should be set to null
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilitiesIsNull)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities = null;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.AcceleratorCapabilities = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_AcceleratorCapabilities;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
            Amazon.Deadline.Model.MemoryMiBRange requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB = null;
            
             // populate MemoryMiB
            var requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiBIsNull = true;
            requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB = new Amazon.Deadline.Model.MemoryMiBRange();
            System.Int32? requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max = null;
            if (cmdletContext.Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max = cmdletContext.Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max.Value;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB.Max = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max.Value;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiBIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min = null;
            if (cmdletContext.Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min = cmdletContext.Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min.Value;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB.Min = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min.Value;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiBIsNull = false;
            }
             // determine if requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB should be set to null
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiBIsNull)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB = null;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.MemoryMiB = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
            Amazon.Deadline.Model.VCpuCountRange requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount = null;
            
             // populate VCpuCount
            var requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCountIsNull = true;
            requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount = new Amazon.Deadline.Model.VCpuCountRange();
            System.Int32? requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max = null;
            if (cmdletContext.Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max = cmdletContext.Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max.Value;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount.Max = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max.Value;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCountIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min = null;
            if (cmdletContext.Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min = cmdletContext.Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min.Value;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount.Min = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min.Value;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCountIsNull = false;
            }
             // determine if requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount should be set to null
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCountIsNull)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount = null;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.VCpuCount = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
            Amazon.Deadline.Model.Ec2EbsVolume requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume = null;
            
             // populate RootEbsVolume
            var requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolumeIsNull = true;
            requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume = new Amazon.Deadline.Model.Ec2EbsVolume();
            System.Int32? requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_Iops = null;
            if (cmdletContext.RootEbsVolume_Iops != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_Iops = cmdletContext.RootEbsVolume_Iops.Value;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_Iops != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume.Iops = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_Iops.Value;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolumeIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_SizeGiB = null;
            if (cmdletContext.RootEbsVolume_SizeGiB != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_SizeGiB = cmdletContext.RootEbsVolume_SizeGiB.Value;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_SizeGiB != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume.SizeGiB = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_SizeGiB.Value;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolumeIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_ThroughputMiB = null;
            if (cmdletContext.RootEbsVolume_ThroughputMiB != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_ThroughputMiB = cmdletContext.RootEbsVolume_ThroughputMiB.Value;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_ThroughputMiB != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume.ThroughputMiB = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume_rootEbsVolume_ThroughputMiB.Value;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolumeIsNull = false;
            }
             // determine if requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume should be set to null
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolumeIsNull)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume = null;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities.RootEbsVolume = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities_configuration_ServiceManagedEc2_InstanceCapabilities_RootEbsVolume;
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull = false;
            }
             // determine if requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities should be set to null
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilitiesIsNull)
            {
                requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities = null;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities != null)
            {
                requestConfiguration_configuration_ServiceManagedEc2.InstanceCapabilities = requestConfiguration_configuration_ServiceManagedEc2_configuration_ServiceManagedEc2_InstanceCapabilities;
                requestConfiguration_configuration_ServiceManagedEc2IsNull = false;
            }
             // determine if requestConfiguration_configuration_ServiceManagedEc2 should be set to null
            if (requestConfiguration_configuration_ServiceManagedEc2IsNull)
            {
                requestConfiguration_configuration_ServiceManagedEc2 = null;
            }
            if (requestConfiguration_configuration_ServiceManagedEc2 != null)
            {
                request.Configuration.ServiceManagedEc2 = requestConfiguration_configuration_ServiceManagedEc2;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.FarmId != null)
            {
                request.FarmId = cmdletContext.FarmId;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            
             // populate HostConfiguration
            var requestHostConfigurationIsNull = true;
            request.HostConfiguration = new Amazon.Deadline.Model.HostConfiguration();
            System.String requestHostConfiguration_hostConfiguration_ScriptBody = null;
            if (cmdletContext.HostConfiguration_ScriptBody != null)
            {
                requestHostConfiguration_hostConfiguration_ScriptBody = cmdletContext.HostConfiguration_ScriptBody;
            }
            if (requestHostConfiguration_hostConfiguration_ScriptBody != null)
            {
                request.HostConfiguration.ScriptBody = requestHostConfiguration_hostConfiguration_ScriptBody;
                requestHostConfigurationIsNull = false;
            }
            System.Int32? requestHostConfiguration_hostConfiguration_ScriptTimeoutSecond = null;
            if (cmdletContext.HostConfiguration_ScriptTimeoutSecond != null)
            {
                requestHostConfiguration_hostConfiguration_ScriptTimeoutSecond = cmdletContext.HostConfiguration_ScriptTimeoutSecond.Value;
            }
            if (requestHostConfiguration_hostConfiguration_ScriptTimeoutSecond != null)
            {
                request.HostConfiguration.ScriptTimeoutSeconds = requestHostConfiguration_hostConfiguration_ScriptTimeoutSecond.Value;
                requestHostConfigurationIsNull = false;
            }
             // determine if request.HostConfiguration should be set to null
            if (requestHostConfigurationIsNull)
            {
                request.HostConfiguration = null;
            }
            if (cmdletContext.MaxWorkerCount != null)
            {
                request.MaxWorkerCount = cmdletContext.MaxWorkerCount.Value;
            }
            if (cmdletContext.MinWorkerCount != null)
            {
                request.MinWorkerCount = cmdletContext.MinWorkerCount.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Deadline.Model.UpdateFleetResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.UpdateFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "UpdateFleet");
            try
            {
                #if DESKTOP
                return client.UpdateFleet(request);
                #elif CORECLR
                return client.UpdateFleetAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Deadline.AutoScalingMode CustomerManaged_Mode { get; set; }
            public System.String CustomerManaged_StorageProfileId { get; set; }
            public Amazon.Deadline.TagPropagationMode CustomerManaged_TagPropagationMode { get; set; }
            public System.Int32? AcceleratorCount_Max { get; set; }
            public System.Int32? AcceleratorCount_Min { get; set; }
            public System.Int32? AcceleratorTotalMemoryMiB_Max { get; set; }
            public System.Int32? AcceleratorTotalMemoryMiB_Min { get; set; }
            public List<System.String> WorkerCapabilities_AcceleratorType { get; set; }
            public Amazon.Deadline.CpuArchitectureType WorkerCapabilities_CpuArchitectureType { get; set; }
            public List<Amazon.Deadline.Model.FleetAmountCapability> WorkerCapabilities_CustomAmount { get; set; }
            public List<Amazon.Deadline.Model.FleetAttributeCapability> WorkerCapabilities_CustomAttribute { get; set; }
            public System.Int32? Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Max { get; set; }
            public System.Int32? Configuration_CustomerManaged_WorkerCapabilities_MemoryMiB_Min { get; set; }
            public Amazon.Deadline.CustomerManagedFleetOperatingSystemFamily WorkerCapabilities_OsFamily { get; set; }
            public System.Int32? Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Max { get; set; }
            public System.Int32? Configuration_CustomerManaged_WorkerCapabilities_VCpuCount_Min { get; set; }
            public System.Int32? Count_Max { get; set; }
            public System.Int32? Count_Min { get; set; }
            public List<Amazon.Deadline.Model.AcceleratorSelection> AcceleratorCapabilities_Selection { get; set; }
            public List<System.String> InstanceCapabilities_AllowedInstanceType { get; set; }
            public Amazon.Deadline.CpuArchitectureType InstanceCapabilities_CpuArchitectureType { get; set; }
            public List<Amazon.Deadline.Model.FleetAmountCapability> InstanceCapabilities_CustomAmount { get; set; }
            public List<Amazon.Deadline.Model.FleetAttributeCapability> InstanceCapabilities_CustomAttribute { get; set; }
            public List<System.String> InstanceCapabilities_ExcludedInstanceType { get; set; }
            public System.Int32? Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Max { get; set; }
            public System.Int32? Configuration_ServiceManagedEc2_InstanceCapabilities_MemoryMiB_Min { get; set; }
            public Amazon.Deadline.ServiceManagedFleetOperatingSystemFamily InstanceCapabilities_OsFamily { get; set; }
            public System.Int32? RootEbsVolume_Iops { get; set; }
            public System.Int32? RootEbsVolume_SizeGiB { get; set; }
            public System.Int32? RootEbsVolume_ThroughputMiB { get; set; }
            public System.Int32? Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Max { get; set; }
            public System.Int32? Configuration_ServiceManagedEc2_InstanceCapabilities_VCpuCount_Min { get; set; }
            public Amazon.Deadline.Ec2MarketType InstanceMarketOptions_Type { get; set; }
            public System.String ServiceManagedEc2_StorageProfileId { get; set; }
            public List<System.String> VpcConfiguration_ResourceConfigurationArn { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String FarmId { get; set; }
            public System.String FleetId { get; set; }
            public System.String HostConfiguration_ScriptBody { get; set; }
            public System.Int32? HostConfiguration_ScriptTimeoutSecond { get; set; }
            public System.Int32? MaxWorkerCount { get; set; }
            public System.Int32? MinWorkerCount { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.Deadline.Model.UpdateFleetResponse, UpdateADCFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
