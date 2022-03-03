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
    /// Creates an FSx for ONTAP or Amazon FSx for OpenZFS storage volume.
    /// </summary>
    [Cmdlet("New", "FSXVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.Volume")]
    [AWSCmdlet("Calls the Amazon FSx CreateVolume API operation.", Operation = new[] {"CreateVolume"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateVolumeResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.Volume or Amazon.FSx.Model.CreateVolumeResponse",
        "This cmdlet returns an Amazon.FSx.Model.Volume object.",
        "The service call response (type Amazon.FSx.Model.CreateVolumeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFSXVolumeCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
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
        /// it is considered "cold" and moved to the capacity pool. Used with the <code>AUTO</code>
        /// and <code>SNAPSHOT_ONLY</code> tiering policies. Enter a whole number between 2 and
        /// 183. Default values are 31 days for <code>AUTO</code> and 2 days for <code>SNAPSHOT_ONLY</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_TieringPolicy_CoolingPeriod")]
        public System.Int32? TieringPolicy_CoolingPeriod { get; set; }
        #endregion
        
        #region Parameter OriginSnapshot_CopyStrategy
        /// <summary>
        /// <para>
        /// <para>The strategy used when copying data from the snapshot to the new volume. </para><ul><li><para><code>CLONE</code> - The new volume references the data in the origin snapshot. Cloning
        /// a snapshot is faster than copying data from the snapshot to a new volume and doesn't
        /// consume disk throughput. However, the origin snapshot can't be deleted if there is
        /// a volume using its copied data. </para></li><li><para><code>FULL_COPY</code> - Copies all data from the snapshot to the new volume. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_OriginSnapshot_CopyStrategy")]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSCopyStrategy")]
        public Amazon.FSx.OpenZFSCopyStrategy OriginSnapshot_CopyStrategy { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>A Boolean value indicating whether tags for the volume should be copied to snapshots.
        /// This value defaults to <code>false</code>. If it's set to <code>true</code>, all tags
        /// for the volume are copied to snapshots where the user doesn't specify tags. If this
        /// value is <code>true</code>, and you specify one or more tags, only the specified tags
        /// are copied to snapshots. If you specify one or more tags when creating the snapshot,
        /// no tags are copied from the volume, regardless of this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_CopyTagsToSnapshots")]
        public System.Boolean? OpenZFSConfiguration_CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_DataCompressionType
        /// <summary>
        /// <para>
        /// <para>Specifies the method used to compress the data on the volume. The compression type
        /// is <code>NONE</code> by default.</para><ul><li><para><code>NONE</code> - Doesn't compress the data on the volume. <code>NONE</code> is
        /// the default.</para></li><li><para><code>ZSTD</code> - Compresses the data in the volume using the Zstandard (ZSTD)
        /// compression algorithm. ZSTD compression provides a higher level of data compression
        /// and higher read throughput performance than LZ4 compression.</para></li><li><para><code>LZ4</code> - Compresses the data in the volume using the LZ4 compression algorithm.
        /// LZ4 compression provides a lower level of compression and higher write throughput
        /// performance than ZSTD compression.</para></li></ul><para>For more information about volume compression types and the performance of your Amazon
        /// FSx for OpenZFS file system, see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/performance.html#performance-tips-zfs">
        /// Tips for maximizing performance</a> File system and volume settings in the <i>Amazon
        /// FSx for OpenZFS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSDataCompressionType")]
        public Amazon.FSx.OpenZFSDataCompressionType OpenZFSConfiguration_DataCompressionType { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_JunctionPath
        /// <summary>
        /// <para>
        /// <para>Specifies the location in the SVM's namespace where the volume is mounted. The <code>JunctionPath</code>
        /// must have a leading forward slash, such as <code>/vol3</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_JunctionPath { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the volume that you're creating.</para>
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
        /// <para>Specifies the tiering policy used to transition data. Default value is <code>SNAPSHOT_ONLY</code>.</para><ul><li><para><code>SNAPSHOT_ONLY</code> - moves cold snapshots to the capacity pool storage tier.</para></li><li><para><code>AUTO</code> - moves cold user data and snapshots to the capacity pool storage
        /// tier based on your access patterns.</para></li><li><para><code>ALL</code> - moves all user data blocks in both the active file system and
        /// Snapshot copies to the storage pool tier.</para></li><li><para><code>NONE</code> - keeps a volume's data in the primary storage tier, preventing
        /// it from being moved to the capacity pool tier.</para></li></ul>
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
        
        #region Parameter OpenZFSConfiguration_ParentVolumeId
        /// <summary>
        /// <para>
        /// <para>The ID of the volume to use as the parent volume of the volume that you are creating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenZFSConfiguration_ParentVolumeId { get; set; }
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
        /// <para>Specifies the suggested block size for a volume in a ZFS dataset, in kibibytes (KiB).
        /// Valid values are 4, 8, 16, 32, 64, 128, 256, 512, or 1024 KiB. The default is 128
        /// KiB. We recommend using the default setting for the majority of use cases. Generally,
        /// workloads that write in fixed small or large record sizes may benefit from setting
        /// a custom record size, like database workloads (small record size) or media streaming
        /// workloads (large record size). For additional guidance on when to set a custom record
        /// size, see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/performance.html#record-size-performance">
        /// ZFS Record size</a> in the <i>Amazon FSx for OpenZFS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_RecordSizeKiB { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SecurityStyle
        /// <summary>
        /// <para>
        /// <para>The security style for the volume. Specify one of the following values:</para><ul><li><para><code>UNIX</code> if the file system is managed by a UNIX administrator, the majority
        /// of users are NFS clients, and an application accessing the data uses a UNIX user as
        /// the service account. <code>UNIX</code> is the default.</para></li><li><para><code>NTFS</code> if the file system is managed by a Windows administrator, the majority
        /// of users are SMB clients, and an application accessing the data uses a Windows user
        /// as the service account.</para></li><li><para><code>MIXED</code> if the file system is managed by both UNIX and Windows administrators
        /// and users consist of both NFS and SMB clients.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.SecurityStyle")]
        public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_SizeInMegabyte
        /// <summary>
        /// <para>
        /// <para>Specifies the size of the volume, in megabytes (MB), that you are creating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_SizeInMegabytes")]
        public System.Int32? OntapConfiguration_SizeInMegabyte { get; set; }
        #endregion
        
        #region Parameter OriginSnapshot_SnapshotARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_OriginSnapshot_SnapshotARN")]
        public System.String OriginSnapshot_SnapshotARN { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_StorageCapacityQuotaGiB
        /// <summary>
        /// <para>
        /// <para>Sets the maximum storage size in gibibytes (GiB) for the volume. You can specify a
        /// quota that is larger than the storage on the parent volume. A volume quota limits
        /// the amount of storage that the volume can consume to the configured amount, but does
        /// not guarantee the space will be available on the parent volume. To guarantee quota
        /// space, you must also set <code>StorageCapacityReservationGiB</code>. To <i>not</i>
        /// specify a storage capacity quota, set this to <code>-1</code>. </para><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/managing-volumes.html#volume-properties">Volume
        /// properties</a> in the <i>Amazon FSx for OpenZFS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_StorageCapacityQuotaGiB { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_StorageCapacityReservationGiB
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of storage in gibibytes (GiB) to reserve from the parent volume.
        /// Setting <code>StorageCapacityReservationGiB</code> guarantees that the specified amount
        /// of storage space on the parent volume will always be available for the volume. You
        /// can't reserve more storage than the parent volume has. To <i>not</i> specify a storage
        /// capacity reservation, set this to <code>0</code> or <code>-1</code>. For more information,
        /// see <a href="https://docs.aws.amazon.com/fsx/latest/OpenZFSGuide/managing-volumes.html#volume-properties">Volume
        /// properties</a> in the <i>Amazon FSx for OpenZFS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_StorageCapacityReservationGiB { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_StorageEfficiencyEnabled
        /// <summary>
        /// <para>
        /// <para>Set to true to enable deduplication, compression, and compaction storage efficiency
        /// features on the volume.</para>
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
        
        #region Parameter VolumeType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of volume to create; <code>ONTAP</code> and <code>OPENZFS</code>
        /// are the only valid volume types.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FSx.VolumeType")]
        public Amazon.FSx.VolumeType VolumeType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Volume'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateVolumeResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateVolumeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Volume";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXVolume (CreateVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateVolumeResponse, NewFSXVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OntapConfiguration_JunctionPath = this.OntapConfiguration_JunctionPath;
            context.OntapConfiguration_SecurityStyle = this.OntapConfiguration_SecurityStyle;
            context.OntapConfiguration_SizeInMegabyte = this.OntapConfiguration_SizeInMegabyte;
            context.OntapConfiguration_StorageEfficiencyEnabled = this.OntapConfiguration_StorageEfficiencyEnabled;
            context.OntapConfiguration_StorageVirtualMachineId = this.OntapConfiguration_StorageVirtualMachineId;
            context.TieringPolicy_CoolingPeriod = this.TieringPolicy_CoolingPeriod;
            context.TieringPolicy_Name = this.TieringPolicy_Name;
            context.OpenZFSConfiguration_CopyTagsToSnapshot = this.OpenZFSConfiguration_CopyTagsToSnapshot;
            context.OpenZFSConfiguration_DataCompressionType = this.OpenZFSConfiguration_DataCompressionType;
            if (this.OpenZFSConfiguration_NfsExport != null)
            {
                context.OpenZFSConfiguration_NfsExport = new List<Amazon.FSx.Model.OpenZFSNfsExport>(this.OpenZFSConfiguration_NfsExport);
            }
            context.OriginSnapshot_CopyStrategy = this.OriginSnapshot_CopyStrategy;
            context.OriginSnapshot_SnapshotARN = this.OriginSnapshot_SnapshotARN;
            context.OpenZFSConfiguration_ParentVolumeId = this.OpenZFSConfiguration_ParentVolumeId;
            context.OpenZFSConfiguration_ReadOnly = this.OpenZFSConfiguration_ReadOnly;
            context.OpenZFSConfiguration_RecordSizeKiB = this.OpenZFSConfiguration_RecordSizeKiB;
            context.OpenZFSConfiguration_StorageCapacityQuotaGiB = this.OpenZFSConfiguration_StorageCapacityQuotaGiB;
            context.OpenZFSConfiguration_StorageCapacityReservationGiB = this.OpenZFSConfiguration_StorageCapacityReservationGiB;
            if (this.OpenZFSConfiguration_UserAndGroupQuota != null)
            {
                context.OpenZFSConfiguration_UserAndGroupQuota = new List<Amazon.FSx.Model.OpenZFSUserOrGroupQuota>(this.OpenZFSConfiguration_UserAndGroupQuota);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
            }
            context.VolumeType = this.VolumeType;
            #if MODULAR
            if (this.VolumeType == null && ParameterWasBound(nameof(this.VolumeType)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FSx.Model.CreateVolumeRequest();
            
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
             // determine if request.OntapConfiguration should be set to null
            if (requestOntapConfigurationIsNull)
            {
                request.OntapConfiguration = null;
            }
            
             // populate OpenZFSConfiguration
            var requestOpenZFSConfigurationIsNull = true;
            request.OpenZFSConfiguration = new Amazon.FSx.Model.CreateOpenZFSVolumeConfiguration();
            System.Boolean? requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToSnapshot = null;
            if (cmdletContext.OpenZFSConfiguration_CopyTagsToSnapshot != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToSnapshot = cmdletContext.OpenZFSConfiguration_CopyTagsToSnapshot.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToSnapshot != null)
            {
                request.OpenZFSConfiguration.CopyTagsToSnapshots = requestOpenZFSConfiguration_openZFSConfiguration_CopyTagsToSnapshot.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
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
            System.String requestOpenZFSConfiguration_openZFSConfiguration_ParentVolumeId = null;
            if (cmdletContext.OpenZFSConfiguration_ParentVolumeId != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_ParentVolumeId = cmdletContext.OpenZFSConfiguration_ParentVolumeId;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_ParentVolumeId != null)
            {
                request.OpenZFSConfiguration.ParentVolumeId = requestOpenZFSConfiguration_openZFSConfiguration_ParentVolumeId;
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
            Amazon.FSx.Model.CreateOpenZFSOriginSnapshotConfiguration requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot = null;
            
             // populate OriginSnapshot
            var requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshotIsNull = true;
            requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot = new Amazon.FSx.Model.CreateOpenZFSOriginSnapshotConfiguration();
            Amazon.FSx.OpenZFSCopyStrategy requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot_originSnapshot_CopyStrategy = null;
            if (cmdletContext.OriginSnapshot_CopyStrategy != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot_originSnapshot_CopyStrategy = cmdletContext.OriginSnapshot_CopyStrategy;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot_originSnapshot_CopyStrategy != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot.CopyStrategy = requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot_originSnapshot_CopyStrategy;
                requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshotIsNull = false;
            }
            System.String requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot_originSnapshot_SnapshotARN = null;
            if (cmdletContext.OriginSnapshot_SnapshotARN != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot_originSnapshot_SnapshotARN = cmdletContext.OriginSnapshot_SnapshotARN;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot_originSnapshot_SnapshotARN != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot.SnapshotARN = requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot_originSnapshot_SnapshotARN;
                requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshotIsNull = false;
            }
             // determine if requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot should be set to null
            if (requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshotIsNull)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot = null;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot != null)
            {
                request.OpenZFSConfiguration.OriginSnapshot = requestOpenZFSConfiguration_openZFSConfiguration_OriginSnapshot;
                requestOpenZFSConfigurationIsNull = false;
            }
             // determine if request.OpenZFSConfiguration should be set to null
            if (requestOpenZFSConfigurationIsNull)
            {
                request.OpenZFSConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VolumeType != null)
            {
                request.VolumeType = cmdletContext.VolumeType;
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
        
        private Amazon.FSx.Model.CreateVolumeResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateVolume");
            try
            {
                #if DESKTOP
                return client.CreateVolume(request);
                #elif CORECLR
                return client.CreateVolumeAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String OntapConfiguration_JunctionPath { get; set; }
            public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
            public System.Int32? OntapConfiguration_SizeInMegabyte { get; set; }
            public System.Boolean? OntapConfiguration_StorageEfficiencyEnabled { get; set; }
            public System.String OntapConfiguration_StorageVirtualMachineId { get; set; }
            public System.Int32? TieringPolicy_CoolingPeriod { get; set; }
            public Amazon.FSx.TieringPolicyName TieringPolicy_Name { get; set; }
            public System.Boolean? OpenZFSConfiguration_CopyTagsToSnapshot { get; set; }
            public Amazon.FSx.OpenZFSDataCompressionType OpenZFSConfiguration_DataCompressionType { get; set; }
            public List<Amazon.FSx.Model.OpenZFSNfsExport> OpenZFSConfiguration_NfsExport { get; set; }
            public Amazon.FSx.OpenZFSCopyStrategy OriginSnapshot_CopyStrategy { get; set; }
            public System.String OriginSnapshot_SnapshotARN { get; set; }
            public System.String OpenZFSConfiguration_ParentVolumeId { get; set; }
            public System.Boolean? OpenZFSConfiguration_ReadOnly { get; set; }
            public System.Int32? OpenZFSConfiguration_RecordSizeKiB { get; set; }
            public System.Int32? OpenZFSConfiguration_StorageCapacityQuotaGiB { get; set; }
            public System.Int32? OpenZFSConfiguration_StorageCapacityReservationGiB { get; set; }
            public List<Amazon.FSx.Model.OpenZFSUserOrGroupQuota> OpenZFSConfiguration_UserAndGroupQuota { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public Amazon.FSx.VolumeType VolumeType { get; set; }
            public System.Func<Amazon.FSx.Model.CreateVolumeResponse, NewFSXVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Volume;
        }
        
    }
}
