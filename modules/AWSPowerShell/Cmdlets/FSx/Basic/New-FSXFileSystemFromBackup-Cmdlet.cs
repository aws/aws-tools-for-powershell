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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates a new Amazon FSx for Lustre, Amazon FSx for Windows File Server, or Amazon
    /// FSx for OpenZFS file system from an existing Amazon FSx backup.
    /// 
    ///  
    /// <para>
    /// If a file system with the specified client request token exists and the parameters
    /// match, this operation returns the description of the file system. If a file system
    /// with the specified client request token exists but the parameters don't match, this
    /// call returns <code>IncompatibleParameterError</code>. If a file system with the specified
    /// client request token doesn't exist, this operation does the following:
    /// </para><ul><li><para>
    /// Creates a new Amazon FSx file system from backup with an assigned ID, and an initial
    /// lifecycle state of <code>CREATING</code>.
    /// </para></li><li><para>
    /// Returns the description of the file system.
    /// </para></li></ul><para>
    /// Parameters like the Active Directory, default share name, automatic backup, and backup
    /// settings default to the parameters of the file system that was backed up, unless overridden.
    /// You can explicitly supply other settings.
    /// </para><para>
    /// By using the idempotent operation, you can retry a <code>CreateFileSystemFromBackup</code>
    /// call without the risk of creating an extra file system. This approach can be useful
    /// when an initial call fails in a way that makes it unclear whether a file system was
    /// created. Examples are if a transport level timeout occurred, or your connection was
    /// reset. If you use the same client request token and the initial call created a file
    /// system, the client receives a success message as long as the parameters are the same.
    /// </para><note><para>
    /// The <code>CreateFileSystemFromBackup</code> call returns while the file system's lifecycle
    /// state is still <code>CREATING</code>. You can check the file-system creation status
    /// by calling the <a href="https://docs.aws.amazon.com/fsx/latest/APIReference/API_DescribeFileSystems.html">
    /// DescribeFileSystems</a> operation, which returns the file system state along with
    /// other information.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FSXFileSystemFromBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.FileSystem")]
    [AWSCmdlet("Calls the Amazon FSx CreateFileSystemFromBackup API operation.", Operation = new[] {"CreateFileSystemFromBackup"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateFileSystemFromBackupResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.FileSystem or Amazon.FSx.Model.CreateFileSystemFromBackupResponse",
        "This cmdlet returns an Amazon.FSx.Model.FileSystem object.",
        "The service call response (type Amazon.FSx.Model.CreateFileSystemFromBackupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFSXFileSystemFromBackupCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        #region Parameter OpenZFSConfiguration_AutomaticBackupRetentionDay
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_AutomaticBackupRetentionDays")]
        public System.Int32? OpenZFSConfiguration_AutomaticBackupRetentionDay { get; set; }
        #endregion
        
        #region Parameter BackupId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String BackupId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A string of up to 64 ASCII characters that Amazon FSx uses to ensure idempotent creation.
        /// This string is automatically filled on your behalf when you use the Command Line Interface
        /// (CLI) or an Amazon Web Services SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_CopyTagsToBackup
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether tags for the file system should be copied to backups.
        /// This value defaults to <code>false</code>. If it's set to <code>true</code>, all tags
        /// for the file system are copied to all automatic and user-initiated backups where the
        /// user doesn't specify tags. If this value is <code>true</code>, and you specify one
        /// or more tags, only the specified tags are copied to backups. If you specify one or
        /// more tags when creating a user-initiated backup, no tags are copied from the file
        /// system, regardless of this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_CopyTagsToBackups")]
        public System.Boolean? OpenZFSConfiguration_CopyTagsToBackup { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfiguration_CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether tags for the volume should be copied to snapshots
        /// of the volume. This value defaults to <code>false</code>. If it's set to <code>true</code>,
        /// all tags for the volume are copied to snapshots where the user doesn't specify tags.
        /// If this value is <code>true</code> and you specify one or more tags, only the specified
        /// tags are copied to snapshots. If you specify one or more tags when creating the snapshot,
        /// no tags are copied from the volume, regardless of this value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RootVolumeConfiguration_CopyTagsToSnapshots")]
        public System.Boolean? RootVolumeConfiguration_CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_CopyTagsToVolume
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether tags for the file system should be copied to volumes.
        /// This value defaults to <code>false</code>. If it's set to <code>true</code>, all tags
        /// for the file system are copied to volumes where the user doesn't specify tags. If
        /// this value is <code>true</code>, and you specify one or more tags, only the specified
        /// tags are copied to volumes. If you specify one or more tags when creating the volume,
        /// no tags are copied from the file system, regardless of this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_CopyTagsToVolumes")]
        public System.Boolean? OpenZFSConfiguration_CopyTagsToVolume { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_DailyAutomaticBackupStartTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenZFSConfiguration_DailyAutomaticBackupStartTime { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfiguration_DataCompressionType
        /// <summary>
        /// <para>
        /// <para>Specifies the method used to compress the data on the volume. The compression type
        /// is <code>NONE</code> by default.</para><ul><li><para><code>NONE</code> - Doesn't compress the data on the volume. <code>NONE</code> is
        /// the default.</para></li><li><para><code>ZSTD</code> - Compresses the data in the volume using the Zstandard (ZSTD)
        /// compression algorithm. Compared to LZ4, Z-Standard provides a better compression ratio
        /// to minimize on-disk storage utilization.</para></li><li><para><code>LZ4</code> - Compresses the data in the volume using the LZ4 compression algorithm.
        /// Compared to Z-Standard, LZ4 is less compute-intensive and delivers higher write throughput
        /// speeds.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RootVolumeConfiguration_DataCompressionType")]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSDataCompressionType")]
        public Amazon.FSx.OpenZFSDataCompressionType RootVolumeConfiguration_DataCompressionType { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_DeploymentType
        /// <summary>
        /// <para>
        /// <para>Specifies the file system deployment type. Single AZ deployment types are configured
        /// for redundancy within a single Availability Zone in an Amazon Web Services Region
        /// . Valid values are the following:</para><ul><li><para><code>SINGLE_AZ_1</code>- (Default) Creates file systems with throughput capacities
        /// of 64 - 4,096 MB/s. <code>Single_AZ_1</code> is available in all Amazon Web Services
        /// Regions where Amazon FSx for OpenZFS is available, except US West (Oregon).</para></li><li><para><code>SINGLE_AZ_2</code>- Creates file systems with throughput capacities of 160
        /// - 10,240 MB/s using an NVMe L2ARC cache. <code>Single_AZ_2</code> is available only
        /// in the US East (N. Virginia), US East (Ohio), US West (Oregon), and Europe (Ireland)
        /// Amazon Web Services Regions.</para></li></ul><para>For more information, see: <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/available-aws-regions.html">Deployment
        /// type availability</a> and <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/zfs-fs-performance.html">
        /// File system performance</a>in the<i>Amazon FSx for OpenZFS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSDeploymentType")]
        public Amazon.FSx.OpenZFSDeploymentType OpenZFSConfiguration_DeploymentType { get; set; }
        #endregion
        
        #region Parameter FileSystemTypeVersion
        /// <summary>
        /// <para>
        /// <para>Sets the version for the Amazon FSx for Lustre file system that you're creating from
        /// a backup. Valid values are <code>2.10</code> and <code>2.12</code>.</para><para>You don't need to specify <code>FileSystemTypeVersion</code> because it will be applied
        /// using the backup's <code>FileSystemTypeVersion</code> setting. If you choose to specify
        /// <code>FileSystemTypeVersion</code> when creating from backup, the value must match
        /// the backup's <code>FileSystemTypeVersion</code> setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FileSystemTypeVersion { get; set; }
        #endregion
        
        #region Parameter DiskIopsConfiguration_Iops
        /// <summary>
        /// <para>
        /// <para>The total number of SSD IOPS provisioned for the file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_DiskIopsConfiguration_Iops")]
        public System.Int64? DiskIopsConfiguration_Iops { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LustreConfiguration
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.FSx.Model.CreateFileSystemLustreConfiguration LustreConfiguration { get; set; }
        #endregion
        
        #region Parameter DiskIopsConfiguration_Mode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the number of IOPS for the file system is using the system default
        /// (<code>AUTOMATIC</code>) or was provisioned by the customer (<code>USER_PROVISIONED</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_DiskIopsConfiguration_Mode")]
        [AWSConstantClassSource("Amazon.FSx.DiskIopsConfigurationMode")]
        public Amazon.FSx.DiskIopsConfigurationMode DiskIopsConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfiguration_NfsExport
        /// <summary>
        /// <para>
        /// <para>The configuration object for mounting a file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RootVolumeConfiguration_NfsExports")]
        public Amazon.FSx.Model.OpenZFSNfsExport[] RootVolumeConfiguration_NfsExport { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfiguration_ReadOnly
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether the volume is read-only. Setting this value to
        /// <code>true</code> can be useful after you have completed changes to a volume and no
        /// longer want changes to occur. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RootVolumeConfiguration_ReadOnly")]
        public System.Boolean? RootVolumeConfiguration_ReadOnly { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfiguration_RecordSizeKiB
        /// <summary>
        /// <para>
        /// <para>Specifies the record size of an OpenZFS root volume, in kibibytes (KiB). Valid values
        /// are 4, 8, 16, 32, 64, 128, 256, 512, or 1024 KiB. The default is 128 KiB. Most workloads
        /// should use the default record size. Database workflows can benefit from a smaller
        /// record size, while streaming workflows can benefit from a larger record size. For
        /// additional guidance on setting a custom record size, see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/performance.html#performance-tips-zfs">
        /// Tips for maximizing performance</a> in the <i>Amazon FSx for OpenZFS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RootVolumeConfiguration_RecordSizeKiB")]
        public System.Int32? RootVolumeConfiguration_RecordSizeKiB { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of IDs for the security groups that apply to the specified network interfaces
        /// created for file system access. These security groups apply to all network interfaces.
        /// This value isn't returned in later <code>DescribeFileSystem</code> requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>Sets the storage capacity of the OpenZFS file system that you're creating from a backup,
        /// in gibibytes (GiB). Valid values are from 64 GiB up to 524,288 GiB (512 TiB). However,
        /// the value that you specify must be equal to or greater than the backup's storage capacity
        /// value. If you don't use the <code>StorageCapacity</code> parameter, the default is
        /// the backup's <code>StorageCapacity</code> value.</para><para>If used to create a file system other than OpenZFS, you must provide a value that
        /// matches the backup's <code>StorageCapacity</code> value. If you provide any other
        /// value, Amazon FSx responds with a 400 Bad Request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Sets the storage type for the Windows or OpenZFS file system that you're creating
        /// from a backup. Valid values are <code>SSD</code> and <code>HDD</code>.</para><ul><li><para>Set to <code>SSD</code> to use solid state drive storage. SSD is supported on all
        /// Windows and OpenZFS deployment types.</para></li><li><para>Set to <code>HDD</code> to use hard disk drive storage. HDD is supported on <code>SINGLE_AZ_2</code>
        /// and <code>MULTI_AZ_1</code> FSx for Windows File Server file system deployment types.</para></li></ul><para> The default value is <code>SSD</code>. </para><note><para>HDD and SSD storage types have different minimum storage capacity requirements. A
        /// restored file system's storage capacity is tied to the file system that was backed
        /// up. You can create a file system that uses HDD storage from a backup of a file system
        /// that used SSD storage if the original SSD file system had a storage capacity of at
        /// least 2000 GiB.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.StorageType")]
        public Amazon.FSx.StorageType StorageType { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>Specifies the IDs of the subnets that the file system will be accessible from. For
        /// Windows <code>MULTI_AZ_1</code> file system deployment types, provide exactly two
        /// subnet IDs, one for the preferred file server and one for the standby file server.
        /// You specify one of these subnets as the preferred subnet using the <code>WindowsConfiguration
        /// &gt; PreferredSubnetID</code> property.</para><para>Windows <code>SINGLE_AZ_1</code> and <code>SINGLE_AZ_2</code> file system deployment
        /// types, Lustre file systems, and OpenZFS file systems provide exactly one subnet ID.
        /// The file server is launched in that subnet's Availability Zone.</para>
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
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be applied to the file system at file system creation. The key value of
        /// the <code>Name</code> tag appears in the console as the file system name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_ThroughputCapacity
        /// <summary>
        /// <para>
        /// <para>Specifies the throughput of an Amazon FSx for OpenZFS file system, measured in megabytes
        /// per second (MB/s). Valid values depend on the DeploymentType you choose, as follows:</para><ul><li><para>For <code>SINGLE_AZ_1</code>, valid values are 64, 128, 256, 512, 1024, 2048, 3072,
        /// or 4096 MB/s.</para></li><li><para>For <code>SINGLE_AZ_2</code>, valid values are 160, 320, 640, 1280, 2560, 3840, 5120,
        /// 7680, or 10240 MB/s.</para></li></ul><para>You pay for additional throughput capacity that you provision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_ThroughputCapacity { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfiguration_UserAndGroupQuota
        /// <summary>
        /// <para>
        /// <para>An object specifying how much storage users or groups can use on the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RootVolumeConfiguration_UserAndGroupQuotas")]
        public Amazon.FSx.Model.OpenZFSUserOrGroupQuota[] RootVolumeConfiguration_UserAndGroupQuota { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_WeeklyMaintenanceStartTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenZFSConfiguration_WeeklyMaintenanceStartTime { get; set; }
        #endregion
        
        #region Parameter WindowsConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration for this Microsoft Windows file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.FSx.Model.CreateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileSystem'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateFileSystemFromBackupResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateFileSystemFromBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileSystem";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BackupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BackupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BackupId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BackupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXFileSystemFromBackup (CreateFileSystemFromBackup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateFileSystemFromBackupResponse, NewFSXFileSystemFromBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BackupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupId = this.BackupId;
            #if MODULAR
            if (this.BackupId == null && ParameterWasBound(nameof(this.BackupId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileSystemTypeVersion = this.FileSystemTypeVersion;
            context.KmsKeyId = this.KmsKeyId;
            context.LustreConfiguration = this.LustreConfiguration;
            context.OpenZFSConfiguration_AutomaticBackupRetentionDay = this.OpenZFSConfiguration_AutomaticBackupRetentionDay;
            context.OpenZFSConfiguration_CopyTagsToBackup = this.OpenZFSConfiguration_CopyTagsToBackup;
            context.OpenZFSConfiguration_CopyTagsToVolume = this.OpenZFSConfiguration_CopyTagsToVolume;
            context.OpenZFSConfiguration_DailyAutomaticBackupStartTime = this.OpenZFSConfiguration_DailyAutomaticBackupStartTime;
            context.OpenZFSConfiguration_DeploymentType = this.OpenZFSConfiguration_DeploymentType;
            context.DiskIopsConfiguration_Iops = this.DiskIopsConfiguration_Iops;
            context.DiskIopsConfiguration_Mode = this.DiskIopsConfiguration_Mode;
            context.RootVolumeConfiguration_CopyTagsToSnapshot = this.RootVolumeConfiguration_CopyTagsToSnapshot;
            context.RootVolumeConfiguration_DataCompressionType = this.RootVolumeConfiguration_DataCompressionType;
            if (this.RootVolumeConfiguration_NfsExport != null)
            {
                context.RootVolumeConfiguration_NfsExport = new List<Amazon.FSx.Model.OpenZFSNfsExport>(this.RootVolumeConfiguration_NfsExport);
            }
            context.RootVolumeConfiguration_ReadOnly = this.RootVolumeConfiguration_ReadOnly;
            context.RootVolumeConfiguration_RecordSizeKiB = this.RootVolumeConfiguration_RecordSizeKiB;
            if (this.RootVolumeConfiguration_UserAndGroupQuota != null)
            {
                context.RootVolumeConfiguration_UserAndGroupQuota = new List<Amazon.FSx.Model.OpenZFSUserOrGroupQuota>(this.RootVolumeConfiguration_UserAndGroupQuota);
            }
            context.OpenZFSConfiguration_ThroughputCapacity = this.OpenZFSConfiguration_ThroughputCapacity;
            context.OpenZFSConfiguration_WeeklyMaintenanceStartTime = this.OpenZFSConfiguration_WeeklyMaintenanceStartTime;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.StorageCapacity = this.StorageCapacity;
            context.StorageType = this.StorageType;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
            }
            context.WindowsConfiguration = this.WindowsConfiguration;
            
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
            var request = new Amazon.FSx.Model.CreateFileSystemFromBackupRequest();
            
            if (cmdletContext.BackupId != null)
            {
                request.BackupId = cmdletContext.BackupId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemTypeVersion != null)
            {
                request.FileSystemTypeVersion = cmdletContext.FileSystemTypeVersion;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LustreConfiguration != null)
            {
                request.LustreConfiguration = cmdletContext.LustreConfiguration;
            }
            
             // populate OpenZFSConfiguration
            var requestOpenZFSConfigurationIsNull = true;
            request.OpenZFSConfiguration = new Amazon.FSx.Model.CreateFileSystemOpenZFSConfiguration();
            System.Int32? requestOpenZFSConfiguration_openZFSConfiguration_AutomaticBackupRetentionDay = null;
            if (cmdletContext.OpenZFSConfiguration_AutomaticBackupRetentionDay != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_AutomaticBackupRetentionDay = cmdletContext.OpenZFSConfiguration_AutomaticBackupRetentionDay.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_AutomaticBackupRetentionDay != null)
            {
                request.OpenZFSConfiguration.AutomaticBackupRetentionDays = requestOpenZFSConfiguration_openZFSConfiguration_AutomaticBackupRetentionDay.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.Boolean? requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToBackup = null;
            if (cmdletContext.OpenZFSConfiguration_CopyTagsToBackup != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToBackup = cmdletContext.OpenZFSConfiguration_CopyTagsToBackup.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToBackup != null)
            {
                request.OpenZFSConfiguration.CopyTagsToBackups = requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToBackup.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.Boolean? requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToVolume = null;
            if (cmdletContext.OpenZFSConfiguration_CopyTagsToVolume != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToVolume = cmdletContext.OpenZFSConfiguration_CopyTagsToVolume.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToVolume != null)
            {
                request.OpenZFSConfiguration.CopyTagsToVolumes = requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToVolume.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.String requestOpenZFSConfiguration_openZFSConfiguration_DailyAutomaticBackupStartTime = null;
            if (cmdletContext.OpenZFSConfiguration_DailyAutomaticBackupStartTime != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DailyAutomaticBackupStartTime = cmdletContext.OpenZFSConfiguration_DailyAutomaticBackupStartTime;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_DailyAutomaticBackupStartTime != null)
            {
                request.OpenZFSConfiguration.DailyAutomaticBackupStartTime = requestOpenZFSConfiguration_openZFSConfiguration_DailyAutomaticBackupStartTime;
                requestOpenZFSConfigurationIsNull = false;
            }
            Amazon.FSx.OpenZFSDeploymentType requestOpenZFSConfiguration_openZFSConfiguration_DeploymentType = null;
            if (cmdletContext.OpenZFSConfiguration_DeploymentType != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DeploymentType = cmdletContext.OpenZFSConfiguration_DeploymentType;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_DeploymentType != null)
            {
                request.OpenZFSConfiguration.DeploymentType = requestOpenZFSConfiguration_openZFSConfiguration_DeploymentType;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.Int32? requestOpenZFSConfiguration_openZFSConfiguration_ThroughputCapacity = null;
            if (cmdletContext.OpenZFSConfiguration_ThroughputCapacity != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_ThroughputCapacity = cmdletContext.OpenZFSConfiguration_ThroughputCapacity.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_ThroughputCapacity != null)
            {
                request.OpenZFSConfiguration.ThroughputCapacity = requestOpenZFSConfiguration_openZFSConfiguration_ThroughputCapacity.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.String requestOpenZFSConfiguration_openZFSConfiguration_WeeklyMaintenanceStartTime = null;
            if (cmdletContext.OpenZFSConfiguration_WeeklyMaintenanceStartTime != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_WeeklyMaintenanceStartTime = cmdletContext.OpenZFSConfiguration_WeeklyMaintenanceStartTime;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_WeeklyMaintenanceStartTime != null)
            {
                request.OpenZFSConfiguration.WeeklyMaintenanceStartTime = requestOpenZFSConfiguration_openZFSConfiguration_WeeklyMaintenanceStartTime;
                requestOpenZFSConfigurationIsNull = false;
            }
            Amazon.FSx.Model.DiskIopsConfiguration requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration = null;
            
             // populate DiskIopsConfiguration
            var requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfigurationIsNull = true;
            requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration = new Amazon.FSx.Model.DiskIopsConfiguration();
            System.Int64? requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Iops = null;
            if (cmdletContext.DiskIopsConfiguration_Iops != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Iops = cmdletContext.DiskIopsConfiguration_Iops.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Iops != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration.Iops = requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Iops.Value;
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfigurationIsNull = false;
            }
            Amazon.FSx.DiskIopsConfigurationMode requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Mode = null;
            if (cmdletContext.DiskIopsConfiguration_Mode != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Mode = cmdletContext.DiskIopsConfiguration_Mode;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Mode != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration.Mode = requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Mode;
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfigurationIsNull = false;
            }
             // determine if requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration should be set to null
            if (requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfigurationIsNull)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration = null;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration != null)
            {
                request.OpenZFSConfiguration.DiskIopsConfiguration = requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration;
                requestOpenZFSConfigurationIsNull = false;
            }
            Amazon.FSx.Model.OpenZFSCreateRootVolumeConfiguration requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration = null;
            
             // populate RootVolumeConfiguration
            var requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfigurationIsNull = true;
            requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration = new Amazon.FSx.Model.OpenZFSCreateRootVolumeConfiguration();
            System.Boolean? requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_CopyTagsToSnapshot = null;
            if (cmdletContext.RootVolumeConfiguration_CopyTagsToSnapshot != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_CopyTagsToSnapshot = cmdletContext.RootVolumeConfiguration_CopyTagsToSnapshot.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_CopyTagsToSnapshot != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration.CopyTagsToSnapshots = requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_CopyTagsToSnapshot.Value;
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfigurationIsNull = false;
            }
            Amazon.FSx.OpenZFSDataCompressionType requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_DataCompressionType = null;
            if (cmdletContext.RootVolumeConfiguration_DataCompressionType != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_DataCompressionType = cmdletContext.RootVolumeConfiguration_DataCompressionType;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_DataCompressionType != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration.DataCompressionType = requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_DataCompressionType;
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfigurationIsNull = false;
            }
            List<Amazon.FSx.Model.OpenZFSNfsExport> requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_NfsExport = null;
            if (cmdletContext.RootVolumeConfiguration_NfsExport != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_NfsExport = cmdletContext.RootVolumeConfiguration_NfsExport;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_NfsExport != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration.NfsExports = requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_NfsExport;
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfigurationIsNull = false;
            }
            System.Boolean? requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_ReadOnly = null;
            if (cmdletContext.RootVolumeConfiguration_ReadOnly != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_ReadOnly = cmdletContext.RootVolumeConfiguration_ReadOnly.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_ReadOnly != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration.ReadOnly = requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_ReadOnly.Value;
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfigurationIsNull = false;
            }
            System.Int32? requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_RecordSizeKiB = null;
            if (cmdletContext.RootVolumeConfiguration_RecordSizeKiB != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_RecordSizeKiB = cmdletContext.RootVolumeConfiguration_RecordSizeKiB.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_RecordSizeKiB != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration.RecordSizeKiB = requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_RecordSizeKiB.Value;
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfigurationIsNull = false;
            }
            List<Amazon.FSx.Model.OpenZFSUserOrGroupQuota> requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_UserAndGroupQuota = null;
            if (cmdletContext.RootVolumeConfiguration_UserAndGroupQuota != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_UserAndGroupQuota = cmdletContext.RootVolumeConfiguration_UserAndGroupQuota;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_UserAndGroupQuota != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration.UserAndGroupQuotas = requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration_rootVolumeConfiguration_UserAndGroupQuota;
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfigurationIsNull = false;
            }
             // determine if requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration should be set to null
            if (requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfigurationIsNull)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration = null;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration != null)
            {
                request.OpenZFSConfiguration.RootVolumeConfiguration = requestOpenZFSConfiguration_openZFSConfiguration_RootVolumeConfiguration;
                requestOpenZFSConfigurationIsNull = false;
            }
             // determine if request.OpenZFSConfiguration should be set to null
            if (requestOpenZFSConfigurationIsNull)
            {
                request.OpenZFSConfiguration = null;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.StorageCapacity != null)
            {
                request.StorageCapacity = cmdletContext.StorageCapacity.Value;
            }
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WindowsConfiguration != null)
            {
                request.WindowsConfiguration = cmdletContext.WindowsConfiguration;
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
        
        private Amazon.FSx.Model.CreateFileSystemFromBackupResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateFileSystemFromBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateFileSystemFromBackup");
            try
            {
                #if DESKTOP
                return client.CreateFileSystemFromBackup(request);
                #elif CORECLR
                return client.CreateFileSystemFromBackupAsync(request).GetAwaiter().GetResult();
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
            public System.String FileSystemTypeVersion { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.FSx.Model.CreateFileSystemLustreConfiguration LustreConfiguration { get; set; }
            public System.Int32? OpenZFSConfiguration_AutomaticBackupRetentionDay { get; set; }
            public System.Boolean? OpenZFSConfiguration_CopyTagsToBackup { get; set; }
            public System.Boolean? OpenZFSConfiguration_CopyTagsToVolume { get; set; }
            public System.String OpenZFSConfiguration_DailyAutomaticBackupStartTime { get; set; }
            public Amazon.FSx.OpenZFSDeploymentType OpenZFSConfiguration_DeploymentType { get; set; }
            public System.Int64? DiskIopsConfiguration_Iops { get; set; }
            public Amazon.FSx.DiskIopsConfigurationMode DiskIopsConfiguration_Mode { get; set; }
            public System.Boolean? RootVolumeConfiguration_CopyTagsToSnapshot { get; set; }
            public Amazon.FSx.OpenZFSDataCompressionType RootVolumeConfiguration_DataCompressionType { get; set; }
            public List<Amazon.FSx.Model.OpenZFSNfsExport> RootVolumeConfiguration_NfsExport { get; set; }
            public System.Boolean? RootVolumeConfiguration_ReadOnly { get; set; }
            public System.Int32? RootVolumeConfiguration_RecordSizeKiB { get; set; }
            public List<Amazon.FSx.Model.OpenZFSUserOrGroupQuota> RootVolumeConfiguration_UserAndGroupQuota { get; set; }
            public System.Int32? OpenZFSConfiguration_ThroughputCapacity { get; set; }
            public System.String OpenZFSConfiguration_WeeklyMaintenanceStartTime { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.Int32? StorageCapacity { get; set; }
            public Amazon.FSx.StorageType StorageType { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public Amazon.FSx.Model.CreateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
            public System.Func<Amazon.FSx.Model.CreateFileSystemFromBackupResponse, NewFSXFileSystemFromBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileSystem;
        }
        
    }
}
