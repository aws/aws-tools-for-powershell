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
using Amazon.Keyspaces;
using Amazon.Keyspaces.Model;

namespace Amazon.PowerShell.Cmdlets.KS
{
    /// <summary>
    /// The <c>CreateTable</c> operation adds a new table to the specified keyspace. Within
    /// a keyspace, table names must be unique.
    /// 
    ///  
    /// <para><c>CreateTable</c> is an asynchronous operation. When the request is received, the
    /// status of the table is set to <c>CREATING</c>. You can monitor the creation status
    /// of the new table by using the <c>GetTable</c> operation, which returns the current
    /// <c>status</c> of the table. You can start using a table when the status is <c>ACTIVE</c>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/working-with-tables.html#tables-create">Creating
    /// tables</a> in the <i>Amazon Keyspaces Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KSTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Keyspaces CreateTable API operation.", Operation = new[] {"CreateTable"}, SelectReturnType = typeof(Amazon.Keyspaces.Model.CreateTableResponse))]
    [AWSCmdletOutput("System.String or Amazon.Keyspaces.Model.CreateTableResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Keyspaces.Model.CreateTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKSTableCmdlet : AmazonKeyspacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SchemaDefinition_AllColumn
        /// <summary>
        /// <para>
        /// <para>The regular columns of the table.</para>
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
        [Alias("SchemaDefinition_AllColumns")]
        public Amazon.Keyspaces.Model.ColumnDefinition[] SchemaDefinition_AllColumn { get; set; }
        #endregion
        
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
        
        #region Parameter SchemaDefinition_ClusteringKey
        /// <summary>
        /// <para>
        /// <para>The columns that are part of the clustering key of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchemaDefinition_ClusteringKeys")]
        public Amazon.Keyspaces.Model.ClusteringKey[] SchemaDefinition_ClusteringKey { get; set; }
        #endregion
        
        #region Parameter DefaultTimeToLive
        /// <summary>
        /// <para>
        /// <para>The default Time to Live setting in seconds for the table.</para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/TTL-how-it-works.html#ttl-howitworks_default_ttl">Setting
        /// the default TTL value for a table</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultTimeToLive { get; set; }
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
        
        #region Parameter KeyspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the keyspace that the table is going to be created in.</para>
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
        public System.String KeyspaceName { get; set; }
        #endregion
        
        #region Parameter EncryptionSpecification_KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer managed KMS key, for example <c>kms_key_identifier:ARN</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionSpecification_KmsKeyIdentifier { get; set; }
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
        
        #region Parameter Comment_Message
        /// <summary>
        /// <para>
        /// <para>An optional description of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment_Message { get; set; }
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
        
        #region Parameter SchemaDefinition_PartitionKey
        /// <summary>
        /// <para>
        /// <para>The columns that are part of the partition key of the table .</para>
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
        [Alias("SchemaDefinition_PartitionKeys")]
        public Amazon.Keyspaces.Model.PartitionKey[] SchemaDefinition_PartitionKey { get; set; }
        #endregion
        
        #region Parameter CapacitySpecification_ReadCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <c>read</c> operations defined in <c>read capacity
        /// units</c><c>(RCUs)</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecification_ReadCapacityUnits")]
        public System.Int64? CapacitySpecification_ReadCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ReplicaSpecification
        /// <summary>
        /// <para>
        /// <para>The optional Amazon Web Services Region specific settings of a multi-Region table.
        /// These settings overwrite the general settings of the table for the specified Region.
        /// </para><para>For a multi-Region table in provisioned capacity mode, you can configure the table's
        /// read capacity differently for each Region's replica. The write capacity, however,
        /// remains synchronized between all replicas to ensure that there's enough capacity to
        /// replicate writes across all Regions. To define the read capacity for a table replica
        /// in a specific Region, you can do so by configuring the following parameters.</para><ul><li><para><c>region</c>: The Region where these settings are applied. (Required)</para></li><li><para><c>readCapacityUnits</c>: The provisioned read capacity units. (Optional)</para></li><li><para><c>readCapacityAutoScaling</c>: The read capacity auto scaling settings for the table.
        /// (Optional) </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicaSpecifications")]
        public Amazon.Keyspaces.Model.ReplicaSpecification[] ReplicaSpecification { get; set; }
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
        
        #region Parameter SchemaDefinition_StaticColumn
        /// <summary>
        /// <para>
        /// <para>The columns that have been defined as <c>STATIC</c>. Static columns store values that
        /// are shared by all rows in the same partition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchemaDefinition_StaticColumns")]
        public Amazon.Keyspaces.Model.StaticColumn[] SchemaDefinition_StaticColumn { get; set; }
        #endregion
        
        #region Parameter ClientSideTimestamps_Status
        /// <summary>
        /// <para>
        /// <para>Shows how to enable client-side timestamps settings for the specified table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.ClientSideTimestampsStatus")]
        public Amazon.Keyspaces.ClientSideTimestampsStatus ClientSideTimestamps_Status { get; set; }
        #endregion
        
        #region Parameter PointInTimeRecovery_Status
        /// <summary>
        /// <para>
        /// <para>The options are:</para><ul><li><para><c>status=ENABLED</c></para></li><li><para><c>status=DISABLED</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.PointInTimeRecoveryStatus")]
        public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecovery_Status { get; set; }
        #endregion
        
        #region Parameter Ttl_Status
        /// <summary>
        /// <para>
        /// <para>Shows how to enable custom Time to Live (TTL) settings for the specified table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.TimeToLiveStatus")]
        public Amazon.Keyspaces.TimeToLiveStatus Ttl_Status { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pair tags to be attached to the resource. </para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/tagging-keyspaces.html">Adding
        /// tags and labels to Amazon Keyspaces resources</a> in the <i>Amazon Keyspaces Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Keyspaces.Model.Tag[] Tag { get; set; }
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
        
        #region Parameter CapacitySpecification_ThroughputMode
        /// <summary>
        /// <para>
        /// <para>The read/write throughput capacity mode for a table. The options are:</para><ul><li><para><c>throughputMode:PAY_PER_REQUEST</c> and </para></li><li><para><c>throughputMode:PROVISIONED</c> - Provisioned capacity mode requires <c>readCapacityUnits</c>
        /// and <c>writeCapacityUnits</c> as input.</para></li></ul><para>The default is <c>throughput_mode:PAY_PER_REQUEST</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/ReadWriteCapacityMode.html">Read/write
        /// capacity modes</a> in the <i>Amazon Keyspaces Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Keyspaces.ThroughputMode")]
        public Amazon.Keyspaces.ThroughputMode CapacitySpecification_ThroughputMode { get; set; }
        #endregion
        
        #region Parameter EncryptionSpecification_Type
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
        public Amazon.Keyspaces.EncryptionType EncryptionSpecification_Type { get; set; }
        #endregion
        
        #region Parameter CapacitySpecification_WriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The throughput capacity specified for <c>write</c> operations defined in <c>write
        /// capacity units</c><c>(WCUs)</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacitySpecification_WriteCapacityUnits")]
        public System.Int64? CapacitySpecification_WriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Keyspaces.Model.CreateTableResponse).
        /// Specifying the name of a property of type Amazon.Keyspaces.Model.CreateTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KSTable (CreateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Keyspaces.Model.CreateTableResponse, NewKSTableCmdlet>(Select) ??
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
            context.CapacitySpecification_ReadCapacityUnit = this.CapacitySpecification_ReadCapacityUnit;
            context.CapacitySpecification_ThroughputMode = this.CapacitySpecification_ThroughputMode;
            context.CapacitySpecification_WriteCapacityUnit = this.CapacitySpecification_WriteCapacityUnit;
            context.ClientSideTimestamps_Status = this.ClientSideTimestamps_Status;
            context.Comment_Message = this.Comment_Message;
            context.DefaultTimeToLive = this.DefaultTimeToLive;
            context.EncryptionSpecification_KmsKeyIdentifier = this.EncryptionSpecification_KmsKeyIdentifier;
            context.EncryptionSpecification_Type = this.EncryptionSpecification_Type;
            context.KeyspaceName = this.KeyspaceName;
            #if MODULAR
            if (this.KeyspaceName == null && ParameterWasBound(nameof(this.KeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PointInTimeRecovery_Status = this.PointInTimeRecovery_Status;
            if (this.ReplicaSpecification != null)
            {
                context.ReplicaSpecification = new List<Amazon.Keyspaces.Model.ReplicaSpecification>(this.ReplicaSpecification);
            }
            if (this.SchemaDefinition_AllColumn != null)
            {
                context.SchemaDefinition_AllColumn = new List<Amazon.Keyspaces.Model.ColumnDefinition>(this.SchemaDefinition_AllColumn);
            }
            #if MODULAR
            if (this.SchemaDefinition_AllColumn == null && ParameterWasBound(nameof(this.SchemaDefinition_AllColumn)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaDefinition_AllColumn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SchemaDefinition_ClusteringKey != null)
            {
                context.SchemaDefinition_ClusteringKey = new List<Amazon.Keyspaces.Model.ClusteringKey>(this.SchemaDefinition_ClusteringKey);
            }
            if (this.SchemaDefinition_PartitionKey != null)
            {
                context.SchemaDefinition_PartitionKey = new List<Amazon.Keyspaces.Model.PartitionKey>(this.SchemaDefinition_PartitionKey);
            }
            #if MODULAR
            if (this.SchemaDefinition_PartitionKey == null && ParameterWasBound(nameof(this.SchemaDefinition_PartitionKey)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaDefinition_PartitionKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SchemaDefinition_StaticColumn != null)
            {
                context.SchemaDefinition_StaticColumn = new List<Amazon.Keyspaces.Model.StaticColumn>(this.SchemaDefinition_StaticColumn);
            }
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Keyspaces.Model.Tag>(this.Tag);
            }
            context.Ttl_Status = this.Ttl_Status;
            
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
            var request = new Amazon.Keyspaces.Model.CreateTableRequest();
            
            
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
            
             // populate CapacitySpecification
            var requestCapacitySpecificationIsNull = true;
            request.CapacitySpecification = new Amazon.Keyspaces.Model.CapacitySpecification();
            System.Int64? requestCapacitySpecification_capacitySpecification_ReadCapacityUnit = null;
            if (cmdletContext.CapacitySpecification_ReadCapacityUnit != null)
            {
                requestCapacitySpecification_capacitySpecification_ReadCapacityUnit = cmdletContext.CapacitySpecification_ReadCapacityUnit.Value;
            }
            if (requestCapacitySpecification_capacitySpecification_ReadCapacityUnit != null)
            {
                request.CapacitySpecification.ReadCapacityUnits = requestCapacitySpecification_capacitySpecification_ReadCapacityUnit.Value;
                requestCapacitySpecificationIsNull = false;
            }
            Amazon.Keyspaces.ThroughputMode requestCapacitySpecification_capacitySpecification_ThroughputMode = null;
            if (cmdletContext.CapacitySpecification_ThroughputMode != null)
            {
                requestCapacitySpecification_capacitySpecification_ThroughputMode = cmdletContext.CapacitySpecification_ThroughputMode;
            }
            if (requestCapacitySpecification_capacitySpecification_ThroughputMode != null)
            {
                request.CapacitySpecification.ThroughputMode = requestCapacitySpecification_capacitySpecification_ThroughputMode;
                requestCapacitySpecificationIsNull = false;
            }
            System.Int64? requestCapacitySpecification_capacitySpecification_WriteCapacityUnit = null;
            if (cmdletContext.CapacitySpecification_WriteCapacityUnit != null)
            {
                requestCapacitySpecification_capacitySpecification_WriteCapacityUnit = cmdletContext.CapacitySpecification_WriteCapacityUnit.Value;
            }
            if (requestCapacitySpecification_capacitySpecification_WriteCapacityUnit != null)
            {
                request.CapacitySpecification.WriteCapacityUnits = requestCapacitySpecification_capacitySpecification_WriteCapacityUnit.Value;
                requestCapacitySpecificationIsNull = false;
            }
             // determine if request.CapacitySpecification should be set to null
            if (requestCapacitySpecificationIsNull)
            {
                request.CapacitySpecification = null;
            }
            
             // populate ClientSideTimestamps
            var requestClientSideTimestampsIsNull = true;
            request.ClientSideTimestamps = new Amazon.Keyspaces.Model.ClientSideTimestamps();
            Amazon.Keyspaces.ClientSideTimestampsStatus requestClientSideTimestamps_clientSideTimestamps_Status = null;
            if (cmdletContext.ClientSideTimestamps_Status != null)
            {
                requestClientSideTimestamps_clientSideTimestamps_Status = cmdletContext.ClientSideTimestamps_Status;
            }
            if (requestClientSideTimestamps_clientSideTimestamps_Status != null)
            {
                request.ClientSideTimestamps.Status = requestClientSideTimestamps_clientSideTimestamps_Status;
                requestClientSideTimestampsIsNull = false;
            }
             // determine if request.ClientSideTimestamps should be set to null
            if (requestClientSideTimestampsIsNull)
            {
                request.ClientSideTimestamps = null;
            }
            
             // populate Comment
            var requestCommentIsNull = true;
            request.Comment = new Amazon.Keyspaces.Model.Comment();
            System.String requestComment_comment_Message = null;
            if (cmdletContext.Comment_Message != null)
            {
                requestComment_comment_Message = cmdletContext.Comment_Message;
            }
            if (requestComment_comment_Message != null)
            {
                request.Comment.Message = requestComment_comment_Message;
                requestCommentIsNull = false;
            }
             // determine if request.Comment should be set to null
            if (requestCommentIsNull)
            {
                request.Comment = null;
            }
            if (cmdletContext.DefaultTimeToLive != null)
            {
                request.DefaultTimeToLive = cmdletContext.DefaultTimeToLive.Value;
            }
            
             // populate EncryptionSpecification
            var requestEncryptionSpecificationIsNull = true;
            request.EncryptionSpecification = new Amazon.Keyspaces.Model.EncryptionSpecification();
            System.String requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier = null;
            if (cmdletContext.EncryptionSpecification_KmsKeyIdentifier != null)
            {
                requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier = cmdletContext.EncryptionSpecification_KmsKeyIdentifier;
            }
            if (requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier != null)
            {
                request.EncryptionSpecification.KmsKeyIdentifier = requestEncryptionSpecification_encryptionSpecification_KmsKeyIdentifier;
                requestEncryptionSpecificationIsNull = false;
            }
            Amazon.Keyspaces.EncryptionType requestEncryptionSpecification_encryptionSpecification_Type = null;
            if (cmdletContext.EncryptionSpecification_Type != null)
            {
                requestEncryptionSpecification_encryptionSpecification_Type = cmdletContext.EncryptionSpecification_Type;
            }
            if (requestEncryptionSpecification_encryptionSpecification_Type != null)
            {
                request.EncryptionSpecification.Type = requestEncryptionSpecification_encryptionSpecification_Type;
                requestEncryptionSpecificationIsNull = false;
            }
             // determine if request.EncryptionSpecification should be set to null
            if (requestEncryptionSpecificationIsNull)
            {
                request.EncryptionSpecification = null;
            }
            if (cmdletContext.KeyspaceName != null)
            {
                request.KeyspaceName = cmdletContext.KeyspaceName;
            }
            
             // populate PointInTimeRecovery
            var requestPointInTimeRecoveryIsNull = true;
            request.PointInTimeRecovery = new Amazon.Keyspaces.Model.PointInTimeRecovery();
            Amazon.Keyspaces.PointInTimeRecoveryStatus requestPointInTimeRecovery_pointInTimeRecovery_Status = null;
            if (cmdletContext.PointInTimeRecovery_Status != null)
            {
                requestPointInTimeRecovery_pointInTimeRecovery_Status = cmdletContext.PointInTimeRecovery_Status;
            }
            if (requestPointInTimeRecovery_pointInTimeRecovery_Status != null)
            {
                request.PointInTimeRecovery.Status = requestPointInTimeRecovery_pointInTimeRecovery_Status;
                requestPointInTimeRecoveryIsNull = false;
            }
             // determine if request.PointInTimeRecovery should be set to null
            if (requestPointInTimeRecoveryIsNull)
            {
                request.PointInTimeRecovery = null;
            }
            if (cmdletContext.ReplicaSpecification != null)
            {
                request.ReplicaSpecifications = cmdletContext.ReplicaSpecification;
            }
            
             // populate SchemaDefinition
            var requestSchemaDefinitionIsNull = true;
            request.SchemaDefinition = new Amazon.Keyspaces.Model.SchemaDefinition();
            List<Amazon.Keyspaces.Model.ColumnDefinition> requestSchemaDefinition_schemaDefinition_AllColumn = null;
            if (cmdletContext.SchemaDefinition_AllColumn != null)
            {
                requestSchemaDefinition_schemaDefinition_AllColumn = cmdletContext.SchemaDefinition_AllColumn;
            }
            if (requestSchemaDefinition_schemaDefinition_AllColumn != null)
            {
                request.SchemaDefinition.AllColumns = requestSchemaDefinition_schemaDefinition_AllColumn;
                requestSchemaDefinitionIsNull = false;
            }
            List<Amazon.Keyspaces.Model.ClusteringKey> requestSchemaDefinition_schemaDefinition_ClusteringKey = null;
            if (cmdletContext.SchemaDefinition_ClusteringKey != null)
            {
                requestSchemaDefinition_schemaDefinition_ClusteringKey = cmdletContext.SchemaDefinition_ClusteringKey;
            }
            if (requestSchemaDefinition_schemaDefinition_ClusteringKey != null)
            {
                request.SchemaDefinition.ClusteringKeys = requestSchemaDefinition_schemaDefinition_ClusteringKey;
                requestSchemaDefinitionIsNull = false;
            }
            List<Amazon.Keyspaces.Model.PartitionKey> requestSchemaDefinition_schemaDefinition_PartitionKey = null;
            if (cmdletContext.SchemaDefinition_PartitionKey != null)
            {
                requestSchemaDefinition_schemaDefinition_PartitionKey = cmdletContext.SchemaDefinition_PartitionKey;
            }
            if (requestSchemaDefinition_schemaDefinition_PartitionKey != null)
            {
                request.SchemaDefinition.PartitionKeys = requestSchemaDefinition_schemaDefinition_PartitionKey;
                requestSchemaDefinitionIsNull = false;
            }
            List<Amazon.Keyspaces.Model.StaticColumn> requestSchemaDefinition_schemaDefinition_StaticColumn = null;
            if (cmdletContext.SchemaDefinition_StaticColumn != null)
            {
                requestSchemaDefinition_schemaDefinition_StaticColumn = cmdletContext.SchemaDefinition_StaticColumn;
            }
            if (requestSchemaDefinition_schemaDefinition_StaticColumn != null)
            {
                request.SchemaDefinition.StaticColumns = requestSchemaDefinition_schemaDefinition_StaticColumn;
                requestSchemaDefinitionIsNull = false;
            }
             // determine if request.SchemaDefinition should be set to null
            if (requestSchemaDefinitionIsNull)
            {
                request.SchemaDefinition = null;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Ttl
            var requestTtlIsNull = true;
            request.Ttl = new Amazon.Keyspaces.Model.TimeToLive();
            Amazon.Keyspaces.TimeToLiveStatus requestTtl_ttl_Status = null;
            if (cmdletContext.Ttl_Status != null)
            {
                requestTtl_ttl_Status = cmdletContext.Ttl_Status;
            }
            if (requestTtl_ttl_Status != null)
            {
                request.Ttl.Status = requestTtl_ttl_Status;
                requestTtlIsNull = false;
            }
             // determine if request.Ttl should be set to null
            if (requestTtlIsNull)
            {
                request.Ttl = null;
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
        
        private Amazon.Keyspaces.Model.CreateTableResponse CallAWSServiceOperation(IAmazonKeyspaces client, Amazon.Keyspaces.Model.CreateTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces", "CreateTable");
            try
            {
                #if DESKTOP
                return client.CreateTable(request);
                #elif CORECLR
                return client.CreateTableAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? CapacitySpecification_ReadCapacityUnit { get; set; }
            public Amazon.Keyspaces.ThroughputMode CapacitySpecification_ThroughputMode { get; set; }
            public System.Int64? CapacitySpecification_WriteCapacityUnit { get; set; }
            public Amazon.Keyspaces.ClientSideTimestampsStatus ClientSideTimestamps_Status { get; set; }
            public System.String Comment_Message { get; set; }
            public System.Int32? DefaultTimeToLive { get; set; }
            public System.String EncryptionSpecification_KmsKeyIdentifier { get; set; }
            public Amazon.Keyspaces.EncryptionType EncryptionSpecification_Type { get; set; }
            public System.String KeyspaceName { get; set; }
            public Amazon.Keyspaces.PointInTimeRecoveryStatus PointInTimeRecovery_Status { get; set; }
            public List<Amazon.Keyspaces.Model.ReplicaSpecification> ReplicaSpecification { get; set; }
            public List<Amazon.Keyspaces.Model.ColumnDefinition> SchemaDefinition_AllColumn { get; set; }
            public List<Amazon.Keyspaces.Model.ClusteringKey> SchemaDefinition_ClusteringKey { get; set; }
            public List<Amazon.Keyspaces.Model.PartitionKey> SchemaDefinition_PartitionKey { get; set; }
            public List<Amazon.Keyspaces.Model.StaticColumn> SchemaDefinition_StaticColumn { get; set; }
            public System.String TableName { get; set; }
            public List<Amazon.Keyspaces.Model.Tag> Tag { get; set; }
            public Amazon.Keyspaces.TimeToLiveStatus Ttl_Status { get; set; }
            public System.Func<Amazon.Keyspaces.Model.CreateTableResponse, NewKSTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceArn;
        }
        
    }
}
