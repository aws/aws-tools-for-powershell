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
    /// Updates the configuration of an Amazon FSx for NetApp ONTAP or Amazon FSx for OpenZFS
    /// volume.
    /// </summary>
    [Cmdlet("Update", "FSXVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.Volume")]
    [AWSCmdlet("Calls the Amazon FSx UpdateVolume API operation.", Operation = new[] {"UpdateVolume"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateVolumeResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.Volume or Amazon.FSx.Model.UpdateVolumeResponse",
        "This cmdlet returns an Amazon.FSx.Model.Volume object.",
        "The service call response (type Amazon.FSx.Model.UpdateVolumeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateFSXVolumeCmdlet : AmazonFSxClientCmdlet, IExecutor
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
        /// is <code>NONE</code> by default.</para><ul><li><para><code>NONE</code> - Doesn't compress the data on the volume. <code>NONE</code> is
        /// the default.</para></li><li><para><code>ZSTD</code> - Compresses the data in the volume using the Zstandard (ZSTD)
        /// compression algorithm. Compared to LZ4, Z-Standard provides a better compression ratio
        /// to minimize on-disk storage utilization.</para></li><li><para><code>LZ4</code> - Compresses the data in the volume using the LZ4 compression algorithm.
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
        /// <para>The name of the OpenZFS volume. OpenZFS root volumes are automatically named <code>FSX</code>.
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
        /// <para>The security style for the volume, which can be <code>UNIX</code>. <code>NTFS</code>,
        /// or <code>MIXED</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.SecurityStyle")]
        public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
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
        /// <para>Specifies the snapshot policy for the volume. There are three built-in snapshot policies:</para><ul><li><para><code>default</code>: This is the default policy. A maximum of six hourly snapshots
        /// taken five minutes past the hour. A maximum of two daily snapshots taken Monday through
        /// Saturday at 10 minutes after midnight. A maximum of two weekly snapshots taken every
        /// Sunday at 15 minutes after midnight.</para></li><li><para><code>default-1weekly</code>: This policy is the same as the <code>default</code>
        /// policy except that it only retains one snapshot from the weekly schedule.</para></li><li><para><code>none</code>: This policy does not take any snapshots. This policy can be assigned
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
        /// can specify a value of <code>-1</code> to unset a volume's storage capacity quota.</para>
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
        /// of <code>-1</code> to unset a volume's storage capacity reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_StorageCapacityReservationGiB { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_StorageEfficiencyEnabled
        /// <summary>
        /// <para>
        /// <para>Default is <code>false</code>. Set to true to enable the deduplication, compression,
        /// and compaction storage efficiency features on the volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OntapConfiguration_StorageEfficiencyEnabled { get; set; }
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
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>The ID of the volume that you want to update, in the format <code>fsvol-0123456789abcdef0</code>.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VolumeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXVolume (UpdateVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateVolumeResponse, UpdateFSXVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VolumeId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.Name = this.Name;
            context.OntapConfiguration_CopyTagsToBackup = this.OntapConfiguration_CopyTagsToBackup;
            context.OntapConfiguration_JunctionPath = this.OntapConfiguration_JunctionPath;
            context.OntapConfiguration_SecurityStyle = this.OntapConfiguration_SecurityStyle;
            context.OntapConfiguration_SizeInMegabyte = this.OntapConfiguration_SizeInMegabyte;
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
                #if DESKTOP
                return client.UpdateVolume(request);
                #elif CORECLR
                return client.UpdateVolumeAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? OntapConfiguration_CopyTagsToBackup { get; set; }
            public System.String OntapConfiguration_JunctionPath { get; set; }
            public Amazon.FSx.SecurityStyle OntapConfiguration_SecurityStyle { get; set; }
            public System.Int32? OntapConfiguration_SizeInMegabyte { get; set; }
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
