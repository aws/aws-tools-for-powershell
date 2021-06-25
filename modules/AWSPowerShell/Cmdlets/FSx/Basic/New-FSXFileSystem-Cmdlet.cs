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
    /// Creates a new, empty Amazon FSx file system.
    /// 
    ///  
    /// <para>
    /// If a file system with the specified client request token exists and the parameters
    /// match, <code>CreateFileSystem</code> returns the description of the existing file
    /// system. If a file system specified client request token exists and the parameters
    /// don't match, this call returns <code>IncompatibleParameterError</code>. If a file
    /// system with the specified client request token doesn't exist, <code>CreateFileSystem</code>
    /// does the following: 
    /// </para><ul><li><para>
    /// Creates a new, empty Amazon FSx file system with an assigned ID, and an initial lifecycle
    /// state of <code>CREATING</code>.
    /// </para></li><li><para>
    /// Returns the description of the file system.
    /// </para></li></ul><para>
    /// This operation requires a client request token in the request that Amazon FSx uses
    /// to ensure idempotent creation. This means that calling the operation multiple times
    /// with the same client request token has no effect. By using the idempotent operation,
    /// you can retry a <code>CreateFileSystem</code> operation without the risk of creating
    /// an extra file system. This approach can be useful when an initial call fails in a
    /// way that makes it unclear whether a file system was created. Examples are if a transport
    /// level timeout occurred, or your connection was reset. If you use the same client request
    /// token and the initial call created a file system, the client receives success as long
    /// as the parameters are the same.
    /// </para><note><para>
    /// The <code>CreateFileSystem</code> call returns while the file system's lifecycle state
    /// is still <code>CREATING</code>. You can check the file-system creation status by calling
    /// the <a>DescribeFileSystems</a> operation, which returns the file system state along
    /// with other information.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "FSXFileSystem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.FileSystem")]
    [AWSCmdlet("Calls the Amazon FSx CreateFileSystem API operation.", Operation = new[] {"CreateFileSystem"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateFileSystemResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.FileSystem or Amazon.FSx.Model.CreateFileSystemResponse",
        "This cmdlet returns an Amazon.FSx.Model.FileSystem object.",
        "The service call response (type Amazon.FSx.Model.CreateFileSystemResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFSXFileSystemCmdlet : AmazonFSxClientCmdlet, IExecutor
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
        
        #region Parameter OntapConfiguration_DailyAutomaticBackupStartTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_DailyAutomaticBackupStartTime { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_DeploymentType
        /// <summary>
        /// <para>
        /// <para>Specifies the ONTAP file system deployment type to use in creating the file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.OntapDeploymentType")]
        public Amazon.FSx.OntapDeploymentType OntapConfiguration_DeploymentType { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_EndpointIpAddressRange
        /// <summary>
        /// <para>
        /// <para>Specifies the IP address range in which the endpoints to access your file system will
        /// be created. By default, Amazon FSx selects an unused IP address range for you from
        /// the 198.19.* range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_EndpointIpAddressRange { get; set; }
        #endregion
        
        #region Parameter FileSystemType
        /// <summary>
        /// <para>
        /// <para>The type of Amazon FSx file system to create. Valid values are <code>WINDOWS</code>,
        /// <code>LUSTRE</code>, and <code>ONTAP</code>.</para>
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
        
        #region Parameter OntapConfiguration_FsxAdminPassword
        /// <summary>
        /// <para>
        /// <para>The ONTAP administrative password for the <code>fsxadmin</code> user that you can
        /// use to administer your file system using the ONTAP CLI and REST API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_FsxAdminPassword { get; set; }
        #endregion
        
        #region Parameter DiskIopsConfiguration_Iops
        /// <summary>
        /// <para>
        /// <para>The total number of SSD IOPS provisioned for the file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_DiskIopsConfiguration_Iops")]
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
        [Alias("OntapConfiguration_DiskIopsConfiguration_Mode")]
        [AWSConstantClassSource("Amazon.FSx.DiskIopsConfigurationMode")]
        public Amazon.FSx.DiskIopsConfigurationMode DiskIopsConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_PreferredSubnetId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OntapConfiguration_PreferredSubnetId { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_RouteTableId
        /// <summary>
        /// <para>
        /// <para>Specifies the VPC route tables in which your file system's endpoints will be created.
        /// You should specify all VPC route tables associated with the subnets in which your
        /// clients are located. By default, Amazon FSx selects your VPC's default route table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OntapConfiguration_RouteTableIds")]
        public System.String[] OntapConfiguration_RouteTableId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of IDs specifying the security groups to apply to all network interfaces created
        /// for file system access. This list isn't returned in later requests to describe the
        /// file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter StorageCapacity
        /// <summary>
        /// <para>
        /// <para>Sets the storage capacity of the file system that you're creating.</para><para>For Lustre file systems:</para><ul><li><para>For <code>SCRATCH_2</code> and <code>PERSISTENT_1 SSD</code> deployment types, valid
        /// values are 1200 GiB, 2400 GiB, and increments of 2400 GiB.</para></li><li><para>For <code>PERSISTENT HDD</code> file systems, valid values are increments of 6000
        /// GiB for 12 MB/s/TiB file systems and increments of 1800 GiB for 40 MB/s/TiB file systems.</para></li><li><para>For <code>SCRATCH_1</code> deployment type, valid values are 1200 GiB, 2400 GiB, and
        /// increments of 3600 GiB.</para></li></ul><para>For Windows file systems:</para><ul><li><para>If <code>StorageType=SSD</code>, valid values are 32 GiB - 65,536 GiB (64 TiB).</para></li><li><para>If <code>StorageType=HDD</code>, valid values are 2000 GiB - 65,536 GiB (64 TiB).</para></li></ul><para>For ONTAP file systems:</para><ul><li><para>Valid values are 1024 GiB - 196,608 GiB (192 TiB).</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? StorageCapacity { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Sets the storage type for the file system you're creating. Valid values are <code>SSD</code>
        /// and <code>HDD</code>.</para><ul><li><para>Set to <code>SSD</code> to use solid state drive storage. SSD is supported on all
        /// Windows, Lustre, and ONTAP deployment types.</para></li><li><para>Set to <code>HDD</code> to use hard disk drive storage. HDD is supported on <code>SINGLE_AZ_2</code>
        /// and <code>MULTI_AZ_1</code> Windows file system deployment types, and on <code>PERSISTENT</code>
        /// Lustre file system deployment types. </para></li></ul><para> Default value is <code>SSD</code>. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/WindowsGuide/optimize-fsx-costs.html#storage-type-options">
        /// Storage Type Options</a> in the <i>Amazon FSx for Windows User Guide</i> and <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/what-is.html#storage-options">Multiple
        /// Storage Options</a> in the <i>Amazon FSx for Lustre User Guide</i>. </para>
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
        /// Windows and ONTAP <code>MULTI_AZ_1</code> file system deployment types, provide exactly
        /// two subnet IDs, one for the preferred file server and one for the standby file server.
        /// You specify one of these subnets as the preferred subnet using the <code>WindowsConfiguration
        /// &gt; PreferredSubnetID</code> or <code>OntapConfiguration &gt; PreferredSubnetID</code>
        /// properties. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/WindowsGuide/high-availability-multiAZ.html">
        /// Availability and durability: Single-AZ and Multi-AZ file systems</a> in the <i>Amazon
        /// FSx for Windows User Guide</i> and <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/high-availability-multiAZ.html">
        /// Availability and durability</a> in the <i>Amazon FSx for ONTAP User Guide</i>.</para><para>For Windows <code>SINGLE_AZ_1</code> and <code>SINGLE_AZ_2</code> file system deployment
        /// types and Lustre file systems, provide exactly one subnet ID. The file server is launched
        /// in that subnet's Availability Zone.</para>
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
        /// <para>The tags to apply to the file system being created. The key value of the <code>Name</code>
        /// tag appears in the console as the file system name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter OntapConfiguration_ThroughputCapacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OntapConfiguration_ThroughputCapacity { get; set; }
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
        
        #region Parameter WindowsConfiguration
        /// <summary>
        /// <para>
        /// <para>The Microsoft Windows configuration for the file system being created. </para>
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
            context.KmsKeyId = this.KmsKeyId;
            context.LustreConfiguration = this.LustreConfiguration;
            context.OntapConfiguration_AutomaticBackupRetentionDay = this.OntapConfiguration_AutomaticBackupRetentionDay;
            context.OntapConfiguration_DailyAutomaticBackupStartTime = this.OntapConfiguration_DailyAutomaticBackupStartTime;
            context.OntapConfiguration_DeploymentType = this.OntapConfiguration_DeploymentType;
            context.DiskIopsConfiguration_Iops = this.DiskIopsConfiguration_Iops;
            context.DiskIopsConfiguration_Mode = this.DiskIopsConfiguration_Mode;
            context.OntapConfiguration_EndpointIpAddressRange = this.OntapConfiguration_EndpointIpAddressRange;
            context.OntapConfiguration_FsxAdminPassword = this.OntapConfiguration_FsxAdminPassword;
            context.OntapConfiguration_PreferredSubnetId = this.OntapConfiguration_PreferredSubnetId;
            if (this.OntapConfiguration_RouteTableId != null)
            {
                context.OntapConfiguration_RouteTableId = new List<System.String>(this.OntapConfiguration_RouteTableId);
            }
            context.OntapConfiguration_ThroughputCapacity = this.OntapConfiguration_ThroughputCapacity;
            context.OntapConfiguration_WeeklyMaintenanceStartTime = this.OntapConfiguration_WeeklyMaintenanceStartTime;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.StorageCapacity = this.StorageCapacity;
            #if MODULAR
            if (this.StorageCapacity == null && ParameterWasBound(nameof(this.StorageCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LustreConfiguration != null)
            {
                request.LustreConfiguration = cmdletContext.LustreConfiguration;
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
            System.Int64? requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Iops = null;
            if (cmdletContext.DiskIopsConfiguration_Iops != null)
            {
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Iops = cmdletContext.DiskIopsConfiguration_Iops.Value;
            }
            if (requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Iops != null)
            {
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration.Iops = requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Iops.Value;
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfigurationIsNull = false;
            }
            Amazon.FSx.DiskIopsConfigurationMode requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Mode = null;
            if (cmdletContext.DiskIopsConfiguration_Mode != null)
            {
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Mode = cmdletContext.DiskIopsConfiguration_Mode;
            }
            if (requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Mode != null)
            {
                requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration.Mode = requestOntapConfiguration_ontapConfiguration_DiskIopsConfiguration_diskIopsConfiguration_Mode;
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
                #if DESKTOP
                return client.CreateFileSystem(request);
                #elif CORECLR
                return client.CreateFileSystemAsync(request).GetAwaiter().GetResult();
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
            public Amazon.FSx.FileSystemType FileSystemType { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.FSx.Model.CreateFileSystemLustreConfiguration LustreConfiguration { get; set; }
            public System.Int32? OntapConfiguration_AutomaticBackupRetentionDay { get; set; }
            public System.String OntapConfiguration_DailyAutomaticBackupStartTime { get; set; }
            public Amazon.FSx.OntapDeploymentType OntapConfiguration_DeploymentType { get; set; }
            public System.Int64? DiskIopsConfiguration_Iops { get; set; }
            public Amazon.FSx.DiskIopsConfigurationMode DiskIopsConfiguration_Mode { get; set; }
            public System.String OntapConfiguration_EndpointIpAddressRange { get; set; }
            public System.String OntapConfiguration_FsxAdminPassword { get; set; }
            public System.String OntapConfiguration_PreferredSubnetId { get; set; }
            public List<System.String> OntapConfiguration_RouteTableId { get; set; }
            public System.Int32? OntapConfiguration_ThroughputCapacity { get; set; }
            public System.String OntapConfiguration_WeeklyMaintenanceStartTime { get; set; }
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
