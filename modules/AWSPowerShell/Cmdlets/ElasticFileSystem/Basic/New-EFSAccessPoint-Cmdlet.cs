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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Creates an EFS access point. An access point is an application-specific view into
    /// an EFS file system that applies an operating system user and group, and a file system
    /// path, to any file system request made through the access point. The operating system
    /// user and group override any identity information provided by the NFS client. The file
    /// system path is exposed as the access point's root directory. Applications using the
    /// access point can only access data in the application's own directory and any subdirectories.
    /// A file system can have a maximum of 10,000 access points unless you request an increase.
    /// To learn more, see <a href="https://docs.aws.amazon.com/efs/latest/ug/efs-access-points.html">Mounting
    /// a file system using EFS access points</a>.
    /// 
    ///  <note><para>
    /// If multiple requests to create access points on the same file system are sent in quick
    /// succession, and the file system is near the limit of access points, you may experience
    /// a throttling response for these requests. This is to ensure that the file system does
    /// not exceed the stated access point limit.
    /// </para></note><para>
    /// This operation requires permissions for the <c>elasticfilesystem:CreateAccessPoint</c>
    /// action.
    /// </para><para>
    /// Access points can be tagged on creation. If tags are specified in the creation action,
    /// IAM performs additional authorization on the <c>elasticfilesystem:TagResource</c>
    /// action to verify if users have permissions to create tags. Therefore, you must grant
    /// explicit permissions to use the <c>elasticfilesystem:TagResource</c> action. For more
    /// information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/using-tags-efs.html#supported-iam-actions-tagging.html">Granting
    /// permissions to tag resources during creation</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EFSAccessPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.CreateAccessPointResponse")]
    [AWSCmdlet("Calls the Amazon Elastic File System CreateAccessPoint API operation.", Operation = new[] {"CreateAccessPoint"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.CreateAccessPointResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.CreateAccessPointResponse",
        "This cmdlet returns an Amazon.ElasticFileSystem.Model.CreateAccessPointResponse object containing multiple properties."
    )]
    public partial class NewEFSAccessPointCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the EFS file system that the access point provides access to.</para>
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
        
        #region Parameter PosixUser_Gid
        /// <summary>
        /// <para>
        /// <para>The POSIX group ID used for all file system operations using this access point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PosixUser_Gid { get; set; }
        #endregion
        
        #region Parameter CreationInfo_OwnerGid
        /// <summary>
        /// <para>
        /// <para>Specifies the POSIX group ID to apply to the <c>RootDirectory</c>. Accepts values
        /// from 0 to 2^32 (4294967295).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RootDirectory_CreationInfo_OwnerGid")]
        public System.Int64? CreationInfo_OwnerGid { get; set; }
        #endregion
        
        #region Parameter CreationInfo_OwnerUid
        /// <summary>
        /// <para>
        /// <para>Specifies the POSIX user ID to apply to the <c>RootDirectory</c>. Accepts values from
        /// 0 to 2^32 (4294967295).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RootDirectory_CreationInfo_OwnerUid")]
        public System.Int64? CreationInfo_OwnerUid { get; set; }
        #endregion
        
        #region Parameter RootDirectory_Path
        /// <summary>
        /// <para>
        /// <para>Specifies the path on the EFS file system to expose as the root directory to NFS clients
        /// using the access point to access the EFS file system. A path can have up to four subdirectories.
        /// If the specified path does not exist, you are required to provide the <c>CreationInfo</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RootDirectory_Path { get; set; }
        #endregion
        
        #region Parameter CreationInfo_Permission
        /// <summary>
        /// <para>
        /// <para>Specifies the POSIX permissions to apply to the <c>RootDirectory</c>, in the format
        /// of an octal number representing the file's mode bits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RootDirectory_CreationInfo_Permissions")]
        public System.String CreationInfo_Permission { get; set; }
        #endregion
        
        #region Parameter PosixUser_SecondaryGid
        /// <summary>
        /// <para>
        /// <para>Secondary POSIX group IDs used for all file system operations using this access point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PosixUser_SecondaryGids")]
        public System.Int64[] PosixUser_SecondaryGid { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Creates tags associated with the access point. Each tag is a key-value pair, each
        /// key must be unique. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a> in the <i>Amazon Web Services General Reference
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticFileSystem.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter PosixUser_Uid
        /// <summary>
        /// <para>
        /// <para>The POSIX user ID used for all file system operations using this access point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PosixUser_Uid { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A string of up to 64 ASCII characters that Amazon EFS uses to ensure idempotent creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.CreateAccessPointResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.CreateAccessPointResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EFSAccessPoint (CreateAccessPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.CreateAccessPointResponse, NewEFSAccessPointCmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PosixUser_Gid = this.PosixUser_Gid;
            if (this.PosixUser_SecondaryGid != null)
            {
                context.PosixUser_SecondaryGid = new List<System.Int64>(this.PosixUser_SecondaryGid);
            }
            context.PosixUser_Uid = this.PosixUser_Uid;
            context.CreationInfo_OwnerGid = this.CreationInfo_OwnerGid;
            context.CreationInfo_OwnerUid = this.CreationInfo_OwnerUid;
            context.CreationInfo_Permission = this.CreationInfo_Permission;
            context.RootDirectory_Path = this.RootDirectory_Path;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticFileSystem.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.ElasticFileSystem.Model.CreateAccessPointRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            
             // populate PosixUser
            var requestPosixUserIsNull = true;
            request.PosixUser = new Amazon.ElasticFileSystem.Model.PosixUser();
            System.Int64? requestPosixUser_posixUser_Gid = null;
            if (cmdletContext.PosixUser_Gid != null)
            {
                requestPosixUser_posixUser_Gid = cmdletContext.PosixUser_Gid.Value;
            }
            if (requestPosixUser_posixUser_Gid != null)
            {
                request.PosixUser.Gid = requestPosixUser_posixUser_Gid.Value;
                requestPosixUserIsNull = false;
            }
            List<System.Int64> requestPosixUser_posixUser_SecondaryGid = null;
            if (cmdletContext.PosixUser_SecondaryGid != null)
            {
                requestPosixUser_posixUser_SecondaryGid = cmdletContext.PosixUser_SecondaryGid;
            }
            if (requestPosixUser_posixUser_SecondaryGid != null)
            {
                request.PosixUser.SecondaryGids = requestPosixUser_posixUser_SecondaryGid;
                requestPosixUserIsNull = false;
            }
            System.Int64? requestPosixUser_posixUser_Uid = null;
            if (cmdletContext.PosixUser_Uid != null)
            {
                requestPosixUser_posixUser_Uid = cmdletContext.PosixUser_Uid.Value;
            }
            if (requestPosixUser_posixUser_Uid != null)
            {
                request.PosixUser.Uid = requestPosixUser_posixUser_Uid.Value;
                requestPosixUserIsNull = false;
            }
             // determine if request.PosixUser should be set to null
            if (requestPosixUserIsNull)
            {
                request.PosixUser = null;
            }
            
             // populate RootDirectory
            var requestRootDirectoryIsNull = true;
            request.RootDirectory = new Amazon.ElasticFileSystem.Model.RootDirectory();
            System.String requestRootDirectory_rootDirectory_Path = null;
            if (cmdletContext.RootDirectory_Path != null)
            {
                requestRootDirectory_rootDirectory_Path = cmdletContext.RootDirectory_Path;
            }
            if (requestRootDirectory_rootDirectory_Path != null)
            {
                request.RootDirectory.Path = requestRootDirectory_rootDirectory_Path;
                requestRootDirectoryIsNull = false;
            }
            Amazon.ElasticFileSystem.Model.CreationInfo requestRootDirectory_rootDirectory_CreationInfo = null;
            
             // populate CreationInfo
            var requestRootDirectory_rootDirectory_CreationInfoIsNull = true;
            requestRootDirectory_rootDirectory_CreationInfo = new Amazon.ElasticFileSystem.Model.CreationInfo();
            System.Int64? requestRootDirectory_rootDirectory_CreationInfo_creationInfo_OwnerGid = null;
            if (cmdletContext.CreationInfo_OwnerGid != null)
            {
                requestRootDirectory_rootDirectory_CreationInfo_creationInfo_OwnerGid = cmdletContext.CreationInfo_OwnerGid.Value;
            }
            if (requestRootDirectory_rootDirectory_CreationInfo_creationInfo_OwnerGid != null)
            {
                requestRootDirectory_rootDirectory_CreationInfo.OwnerGid = requestRootDirectory_rootDirectory_CreationInfo_creationInfo_OwnerGid.Value;
                requestRootDirectory_rootDirectory_CreationInfoIsNull = false;
            }
            System.Int64? requestRootDirectory_rootDirectory_CreationInfo_creationInfo_OwnerUid = null;
            if (cmdletContext.CreationInfo_OwnerUid != null)
            {
                requestRootDirectory_rootDirectory_CreationInfo_creationInfo_OwnerUid = cmdletContext.CreationInfo_OwnerUid.Value;
            }
            if (requestRootDirectory_rootDirectory_CreationInfo_creationInfo_OwnerUid != null)
            {
                requestRootDirectory_rootDirectory_CreationInfo.OwnerUid = requestRootDirectory_rootDirectory_CreationInfo_creationInfo_OwnerUid.Value;
                requestRootDirectory_rootDirectory_CreationInfoIsNull = false;
            }
            System.String requestRootDirectory_rootDirectory_CreationInfo_creationInfo_Permission = null;
            if (cmdletContext.CreationInfo_Permission != null)
            {
                requestRootDirectory_rootDirectory_CreationInfo_creationInfo_Permission = cmdletContext.CreationInfo_Permission;
            }
            if (requestRootDirectory_rootDirectory_CreationInfo_creationInfo_Permission != null)
            {
                requestRootDirectory_rootDirectory_CreationInfo.Permissions = requestRootDirectory_rootDirectory_CreationInfo_creationInfo_Permission;
                requestRootDirectory_rootDirectory_CreationInfoIsNull = false;
            }
             // determine if requestRootDirectory_rootDirectory_CreationInfo should be set to null
            if (requestRootDirectory_rootDirectory_CreationInfoIsNull)
            {
                requestRootDirectory_rootDirectory_CreationInfo = null;
            }
            if (requestRootDirectory_rootDirectory_CreationInfo != null)
            {
                request.RootDirectory.CreationInfo = requestRootDirectory_rootDirectory_CreationInfo;
                requestRootDirectoryIsNull = false;
            }
             // determine if request.RootDirectory should be set to null
            if (requestRootDirectoryIsNull)
            {
                request.RootDirectory = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ElasticFileSystem.Model.CreateAccessPointResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.CreateAccessPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "CreateAccessPoint");
            try
            {
                #if DESKTOP
                return client.CreateAccessPoint(request);
                #elif CORECLR
                return client.CreateAccessPointAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String FileSystemId { get; set; }
            public System.Int64? PosixUser_Gid { get; set; }
            public List<System.Int64> PosixUser_SecondaryGid { get; set; }
            public System.Int64? PosixUser_Uid { get; set; }
            public System.Int64? CreationInfo_OwnerGid { get; set; }
            public System.Int64? CreationInfo_OwnerUid { get; set; }
            public System.String CreationInfo_Permission { get; set; }
            public System.String RootDirectory_Path { get; set; }
            public List<Amazon.ElasticFileSystem.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.CreateAccessPointResponse, NewEFSAccessPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
