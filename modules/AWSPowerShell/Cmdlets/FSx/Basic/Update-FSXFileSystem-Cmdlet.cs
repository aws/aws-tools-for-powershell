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
    /// Use this operation to update the configuration of an existing Amazon FSx file system.
    /// You can update multiple properties in a single request.
    /// 
    ///  
    /// <para>
    /// For FSx for Windows File Server file systems, you can update the following properties:
    /// </para><ul><li><para><c>AuditLogConfiguration</c></para></li><li><para><c>AutomaticBackupRetentionDays</c></para></li><li><para><c>DailyAutomaticBackupStartTime</c></para></li><li><para><c>SelfManagedActiveDirectoryConfiguration</c></para></li><li><para><c>StorageCapacity</c></para></li><li><para><c>StorageType</c></para></li><li><para><c>ThroughputCapacity</c></para></li><li><para><c>DiskIopsConfiguration</c></para></li><li><para><c>WeeklyMaintenanceStartTime</c></para></li></ul><para>
    /// For FSx for Lustre file systems, you can update the following properties:
    /// </para><ul><li><para><c>AutoImportPolicy</c></para></li><li><para><c>AutomaticBackupRetentionDays</c></para></li><li><para><c>DailyAutomaticBackupStartTime</c></para></li><li><para><c>DataCompressionType</c></para></li><li><para><c>LogConfiguration</c></para></li><li><para><c>LustreRootSquashConfiguration</c></para></li><li><para><c>MetadataConfiguration</c></para></li><li><para><c>PerUnitStorageThroughput</c></para></li><li><para><c>StorageCapacity</c></para></li><li><para><c>WeeklyMaintenanceStartTime</c></para></li></ul><para>
    /// For FSx for ONTAP file systems, you can update the following properties:
    /// </para><ul><li><para><c>AddRouteTableIds</c></para></li><li><para><c>AutomaticBackupRetentionDays</c></para></li><li><para><c>DailyAutomaticBackupStartTime</c></para></li><li><para><c>DiskIopsConfiguration</c></para></li><li><para><c>FsxAdminPassword</c></para></li><li><para><c>HAPairs</c></para></li><li><para><c>RemoveRouteTableIds</c></para></li><li><para><c>StorageCapacity</c></para></li><li><para><c>ThroughputCapacity</c></para></li><li><para><c>ThroughputCapacityPerHAPair</c></para></li><li><para><c>WeeklyMaintenanceStartTime</c></para></li></ul><para>
    /// For FSx for OpenZFS file systems, you can update the following properties:
    /// </para><ul><li><para><c>AddRouteTableIds</c></para></li><li><para><c>AutomaticBackupRetentionDays</c></para></li><li><para><c>CopyTagsToBackups</c></para></li><li><para><c>CopyTagsToVolumes</c></para></li><li><para><c>DailyAutomaticBackupStartTime</c></para></li><li><para><c>DiskIopsConfiguration</c></para></li><li><para><c>RemoveRouteTableIds</c></para></li><li><para><c>StorageCapacity</c></para></li><li><para><c>ThroughputCapacity</c></para></li><li><para><c>WeeklyMaintenanceStartTime</c></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "FSXFileSystem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.FileSystem")]
    [AWSCmdlet("Calls the Amazon FSx UpdateFileSystem API operation.", Operation = new[] {"UpdateFileSystem"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateFileSystemResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.FileSystem or Amazon.FSx.Model.UpdateFileSystemResponse",
        "This cmdlet returns an Amazon.FSx.Model.FileSystem object.",
        "The service call response (type Amazon.FSx.Model.UpdateFileSystemResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateFSXFileSystemCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OntapConfiguration_AddRouteTableId
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) A list of IDs of new virtual private cloud (VPC) route tables to associate
        /// (add) with your Amazon FSx for NetApp ONTAP file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_AddRouteTableIds")]
        public System.String[] OntapConfiguration_AddRouteTableId { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_AddRouteTableId
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) A list of IDs of new virtual private cloud (VPC) route tables to associate
        /// (add) with your Amazon FSx for OpenZFS file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_AddRouteTableIds")]
        public System.String[] OpenZFSConfiguration_AddRouteTableId { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_AutomaticBackupRetentionDay
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_AutomaticBackupRetentionDays")]
        public System.Int32? OntapConfiguration_AutomaticBackupRetentionDay { get; set; }
        #endregion
        
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
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A string of up to 63 ASCII characters that Amazon FSx uses to ensure idempotent updates.
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
        /// This value defaults to <c>false</c>. If it's set to <c>true</c>, all tags for the
        /// file system are copied to all automatic and user-initiated backups where the user
        /// doesn't specify tags. If this value is <c>true</c> and you specify one or more tags,
        /// only the specified tags are copied to backups. If you specify one or more tags when
        /// creating a user-initiated backup, no tags are copied from the file system, regardless
        /// of this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_CopyTagsToBackups")]
        public System.Boolean? OpenZFSConfiguration_CopyTagsToBackup { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_CopyTagsToVolume
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether tags for the volume should be copied to snapshots.
        /// This value defaults to <c>false</c>. If it's set to <c>true</c>, all tags for the
        /// volume are copied to snapshots where the user doesn't specify tags. If this value
        /// is <c>true</c> and you specify one or more tags, only the specified tags are copied
        /// to snapshots. If you specify one or more tags when creating the snapshot, no tags
        /// are copied from the volume, regardless of this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_CopyTagsToVolumes")]
        public System.Boolean? OpenZFSConfiguration_CopyTagsToVolume { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_DailyAutomaticBackupStartTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_DailyAutomaticBackupStartTime { get; set; }
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
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the file system that you are updating.</para>
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_FsxAdminPassword
        /// <summary>
        /// <para>
        /// <para>Update the password for the <c>fsxadmin</c> user by entering a new password. You use
        /// the <c>fsxadmin</c> user to access the NetApp ONTAP CLI and REST API to manage your
        /// file system resources. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-resources-ontap-apps.html">Managing
        /// resources using NetApp Applicaton</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_FsxAdminPassword { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_DiskIopsConfiguration_Iops
        /// <summary>
        /// <para>
        /// <para>The total number of SSD IOPS provisioned for the file system.</para><para>The minimum and maximum values for this property depend on the value of <c>HAPairs</c>
        /// and <c>StorageCapacity</c>. The minimum value is calculated as <c>StorageCapacity</c>
        /// * 3 * <c>HAPairs</c> (3 IOPS per GB of <c>StorageCapacity</c>). The maximum value
        /// is calculated as 200,000 * <c>HAPairs</c>.</para><para>Amazon FSx responds with an HTTP status code 400 (Bad Request) if the value of <c>Iops</c>
        /// is outside of the minimum or maximum values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OntapConfiguration_DiskIopsConfiguration_Iops { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_DiskIopsConfiguration_Iops
        /// <summary>
        /// <para>
        /// <para>The total number of SSD IOPS provisioned for the file system.</para><para>The minimum and maximum values for this property depend on the value of <c>HAPairs</c>
        /// and <c>StorageCapacity</c>. The minimum value is calculated as <c>StorageCapacity</c>
        /// * 3 * <c>HAPairs</c> (3 IOPS per GB of <c>StorageCapacity</c>). The maximum value
        /// is calculated as 200,000 * <c>HAPairs</c>.</para><para>Amazon FSx responds with an HTTP status code 400 (Bad Request) if the value of <c>Iops</c>
        /// is outside of the minimum or maximum values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OpenZFSConfiguration_DiskIopsConfiguration_Iops { get; set; }
        #endregion
        
        #region Parameter LustreConfiguration
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.FSx.Model.UpdateFileSystemLustreConfiguration LustreConfiguration { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_DiskIopsConfiguration_Mode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the file system is using the <c>AUTOMATIC</c> setting of SSD IOPS
        /// of 3 IOPS per GB of storage capacity, or if it using a <c>USER_PROVISIONED</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.DiskIopsConfigurationMode")]
        public Amazon.FSx.DiskIopsConfigurationMode OntapConfiguration_DiskIopsConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_DiskIopsConfiguration_Mode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the file system is using the <c>AUTOMATIC</c> setting of SSD IOPS
        /// of 3 IOPS per GB of storage capacity, or if it using a <c>USER_PROVISIONED</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.DiskIopsConfigurationMode")]
        public Amazon.FSx.DiskIopsConfigurationMode OpenZFSConfiguration_DiskIopsConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_RemoveRouteTableId
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) A list of IDs of existing virtual private cloud (VPC) route tables
        /// to disassociate (remove) from your Amazon FSx for NetApp ONTAP file system. You can
        /// use the API operation to retrieve the list of VPC route table IDs for a file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_RemoveRouteTableIds")]
        public System.String[] OntapConfiguration_RemoveRouteTableId { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_RemoveRouteTableId
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) A list of IDs of existing virtual private cloud (VPC) route tables
        /// to disassociate (remove) from your Amazon FSx for OpenZFS file system. You can use
        /// the API operation to retrieve the list of VPC route table IDs for a file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RemoveRouteTableIds")]
        public System.String[] OpenZFSConfiguration_RemoveRouteTableId { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>Use this parameter to increase the storage capacity of an FSx for Windows File Server,
        /// FSx for Lustre, FSx for OpenZFS, or FSx for ONTAP file system. Specifies the storage
        /// capacity target value, in GiB, to increase the storage capacity for the file system
        /// that you're updating. </para><note><para>You can't make a storage capacity increase request if there is an existing storage
        /// capacity increase request in progress.</para></note><para>For Lustre file systems, the storage capacity target value can be the following:</para><ul><li><para>For <c>SCRATCH_2</c>, <c>PERSISTENT_1</c>, and <c>PERSISTENT_2 SSD</c> deployment
        /// types, valid values are in multiples of 2400 GiB. The value must be greater than the
        /// current storage capacity.</para></li><li><para>For <c>PERSISTENT HDD</c> file systems, valid values are multiples of 6000 GiB for
        /// 12-MBps throughput per TiB file systems and multiples of 1800 GiB for 40-MBps throughput
        /// per TiB file systems. The values must be greater than the current storage capacity.</para></li><li><para>For <c>SCRATCH_1</c> file systems, you can't increase the storage capacity.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/managing-storage-capacity.html">Managing
        /// storage and throughput capacity</a> in the <i>FSx for Lustre User Guide</i>.</para><para>For FSx for OpenZFS file systems, the storage capacity target value must be at least
        /// 10 percent greater than the current storage capacity value. For more information,
        /// see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/managing-storage-capacity.html">Managing
        /// storage capacity</a> in the <i>FSx for OpenZFS User Guide</i>.</para><para>For Windows file systems, the storage capacity target value must be at least 10 percent
        /// greater than the current storage capacity value. To increase storage capacity, the
        /// file system must have at least 16 MBps of throughput capacity. For more information,
        /// see <a href="https://docs.aws.amazon.com/fsx/latest/WindowsGuide/managing-storage-capacity.html">Managing
        /// storage capacity</a> in the <i>Amazon FSxfor Windows File Server User Guide</i>.</para><para>For ONTAP file systems, the storage capacity target value must be at least 10 percent
        /// greater than the current storage capacity value. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-storage-capacity.html">Managing
        /// storage capacity and provisioned IOPS</a> in the <i>Amazon FSx for NetApp ONTAP User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.StorageType")]
        public Amazon.FSx.StorageType StorageType { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_ThroughputCapacity
        /// <summary>
        /// <para>
        /// <para>Enter a new value to change the amount of throughput capacity for the file system
        /// in megabytes per second (MBps). For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-throughput-capacity.html">Managing
        /// throughput capacity</a> in the FSx for ONTAP User Guide.</para><para>Amazon FSx responds with an HTTP status code 400 (Bad Request) for the following conditions:</para><ul><li><para>The value of <c>ThroughputCapacity</c> and <c>ThroughputCapacityPerHAPair</c> are
        /// not the same value.</para></li><li><para>The value of <c>ThroughputCapacity</c> when divided by the value of <c>HAPairs</c>
        /// is outside of the valid range for <c>ThroughputCapacity</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OntapConfiguration_ThroughputCapacity { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_ThroughputCapacity
        /// <summary>
        /// <para>
        /// <para>The throughput of an Amazon FSx for OpenZFS file system, measured in megabytes per
        /// second  (MB/s). Valid values depend on the DeploymentType you choose, as follows:</para><ul><li><para>For <c>MULTI_AZ_1</c> and <c>SINGLE_AZ_2</c>, valid values are 160, 320, 640, 1280,
        /// 2560, 3840, 5120, 7680, or 10240 MB/s.</para></li><li><para>For <c>SINGLE_AZ_1</c>, valid values are 64, 128, 256, 512, 1024, 2048, 3072, or 4096
        /// MB/s.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_ThroughputCapacity { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_ThroughputCapacityPerHAPair
        /// <summary>
        /// <para>
        /// <para>Use to choose the throughput capacity per HA pair, rather than the total throughput
        /// for the file system. </para><para>This field and <c>ThroughputCapacity</c> cannot be defined in the same API call, but
        /// one is required.</para><para>This field and <c>ThroughputCapacity</c> are the same for file systems with one HA
        /// pair.</para><ul><li><para>For <c>SINGLE_AZ_1</c> and <c>MULTI_AZ_1</c>, valid values are 128, 256, 512, 1024,
        /// 2048, or 4096 MBps.</para></li><li><para>For <c>SINGLE_AZ_2</c>, valid values are 3072 or 6144 MBps.</para></li></ul><para>Amazon FSx responds with an HTTP status code 400 (Bad Request) for the following conditions:</para><ul><li><para>The value of <c>ThroughputCapacity</c> and <c>ThroughputCapacityPerHAPair</c> are
        /// not the same value for file systems with one HA pair.</para></li><li><para>The value of deployment type is <c>SINGLE_AZ_2</c> and <c>ThroughputCapacity</c> /
        /// <c>ThroughputCapacityPerHAPair</c> is a valid HA pair (a value between 2 and 12).</para></li><li><para>The value of <c>ThroughputCapacityPerHAPair</c> is not a valid value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OntapConfiguration_ThroughputCapacityPerHAPair { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_WeeklyMaintenanceStartTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_WeeklyMaintenanceStartTime { get; set; }
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
        /// <para>The configuration updates for an Amazon FSx for Windows File Server file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.FSx.Model.UpdateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileSystem'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateFileSystemResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateFileSystemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileSystem";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FileSystemId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FileSystemId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FileSystemId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXFileSystem (UpdateFileSystem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateFileSystemResponse, UpdateFSXFileSystemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FileSystemId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LustreConfiguration = this.LustreConfiguration;
            if (this.OntapConfiguration_AddRouteTableId != null)
            {
                context.OntapConfiguration_AddRouteTableId = new List<System.String>(this.OntapConfiguration_AddRouteTableId);
            }
            context.OntapConfiguration_AutomaticBackupRetentionDay = this.OntapConfiguration_AutomaticBackupRetentionDay;
            context.OntapConfiguration_DailyAutomaticBackupStartTime = this.OntapConfiguration_DailyAutomaticBackupStartTime;
            context.OntapConfiguration_DiskIopsConfiguration_Iops = this.OntapConfiguration_DiskIopsConfiguration_Iops;
            context.OntapConfiguration_DiskIopsConfiguration_Mode = this.OntapConfiguration_DiskIopsConfiguration_Mode;
            context.OntapConfiguration_FsxAdminPassword = this.OntapConfiguration_FsxAdminPassword;
            if (this.OntapConfiguration_RemoveRouteTableId != null)
            {
                context.OntapConfiguration_RemoveRouteTableId = new List<System.String>(this.OntapConfiguration_RemoveRouteTableId);
            }
            context.OntapConfiguration_ThroughputCapacity = this.OntapConfiguration_ThroughputCapacity;
            context.OntapConfiguration_ThroughputCapacityPerHAPair = this.OntapConfiguration_ThroughputCapacityPerHAPair;
            context.OntapConfiguration_WeeklyMaintenanceStartTime = this.OntapConfiguration_WeeklyMaintenanceStartTime;
            if (this.OpenZFSConfiguration_AddRouteTableId != null)
            {
                context.OpenZFSConfiguration_AddRouteTableId = new List<System.String>(this.OpenZFSConfiguration_AddRouteTableId);
            }
            context.OpenZFSConfiguration_AutomaticBackupRetentionDay = this.OpenZFSConfiguration_AutomaticBackupRetentionDay;
            context.OpenZFSConfiguration_CopyTagsToBackup = this.OpenZFSConfiguration_CopyTagsToBackup;
            context.OpenZFSConfiguration_CopyTagsToVolume = this.OpenZFSConfiguration_CopyTagsToVolume;
            context.OpenZFSConfiguration_DailyAutomaticBackupStartTime = this.OpenZFSConfiguration_DailyAutomaticBackupStartTime;
            context.OpenZFSConfiguration_DiskIopsConfiguration_Iops = this.OpenZFSConfiguration_DiskIopsConfiguration_Iops;
            context.OpenZFSConfiguration_DiskIopsConfiguration_Mode = this.OpenZFSConfiguration_DiskIopsConfiguration_Mode;
            if (this.OpenZFSConfiguration_RemoveRouteTableId != null)
            {
                context.OpenZFSConfiguration_RemoveRouteTableId = new List<System.String>(this.OpenZFSConfiguration_RemoveRouteTableId);
            }
            context.OpenZFSConfiguration_ThroughputCapacity = this.OpenZFSConfiguration_ThroughputCapacity;
            context.OpenZFSConfiguration_WeeklyMaintenanceStartTime = this.OpenZFSConfiguration_WeeklyMaintenanceStartTime;
            context.StorageCapacity = this.StorageCapacity;
            context.StorageType = this.StorageType;
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
            var request = new Amazon.FSx.Model.UpdateFileSystemRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.LustreConfiguration != null)
            {
                request.LustreConfiguration = cmdletContext.LustreConfiguration;
            }
            
             // populate OntapConfiguration
            var requestOntapConfigurationIsNull = true;
            request.OntapConfiguration = new Amazon.FSx.Model.UpdateFileSystemOntapConfiguration();
            List<System.String> requestOntapConfiguration_ontapConfiguration_AddRouteTableId = null;
            if (cmdletContext.OntapConfiguration_AddRouteTableId != null)
            {
                requestOntapConfiguration_ontapConfiguration_AddRouteTableId = cmdletContext.OntapConfiguration_AddRouteTableId;
            }
            if (requestOntapConfiguration_ontapConfiguration_AddRouteTableId != null)
            {
                request.OntapConfiguration.AddRouteTableIds = requestOntapConfiguration_ontapConfiguration_AddRouteTableId;
                requestOntapConfigurationIsNull = false;
            }
            System.Int32? requestOntapConfiguration_ontapConfiguration_AutomaticBackupRetentionDay = null;
            if (cmdletContext.OntapConfiguration_AutomaticBackupRetentionDay != null)
            {
                requestOntapConfiguration_ontapConfiguration_AutomaticBackupRetentionDay = cmdletContext.OntapConfiguration_AutomaticBackupRetentionDay.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_AutomaticBackupRetentionDay != null)
            {
                request.OntapConfiguration.AutomaticBackupRetentionDays = requestOntapConfiguration_ontapConfiguration_AutomaticBackupRetentionDay.Value;
                requestOntapConfigurationIsNull = false;
            }
            System.String requestOntapConfiguration_ontapConfiguration_DailyAutomaticBackupStartTime = null;
            if (cmdletContext.OntapConfiguration_DailyAutomaticBackupStartTime != null)
            {
                requestOntapConfiguration_ontapConfiguration_DailyAutomaticBackupStartTime = cmdletContext.OntapConfiguration_DailyAutomaticBackupStartTime;
            }
            if (requestOntapConfiguration_ontapConfiguration_DailyAutomaticBackupStartTime != null)
            {
                request.OntapConfiguration.DailyAutomaticBackupStartTime = requestOntapConfiguration_ontapConfiguration_DailyAutomaticBackupStartTime;
                requestOntapConfigurationIsNull = false;
            }
            System.String requestOntapConfiguration_ontapConfiguration_FsxAdminPassword = null;
            if (cmdletContext.OntapConfiguration_FsxAdminPassword != null)
            {
                requestOntapConfiguration_ontapConfiguration_FsxAdminPassword = cmdletContext.OntapConfiguration_FsxAdminPassword;
            }
            if (requestOntapConfiguration_ontapConfiguration_FsxAdminPassword != null)
            {
                request.OntapConfiguration.FsxAdminPassword = requestOntapConfiguration_ontapConfiguration_FsxAdminPassword;
                requestOntapConfigurationIsNull = false;
            }
            List<System.String> requestOntapConfiguration_ontapConfiguration_RemoveRouteTableId = null;
            if (cmdletContext.OntapConfiguration_RemoveRouteTableId != null)
            {
                requestOntapConfiguration_ontapConfiguration_RemoveRouteTableId = cmdletContext.OntapConfiguration_RemoveRouteTableId;
            }
            if (requestOntapConfiguration_ontapConfiguration_RemoveRouteTableId != null)
            {
                request.OntapConfiguration.RemoveRouteTableIds = requestOntapConfiguration_ontapConfiguration_RemoveRouteTableId;
                requestOntapConfigurationIsNull = false;
            }
            System.Int32? requestOntapConfiguration_ontapConfiguration_ThroughputCapacity = null;
            if (cmdletContext.OntapConfiguration_ThroughputCapacity != null)
            {
                requestOntapConfiguration_ontapConfiguration_ThroughputCapacity = cmdletContext.OntapConfiguration_ThroughputCapacity.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_ThroughputCapacity != null)
            {
                request.OntapConfiguration.ThroughputCapacity = requestOntapConfiguration_ontapConfiguration_ThroughputCapacity.Value;
                requestOntapConfigurationIsNull = false;
            }
            System.Int32? requestOntapConfiguration_ontapConfiguration_ThroughputCapacityPerHAPair = null;
            if (cmdletContext.OntapConfiguration_ThroughputCapacityPerHAPair != null)
            {
                requestOntapConfiguration_ontapConfiguration_ThroughputCapacityPerHAPair = cmdletContext.OntapConfiguration_ThroughputCapacityPerHAPair.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_ThroughputCapacityPerHAPair != null)
            {
                request.OntapConfiguration.ThroughputCapacityPerHAPair = requestOntapConfiguration_ontapConfiguration_ThroughputCapacityPerHAPair.Value;
                requestOntapConfigurationIsNull = false;
            }
            System.String requestOntapConfiguration_ontapConfiguration_WeeklyMaintenanceStartTime = null;
            if (cmdletContext.OntapConfiguration_WeeklyMaintenanceStartTime != null)
            {
                requestOntapConfiguration_ontapConfiguration_WeeklyMaintenanceStartTime = cmdletContext.OntapConfiguration_WeeklyMaintenanceStartTime;
            }
            if (requestOntapConfiguration_ontapConfiguration_WeeklyMaintenanceStartTime != null)
            {
                request.OntapConfiguration.WeeklyMaintenanceStartTime = requestOntapConfiguration_ontapConfiguration_WeeklyMaintenanceStartTime;
                requestOntapConfigurationIsNull = false;
            }
            Amazon.FSx.Model.DiskIopsConfiguration requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration = null;
            
             // populate DiskIopsConfiguration
            var requestOntapConfiguration_ontapConfiguration_DiskIopsConfigurationIsNull = true;
            requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration = new Amazon.FSx.Model.DiskIopsConfiguration();
            System.Int64? requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_ontapConfiguration_DiskIopsConfiguration_Iops = null;
            if (cmdletContext.OntapConfiguration_DiskIopsConfiguration_Iops != null)
            {
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_ontapConfiguration_DiskIopsConfiguration_Iops = cmdletContext.OntapConfiguration_DiskIopsConfiguration_Iops.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_ontapConfiguration_DiskIopsConfiguration_Iops != null)
            {
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration.Iops = requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_ontapConfiguration_DiskIopsConfiguration_Iops.Value;
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfigurationIsNull = false;
            }
            Amazon.FSx.DiskIopsConfigurationMode requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_ontapConfiguration_DiskIopsConfiguration_Mode = null;
            if (cmdletContext.OntapConfiguration_DiskIopsConfiguration_Mode != null)
            {
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_ontapConfiguration_DiskIopsConfiguration_Mode = cmdletContext.OntapConfiguration_DiskIopsConfiguration_Mode;
            }
            if (requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_ontapConfiguration_DiskIopsConfiguration_Mode != null)
            {
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration.Mode = requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_ontapConfiguration_DiskIopsConfiguration_Mode;
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfigurationIsNull = false;
            }
             // determine if requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration should be set to null
            if (requestOntapConfiguration_ontapConfiguration_DiskIopsConfigurationIsNull)
            {
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration = null;
            }
            if (requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration != null)
            {
                request.OntapConfiguration.DiskIopsConfiguration = requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration;
                requestOntapConfigurationIsNull = false;
            }
             // determine if request.OntapConfiguration should be set to null
            if (requestOntapConfigurationIsNull)
            {
                request.OntapConfiguration = null;
            }
            
             // populate OpenZFSConfiguration
            var requestOpenZFSConfigurationIsNull = true;
            request.OpenZFSConfiguration = new Amazon.FSx.Model.UpdateFileSystemOpenZFSConfiguration();
            List<System.String> requestOpenZFSConfiguration_openZFSConfiguration_AddRouteTableId = null;
            if (cmdletContext.OpenZFSConfiguration_AddRouteTableId != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_AddRouteTableId = cmdletContext.OpenZFSConfiguration_AddRouteTableId;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_AddRouteTableId != null)
            {
                request.OpenZFSConfiguration.AddRouteTableIds = requestOpenZFSConfiguration_openZFSConfiguration_AddRouteTableId;
                requestOpenZFSConfigurationIsNull = false;
            }
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
            List<System.String> requestOpenZFSConfiguration_openZFSConfiguration_RemoveRouteTableId = null;
            if (cmdletContext.OpenZFSConfiguration_RemoveRouteTableId != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RemoveRouteTableId = cmdletContext.OpenZFSConfiguration_RemoveRouteTableId;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RemoveRouteTableId != null)
            {
                request.OpenZFSConfiguration.RemoveRouteTableIds = requestOpenZFSConfiguration_openZFSConfiguration_RemoveRouteTableId;
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
            System.Int64? requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_openZFSConfiguration_DiskIopsConfiguration_Iops = null;
            if (cmdletContext.OpenZFSConfiguration_DiskIopsConfiguration_Iops != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_openZFSConfiguration_DiskIopsConfiguration_Iops = cmdletContext.OpenZFSConfiguration_DiskIopsConfiguration_Iops.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_openZFSConfiguration_DiskIopsConfiguration_Iops != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration.Iops = requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_openZFSConfiguration_DiskIopsConfiguration_Iops.Value;
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfigurationIsNull = false;
            }
            Amazon.FSx.DiskIopsConfigurationMode requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_openZFSConfiguration_DiskIopsConfiguration_Mode = null;
            if (cmdletContext.OpenZFSConfiguration_DiskIopsConfiguration_Mode != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_openZFSConfiguration_DiskIopsConfiguration_Mode = cmdletContext.OpenZFSConfiguration_DiskIopsConfiguration_Mode;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_openZFSConfiguration_DiskIopsConfiguration_Mode != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration.Mode = requestOpenZFSConfiguration_openZFSConfiguration_DiskIopsConfiguration_openZFSConfiguration_DiskIopsConfiguration_Mode;
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
             // determine if request.OpenZFSConfiguration should be set to null
            if (requestOpenZFSConfigurationIsNull)
            {
                request.OpenZFSConfiguration = null;
            }
            if (cmdletContext.StorageCapacity != null)
            {
                request.StorageCapacity = cmdletContext.StorageCapacity.Value;
            }
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
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
        
        private Amazon.FSx.Model.UpdateFileSystemResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateFileSystemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateFileSystem");
            try
            {
                #if DESKTOP
                return client.UpdateFileSystem(request);
                #elif CORECLR
                return client.UpdateFileSystemAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String FileSystemId { get; set; }
            public Amazon.FSx.Model.UpdateFileSystemLustreConfiguration LustreConfiguration { get; set; }
            public List<System.String> OntapConfiguration_AddRouteTableId { get; set; }
            public System.Int32? OntapConfiguration_AutomaticBackupRetentionDay { get; set; }
            public System.String OntapConfiguration_DailyAutomaticBackupStartTime { get; set; }
            public System.Int64? OntapConfiguration_DiskIopsConfiguration_Iops { get; set; }
            public Amazon.FSx.DiskIopsConfigurationMode OntapConfiguration_DiskIopsConfiguration_Mode { get; set; }
            public System.String OntapConfiguration_FsxAdminPassword { get; set; }
            public List<System.String> OntapConfiguration_RemoveRouteTableId { get; set; }
            public System.Int32? OntapConfiguration_ThroughputCapacity { get; set; }
            public System.Int32? OntapConfiguration_ThroughputCapacityPerHAPair { get; set; }
            public System.String OntapConfiguration_WeeklyMaintenanceStartTime { get; set; }
            public List<System.String> OpenZFSConfiguration_AddRouteTableId { get; set; }
            public System.Int32? OpenZFSConfiguration_AutomaticBackupRetentionDay { get; set; }
            public System.Boolean? OpenZFSConfiguration_CopyTagsToBackup { get; set; }
            public System.Boolean? OpenZFSConfiguration_CopyTagsToVolume { get; set; }
            public System.String OpenZFSConfiguration_DailyAutomaticBackupStartTime { get; set; }
            public System.Int64? OpenZFSConfiguration_DiskIopsConfiguration_Iops { get; set; }
            public Amazon.FSx.DiskIopsConfigurationMode OpenZFSConfiguration_DiskIopsConfiguration_Mode { get; set; }
            public List<System.String> OpenZFSConfiguration_RemoveRouteTableId { get; set; }
            public System.Int32? OpenZFSConfiguration_ThroughputCapacity { get; set; }
            public System.String OpenZFSConfiguration_WeeklyMaintenanceStartTime { get; set; }
            public System.Int32? StorageCapacity { get; set; }
            public Amazon.FSx.StorageType StorageType { get; set; }
            public Amazon.FSx.Model.UpdateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateFileSystemResponse, UpdateFSXFileSystemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileSystem;
        }
        
    }
}
