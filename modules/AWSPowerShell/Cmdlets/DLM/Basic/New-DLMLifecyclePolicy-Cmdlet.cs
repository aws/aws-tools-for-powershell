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
using Amazon.DLM;
using Amazon.DLM.Model;

namespace Amazon.PowerShell.Cmdlets.DLM
{
    /// <summary>
    /// Creates an Amazon Data Lifecycle Manager lifecycle policy. Amazon Data Lifecycle Manager
    /// supports the following policy types:
    /// 
    ///  <ul><li><para>
    /// Custom EBS snapshot policy
    /// </para></li><li><para>
    /// Custom EBS-backed AMI policy
    /// </para></li><li><para>
    /// Cross-account copy event policy
    /// </para></li><li><para>
    /// Default policy for EBS snapshots
    /// </para></li><li><para>
    /// Default policy for EBS-backed AMIs
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/policy-differences.html">
    /// Default policies vs custom policies</a>.
    /// </para><important><para>
    /// If you create a default policy, you can specify the request parameters either in the
    /// request body, or in the PolicyDetails request structure, but not both.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "DLMLifecyclePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Data Lifecycle Manager CreateLifecyclePolicy API operation.", Operation = new[] {"CreateLifecyclePolicy"}, SelectReturnType = typeof(Amazon.DLM.Model.CreateLifecyclePolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.DLM.Model.CreateLifecyclePolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DLM.Model.CreateLifecyclePolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDLMLifecyclePolicyCmdlet : AmazonDLMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PolicyDetails_Action
        /// <summary>
        /// <para>
        /// <para><b>[Event-based policies only]</b> The actions to be performed when the event-based
        /// policy is activated. You can specify only one action per policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_Actions")]
        public Amazon.DLM.Model.Action[] PolicyDetails_Action { get; set; }
        #endregion
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Indicates whether the policy should copy tags from
        /// the source resource to the snapshot or AMI. If you do not specify a value, the default
        /// is <c>false</c>.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyTags")]
        public System.Boolean? CopyTag { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_CopyTag
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Indicates whether the policy should copy tags from
        /// the source resource to the snapshot or AMI. If you do not specify a value, the default
        /// is <c>false</c>.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_CopyTags")]
        public System.Boolean? PolicyDetails_CopyTag { get; set; }
        #endregion
        
        #region Parameter CreateInterval
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Specifies how often the policy should run and create
        /// snapshots or AMIs. The creation frequency can range from 1 to 7 days. If you do not
        /// specify a value, the default is 1.</para><para>Default: 1</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CreateInterval { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_CreateInterval
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Specifies how often the policy should run and create
        /// snapshots or AMIs. The creation frequency can range from 1 to 7 days. If you do not
        /// specify a value, the default is 1.</para><para>Default: 1</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PolicyDetails_CreateInterval { get; set; }
        #endregion
        
        #region Parameter CrossRegionCopyTarget
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Specifies destination Regions for snapshot or AMI
        /// copies. You can specify up to 3 destination Regions. If you do not want to create
        /// cross-Region copies, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CrossRegionCopyTargets")]
        public Amazon.DLM.Model.CrossRegionCopyTarget[] CrossRegionCopyTarget { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_CrossRegionCopyTarget
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Specifies destination Regions for snapshot or AMI
        /// copies. You can specify up to 3 destination Regions. If you do not want to create
        /// cross-Region copies, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_CrossRegionCopyTargets")]
        public Amazon.DLM.Model.CrossRegionCopyTarget[] PolicyDetails_CrossRegionCopyTarget { get; set; }
        #endregion
        
        #region Parameter DefaultPolicy
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Specify the type of default policy to create.</para><ul><li><para>To create a default policy for EBS snapshots, that creates snapshots of all volumes
        /// in the Region that do not have recent backups, specify <c>VOLUME</c>.</para></li><li><para>To create a default policy for EBS-backed AMIs, that creates EBS-backed AMIs from
        /// all instances in the Region that do not have recent backups, specify <c>INSTANCE</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DLM.DefaultPolicyTypeValues")]
        public Amazon.DLM.DefaultPolicyTypeValues DefaultPolicy { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the lifecycle policy. The characters ^[0-9A-Za-z _-]+$ are supported.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Parameters_DescriptionRegex
        /// <summary>
        /// <para>
        /// <para>The snapshot description that can trigger the policy. The description pattern is specified
        /// using a regular expression. The policy runs only if a snapshot with a description
        /// that matches the specified pattern is shared with your account.</para><para>For example, specifying <c>^.*Created for policy: policy-1234567890abcdef0.*$</c>
        /// configures the policy to run only if snapshots created by policy <c>policy-1234567890abcdef0</c>
        /// are shared with your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_EventSource_Parameters_DescriptionRegex")]
        public System.String Parameters_DescriptionRegex { get; set; }
        #endregion
        
        #region Parameter Parameters_EventType
        /// <summary>
        /// <para>
        /// <para>The type of event. Currently, only snapshot sharing events are supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_EventSource_Parameters_EventType")]
        [AWSConstantClassSource("Amazon.DLM.EventTypeValues")]
        public Amazon.DLM.EventTypeValues Parameters_EventType { get; set; }
        #endregion
        
        #region Parameter Parameters_ExcludeBootVolume
        /// <summary>
        /// <para>
        /// <para><b>[Custom snapshot policies that target instances only]</b> Indicates whether to
        /// exclude the root volume from multi-volume snapshot sets. The default is <c>false</c>.
        /// If you specify <c>true</c>, then the root volumes attached to targeted instances will
        /// be excluded from the multi-volume snapshot sets created by the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_Parameters_ExcludeBootVolume")]
        public System.Boolean? Parameters_ExcludeBootVolume { get; set; }
        #endregion
        
        #region Parameter Exclusions_ExcludeBootVolume
        /// <summary>
        /// <para>
        /// <para><b>[Default policies for EBS snapshots only]</b> Indicates whether to exclude volumes
        /// that are attached to instances as the boot volume. If you exclude boot volumes, only
        /// volumes attached as data (non-boot) volumes will be backed up by the policy. To exclude
        /// boot volumes, specify <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Exclusions_ExcludeBootVolumes")]
        public System.Boolean? Exclusions_ExcludeBootVolume { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_Exclusions_ExcludeBootVolumes
        /// <summary>
        /// <para>
        /// <para><b>[Default policies for EBS snapshots only]</b> Indicates whether to exclude volumes
        /// that are attached to instances as the boot volume. If you exclude boot volumes, only
        /// volumes attached as data (non-boot) volumes will be backed up by the policy. To exclude
        /// boot volumes, specify <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PolicyDetails_Exclusions_ExcludeBootVolumes { get; set; }
        #endregion
        
        #region Parameter Parameters_ExcludeDataVolumeTag
        /// <summary>
        /// <para>
        /// <para><b>[Custom snapshot policies that target instances only]</b> The tags used to identify
        /// data (non-root) volumes to exclude from multi-volume snapshot sets.</para><para>If you create a snapshot lifecycle policy that targets instances and you specify tags
        /// for this parameter, then data volumes with the specified tags that are attached to
        /// targeted instances will be excluded from the multi-volume snapshot sets created by
        /// the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_Parameters_ExcludeDataVolumeTags")]
        public Amazon.DLM.Model.Tag[] Parameters_ExcludeDataVolumeTag { get; set; }
        #endregion
        
        #region Parameter Exclusions_ExcludeTag
        /// <summary>
        /// <para>
        /// <para><b>[Default policies for EBS-backed AMIs only]</b> Specifies whether to exclude volumes
        /// that have specific tags. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Exclusions_ExcludeTags")]
        public Amazon.DLM.Model.Tag[] Exclusions_ExcludeTag { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_Exclusions_ExcludeTags
        /// <summary>
        /// <para>
        /// <para><b>[Default policies for EBS-backed AMIs only]</b> Specifies whether to exclude volumes
        /// that have specific tags. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DLM.Model.Tag[] PolicyDetails_Exclusions_ExcludeTags { get; set; }
        #endregion
        
        #region Parameter Exclusions_ExcludeVolumeType
        /// <summary>
        /// <para>
        /// <para><b>[Default policies for EBS snapshots only]</b> Specifies the volume types to exclude.
        /// Volumes of the specified types will not be targeted by the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Exclusions_ExcludeVolumeTypes")]
        public System.String[] Exclusions_ExcludeVolumeType { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_Exclusions_ExcludeVolumeTypes
        /// <summary>
        /// <para>
        /// <para><b>[Default policies for EBS snapshots only]</b> Specifies the volume types to exclude.
        /// Volumes of the specified types will not be targeted by the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PolicyDetails_Exclusions_ExcludeVolumeTypes { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role used to run the operations specified
        /// by the lifecycle policy.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ExtendDeletion
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Defines the snapshot or AMI retention behavior for
        /// the policy if the source volume or instance is deleted, or if the policy enters the
        /// error, disabled, or deleted state.</para><para>By default (<b>ExtendDeletion=false</b>):</para><ul><li><para>If a source resource is deleted, Amazon Data Lifecycle Manager will continue to delete
        /// previously created snapshots or AMIs, up to but not including the last one, based
        /// on the specified retention period. If you want Amazon Data Lifecycle Manager to delete
        /// all snapshots or AMIs, including the last one, specify <c>true</c>.</para></li><li><para>If a policy enters the error, disabled, or deleted state, Amazon Data Lifecycle Manager
        /// stops deleting snapshots and AMIs. If you want Amazon Data Lifecycle Manager to continue
        /// deleting snapshots or AMIs, including the last one, if the policy enters one of these
        /// states, specify <c>true</c>.</para></li></ul><para>If you enable extended deletion (<b>ExtendDeletion=true</b>), you override both default
        /// behaviors simultaneously.</para><para>If you do not specify a value, the default is <c>false</c>.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExtendDeletion { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_ExtendDeletion
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Defines the snapshot or AMI retention behavior for
        /// the policy if the source volume or instance is deleted, or if the policy enters the
        /// error, disabled, or deleted state.</para><para>By default (<b>ExtendDeletion=false</b>):</para><ul><li><para>If a source resource is deleted, Amazon Data Lifecycle Manager will continue to delete
        /// previously created snapshots or AMIs, up to but not including the last one, based
        /// on the specified retention period. If you want Amazon Data Lifecycle Manager to delete
        /// all snapshots or AMIs, including the last one, specify <c>true</c>.</para></li><li><para>If a policy enters the error, disabled, or deleted state, Amazon Data Lifecycle Manager
        /// stops deleting snapshots and AMIs. If you want Amazon Data Lifecycle Manager to continue
        /// deleting snapshots or AMIs, including the last one, if the policy enters one of these
        /// states, specify <c>true</c>.</para></li></ul><para>If you enable extended deletion (<b>ExtendDeletion=true</b>), you override both default
        /// behaviors simultaneously.</para><para>If you do not specify a value, the default is <c>false</c>.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PolicyDetails_ExtendDeletion { get; set; }
        #endregion
        
        #region Parameter Parameters_NoReboot
        /// <summary>
        /// <para>
        /// <para><b>[Custom AMI policies only]</b> Indicates whether targeted instances are rebooted
        /// when the lifecycle policy runs. <c>true</c> indicates that targeted instances are
        /// not rebooted when the policy runs. <c>false</c> indicates that target instances are
        /// rebooted when the policy runs. The default is <c>true</c> (instances are not rebooted).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_Parameters_NoReboot")]
        public System.Boolean? Parameters_NoReboot { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_PolicyLanguage
        /// <summary>
        /// <para>
        /// <para>The type of policy to create. Specify one of the following:</para><ul><li><para><c>SIMPLIFIED</c> To create a default policy.</para></li><li><para><c>STANDARD</c> To create a custom policy.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DLM.PolicyLanguageValues")]
        public Amazon.DLM.PolicyLanguageValues PolicyDetails_PolicyLanguage { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_PolicyType
        /// <summary>
        /// <para>
        /// <para><b>[Custom policies only]</b> The valid target resource types and actions a policy
        /// can manage. Specify <c>EBS_SNAPSHOT_MANAGEMENT</c> to create a lifecycle policy that
        /// manages the lifecycle of Amazon EBS snapshots. Specify <c>IMAGE_MANAGEMENT</c> to
        /// create a lifecycle policy that manages the lifecycle of EBS-backed AMIs. Specify <c>EVENT_BASED_POLICY
        /// </c> to create an event-based policy that performs specific actions when a defined
        /// event occurs in your Amazon Web Services account.</para><para>The default is <c>EBS_SNAPSHOT_MANAGEMENT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DLM.PolicyTypeValues")]
        public Amazon.DLM.PolicyTypeValues PolicyDetails_PolicyType { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_ResourceLocation
        /// <summary>
        /// <para>
        /// <para><b>[Custom snapshot and AMI policies only]</b> The location of the resources to backup.
        /// If the source resources are located in an Amazon Web Services Region, specify <c>CLOUD</c>.
        /// If the source resources are located on an Outpost in your account, specify <c>OUTPOST</c>.</para><para>If you specify <c>OUTPOST</c>, Amazon Data Lifecycle Manager backs up all resources
        /// of the specified type with matching target tags across all of the Outposts in your
        /// account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_ResourceLocations")]
        public System.String[] PolicyDetails_ResourceLocation { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_SimplifiedResourceType
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Specify the type of default policy to create.</para><ul><li><para>To create a default policy for EBS snapshots, that creates snapshots of all volumes
        /// in the Region that do not have recent backups, specify <c>VOLUME</c>.</para></li><li><para>To create a default policy for EBS-backed AMIs, that creates EBS-backed AMIs from
        /// all instances in the Region that do not have recent backups, specify <c>INSTANCE</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DLM.ResourceTypeValues")]
        public Amazon.DLM.ResourceTypeValues PolicyDetails_SimplifiedResourceType { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_ResourceType
        /// <summary>
        /// <para>
        /// <para><b>[Custom snapshot policies only]</b> The target resource type for snapshot and
        /// AMI lifecycle policies. Use <c>VOLUME </c>to create snapshots of individual volumes
        /// or use <c>INSTANCE</c> to create multi-volume snapshots from the volumes for an instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_ResourceTypes")]
        public System.String[] PolicyDetails_ResourceType { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_RetainInterval
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Specifies how long the policy should retain snapshots
        /// or AMIs before deleting them. The retention period can range from 2 to 14 days, but
        /// it must be greater than the creation frequency to ensure that the policy retains at
        /// least 1 snapshot or AMI at any given time. If you do not specify a value, the default
        /// is 7.</para><para>Default: 7</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PolicyDetails_RetainInterval { get; set; }
        #endregion
        
        #region Parameter RetainInterval
        /// <summary>
        /// <para>
        /// <para><b>[Default policies only]</b> Specifies how long the policy should retain snapshots
        /// or AMIs before deleting them. The retention period can range from 2 to 14 days, but
        /// it must be greater than the creation frequency to ensure that the policy retains at
        /// least 1 snapshot or AMI at any given time. If you do not specify a value, the default
        /// is 7.</para><para>Default: 7</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RetainInterval { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_Schedule
        /// <summary>
        /// <para>
        /// <para><b>[Custom snapshot and AMI policies only]</b> The schedules of policy-defined actions
        /// for snapshot and AMI lifecycle policies. A policy can have up to four schedules—one
        /// mandatory schedule and up to three optional schedules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_Schedules")]
        public Amazon.DLM.Model.Schedule[] PolicyDetails_Schedule { get; set; }
        #endregion
        
        #region Parameter Parameters_SnapshotOwner
        /// <summary>
        /// <para>
        /// <para>The IDs of the Amazon Web Services accounts that can trigger policy by sharing snapshots
        /// with your account. The policy only runs if one of the specified Amazon Web Services
        /// accounts shares a snapshot with your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_EventSource_Parameters_SnapshotOwner")]
        public System.String[] Parameters_SnapshotOwner { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The activation state of the lifecycle policy after creation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DLM.SettablePolicyStateValues")]
        public Amazon.DLM.SettablePolicyStateValues State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the lifecycle policy during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter PolicyDetails_TargetTag
        /// <summary>
        /// <para>
        /// <para><b>[Custom snapshot and AMI policies only]</b> The single tag that identifies targeted
        /// resources for this policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_TargetTags")]
        public Amazon.DLM.Model.Tag[] PolicyDetails_TargetTag { get; set; }
        #endregion
        
        #region Parameter EventSource_Type
        /// <summary>
        /// <para>
        /// <para>The source of the event. Currently only managed CloudWatch Events rules are supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyDetails_EventSource_Type")]
        [AWSConstantClassSource("Amazon.DLM.EventSourceValues")]
        public Amazon.DLM.EventSourceValues EventSource_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PolicyId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DLM.Model.CreateLifecyclePolicyResponse).
        /// Specifying the name of a property of type Amazon.DLM.Model.CreateLifecyclePolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PolicyId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExecutionRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DLMLifecyclePolicy (CreateLifecyclePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DLM.Model.CreateLifecyclePolicyResponse, NewDLMLifecyclePolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CopyTag = this.CopyTag;
            context.CreateInterval = this.CreateInterval;
            if (this.CrossRegionCopyTarget != null)
            {
                context.CrossRegionCopyTarget = new List<Amazon.DLM.Model.CrossRegionCopyTarget>(this.CrossRegionCopyTarget);
            }
            context.DefaultPolicy = this.DefaultPolicy;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Exclusions_ExcludeBootVolume = this.Exclusions_ExcludeBootVolume;
            if (this.Exclusions_ExcludeTag != null)
            {
                context.Exclusions_ExcludeTag = new List<Amazon.DLM.Model.Tag>(this.Exclusions_ExcludeTag);
            }
            if (this.Exclusions_ExcludeVolumeType != null)
            {
                context.Exclusions_ExcludeVolumeType = new List<System.String>(this.Exclusions_ExcludeVolumeType);
            }
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExtendDeletion = this.ExtendDeletion;
            if (this.PolicyDetails_Action != null)
            {
                context.PolicyDetails_Action = new List<Amazon.DLM.Model.Action>(this.PolicyDetails_Action);
            }
            context.PolicyDetails_CopyTag = this.PolicyDetails_CopyTag;
            context.PolicyDetails_CreateInterval = this.PolicyDetails_CreateInterval;
            if (this.PolicyDetails_CrossRegionCopyTarget != null)
            {
                context.PolicyDetails_CrossRegionCopyTarget = new List<Amazon.DLM.Model.CrossRegionCopyTarget>(this.PolicyDetails_CrossRegionCopyTarget);
            }
            context.Parameters_DescriptionRegex = this.Parameters_DescriptionRegex;
            context.Parameters_EventType = this.Parameters_EventType;
            if (this.Parameters_SnapshotOwner != null)
            {
                context.Parameters_SnapshotOwner = new List<System.String>(this.Parameters_SnapshotOwner);
            }
            context.EventSource_Type = this.EventSource_Type;
            context.PolicyDetails_Exclusions_ExcludeBootVolumes = this.PolicyDetails_Exclusions_ExcludeBootVolumes;
            if (this.PolicyDetails_Exclusions_ExcludeTags != null)
            {
                context.PolicyDetails_Exclusions_ExcludeTags = new List<Amazon.DLM.Model.Tag>(this.PolicyDetails_Exclusions_ExcludeTags);
            }
            if (this.PolicyDetails_Exclusions_ExcludeVolumeTypes != null)
            {
                context.PolicyDetails_Exclusions_ExcludeVolumeTypes = new List<System.String>(this.PolicyDetails_Exclusions_ExcludeVolumeTypes);
            }
            context.PolicyDetails_ExtendDeletion = this.PolicyDetails_ExtendDeletion;
            context.Parameters_ExcludeBootVolume = this.Parameters_ExcludeBootVolume;
            if (this.Parameters_ExcludeDataVolumeTag != null)
            {
                context.Parameters_ExcludeDataVolumeTag = new List<Amazon.DLM.Model.Tag>(this.Parameters_ExcludeDataVolumeTag);
            }
            context.Parameters_NoReboot = this.Parameters_NoReboot;
            context.PolicyDetails_PolicyLanguage = this.PolicyDetails_PolicyLanguage;
            context.PolicyDetails_PolicyType = this.PolicyDetails_PolicyType;
            if (this.PolicyDetails_ResourceLocation != null)
            {
                context.PolicyDetails_ResourceLocation = new List<System.String>(this.PolicyDetails_ResourceLocation);
            }
            context.PolicyDetails_SimplifiedResourceType = this.PolicyDetails_SimplifiedResourceType;
            if (this.PolicyDetails_ResourceType != null)
            {
                context.PolicyDetails_ResourceType = new List<System.String>(this.PolicyDetails_ResourceType);
            }
            context.PolicyDetails_RetainInterval = this.PolicyDetails_RetainInterval;
            if (this.PolicyDetails_Schedule != null)
            {
                context.PolicyDetails_Schedule = new List<Amazon.DLM.Model.Schedule>(this.PolicyDetails_Schedule);
            }
            if (this.PolicyDetails_TargetTag != null)
            {
                context.PolicyDetails_TargetTag = new List<Amazon.DLM.Model.Tag>(this.PolicyDetails_TargetTag);
            }
            context.RetainInterval = this.RetainInterval;
            context.State = this.State;
            #if MODULAR
            if (this.State == null && ParameterWasBound(nameof(this.State)))
            {
                WriteWarning("You are passing $null as a value for parameter State which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.DLM.Model.CreateLifecyclePolicyRequest();
            
            if (cmdletContext.CopyTag != null)
            {
                request.CopyTags = cmdletContext.CopyTag.Value;
            }
            if (cmdletContext.CreateInterval != null)
            {
                request.CreateInterval = cmdletContext.CreateInterval.Value;
            }
            if (cmdletContext.CrossRegionCopyTarget != null)
            {
                request.CrossRegionCopyTargets = cmdletContext.CrossRegionCopyTarget;
            }
            if (cmdletContext.DefaultPolicy != null)
            {
                request.DefaultPolicy = cmdletContext.DefaultPolicy;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Exclusions
            var requestExclusionsIsNull = true;
            request.Exclusions = new Amazon.DLM.Model.Exclusions();
            System.Boolean? requestExclusions_exclusions_ExcludeBootVolume = null;
            if (cmdletContext.Exclusions_ExcludeBootVolume != null)
            {
                requestExclusions_exclusions_ExcludeBootVolume = cmdletContext.Exclusions_ExcludeBootVolume.Value;
            }
            if (requestExclusions_exclusions_ExcludeBootVolume != null)
            {
                request.Exclusions.ExcludeBootVolumes = requestExclusions_exclusions_ExcludeBootVolume.Value;
                requestExclusionsIsNull = false;
            }
            List<Amazon.DLM.Model.Tag> requestExclusions_exclusions_ExcludeTag = null;
            if (cmdletContext.Exclusions_ExcludeTag != null)
            {
                requestExclusions_exclusions_ExcludeTag = cmdletContext.Exclusions_ExcludeTag;
            }
            if (requestExclusions_exclusions_ExcludeTag != null)
            {
                request.Exclusions.ExcludeTags = requestExclusions_exclusions_ExcludeTag;
                requestExclusionsIsNull = false;
            }
            List<System.String> requestExclusions_exclusions_ExcludeVolumeType = null;
            if (cmdletContext.Exclusions_ExcludeVolumeType != null)
            {
                requestExclusions_exclusions_ExcludeVolumeType = cmdletContext.Exclusions_ExcludeVolumeType;
            }
            if (requestExclusions_exclusions_ExcludeVolumeType != null)
            {
                request.Exclusions.ExcludeVolumeTypes = requestExclusions_exclusions_ExcludeVolumeType;
                requestExclusionsIsNull = false;
            }
             // determine if request.Exclusions should be set to null
            if (requestExclusionsIsNull)
            {
                request.Exclusions = null;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.ExtendDeletion != null)
            {
                request.ExtendDeletion = cmdletContext.ExtendDeletion.Value;
            }
            
             // populate PolicyDetails
            var requestPolicyDetailsIsNull = true;
            request.PolicyDetails = new Amazon.DLM.Model.PolicyDetails();
            List<Amazon.DLM.Model.Action> requestPolicyDetails_policyDetails_Action = null;
            if (cmdletContext.PolicyDetails_Action != null)
            {
                requestPolicyDetails_policyDetails_Action = cmdletContext.PolicyDetails_Action;
            }
            if (requestPolicyDetails_policyDetails_Action != null)
            {
                request.PolicyDetails.Actions = requestPolicyDetails_policyDetails_Action;
                requestPolicyDetailsIsNull = false;
            }
            System.Boolean? requestPolicyDetails_policyDetails_CopyTag = null;
            if (cmdletContext.PolicyDetails_CopyTag != null)
            {
                requestPolicyDetails_policyDetails_CopyTag = cmdletContext.PolicyDetails_CopyTag.Value;
            }
            if (requestPolicyDetails_policyDetails_CopyTag != null)
            {
                request.PolicyDetails.CopyTags = requestPolicyDetails_policyDetails_CopyTag.Value;
                requestPolicyDetailsIsNull = false;
            }
            System.Int32? requestPolicyDetails_policyDetails_CreateInterval = null;
            if (cmdletContext.PolicyDetails_CreateInterval != null)
            {
                requestPolicyDetails_policyDetails_CreateInterval = cmdletContext.PolicyDetails_CreateInterval.Value;
            }
            if (requestPolicyDetails_policyDetails_CreateInterval != null)
            {
                request.PolicyDetails.CreateInterval = requestPolicyDetails_policyDetails_CreateInterval.Value;
                requestPolicyDetailsIsNull = false;
            }
            List<Amazon.DLM.Model.CrossRegionCopyTarget> requestPolicyDetails_policyDetails_CrossRegionCopyTarget = null;
            if (cmdletContext.PolicyDetails_CrossRegionCopyTarget != null)
            {
                requestPolicyDetails_policyDetails_CrossRegionCopyTarget = cmdletContext.PolicyDetails_CrossRegionCopyTarget;
            }
            if (requestPolicyDetails_policyDetails_CrossRegionCopyTarget != null)
            {
                request.PolicyDetails.CrossRegionCopyTargets = requestPolicyDetails_policyDetails_CrossRegionCopyTarget;
                requestPolicyDetailsIsNull = false;
            }
            System.Boolean? requestPolicyDetails_policyDetails_ExtendDeletion = null;
            if (cmdletContext.PolicyDetails_ExtendDeletion != null)
            {
                requestPolicyDetails_policyDetails_ExtendDeletion = cmdletContext.PolicyDetails_ExtendDeletion.Value;
            }
            if (requestPolicyDetails_policyDetails_ExtendDeletion != null)
            {
                request.PolicyDetails.ExtendDeletion = requestPolicyDetails_policyDetails_ExtendDeletion.Value;
                requestPolicyDetailsIsNull = false;
            }
            Amazon.DLM.PolicyLanguageValues requestPolicyDetails_policyDetails_PolicyLanguage = null;
            if (cmdletContext.PolicyDetails_PolicyLanguage != null)
            {
                requestPolicyDetails_policyDetails_PolicyLanguage = cmdletContext.PolicyDetails_PolicyLanguage;
            }
            if (requestPolicyDetails_policyDetails_PolicyLanguage != null)
            {
                request.PolicyDetails.PolicyLanguage = requestPolicyDetails_policyDetails_PolicyLanguage;
                requestPolicyDetailsIsNull = false;
            }
            Amazon.DLM.PolicyTypeValues requestPolicyDetails_policyDetails_PolicyType = null;
            if (cmdletContext.PolicyDetails_PolicyType != null)
            {
                requestPolicyDetails_policyDetails_PolicyType = cmdletContext.PolicyDetails_PolicyType;
            }
            if (requestPolicyDetails_policyDetails_PolicyType != null)
            {
                request.PolicyDetails.PolicyType = requestPolicyDetails_policyDetails_PolicyType;
                requestPolicyDetailsIsNull = false;
            }
            List<System.String> requestPolicyDetails_policyDetails_ResourceLocation = null;
            if (cmdletContext.PolicyDetails_ResourceLocation != null)
            {
                requestPolicyDetails_policyDetails_ResourceLocation = cmdletContext.PolicyDetails_ResourceLocation;
            }
            if (requestPolicyDetails_policyDetails_ResourceLocation != null)
            {
                request.PolicyDetails.ResourceLocations = requestPolicyDetails_policyDetails_ResourceLocation;
                requestPolicyDetailsIsNull = false;
            }
            Amazon.DLM.ResourceTypeValues requestPolicyDetails_policyDetails_SimplifiedResourceType = null;
            if (cmdletContext.PolicyDetails_SimplifiedResourceType != null)
            {
                requestPolicyDetails_policyDetails_SimplifiedResourceType = cmdletContext.PolicyDetails_SimplifiedResourceType;
            }
            if (requestPolicyDetails_policyDetails_SimplifiedResourceType != null)
            {
                request.PolicyDetails.ResourceType = requestPolicyDetails_policyDetails_SimplifiedResourceType;
                requestPolicyDetailsIsNull = false;
            }
            List<System.String> requestPolicyDetails_policyDetails_ResourceType = null;
            if (cmdletContext.PolicyDetails_ResourceType != null)
            {
                requestPolicyDetails_policyDetails_ResourceType = cmdletContext.PolicyDetails_ResourceType;
            }
            if (requestPolicyDetails_policyDetails_ResourceType != null)
            {
                request.PolicyDetails.ResourceTypes = requestPolicyDetails_policyDetails_ResourceType;
                requestPolicyDetailsIsNull = false;
            }
            System.Int32? requestPolicyDetails_policyDetails_RetainInterval = null;
            if (cmdletContext.PolicyDetails_RetainInterval != null)
            {
                requestPolicyDetails_policyDetails_RetainInterval = cmdletContext.PolicyDetails_RetainInterval.Value;
            }
            if (requestPolicyDetails_policyDetails_RetainInterval != null)
            {
                request.PolicyDetails.RetainInterval = requestPolicyDetails_policyDetails_RetainInterval.Value;
                requestPolicyDetailsIsNull = false;
            }
            List<Amazon.DLM.Model.Schedule> requestPolicyDetails_policyDetails_Schedule = null;
            if (cmdletContext.PolicyDetails_Schedule != null)
            {
                requestPolicyDetails_policyDetails_Schedule = cmdletContext.PolicyDetails_Schedule;
            }
            if (requestPolicyDetails_policyDetails_Schedule != null)
            {
                request.PolicyDetails.Schedules = requestPolicyDetails_policyDetails_Schedule;
                requestPolicyDetailsIsNull = false;
            }
            List<Amazon.DLM.Model.Tag> requestPolicyDetails_policyDetails_TargetTag = null;
            if (cmdletContext.PolicyDetails_TargetTag != null)
            {
                requestPolicyDetails_policyDetails_TargetTag = cmdletContext.PolicyDetails_TargetTag;
            }
            if (requestPolicyDetails_policyDetails_TargetTag != null)
            {
                request.PolicyDetails.TargetTags = requestPolicyDetails_policyDetails_TargetTag;
                requestPolicyDetailsIsNull = false;
            }
            Amazon.DLM.Model.EventSource requestPolicyDetails_policyDetails_EventSource = null;
            
             // populate EventSource
            var requestPolicyDetails_policyDetails_EventSourceIsNull = true;
            requestPolicyDetails_policyDetails_EventSource = new Amazon.DLM.Model.EventSource();
            Amazon.DLM.EventSourceValues requestPolicyDetails_policyDetails_EventSource_eventSource_Type = null;
            if (cmdletContext.EventSource_Type != null)
            {
                requestPolicyDetails_policyDetails_EventSource_eventSource_Type = cmdletContext.EventSource_Type;
            }
            if (requestPolicyDetails_policyDetails_EventSource_eventSource_Type != null)
            {
                requestPolicyDetails_policyDetails_EventSource.Type = requestPolicyDetails_policyDetails_EventSource_eventSource_Type;
                requestPolicyDetails_policyDetails_EventSourceIsNull = false;
            }
            Amazon.DLM.Model.EventParameters requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters = null;
            
             // populate Parameters
            var requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_ParametersIsNull = true;
            requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters = new Amazon.DLM.Model.EventParameters();
            System.String requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_DescriptionRegex = null;
            if (cmdletContext.Parameters_DescriptionRegex != null)
            {
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_DescriptionRegex = cmdletContext.Parameters_DescriptionRegex;
            }
            if (requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_DescriptionRegex != null)
            {
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters.DescriptionRegex = requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_DescriptionRegex;
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_ParametersIsNull = false;
            }
            Amazon.DLM.EventTypeValues requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_EventType = null;
            if (cmdletContext.Parameters_EventType != null)
            {
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_EventType = cmdletContext.Parameters_EventType;
            }
            if (requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_EventType != null)
            {
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters.EventType = requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_EventType;
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_ParametersIsNull = false;
            }
            List<System.String> requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_SnapshotOwner = null;
            if (cmdletContext.Parameters_SnapshotOwner != null)
            {
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_SnapshotOwner = cmdletContext.Parameters_SnapshotOwner;
            }
            if (requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_SnapshotOwner != null)
            {
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters.SnapshotOwner = requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters_parameters_SnapshotOwner;
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_ParametersIsNull = false;
            }
             // determine if requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters should be set to null
            if (requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_ParametersIsNull)
            {
                requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters = null;
            }
            if (requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters != null)
            {
                requestPolicyDetails_policyDetails_EventSource.Parameters = requestPolicyDetails_policyDetails_EventSource_policyDetails_EventSource_Parameters;
                requestPolicyDetails_policyDetails_EventSourceIsNull = false;
            }
             // determine if requestPolicyDetails_policyDetails_EventSource should be set to null
            if (requestPolicyDetails_policyDetails_EventSourceIsNull)
            {
                requestPolicyDetails_policyDetails_EventSource = null;
            }
            if (requestPolicyDetails_policyDetails_EventSource != null)
            {
                request.PolicyDetails.EventSource = requestPolicyDetails_policyDetails_EventSource;
                requestPolicyDetailsIsNull = false;
            }
            Amazon.DLM.Model.Exclusions requestPolicyDetails_policyDetails_Exclusions = null;
            
             // populate Exclusions
            var requestPolicyDetails_policyDetails_ExclusionsIsNull = true;
            requestPolicyDetails_policyDetails_Exclusions = new Amazon.DLM.Model.Exclusions();
            System.Boolean? requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeBootVolumes = null;
            if (cmdletContext.PolicyDetails_Exclusions_ExcludeBootVolumes != null)
            {
                requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeBootVolumes = cmdletContext.PolicyDetails_Exclusions_ExcludeBootVolumes.Value;
            }
            if (requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeBootVolumes != null)
            {
                requestPolicyDetails_policyDetails_Exclusions.ExcludeBootVolumes = requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeBootVolumes.Value;
                requestPolicyDetails_policyDetails_ExclusionsIsNull = false;
            }
            List<Amazon.DLM.Model.Tag> requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeTags = null;
            if (cmdletContext.PolicyDetails_Exclusions_ExcludeTags != null)
            {
                requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeTags = cmdletContext.PolicyDetails_Exclusions_ExcludeTags;
            }
            if (requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeTags != null)
            {
                requestPolicyDetails_policyDetails_Exclusions.ExcludeTags = requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeTags;
                requestPolicyDetails_policyDetails_ExclusionsIsNull = false;
            }
            List<System.String> requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeVolumeTypes = null;
            if (cmdletContext.PolicyDetails_Exclusions_ExcludeVolumeTypes != null)
            {
                requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeVolumeTypes = cmdletContext.PolicyDetails_Exclusions_ExcludeVolumeTypes;
            }
            if (requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeVolumeTypes != null)
            {
                requestPolicyDetails_policyDetails_Exclusions.ExcludeVolumeTypes = requestPolicyDetails_policyDetails_Exclusions_policyDetails_Exclusions_ExcludeVolumeTypes;
                requestPolicyDetails_policyDetails_ExclusionsIsNull = false;
            }
             // determine if requestPolicyDetails_policyDetails_Exclusions should be set to null
            if (requestPolicyDetails_policyDetails_ExclusionsIsNull)
            {
                requestPolicyDetails_policyDetails_Exclusions = null;
            }
            if (requestPolicyDetails_policyDetails_Exclusions != null)
            {
                request.PolicyDetails.Exclusions = requestPolicyDetails_policyDetails_Exclusions;
                requestPolicyDetailsIsNull = false;
            }
            Amazon.DLM.Model.Parameters requestPolicyDetails_policyDetails_Parameters = null;
            
             // populate Parameters
            var requestPolicyDetails_policyDetails_ParametersIsNull = true;
            requestPolicyDetails_policyDetails_Parameters = new Amazon.DLM.Model.Parameters();
            System.Boolean? requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeBootVolume = null;
            if (cmdletContext.Parameters_ExcludeBootVolume != null)
            {
                requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeBootVolume = cmdletContext.Parameters_ExcludeBootVolume.Value;
            }
            if (requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeBootVolume != null)
            {
                requestPolicyDetails_policyDetails_Parameters.ExcludeBootVolume = requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeBootVolume.Value;
                requestPolicyDetails_policyDetails_ParametersIsNull = false;
            }
            List<Amazon.DLM.Model.Tag> requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeDataVolumeTag = null;
            if (cmdletContext.Parameters_ExcludeDataVolumeTag != null)
            {
                requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeDataVolumeTag = cmdletContext.Parameters_ExcludeDataVolumeTag;
            }
            if (requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeDataVolumeTag != null)
            {
                requestPolicyDetails_policyDetails_Parameters.ExcludeDataVolumeTags = requestPolicyDetails_policyDetails_Parameters_parameters_ExcludeDataVolumeTag;
                requestPolicyDetails_policyDetails_ParametersIsNull = false;
            }
            System.Boolean? requestPolicyDetails_policyDetails_Parameters_parameters_NoReboot = null;
            if (cmdletContext.Parameters_NoReboot != null)
            {
                requestPolicyDetails_policyDetails_Parameters_parameters_NoReboot = cmdletContext.Parameters_NoReboot.Value;
            }
            if (requestPolicyDetails_policyDetails_Parameters_parameters_NoReboot != null)
            {
                requestPolicyDetails_policyDetails_Parameters.NoReboot = requestPolicyDetails_policyDetails_Parameters_parameters_NoReboot.Value;
                requestPolicyDetails_policyDetails_ParametersIsNull = false;
            }
             // determine if requestPolicyDetails_policyDetails_Parameters should be set to null
            if (requestPolicyDetails_policyDetails_ParametersIsNull)
            {
                requestPolicyDetails_policyDetails_Parameters = null;
            }
            if (requestPolicyDetails_policyDetails_Parameters != null)
            {
                request.PolicyDetails.Parameters = requestPolicyDetails_policyDetails_Parameters;
                requestPolicyDetailsIsNull = false;
            }
             // determine if request.PolicyDetails should be set to null
            if (requestPolicyDetailsIsNull)
            {
                request.PolicyDetails = null;
            }
            if (cmdletContext.RetainInterval != null)
            {
                request.RetainInterval = cmdletContext.RetainInterval.Value;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
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
        
        private Amazon.DLM.Model.CreateLifecyclePolicyResponse CallAWSServiceOperation(IAmazonDLM client, Amazon.DLM.Model.CreateLifecyclePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Data Lifecycle Manager", "CreateLifecyclePolicy");
            try
            {
                #if DESKTOP
                return client.CreateLifecyclePolicy(request);
                #elif CORECLR
                return client.CreateLifecyclePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CopyTag { get; set; }
            public System.Int32? CreateInterval { get; set; }
            public List<Amazon.DLM.Model.CrossRegionCopyTarget> CrossRegionCopyTarget { get; set; }
            public Amazon.DLM.DefaultPolicyTypeValues DefaultPolicy { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? Exclusions_ExcludeBootVolume { get; set; }
            public List<Amazon.DLM.Model.Tag> Exclusions_ExcludeTag { get; set; }
            public List<System.String> Exclusions_ExcludeVolumeType { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.Boolean? ExtendDeletion { get; set; }
            public List<Amazon.DLM.Model.Action> PolicyDetails_Action { get; set; }
            public System.Boolean? PolicyDetails_CopyTag { get; set; }
            public System.Int32? PolicyDetails_CreateInterval { get; set; }
            public List<Amazon.DLM.Model.CrossRegionCopyTarget> PolicyDetails_CrossRegionCopyTarget { get; set; }
            public System.String Parameters_DescriptionRegex { get; set; }
            public Amazon.DLM.EventTypeValues Parameters_EventType { get; set; }
            public List<System.String> Parameters_SnapshotOwner { get; set; }
            public Amazon.DLM.EventSourceValues EventSource_Type { get; set; }
            public System.Boolean? PolicyDetails_Exclusions_ExcludeBootVolumes { get; set; }
            public List<Amazon.DLM.Model.Tag> PolicyDetails_Exclusions_ExcludeTags { get; set; }
            public List<System.String> PolicyDetails_Exclusions_ExcludeVolumeTypes { get; set; }
            public System.Boolean? PolicyDetails_ExtendDeletion { get; set; }
            public System.Boolean? Parameters_ExcludeBootVolume { get; set; }
            public List<Amazon.DLM.Model.Tag> Parameters_ExcludeDataVolumeTag { get; set; }
            public System.Boolean? Parameters_NoReboot { get; set; }
            public Amazon.DLM.PolicyLanguageValues PolicyDetails_PolicyLanguage { get; set; }
            public Amazon.DLM.PolicyTypeValues PolicyDetails_PolicyType { get; set; }
            public List<System.String> PolicyDetails_ResourceLocation { get; set; }
            public Amazon.DLM.ResourceTypeValues PolicyDetails_SimplifiedResourceType { get; set; }
            public List<System.String> PolicyDetails_ResourceType { get; set; }
            public System.Int32? PolicyDetails_RetainInterval { get; set; }
            public List<Amazon.DLM.Model.Schedule> PolicyDetails_Schedule { get; set; }
            public List<Amazon.DLM.Model.Tag> PolicyDetails_TargetTag { get; set; }
            public System.Int32? RetainInterval { get; set; }
            public Amazon.DLM.SettablePolicyStateValues State { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.DLM.Model.CreateLifecyclePolicyResponse, NewDLMLifecyclePolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PolicyId;
        }
        
    }
}
