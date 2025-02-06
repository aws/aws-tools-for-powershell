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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates a new Amazon FSx for NetApp ONTAP volume from an existing Amazon FSx volume
    /// backup.
    /// </summary>
    [Cmdlet("New", "FSXVolumeFromBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.Volume")]
    [AWSCmdlet("Calls the Amazon FSx CreateVolumeFromBackup API operation.", Operation = new[] {"CreateVolumeFromBackup"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateVolumeFromBackupResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.Volume or Amazon.FSx.Model.CreateVolumeFromBackupResponse",
        "This cmdlet returns an Amazon.FSx.Model.Volume object.",
        "The service call response (type Amazon.FSx.Model.CreateVolumeFromBackupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFSXVolumeFromBackupCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AggregateConfiguration_Aggregate
        /// <summary>
        /// <para>
        /// <para>Used to specify the names of aggregates on which the volume will be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_AggregateConfiguration_Aggregates")]
        public System.String[] AggregateConfiguration_Aggregate { get; set; }
        #endregion
        
        #region Parameter SnaplockConfiguration_AuditLogVolume
        /// <summary>
        /// <para>
        /// <para>Enables or disables the audit log volume for an FSx for ONTAP SnapLock volume. The
        /// default value is <c>false</c>. If you set <c>AuditLogVolume</c> to <c>true</c>, the
        /// SnapLock volume is created as an audit log volume. The minimum retention period for
        /// an audit log volume is six months. </para><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/how-snaplock-works.html#snaplock-audit-log-volume">
        /// SnapLock audit log volumes</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_AuditLogVolume")]
        public System.Boolean? SnaplockConfiguration_AuditLogVolume { get; set; }
        #endregion
        
        #region Parameter BackupId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String BackupId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter AggregateConfiguration_ConstituentsPerAggregate
        /// <summary>
        /// <para>
        /// <para>Used to explicitly set the number of constituents within the FlexGroup per storage
        /// aggregate. This field is optional when creating a FlexGroup volume. If unspecified,
        /// the default value will be 8. This field cannot be provided when creating a FlexVol
        /// volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_AggregateConfiguration_ConstituentsPerAggregate")]
        public System.Int32? AggregateConfiguration_ConstituentsPerAggregate { get; set; }
        #endregion
        
        #region Parameter TieringPolicy_CoolingPeriod
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days that user data in a volume must remain inactive before
        /// it is considered "cold" and moved to the capacity pool. Used with the <c>AUTO</c>
        /// and <c>SNAPSHOT_ONLY</c> tiering policies. Enter a whole number between 2 and 183.
        /// Default values are 31 days for <c>AUTO</c> and 2 days for <c>SNAPSHOT_ONLY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_TieringPolicy_CoolingPeriod")]
        public System.Int32? TieringPolicy_CoolingPeriod { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_CopyTagsToBackup
        /// <summary>
        /// <para>
        /// <para>A boolean flag indicating whether tags for the volume should be copied to backups.
        /// This value defaults to false. If it's set to true, all tags for the volume are copied
        /// to all automatic and user-initiated backups where the user doesn't specify tags. If
        /// this value is true, and you specify one or more tags, only the specified tags are
        /// copied to backups. If you specify one or more tags when creating a user-initiated
        /// backup, no tags are copied from the volume, regardless of this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_CopyTagsToBackups")]
        public System.Boolean? OntapConfiguration_CopyTagsToBackup { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_JunctionPath
        /// <summary>
        /// <para>
        /// <para>Specifies the location in the SVM's namespace where the volume is mounted. This parameter
        /// is required. The <c>JunctionPath</c> must have a leading forward slash, such as <c>/vol3</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_JunctionPath { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new volume you're creating.</para>
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
        
        #region Parameter TieringPolicy_Name
        /// <summary>
        /// <para>
        /// <para>Specifies the tiering policy used to transition data. Default value is <c>SNAPSHOT_ONLY</c>.</para><ul><li><para><c>SNAPSHOT_ONLY</c> - moves cold snapshots to the capacity pool storage tier.</para></li><li><para><c>AUTO</c> - moves cold user data and snapshots to the capacity pool storage tier
        /// based on your access patterns.</para></li><li><para><c>ALL</c> - moves all user data blocks in both the active file system and Snapshot
        /// copies to the storage pool tier.</para></li><li><para><c>NONE</c> - keeps a volume's data in the primary storage tier, preventing it from
        /// being moved to the capacity pool tier.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_TieringPolicy_Name")]
        [AWSConstantClassSource("Amazon.FSx.TieringPolicyName")]
        public Amazon.FSx.TieringPolicyName TieringPolicy_Name { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_OntapVolumeType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of volume you are creating. Valid values are the following:</para><ul><li><para><c>RW</c> specifies a read/write volume. <c>RW</c> is the default.</para></li><li><para><c>DP</c> specifies a data-protection volume. A <c>DP</c> volume is read-only and
        /// can be used as the destination of a NetApp SnapMirror relationship.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-volumes.html#volume-types">Volume
        /// types</a> in the Amazon FSx for NetApp ONTAP User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.InputOntapVolumeType")]
        public Amazon.FSx.InputOntapVolumeType OntapConfiguration_OntapVolumeType { get; set; }
        #endregion
        
        #region Parameter SnaplockConfiguration_PrivilegedDelete
        /// <summary>
        /// <para>
        /// <para>Enables, disables, or permanently disables privileged delete on an FSx for ONTAP SnapLock
        /// Enterprise volume. Enabling privileged delete allows SnapLock administrators to delete
        /// WORM files even if they have active retention periods. <c>PERMANENTLY_DISABLED</c>
        /// is a terminal state. If privileged delete is permanently disabled on a SnapLock volume,
        /// you can't re-enable it. The default value is <c>DISABLED</c>. </para><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/snaplock-enterprise.html#privileged-delete">Privileged
        /// delete</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_PrivilegedDelete")]
        [AWSConstantClassSource("Amazon.FSx.PrivilegedDelete")]
        public Amazon.FSx.PrivilegedDelete SnaplockConfiguration_PrivilegedDelete { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SecurityStyle
        /// <summary>
        /// <para>
        /// <para>Specifies the security style for the volume. If a volume's security style is not specified,
        /// it is automatically set to the root volume's security style. The security style determines
        /// the type of permissions that FSx for ONTAP uses to control data access. Specify one
        /// of the following values:</para><ul><li><para><c>UNIX</c> if the file system is managed by a UNIX administrator, the majority of
        /// users are NFS clients, and an application accessing the data uses a UNIX user as the
        /// service account. </para></li><li><para><c>NTFS</c> if the file system is managed by a Windows administrator, the majority
        /// of users are SMB clients, and an application accessing the data uses a Windows user
        /// as the service account.</para></li><li><para><c>MIXED</c> This is an advanced setting. For more information, see the topic <a href="https://docs.netapp.com/us-en/ontap/nfs-admin/security-styles-their-effects-concept.html">What
        /// the security styles and their effects are</a> in the NetApp Documentation Center.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-volumes.html#volume-security-style">Volume
        /// security style</a> in the FSx for ONTAP User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.SecurityStyle")]
        public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SizeInByte
        /// <summary>
        /// <para>
        /// <para>Specifies the configured size of the volume, in bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SizeInBytes")]
        public System.Int64? OntapConfiguration_SizeInByte { get; set; }
        #endregion
        
        #region Parameter SnaplockConfiguration_SnaplockType
        /// <summary>
        /// <para>
        /// <para>Specifies the retention mode of an FSx for ONTAP SnapLock volume. After it is set,
        /// it can't be changed. You can choose one of the following retention modes: </para><ul><li><para><c>COMPLIANCE</c>: Files transitioned to write once, read many (WORM) on a Compliance
        /// volume can't be deleted until their retention periods expire. This retention mode
        /// is used to address government or industry-specific mandates or to protect against
        /// ransomware attacks. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/snaplock-compliance.html">SnapLock
        /// Compliance</a>. </para></li><li><para><c>ENTERPRISE</c>: Files transitioned to WORM on an Enterprise volume can be deleted
        /// by authorized users before their retention periods expire using privileged delete.
        /// This retention mode is used to advance an organization's data integrity and internal
        /// compliance or to test retention settings before using SnapLock Compliance. For more
        /// information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/snaplock-enterprise.html">SnapLock
        /// Enterprise</a>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_SnaplockType")]
        [AWSConstantClassSource("Amazon.FSx.SnaplockType")]
        public Amazon.FSx.SnaplockType SnaplockConfiguration_SnaplockType { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SnapshotPolicy
        /// <summary>
        /// <para>
        /// <para>Specifies the snapshot policy for the volume. There are three built-in snapshot policies:</para><ul><li><para><c>default</c>: This is the default policy. A maximum of six hourly snapshots taken
        /// five minutes past the hour. A maximum of two daily snapshots taken Monday through
        /// Saturday at 10 minutes after midnight. A maximum of two weekly snapshots taken every
        /// Sunday at 15 minutes after midnight.</para></li><li><para><c>default-1weekly</c>: This policy is the same as the <c>default</c> policy except
        /// that it only retains one snapshot from the weekly schedule.</para></li><li><para><c>none</c>: This policy does not take any snapshots. This policy can be assigned
        /// to volumes to prevent automatic snapshots from being taken.</para></li></ul><para>You can also provide the name of a custom policy that you created with the ONTAP CLI
        /// or REST API.</para><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/snapshots-ontap.html#snapshot-policies">Snapshot
        /// policies</a> in the Amazon FSx for NetApp ONTAP User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_SnapshotPolicy { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_StorageEfficiencyEnabled
        /// <summary>
        /// <para>
        /// <para>Set to true to enable deduplication, compression, and compaction storage efficiency
        /// features on the volume, or set to false to disable them.</para><para><c>StorageEfficiencyEnabled</c> is required when creating a <c>RW</c> volume (<c>OntapVolumeType</c>
        /// set to <c>RW</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OntapConfiguration_StorageEfficiencyEnabled { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_StorageVirtualMachineId
        /// <summary>
        /// <para>
        /// <para>Specifies the ONTAP SVM in which to create the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_StorageVirtualMachineId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter AutocommitPeriod_Type
        /// <summary>
        /// <para>
        /// <para>Defines the type of time for the autocommit period of a file in an FSx for ONTAP SnapLock
        /// volume. Setting this value to <c>NONE</c> disables autocommit. The default value is
        /// <c>NONE</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_AutocommitPeriod_Type")]
        [AWSConstantClassSource("Amazon.FSx.AutocommitPeriodType")]
        public Amazon.FSx.AutocommitPeriodType AutocommitPeriod_Type { get; set; }
        #endregion
        
        #region Parameter DefaultRetention_Type
        /// <summary>
        /// <para>
        /// <para>Defines the type of time for the retention period of an FSx for ONTAP SnapLock volume.
        /// Set it to one of the valid types. If you set it to <c>INFINITE</c>, the files are
        /// retained forever. If you set it to <c>UNSPECIFIED</c>, the files are retained until
        /// you set an explicit retention period. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_Type")]
        [AWSConstantClassSource("Amazon.FSx.RetentionPeriodType")]
        public Amazon.FSx.RetentionPeriodType DefaultRetention_Type { get; set; }
        #endregion
        
        #region Parameter MaximumRetention_Type
        /// <summary>
        /// <para>
        /// <para>Defines the type of time for the retention period of an FSx for ONTAP SnapLock volume.
        /// Set it to one of the valid types. If you set it to <c>INFINITE</c>, the files are
        /// retained forever. If you set it to <c>UNSPECIFIED</c>, the files are retained until
        /// you set an explicit retention period. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_Type")]
        [AWSConstantClassSource("Amazon.FSx.RetentionPeriodType")]
        public Amazon.FSx.RetentionPeriodType MaximumRetention_Type { get; set; }
        #endregion
        
        #region Parameter MinimumRetention_Type
        /// <summary>
        /// <para>
        /// <para>Defines the type of time for the retention period of an FSx for ONTAP SnapLock volume.
        /// Set it to one of the valid types. If you set it to <c>INFINITE</c>, the files are
        /// retained forever. If you set it to <c>UNSPECIFIED</c>, the files are retained until
        /// you set an explicit retention period. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_Type")]
        [AWSConstantClassSource("Amazon.FSx.RetentionPeriodType")]
        public Amazon.FSx.RetentionPeriodType MinimumRetention_Type { get; set; }
        #endregion
        
        #region Parameter AutocommitPeriod_Value
        /// <summary>
        /// <para>
        /// <para>Defines the amount of time for the autocommit period of a file in an FSx for ONTAP
        /// SnapLock volume. The following ranges are valid: </para><ul><li><para><c>Minutes</c>: 5 - 65,535</para></li><li><para><c>Hours</c>: 1 - 65,535</para></li><li><para><c>Days</c>: 1 - 3,650</para></li><li><para><c>Months</c>: 1 - 120</para></li><li><para><c>Years</c>: 1 - 10</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_AutocommitPeriod_Value")]
        public System.Int32? AutocommitPeriod_Value { get; set; }
        #endregion
        
        #region Parameter DefaultRetention_Value
        /// <summary>
        /// <para>
        /// <para>Defines the amount of time for the retention period of an FSx for ONTAP SnapLock volume.
        /// You can't set a value for <c>INFINITE</c> or <c>UNSPECIFIED</c>. For all other options,
        /// the following ranges are valid: </para><ul><li><para><c>Seconds</c>: 0 - 65,535</para></li><li><para><c>Minutes</c>: 0 - 65,535</para></li><li><para><c>Hours</c>: 0 - 24</para></li><li><para><c>Days</c>: 0 - 365</para></li><li><para><c>Months</c>: 0 - 12</para></li><li><para><c>Years</c>: 0 - 100</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_Value")]
        public System.Int32? DefaultRetention_Value { get; set; }
        #endregion
        
        #region Parameter MaximumRetention_Value
        /// <summary>
        /// <para>
        /// <para>Defines the amount of time for the retention period of an FSx for ONTAP SnapLock volume.
        /// You can't set a value for <c>INFINITE</c> or <c>UNSPECIFIED</c>. For all other options,
        /// the following ranges are valid: </para><ul><li><para><c>Seconds</c>: 0 - 65,535</para></li><li><para><c>Minutes</c>: 0 - 65,535</para></li><li><para><c>Hours</c>: 0 - 24</para></li><li><para><c>Days</c>: 0 - 365</para></li><li><para><c>Months</c>: 0 - 12</para></li><li><para><c>Years</c>: 0 - 100</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_Value")]
        public System.Int32? MaximumRetention_Value { get; set; }
        #endregion
        
        #region Parameter MinimumRetention_Value
        /// <summary>
        /// <para>
        /// <para>Defines the amount of time for the retention period of an FSx for ONTAP SnapLock volume.
        /// You can't set a value for <c>INFINITE</c> or <c>UNSPECIFIED</c>. For all other options,
        /// the following ranges are valid: </para><ul><li><para><c>Seconds</c>: 0 - 65,535</para></li><li><para><c>Minutes</c>: 0 - 65,535</para></li><li><para><c>Hours</c>: 0 - 24</para></li><li><para><c>Days</c>: 0 - 365</para></li><li><para><c>Months</c>: 0 - 12</para></li><li><para><c>Years</c>: 0 - 100</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_Value")]
        public System.Int32? MinimumRetention_Value { get; set; }
        #endregion
        
        #region Parameter SnaplockConfiguration_VolumeAppendModeEnabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables volume-append mode on an FSx for ONTAP SnapLock volume. Volume-append
        /// mode allows you to create WORM-appendable files and write data to them incrementally.
        /// The default value is <c>false</c>. </para><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/worm-state.html#worm-state-append">Volume-append
        /// mode</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SnaplockConfiguration_VolumeAppendModeEnabled")]
        public System.Boolean? SnaplockConfiguration_VolumeAppendModeEnabled { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_VolumeStyle
        /// <summary>
        /// <para>
        /// <para>Use to specify the style of an ONTAP volume. FSx for ONTAP offers two styles of volumes
        /// that you can use for different purposes, FlexVol and FlexGroup volumes. For more information,
        /// see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-volumes.html#volume-styles">Volume
        /// styles</a> in the Amazon FSx for NetApp ONTAP User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.VolumeStyle")]
        public Amazon.FSx.VolumeStyle OntapConfiguration_VolumeStyle { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SizeInMegabyte
        /// <summary>
        /// <para>
        /// <para>Use <c>SizeInBytes</c> instead. Specifies the size of the volume, in megabytes (MB),
        /// that you are creating.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated, use SizeInBytes instead")]
        [Alias("OntapConfiguration_SizeInMegabytes")]
        public System.Int32? OntapConfiguration_SizeInMegabyte { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Volume'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateVolumeFromBackupResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateVolumeFromBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Volume";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXVolumeFromBackup (CreateVolumeFromBackup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateVolumeFromBackupResponse, NewFSXVolumeFromBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BackupId = this.BackupId;
            #if MODULAR
            if (this.BackupId == null && ParameterWasBound(nameof(this.BackupId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AggregateConfiguration_Aggregate != null)
            {
                context.AggregateConfiguration_Aggregate = new List<System.String>(this.AggregateConfiguration_Aggregate);
            }
            context.AggregateConfiguration_ConstituentsPerAggregate = this.AggregateConfiguration_ConstituentsPerAggregate;
            context.OntapConfiguration_CopyTagsToBackup = this.OntapConfiguration_CopyTagsToBackup;
            context.OntapConfiguration_JunctionPath = this.OntapConfiguration_JunctionPath;
            context.OntapConfiguration_OntapVolumeType = this.OntapConfiguration_OntapVolumeType;
            context.OntapConfiguration_SecurityStyle = this.OntapConfiguration_SecurityStyle;
            context.OntapConfiguration_SizeInByte = this.OntapConfiguration_SizeInByte;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.OntapConfiguration_SizeInMegabyte = this.OntapConfiguration_SizeInMegabyte;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SnaplockConfiguration_AuditLogVolume = this.SnaplockConfiguration_AuditLogVolume;
            context.AutocommitPeriod_Type = this.AutocommitPeriod_Type;
            context.AutocommitPeriod_Value = this.AutocommitPeriod_Value;
            context.SnaplockConfiguration_PrivilegedDelete = this.SnaplockConfiguration_PrivilegedDelete;
            context.DefaultRetention_Type = this.DefaultRetention_Type;
            context.DefaultRetention_Value = this.DefaultRetention_Value;
            context.MaximumRetention_Type = this.MaximumRetention_Type;
            context.MaximumRetention_Value = this.MaximumRetention_Value;
            context.MinimumRetention_Type = this.MinimumRetention_Type;
            context.MinimumRetention_Value = this.MinimumRetention_Value;
            context.SnaplockConfiguration_SnaplockType = this.SnaplockConfiguration_SnaplockType;
            context.SnaplockConfiguration_VolumeAppendModeEnabled = this.SnaplockConfiguration_VolumeAppendModeEnabled;
            context.OntapConfiguration_SnapshotPolicy = this.OntapConfiguration_SnapshotPolicy;
            context.OntapConfiguration_StorageEfficiencyEnabled = this.OntapConfiguration_StorageEfficiencyEnabled;
            context.OntapConfiguration_StorageVirtualMachineId = this.OntapConfiguration_StorageVirtualMachineId;
            context.TieringPolicy_CoolingPeriod = this.TieringPolicy_CoolingPeriod;
            context.TieringPolicy_Name = this.TieringPolicy_Name;
            context.OntapConfiguration_VolumeStyle = this.OntapConfiguration_VolumeStyle;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
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
            var request = new Amazon.FSx.Model.CreateVolumeFromBackupRequest();
            
            if (cmdletContext.BackupId != null)
            {
                request.BackupId = cmdletContext.BackupId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OntapConfiguration
            var requestOntapConfigurationIsNull = true;
            request.OntapConfiguration = new Amazon.FSx.Model.CreateOntapVolumeConfiguration();
            System.Boolean? requestOntapConfiguration_ontapConfiguration_CopyTagsToBackup = null;
            if (cmdletContext.OntapConfiguration_CopyTagsToBackup != null)
            {
                requestOntapConfiguration_ontapConfiguration_CopyTagsToBackup = cmdletContext.OntapConfiguration_CopyTagsToBackup.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_CopyTagsToBackup != null)
            {
                request.OntapConfiguration.CopyTagsToBackups = requestOntapConfiguration_ontapConfiguration_CopyTagsToBackup.Value;
                requestOntapConfigurationIsNull = false;
            }
            System.String requestOntapConfiguration_ontapConfiguration_JunctionPath = null;
            if (cmdletContext.OntapConfiguration_JunctionPath != null)
            {
                requestOntapConfiguration_ontapConfiguration_JunctionPath = cmdletContext.OntapConfiguration_JunctionPath;
            }
            if (requestOntapConfiguration_ontapConfiguration_JunctionPath != null)
            {
                request.OntapConfiguration.JunctionPath = requestOntapConfiguration_ontapConfiguration_JunctionPath;
                requestOntapConfigurationIsNull = false;
            }
            Amazon.FSx.InputOntapVolumeType requestOntapConfiguration_ontapConfiguration_OntapVolumeType = null;
            if (cmdletContext.OntapConfiguration_OntapVolumeType != null)
            {
                requestOntapConfiguration_ontapConfiguration_OntapVolumeType = cmdletContext.OntapConfiguration_OntapVolumeType;
            }
            if (requestOntapConfiguration_ontapConfiguration_OntapVolumeType != null)
            {
                request.OntapConfiguration.OntapVolumeType = requestOntapConfiguration_ontapConfiguration_OntapVolumeType;
                requestOntapConfigurationIsNull = false;
            }
            Amazon.FSx.SecurityStyle requestOntapConfiguration_ontapConfiguration_SecurityStyle = null;
            if (cmdletContext.OntapConfiguration_SecurityStyle != null)
            {
                requestOntapConfiguration_ontapConfiguration_SecurityStyle = cmdletContext.OntapConfiguration_SecurityStyle;
            }
            if (requestOntapConfiguration_ontapConfiguration_SecurityStyle != null)
            {
                request.OntapConfiguration.SecurityStyle = requestOntapConfiguration_ontapConfiguration_SecurityStyle;
                requestOntapConfigurationIsNull = false;
            }
            System.Int64? requestOntapConfiguration_ontapConfiguration_SizeInByte = null;
            if (cmdletContext.OntapConfiguration_SizeInByte != null)
            {
                requestOntapConfiguration_ontapConfiguration_SizeInByte = cmdletContext.OntapConfiguration_SizeInByte.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SizeInByte != null)
            {
                request.OntapConfiguration.SizeInBytes = requestOntapConfiguration_ontapConfiguration_SizeInByte.Value;
                requestOntapConfigurationIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Int32? requestOntapConfiguration_ontapConfiguration_SizeInMegabyte = null;
            if (cmdletContext.OntapConfiguration_SizeInMegabyte != null)
            {
                requestOntapConfiguration_ontapConfiguration_SizeInMegabyte = cmdletContext.OntapConfiguration_SizeInMegabyte.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SizeInMegabyte != null)
            {
                request.OntapConfiguration.SizeInMegabytes = requestOntapConfiguration_ontapConfiguration_SizeInMegabyte.Value;
                requestOntapConfigurationIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.String requestOntapConfiguration_ontapConfiguration_SnapshotPolicy = null;
            if (cmdletContext.OntapConfiguration_SnapshotPolicy != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnapshotPolicy = cmdletContext.OntapConfiguration_SnapshotPolicy;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnapshotPolicy != null)
            {
                request.OntapConfiguration.SnapshotPolicy = requestOntapConfiguration_ontapConfiguration_SnapshotPolicy;
                requestOntapConfigurationIsNull = false;
            }
            System.Boolean? requestOntapConfiguration_ontapConfiguration_StorageEfficiencyEnabled = null;
            if (cmdletContext.OntapConfiguration_StorageEfficiencyEnabled != null)
            {
                requestOntapConfiguration_ontapConfiguration_StorageEfficiencyEnabled = cmdletContext.OntapConfiguration_StorageEfficiencyEnabled.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_StorageEfficiencyEnabled != null)
            {
                request.OntapConfiguration.StorageEfficiencyEnabled = requestOntapConfiguration_ontapConfiguration_StorageEfficiencyEnabled.Value;
                requestOntapConfigurationIsNull = false;
            }
            System.String requestOntapConfiguration_ontapConfiguration_StorageVirtualMachineId = null;
            if (cmdletContext.OntapConfiguration_StorageVirtualMachineId != null)
            {
                requestOntapConfiguration_ontapConfiguration_StorageVirtualMachineId = cmdletContext.OntapConfiguration_StorageVirtualMachineId;
            }
            if (requestOntapConfiguration_ontapConfiguration_StorageVirtualMachineId != null)
            {
                request.OntapConfiguration.StorageVirtualMachineId = requestOntapConfiguration_ontapConfiguration_StorageVirtualMachineId;
                requestOntapConfigurationIsNull = false;
            }
            Amazon.FSx.VolumeStyle requestOntapConfiguration_ontapConfiguration_VolumeStyle = null;
            if (cmdletContext.OntapConfiguration_VolumeStyle != null)
            {
                requestOntapConfiguration_ontapConfiguration_VolumeStyle = cmdletContext.OntapConfiguration_VolumeStyle;
            }
            if (requestOntapConfiguration_ontapConfiguration_VolumeStyle != null)
            {
                request.OntapConfiguration.VolumeStyle = requestOntapConfiguration_ontapConfiguration_VolumeStyle;
                requestOntapConfigurationIsNull = false;
            }
            Amazon.FSx.Model.CreateAggregateConfiguration requestOntapConfiguration_ontapConfiguration_AggregateConfiguration = null;
            
             // populate AggregateConfiguration
            var requestOntapConfiguration_ontapConfiguration_AggregateConfigurationIsNull = true;
            requestOntapConfiguration_ontapConfiguration_AggregateConfiguration = new Amazon.FSx.Model.CreateAggregateConfiguration();
            List<System.String> requestOntapConfiguration_ontapConfiguration_AggregateConfiguration_aggregateConfiguration_Aggregate = null;
            if (cmdletContext.AggregateConfiguration_Aggregate != null)
            {
                requestOntapConfiguration_ontapConfiguration_AggregateConfiguration_aggregateConfiguration_Aggregate = cmdletContext.AggregateConfiguration_Aggregate;
            }
            if (requestOntapConfiguration_ontapConfiguration_AggregateConfiguration_aggregateConfiguration_Aggregate != null)
            {
                requestOntapConfiguration_ontapConfiguration_AggregateConfiguration.Aggregates = requestOntapConfiguration_ontapConfiguration_AggregateConfiguration_aggregateConfiguration_Aggregate;
                requestOntapConfiguration_ontapConfiguration_AggregateConfigurationIsNull = false;
            }
            System.Int32? requestOntapConfiguration_ontapConfiguration_AggregateConfiguration_aggregateConfiguration_ConstituentsPerAggregate = null;
            if (cmdletContext.AggregateConfiguration_ConstituentsPerAggregate != null)
            {
                requestOntapConfiguration_ontapConfiguration_AggregateConfiguration_aggregateConfiguration_ConstituentsPerAggregate = cmdletContext.AggregateConfiguration_ConstituentsPerAggregate.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_AggregateConfiguration_aggregateConfiguration_ConstituentsPerAggregate != null)
            {
                requestOntapConfiguration_ontapConfiguration_AggregateConfiguration.ConstituentsPerAggregate = requestOntapConfiguration_ontapConfiguration_AggregateConfiguration_aggregateConfiguration_ConstituentsPerAggregate.Value;
                requestOntapConfiguration_ontapConfiguration_AggregateConfigurationIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_AggregateConfiguration should be set to null
            if (requestOntapConfiguration_ontapConfiguration_AggregateConfigurationIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_AggregateConfiguration = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_AggregateConfiguration != null)
            {
                request.OntapConfiguration.AggregateConfiguration = requestOntapConfiguration_ontapConfiguration_AggregateConfiguration;
                requestOntapConfigurationIsNull = false;
            }
            Amazon.FSx.Model.TieringPolicy requestOntapConfiguration_ontapConfiguration_TieringPolicy = null;
            
             // populate TieringPolicy
            var requestOntapConfiguration_ontapConfiguration_TieringPolicyIsNull = true;
            requestOntapConfiguration_ontapConfiguration_TieringPolicy = new Amazon.FSx.Model.TieringPolicy();
            System.Int32? requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_CoolingPeriod = null;
            if (cmdletContext.TieringPolicy_CoolingPeriod != null)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_CoolingPeriod = cmdletContext.TieringPolicy_CoolingPeriod.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_CoolingPeriod != null)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy.CoolingPeriod = requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_CoolingPeriod.Value;
                requestOntapConfiguration_ontapConfiguration_TieringPolicyIsNull = false;
            }
            Amazon.FSx.TieringPolicyName requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_Name = null;
            if (cmdletContext.TieringPolicy_Name != null)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_Name = cmdletContext.TieringPolicy_Name;
            }
            if (requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_Name != null)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy.Name = requestOntapConfiguration_ontapConfiguration_TieringPolicy_tieringPolicy_Name;
                requestOntapConfiguration_ontapConfiguration_TieringPolicyIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_TieringPolicy should be set to null
            if (requestOntapConfiguration_ontapConfiguration_TieringPolicyIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_TieringPolicy = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_TieringPolicy != null)
            {
                request.OntapConfiguration.TieringPolicy = requestOntapConfiguration_ontapConfiguration_TieringPolicy;
                requestOntapConfigurationIsNull = false;
            }
            Amazon.FSx.Model.CreateSnaplockConfiguration requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration = null;
            
             // populate SnaplockConfiguration
            var requestOntapConfiguration_ontapConfiguration_SnaplockConfigurationIsNull = true;
            requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration = new Amazon.FSx.Model.CreateSnaplockConfiguration();
            System.Boolean? requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_AuditLogVolume = null;
            if (cmdletContext.SnaplockConfiguration_AuditLogVolume != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_AuditLogVolume = cmdletContext.SnaplockConfiguration_AuditLogVolume.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_AuditLogVolume != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration.AuditLogVolume = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_AuditLogVolume.Value;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfigurationIsNull = false;
            }
            Amazon.FSx.PrivilegedDelete requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_PrivilegedDelete = null;
            if (cmdletContext.SnaplockConfiguration_PrivilegedDelete != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_PrivilegedDelete = cmdletContext.SnaplockConfiguration_PrivilegedDelete;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_PrivilegedDelete != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration.PrivilegedDelete = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_PrivilegedDelete;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfigurationIsNull = false;
            }
            Amazon.FSx.SnaplockType requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_SnaplockType = null;
            if (cmdletContext.SnaplockConfiguration_SnaplockType != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_SnaplockType = cmdletContext.SnaplockConfiguration_SnaplockType;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_SnaplockType != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration.SnaplockType = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_SnaplockType;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfigurationIsNull = false;
            }
            System.Boolean? requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_VolumeAppendModeEnabled = null;
            if (cmdletContext.SnaplockConfiguration_VolumeAppendModeEnabled != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_VolumeAppendModeEnabled = cmdletContext.SnaplockConfiguration_VolumeAppendModeEnabled.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_VolumeAppendModeEnabled != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration.VolumeAppendModeEnabled = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_snaplockConfiguration_VolumeAppendModeEnabled.Value;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfigurationIsNull = false;
            }
            Amazon.FSx.Model.AutocommitPeriod requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod = null;
            
             // populate AutocommitPeriod
            var requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriodIsNull = true;
            requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod = new Amazon.FSx.Model.AutocommitPeriod();
            Amazon.FSx.AutocommitPeriodType requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod_autocommitPeriod_Type = null;
            if (cmdletContext.AutocommitPeriod_Type != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod_autocommitPeriod_Type = cmdletContext.AutocommitPeriod_Type;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod_autocommitPeriod_Type != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod.Type = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod_autocommitPeriod_Type;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriodIsNull = false;
            }
            System.Int32? requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod_autocommitPeriod_Value = null;
            if (cmdletContext.AutocommitPeriod_Value != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod_autocommitPeriod_Value = cmdletContext.AutocommitPeriod_Value.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod_autocommitPeriod_Value != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod.Value = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod_autocommitPeriod_Value.Value;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriodIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod should be set to null
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriodIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration.AutocommitPeriod = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_AutocommitPeriod;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfigurationIsNull = false;
            }
            Amazon.FSx.Model.SnaplockRetentionPeriod requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod = null;
            
             // populate RetentionPeriod
            var requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriodIsNull = true;
            requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod = new Amazon.FSx.Model.SnaplockRetentionPeriod();
            Amazon.FSx.Model.RetentionPeriod requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention = null;
            
             // populate DefaultRetention
            var requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetentionIsNull = true;
            requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention = new Amazon.FSx.Model.RetentionPeriod();
            Amazon.FSx.RetentionPeriodType requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_defaultRetention_Type = null;
            if (cmdletContext.DefaultRetention_Type != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_defaultRetention_Type = cmdletContext.DefaultRetention_Type;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_defaultRetention_Type != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention.Type = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_defaultRetention_Type;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetentionIsNull = false;
            }
            System.Int32? requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_defaultRetention_Value = null;
            if (cmdletContext.DefaultRetention_Value != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_defaultRetention_Value = cmdletContext.DefaultRetention_Value.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_defaultRetention_Value != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention.Value = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention_defaultRetention_Value.Value;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetentionIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention should be set to null
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetentionIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod.DefaultRetention = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_DefaultRetention;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriodIsNull = false;
            }
            Amazon.FSx.Model.RetentionPeriod requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention = null;
            
             // populate MaximumRetention
            var requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetentionIsNull = true;
            requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention = new Amazon.FSx.Model.RetentionPeriod();
            Amazon.FSx.RetentionPeriodType requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_maximumRetention_Type = null;
            if (cmdletContext.MaximumRetention_Type != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_maximumRetention_Type = cmdletContext.MaximumRetention_Type;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_maximumRetention_Type != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention.Type = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_maximumRetention_Type;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetentionIsNull = false;
            }
            System.Int32? requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_maximumRetention_Value = null;
            if (cmdletContext.MaximumRetention_Value != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_maximumRetention_Value = cmdletContext.MaximumRetention_Value.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_maximumRetention_Value != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention.Value = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention_maximumRetention_Value.Value;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetentionIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention should be set to null
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetentionIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod.MaximumRetention = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MaximumRetention;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriodIsNull = false;
            }
            Amazon.FSx.Model.RetentionPeriod requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention = null;
            
             // populate MinimumRetention
            var requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetentionIsNull = true;
            requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention = new Amazon.FSx.Model.RetentionPeriod();
            Amazon.FSx.RetentionPeriodType requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_minimumRetention_Type = null;
            if (cmdletContext.MinimumRetention_Type != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_minimumRetention_Type = cmdletContext.MinimumRetention_Type;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_minimumRetention_Type != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention.Type = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_minimumRetention_Type;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetentionIsNull = false;
            }
            System.Int32? requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_minimumRetention_Value = null;
            if (cmdletContext.MinimumRetention_Value != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_minimumRetention_Value = cmdletContext.MinimumRetention_Value.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_minimumRetention_Value != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention.Value = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention_minimumRetention_Value.Value;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetentionIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention should be set to null
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetentionIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod.MinimumRetention = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_ontapConfiguration_SnaplockConfiguration_RetentionPeriod_MinimumRetention;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriodIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod should be set to null
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriodIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod != null)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration.RetentionPeriod = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration_ontapConfiguration_SnaplockConfiguration_RetentionPeriod;
                requestOntapConfiguration_ontapConfiguration_SnaplockConfigurationIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration should be set to null
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfigurationIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration != null)
            {
                request.OntapConfiguration.SnaplockConfiguration = requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration;
                requestOntapConfigurationIsNull = false;
            }
             // determine if request.OntapConfiguration should be set to null
            if (requestOntapConfigurationIsNull)
            {
                request.OntapConfiguration = null;
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
        
        private Amazon.FSx.Model.CreateVolumeFromBackupResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateVolumeFromBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateVolumeFromBackup");
            try
            {
                #if DESKTOP
                return client.CreateVolumeFromBackup(request);
                #elif CORECLR
                return client.CreateVolumeFromBackupAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Name { get; set; }
            public List<System.String> AggregateConfiguration_Aggregate { get; set; }
            public System.Int32? AggregateConfiguration_ConstituentsPerAggregate { get; set; }
            public System.Boolean? OntapConfiguration_CopyTagsToBackup { get; set; }
            public System.String OntapConfiguration_JunctionPath { get; set; }
            public Amazon.FSx.InputOntapVolumeType OntapConfiguration_OntapVolumeType { get; set; }
            public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
            public System.Int64? OntapConfiguration_SizeInByte { get; set; }
            [System.ObsoleteAttribute]
            public System.Int32? OntapConfiguration_SizeInMegabyte { get; set; }
            public System.Boolean? SnaplockConfiguration_AuditLogVolume { get; set; }
            public Amazon.FSx.AutocommitPeriodType AutocommitPeriod_Type { get; set; }
            public System.Int32? AutocommitPeriod_Value { get; set; }
            public Amazon.FSx.PrivilegedDelete SnaplockConfiguration_PrivilegedDelete { get; set; }
            public Amazon.FSx.RetentionPeriodType DefaultRetention_Type { get; set; }
            public System.Int32? DefaultRetention_Value { get; set; }
            public Amazon.FSx.RetentionPeriodType MaximumRetention_Type { get; set; }
            public System.Int32? MaximumRetention_Value { get; set; }
            public Amazon.FSx.RetentionPeriodType MinimumRetention_Type { get; set; }
            public System.Int32? MinimumRetention_Value { get; set; }
            public Amazon.FSx.SnaplockType SnaplockConfiguration_SnaplockType { get; set; }
            public System.Boolean? SnaplockConfiguration_VolumeAppendModeEnabled { get; set; }
            public System.String OntapConfiguration_SnapshotPolicy { get; set; }
            public System.Boolean? OntapConfiguration_StorageEfficiencyEnabled { get; set; }
            public System.String OntapConfiguration_StorageVirtualMachineId { get; set; }
            public System.Int32? TieringPolicy_CoolingPeriod { get; set; }
            public Amazon.FSx.TieringPolicyName TieringPolicy_Name { get; set; }
            public Amazon.FSx.VolumeStyle OntapConfiguration_VolumeStyle { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FSx.Model.CreateVolumeFromBackupResponse, NewFSXVolumeFromBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Volume;
        }
        
    }
}
