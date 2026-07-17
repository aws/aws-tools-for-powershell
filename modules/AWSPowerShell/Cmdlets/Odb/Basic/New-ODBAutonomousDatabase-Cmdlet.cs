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
    /// Creates a new Autonomous Database.
    /// </summary>
    [Cmdlet("New", "ODBAutonomousDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.CreateAutonomousDatabaseResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services CreateAutonomousDatabase API operation.", Operation = new[] {"CreateAutonomousDatabase"}, SelectReturnType = typeof(Amazon.Odb.Model.CreateAutonomousDatabaseResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.CreateAutonomousDatabaseResponse",
        "This cmdlet returns an Amazon.Odb.Model.CreateAutonomousDatabaseResponse object containing multiple properties."
    )]
    public partial class NewODBAutonomousDatabaseCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdminPassword
        /// <summary>
        /// <para>
        /// <para>The password for the <c>ADMIN</c> user of the Autonomous Database.</para>
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
        
        #region Parameter SourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Autonomous Database backup to restore from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId { get; set; }
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
        
        #region Parameter SourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond
        /// <summary>
        /// <para>
        /// <para>The frequency, in seconds, at which the refreshable clone is automatically refreshed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSeconds")]
        public System.Int32? SourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond
        /// <summary>
        /// <para>
        /// <para>The time lag, in seconds, between the refreshable clone and its source database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSeconds")]
        public System.Int32? SourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond { get; set; }
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
        
        #region Parameter CharacterSet
        /// <summary>
        /// <para>
        /// <para>The character set to use for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CharacterSet { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_PointInTimeRestore_CloneTableSpaceList
        /// <summary>
        /// <para>
        /// <para>The list of tablespace identifiers to clone from the point-in-time restore.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] SourceConfiguration_PointInTimeRestore_CloneTableSpaceList { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_RestoreFromBackup_CloneTableSpaceList
        /// <summary>
        /// <para>
        /// <para>The list of tablespace identifiers to clone from the backup.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] SourceConfiguration_RestoreFromBackup_CloneTableSpaceList { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_CloneToRefreshable_CloneType
        /// <summary>
        /// <para>
        /// <para>The type of clone to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.CloneType")]
        public Amazon.Odb.CloneType SourceConfiguration_CloneToRefreshable_CloneType { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_DatabaseClone_CloneType
        /// <summary>
        /// <para>
        /// <para>The type of clone to create, either a full clone, a metadata clone, or a partial clone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.CloneType")]
        public Amazon.Odb.CloneType SourceConfiguration_DatabaseClone_CloneType { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_PointInTimeRestore_CloneType
        /// <summary>
        /// <para>
        /// <para>The type of clone to create from the point-in-time restore.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.CloneType")]
        public Amazon.Odb.CloneType SourceConfiguration_PointInTimeRestore_CloneType { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_RestoreFromBackup_CloneType
        /// <summary>
        /// <para>
        /// <para>The type of clone to create from the backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.CloneType")]
        public Amazon.Odb.CloneType SourceConfiguration_RestoreFromBackup_CloneType { get; set; }
        #endregion
        
        #region Parameter ComputeCount
        /// <summary>
        /// <para>
        /// <para>The compute capacity, in number of Elastic CPUs (ECPUs) or Oracle CPUs (OCPUs), to
        /// assign to the Autonomous Database.</para>
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
        /// <para>The list of customer contacts to receive operational notifications from Oracle Cloud
        /// Infrastructure (OCI) for the Autonomous Database.</para><para />
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
        /// <para>The name of the Autonomous Database. The name must begin with an alphabetic character
        /// and can contain a maximum of 30 alphanumeric characters. Special characters are not
        /// permitted. The name must be unique in the Amazon Web Services account.</para>
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
        /// <para>The user-friendly name for the Autonomous Database. The name does not have to be unique.</para>
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
        
        #region Parameter ResourcePoolSummary_IsDisabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the resource pool is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ResourcePoolSummary_IsDisabled { get; set; }
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
        
        #region Parameter SourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup
        /// <summary>
        /// <para>
        /// <para>Indicates whether automatic backups are replicated to the disaster recovery database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackups")]
        public System.Boolean? SourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup { get; set; }
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
        
        #region Parameter NcharacterSet
        /// <summary>
        /// <para>
        /// <para>The national character set to use for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NcharacterSet { get; set; }
        #endregion
        
        #region Parameter OdbNetworkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the ODB network to be used for the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OdbNetworkId { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_CloneToRefreshable_OpenMode
        /// <summary>
        /// <para>
        /// <para>The mode in which to open the refreshable clone, either read-only or read/write.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.OpenMode")]
        public Amazon.Odb.OpenMode SourceConfiguration_CloneToRefreshable_OpenMode { get; set; }
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
        
        #region Parameter SourceConfiguration_CloneToRefreshable_RefreshableMode
        /// <summary>
        /// <para>
        /// <para>The refresh mode of the refreshable clone, either automatic or manual.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.RefreshableMode")]
        public Amazon.Odb.RefreshableMode SourceConfiguration_CloneToRefreshable_RefreshableMode { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType
        /// <summary>
        /// <para>
        /// <para>The type of remote disaster recovery to configure, either Autonomous Data Guard or
        /// backup-based.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.DisasterRecoveryType")]
        public Amazon.Odb.DisasterRecoveryType SourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType { get; set; }
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
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The source from which to create the Autonomous Database, such as a clone, backup,
        /// or cross-Region copy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.SourceType")]
        public Amazon.Odb.SourceType Source { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source Autonomous Database for the cross-Region
        /// Oracle Data Guard configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source Autonomous Database for the cross-Region
        /// disaster recovery configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the source Autonomous Database to create the refreshable
        /// clone from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the source Autonomous Database to clone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the source Autonomous Database to restore from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of resource tags to apply to the Autonomous Database. Each tag is a key-value
        /// pair with no predefined name, type, or namespace.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart
        /// <summary>
        /// <para>
        /// <para>The date and time at which the automatic refresh of the refreshable clone starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_PointInTimeRestore_Timestamp
        /// <summary>
        /// <para>
        /// <para>The date and time to which to restore the Autonomous Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SourceConfiguration_PointInTimeRestore_Timestamp { get; set; }
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
        
        #region Parameter TransportableTablespace_TtsBundleUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the transportable tablespace bundle to use when creating the Autonomous
        /// Database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransportableTablespace_TtsBundleUrl { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp
        /// <summary>
        /// <para>
        /// <para>Indicates whether to use the latest available backup timestamp for the restore.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A client-provided token to ensure the idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.CreateAutonomousDatabaseResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.CreateAutonomousDatabaseResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ODBAutonomousDatabase (CreateAutonomousDatabase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.CreateAutonomousDatabaseResponse, NewODBAutonomousDatabaseCmdlet>(Select) ??
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
            context.AutonomousMaintenanceScheduleType = this.AutonomousMaintenanceScheduleType;
            context.BackupRetentionPeriodInDay = this.BackupRetentionPeriodInDay;
            context.ByolComputeCountLimit = this.ByolComputeCountLimit;
            context.CharacterSet = this.CharacterSet;
            context.ClientToken = this.ClientToken;
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
            context.IsLocalDataGuardEnabled = this.IsLocalDataGuardEnabled;
            context.IsMtlsConnectionRequired = this.IsMtlsConnectionRequired;
            context.LicenseModel = this.LicenseModel;
            context.NcharacterSet = this.NcharacterSet;
            context.OdbNetworkId = this.OdbNetworkId;
            context.PrivateEndpointIp = this.PrivateEndpointIp;
            context.PrivateEndpointLabel = this.PrivateEndpointLabel;
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
            context.Source = this.Source;
            context.SourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond = this.SourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond;
            context.SourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond = this.SourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond;
            context.SourceConfiguration_CloneToRefreshable_CloneType = this.SourceConfiguration_CloneToRefreshable_CloneType;
            context.SourceConfiguration_CloneToRefreshable_OpenMode = this.SourceConfiguration_CloneToRefreshable_OpenMode;
            context.SourceConfiguration_CloneToRefreshable_RefreshableMode = this.SourceConfiguration_CloneToRefreshable_RefreshableMode;
            context.SourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId = this.SourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId;
            context.SourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart = this.SourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart;
            context.SourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn = this.SourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn;
            context.SourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup = this.SourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup;
            context.SourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType = this.SourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType;
            context.SourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn = this.SourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn;
            context.SourceConfiguration_DatabaseClone_CloneType = this.SourceConfiguration_DatabaseClone_CloneType;
            context.SourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId = this.SourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId;
            if (this.SourceConfiguration_PointInTimeRestore_CloneTableSpaceList != null)
            {
                context.SourceConfiguration_PointInTimeRestore_CloneTableSpaceList = new List<System.Int32>(this.SourceConfiguration_PointInTimeRestore_CloneTableSpaceList);
            }
            context.SourceConfiguration_PointInTimeRestore_CloneType = this.SourceConfiguration_PointInTimeRestore_CloneType;
            context.SourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId = this.SourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId;
            context.SourceConfiguration_PointInTimeRestore_Timestamp = this.SourceConfiguration_PointInTimeRestore_Timestamp;
            context.SourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp = this.SourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp;
            context.SourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId = this.SourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId;
            if (this.SourceConfiguration_RestoreFromBackup_CloneTableSpaceList != null)
            {
                context.SourceConfiguration_RestoreFromBackup_CloneTableSpaceList = new List<System.Int32>(this.SourceConfiguration_RestoreFromBackup_CloneTableSpaceList);
            }
            context.SourceConfiguration_RestoreFromBackup_CloneType = this.SourceConfiguration_RestoreFromBackup_CloneType;
            if (this.StandbyAllowlistedIp != null)
            {
                context.StandbyAllowlistedIp = new List<System.String>(this.StandbyAllowlistedIp);
            }
            context.StandbyAllowlistedIpsSource = this.StandbyAllowlistedIpsSource;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TransportableTablespace_TtsBundleUrl = this.TransportableTablespace_TtsBundleUrl;
            
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
            var request = new Amazon.Odb.Model.CreateAutonomousDatabaseRequest();
            
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
            if (cmdletContext.AutonomousMaintenanceScheduleType != null)
            {
                request.AutonomousMaintenanceScheduleType = cmdletContext.AutonomousMaintenanceScheduleType;
            }
            if (cmdletContext.BackupRetentionPeriodInDay != null)
            {
                request.BackupRetentionPeriodInDays = cmdletContext.BackupRetentionPeriodInDay.Value;
            }
            if (cmdletContext.ByolComputeCountLimit != null)
            {
                request.ByolComputeCountLimit = cmdletContext.ByolComputeCountLimit.Value;
            }
            if (cmdletContext.CharacterSet != null)
            {
                request.CharacterSet = cmdletContext.CharacterSet;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
            if (cmdletContext.IsLocalDataGuardEnabled != null)
            {
                request.IsLocalDataGuardEnabled = cmdletContext.IsLocalDataGuardEnabled.Value;
            }
            if (cmdletContext.IsMtlsConnectionRequired != null)
            {
                request.IsMtlsConnectionRequired = cmdletContext.IsMtlsConnectionRequired.Value;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.NcharacterSet != null)
            {
                request.NcharacterSet = cmdletContext.NcharacterSet;
            }
            if (cmdletContext.OdbNetworkId != null)
            {
                request.OdbNetworkId = cmdletContext.OdbNetworkId;
            }
            if (cmdletContext.PrivateEndpointIp != null)
            {
                request.PrivateEndpointIp = cmdletContext.PrivateEndpointIp;
            }
            if (cmdletContext.PrivateEndpointLabel != null)
            {
                request.PrivateEndpointLabel = cmdletContext.PrivateEndpointLabel;
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
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            
             // populate SourceConfiguration
            var requestSourceConfigurationIsNull = true;
            request.SourceConfiguration = new Amazon.Odb.Model.SourceConfiguration();
            Amazon.Odb.Model.CrossRegionDataGuardConfiguration requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard = null;
            
             // populate CrossRegionDataGuard
            var requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuardIsNull = true;
            requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard = new Amazon.Odb.Model.CrossRegionDataGuardConfiguration();
            System.String requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard_sourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn = null;
            if (cmdletContext.SourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard_sourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn = cmdletContext.SourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn;
            }
            if (requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard_sourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard.SourceAutonomousDatabaseArn = requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard_sourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn;
                requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuardIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard should be set to null
            if (requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuardIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard != null)
            {
                request.SourceConfiguration.CrossRegionDataGuard = requestSourceConfiguration_sourceConfiguration_CrossRegionDataGuard;
                requestSourceConfigurationIsNull = false;
            }
            Amazon.Odb.Model.DatabaseCloneConfiguration requestSourceConfiguration_sourceConfiguration_DatabaseClone = null;
            
             // populate DatabaseClone
            var requestSourceConfiguration_sourceConfiguration_DatabaseCloneIsNull = true;
            requestSourceConfiguration_sourceConfiguration_DatabaseClone = new Amazon.Odb.Model.DatabaseCloneConfiguration();
            Amazon.Odb.CloneType requestSourceConfiguration_sourceConfiguration_DatabaseClone_sourceConfiguration_DatabaseClone_CloneType = null;
            if (cmdletContext.SourceConfiguration_DatabaseClone_CloneType != null)
            {
                requestSourceConfiguration_sourceConfiguration_DatabaseClone_sourceConfiguration_DatabaseClone_CloneType = cmdletContext.SourceConfiguration_DatabaseClone_CloneType;
            }
            if (requestSourceConfiguration_sourceConfiguration_DatabaseClone_sourceConfiguration_DatabaseClone_CloneType != null)
            {
                requestSourceConfiguration_sourceConfiguration_DatabaseClone.CloneType = requestSourceConfiguration_sourceConfiguration_DatabaseClone_sourceConfiguration_DatabaseClone_CloneType;
                requestSourceConfiguration_sourceConfiguration_DatabaseCloneIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_DatabaseClone_sourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId = null;
            if (cmdletContext.SourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId != null)
            {
                requestSourceConfiguration_sourceConfiguration_DatabaseClone_sourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId = cmdletContext.SourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId;
            }
            if (requestSourceConfiguration_sourceConfiguration_DatabaseClone_sourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId != null)
            {
                requestSourceConfiguration_sourceConfiguration_DatabaseClone.SourceAutonomousDatabaseId = requestSourceConfiguration_sourceConfiguration_DatabaseClone_sourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId;
                requestSourceConfiguration_sourceConfiguration_DatabaseCloneIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_DatabaseClone should be set to null
            if (requestSourceConfiguration_sourceConfiguration_DatabaseCloneIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_DatabaseClone = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_DatabaseClone != null)
            {
                request.SourceConfiguration.DatabaseClone = requestSourceConfiguration_sourceConfiguration_DatabaseClone;
                requestSourceConfigurationIsNull = false;
            }
            Amazon.Odb.Model.CrossRegionDisasterRecoveryConfiguration requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery = null;
            
             // populate CrossRegionDisasterRecovery
            var requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecoveryIsNull = true;
            requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery = new Amazon.Odb.Model.CrossRegionDisasterRecoveryConfiguration();
            System.Boolean? requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup = null;
            if (cmdletContext.SourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup != null)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup = cmdletContext.SourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup.Value;
            }
            if (requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup != null)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery.IsReplicateAutomaticBackups = requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup.Value;
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecoveryIsNull = false;
            }
            Amazon.Odb.DisasterRecoveryType requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType = null;
            if (cmdletContext.SourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType != null)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType = cmdletContext.SourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType;
            }
            if (requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType != null)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery.RemoteDisasterRecoveryType = requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType;
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecoveryIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn = null;
            if (cmdletContext.SourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn = cmdletContext.SourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn;
            }
            if (requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery.SourceAutonomousDatabaseArn = requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery_sourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn;
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecoveryIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery should be set to null
            if (requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecoveryIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery != null)
            {
                request.SourceConfiguration.CrossRegionDisasterRecovery = requestSourceConfiguration_sourceConfiguration_CrossRegionDisasterRecovery;
                requestSourceConfigurationIsNull = false;
            }
            Amazon.Odb.Model.RestoreFromBackupConfiguration requestSourceConfiguration_sourceConfiguration_RestoreFromBackup = null;
            
             // populate RestoreFromBackup
            var requestSourceConfiguration_sourceConfiguration_RestoreFromBackupIsNull = true;
            requestSourceConfiguration_sourceConfiguration_RestoreFromBackup = new Amazon.Odb.Model.RestoreFromBackupConfiguration();
            System.String requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId = null;
            if (cmdletContext.SourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId != null)
            {
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId = cmdletContext.SourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId;
            }
            if (requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId != null)
            {
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackup.AutonomousDatabaseBackupId = requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId;
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackupIsNull = false;
            }
            List<System.Int32> requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_CloneTableSpaceList = null;
            if (cmdletContext.SourceConfiguration_RestoreFromBackup_CloneTableSpaceList != null)
            {
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_CloneTableSpaceList = cmdletContext.SourceConfiguration_RestoreFromBackup_CloneTableSpaceList;
            }
            if (requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_CloneTableSpaceList != null)
            {
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackup.CloneTableSpaceList = requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_CloneTableSpaceList;
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackupIsNull = false;
            }
            Amazon.Odb.CloneType requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_CloneType = null;
            if (cmdletContext.SourceConfiguration_RestoreFromBackup_CloneType != null)
            {
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_CloneType = cmdletContext.SourceConfiguration_RestoreFromBackup_CloneType;
            }
            if (requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_CloneType != null)
            {
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackup.CloneType = requestSourceConfiguration_sourceConfiguration_RestoreFromBackup_sourceConfiguration_RestoreFromBackup_CloneType;
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackupIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_RestoreFromBackup should be set to null
            if (requestSourceConfiguration_sourceConfiguration_RestoreFromBackupIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_RestoreFromBackup = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_RestoreFromBackup != null)
            {
                request.SourceConfiguration.RestoreFromBackup = requestSourceConfiguration_sourceConfiguration_RestoreFromBackup;
                requestSourceConfigurationIsNull = false;
            }
            Amazon.Odb.Model.PointInTimeRestoreConfiguration requestSourceConfiguration_sourceConfiguration_PointInTimeRestore = null;
            
             // populate PointInTimeRestore
            var requestSourceConfiguration_sourceConfiguration_PointInTimeRestoreIsNull = true;
            requestSourceConfiguration_sourceConfiguration_PointInTimeRestore = new Amazon.Odb.Model.PointInTimeRestoreConfiguration();
            List<System.Int32> requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_CloneTableSpaceList = null;
            if (cmdletContext.SourceConfiguration_PointInTimeRestore_CloneTableSpaceList != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_CloneTableSpaceList = cmdletContext.SourceConfiguration_PointInTimeRestore_CloneTableSpaceList;
            }
            if (requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_CloneTableSpaceList != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore.CloneTableSpaceList = requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_CloneTableSpaceList;
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestoreIsNull = false;
            }
            Amazon.Odb.CloneType requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_CloneType = null;
            if (cmdletContext.SourceConfiguration_PointInTimeRestore_CloneType != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_CloneType = cmdletContext.SourceConfiguration_PointInTimeRestore_CloneType;
            }
            if (requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_CloneType != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore.CloneType = requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_CloneType;
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestoreIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId = null;
            if (cmdletContext.SourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId = cmdletContext.SourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId;
            }
            if (requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore.SourceAutonomousDatabaseId = requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId;
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestoreIsNull = false;
            }
            System.DateTime? requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_Timestamp = null;
            if (cmdletContext.SourceConfiguration_PointInTimeRestore_Timestamp != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_Timestamp = cmdletContext.SourceConfiguration_PointInTimeRestore_Timestamp.Value;
            }
            if (requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_Timestamp != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore.Timestamp = requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_Timestamp.Value;
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestoreIsNull = false;
            }
            System.Boolean? requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp = null;
            if (cmdletContext.SourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp = cmdletContext.SourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp.Value;
            }
            if (requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp != null)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore.UseLatestAvailableBackupTimestamp = requestSourceConfiguration_sourceConfiguration_PointInTimeRestore_sourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp.Value;
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestoreIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_PointInTimeRestore should be set to null
            if (requestSourceConfiguration_sourceConfiguration_PointInTimeRestoreIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_PointInTimeRestore = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_PointInTimeRestore != null)
            {
                request.SourceConfiguration.PointInTimeRestore = requestSourceConfiguration_sourceConfiguration_PointInTimeRestore;
                requestSourceConfigurationIsNull = false;
            }
            Amazon.Odb.Model.CloneToRefreshableConfiguration requestSourceConfiguration_sourceConfiguration_CloneToRefreshable = null;
            
             // populate CloneToRefreshable
            var requestSourceConfiguration_sourceConfiguration_CloneToRefreshableIsNull = true;
            requestSourceConfiguration_sourceConfiguration_CloneToRefreshable = new Amazon.Odb.Model.CloneToRefreshableConfiguration();
            System.Int32? requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond = null;
            if (cmdletContext.SourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond = cmdletContext.SourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond.Value;
            }
            if (requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable.AutoRefreshFrequencyInSeconds = requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond.Value;
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshableIsNull = false;
            }
            System.Int32? requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond = null;
            if (cmdletContext.SourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond = cmdletContext.SourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond.Value;
            }
            if (requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable.AutoRefreshPointLagInSeconds = requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond.Value;
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshableIsNull = false;
            }
            Amazon.Odb.CloneType requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_CloneType = null;
            if (cmdletContext.SourceConfiguration_CloneToRefreshable_CloneType != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_CloneType = cmdletContext.SourceConfiguration_CloneToRefreshable_CloneType;
            }
            if (requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_CloneType != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable.CloneType = requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_CloneType;
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshableIsNull = false;
            }
            Amazon.Odb.OpenMode requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_OpenMode = null;
            if (cmdletContext.SourceConfiguration_CloneToRefreshable_OpenMode != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_OpenMode = cmdletContext.SourceConfiguration_CloneToRefreshable_OpenMode;
            }
            if (requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_OpenMode != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable.OpenMode = requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_OpenMode;
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshableIsNull = false;
            }
            Amazon.Odb.RefreshableMode requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_RefreshableMode = null;
            if (cmdletContext.SourceConfiguration_CloneToRefreshable_RefreshableMode != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_RefreshableMode = cmdletContext.SourceConfiguration_CloneToRefreshable_RefreshableMode;
            }
            if (requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_RefreshableMode != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable.RefreshableMode = requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_RefreshableMode;
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshableIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId = null;
            if (cmdletContext.SourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId = cmdletContext.SourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId;
            }
            if (requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable.SourceAutonomousDatabaseId = requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId;
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshableIsNull = false;
            }
            System.DateTime? requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart = null;
            if (cmdletContext.SourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart = cmdletContext.SourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart.Value;
            }
            if (requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart != null)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable.TimeOfAutoRefreshStart = requestSourceConfiguration_sourceConfiguration_CloneToRefreshable_sourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart.Value;
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshableIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_CloneToRefreshable should be set to null
            if (requestSourceConfiguration_sourceConfiguration_CloneToRefreshableIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_CloneToRefreshable = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_CloneToRefreshable != null)
            {
                request.SourceConfiguration.CloneToRefreshable = requestSourceConfiguration_sourceConfiguration_CloneToRefreshable;
                requestSourceConfigurationIsNull = false;
            }
             // determine if request.SourceConfiguration should be set to null
            if (requestSourceConfigurationIsNull)
            {
                request.SourceConfiguration = null;
            }
            if (cmdletContext.StandbyAllowlistedIp != null)
            {
                request.StandbyAllowlistedIps = cmdletContext.StandbyAllowlistedIp;
            }
            if (cmdletContext.StandbyAllowlistedIpsSource != null)
            {
                request.StandbyAllowlistedIpsSource = cmdletContext.StandbyAllowlistedIpsSource;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TransportableTablespace
            var requestTransportableTablespaceIsNull = true;
            request.TransportableTablespace = new Amazon.Odb.Model.TransportableTablespace();
            System.String requestTransportableTablespace_transportableTablespace_TtsBundleUrl = null;
            if (cmdletContext.TransportableTablespace_TtsBundleUrl != null)
            {
                requestTransportableTablespace_transportableTablespace_TtsBundleUrl = cmdletContext.TransportableTablespace_TtsBundleUrl;
            }
            if (requestTransportableTablespace_transportableTablespace_TtsBundleUrl != null)
            {
                request.TransportableTablespace.TtsBundleUrl = requestTransportableTablespace_transportableTablespace_TtsBundleUrl;
                requestTransportableTablespaceIsNull = false;
            }
             // determine if request.TransportableTablespace should be set to null
            if (requestTransportableTablespaceIsNull)
            {
                request.TransportableTablespace = null;
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
        
        private Amazon.Odb.Model.CreateAutonomousDatabaseResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.CreateAutonomousDatabaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "CreateAutonomousDatabase");
            try
            {
                return client.CreateAutonomousDatabaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Odb.AutonomousMaintenanceScheduleType AutonomousMaintenanceScheduleType { get; set; }
            public System.Int32? BackupRetentionPeriodInDay { get; set; }
            public System.Double? ByolComputeCountLimit { get; set; }
            public System.String CharacterSet { get; set; }
            public System.String ClientToken { get; set; }
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
            public System.Boolean? IsLocalDataGuardEnabled { get; set; }
            public System.Boolean? IsMtlsConnectionRequired { get; set; }
            public Amazon.Odb.LicenseModel LicenseModel { get; set; }
            public System.String NcharacterSet { get; set; }
            public System.String OdbNetworkId { get; set; }
            public System.String PrivateEndpointIp { get; set; }
            public System.String PrivateEndpointLabel { get; set; }
            public System.String ResourcePoolLeaderId { get; set; }
            public System.Int32? ResourcePoolSummary_AvailableComputeCapacity { get; set; }
            public System.Double? ResourcePoolSummary_AvailableStorageCapacityInTBs { get; set; }
            public System.Boolean? ResourcePoolSummary_IsDisabled { get; set; }
            public System.Int32? ResourcePoolSummary_PoolSize { get; set; }
            public System.Int32? ResourcePoolSummary_PoolStorageSizeInTBs { get; set; }
            public System.Int32? ResourcePoolSummary_TotalComputeCapacity { get; set; }
            public List<Amazon.Odb.Model.ScheduledOperationDetails> ScheduledOperation { get; set; }
            public Amazon.Odb.SourceType Source { get; set; }
            public System.Int32? SourceConfiguration_CloneToRefreshable_AutoRefreshFrequencyInSecond { get; set; }
            public System.Int32? SourceConfiguration_CloneToRefreshable_AutoRefreshPointLagInSecond { get; set; }
            public Amazon.Odb.CloneType SourceConfiguration_CloneToRefreshable_CloneType { get; set; }
            public Amazon.Odb.OpenMode SourceConfiguration_CloneToRefreshable_OpenMode { get; set; }
            public Amazon.Odb.RefreshableMode SourceConfiguration_CloneToRefreshable_RefreshableMode { get; set; }
            public System.String SourceConfiguration_CloneToRefreshable_SourceAutonomousDatabaseId { get; set; }
            public System.DateTime? SourceConfiguration_CloneToRefreshable_TimeOfAutoRefreshStart { get; set; }
            public System.String SourceConfiguration_CrossRegionDataGuard_SourceAutonomousDatabaseArn { get; set; }
            public System.Boolean? SourceConfiguration_CrossRegionDisasterRecovery_IsReplicateAutomaticBackup { get; set; }
            public Amazon.Odb.DisasterRecoveryType SourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType { get; set; }
            public System.String SourceConfiguration_CrossRegionDisasterRecovery_SourceAutonomousDatabaseArn { get; set; }
            public Amazon.Odb.CloneType SourceConfiguration_DatabaseClone_CloneType { get; set; }
            public System.String SourceConfiguration_DatabaseClone_SourceAutonomousDatabaseId { get; set; }
            public List<System.Int32> SourceConfiguration_PointInTimeRestore_CloneTableSpaceList { get; set; }
            public Amazon.Odb.CloneType SourceConfiguration_PointInTimeRestore_CloneType { get; set; }
            public System.String SourceConfiguration_PointInTimeRestore_SourceAutonomousDatabaseId { get; set; }
            public System.DateTime? SourceConfiguration_PointInTimeRestore_Timestamp { get; set; }
            public System.Boolean? SourceConfiguration_PointInTimeRestore_UseLatestAvailableBackupTimestamp { get; set; }
            public System.String SourceConfiguration_RestoreFromBackup_AutonomousDatabaseBackupId { get; set; }
            public List<System.Int32> SourceConfiguration_RestoreFromBackup_CloneTableSpaceList { get; set; }
            public Amazon.Odb.CloneType SourceConfiguration_RestoreFromBackup_CloneType { get; set; }
            public List<System.String> StandbyAllowlistedIp { get; set; }
            public Amazon.Odb.StandbyAllowlistedIpsSource StandbyAllowlistedIpsSource { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TransportableTablespace_TtsBundleUrl { get; set; }
            public System.Func<Amazon.Odb.Model.CreateAutonomousDatabaseResponse, NewODBAutonomousDatabaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
