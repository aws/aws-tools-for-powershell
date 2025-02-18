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
using Amazon.Keyspaces;
using Amazon.Keyspaces.Model;

namespace Amazon.PowerShell.Cmdlets.KS
{
    /// <summary>
    /// Restores the table to the specified point in time within the <c>earliest_restorable_timestamp</c>
    /// and the current time. For more information about restore points, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/PointInTimeRecovery_HowItWorks.html#howitworks_backup_window">
    /// Time window for PITR continuous backups</a> in the <i>Amazon Keyspaces Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// Any number of users can execute up to 4 concurrent restores (any type of restore)
    /// in a given account.
    /// </para><para>
    /// When you restore using point in time recovery, Amazon Keyspaces restores your source
    /// table's schema and data to the state based on the selected timestamp <c>(day:hour:minute:second)</c>
    /// to a new table. The Time to Live (TTL) settings are also restored to the state based
    /// on the selected timestamp.
    /// </para><para>
    /// In addition to the table's schema, data, and TTL settings, <c>RestoreTable</c> restores
    /// the capacity mode, auto scaling settings, encryption settings, and point-in-time recovery
    /// settings from the source table. Unlike the table's schema data and TTL settings, which
    /// are restored based on the selected timestamp, these settings are always restored based
    /// on the table's settings as of the current time or when the table was deleted.
    /// </para><para>
    /// You can also overwrite these settings during restore:
    /// </para><ul><li><para>
    /// Read/write capacity mode
    /// </para></li><li><para>
    /// Provisioned throughput capacity units
    /// </para></li><li><para>
    /// Auto scaling settings
    /// </para></li><li><para>
    /// Point-in-time (PITR) settings
    /// </para></li><li><para>
    /// Tags
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/PointInTimeRecovery_HowItWorks.html#howitworks_backup_settings">PITR
    /// restore settings</a> in the <i>Amazon Keyspaces Developer Guide</i>.
    /// </para><para>
    /// Note that the following settings are not restored, and you must configure them manually
    /// for the new table:
    /// </para><ul><li><para>
    /// Identity and Access Management (IAM) policies
    /// </para></li><li><para>
    /// Amazon CloudWatch metrics and alarms
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Restore", "KSTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Keyspaces RestoreTable API operation.", Operation = new[] {"RestoreTable"}, SelectReturnType = typeof(Amazon.Keyspaces.Model.RestoreTableResponse))]
    [AWSCmdletOutput("System.String or Amazon.Keyspaces.Model.RestoreTableResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Keyspaces.Model.RestoreTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RestoreKSTableCmdlet : AmazonKeyspacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ReadCapacityAutoScaling_AutoScalingDisabled
        /// <summary>
        /// <para>
        /// <para>This optional parameter enables auto scaling for the table if set to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_ReadCapacityAutoScaling_AutoScalingDisabled")]
        public System.Boolean? ReadCapacityAutoScaling_AutoScalingDisabled { get; set; }
        #endregion
        
        #region Parameter WriteCapacityAutoScaling_AutoScalingDisabled
        /// <summary>
        /// <para>
        /// <para>This optional parameter enables auto scaling for the table if set to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_WriteCapacityAutoScaling_AutoScalingDisabled")]
        public System.Boolean? WriteCapacityAutoScaling_AutoScalingDisabled { get; set; }
        #endregion
        
        #region Parameter ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn
        /// <summary>
        /// <para>
        /// <para>Specifies if <c>scale-in</c> is enabled.</para><para>When auto scaling automatically decreases capacity for a table, the table <i>scales
        /// in</i>. When scaling policies are set, they can't scale in the table lower than its
        /// minimum capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_DisableScaleIn")]
        public System.Boolean? ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn { get; set; }
        #endregion
        
        #region Parameter WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn
        /// <summary>
        /// <para>
        /// <para>Specifies if <c>scale-in</c> is enabled.</para><para>When auto scaling automatically decreases capacity for a table, the table <i>scales
        /// in</i>. When scaling policies are set, they can't scale in the table lower than its
        /// minimum capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_DisableScaleIn")]
        public System.Boolean? WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn { get; set; }
        #endregion
        
        #region Parameter EncryptionSpecificationOverride_KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer managed KMS key, for example <c>kms_key_identifier:ARN</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSpecificationOverride_KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter ReadCapacityAutoScaling_MaximumUnit
        /// <summary>
        /// <para>
        /// <para>Manage costs by specifying the maximum amount of throughput to provision. The value
        /// must be between 1 and the max throughput per second quota for your account (40,000
        /// by default).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_ReadCapacityAutoScaling_MaximumUnits")]
        public System.Int64? ReadCapacityAutoScaling_MaximumUnit { get; set; }
        #endregion
        
        #region Parameter WriteCapacityAutoScaling_MaximumUnit
        /// <summary>
        /// <para>
        /// <para>Manage costs by specifying the maximum amount of throughput to provision. The value
        /// must be between 1 and the max throughput per second quota for your account (40,000
        /// by default).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_WriteCapacityAutoScaling_MaximumUnits")]
        public System.Int64? WriteCapacityAutoScaling_MaximumUnit { get; set; }
        #endregion
        
        #region Parameter ReadCapacityAutoScaling_MinimumUnit
        /// <summary>
        /// <para>
        /// <para>The minimum level of throughput the table should always be ready to support. The value
        /// must be between 1 and the max throughput per second quota for your account (40,000
        /// by default).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_ReadCapacityAutoScaling_MinimumUnits")]
        public System.Int64? ReadCapacityAutoScaling_MinimumUnit { get; set; }
        #endregion
        
        #region Parameter WriteCapacityAutoScaling_MinimumUnit
        /// <summary>
        /// <para>
        /// <para>The minimum level of throughput the table should always be ready to support. The value
        /// must be between 1 and the max throughput per second quota for your account (40,000
        /// by default).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_WriteCapacityAutoScaling_MinimumUnits")]
        public System.Int64? WriteCapacityAutoScaling_MinimumUnit { get; set; }
        #endregion
        
        #region Parameter CapacitySpecificationOverride_ReadCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <c>read</c> operations defined in <c>read capacity
        /// units</c><c>(RCUs)</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecificationOverride_ReadCapacityUnits")]
        public System.Int64? CapacitySpecificationOverride_ReadCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ReplicaSpecification
        /// <summary>
        /// <para>
        /// <para>The optional Region specific settings of a multi-Regional table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicaSpecifications")]
        public Amazon.Keyspaces.Model.ReplicaSpecification[] ReplicaSpecification { get; set; }
        #endregion
        
        #region Parameter RestoreTimestamp
        /// <summary>
        /// <para>
        /// <para>The restore timestamp in ISO 8601 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RestoreTimestamp { get; set; }
        #endregion
        
        #region Parameter ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown
        /// <summary>
        /// <para>
        /// <para>Specifies a <c>scale-in</c> cool down period.</para><para>A cooldown period in seconds between scaling activities that lets the table stabilize
        /// before another scaling activity starts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown")]
        public System.Int32? ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
        #endregion
        
        #region Parameter WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown
        /// <summary>
        /// <para>
        /// <para>Specifies a <c>scale-in</c> cool down period.</para><para>A cooldown period in seconds between scaling activities that lets the table stabilize
        /// before another scaling activity starts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown")]
        public System.Int32? WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
        #endregion
        
        #region Parameter ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown
        /// <summary>
        /// <para>
        /// <para>Specifies a scale out cool down period.</para><para>A cooldown period in seconds between scaling activities that lets the table stabilize
        /// before another scaling activity starts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown")]
        public System.Int32? ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
        #endregion
        
        #region Parameter WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown
        /// <summary>
        /// <para>
        /// <para>Specifies a scale out cool down period.</para><para>A cooldown period in seconds between scaling activities that lets the table stabilize
        /// before another scaling activity starts. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown")]
        public System.Int32? WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
        #endregion
        
        #region Parameter SourceKeyspaceName
        /// <summary>
        /// <para>
        /// <para>The keyspace name of the source table.</para>
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
        public System.String SourceKeyspaceName { get; set; }
        #endregion
        
        #region Parameter SourceTableName
        /// <summary>
        /// <para>
        /// <para>The name of the source table.</para>
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
        public System.String SourceTableName { get; set; }
        #endregion
        
        #region Parameter PointInTimeRecoveryOverride_Status
        /// <summary>
        /// <para>
        /// <para>The options are:</para><ul><li><para><c>status=ENABLED</c></para></li><li><para><c>status=DISABLED</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.PointInTimeRecoveryStatus")]
        public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecoveryOverride_Status { get; set; }
        #endregion
        
        #region Parameter TagsOverride
        /// <summary>
        /// <para>
        /// <para>A list of key-value pair tags to be attached to the restored table. </para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/tagging-keyspaces.html">Adding
        /// tags and labels to Amazon Keyspaces resources</a> in the <i>Amazon Keyspaces Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Keyspaces.Model.Tag[] TagsOverride { get; set; }
        #endregion
        
        #region Parameter TargetKeyspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the target keyspace.</para>
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
        public System.String TargetKeyspaceName { get; set; }
        #endregion
        
        #region Parameter TargetTableName
        /// <summary>
        /// <para>
        /// <para>The name of the target table.</para>
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
        public System.String TargetTableName { get; set; }
        #endregion
        
        #region Parameter ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>Specifies the target value for the target tracking auto scaling policy.</para><para>Amazon Keyspaces auto scaling scales up capacity automatically when traffic exceeds
        /// this target utilization rate, and then back down when it falls below the target. This
        /// ensures that the ratio of consumed capacity to provisioned capacity stays at or near
        /// this value. You define <c>targetValue</c> as a percentage. A <c>double</c> between
        /// 20 and 90.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_TargetValue")]
        public System.Double? ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
        #endregion
        
        #region Parameter WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>Specifies the target value for the target tracking auto scaling policy.</para><para>Amazon Keyspaces auto scaling scales up capacity automatically when traffic exceeds
        /// this target utilization rate, and then back down when it falls below the target. This
        /// ensures that the ratio of consumed capacity to provisioned capacity stays at or near
        /// this value. You define <c>targetValue</c> as a percentage. A <c>double</c> between
        /// 20 and 90.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_TargetValue")]
        public System.Double? WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
        #endregion
        
        #region Parameter CapacitySpecificationOverride_ThroughputMode
        /// <summary>
        /// <para>
        /// <para>The read/write throughput capacity mode for a table. The options are:</para><ul><li><para><c>throughputMode:PAY_PER_REQUEST</c> and </para></li><li><para><c>throughputMode:PROVISIONED</c> - Provisioned capacity mode requires <c>readCapacityUnits</c>
        /// and <c>writeCapacityUnits</c> as input.</para></li></ul><para>The default is <c>throughput_mode:PAY_PER_REQUEST</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/ReadWriteCapacityMode.html">Read/write
        /// capacity modes</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.ThroughputMode")]
        public Amazon.Keyspaces.ThroughputMode CapacitySpecificationOverride_ThroughputMode { get; set; }
        #endregion
        
        #region Parameter EncryptionSpecificationOverride_Type
        /// <summary>
        /// <para>
        /// <para>The encryption option specified for the table. You can choose one of the following
        /// KMS keys (KMS keys):</para><ul><li><para><c>type:AWS_OWNED_KMS_KEY</c> - This key is owned by Amazon Keyspaces. </para></li><li><para><c>type:CUSTOMER_MANAGED_KMS_KEY</c> - This key is stored in your account and is
        /// created, owned, and managed by you. This option requires the <c>kms_key_identifier</c>
        /// of the KMS key in Amazon Resource Name (ARN) format as input. </para></li></ul><para>The default is <c>type:AWS_OWNED_KMS_KEY</c>. </para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/EncryptionAtRest.html">Encryption
        /// at rest</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.EncryptionType")]
        public Amazon.Keyspaces.EncryptionType EncryptionSpecificationOverride_Type { get; set; }
        #endregion
        
        #region Parameter CapacitySpecificationOverride_WriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <c>write</c> operations defined in <c>write
        /// capacity units</c><c>(WCUs)</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecificationOverride_WriteCapacityUnits")]
        public System.Int64? CapacitySpecificationOverride_WriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RestoredTableARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Keyspaces.Model.RestoreTableResponse).
        /// Specifying the name of a property of type Amazon.Keyspaces.Model.RestoreTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RestoredTableARN";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-KSTable (RestoreTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Keyspaces.Model.RestoreTableResponse, RestoreKSTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ReadCapacityAutoScaling_AutoScalingDisabled = this.ReadCapacityAutoScaling_AutoScalingDisabled;
            context.ReadCapacityAutoScaling_MaximumUnit = this.ReadCapacityAutoScaling_MaximumUnit;
            context.ReadCapacityAutoScaling_MinimumUnit = this.ReadCapacityAutoScaling_MinimumUnit;
            context.ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn = this.ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn;
            context.ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown = this.ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown;
            context.ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown = this.ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown;
            context.ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue = this.ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue;
            context.WriteCapacityAutoScaling_AutoScalingDisabled = this.WriteCapacityAutoScaling_AutoScalingDisabled;
            context.WriteCapacityAutoScaling_MaximumUnit = this.WriteCapacityAutoScaling_MaximumUnit;
            context.WriteCapacityAutoScaling_MinimumUnit = this.WriteCapacityAutoScaling_MinimumUnit;
            context.WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn = this.WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn;
            context.WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown = this.WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown;
            context.WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown = this.WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown;
            context.WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue = this.WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue;
            context.CapacitySpecificationOverride_ReadCapacityUnit = this.CapacitySpecificationOverride_ReadCapacityUnit;
            context.CapacitySpecificationOverride_ThroughputMode = this.CapacitySpecificationOverride_ThroughputMode;
            context.CapacitySpecificationOverride_WriteCapacityUnit = this.CapacitySpecificationOverride_WriteCapacityUnit;
            context.EncryptionSpecificationOverride_KmsKeyIdentifier = this.EncryptionSpecificationOverride_KmsKeyIdentifier;
            context.EncryptionSpecificationOverride_Type = this.EncryptionSpecificationOverride_Type;
            context.PointInTimeRecoveryOverride_Status = this.PointInTimeRecoveryOverride_Status;
            if (this.ReplicaSpecification != null)
            {
                context.ReplicaSpecification = new List<Amazon.Keyspaces.Model.ReplicaSpecification>(this.ReplicaSpecification);
            }
            context.RestoreTimestamp = this.RestoreTimestamp;
            context.SourceKeyspaceName = this.SourceKeyspaceName;
            #if MODULAR
            if (this.SourceKeyspaceName == null && ParameterWasBound(nameof(this.SourceKeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceKeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceTableName = this.SourceTableName;
            #if MODULAR
            if (this.SourceTableName == null && ParameterWasBound(nameof(this.SourceTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagsOverride != null)
            {
                context.TagsOverride = new List<Amazon.Keyspaces.Model.Tag>(this.TagsOverride);
            }
            context.TargetKeyspaceName = this.TargetKeyspaceName;
            #if MODULAR
            if (this.TargetKeyspaceName == null && ParameterWasBound(nameof(this.TargetKeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetKeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetTableName = this.TargetTableName;
            #if MODULAR
            if (this.TargetTableName == null && ParameterWasBound(nameof(this.TargetTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Keyspaces.Model.RestoreTableRequest();
            
            
             // populate AutoScalingSpecification
            var requestAutoScalingSpecificationIsNull = true;
            request.AutoScalingSpecification = new Amazon.Keyspaces.Model.AutoScalingSpecification();
            Amazon.Keyspaces.Model.AutoScalingSettings requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling = null;
            
             // populate ReadCapacityAutoScaling
            var requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScalingIsNull = true;
            requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling = new Amazon.Keyspaces.Model.AutoScalingSettings();
            System.Boolean? requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_AutoScalingDisabled = null;
            if (cmdletContext.ReadCapacityAutoScaling_AutoScalingDisabled != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_AutoScalingDisabled = cmdletContext.ReadCapacityAutoScaling_AutoScalingDisabled.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_AutoScalingDisabled != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling.AutoScalingDisabled = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_AutoScalingDisabled.Value;
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScalingIsNull = false;
            }
            System.Int64? requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_MaximumUnit = null;
            if (cmdletContext.ReadCapacityAutoScaling_MaximumUnit != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_MaximumUnit = cmdletContext.ReadCapacityAutoScaling_MaximumUnit.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_MaximumUnit != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling.MaximumUnits = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_MaximumUnit.Value;
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScalingIsNull = false;
            }
            System.Int64? requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_MinimumUnit = null;
            if (cmdletContext.ReadCapacityAutoScaling_MinimumUnit != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_MinimumUnit = cmdletContext.ReadCapacityAutoScaling_MinimumUnit.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_MinimumUnit != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling.MinimumUnits = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_readCapacityAutoScaling_MinimumUnit.Value;
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScalingIsNull = false;
            }
            Amazon.Keyspaces.Model.AutoScalingPolicy requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy = null;
            
             // populate ScalingPolicy
            var requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicyIsNull = true;
            requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy = new Amazon.Keyspaces.Model.AutoScalingPolicy();
            Amazon.Keyspaces.Model.TargetTrackingScalingPolicyConfiguration requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration = null;
            
             // populate TargetTrackingScalingPolicyConfiguration
            var requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = true;
            requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration = new Amazon.Keyspaces.Model.TargetTrackingScalingPolicyConfiguration();
            System.Boolean? requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn = null;
            if (cmdletContext.ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn = cmdletContext.ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration.DisableScaleIn = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn.Value;
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown = null;
            if (cmdletContext.ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown = cmdletContext.ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration.ScaleInCooldown = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown.Value;
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown = null;
            if (cmdletContext.ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown = cmdletContext.ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration.ScaleOutCooldown = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown.Value;
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Double? requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue = null;
            if (cmdletContext.ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue = cmdletContext.ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration.TargetValue = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_readCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue.Value;
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
             // determine if requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration should be set to null
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration = null;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy.TargetTrackingScalingPolicyConfiguration = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration;
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicyIsNull = false;
            }
             // determine if requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy should be set to null
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicyIsNull)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy = null;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling.ScalingPolicy = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling_autoScalingSpecification_ReadCapacityAutoScaling_ScalingPolicy;
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScalingIsNull = false;
            }
             // determine if requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling should be set to null
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScalingIsNull)
            {
                requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling = null;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling != null)
            {
                request.AutoScalingSpecification.ReadCapacityAutoScaling = requestAutoScalingSpecification_autoScalingSpecification_ReadCapacityAutoScaling;
                requestAutoScalingSpecificationIsNull = false;
            }
            Amazon.Keyspaces.Model.AutoScalingSettings requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling = null;
            
             // populate WriteCapacityAutoScaling
            var requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScalingIsNull = true;
            requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling = new Amazon.Keyspaces.Model.AutoScalingSettings();
            System.Boolean? requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_AutoScalingDisabled = null;
            if (cmdletContext.WriteCapacityAutoScaling_AutoScalingDisabled != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_AutoScalingDisabled = cmdletContext.WriteCapacityAutoScaling_AutoScalingDisabled.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_AutoScalingDisabled != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling.AutoScalingDisabled = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_AutoScalingDisabled.Value;
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScalingIsNull = false;
            }
            System.Int64? requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_MaximumUnit = null;
            if (cmdletContext.WriteCapacityAutoScaling_MaximumUnit != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_MaximumUnit = cmdletContext.WriteCapacityAutoScaling_MaximumUnit.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_MaximumUnit != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling.MaximumUnits = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_MaximumUnit.Value;
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScalingIsNull = false;
            }
            System.Int64? requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_MinimumUnit = null;
            if (cmdletContext.WriteCapacityAutoScaling_MinimumUnit != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_MinimumUnit = cmdletContext.WriteCapacityAutoScaling_MinimumUnit.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_MinimumUnit != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling.MinimumUnits = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_writeCapacityAutoScaling_MinimumUnit.Value;
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScalingIsNull = false;
            }
            Amazon.Keyspaces.Model.AutoScalingPolicy requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy = null;
            
             // populate ScalingPolicy
            var requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicyIsNull = true;
            requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy = new Amazon.Keyspaces.Model.AutoScalingPolicy();
            Amazon.Keyspaces.Model.TargetTrackingScalingPolicyConfiguration requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration = null;
            
             // populate TargetTrackingScalingPolicyConfiguration
            var requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = true;
            requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration = new Amazon.Keyspaces.Model.TargetTrackingScalingPolicyConfiguration();
            System.Boolean? requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn = null;
            if (cmdletContext.WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn = cmdletContext.WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration.DisableScaleIn = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn.Value;
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown = null;
            if (cmdletContext.WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown = cmdletContext.WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration.ScaleInCooldown = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown.Value;
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown = null;
            if (cmdletContext.WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown = cmdletContext.WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration.ScaleOutCooldown = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown.Value;
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Double? requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue = null;
            if (cmdletContext.WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue = cmdletContext.WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue.Value;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration.TargetValue = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration_writeCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue.Value;
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull = false;
            }
             // determine if requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration should be set to null
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfigurationIsNull)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration = null;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy.TargetTrackingScalingPolicyConfiguration = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy_TargetTrackingScalingPolicyConfiguration;
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicyIsNull = false;
            }
             // determine if requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy should be set to null
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicyIsNull)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy = null;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy != null)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling.ScalingPolicy = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling_autoScalingSpecification_WriteCapacityAutoScaling_ScalingPolicy;
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScalingIsNull = false;
            }
             // determine if requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling should be set to null
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScalingIsNull)
            {
                requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling = null;
            }
            if (requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling != null)
            {
                request.AutoScalingSpecification.WriteCapacityAutoScaling = requestAutoScalingSpecification_autoScalingSpecification_WriteCapacityAutoScaling;
                requestAutoScalingSpecificationIsNull = false;
            }
             // determine if request.AutoScalingSpecification should be set to null
            if (requestAutoScalingSpecificationIsNull)
            {
                request.AutoScalingSpecification = null;
            }
            
             // populate CapacitySpecificationOverride
            var requestCapacitySpecificationOverrideIsNull = true;
            request.CapacitySpecificationOverride = new Amazon.Keyspaces.Model.CapacitySpecification();
            System.Int64? requestCapacitySpecificationOverride_capacitySpecificationOverride_ReadCapacityUnit = null;
            if (cmdletContext.CapacitySpecificationOverride_ReadCapacityUnit != null)
            {
                requestCapacitySpecificationOverride_capacitySpecificationOverride_ReadCapacityUnit = cmdletContext.CapacitySpecificationOverride_ReadCapacityUnit.Value;
            }
            if (requestCapacitySpecificationOverride_capacitySpecificationOverride_ReadCapacityUnit != null)
            {
                request.CapacitySpecificationOverride.ReadCapacityUnits = requestCapacitySpecificationOverride_capacitySpecificationOverride_ReadCapacityUnit.Value;
                requestCapacitySpecificationOverrideIsNull = false;
            }
            Amazon.Keyspaces.ThroughputMode requestCapacitySpecificationOverride_capacitySpecificationOverride_ThroughputMode = null;
            if (cmdletContext.CapacitySpecificationOverride_ThroughputMode != null)
            {
                requestCapacitySpecificationOverride_capacitySpecificationOverride_ThroughputMode = cmdletContext.CapacitySpecificationOverride_ThroughputMode;
            }
            if (requestCapacitySpecificationOverride_capacitySpecificationOverride_ThroughputMode != null)
            {
                request.CapacitySpecificationOverride.ThroughputMode = requestCapacitySpecificationOverride_capacitySpecificationOverride_ThroughputMode;
                requestCapacitySpecificationOverrideIsNull = false;
            }
            System.Int64? requestCapacitySpecificationOverride_capacitySpecificationOverride_WriteCapacityUnit = null;
            if (cmdletContext.CapacitySpecificationOverride_WriteCapacityUnit != null)
            {
                requestCapacitySpecificationOverride_capacitySpecificationOverride_WriteCapacityUnit = cmdletContext.CapacitySpecificationOverride_WriteCapacityUnit.Value;
            }
            if (requestCapacitySpecificationOverride_capacitySpecificationOverride_WriteCapacityUnit != null)
            {
                request.CapacitySpecificationOverride.WriteCapacityUnits = requestCapacitySpecificationOverride_capacitySpecificationOverride_WriteCapacityUnit.Value;
                requestCapacitySpecificationOverrideIsNull = false;
            }
             // determine if request.CapacitySpecificationOverride should be set to null
            if (requestCapacitySpecificationOverrideIsNull)
            {
                request.CapacitySpecificationOverride = null;
            }
            
             // populate EncryptionSpecificationOverride
            var requestEncryptionSpecificationOverrideIsNull = true;
            request.EncryptionSpecificationOverride = new Amazon.Keyspaces.Model.EncryptionSpecification();
            System.String requestEncryptionSpecificationOverride_encryptionSpecificationOverride_KmsKeyIdentifier = null;
            if (cmdletContext.EncryptionSpecificationOverride_KmsKeyIdentifier != null)
            {
                requestEncryptionSpecificationOverride_encryptionSpecificationOverride_KmsKeyIdentifier = cmdletContext.EncryptionSpecificationOverride_KmsKeyIdentifier;
            }
            if (requestEncryptionSpecificationOverride_encryptionSpecificationOverride_KmsKeyIdentifier != null)
            {
                request.EncryptionSpecificationOverride.KmsKeyIdentifier = requestEncryptionSpecificationOverride_encryptionSpecificationOverride_KmsKeyIdentifier;
                requestEncryptionSpecificationOverrideIsNull = false;
            }
            Amazon.Keyspaces.EncryptionType requestEncryptionSpecificationOverride_encryptionSpecificationOverride_Type = null;
            if (cmdletContext.EncryptionSpecificationOverride_Type != null)
            {
                requestEncryptionSpecificationOverride_encryptionSpecificationOverride_Type = cmdletContext.EncryptionSpecificationOverride_Type;
            }
            if (requestEncryptionSpecificationOverride_encryptionSpecificationOverride_Type != null)
            {
                request.EncryptionSpecificationOverride.Type = requestEncryptionSpecificationOverride_encryptionSpecificationOverride_Type;
                requestEncryptionSpecificationOverrideIsNull = false;
            }
             // determine if request.EncryptionSpecificationOverride should be set to null
            if (requestEncryptionSpecificationOverrideIsNull)
            {
                request.EncryptionSpecificationOverride = null;
            }
            
             // populate PointInTimeRecoveryOverride
            var requestPointInTimeRecoveryOverrideIsNull = true;
            request.PointInTimeRecoveryOverride = new Amazon.Keyspaces.Model.PointInTimeRecovery();
            Amazon.Keyspaces.PointInTimeRecoveryStatus requestPointInTimeRecoveryOverride_pointInTimeRecoveryOverride_Status = null;
            if (cmdletContext.PointInTimeRecoveryOverride_Status != null)
            {
                requestPointInTimeRecoveryOverride_pointInTimeRecoveryOverride_Status = cmdletContext.PointInTimeRecoveryOverride_Status;
            }
            if (requestPointInTimeRecoveryOverride_pointInTimeRecoveryOverride_Status != null)
            {
                request.PointInTimeRecoveryOverride.Status = requestPointInTimeRecoveryOverride_pointInTimeRecoveryOverride_Status;
                requestPointInTimeRecoveryOverrideIsNull = false;
            }
             // determine if request.PointInTimeRecoveryOverride should be set to null
            if (requestPointInTimeRecoveryOverrideIsNull)
            {
                request.PointInTimeRecoveryOverride = null;
            }
            if (cmdletContext.ReplicaSpecification != null)
            {
                request.ReplicaSpecifications = cmdletContext.ReplicaSpecification;
            }
            if (cmdletContext.RestoreTimestamp != null)
            {
                request.RestoreTimestamp = cmdletContext.RestoreTimestamp.Value;
            }
            if (cmdletContext.SourceKeyspaceName != null)
            {
                request.SourceKeyspaceName = cmdletContext.SourceKeyspaceName;
            }
            if (cmdletContext.SourceTableName != null)
            {
                request.SourceTableName = cmdletContext.SourceTableName;
            }
            if (cmdletContext.TagsOverride != null)
            {
                request.TagsOverride = cmdletContext.TagsOverride;
            }
            if (cmdletContext.TargetKeyspaceName != null)
            {
                request.TargetKeyspaceName = cmdletContext.TargetKeyspaceName;
            }
            if (cmdletContext.TargetTableName != null)
            {
                request.TargetTableName = cmdletContext.TargetTableName;
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
        
        private Amazon.Keyspaces.Model.RestoreTableResponse CallAWSServiceOperation(IAmazonKeyspaces client, Amazon.Keyspaces.Model.RestoreTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces", "RestoreTable");
            try
            {
                return client.RestoreTableAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ReadCapacityAutoScaling_AutoScalingDisabled { get; set; }
            public System.Int64? ReadCapacityAutoScaling_MaximumUnit { get; set; }
            public System.Int64? ReadCapacityAutoScaling_MinimumUnit { get; set; }
            public System.Boolean? ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn { get; set; }
            public System.Int32? ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
            public System.Int32? ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
            public System.Double? ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
            public System.Boolean? WriteCapacityAutoScaling_AutoScalingDisabled { get; set; }
            public System.Int64? WriteCapacityAutoScaling_MaximumUnit { get; set; }
            public System.Int64? WriteCapacityAutoScaling_MinimumUnit { get; set; }
            public System.Boolean? WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn { get; set; }
            public System.Int32? WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
            public System.Int32? WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
            public System.Double? WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
            public System.Int64? CapacitySpecificationOverride_ReadCapacityUnit { get; set; }
            public Amazon.Keyspaces.ThroughputMode CapacitySpecificationOverride_ThroughputMode { get; set; }
            public System.Int64? CapacitySpecificationOverride_WriteCapacityUnit { get; set; }
            public System.String EncryptionSpecificationOverride_KmsKeyIdentifier { get; set; }
            public Amazon.Keyspaces.EncryptionType EncryptionSpecificationOverride_Type { get; set; }
            public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecoveryOverride_Status { get; set; }
            public List<Amazon.Keyspaces.Model.ReplicaSpecification> ReplicaSpecification { get; set; }
            public System.DateTime? RestoreTimestamp { get; set; }
            public System.String SourceKeyspaceName { get; set; }
            public System.String SourceTableName { get; set; }
            public List<Amazon.Keyspaces.Model.Tag> TagsOverride { get; set; }
            public System.String TargetKeyspaceName { get; set; }
            public System.String TargetTableName { get; set; }
            public System.Func<Amazon.Keyspaces.Model.RestoreTableResponse, RestoreKSTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RestoredTableARN;
        }
        
    }
}
