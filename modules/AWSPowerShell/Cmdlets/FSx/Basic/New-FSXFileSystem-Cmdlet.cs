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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates a new, empty Amazon FSx file system. You can create the following supported
    /// Amazon FSx file systems using the <c>CreateFileSystem</c> API operation:
    /// 
    ///  <ul><li><para>
    /// Amazon FSx for Lustre
    /// </para></li><li><para>
    /// Amazon FSx for NetApp ONTAP
    /// </para></li><li><para>
    /// Amazon FSx for OpenZFS
    /// </para></li><li><para>
    /// Amazon FSx for Windows File Server
    /// </para></li></ul><para>
    /// This operation requires a client request token in the request that Amazon FSx uses
    /// to ensure idempotent creation. This means that calling the operation multiple times
    /// with the same client request token has no effect. By using the idempotent operation,
    /// you can retry a <c>CreateFileSystem</c> operation without the risk of creating an
    /// extra file system. This approach can be useful when an initial call fails in a way
    /// that makes it unclear whether a file system was created. Examples are if a transport
    /// level timeout occurred, or your connection was reset. If you use the same client request
    /// token and the initial call created a file system, the client receives success as long
    /// as the parameters are the same.
    /// </para><para>
    /// If a file system with the specified client request token exists and the parameters
    /// match, <c>CreateFileSystem</c> returns the description of the existing file system.
    /// If a file system with the specified client request token exists and the parameters
    /// don't match, this call returns <c>IncompatibleParameterError</c>. If a file system
    /// with the specified client request token doesn't exist, <c>CreateFileSystem</c> does
    /// the following:
    /// </para><ul><li><para>
    /// Creates a new, empty Amazon FSx file system with an assigned ID, and an initial lifecycle
    /// state of <c>CREATING</c>.
    /// </para></li><li><para>
    /// Returns the description of the file system in JSON format.
    /// </para></li></ul><note><para>
    /// The <c>CreateFileSystem</c> call returns while the file system's lifecycle state is
    /// still <c>CREATING</c>. You can check the file-system creation status by calling the
    /// <a href="https://docs.aws.amazon.com/fsx/latest/APIReference/API_DescribeFileSystems.html">DescribeFileSystems</a>
    /// operation, which returns the file system state along with other information.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FSXFileSystem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.FileSystem")]
    [AWSCmdlet("Calls the Amazon FSx CreateFileSystem API operation.", Operation = new[] {"CreateFileSystem"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateFileSystemResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.FileSystem or Amazon.FSx.Model.CreateFileSystemResponse",
        "This cmdlet returns an Amazon.FSx.Model.FileSystem object.",
        "The service call response (type Amazon.FSx.Model.CreateFileSystemResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFSXFileSystemCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>A string of up to 63 ASCII characters that Amazon FSx uses to ensure idempotent creation.
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
        /// doesn't specify tags. If this value is <c>true</c>, and you specify one or more tags,
        /// only the specified tags are copied to backups. If you specify one or more tags when
        /// creating a user-initiated backup, no tags are copied from the file system, regardless
        /// of this value.</para>
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
        /// of the volume. This value defaults to <c>false</c>. If it's set to <c>true</c>, all
        /// tags for the volume are copied to snapshots where the user doesn't specify tags. If
        /// this value is <c>true</c> and you specify one or more tags, only the specified tags
        /// are copied to snapshots. If you specify one or more tags when creating the snapshot,
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
        /// This value defaults to <c>false</c>. If it's set to <c>true</c>, all tags for the
        /// file system are copied to volumes where the user doesn't specify tags. If this value
        /// is <c>true</c>, and you specify one or more tags, only the specified tags are copied
        /// to volumes. If you specify one or more tags when creating the volume, no tags are
        /// copied from the file system, regardless of this value.</para>
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
        
        #region Parameter RootVolumeConfiguration_DataCompressionType
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
        [Alias("OpenZFSConfiguration_RootVolumeConfiguration_DataCompressionType")]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSDataCompressionType")]
        public Amazon.FSx.OpenZFSDataCompressionType RootVolumeConfiguration_DataCompressionType { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_DeploymentType
        /// <summary>
        /// <para>
        /// <para>Specifies the FSx for ONTAP file system deployment type to use in creating the file
        /// system. </para><ul><li><para><c>MULTI_AZ_1</c> - A high availability file system configured for Multi-AZ redundancy
        /// to tolerate temporary Availability Zone (AZ) unavailability. This is a first-generation
        /// FSx for ONTAP file system.</para></li><li><para><c>MULTI_AZ_2</c> - A high availability file system configured for Multi-AZ redundancy
        /// to tolerate temporary AZ unavailability. This is a second-generation FSx for ONTAP
        /// file system.</para></li><li><para><c>SINGLE_AZ_1</c> - A file system configured for Single-AZ redundancy. This is a
        /// first-generation FSx for ONTAP file system.</para></li><li><para><c>SINGLE_AZ_2</c> - A file system configured with multiple high-availability (HA)
        /// pairs for Single-AZ redundancy. This is a second-generation FSx for ONTAP file system.</para></li></ul><para>For information about the use cases for Multi-AZ and Single-AZ deployments, refer
        /// to <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/high-availability-AZ.html">Choosing
        /// a file system deployment type</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.OntapDeploymentType")]
        public Amazon.FSx.OntapDeploymentType OntapConfiguration_DeploymentType { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_DeploymentType
        /// <summary>
        /// <para>
        /// <para>Specifies the file system deployment type. Valid values are the following:</para><ul><li><para><c>MULTI_AZ_1</c>- Creates file systems with high availability and durability by
        /// replicating your data and supporting failover across multiple Availability Zones in
        /// the same Amazon Web Services Region.</para></li><li><para><c>SINGLE_AZ_HA_2</c>- Creates file systems with high availability and throughput
        /// capacities of 160 - 10,240 MB/s using an NVMe L2ARC cache by deploying a primary and
        /// standby file system within the same Availability Zone.</para></li><li><para><c>SINGLE_AZ_HA_1</c>- Creates file systems with high availability and throughput
        /// capacities of 64 - 4,096 MB/s by deploying a primary and standby file system within
        /// the same Availability Zone.</para></li><li><para><c>SINGLE_AZ_2</c>- Creates file systems with throughput capacities of 160 - 10,240
        /// MB/s using an NVMe L2ARC cache that automatically recover within a single Availability
        /// Zone.</para></li><li><para><c>SINGLE_AZ_1</c>- Creates file systems with throughput capacities of 64 - 4,096
        /// MBs that automatically recover within a single Availability Zone.</para></li></ul><para>For a list of which Amazon Web Services Regions each deployment type is available
        /// in, see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/availability-durability.html#available-aws-regions">Deployment
        /// type availability</a>. For more information on the differences in performance between
        /// deployment types, see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/performance.html#zfs-fs-performance">File
        /// system performance</a> in the <i>Amazon FSx for OpenZFS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSDeploymentType")]
        public Amazon.FSx.OpenZFSDeploymentType OpenZFSConfiguration_DeploymentType { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_EndpointIpAddressRange
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) Specifies the IPv4 address range in which the endpoints to access
        /// your file system will be created. By default in the Amazon FSx API, Amazon FSx selects
        /// an unused IP address range for you from the 198.19.* range. By default in the Amazon
        /// FSx console, Amazon FSx chooses the last 64 IP addresses from the VPC’s primary CIDR
        /// range to use as the endpoint IP address range for the file system. You can have overlapping
        /// endpoint IP addresses for file systems deployed in the same VPC/route tables, as long
        /// as they don't overlap with any subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_EndpointIpAddressRange { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_EndpointIpAddressRange
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) Specifies the IPv4 address range in which the endpoints to access
        /// your file system will be created. By default in the Amazon FSx API and Amazon FSx
        /// console, Amazon FSx selects an available /28 IP address range for you from one of
        /// the VPC's CIDR ranges. You can have overlapping endpoint IP addresses for file systems
        /// deployed in the same VPC/route tables, as long as they don't overlap with any subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenZFSConfiguration_EndpointIpAddressRange { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_EndpointIpv6AddressRange
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) Specifies the IPv6 address range in which the endpoints to access
        /// your file system will be created. By default in the Amazon FSx API and Amazon FSx
        /// console, Amazon FSx selects an available /118 IP address range for you from one of
        /// the VPC's CIDR ranges. You can have overlapping endpoint IP addresses for file systems
        /// deployed in the same VPC/route tables, as long as they don't overlap with any subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_EndpointIpv6AddressRange { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_EndpointIpv6AddressRange
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) Specifies the IPv6 address range in which the endpoints to access
        /// your file system will be created. By default in the Amazon FSx API and Amazon FSx
        /// console, Amazon FSx selects an available /118 IP address range for you from one of
        /// the VPC's CIDR ranges. You can have overlapping endpoint IP addresses for file systems
        /// deployed in the same VPC/route tables, as long as they don't overlap with any subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenZFSConfiguration_EndpointIpv6AddressRange { get; set; }
        #endregion
        
        #region Parameter FileSystemType
        /// <summary>
        /// <para>
        /// <para>The type of Amazon FSx file system to create. Valid values are <c>WINDOWS</c>, <c>LUSTRE</c>,
        /// <c>ONTAP</c>, and <c>OPENZFS</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FSx.FileSystemType")]
        public Amazon.FSx.FileSystemType FileSystemType { get; set; }
        #endregion
        
        #region Parameter FileSystemTypeVersion
        /// <summary>
        /// <para>
        /// <para>For FSx for Lustre file systems, sets the Lustre version for the file system that
        /// you're creating. Valid values are <c>2.10</c>, <c>2.12</c>, and <c>2.15</c>:</para><ul><li><para><c>2.10</c> is supported by the Scratch and Persistent_1 Lustre deployment types.</para></li><li><para><c>2.12</c> is supported by all Lustre deployment types, except for <c>PERSISTENT_2</c>
        /// with a metadata configuration mode.</para></li><li><para><c>2.15</c> is supported by all Lustre deployment types and is recommended for all
        /// new file systems.</para></li></ul><para>Default value is <c>2.10</c>, except for the following deployments:</para><ul><li><para>Default value is <c>2.12</c> when <c>DeploymentType</c> is set to <c>PERSISTENT_2</c>
        /// without a metadata configuration mode.</para></li><li><para>Default value is <c>2.15</c> when <c>DeploymentType</c> is set to <c>PERSISTENT_2</c>
        /// with a metadata configuration mode.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FileSystemTypeVersion { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_FsxAdminPassword
        /// <summary>
        /// <para>
        /// <para>The ONTAP administrative password for the <c>fsxadmin</c> user with which you administer
        /// your file system using the NetApp ONTAP CLI and REST API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_FsxAdminPassword { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_HAPair
        /// <summary>
        /// <para>
        /// <para>Specifies how many high-availability (HA) pairs of file servers will power your file
        /// system. First-generation file systems are powered by 1 HA pair. Second-generation
        /// multi-AZ file systems are powered by 1 HA pair. Second generation single-AZ file systems
        /// are powered by up to 12 HA pairs. The default value is 1. The value of this property
        /// affects the values of <c>StorageCapacity</c>, <c>Iops</c>, and <c>ThroughputCapacity</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/administering-file-systems.html#HA-pairs">High-availability
        /// (HA) pairs</a> in the FSx for ONTAP user guide. Block storage protocol support (iSCSI
        /// and NVMe over TCP) is disabled on file systems with more than 6 HA pairs. For more
        /// information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/supported-fsx-clients.html#using-block-storage">Using
        /// block storage protocols</a>. </para><para>Amazon FSx responds with an HTTP status code 400 (Bad Request) for the following conditions:</para><ul><li><para>The value of <c>HAPairs</c> is less than 1 or greater than 12.</para></li><li><para>The value of <c>HAPairs</c> is greater than 1 and the value of <c>DeploymentType</c>
        /// is <c>SINGLE_AZ_1</c>, <c>MULTI_AZ_1</c>, or <c>MULTI_AZ_2</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_HAPairs")]
        public System.Int32? OntapConfiguration_HAPair { get; set; }
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
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The network type of the Amazon FSx file system that you are creating. Valid values
        /// are <c>IPV4</c> (which supports IPv4 only) and <c>DUAL</c> (for dual-stack mode, which
        /// supports both IPv4 and IPv6). The default is <c>IPV4</c>. Supported for FSx for OpenZFS,
        /// FSx for ONTAP, and FSx for Windows File Server file systems.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.NetworkType")]
        public Amazon.FSx.NetworkType NetworkType { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfiguration_NfsExport
        /// <summary>
        /// <para>
        /// <para>The configuration object for mounting a file system.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RootVolumeConfiguration_NfsExports")]
        public Amazon.FSx.Model.OpenZFSNfsExport[] RootVolumeConfiguration_NfsExport { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_PreferredSubnetId
        /// <summary>
        /// <para>
        /// <para>Required when <c>DeploymentType</c> is set to <c>MULTI_AZ_1</c> or <c>MULTI_AZ_2</c>.
        /// This specifies the subnet in which you want the preferred file server to be located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_PreferredSubnetId { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_PreferredSubnetId
        /// <summary>
        /// <para>
        /// <para>Required when <c>DeploymentType</c> is set to <c>MULTI_AZ_1</c>. This specifies the
        /// subnet in which you want the preferred file server to be located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenZFSConfiguration_PreferredSubnetId { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfiguration_ReadOnly
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether the volume is read-only. Setting this value to
        /// <c>true</c> can be useful after you have completed changes to a volume and no longer
        /// want changes to occur. </para>
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
        
        #region Parameter OntapConfiguration_RouteTableId
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) Specifies the route tables in which Amazon FSx creates the rules for
        /// routing traffic to the correct file server. You should specify all virtual private
        /// cloud (VPC) route tables associated with the subnets in which your clients are located.
        /// By default, Amazon FSx selects your VPC's default route table.</para><note><para>Amazon FSx manages these route tables for Multi-AZ file systems using tag-based authentication.
        /// These route tables are tagged with <c>Key: AmazonFSx; Value: ManagedByAmazonFSx</c>.
        /// When creating FSx for ONTAP Multi-AZ file systems using CloudFormation we recommend
        /// that you add the <c>Key: AmazonFSx; Value: ManagedByAmazonFSx</c> tag manually.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_RouteTableIds")]
        public System.String[] OntapConfiguration_RouteTableId { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_RouteTableId
        /// <summary>
        /// <para>
        /// <para>(Multi-AZ only) Specifies the route tables in which Amazon FSx creates the rules for
        /// routing traffic to the correct file server. You should specify all virtual private
        /// cloud (VPC) route tables associated with the subnets in which your clients are located.
        /// By default, Amazon FSx selects your VPC's default route table.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RouteTableIds")]
        public System.String[] OpenZFSConfiguration_RouteTableId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of IDs specifying the security groups to apply to all network interfaces created
        /// for file system access. This list isn't returned in later requests to describe the
        /// file system.</para><important><para>You must specify a security group if you are creating a Multi-AZ FSx for ONTAP file
        /// system in a VPC subnet that has been shared with you.</para></important><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ReadCacheConfiguration_SizeGiB
        /// <summary>
        /// <para>
        /// <para> Required if <c>SizingMode</c> is set to <c>USER_PROVISIONED</c>. Specifies the size
        /// of the file system's SSD read cache, in gibibytes (GiB). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_ReadCacheConfiguration_SizeGiB")]
        public System.Int32? ReadCacheConfiguration_SizeGiB { get; set; }
        #endregion
        
        #region Parameter ReadCacheConfiguration_SizingMode
        /// <summary>
        /// <para>
        /// <para> Specifies how the provisioned SSD read cache is sized, as follows: </para><ul><li><para>Set to <c>NO_CACHE</c> if you do not want to use an SSD read cache with your Intelligent-Tiering
        /// file system.</para></li><li><para>Set to <c>USER_PROVISIONED</c> to specify the exact size of your SSD read cache.</para></li><li><para>Set to <c>PROPORTIONAL_TO_THROUGHPUT_CAPACITY</c> to have your SSD read cache automatically
        /// sized based on your throughput capacity.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_ReadCacheConfiguration_SizingMode")]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSReadCacheSizingMode")]
        public Amazon.FSx.OpenZFSReadCacheSizingMode ReadCacheConfiguration_SizingMode { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>Sets the storage capacity of the file system that you're creating, in gibibytes (GiB).</para><para><b>FSx for Lustre file systems</b> - The amount of storage capacity that you can
        /// configure depends on the value that you set for <c>StorageType</c> and the Lustre
        /// <c>DeploymentType</c>, as follows:</para><ul><li><para>For <c>SCRATCH_2</c>, <c>PERSISTENT_2</c>, and <c>PERSISTENT_1</c> deployment types
        /// using SSD storage type, the valid values are 1200 GiB, 2400 GiB, and increments of
        /// 2400 GiB.</para></li><li><para>For <c>PERSISTENT_1</c> HDD file systems, valid values are increments of 6000 GiB
        /// for 12 MB/s/TiB file systems and increments of 1800 GiB for 40 MB/s/TiB file systems.</para></li><li><para>For <c>SCRATCH_1</c> deployment type, valid values are 1200 GiB, 2400 GiB, and increments
        /// of 3600 GiB.</para></li></ul><para><b>FSx for ONTAP file systems</b> - The amount of storage capacity that you can configure
        /// depends on the value of the <c>HAPairs</c> property. The minimum value is calculated
        /// as 1,024 * <c>HAPairs</c> and the maximum is calculated as 524,288 * <c>HAPairs</c>.
        /// </para><para><b>FSx for OpenZFS file systems</b> - The amount of storage capacity that you can
        /// configure is from 64 GiB up to 524,288 GiB (512 TiB).</para><para><b>FSx for Windows File Server file systems</b> - The amount of storage capacity
        /// that you can configure depends on the value that you set for <c>StorageType</c> as
        /// follows:</para><ul><li><para>For SSD storage, valid values are 32 GiB-65,536 GiB (64 TiB).</para></li><li><para>For HDD storage, valid values are 2000 GiB-65,536 GiB (64 TiB).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Sets the storage class for the file system that you're creating. Valid values are
        /// <c>SSD</c>, <c>HDD</c>, and <c>INTELLIGENT_TIERING</c>.</para><ul><li><para>Set to <c>SSD</c> to use solid state drive storage. SSD is supported on all Windows,
        /// Lustre, ONTAP, and OpenZFS deployment types.</para></li><li><para>Set to <c>HDD</c> to use hard disk drive storage, which is supported on <c>SINGLE_AZ_2</c>
        /// and <c>MULTI_AZ_1</c> Windows file system deployment types, and on <c>PERSISTENT_1</c>
        /// Lustre file system deployment types.</para></li><li><para>Set to <c>INTELLIGENT_TIERING</c> to use fully elastic, intelligently-tiered storage.
        /// Intelligent-Tiering is only available for OpenZFS file systems with the Multi-AZ deployment
        /// type and for Lustre file systems with the Persistent_2 deployment type.</para></li></ul><para>Default value is <c>SSD</c>. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/WindowsGuide/optimize-fsx-costs.html#storage-type-options">
        /// Storage type options</a> in the <i>FSx for Windows File Server User Guide</i>, <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/using-fsx-lustre.html#lustre-storage-classes">FSx
        /// for Lustre storage classes</a> in the <i>FSx for Lustre User Guide</i>, and <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/performance-intelligent-tiering">Working
        /// with Intelligent-Tiering</a> in the <i>Amazon FSx for OpenZFS User Guide</i>.</para>
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
        /// Windows and ONTAP <c>MULTI_AZ_1</c> deployment types,provide exactly two subnet IDs,
        /// one for the preferred file server and one for the standby file server. You specify
        /// one of these subnets as the preferred subnet using the <c>WindowsConfiguration &gt;
        /// PreferredSubnetID</c> or <c>OntapConfiguration &gt; PreferredSubnetID</c> properties.
        /// For more information about Multi-AZ file system configuration, see <a href="https://docs.aws.amazon.com/fsx/latest/WindowsGuide/high-availability-multiAZ.html">
        /// Availability and durability: Single-AZ and Multi-AZ file systems</a> in the <i>Amazon
        /// FSx for Windows User Guide</i> and <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/high-availability-multiAZ.html">
        /// Availability and durability</a> in the <i>Amazon FSx for ONTAP User Guide</i>.</para><para>For Windows <c>SINGLE_AZ_1</c> and <c>SINGLE_AZ_2</c> and all Lustre deployment types,
        /// provide exactly one subnet ID. The file server is launched in that subnet's Availability
        /// Zone.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>The tags to apply to the file system that's being created. The key value of the <c>Name</c>
        /// tag appears in the console as the file system name.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_ThroughputCapacity
        /// <summary>
        /// <para>
        /// <para>Sets the throughput capacity for the file system that you're creating in megabytes
        /// per second (MBps). For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-throughput-capacity.html">Managing
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
        /// <para>Specifies the throughput of an Amazon FSx for OpenZFS file system, measured in megabytes
        /// per second (MBps). Valid values depend on the <c>DeploymentType</c> that you choose,
        /// as follows:</para><ul><li><para>For <c>MULTI_AZ_1</c> and <c>SINGLE_AZ_2</c>, valid values are 160, 320, 640, 1280,
        /// 2560, 3840, 5120, 7680, or 10240 MBps.</para></li><li><para>For <c>SINGLE_AZ_1</c>, valid values are 64, 128, 256, 512, 1024, 2048, 3072, or 4096
        /// MBps.</para></li></ul><para>You pay for additional throughput capacity that you provision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_ThroughputCapacity { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_ThroughputCapacityPerHAPair
        /// <summary>
        /// <para>
        /// <para>Use to choose the throughput capacity per HA pair, rather than the total throughput
        /// for the file system. </para><para>You can define either the <c>ThroughputCapacityPerHAPair</c> or the <c>ThroughputCapacity</c>
        /// when creating a file system, but not both.</para><para>This field and <c>ThroughputCapacity</c> are the same for file systems powered by
        /// one HA pair.</para><ul><li><para>For <c>SINGLE_AZ_1</c> and <c>MULTI_AZ_1</c> file systems, valid values are 128, 256,
        /// 512, 1024, 2048, or 4096 MBps.</para></li><li><para>For <c>SINGLE_AZ_2</c>, valid values are 1536, 3072, or 6144 MBps.</para></li><li><para>For <c>MULTI_AZ_2</c>, valid values are 384, 768, 1536, 3072, or 6144 MBps.</para></li></ul><para>Amazon FSx responds with an HTTP status code 400 (Bad Request) for the following conditions:</para><ul><li><para>The value of <c>ThroughputCapacity</c> and <c>ThroughputCapacityPerHAPair</c> are
        /// not the same value for file systems with one HA pair.</para></li><li><para>The value of deployment type is <c>SINGLE_AZ_2</c> and <c>ThroughputCapacity</c> /
        /// <c>ThroughputCapacityPerHAPair</c> is not a valid HA pair (a value between 1 and 12).</para></li><li><para>The value of <c>ThroughputCapacityPerHAPair</c> is not a valid value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OntapConfiguration_ThroughputCapacityPerHAPair { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfiguration_UserAndGroupQuota
        /// <summary>
        /// <para>
        /// <para>An object specifying how much storage users or groups can use on the volume.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_RootVolumeConfiguration_UserAndGroupQuotas")]
        public Amazon.FSx.Model.OpenZFSUserOrGroupQuota[] RootVolumeConfiguration_UserAndGroupQuota { get; set; }
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
        /// <para>The Microsoft Windows configuration for the file system that's being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.FSx.Model.CreateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileSystem'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateFileSystemResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateFileSystemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileSystem";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXFileSystem (CreateFileSystem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateFileSystemResponse, NewFSXFileSystemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileSystemType = this.FileSystemType;
            #if MODULAR
            if (this.FileSystemType == null && ParameterWasBound(nameof(this.FileSystemType)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileSystemTypeVersion = this.FileSystemTypeVersion;
            context.KmsKeyId = this.KmsKeyId;
            context.LustreConfiguration = this.LustreConfiguration;
            context.NetworkType = this.NetworkType;
            context.OntapConfiguration_AutomaticBackupRetentionDay = this.OntapConfiguration_AutomaticBackupRetentionDay;
            context.OntapConfiguration_DailyAutomaticBackupStartTime = this.OntapConfiguration_DailyAutomaticBackupStartTime;
            context.OntapConfiguration_DeploymentType = this.OntapConfiguration_DeploymentType;
            context.OntapConfiguration_DiskIopsConfiguration_Iops = this.OntapConfiguration_DiskIopsConfiguration_Iops;
            context.OntapConfiguration_DiskIopsConfiguration_Mode = this.OntapConfiguration_DiskIopsConfiguration_Mode;
            context.OntapConfiguration_EndpointIpAddressRange = this.OntapConfiguration_EndpointIpAddressRange;
            context.OntapConfiguration_EndpointIpv6AddressRange = this.OntapConfiguration_EndpointIpv6AddressRange;
            context.OntapConfiguration_FsxAdminPassword = this.OntapConfiguration_FsxAdminPassword;
            context.OntapConfiguration_HAPair = this.OntapConfiguration_HAPair;
            context.OntapConfiguration_PreferredSubnetId = this.OntapConfiguration_PreferredSubnetId;
            if (this.OntapConfiguration_RouteTableId != null)
            {
                context.OntapConfiguration_RouteTableId = new List<System.String>(this.OntapConfiguration_RouteTableId);
            }
            context.OntapConfiguration_ThroughputCapacity = this.OntapConfiguration_ThroughputCapacity;
            context.OntapConfiguration_ThroughputCapacityPerHAPair = this.OntapConfiguration_ThroughputCapacityPerHAPair;
            context.OntapConfiguration_WeeklyMaintenanceStartTime = this.OntapConfiguration_WeeklyMaintenanceStartTime;
            context.OpenZFSConfiguration_AutomaticBackupRetentionDay = this.OpenZFSConfiguration_AutomaticBackupRetentionDay;
            context.OpenZFSConfiguration_CopyTagsToBackup = this.OpenZFSConfiguration_CopyTagsToBackup;
            context.OpenZFSConfiguration_CopyTagsToVolume = this.OpenZFSConfiguration_CopyTagsToVolume;
            context.OpenZFSConfiguration_DailyAutomaticBackupStartTime = this.OpenZFSConfiguration_DailyAutomaticBackupStartTime;
            context.OpenZFSConfiguration_DeploymentType = this.OpenZFSConfiguration_DeploymentType;
            context.OpenZFSConfiguration_DiskIopsConfiguration_Iops = this.OpenZFSConfiguration_DiskIopsConfiguration_Iops;
            context.OpenZFSConfiguration_DiskIopsConfiguration_Mode = this.OpenZFSConfiguration_DiskIopsConfiguration_Mode;
            context.OpenZFSConfiguration_EndpointIpAddressRange = this.OpenZFSConfiguration_EndpointIpAddressRange;
            context.OpenZFSConfiguration_EndpointIpv6AddressRange = this.OpenZFSConfiguration_EndpointIpv6AddressRange;
            context.OpenZFSConfiguration_PreferredSubnetId = this.OpenZFSConfiguration_PreferredSubnetId;
            context.ReadCacheConfiguration_SizeGiB = this.ReadCacheConfiguration_SizeGiB;
            context.ReadCacheConfiguration_SizingMode = this.ReadCacheConfiguration_SizingMode;
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
            if (this.OpenZFSConfiguration_RouteTableId != null)
            {
                context.OpenZFSConfiguration_RouteTableId = new List<System.String>(this.OpenZFSConfiguration_RouteTableId);
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
            var request = new Amazon.FSx.Model.CreateFileSystemRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemType != null)
            {
                request.FileSystemType = cmdletContext.FileSystemType;
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
            if (cmdletContext.NetworkType != null)
            {
                request.NetworkType = cmdletContext.NetworkType;
            }
            
             // populate OntapConfiguration
            var requestOntapConfigurationIsNull = true;
            request.OntapConfiguration = new Amazon.FSx.Model.CreateFileSystemOntapConfiguration();
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
            Amazon.FSx.OntapDeploymentType requestOntapConfiguration_ontapConfiguration_DeploymentType = null;
            if (cmdletContext.OntapConfiguration_DeploymentType != null)
            {
                requestOntapConfiguration_ontapConfiguration_DeploymentType = cmdletContext.OntapConfiguration_DeploymentType;
            }
            if (requestOntapConfiguration_ontapConfiguration_DeploymentType != null)
            {
                request.OntapConfiguration.DeploymentType = requestOntapConfiguration_ontapConfiguration_DeploymentType;
                requestOntapConfigurationIsNull = false;
            }
            System.String requestOntapConfiguration_ontapConfiguration_EndpointIpAddressRange = null;
            if (cmdletContext.OntapConfiguration_EndpointIpAddressRange != null)
            {
                requestOntapConfiguration_ontapConfiguration_EndpointIpAddressRange = cmdletContext.OntapConfiguration_EndpointIpAddressRange;
            }
            if (requestOntapConfiguration_ontapConfiguration_EndpointIpAddressRange != null)
            {
                request.OntapConfiguration.EndpointIpAddressRange = requestOntapConfiguration_ontapConfiguration_EndpointIpAddressRange;
                requestOntapConfigurationIsNull = false;
            }
            System.String requestOntapConfiguration_ontapConfiguration_EndpointIpv6AddressRange = null;
            if (cmdletContext.OntapConfiguration_EndpointIpv6AddressRange != null)
            {
                requestOntapConfiguration_ontapConfiguration_EndpointIpv6AddressRange = cmdletContext.OntapConfiguration_EndpointIpv6AddressRange;
            }
            if (requestOntapConfiguration_ontapConfiguration_EndpointIpv6AddressRange != null)
            {
                request.OntapConfiguration.EndpointIpv6AddressRange = requestOntapConfiguration_ontapConfiguration_EndpointIpv6AddressRange;
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
            System.Int32? requestOntapConfiguration_ontapConfiguration_HAPair = null;
            if (cmdletContext.OntapConfiguration_HAPair != null)
            {
                requestOntapConfiguration_ontapConfiguration_HAPair = cmdletContext.OntapConfiguration_HAPair.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_HAPair != null)
            {
                request.OntapConfiguration.HAPairs = requestOntapConfiguration_ontapConfiguration_HAPair.Value;
                requestOntapConfigurationIsNull = false;
            }
            System.String requestOntapConfiguration_ontapConfiguration_PreferredSubnetId = null;
            if (cmdletContext.OntapConfiguration_PreferredSubnetId != null)
            {
                requestOntapConfiguration_ontapConfiguration_PreferredSubnetId = cmdletContext.OntapConfiguration_PreferredSubnetId;
            }
            if (requestOntapConfiguration_ontapConfiguration_PreferredSubnetId != null)
            {
                request.OntapConfiguration.PreferredSubnetId = requestOntapConfiguration_ontapConfiguration_PreferredSubnetId;
                requestOntapConfigurationIsNull = false;
            }
            List<System.String> requestOntapConfiguration_ontapConfiguration_RouteTableId = null;
            if (cmdletContext.OntapConfiguration_RouteTableId != null)
            {
                requestOntapConfiguration_ontapConfiguration_RouteTableId = cmdletContext.OntapConfiguration_RouteTableId;
            }
            if (requestOntapConfiguration_ontapConfiguration_RouteTableId != null)
            {
                request.OntapConfiguration.RouteTableIds = requestOntapConfiguration_ontapConfiguration_RouteTableId;
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
            System.String requestOpenZFSConfiguration_openZFSConfiguration_EndpointIpAddressRange = null;
            if (cmdletContext.OpenZFSConfiguration_EndpointIpAddressRange != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_EndpointIpAddressRange = cmdletContext.OpenZFSConfiguration_EndpointIpAddressRange;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_EndpointIpAddressRange != null)
            {
                request.OpenZFSConfiguration.EndpointIpAddressRange = requestOpenZFSConfiguration_openZFSConfiguration_EndpointIpAddressRange;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.String requestOpenZFSConfiguration_openZFSConfiguration_EndpointIpv6AddressRange = null;
            if (cmdletContext.OpenZFSConfiguration_EndpointIpv6AddressRange != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_EndpointIpv6AddressRange = cmdletContext.OpenZFSConfiguration_EndpointIpv6AddressRange;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_EndpointIpv6AddressRange != null)
            {
                request.OpenZFSConfiguration.EndpointIpv6AddressRange = requestOpenZFSConfiguration_openZFSConfiguration_EndpointIpv6AddressRange;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.String requestOpenZFSConfiguration_openZFSConfiguration_PreferredSubnetId = null;
            if (cmdletContext.OpenZFSConfiguration_PreferredSubnetId != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_PreferredSubnetId = cmdletContext.OpenZFSConfiguration_PreferredSubnetId;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_PreferredSubnetId != null)
            {
                request.OpenZFSConfiguration.PreferredSubnetId = requestOpenZFSConfiguration_openZFSConfiguration_PreferredSubnetId;
                requestOpenZFSConfigurationIsNull = false;
            }
            List<System.String> requestOpenZFSConfiguration_openZFSConfiguration_RouteTableId = null;
            if (cmdletContext.OpenZFSConfiguration_RouteTableId != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_RouteTableId = cmdletContext.OpenZFSConfiguration_RouteTableId;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_RouteTableId != null)
            {
                request.OpenZFSConfiguration.RouteTableIds = requestOpenZFSConfiguration_openZFSConfiguration_RouteTableId;
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
            Amazon.FSx.Model.OpenZFSReadCacheConfiguration requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration = null;
            
             // populate ReadCacheConfiguration
            var requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfigurationIsNull = true;
            requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration = new Amazon.FSx.Model.OpenZFSReadCacheConfiguration();
            System.Int32? requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration_readCacheConfiguration_SizeGiB = null;
            if (cmdletContext.ReadCacheConfiguration_SizeGiB != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration_readCacheConfiguration_SizeGiB = cmdletContext.ReadCacheConfiguration_SizeGiB.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration_readCacheConfiguration_SizeGiB != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration.SizeGiB = requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration_readCacheConfiguration_SizeGiB.Value;
                requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfigurationIsNull = false;
            }
            Amazon.FSx.OpenZFSReadCacheSizingMode requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration_readCacheConfiguration_SizingMode = null;
            if (cmdletContext.ReadCacheConfiguration_SizingMode != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration_readCacheConfiguration_SizingMode = cmdletContext.ReadCacheConfiguration_SizingMode;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration_readCacheConfiguration_SizingMode != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration.SizingMode = requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration_readCacheConfiguration_SizingMode;
                requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfigurationIsNull = false;
            }
             // determine if requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration should be set to null
            if (requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfigurationIsNull)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration = null;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration != null)
            {
                request.OpenZFSConfiguration.ReadCacheConfiguration = requestOpenZFSConfiguration_openZFSConfiguration_ReadCacheConfiguration;
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
        
        private Amazon.FSx.Model.CreateFileSystemResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateFileSystemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateFileSystem");
            try
            {
                return client.CreateFileSystemAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.FSx.FileSystemType FileSystemType { get; set; }
            public System.String FileSystemTypeVersion { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.FSx.Model.CreateFileSystemLustreConfiguration LustreConfiguration { get; set; }
            public Amazon.FSx.NetworkType NetworkType { get; set; }
            public System.Int32? OntapConfiguration_AutomaticBackupRetentionDay { get; set; }
            public System.String OntapConfiguration_DailyAutomaticBackupStartTime { get; set; }
            public Amazon.FSx.OntapDeploymentType OntapConfiguration_DeploymentType { get; set; }
            public System.Int64? OntapConfiguration_DiskIopsConfiguration_Iops { get; set; }
            public Amazon.FSx.DiskIopsConfigurationMode OntapConfiguration_DiskIopsConfiguration_Mode { get; set; }
            public System.String OntapConfiguration_EndpointIpAddressRange { get; set; }
            public System.String OntapConfiguration_EndpointIpv6AddressRange { get; set; }
            public System.String OntapConfiguration_FsxAdminPassword { get; set; }
            public System.Int32? OntapConfiguration_HAPair { get; set; }
            public System.String OntapConfiguration_PreferredSubnetId { get; set; }
            public List<System.String> OntapConfiguration_RouteTableId { get; set; }
            public System.Int32? OntapConfiguration_ThroughputCapacity { get; set; }
            public System.Int32? OntapConfiguration_ThroughputCapacityPerHAPair { get; set; }
            public System.String OntapConfiguration_WeeklyMaintenanceStartTime { get; set; }
            public System.Int32? OpenZFSConfiguration_AutomaticBackupRetentionDay { get; set; }
            public System.Boolean? OpenZFSConfiguration_CopyTagsToBackup { get; set; }
            public System.Boolean? OpenZFSConfiguration_CopyTagsToVolume { get; set; }
            public System.String OpenZFSConfiguration_DailyAutomaticBackupStartTime { get; set; }
            public Amazon.FSx.OpenZFSDeploymentType OpenZFSConfiguration_DeploymentType { get; set; }
            public System.Int64? OpenZFSConfiguration_DiskIopsConfiguration_Iops { get; set; }
            public Amazon.FSx.DiskIopsConfigurationMode OpenZFSConfiguration_DiskIopsConfiguration_Mode { get; set; }
            public System.String OpenZFSConfiguration_EndpointIpAddressRange { get; set; }
            public System.String OpenZFSConfiguration_EndpointIpv6AddressRange { get; set; }
            public System.String OpenZFSConfiguration_PreferredSubnetId { get; set; }
            public System.Int32? ReadCacheConfiguration_SizeGiB { get; set; }
            public Amazon.FSx.OpenZFSReadCacheSizingMode ReadCacheConfiguration_SizingMode { get; set; }
            public System.Boolean? RootVolumeConfiguration_CopyTagsToSnapshot { get; set; }
            public Amazon.FSx.OpenZFSDataCompressionType RootVolumeConfiguration_DataCompressionType { get; set; }
            public List<Amazon.FSx.Model.OpenZFSNfsExport> RootVolumeConfiguration_NfsExport { get; set; }
            public System.Boolean? RootVolumeConfiguration_ReadOnly { get; set; }
            public System.Int32? RootVolumeConfiguration_RecordSizeKiB { get; set; }
            public List<Amazon.FSx.Model.OpenZFSUserOrGroupQuota> RootVolumeConfiguration_UserAndGroupQuota { get; set; }
            public List<System.String> OpenZFSConfiguration_RouteTableId { get; set; }
            public System.Int32? OpenZFSConfiguration_ThroughputCapacity { get; set; }
            public System.String OpenZFSConfiguration_WeeklyMaintenanceStartTime { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.Int32? StorageCapacity { get; set; }
            public Amazon.FSx.StorageType StorageType { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public Amazon.FSx.Model.CreateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
            public System.Func<Amazon.FSx.Model.CreateFileSystemResponse, NewFSXFileSystemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileSystem;
        }
        
    }
}
