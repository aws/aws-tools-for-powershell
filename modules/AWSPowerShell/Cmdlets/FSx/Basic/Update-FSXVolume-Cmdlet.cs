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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Updates the configuration of an Amazon FSx for NetApp ONTAP or Amazon FSx for OpenZFS
    /// volume.
    /// </summary>
    [Cmdlet("Update", "FSXVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.Volume")]
    [AWSCmdlet("Calls the Amazon FSx UpdateVolume API operation.", Operation = new[] {"UpdateVolume"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateVolumeResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.Volume or Amazon.FSx.Model.UpdateVolumeResponse",
        "This cmdlet returns an Amazon.FSx.Model.Volume object.",
        "The service call response (type Amazon.FSx.Model.UpdateVolumeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateFSXVolumeCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
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
        
        #region Parameter OpenZFSConfiguration_DataCompressionType
        /// <summary>
        /// <para>
        /// <para>Specifies the method used to compress the data on the volume. The compression type
        /// is <c>NONE</c> by default.</para><ul><li><para><c>NONE</c> - Doesn't compress the data on the volume. <c>NONE</c> is the default.</para></li><li><para><c>ZSTD</c> - Compresses the data in the volume using the Zstandard (ZSTD) compression
        /// algorithm. Compared to LZ4, Z-Standard provides a better compression ratio to minimize
        /// on-disk storage utilization.</para></li><li><para><c>LZ4</c> - Compresses the data in the volume using the LZ4 compression algorithm.
        /// Compared to Z-Standard, LZ4 is less compute-intensive and delivers higher write throughput
        /// speeds.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSDataCompressionType")]
        public Amazon.FSx.OpenZFSDataCompressionType OpenZFSConfiguration_DataCompressionType { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_JunctionPath
        /// <summary>
        /// <para>
        /// <para>Specifies the location in the SVM's namespace where the volume is mounted. The <c>JunctionPath</c>
        /// must have a leading forward slash, such as <c>/vol3</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_JunctionPath { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the OpenZFS volume. OpenZFS root volumes are automatically named <c>FSX</c>.
        /// Child volume names must be unique among their parent volume's children. The name of
        /// the volume is part of the mount string for the OpenZFS volume. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter OpenZFSConfiguration_NfsExport
        /// <summary>
        /// <para>
        /// <para>The configuration object for mounting a Network File System (NFS) file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_NfsExports")]
        public Amazon.FSx.Model.OpenZFSNfsExport[] OpenZFSConfiguration_NfsExport { get; set; }
        #endregion
        
        #region Parameter SnaplockConfiguration_PrivilegedDelete
        /// <summary>
        /// <para>
        /// <para>Enables, disables, or permanently disables privileged delete on an FSx for ONTAP SnapLock
        /// Enterprise volume. Enabling privileged delete allows SnapLock administrators to delete
        /// write once, read many (WORM) files even if they have active retention periods. <c>PERMANENTLY_DISABLED</c>
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
        
        #region Parameter OpenZFSConfiguration_ReadOnly
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether the volume is read-only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OpenZFSConfiguration_ReadOnly { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_RecordSizeKiB
        /// <summary>
        /// <para>
        /// <para>Specifies the record size of an OpenZFS volume, in kibibytes (KiB). Valid values are
        /// 4, 8, 16, 32, 64, 128, 256, 512, or 1024 KiB. The default is 128 KiB. Most workloads
        /// should use the default record size. Database workflows can benefit from a smaller
        /// record size, while streaming workflows can benefit from a larger record size. For
        /// additional guidance on when to set a custom record size, see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/performance.html#performance-tips-zfs">
        /// Tips for maximizing performance</a> in the <i>Amazon FSx for OpenZFS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_RecordSizeKiB { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SecurityStyle
        /// <summary>
        /// <para>
        /// <para>The security style for the volume, which can be <c>UNIX</c>, <c>NTFS</c>, or <c>MIXED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.SecurityStyle")]
        public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SizeInByte
        /// <summary>
        /// <para>
        /// <para>The configured size of the volume, in bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SizeInBytes")]
        public System.Int64? OntapConfiguration_SizeInByte { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SizeInMegabyte
        /// <summary>
        /// <para>
        /// <para>Specifies the size of the volume in megabytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SizeInMegabytes")]
        public System.Int32? OntapConfiguration_SizeInMegabyte { get; set; }
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
        /// policies</a> in the <i>Amazon FSx for NetApp ONTAP User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_SnapshotPolicy { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_StorageCapacityQuotaGiB
        /// <summary>
        /// <para>
        /// <para>The maximum amount of storage in gibibytes (GiB) that the volume can use from its
        /// parent. You can specify a quota larger than the storage on the parent volume. You
        /// can specify a value of <c>-1</c> to unset a volume's storage capacity quota.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_StorageCapacityQuotaGiB { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_StorageCapacityReservationGiB
        /// <summary>
        /// <para>
        /// <para>The amount of storage in gibibytes (GiB) to reserve from the parent volume. You can't
        /// reserve more storage than the parent volume has reserved. You can specify a value
        /// of <c>-1</c> to unset a volume's storage capacity reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_StorageCapacityReservationGiB { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_StorageEfficiencyEnabled
        /// <summary>
        /// <para>
        /// <para>Default is <c>false</c>. Set to true to enable the deduplication, compression, and
        /// compaction storage efficiency features on the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OntapConfiguration_StorageEfficiencyEnabled { get; set; }
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
        
        #region Parameter OpenZFSConfiguration_UserAndGroupQuota
        /// <summary>
        /// <para>
        /// <para>An object specifying how much storage users or groups can use on the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_UserAndGroupQuotas")]
        public Amazon.FSx.Model.OpenZFSUserOrGroupQuota[] OpenZFSConfiguration_UserAndGroupQuota { get; set; }
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
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>The ID of the volume that you want to update, in the format <c>fsvol-0123456789abcdef0</c>.</para>
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
        public System.String VolumeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Volume'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateVolumeResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateVolumeResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXVolume (UpdateVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateVolumeResponse, UpdateFSXVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Name = this.Name;
            context.OntapConfiguration_CopyTagsToBackup = this.OntapConfiguration_CopyTagsToBackup;
            context.OntapConfiguration_JunctionPath = this.OntapConfiguration_JunctionPath;
            context.OntapConfiguration_SecurityStyle = this.OntapConfiguration_SecurityStyle;
            context.OntapConfiguration_SizeInByte = this.OntapConfiguration_SizeInByte;
            context.OntapConfiguration_SizeInMegabyte = this.OntapConfiguration_SizeInMegabyte;
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
            context.SnaplockConfiguration_VolumeAppendModeEnabled = this.SnaplockConfiguration_VolumeAppendModeEnabled;
            context.OntapConfiguration_SnapshotPolicy = this.OntapConfiguration_SnapshotPolicy;
            context.OntapConfiguration_StorageEfficiencyEnabled = this.OntapConfiguration_StorageEfficiencyEnabled;
            context.TieringPolicy_CoolingPeriod = this.TieringPolicy_CoolingPeriod;
            context.TieringPolicy_Name = this.TieringPolicy_Name;
            context.OpenZFSConfiguration_DataCompressionType = this.OpenZFSConfiguration_DataCompressionType;
            if (this.OpenZFSConfiguration_NfsExport != null)
            {
                context.OpenZFSConfiguration_NfsExport = new List<Amazon.FSx.Model.OpenZFSNfsExport>(this.OpenZFSConfiguration_NfsExport);
            }
            context.OpenZFSConfiguration_ReadOnly = this.OpenZFSConfiguration_ReadOnly;
            context.OpenZFSConfiguration_RecordSizeKiB = this.OpenZFSConfiguration_RecordSizeKiB;
            context.OpenZFSConfiguration_StorageCapacityQuotaGiB = this.OpenZFSConfiguration_StorageCapacityQuotaGiB;
            context.OpenZFSConfiguration_StorageCapacityReservationGiB = this.OpenZFSConfiguration_StorageCapacityReservationGiB;
            if (this.OpenZFSConfiguration_UserAndGroupQuota != null)
            {
                context.OpenZFSConfiguration_UserAndGroupQuota = new List<Amazon.FSx.Model.OpenZFSUserOrGroupQuota>(this.OpenZFSConfiguration_UserAndGroupQuota);
            }
            context.VolumeId = this.VolumeId;
            #if MODULAR
            if (this.VolumeId == null && ParameterWasBound(nameof(this.VolumeId)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FSx.Model.UpdateVolumeRequest();
            
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
            request.OntapConfiguration = new Amazon.FSx.Model.UpdateOntapVolumeConfiguration();
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
            Amazon.FSx.Model.UpdateSnaplockConfiguration requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration = null;
            
             // populate SnaplockConfiguration
            var requestOntapConfiguration_ontapConfiguration_SnaplockConfigurationIsNull = true;
            requestOntapConfiguration_ontapConfiguration_SnaplockConfiguration = new Amazon.FSx.Model.UpdateSnaplockConfiguration();
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
            
             // populate OpenZFSConfiguration
            var requestOpenZFSConfigurationIsNull = true;
            request.OpenZFSConfiguration = new Amazon.FSx.Model.UpdateOpenZFSVolumeConfiguration();
            Amazon.FSx.OpenZFSDataCompressionType requestOpenZFSConfiguration_openZFSConfiguration_DataCompressionType = null;
            if (cmdletContext.OpenZFSConfiguration_DataCompressionType != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DataCompressionType = cmdletContext.OpenZFSConfiguration_DataCompressionType;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_DataCompressionType != null)
            {
                request.OpenZFSConfiguration.DataCompressionType = requestOpenZFSConfiguration_openZFSConfiguration_DataCompressionType;
                requestOpenZFSConfigurationIsNull = false;
            }
            List<Amazon.FSx.Model.OpenZFSNfsExport> requestOpenZFSConfiguration_openZFSConfiguration_NfsExport = null;
            if (cmdletContext.OpenZFSConfiguration_NfsExport != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_NfsExport = cmdletContext.OpenZFSConfiguration_NfsExport;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_NfsExport != null)
            {
                request.OpenZFSConfiguration.NfsExports = requestOpenZFSConfiguration_openZFSConfiguration_NfsExport;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.Boolean? requestOpenZFSConfiguration_openZFSConfiguration_ReadOnly = null;
            if (cmdletContext.OpenZFSConfiguration_ReadOnly != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_ReadOnly = cmdletContext.OpenZFSConfiguration_ReadOnly.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_ReadOnly != null)
            {
                request.OpenZFSConfiguration.ReadOnly = requestOpenZFSConfiguration_openZFSConfiguration_ReadOnly.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.Int32? requestOpenZFSConfiguration_openZFSConfiguration_RecordSizeKiB = null;
            if (cmdletContext.OpenZFSConfiguration_RecordSizeKiB != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RecordSizeKiB = cmdletContext.OpenZFSConfiguration_RecordSizeKiB.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RecordSizeKiB != null)
            {
                request.OpenZFSConfiguration.RecordSizeKiB = requestOpenZFSConfiguration_openZFSConfiguration_RecordSizeKiB.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.Int32? requestOpenZFSConfiguration_openZFSConfiguration_StorageCapacityQuotaGiB = null;
            if (cmdletContext.OpenZFSConfiguration_StorageCapacityQuotaGiB != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_StorageCapacityQuotaGiB = cmdletContext.OpenZFSConfiguration_StorageCapacityQuotaGiB.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_StorageCapacityQuotaGiB != null)
            {
                request.OpenZFSConfiguration.StorageCapacityQuotaGiB = requestOpenZFSConfiguration_openZFSConfiguration_StorageCapacityQuotaGiB.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.Int32? requestOpenZFSConfiguration_openZFSConfiguration_StorageCapacityReservationGiB = null;
            if (cmdletContext.OpenZFSConfiguration_StorageCapacityReservationGiB != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_StorageCapacityReservationGiB = cmdletContext.OpenZFSConfiguration_StorageCapacityReservationGiB.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_StorageCapacityReservationGiB != null)
            {
                request.OpenZFSConfiguration.StorageCapacityReservationGiB = requestOpenZFSConfiguration_openZFSConfiguration_StorageCapacityReservationGiB.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
            List<Amazon.FSx.Model.OpenZFSUserOrGroupQuota> requestOpenZFSConfiguration_openZFSConfiguration_UserAndGroupQuota = null;
            if (cmdletContext.OpenZFSConfiguration_UserAndGroupQuota != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_UserAndGroupQuota = cmdletContext.OpenZFSConfiguration_UserAndGroupQuota;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_UserAndGroupQuota != null)
            {
                request.OpenZFSConfiguration.UserAndGroupQuotas = requestOpenZFSConfiguration_openZFSConfiguration_UserAndGroupQuota;
                requestOpenZFSConfigurationIsNull = false;
            }
             // determine if request.OpenZFSConfiguration should be set to null
            if (requestOpenZFSConfigurationIsNull)
            {
                request.OpenZFSConfiguration = null;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeId = cmdletContext.VolumeId;
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
        
        private Amazon.FSx.Model.UpdateVolumeResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateVolume");
            try
            {
                return client.UpdateVolumeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? OntapConfiguration_CopyTagsToBackup { get; set; }
            public System.String OntapConfiguration_JunctionPath { get; set; }
            public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
            public System.Int64? OntapConfiguration_SizeInByte { get; set; }
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
            public System.Boolean? SnaplockConfiguration_VolumeAppendModeEnabled { get; set; }
            public System.String OntapConfiguration_SnapshotPolicy { get; set; }
            public System.Boolean? OntapConfiguration_StorageEfficiencyEnabled { get; set; }
            public System.Int32? TieringPolicy_CoolingPeriod { get; set; }
            public Amazon.FSx.TieringPolicyName TieringPolicy_Name { get; set; }
            public Amazon.FSx.OpenZFSDataCompressionType OpenZFSConfiguration_DataCompressionType { get; set; }
            public List<Amazon.FSx.Model.OpenZFSNfsExport> OpenZFSConfiguration_NfsExport { get; set; }
            public System.Boolean? OpenZFSConfiguration_ReadOnly { get; set; }
            public System.Int32? OpenZFSConfiguration_RecordSizeKiB { get; set; }
            public System.Int32? OpenZFSConfiguration_StorageCapacityQuotaGiB { get; set; }
            public System.Int32? OpenZFSConfiguration_StorageCapacityReservationGiB { get; set; }
            public List<Amazon.FSx.Model.OpenZFSUserOrGroupQuota> OpenZFSConfiguration_UserAndGroupQuota { get; set; }
            public System.String VolumeId { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateVolumeResponse, UpdateFSXVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Volume;
        }
        
    }
}
