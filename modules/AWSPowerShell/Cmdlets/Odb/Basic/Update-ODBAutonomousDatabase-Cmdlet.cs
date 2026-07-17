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
using Amazon.Odb;
using Amazon.Odb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Updates the properties of an Autonomous Database.
    /// </summary>
    [Cmdlet("Update", "ODBAutonomousDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.UpdateAutonomousDatabaseResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services UpdateAutonomousDatabase API operation.", Operation = new[] {"UpdateAutonomousDatabase"}, SelectReturnType = typeof(Amazon.Odb.Model.UpdateAutonomousDatabaseResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.UpdateAutonomousDatabaseResponse",
        "This cmdlet returns an Amazon.Odb.Model.UpdateAutonomousDatabaseResponse object containing multiple properties."
    )]
    public partial class UpdateODBAutonomousDatabaseCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdminPassword
        /// <summary>
        /// <para>
        /// <para>The new password for the <c>ADMIN</c> user of the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminPassword { get; set; }
        #endregion
        
        #region Parameter AdminPasswordSource
        /// <summary>
        /// <para>
        /// <para>The source of the admin password for the Autonomous Database. When set to <c>CUSTOMER_MANAGED_AWS_SECRET</c>,
        /// the admin password is retrieved from an Amazon Web Services Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.AdminPasswordSource")]
        public Amazon.Odb.AdminPasswordSource AdminPasswordSource { get; set; }
        #endregion
        
        #region Parameter AllowlistedIp
        /// <summary>
        /// <para>
        /// <para>The list of IP addresses that are allowed to access the Autonomous Database.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowlistedIps")]
        public System.String[] AllowlistedIp { get; set; }
        #endregion
        
        #region Parameter AutonomousDatabaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Autonomous Database to update.</para>
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
        public System.String AutonomousDatabaseId { get; set; }
        #endregion
        
        #region Parameter AutonomousMaintenanceScheduleType
        /// <summary>
        /// <para>
        /// <para>The maintenance schedule type for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.AutonomousMaintenanceScheduleType")]
        public Amazon.Odb.AutonomousMaintenanceScheduleType AutonomousMaintenanceScheduleType { get; set; }
        #endregion
        
        #region Parameter AutoRefreshFrequencyInSecond
        /// <summary>
        /// <para>
        /// <para>The frequency, in seconds, at which the refreshable clone Autonomous Database is automatically
        /// refreshed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoRefreshFrequencyInSeconds")]
        public System.Int32? AutoRefreshFrequencyInSecond { get; set; }
        #endregion
        
        #region Parameter AutoRefreshPointLagInSecond
        /// <summary>
        /// <para>
        /// <para>The time lag, in seconds, between the refreshable clone and its source Autonomous
        /// Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoRefreshPointLagInSeconds")]
        public System.Int32? AutoRefreshPointLagInSecond { get; set; }
        #endregion
        
        #region Parameter ResourcePoolSummary_AvailableComputeCapacity
        /// <summary>
        /// <para>
        /// <para>The available compute capacity in the resource pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourcePoolSummary_AvailableComputeCapacity { get; set; }
        #endregion
        
        #region Parameter ResourcePoolSummary_AvailableStorageCapacityInTBs
        /// <summary>
        /// <para>
        /// <para>The available storage capacity in the resource pool, in TB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ResourcePoolSummary_AvailableStorageCapacityInTBs { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The retention period, in days, for automatic backups of the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupRetentionPeriodInDays")]
        public System.Int32? BackupRetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter ByolComputeCountLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of compute resources that you can allocate to the Autonomous Database
        /// under the bring-your-own-license (BYOL) model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ByolComputeCountLimit { get; set; }
        #endregion
        
        #region Parameter ComputeCount
        /// <summary>
        /// <para>
        /// <para>The compute capacity, in number of ECPUs or OCPUs, to assign to the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ComputeCount { get; set; }
        #endregion
        
        #region Parameter CpuCoreCount
        /// <summary>
        /// <para>
        /// <para>The number of CPU cores to allocate to the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CpuCoreCount { get; set; }
        #endregion
        
        #region Parameter CustomerContactsToSendToOCI
        /// <summary>
        /// <para>
        /// <para>The list of customer contacts to receive operational notifications from OCI for the
        /// Autonomous Database.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Odb.Model.CustomerContact[] CustomerContactsToSendToOCI { get; set; }
        #endregion
        
        #region Parameter DatabaseEdition
        /// <summary>
        /// <para>
        /// <para>The Oracle Database edition to apply to the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.DatabaseEdition")]
        public Amazon.Odb.DatabaseEdition DatabaseEdition { get; set; }
        #endregion
        
        #region Parameter DataStorageSizeInGBs
        /// <summary>
        /// <para>
        /// <para>The size, in gigabytes (GB), of the data volume to allocate for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DataStorageSizeInGBs { get; set; }
        #endregion
        
        #region Parameter DataStorageSizeInTBs
        /// <summary>
        /// <para>
        /// <para>The size, in terabytes (TB), of the data volume to allocate for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DataStorageSizeInTBs { get; set; }
        #endregion
        
        #region Parameter DbName
        /// <summary>
        /// <para>
        /// <para>The new name of the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbName { get; set; }
        #endregion
        
        #region Parameter DbToolsDetail
        /// <summary>
        /// <para>
        /// <para>The list of database management tools to enable for the Autonomous Database.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DbToolsDetails")]
        public Amazon.Odb.Model.DatabaseTool[] DbToolsDetail { get; set; }
        #endregion
        
        #region Parameter DbVersion
        /// <summary>
        /// <para>
        /// <para>The Oracle Database software version to use for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbVersion { get; set; }
        #endregion
        
        #region Parameter DbWorkload
        /// <summary>
        /// <para>
        /// <para>The intended use of the Autonomous Database, such as transaction processing, data
        /// warehouse, JSON database, or APEX.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.DbWorkload")]
        public Amazon.Odb.DbWorkload DbWorkload { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The new user-friendly name for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyProvider
        /// <summary>
        /// <para>
        /// <para>The provider of the encryption key to use for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.EncryptionKeyProviderInput")]
        public Amazon.Odb.EncryptionKeyProviderInput EncryptionKeyProvider { get; set; }
        #endregion
        
        #region Parameter AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType
        /// <summary>
        /// <para>
        /// <para>The type of Oracle Cloud Identifier (OCID) used as the external ID when assuming the
        /// IAM role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.ExternalIdType")]
        public Amazon.Odb.ExternalIdType AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType
        /// <summary>
        /// <para>
        /// <para>The type of external identifier associated with the encryption key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.ExternalIdType")]
        public Amazon.Odb.ExternalIdType EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType { get; set; }
        #endregion
        
        #region Parameter AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Identity and Access Management
        /// (IAM) role that OCI assumes to retrieve the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Identity and Access Management
        /// (IAM) role that grants access to the KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter IsAutoScalingEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable automatic scaling of the compute resources for the Autonomous
        /// Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsAutoScalingEnabled { get; set; }
        #endregion
        
        #region Parameter IsAutoScalingForStorageEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable automatic scaling of the storage for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsAutoScalingForStorageEnabled { get; set; }
        #endregion
        
        #region Parameter IsBackupRetentionLocked
        /// <summary>
        /// <para>
        /// <para>Specifies whether to lock the backup retention period of the Autonomous Database to
        /// prevent it from being shortened.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsBackupRetentionLocked { get; set; }
        #endregion
        
        #region Parameter LongTermBackupSchedule_IsDisabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the long-term backup schedule is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LongTermBackupSchedule_IsDisabled { get; set; }
        #endregion
        
        #region Parameter ResourcePoolSummary_IsDisabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the resource pool is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ResourcePoolSummary_IsDisabled { get; set; }
        #endregion
        
        #region Parameter IsDisconnectPeer
        /// <summary>
        /// <para>
        /// <para>Specifies whether to disconnect the Autonomous Database from its peer database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsDisconnectPeer { get; set; }
        #endregion
        
        #region Parameter IsLocalDataGuardEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable local Oracle Data Guard for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsLocalDataGuardEnabled { get; set; }
        #endregion
        
        #region Parameter IsMtlsConnectionRequired
        /// <summary>
        /// <para>
        /// <para>Specifies whether mutual TLS (mTLS) authentication is required to connect to the Autonomous
        /// Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsMtlsConnectionRequired { get; set; }
        #endregion
        
        #region Parameter IsRefreshableClone
        /// <summary>
        /// <para>
        /// <para>Specifies whether the Autonomous Database is a refreshable clone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsRefreshableClone { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier or ARN of the Amazon Web Services KMS key to use for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>The Oracle license model to apply to the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.LicenseModel")]
        public Amazon.Odb.LicenseModel LicenseModel { get; set; }
        #endregion
        
        #region Parameter LocalAdgAutoFailoverMaxDataLossLimit
        /// <summary>
        /// <para>
        /// <para>The maximum data loss limit, in seconds, for automatic failover to the local Oracle
        /// Data Guard standby database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LocalAdgAutoFailoverMaxDataLossLimit { get; set; }
        #endregion
        
        #region Parameter OpenMode
        /// <summary>
        /// <para>
        /// <para>The mode in which to open the Autonomous Database, either read-only or read/write.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.OpenMode")]
        public Amazon.Odb.OpenMode OpenMode { get; set; }
        #endregion
        
        #region Parameter PeerDbId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the peer Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PeerDbId { get; set; }
        #endregion
        
        #region Parameter PermissionLevel
        /// <summary>
        /// <para>
        /// <para>The permission level of the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.PermissionLevel")]
        public Amazon.Odb.PermissionLevel PermissionLevel { get; set; }
        #endregion
        
        #region Parameter ResourcePoolSummary_PoolSize
        /// <summary>
        /// <para>
        /// <para>The number of Autonomous Databases that the resource pool can contain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourcePoolSummary_PoolSize { get; set; }
        #endregion
        
        #region Parameter ResourcePoolSummary_PoolStorageSizeInTBs
        /// <summary>
        /// <para>
        /// <para>The total storage size of the resource pool, in terabytes (TB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourcePoolSummary_PoolStorageSizeInTBs { get; set; }
        #endregion
        
        #region Parameter PrivateEndpointIp
        /// <summary>
        /// <para>
        /// <para>The private endpoint IP address for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateEndpointIp { get; set; }
        #endregion
        
        #region Parameter PrivateEndpointLabel
        /// <summary>
        /// <para>
        /// <para>The private endpoint label for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateEndpointLabel { get; set; }
        #endregion
        
        #region Parameter RefreshableMode
        /// <summary>
        /// <para>
        /// <para>The refresh mode of the refreshable clone Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.RefreshableMode")]
        public Amazon.Odb.RefreshableMode RefreshableMode { get; set; }
        #endregion
        
        #region Parameter LongTermBackupSchedule_RepeatCadence
        /// <summary>
        /// <para>
        /// <para>The cadence at which long-term backups are taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.RepeatCadence")]
        public Amazon.Odb.RepeatCadence LongTermBackupSchedule_RepeatCadence { get; set; }
        #endregion
        
        #region Parameter ResourcePoolLeaderId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the resource pool leader Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourcePoolLeaderId { get; set; }
        #endregion
        
        #region Parameter LongTermBackupSchedule_RetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The retention period, in days, for long-term backups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LongTermBackupSchedule_RetentionPeriodInDays")]
        public System.Int32? LongTermBackupSchedule_RetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter ScheduledOperation
        /// <summary>
        /// <para>
        /// <para>The list of scheduled start and stop times for the Autonomous Database.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScheduledOperations")]
        public Amazon.Odb.Model.ScheduledOperationDetails[] ScheduledOperation { get; set; }
        #endregion
        
        #region Parameter AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId
        /// <summary>
        /// <para>
        /// <para>The identifier or ARN of the Amazon Web Services Secrets Manager secret that contains
        /// the password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId { get; set; }
        #endregion
        
        #region Parameter StandbyAllowlistedIp
        /// <summary>
        /// <para>
        /// <para>The list of IP addresses that are allowed to access the standby Autonomous Database.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StandbyAllowlistedIps")]
        public System.String[] StandbyAllowlistedIp { get; set; }
        #endregion
        
        #region Parameter StandbyAllowlistedIpsSource
        /// <summary>
        /// <para>
        /// <para>The source of the allowlisted IP addresses for the standby Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.StandbyAllowlistedIpsSource")]
        public Amazon.Odb.StandbyAllowlistedIpsSource StandbyAllowlistedIpsSource { get; set; }
        #endregion
        
        #region Parameter TimeOfAutoRefreshStart
        /// <summary>
        /// <para>
        /// <para>The date and time at which the automatic refresh of the refreshable clone Autonomous
        /// Database starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimeOfAutoRefreshStart { get; set; }
        #endregion
        
        #region Parameter LongTermBackupSchedule_TimeOfBackup
        /// <summary>
        /// <para>
        /// <para>The date and time at which the long-term backup is taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? LongTermBackupSchedule_TimeOfBackup { get; set; }
        #endregion
        
        #region Parameter ResourcePoolSummary_TotalComputeCapacity
        /// <summary>
        /// <para>
        /// <para>The total compute capacity of the resource pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResourcePoolSummary_TotalComputeCapacity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.UpdateAutonomousDatabaseResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.UpdateAutonomousDatabaseResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutonomousDatabaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ODBAutonomousDatabase (UpdateAutonomousDatabase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.UpdateAutonomousDatabaseResponse, UpdateODBAutonomousDatabaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdminPassword = this.AdminPassword;
            context.AdminPasswordSource = this.AdminPasswordSource;
            context.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType = this.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType;
            context.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn = this.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn;
            context.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId = this.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId;
            if (this.AllowlistedIp != null)
            {
                context.AllowlistedIp = new List<System.String>(this.AllowlistedIp);
            }
            context.AutonomousDatabaseId = this.AutonomousDatabaseId;
            #if MODULAR
            if (this.AutonomousDatabaseId == null && ParameterWasBound(nameof(this.AutonomousDatabaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter AutonomousDatabaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutonomousMaintenanceScheduleType = this.AutonomousMaintenanceScheduleType;
            context.AutoRefreshFrequencyInSecond = this.AutoRefreshFrequencyInSecond;
            context.AutoRefreshPointLagInSecond = this.AutoRefreshPointLagInSecond;
            context.BackupRetentionPeriodInDay = this.BackupRetentionPeriodInDay;
            context.ByolComputeCountLimit = this.ByolComputeCountLimit;
            context.ComputeCount = this.ComputeCount;
            context.CpuCoreCount = this.CpuCoreCount;
            if (this.CustomerContactsToSendToOCI != null)
            {
                context.CustomerContactsToSendToOCI = new List<Amazon.Odb.Model.CustomerContact>(this.CustomerContactsToSendToOCI);
            }
            context.DatabaseEdition = this.DatabaseEdition;
            context.DataStorageSizeInGBs = this.DataStorageSizeInGBs;
            context.DataStorageSizeInTBs = this.DataStorageSizeInTBs;
            context.DbName = this.DbName;
            if (this.DbToolsDetail != null)
            {
                context.DbToolsDetail = new List<Amazon.Odb.Model.DatabaseTool>(this.DbToolsDetail);
            }
            context.DbVersion = this.DbVersion;
            context.DbWorkload = this.DbWorkload;
            context.DisplayName = this.DisplayName;
            context.EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType = this.EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType;
            context.EncryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn = this.EncryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn;
            context.EncryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId = this.EncryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId;
            context.EncryptionKeyProvider = this.EncryptionKeyProvider;
            context.IsAutoScalingEnabled = this.IsAutoScalingEnabled;
            context.IsAutoScalingForStorageEnabled = this.IsAutoScalingForStorageEnabled;
            context.IsBackupRetentionLocked = this.IsBackupRetentionLocked;
            context.IsDisconnectPeer = this.IsDisconnectPeer;
            context.IsLocalDataGuardEnabled = this.IsLocalDataGuardEnabled;
            context.IsMtlsConnectionRequired = this.IsMtlsConnectionRequired;
            context.IsRefreshableClone = this.IsRefreshableClone;
            context.LicenseModel = this.LicenseModel;
            context.LocalAdgAutoFailoverMaxDataLossLimit = this.LocalAdgAutoFailoverMaxDataLossLimit;
            context.LongTermBackupSchedule_IsDisabled = this.LongTermBackupSchedule_IsDisabled;
            context.LongTermBackupSchedule_RepeatCadence = this.LongTermBackupSchedule_RepeatCadence;
            context.LongTermBackupSchedule_RetentionPeriodInDay = this.LongTermBackupSchedule_RetentionPeriodInDay;
            context.LongTermBackupSchedule_TimeOfBackup = this.LongTermBackupSchedule_TimeOfBackup;
            context.OpenMode = this.OpenMode;
            context.PeerDbId = this.PeerDbId;
            context.PermissionLevel = this.PermissionLevel;
            context.PrivateEndpointIp = this.PrivateEndpointIp;
            context.PrivateEndpointLabel = this.PrivateEndpointLabel;
            context.RefreshableMode = this.RefreshableMode;
            context.ResourcePoolLeaderId = this.ResourcePoolLeaderId;
            context.ResourcePoolSummary_AvailableComputeCapacity = this.ResourcePoolSummary_AvailableComputeCapacity;
            context.ResourcePoolSummary_AvailableStorageCapacityInTBs = this.ResourcePoolSummary_AvailableStorageCapacityInTBs;
            context.ResourcePoolSummary_IsDisabled = this.ResourcePoolSummary_IsDisabled;
            context.ResourcePoolSummary_PoolSize = this.ResourcePoolSummary_PoolSize;
            context.ResourcePoolSummary_PoolStorageSizeInTBs = this.ResourcePoolSummary_PoolStorageSizeInTBs;
            context.ResourcePoolSummary_TotalComputeCapacity = this.ResourcePoolSummary_TotalComputeCapacity;
            if (this.ScheduledOperation != null)
            {
                context.ScheduledOperation = new List<Amazon.Odb.Model.ScheduledOperationDetails>(this.ScheduledOperation);
            }
            if (this.StandbyAllowlistedIp != null)
            {
                context.StandbyAllowlistedIp = new List<System.String>(this.StandbyAllowlistedIp);
            }
            context.StandbyAllowlistedIpsSource = this.StandbyAllowlistedIpsSource;
            context.TimeOfAutoRefreshStart = this.TimeOfAutoRefreshStart;
            
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
            var request = new Amazon.Odb.Model.UpdateAutonomousDatabaseRequest();
            
            if (cmdletContext.AdminPassword != null)
            {
                request.AdminPassword = cmdletContext.AdminPassword;
            }
            if (cmdletContext.AdminPasswordSource != null)
            {
                request.AdminPasswordSource = cmdletContext.AdminPasswordSource;
            }
            
             // populate AdminPasswordSourceConfiguration
            var requestAdminPasswordSourceConfigurationIsNull = true;
            request.AdminPasswordSourceConfiguration = new Amazon.Odb.Model.AdminPasswordSourceConfigurationInput();
            Amazon.Odb.Model.CustomerManagedAwsSecretConfigurationInput requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret = null;
            
             // populate CustomerManagedAwsSecret
            var requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecretIsNull = true;
            requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret = new Amazon.Odb.Model.CustomerManagedAwsSecretConfigurationInput();
            Amazon.Odb.ExternalIdType requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType = null;
            if (cmdletContext.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType != null)
            {
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType = cmdletContext.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType;
            }
            if (requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType != null)
            {
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret.ExternalIdType = requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType;
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecretIsNull = false;
            }
            System.String requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn = null;
            if (cmdletContext.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn != null)
            {
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn = cmdletContext.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn;
            }
            if (requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn != null)
            {
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret.IamRoleArn = requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn;
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecretIsNull = false;
            }
            System.String requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId = null;
            if (cmdletContext.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId != null)
            {
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId = cmdletContext.AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId;
            }
            if (requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId != null)
            {
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret.SecretId = requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_adminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId;
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecretIsNull = false;
            }
             // determine if requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret should be set to null
            if (requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecretIsNull)
            {
                requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret = null;
            }
            if (requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret != null)
            {
                request.AdminPasswordSourceConfiguration.CustomerManagedAwsSecret = requestAdminPasswordSourceConfiguration_adminPasswordSourceConfiguration_CustomerManagedAwsSecret;
                requestAdminPasswordSourceConfigurationIsNull = false;
            }
             // determine if request.AdminPasswordSourceConfiguration should be set to null
            if (requestAdminPasswordSourceConfigurationIsNull)
            {
                request.AdminPasswordSourceConfiguration = null;
            }
            if (cmdletContext.AllowlistedIp != null)
            {
                request.AllowlistedIps = cmdletContext.AllowlistedIp;
            }
            if (cmdletContext.AutonomousDatabaseId != null)
            {
                request.AutonomousDatabaseId = cmdletContext.AutonomousDatabaseId;
            }
            if (cmdletContext.AutonomousMaintenanceScheduleType != null)
            {
                request.AutonomousMaintenanceScheduleType = cmdletContext.AutonomousMaintenanceScheduleType;
            }
            if (cmdletContext.AutoRefreshFrequencyInSecond != null)
            {
                request.AutoRefreshFrequencyInSeconds = cmdletContext.AutoRefreshFrequencyInSecond.Value;
            }
            if (cmdletContext.AutoRefreshPointLagInSecond != null)
            {
                request.AutoRefreshPointLagInSeconds = cmdletContext.AutoRefreshPointLagInSecond.Value;
            }
            if (cmdletContext.BackupRetentionPeriodInDay != null)
            {
                request.BackupRetentionPeriodInDays = cmdletContext.BackupRetentionPeriodInDay.Value;
            }
            if (cmdletContext.ByolComputeCountLimit != null)
            {
                request.ByolComputeCountLimit = cmdletContext.ByolComputeCountLimit.Value;
            }
            if (cmdletContext.ComputeCount != null)
            {
                request.ComputeCount = cmdletContext.ComputeCount.Value;
            }
            if (cmdletContext.CpuCoreCount != null)
            {
                request.CpuCoreCount = cmdletContext.CpuCoreCount.Value;
            }
            if (cmdletContext.CustomerContactsToSendToOCI != null)
            {
                request.CustomerContactsToSendToOCI = cmdletContext.CustomerContactsToSendToOCI;
            }
            if (cmdletContext.DatabaseEdition != null)
            {
                request.DatabaseEdition = cmdletContext.DatabaseEdition;
            }
            if (cmdletContext.DataStorageSizeInGBs != null)
            {
                request.DataStorageSizeInGBs = cmdletContext.DataStorageSizeInGBs.Value;
            }
            if (cmdletContext.DataStorageSizeInTBs != null)
            {
                request.DataStorageSizeInTBs = cmdletContext.DataStorageSizeInTBs.Value;
            }
            if (cmdletContext.DbName != null)
            {
                request.DbName = cmdletContext.DbName;
            }
            if (cmdletContext.DbToolsDetail != null)
            {
                request.DbToolsDetails = cmdletContext.DbToolsDetail;
            }
            if (cmdletContext.DbVersion != null)
            {
                request.DbVersion = cmdletContext.DbVersion;
            }
            if (cmdletContext.DbWorkload != null)
            {
                request.DbWorkload = cmdletContext.DbWorkload;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            
             // populate EncryptionKeyConfiguration
            var requestEncryptionKeyConfigurationIsNull = true;
            request.EncryptionKeyConfiguration = new Amazon.Odb.Model.EncryptionKeyConfigurationInput();
            Amazon.Odb.Model.AwsEncryptionKeyConfigurationInput requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey = null;
            
             // populate AwsEncryptionKey
            var requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKeyIsNull = true;
            requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey = new Amazon.Odb.Model.AwsEncryptionKeyConfigurationInput();
            Amazon.Odb.ExternalIdType requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType = null;
            if (cmdletContext.EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType != null)
            {
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType = cmdletContext.EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType;
            }
            if (requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType != null)
            {
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey.ExternalIdType = requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType;
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKeyIsNull = false;
            }
            System.String requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn = null;
            if (cmdletContext.EncryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn != null)
            {
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn = cmdletContext.EncryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn;
            }
            if (requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn != null)
            {
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey.IamRoleArn = requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn;
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKeyIsNull = false;
            }
            System.String requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId = null;
            if (cmdletContext.EncryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId != null)
            {
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId = cmdletContext.EncryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId;
            }
            if (requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId != null)
            {
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey.KmsKeyId = requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey_encryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId;
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKeyIsNull = false;
            }
             // determine if requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey should be set to null
            if (requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKeyIsNull)
            {
                requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey = null;
            }
            if (requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey != null)
            {
                request.EncryptionKeyConfiguration.AwsEncryptionKey = requestEncryptionKeyConfiguration_encryptionKeyConfiguration_AwsEncryptionKey;
                requestEncryptionKeyConfigurationIsNull = false;
            }
             // determine if request.EncryptionKeyConfiguration should be set to null
            if (requestEncryptionKeyConfigurationIsNull)
            {
                request.EncryptionKeyConfiguration = null;
            }
            if (cmdletContext.EncryptionKeyProvider != null)
            {
                request.EncryptionKeyProvider = cmdletContext.EncryptionKeyProvider;
            }
            if (cmdletContext.IsAutoScalingEnabled != null)
            {
                request.IsAutoScalingEnabled = cmdletContext.IsAutoScalingEnabled.Value;
            }
            if (cmdletContext.IsAutoScalingForStorageEnabled != null)
            {
                request.IsAutoScalingForStorageEnabled = cmdletContext.IsAutoScalingForStorageEnabled.Value;
            }
            if (cmdletContext.IsBackupRetentionLocked != null)
            {
                request.IsBackupRetentionLocked = cmdletContext.IsBackupRetentionLocked.Value;
            }
            if (cmdletContext.IsDisconnectPeer != null)
            {
                request.IsDisconnectPeer = cmdletContext.IsDisconnectPeer.Value;
            }
            if (cmdletContext.IsLocalDataGuardEnabled != null)
            {
                request.IsLocalDataGuardEnabled = cmdletContext.IsLocalDataGuardEnabled.Value;
            }
            if (cmdletContext.IsMtlsConnectionRequired != null)
            {
                request.IsMtlsConnectionRequired = cmdletContext.IsMtlsConnectionRequired.Value;
            }
            if (cmdletContext.IsRefreshableClone != null)
            {
                request.IsRefreshableClone = cmdletContext.IsRefreshableClone.Value;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.LocalAdgAutoFailoverMaxDataLossLimit != null)
            {
                request.LocalAdgAutoFailoverMaxDataLossLimit = cmdletContext.LocalAdgAutoFailoverMaxDataLossLimit.Value;
            }
            
             // populate LongTermBackupSchedule
            var requestLongTermBackupScheduleIsNull = true;
            request.LongTermBackupSchedule = new Amazon.Odb.Model.LongTermBackupSchedule();
            System.Boolean? requestLongTermBackupSchedule_longTermBackupSchedule_IsDisabled = null;
            if (cmdletContext.LongTermBackupSchedule_IsDisabled != null)
            {
                requestLongTermBackupSchedule_longTermBackupSchedule_IsDisabled = cmdletContext.LongTermBackupSchedule_IsDisabled.Value;
            }
            if (requestLongTermBackupSchedule_longTermBackupSchedule_IsDisabled != null)
            {
                request.LongTermBackupSchedule.IsDisabled = requestLongTermBackupSchedule_longTermBackupSchedule_IsDisabled.Value;
                requestLongTermBackupScheduleIsNull = false;
            }
            Amazon.Odb.RepeatCadence requestLongTermBackupSchedule_longTermBackupSchedule_RepeatCadence = null;
            if (cmdletContext.LongTermBackupSchedule_RepeatCadence != null)
            {
                requestLongTermBackupSchedule_longTermBackupSchedule_RepeatCadence = cmdletContext.LongTermBackupSchedule_RepeatCadence;
            }
            if (requestLongTermBackupSchedule_longTermBackupSchedule_RepeatCadence != null)
            {
                request.LongTermBackupSchedule.RepeatCadence = requestLongTermBackupSchedule_longTermBackupSchedule_RepeatCadence;
                requestLongTermBackupScheduleIsNull = false;
            }
            System.Int32? requestLongTermBackupSchedule_longTermBackupSchedule_RetentionPeriodInDay = null;
            if (cmdletContext.LongTermBackupSchedule_RetentionPeriodInDay != null)
            {
                requestLongTermBackupSchedule_longTermBackupSchedule_RetentionPeriodInDay = cmdletContext.LongTermBackupSchedule_RetentionPeriodInDay.Value;
            }
            if (requestLongTermBackupSchedule_longTermBackupSchedule_RetentionPeriodInDay != null)
            {
                request.LongTermBackupSchedule.RetentionPeriodInDays = requestLongTermBackupSchedule_longTermBackupSchedule_RetentionPeriodInDay.Value;
                requestLongTermBackupScheduleIsNull = false;
            }
            System.DateTime? requestLongTermBackupSchedule_longTermBackupSchedule_TimeOfBackup = null;
            if (cmdletContext.LongTermBackupSchedule_TimeOfBackup != null)
            {
                requestLongTermBackupSchedule_longTermBackupSchedule_TimeOfBackup = cmdletContext.LongTermBackupSchedule_TimeOfBackup.Value;
            }
            if (requestLongTermBackupSchedule_longTermBackupSchedule_TimeOfBackup != null)
            {
                request.LongTermBackupSchedule.TimeOfBackup = requestLongTermBackupSchedule_longTermBackupSchedule_TimeOfBackup.Value;
                requestLongTermBackupScheduleIsNull = false;
            }
             // determine if request.LongTermBackupSchedule should be set to null
            if (requestLongTermBackupScheduleIsNull)
            {
                request.LongTermBackupSchedule = null;
            }
            if (cmdletContext.OpenMode != null)
            {
                request.OpenMode = cmdletContext.OpenMode;
            }
            if (cmdletContext.PeerDbId != null)
            {
                request.PeerDbId = cmdletContext.PeerDbId;
            }
            if (cmdletContext.PermissionLevel != null)
            {
                request.PermissionLevel = cmdletContext.PermissionLevel;
            }
            if (cmdletContext.PrivateEndpointIp != null)
            {
                request.PrivateEndpointIp = cmdletContext.PrivateEndpointIp;
            }
            if (cmdletContext.PrivateEndpointLabel != null)
            {
                request.PrivateEndpointLabel = cmdletContext.PrivateEndpointLabel;
            }
            if (cmdletContext.RefreshableMode != null)
            {
                request.RefreshableMode = cmdletContext.RefreshableMode;
            }
            if (cmdletContext.ResourcePoolLeaderId != null)
            {
                request.ResourcePoolLeaderId = cmdletContext.ResourcePoolLeaderId;
            }
            
             // populate ResourcePoolSummary
            var requestResourcePoolSummaryIsNull = true;
            request.ResourcePoolSummary = new Amazon.Odb.Model.ResourcePoolSummary();
            System.Int32? requestResourcePoolSummary_resourcePoolSummary_AvailableComputeCapacity = null;
            if (cmdletContext.ResourcePoolSummary_AvailableComputeCapacity != null)
            {
                requestResourcePoolSummary_resourcePoolSummary_AvailableComputeCapacity = cmdletContext.ResourcePoolSummary_AvailableComputeCapacity.Value;
            }
            if (requestResourcePoolSummary_resourcePoolSummary_AvailableComputeCapacity != null)
            {
                request.ResourcePoolSummary.AvailableComputeCapacity = requestResourcePoolSummary_resourcePoolSummary_AvailableComputeCapacity.Value;
                requestResourcePoolSummaryIsNull = false;
            }
            System.Double? requestResourcePoolSummary_resourcePoolSummary_AvailableStorageCapacityInTBs = null;
            if (cmdletContext.ResourcePoolSummary_AvailableStorageCapacityInTBs != null)
            {
                requestResourcePoolSummary_resourcePoolSummary_AvailableStorageCapacityInTBs = cmdletContext.ResourcePoolSummary_AvailableStorageCapacityInTBs.Value;
            }
            if (requestResourcePoolSummary_resourcePoolSummary_AvailableStorageCapacityInTBs != null)
            {
                request.ResourcePoolSummary.AvailableStorageCapacityInTBs = requestResourcePoolSummary_resourcePoolSummary_AvailableStorageCapacityInTBs.Value;
                requestResourcePoolSummaryIsNull = false;
            }
            System.Boolean? requestResourcePoolSummary_resourcePoolSummary_IsDisabled = null;
            if (cmdletContext.ResourcePoolSummary_IsDisabled != null)
            {
                requestResourcePoolSummary_resourcePoolSummary_IsDisabled = cmdletContext.ResourcePoolSummary_IsDisabled.Value;
            }
            if (requestResourcePoolSummary_resourcePoolSummary_IsDisabled != null)
            {
                request.ResourcePoolSummary.IsDisabled = requestResourcePoolSummary_resourcePoolSummary_IsDisabled.Value;
                requestResourcePoolSummaryIsNull = false;
            }
            System.Int32? requestResourcePoolSummary_resourcePoolSummary_PoolSize = null;
            if (cmdletContext.ResourcePoolSummary_PoolSize != null)
            {
                requestResourcePoolSummary_resourcePoolSummary_PoolSize = cmdletContext.ResourcePoolSummary_PoolSize.Value;
            }
            if (requestResourcePoolSummary_resourcePoolSummary_PoolSize != null)
            {
                request.ResourcePoolSummary.PoolSize = requestResourcePoolSummary_resourcePoolSummary_PoolSize.Value;
                requestResourcePoolSummaryIsNull = false;
            }
            System.Int32? requestResourcePoolSummary_resourcePoolSummary_PoolStorageSizeInTBs = null;
            if (cmdletContext.ResourcePoolSummary_PoolStorageSizeInTBs != null)
            {
                requestResourcePoolSummary_resourcePoolSummary_PoolStorageSizeInTBs = cmdletContext.ResourcePoolSummary_PoolStorageSizeInTBs.Value;
            }
            if (requestResourcePoolSummary_resourcePoolSummary_PoolStorageSizeInTBs != null)
            {
                request.ResourcePoolSummary.PoolStorageSizeInTBs = requestResourcePoolSummary_resourcePoolSummary_PoolStorageSizeInTBs.Value;
                requestResourcePoolSummaryIsNull = false;
            }
            System.Int32? requestResourcePoolSummary_resourcePoolSummary_TotalComputeCapacity = null;
            if (cmdletContext.ResourcePoolSummary_TotalComputeCapacity != null)
            {
                requestResourcePoolSummary_resourcePoolSummary_TotalComputeCapacity = cmdletContext.ResourcePoolSummary_TotalComputeCapacity.Value;
            }
            if (requestResourcePoolSummary_resourcePoolSummary_TotalComputeCapacity != null)
            {
                request.ResourcePoolSummary.TotalComputeCapacity = requestResourcePoolSummary_resourcePoolSummary_TotalComputeCapacity.Value;
                requestResourcePoolSummaryIsNull = false;
            }
             // determine if request.ResourcePoolSummary should be set to null
            if (requestResourcePoolSummaryIsNull)
            {
                request.ResourcePoolSummary = null;
            }
            if (cmdletContext.ScheduledOperation != null)
            {
                request.ScheduledOperations = cmdletContext.ScheduledOperation;
            }
            if (cmdletContext.StandbyAllowlistedIp != null)
            {
                request.StandbyAllowlistedIps = cmdletContext.StandbyAllowlistedIp;
            }
            if (cmdletContext.StandbyAllowlistedIpsSource != null)
            {
                request.StandbyAllowlistedIpsSource = cmdletContext.StandbyAllowlistedIpsSource;
            }
            if (cmdletContext.TimeOfAutoRefreshStart != null)
            {
                request.TimeOfAutoRefreshStart = cmdletContext.TimeOfAutoRefreshStart.Value;
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
        
        private Amazon.Odb.Model.UpdateAutonomousDatabaseResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.UpdateAutonomousDatabaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "UpdateAutonomousDatabase");
            try
            {
                return client.UpdateAutonomousDatabaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AdminPassword { get; set; }
            public Amazon.Odb.AdminPasswordSource AdminPasswordSource { get; set; }
            public Amazon.Odb.ExternalIdType AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType { get; set; }
            public System.String AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn { get; set; }
            public System.String AdminPasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId { get; set; }
            public List<System.String> AllowlistedIp { get; set; }
            public System.String AutonomousDatabaseId { get; set; }
            public Amazon.Odb.AutonomousMaintenanceScheduleType AutonomousMaintenanceScheduleType { get; set; }
            public System.Int32? AutoRefreshFrequencyInSecond { get; set; }
            public System.Int32? AutoRefreshPointLagInSecond { get; set; }
            public System.Int32? BackupRetentionPeriodInDay { get; set; }
            public System.Double? ByolComputeCountLimit { get; set; }
            public System.Double? ComputeCount { get; set; }
            public System.Int32? CpuCoreCount { get; set; }
            public List<Amazon.Odb.Model.CustomerContact> CustomerContactsToSendToOCI { get; set; }
            public Amazon.Odb.DatabaseEdition DatabaseEdition { get; set; }
            public System.Int32? DataStorageSizeInGBs { get; set; }
            public System.Int32? DataStorageSizeInTBs { get; set; }
            public System.String DbName { get; set; }
            public List<Amazon.Odb.Model.DatabaseTool> DbToolsDetail { get; set; }
            public System.String DbVersion { get; set; }
            public Amazon.Odb.DbWorkload DbWorkload { get; set; }
            public System.String DisplayName { get; set; }
            public Amazon.Odb.ExternalIdType EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType { get; set; }
            public System.String EncryptionKeyConfiguration_AwsEncryptionKey_IamRoleArn { get; set; }
            public System.String EncryptionKeyConfiguration_AwsEncryptionKey_KmsKeyId { get; set; }
            public Amazon.Odb.EncryptionKeyProviderInput EncryptionKeyProvider { get; set; }
            public System.Boolean? IsAutoScalingEnabled { get; set; }
            public System.Boolean? IsAutoScalingForStorageEnabled { get; set; }
            public System.Boolean? IsBackupRetentionLocked { get; set; }
            public System.Boolean? IsDisconnectPeer { get; set; }
            public System.Boolean? IsLocalDataGuardEnabled { get; set; }
            public System.Boolean? IsMtlsConnectionRequired { get; set; }
            public System.Boolean? IsRefreshableClone { get; set; }
            public Amazon.Odb.LicenseModel LicenseModel { get; set; }
            public System.Int32? LocalAdgAutoFailoverMaxDataLossLimit { get; set; }
            public System.Boolean? LongTermBackupSchedule_IsDisabled { get; set; }
            public Amazon.Odb.RepeatCadence LongTermBackupSchedule_RepeatCadence { get; set; }
            public System.Int32? LongTermBackupSchedule_RetentionPeriodInDay { get; set; }
            public System.DateTime? LongTermBackupSchedule_TimeOfBackup { get; set; }
            public Amazon.Odb.OpenMode OpenMode { get; set; }
            public System.String PeerDbId { get; set; }
            public Amazon.Odb.PermissionLevel PermissionLevel { get; set; }
            public System.String PrivateEndpointIp { get; set; }
            public System.String PrivateEndpointLabel { get; set; }
            public Amazon.Odb.RefreshableMode RefreshableMode { get; set; }
            public System.String ResourcePoolLeaderId { get; set; }
            public System.Int32? ResourcePoolSummary_AvailableComputeCapacity { get; set; }
            public System.Double? ResourcePoolSummary_AvailableStorageCapacityInTBs { get; set; }
            public System.Boolean? ResourcePoolSummary_IsDisabled { get; set; }
            public System.Int32? ResourcePoolSummary_PoolSize { get; set; }
            public System.Int32? ResourcePoolSummary_PoolStorageSizeInTBs { get; set; }
            public System.Int32? ResourcePoolSummary_TotalComputeCapacity { get; set; }
            public List<Amazon.Odb.Model.ScheduledOperationDetails> ScheduledOperation { get; set; }
            public List<System.String> StandbyAllowlistedIp { get; set; }
            public Amazon.Odb.StandbyAllowlistedIpsSource StandbyAllowlistedIpsSource { get; set; }
            public System.DateTime? TimeOfAutoRefreshStart { get; set; }
            public System.Func<Amazon.Odb.Model.UpdateAutonomousDatabaseResponse, UpdateODBAutonomousDatabaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
