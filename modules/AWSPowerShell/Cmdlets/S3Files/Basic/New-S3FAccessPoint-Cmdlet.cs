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
using Amazon.S3Files;
using Amazon.S3Files.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3F
{
    /// <summary>
    /// Creates an S3 File System Access Point for application-specific access with POSIX
    /// user identity and root directory enforcement. Access points provide a way to manage
    /// access to shared datasets in multi-tenant scenarios.
    /// </summary>
    [Cmdlet("New", "S3FAccessPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Files.Model.CreateAccessPointResponse")]
    [AWSCmdlet("Calls the Amazon S3 Files CreateAccessPoint API operation.", Operation = new[] {"CreateAccessPoint"}, SelectReturnType = typeof(Amazon.S3Files.Model.CreateAccessPointResponse))]
    [AWSCmdletOutput("Amazon.S3Files.Model.CreateAccessPointResponse",
        "This cmdlet returns an Amazon.S3Files.Model.CreateAccessPointResponse object containing multiple properties."
    )]
    public partial class NewS3FAccessPointCmdlet : AmazonS3FilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID or Amazon Resource Name (ARN) of the S3 File System.</para>
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
        /// <para>The POSIX group ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PosixUser_Gid { get; set; }
        #endregion
        
        #region Parameter RootDirectory_CreationPermissions_OwnerGid
        /// <summary>
        /// <para>
        /// <para>The POSIX group ID to assign to newly created directories.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? RootDirectory_CreationPermissions_OwnerGid { get; set; }
        #endregion
        
        #region Parameter RootDirectory_CreationPermissions_OwnerUid
        /// <summary>
        /// <para>
        /// <para>The POSIX user ID to assign to newly created directories.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? RootDirectory_CreationPermissions_OwnerUid { get; set; }
        #endregion
        
        #region Parameter RootDirectory_Path
        /// <summary>
        /// <para>
        /// <para>The path to use as the root directory for the access point.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RootDirectory_Path { get; set; }
        #endregion
        
        #region Parameter RootDirectory_CreationPermissions_Permission
        /// <summary>
        /// <para>
        /// <para>The octal permissions to assign to newly created directories.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RootDirectory_CreationPermissions_Permissions")]
        public System.String RootDirectory_CreationPermissions_Permission { get; set; }
        #endregion
        
        #region Parameter PosixUser_SecondaryGid
        /// <summary>
        /// <para>
        /// <para>An array of secondary POSIX group IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PosixUser_SecondaryGids")]
        public System.Int64[] PosixUser_SecondaryGid { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs to apply to the access point for resource tagging.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.S3Files.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter PosixUser_Uid
        /// <summary>
        /// <para>
        /// <para>The POSIX user ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PosixUser_Uid { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, Amazon Web Services ignores
        /// the request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Files.Model.CreateAccessPointResponse).
        /// Specifying the name of a property of type Amazon.S3Files.Model.CreateAccessPointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3FAccessPoint (CreateAccessPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Files.Model.CreateAccessPointResponse, NewS3FAccessPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.RootDirectory_CreationPermissions_OwnerGid = this.RootDirectory_CreationPermissions_OwnerGid;
            context.RootDirectory_CreationPermissions_OwnerUid = this.RootDirectory_CreationPermissions_OwnerUid;
            context.RootDirectory_CreationPermissions_Permission = this.RootDirectory_CreationPermissions_Permission;
            context.RootDirectory_Path = this.RootDirectory_Path;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.S3Files.Model.Tag>(this.Tag);
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
            var request = new Amazon.S3Files.Model.CreateAccessPointRequest();
            
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
            request.PosixUser = new Amazon.S3Files.Model.PosixUser();
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
            request.RootDirectory = new Amazon.S3Files.Model.RootDirectory();
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
            Amazon.S3Files.Model.CreationPermissions requestRootDirectory_rootDirectory_CreationPermissions = null;
            
             // populate CreationPermissions
            var requestRootDirectory_rootDirectory_CreationPermissionsIsNull = true;
            requestRootDirectory_rootDirectory_CreationPermissions = new Amazon.S3Files.Model.CreationPermissions();
            System.Int64? requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_OwnerGid = null;
            if (cmdletContext.RootDirectory_CreationPermissions_OwnerGid != null)
            {
                requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_OwnerGid = cmdletContext.RootDirectory_CreationPermissions_OwnerGid.Value;
            }
            if (requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_OwnerGid != null)
            {
                requestRootDirectory_rootDirectory_CreationPermissions.OwnerGid = requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_OwnerGid.Value;
                requestRootDirectory_rootDirectory_CreationPermissionsIsNull = false;
            }
            System.Int64? requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_OwnerUid = null;
            if (cmdletContext.RootDirectory_CreationPermissions_OwnerUid != null)
            {
                requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_OwnerUid = cmdletContext.RootDirectory_CreationPermissions_OwnerUid.Value;
            }
            if (requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_OwnerUid != null)
            {
                requestRootDirectory_rootDirectory_CreationPermissions.OwnerUid = requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_OwnerUid.Value;
                requestRootDirectory_rootDirectory_CreationPermissionsIsNull = false;
            }
            System.String requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_Permission = null;
            if (cmdletContext.RootDirectory_CreationPermissions_Permission != null)
            {
                requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_Permission = cmdletContext.RootDirectory_CreationPermissions_Permission;
            }
            if (requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_Permission != null)
            {
                requestRootDirectory_rootDirectory_CreationPermissions.Permissions = requestRootDirectory_rootDirectory_CreationPermissions_rootDirectory_CreationPermissions_Permission;
                requestRootDirectory_rootDirectory_CreationPermissionsIsNull = false;
            }
             // determine if requestRootDirectory_rootDirectory_CreationPermissions should be set to null
            if (requestRootDirectory_rootDirectory_CreationPermissionsIsNull)
            {
                requestRootDirectory_rootDirectory_CreationPermissions = null;
            }
            if (requestRootDirectory_rootDirectory_CreationPermissions != null)
            {
                request.RootDirectory.CreationPermissions = requestRootDirectory_rootDirectory_CreationPermissions;
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
        
        private Amazon.S3Files.Model.CreateAccessPointResponse CallAWSServiceOperation(IAmazonS3Files client, Amazon.S3Files.Model.CreateAccessPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Files", "CreateAccessPoint");
            try
            {
                return client.CreateAccessPointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? RootDirectory_CreationPermissions_OwnerGid { get; set; }
            public System.Int64? RootDirectory_CreationPermissions_OwnerUid { get; set; }
            public System.String RootDirectory_CreationPermissions_Permission { get; set; }
            public System.String RootDirectory_Path { get; set; }
            public List<Amazon.S3Files.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.S3Files.Model.CreateAccessPointResponse, NewS3FAccessPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
