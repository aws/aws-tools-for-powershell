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
    /// Creates a new Amazon FSx file system from an existing Amazon FSx for Windows File
    /// Server backup.
    /// 
    ///  
    /// <para>
    /// If a file system with the specified client request token exists and the parameters
    /// match, this operation returns the description of the file system. If a client request
    /// token specified by the file system exists and the parameters don't match, this call
    /// returns <code>IncompatibleParameterError</code>. If a file system with the specified
    /// client request token doesn't exist, this operation does the following:
    /// </para><ul><li><para>
    /// Creates a new Amazon FSx file system from backup with an assigned ID, and an initial
    /// lifecycle state of <code>CREATING</code>.
    /// </para></li><li><para>
    /// Returns the description of the file system.
    /// </para></li></ul><para>
    /// Parameters like Active Directory, default share name, automatic backup, and backup
    /// settings default to the parameters of the file system that was backed up, unless overridden.
    /// You can explicitly supply other settings.
    /// </para><para>
    /// By using the idempotent operation, you can retry a <code>CreateFileSystemFromBackup</code>
    /// call without the risk of creating an extra file system. This approach can be useful
    /// when an initial call fails in a way that makes it unclear whether a file system was
    /// created. Examples are if a transport level timeout occurred, or your connection was
    /// reset. If you use the same client request token and the initial call created a file
    /// system, the client receives success as long as the parameters are the same.
    /// </para><note><para>
    /// The <code>CreateFileSystemFromBackup</code> call returns while the file system's lifecycle
    /// state is still <code>CREATING</code>. You can check the file-system creation status
    /// by calling the <a>DescribeFileSystems</a> operation, which returns the file system
    /// state along with other information.
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
        /// <para>(Optional) A string of up to 64 ASCII characters that Amazon FSx uses to ensure idempotent
        /// creation. This string is automatically filled on your behalf when you use the AWS
        /// Command Line Interface (AWS CLI) or an AWS SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of IDs for the security groups that apply to the specified network interfaces
        /// created for file system access. These security groups apply to all network interfaces.
        /// This value isn't returned in later DescribeFileSystem requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Sets the storage type for the Windows file system you're creating from a backup. Valid
        /// values are <code>SSD</code> and <code>HDD</code>.</para><ul><li><para>Set to <code>SSD</code> to use solid state drive storage. Supported on all Windows
        /// deployment types.</para></li><li><para>Set to <code>HDD</code> to use hard disk drive storage. Supported on <code>SINGLE_AZ_2</code>
        /// and <code>MULTI_AZ_1</code> Windows file system deployment types. </para></li></ul><para> Default value is <code>SSD</code>. </para><note><para>HDD and SSD storage types have different minimum storage capacity requirements. A
        /// restored file system's storage capacity is tied to the file system that was backed
        /// up. You can create a file system that uses HDD storage from a backup of a file system
        /// that used SSD storage only if the original SSD file system had a storage capacity
        /// of at least 2000 GiB. </para></note>
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
        /// &gt; PreferredSubnetID</code> property.</para><para>For Windows <code>SINGLE_AZ_1</code> and <code>SINGLE_AZ_2</code> deployment types
        /// and Lustre file systems, provide exactly one subnet ID. The file server is launched
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
        /// <para>The tags to be applied to the file system at file system creation. The key value of
        /// the <code>Name</code> tag appears in the console as the file system name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
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
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
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
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
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
            public List<System.String> SecurityGroupId { get; set; }
            public Amazon.FSx.StorageType StorageType { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public Amazon.FSx.Model.CreateFileSystemWindowsConfiguration WindowsConfiguration { get; set; }
            public System.Func<Amazon.FSx.Model.CreateFileSystemFromBackupResponse, NewFSXFileSystemFromBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileSystem;
        }
        
    }
}
