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
    /// For Amazon FSx for Windows File Server file systems, you can update the following
    /// properties:
    /// </para><ul><li><para><code>AuditLogConfiguration</code></para></li><li><para><code>AutomaticBackupRetentionDays</code></para></li><li><para><code>DailyAutomaticBackupStartTime</code></para></li><li><para><code>SelfManagedActiveDirectoryConfiguration</code></para></li><li><para><code>StorageCapacity</code></para></li><li><para><code>ThroughputCapacity</code></para></li><li><para><code>WeeklyMaintenanceStartTime</code></para></li></ul><para>
    /// For Amazon FSx for Lustre file systems, you can update the following properties:
    /// </para><ul><li><para><code>AutoImportPolicy</code></para></li><li><para><code>AutomaticBackupRetentionDays</code></para></li><li><para><code>DailyAutomaticBackupStartTime</code></para></li><li><para><code>DataCompressionType</code></para></li><li><para><code>StorageCapacity</code></para></li><li><para><code>WeeklyMaintenanceStartTime</code></para></li></ul><para>
    /// For Amazon FSx for NetApp ONTAP file systems, you can update the following properties:
    /// </para><ul><li><para><code>AutomaticBackupRetentionDays</code></para></li><li><para><code>DailyAutomaticBackupStartTime</code></para></li><li><para><code>DiskIopsConfiguration</code></para></li><li><para><code>FsxAdminPassword</code></para></li><li><para><code>StorageCapacity</code></para></li><li><para><code>WeeklyMaintenanceStartTime</code></para></li></ul><para>
    /// For the Amazon FSx for OpenZFS file systems, you can update the following properties:
    /// </para><ul><li><para><code>AutomaticBackupRetentionDays</code></para></li><li><para><code>CopyTagsToBackups</code></para></li><li><para><code>CopyTagsToVolumes</code></para></li><li><para><code>DailyAutomaticBackupStartTime</code></para></li><li><para><code>ThroughputCapacity</code></para></li><li><para><code>WeeklyMaintenanceStartTime</code></para></li></ul>
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
        /// <para>A string of up to 64 ASCII characters that Amazon FSx uses to ensure idempotent updates.
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
        /// user doesn't specify tags. If this value is <code>true</code> and you specify one
        /// or more tags, only the specified tags are copied to backups. If you specify one or
        /// more tags when creating a user-initiated backup, no tags are copied from the file
        /// system, regardless of this value. </para>
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
        /// This value defaults to <code>false</code>. If it's set to <code>true</code>, all tags
        /// for the volume are copied to snapshots where the user doesn't specify tags. If this
        /// value is <code>true</code> and you specify one or more tags, only the specified tags
        /// are copied to snapshots. If you specify one or more tags when creating the snapshot,
        /// no tags are copied from the volume, regardless of this value. </para>
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
        /// <para>The ONTAP administrative password for the <code>fsxadmin</code> user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_FsxAdminPassword { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_DiskIopsConfiguration_Iops
        /// <summary>
        /// <para>
        /// <para>The total number of SSD IOPS provisioned for the file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OntapConfiguration_DiskIopsConfiguration_Iops { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_DiskIopsConfiguration_Iops
        /// <summary>
        /// <para>
        /// <para>The total number of SSD IOPS provisioned for the file system.</para>
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
        /// <para>Specifies whether the number of IOPS for the file system is using the system default
        /// (<code>AUTOMATIC</code>) or was provisioned by the customer (<code>USER_PROVISIONED</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.DiskIopsConfigurationMode")]
        public Amazon.FSx.DiskIopsConfigurationMode OntapConfiguration_DiskIopsConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_DiskIopsConfiguration_Mode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the number of IOPS for the file system is using the system default
        /// (<code>AUTOMATIC</code>) or was provisioned by the customer (<code>USER_PROVISIONED</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.DiskIopsConfigurationMode")]
        public Amazon.FSx.DiskIopsConfigurationMode OpenZFSConfiguration_DiskIopsConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>Use this parameter to increase the storage capacity of an Amazon FSx for Windows File
        /// Server, Amazon FSx for Lustre, or Amazon FSx for NetApp ONTAP file system. Specifies
        /// the storage capacity target value, in GiB, to increase the storage capacity for the
        /// file system that you're updating. </para><note><para>You can't make a storage capacity increase request if there is an existing storage
        /// capacity increase request in progress.</para></note><para>For Windows file systems, the storage capacity target value must be at least 10 percent
        /// greater than the current storage capacity value. To increase storage capacity, the
        /// file system must have at least 16 MBps of throughput capacity. For more information,
        /// see <a href="https://docs.aws.amazon.com/fsx/latest/WindowsGuide/managing-storage-capacity.html">Managing
        /// storage capacity</a> in the <i>Amazon FSx for Windows File Server User Guide</i>.</para><para>For Lustre file systems, the storage capacity target value can be the following:</para><ul><li><para>For <code>SCRATCH_2</code>, <code>PERSISTENT_1</code>, and <code>PERSISTENT_2 SSD</code>
        /// deployment types, valid values are in multiples of 2400 GiB. The value must be greater
        /// than the current storage capacity.</para></li><li><para>For <code>PERSISTENT HDD</code> file systems, valid values are multiples of 6000 GiB
        /// for 12-MBps throughput per TiB file systems and multiples of 1800 GiB for 40-MBps
        /// throughput per TiB file systems. The values must be greater than the current storage
        /// capacity.</para></li><li><para>For <code>SCRATCH_1</code> file systems, you can't increase the storage capacity.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/managing-storage-capacity.html">Managing
        /// storage and throughput capacity</a> in the <i>Amazon FSx for Lustre User Guide</i>.</para><para>For ONTAP file systems, the storage capacity target value must be at least 10 percent
        /// greater than the current storage capacity value. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-storage-capacity.html">Managing
        /// storage capacity and provisioned IOPS</a> in the <i>Amazon FSx for NetApp ONTAP User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_ThroughputCapacity
        /// <summary>
        /// <para>
        /// <para>The throughput of an Amazon FSx file system, measured in megabytes per second (MBps),
        /// in 2 to the nth increments, between 2^3 (8) and 2^12 (4096). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OpenZFSConfiguration_ThroughputCapacity { get; set; }
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
            context.OntapConfiguration_AutomaticBackupRetentionDay = this.OntapConfiguration_AutomaticBackupRetentionDay;
            context.OntapConfiguration_DailyAutomaticBackupStartTime = this.OntapConfiguration_DailyAutomaticBackupStartTime;
            context.OntapConfiguration_DiskIopsConfiguration_Iops = this.OntapConfiguration_DiskIopsConfiguration_Iops;
            context.OntapConfiguration_DiskIopsConfiguration_Mode = this.OntapConfiguration_DiskIopsConfiguration_Mode;
            context.OntapConfiguration_FsxAdminPassword = this.OntapConfiguration_FsxAdminPassword;
            context.OntapConfiguration_WeeklyMaintenanceStartTime = this.OntapConfiguration_WeeklyMaintenanceStartTime;
            context.OpenZFSConfiguration_AutomaticBackupRetentionDay = this.OpenZFSConfiguration_AutomaticBackupRetentionDay;
            context.OpenZFSConfiguration_CopyTagsToBackup = this.OpenZFSConfiguration_CopyTagsToBackup;
            context.OpenZFSConfiguration_CopyTagsToVolume = this.OpenZFSConfiguration_CopyTagsToVolume;
            context.OpenZFSConfiguration_DailyAutomaticBackupStartTime = this.OpenZFSConfiguration_DailyAutomaticBackupStartTime;
            context.OpenZFSConfiguration_DiskIopsConfiguration_Iops = this.OpenZFSConfiguration_DiskIopsConfiguration_Iops;
            context.OpenZFSConfiguration_DiskIopsConfiguration_Mode = this.OpenZFSConfiguration_DiskIopsConfiguration_Mode;
            context.OpenZFSConfiguration_ThroughputCapacity = this.OpenZFSConfiguration_ThroughputCapacity;
            context.OpenZFSConfiguration_WeeklyMaintenanceStartTime = this.OpenZFSConfiguration_WeeklyMaintenanceStartTime;
            context.StorageCapacity = this.StorageCapacity;
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
            public System.Int32? OntapConfiguration_AutomaticBackupRetentionDay { get; set; }
            public System.String OntapConfiguration_DailyAutomaticBackupStartTime { get; set; }
            public System.Int64? OntapConfiguration_DiskIopsConfiguration_Iops { get; set; }
            public Amazon.FSx.DiskIopsConfigurationMode OntapConfiguration_DiskIopsConfiguration_Mode { get; set; }
            public System.String OntapConfiguration_FsxAdminPassword { get; set; }
            public System.String OntapConfiguration_WeeklyMaintenanceStartTime { get; set; }
            public System.Int32? OpenZFSConfiguration_AutomaticBackupRetentionDay { get; set; }
            public System.Boolean? OpenZFSConfiguration_CopyTagsToBackup { get; set; }
            public System.Boolean? OpenZFSConfiguration_CopyTagsToVolume { get; set; }
            public System.String OpenZFSConfiguration_DailyAutomaticBackupStartTime { get; set; }
            public System.Int64? OpenZFSConfiguration_DiskIopsConfiguration_Iops { get; set; }
            public Amazon.FSx.DiskIopsConfigurationMode OpenZFSConfiguration_DiskIopsConfiguration_Mode { get; set; }
            public System.Int32? OpenZFSConfiguration_ThroughputCapacity { get; set; }
            public System.String OpenZFSConfiguration_WeeklyMaintenanceStartTime { get; set; }
            public System.Int32? StorageCapacity { get; set; }
            public Amazon.FSx.Model.UpdateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateFileSystemResponse, UpdateFSXFileSystemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileSystem;
        }
        
    }
}
