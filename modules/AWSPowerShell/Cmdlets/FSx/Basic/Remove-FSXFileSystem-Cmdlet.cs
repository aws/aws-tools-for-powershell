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
    /// Deletes a file system. After deletion, the file system no longer exists, and its data
    /// is gone. Any existing automatic backups and snapshots are also deleted.
    /// 
    ///  
    /// <para>
    /// To delete an Amazon FSx for NetApp ONTAP file system, first delete all the volumes
    /// and storage virtual machines (SVMs) on the file system. Then provide a <c>FileSystemId</c>
    /// value to the <c>DeleteFileSystem</c> operation.
    /// </para><para>
    /// By default, when you delete an Amazon FSx for Windows File Server file system, a final
    /// backup is created upon deletion. This final backup isn't subject to the file system's
    /// retention policy, and must be manually deleted.
    /// </para><para>
    /// To delete an Amazon FSx for Lustre file system, first <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/unmounting-fs.html">unmount</a>
    /// it from every connected Amazon EC2 instance, then provide a <c>FileSystemId</c> value
    /// to the <c>DeleteFileSystem</c> operation. By default, Amazon FSx will not take a final
    /// backup when the <c>DeleteFileSystem</c> operation is invoked. On file systems not
    /// linked to an Amazon S3 bucket, set <c>SkipFinalBackup</c> to <c>false</c> to take
    /// a final backup of the file system you are deleting. Backups cannot be enabled on S3-linked
    /// file systems. To ensure all of your data is written back to S3 before deleting your
    /// file system, you can either monitor for the <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/monitoring-cloudwatch.html#auto-import-export-metrics">AgeOfOldestQueuedMessage</a>
    /// metric to be zero (if using automatic export) or you can run an <a href="https://docs.aws.amazon.com/fsx/latest/LustreGuide/export-data-repo-task-dra.html">export
    /// data repository task</a>. If you have automatic export enabled and want to use an
    /// export data repository task, you have to disable automatic export before executing
    /// the export data repository task.
    /// </para><para>
    /// The <c>DeleteFileSystem</c> operation returns while the file system has the <c>DELETING</c>
    /// status. You can check the file system deletion status by calling the <a href="https://docs.aws.amazon.com/fsx/latest/APIReference/API_DescribeFileSystems.html">DescribeFileSystems</a>
    /// operation, which returns a list of file systems in your account. If you pass the file
    /// system ID for a deleted file system, the <c>DescribeFileSystems</c> operation returns
    /// a <c>FileSystemNotFound</c> error.
    /// </para><note><para>
    /// If a data repository task is in a <c>PENDING</c> or <c>EXECUTING</c> state, deleting
    /// an Amazon FSx for Lustre file system will fail with an HTTP status code 400 (Bad Request).
    /// </para></note><important><para>
    /// The data in a deleted file system is also deleted and can't be recovered by any means.
    /// </para></important>
    /// </summary>
    [Cmdlet("Remove", "FSXFileSystem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.FSx.Model.DeleteFileSystemResponse")]
    [AWSCmdlet("Calls the Amazon FSx DeleteFileSystem API operation.", Operation = new[] {"DeleteFileSystem"}, SelectReturnType = typeof(Amazon.FSx.Model.DeleteFileSystemResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.DeleteFileSystemResponse",
        "This cmdlet returns an Amazon.FSx.Model.DeleteFileSystemResponse object containing multiple properties."
    )]
    public partial class RemoveFSXFileSystemCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A string of up to 63 ASCII characters that Amazon FSx uses to ensure idempotent deletion.
        /// This token is automatically filled on your behalf when using the Command Line Interface
        /// (CLI) or an Amazon Web Services SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the file system that you want to delete.</para>
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
        
        #region Parameter LustreConfiguration_FinalBackupTag
        /// <summary>
        /// <para>
        /// <para>Use if <c>SkipFinalBackup</c> is set to <c>false</c>, and you want to apply an array
        /// of tags to the final backup. If you have set the file system property <c>CopyTagsToBackups</c>
        /// to true, and you specify one or more <c>FinalBackupTags</c> when deleting a file system,
        /// Amazon FSx will not copy any existing file system tags to the backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LustreConfiguration_FinalBackupTags")]
        public Amazon.FSx.Model.Tag[] LustreConfiguration_FinalBackupTag { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_FinalBackupTag
        /// <summary>
        /// <para>
        /// <para>A list of tags to apply to the file system's final backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_FinalBackupTags")]
        public Amazon.FSx.Model.Tag[] OpenZFSConfiguration_FinalBackupTag { get; set; }
        #endregion
        
        #region Parameter WindowsConfiguration_FinalBackupTag
        /// <summary>
        /// <para>
        /// <para>A set of tags for your final backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WindowsConfiguration_FinalBackupTags")]
        public Amazon.FSx.Model.Tag[] WindowsConfiguration_FinalBackupTag { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_Option
        /// <summary>
        /// <para>
        /// <para>To delete a file system if there are child volumes present below the root volume,
        /// use the string <c>DELETE_CHILD_VOLUMES_AND_SNAPSHOTS</c>. If your file system has
        /// child volumes and you don't use this option, the delete request will fail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_Options")]
        public System.String[] OpenZFSConfiguration_Option { get; set; }
        #endregion
        
        #region Parameter LustreConfiguration_SkipFinalBackup
        /// <summary>
        /// <para>
        /// <para>Set <c>SkipFinalBackup</c> to false if you want to take a final backup of the file
        /// system you are deleting. By default, Amazon FSx will not take a final backup on your
        /// behalf when the <c>DeleteFileSystem</c> operation is invoked. (Default = true)</para><note><para>The <c>fsx:CreateBackup</c> permission is required if you set <c>SkipFinalBackup</c>
        /// to <c>false</c> in order to delete the file system and take a final backup.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LustreConfiguration_SkipFinalBackup { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_SkipFinalBackup
        /// <summary>
        /// <para>
        /// <para>By default, Amazon FSx for OpenZFS takes a final backup on your behalf when the <c>DeleteFileSystem</c>
        /// operation is invoked. Doing this helps protect you from data loss, and we highly recommend
        /// taking the final backup. If you want to skip taking a final backup, set this value
        /// to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OpenZFSConfiguration_SkipFinalBackup { get; set; }
        #endregion
        
        #region Parameter WindowsConfiguration_SkipFinalBackup
        /// <summary>
        /// <para>
        /// <para>By default, Amazon FSx for Windows takes a final backup on your behalf when the <c>DeleteFileSystem</c>
        /// operation is invoked. Doing this helps protect you from data loss, and we highly recommend
        /// taking the final backup. If you want to skip this backup, use this flag to do so.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? WindowsConfiguration_SkipFinalBackup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.DeleteFileSystemResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.DeleteFileSystemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-FSXFileSystem (DeleteFileSystem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.DeleteFileSystemResponse, RemoveFSXFileSystemCmdlet>(Select) ??
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
            if (this.LustreConfiguration_FinalBackupTag != null)
            {
                context.LustreConfiguration_FinalBackupTag = new List<Amazon.FSx.Model.Tag>(this.LustreConfiguration_FinalBackupTag);
            }
            context.LustreConfiguration_SkipFinalBackup = this.LustreConfiguration_SkipFinalBackup;
            if (this.OpenZFSConfiguration_FinalBackupTag != null)
            {
                context.OpenZFSConfiguration_FinalBackupTag = new List<Amazon.FSx.Model.Tag>(this.OpenZFSConfiguration_FinalBackupTag);
            }
            if (this.OpenZFSConfiguration_Option != null)
            {
                context.OpenZFSConfiguration_Option = new List<System.String>(this.OpenZFSConfiguration_Option);
            }
            context.OpenZFSConfiguration_SkipFinalBackup = this.OpenZFSConfiguration_SkipFinalBackup;
            if (this.WindowsConfiguration_FinalBackupTag != null)
            {
                context.WindowsConfiguration_FinalBackupTag = new List<Amazon.FSx.Model.Tag>(this.WindowsConfiguration_FinalBackupTag);
            }
            context.WindowsConfiguration_SkipFinalBackup = this.WindowsConfiguration_SkipFinalBackup;
            
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
            var request = new Amazon.FSx.Model.DeleteFileSystemRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            
             // populate LustreConfiguration
            var requestLustreConfigurationIsNull = true;
            request.LustreConfiguration = new Amazon.FSx.Model.DeleteFileSystemLustreConfiguration();
            List<Amazon.FSx.Model.Tag> requestLustreConfiguration_lustreConfiguration_FinalBackupTag = null;
            if (cmdletContext.LustreConfiguration_FinalBackupTag != null)
            {
                requestLustreConfiguration_lustreConfiguration_FinalBackupTag = cmdletContext.LustreConfiguration_FinalBackupTag;
            }
            if (requestLustreConfiguration_lustreConfiguration_FinalBackupTag != null)
            {
                request.LustreConfiguration.FinalBackupTags = requestLustreConfiguration_lustreConfiguration_FinalBackupTag;
                requestLustreConfigurationIsNull = false;
            }
            System.Boolean? requestLustreConfiguration_lustreConfiguration_SkipFinalBackup = null;
            if (cmdletContext.LustreConfiguration_SkipFinalBackup != null)
            {
                requestLustreConfiguration_lustreConfiguration_SkipFinalBackup = cmdletContext.LustreConfiguration_SkipFinalBackup.Value;
            }
            if (requestLustreConfiguration_lustreConfiguration_SkipFinalBackup != null)
            {
                request.LustreConfiguration.SkipFinalBackup = requestLustreConfiguration_lustreConfiguration_SkipFinalBackup.Value;
                requestLustreConfigurationIsNull = false;
            }
             // determine if request.LustreConfiguration should be set to null
            if (requestLustreConfigurationIsNull)
            {
                request.LustreConfiguration = null;
            }
            
             // populate OpenZFSConfiguration
            var requestOpenZFSConfigurationIsNull = true;
            request.OpenZFSConfiguration = new Amazon.FSx.Model.DeleteFileSystemOpenZFSConfiguration();
            List<Amazon.FSx.Model.Tag> requestOpenZFSConfiguration_openZFSConfiguration_FinalBackupTag = null;
            if (cmdletContext.OpenZFSConfiguration_FinalBackupTag != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FinalBackupTag = cmdletContext.OpenZFSConfiguration_FinalBackupTag;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_FinalBackupTag != null)
            {
                request.OpenZFSConfiguration.FinalBackupTags = requestOpenZFSConfiguration_openZFSConfiguration_FinalBackupTag;
                requestOpenZFSConfigurationIsNull = false;
            }
            List<System.String> requestOpenZFSConfiguration_openZFSConfiguration_Option = null;
            if (cmdletContext.OpenZFSConfiguration_Option != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_Option = cmdletContext.OpenZFSConfiguration_Option;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_Option != null)
            {
                request.OpenZFSConfiguration.Options = requestOpenZFSConfiguration_openZFSConfiguration_Option;
                requestOpenZFSConfigurationIsNull = false;
            }
            System.Boolean? requestOpenZFSConfiguration_openZFSConfiguration_SkipFinalBackup = null;
            if (cmdletContext.OpenZFSConfiguration_SkipFinalBackup != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_SkipFinalBackup = cmdletContext.OpenZFSConfiguration_SkipFinalBackup.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_SkipFinalBackup != null)
            {
                request.OpenZFSConfiguration.SkipFinalBackup = requestOpenZFSConfiguration_openZFSConfiguration_SkipFinalBackup.Value;
                requestOpenZFSConfigurationIsNull = false;
            }
             // determine if request.OpenZFSConfiguration should be set to null
            if (requestOpenZFSConfigurationIsNull)
            {
                request.OpenZFSConfiguration = null;
            }
            
             // populate WindowsConfiguration
            var requestWindowsConfigurationIsNull = true;
            request.WindowsConfiguration = new Amazon.FSx.Model.DeleteFileSystemWindowsConfiguration();
            List<Amazon.FSx.Model.Tag> requestWindowsConfiguration_windowsConfiguration_FinalBackupTag = null;
            if (cmdletContext.WindowsConfiguration_FinalBackupTag != null)
            {
                requestWindowsConfiguration_windowsConfiguration_FinalBackupTag = cmdletContext.WindowsConfiguration_FinalBackupTag;
            }
            if (requestWindowsConfiguration_windowsConfiguration_FinalBackupTag != null)
            {
                request.WindowsConfiguration.FinalBackupTags = requestWindowsConfiguration_windowsConfiguration_FinalBackupTag;
                requestWindowsConfigurationIsNull = false;
            }
            System.Boolean? requestWindowsConfiguration_windowsConfiguration_SkipFinalBackup = null;
            if (cmdletContext.WindowsConfiguration_SkipFinalBackup != null)
            {
                requestWindowsConfiguration_windowsConfiguration_SkipFinalBackup = cmdletContext.WindowsConfiguration_SkipFinalBackup.Value;
            }
            if (requestWindowsConfiguration_windowsConfiguration_SkipFinalBackup != null)
            {
                request.WindowsConfiguration.SkipFinalBackup = requestWindowsConfiguration_windowsConfiguration_SkipFinalBackup.Value;
                requestWindowsConfigurationIsNull = false;
            }
             // determine if request.WindowsConfiguration should be set to null
            if (requestWindowsConfigurationIsNull)
            {
                request.WindowsConfiguration = null;
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
        
        private Amazon.FSx.Model.DeleteFileSystemResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.DeleteFileSystemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "DeleteFileSystem");
            try
            {
                #if DESKTOP
                return client.DeleteFileSystem(request);
                #elif CORECLR
                return client.DeleteFileSystemAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.FSx.Model.Tag> LustreConfiguration_FinalBackupTag { get; set; }
            public System.Boolean? LustreConfiguration_SkipFinalBackup { get; set; }
            public List<Amazon.FSx.Model.Tag> OpenZFSConfiguration_FinalBackupTag { get; set; }
            public List<System.String> OpenZFSConfiguration_Option { get; set; }
            public System.Boolean? OpenZFSConfiguration_SkipFinalBackup { get; set; }
            public List<Amazon.FSx.Model.Tag> WindowsConfiguration_FinalBackupTag { get; set; }
            public System.Boolean? WindowsConfiguration_SkipFinalBackup { get; set; }
            public System.Func<Amazon.FSx.Model.DeleteFileSystemResponse, RemoveFSXFileSystemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
