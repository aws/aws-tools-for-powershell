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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Adds or updates a file in a branch in an CodeCommit repository, and generates a commit
    /// for the addition in the specified branch.
    /// </summary>
    [Cmdlet("Write", "CCFile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.PutFileResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit PutFile API operation.", Operation = new[] {"PutFile"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.PutFileResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.PutFileResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.PutFileResponse object containing multiple properties."
    )]
    public partial class WriteCCFileCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para>The name of the branch where you want to add or update the file. If this is an empty
        /// repository, this branch is created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BranchName { get; set; }
        #endregion
        
        #region Parameter CommitMessage
        /// <summary>
        /// <para>
        /// <para>A message about why this file was added or updated. Although it is optional, a message
        /// makes the commit history for your repository more useful.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommitMessage { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>An email address for the person adding or updating the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter FileContent
        /// <summary>
        /// <para>
        /// <para>The content of the file, in binary object format. </para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] FileContent { get; set; }
        #endregion
        
        #region Parameter FileMode
        /// <summary>
        /// <para>
        /// <para>The file mode permissions of the blob. Valid file mode permissions are listed here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeCommit.FileModeTypeEnum")]
        public Amazon.CodeCommit.FileModeTypeEnum FileMode { get; set; }
        #endregion
        
        #region Parameter FilePath
        /// <summary>
        /// <para>
        /// <para>The name of the file you want to add or update, including the relative path to the
        /// file in the repository.</para><note><para>If the path does not currently exist in the repository, the path is created as part
        /// of adding the file.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FilePath { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the person adding or updating the file. Although it is optional, a name
        /// makes the commit history for your repository more useful.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParentCommitId
        /// <summary>
        /// <para>
        /// <para>The full commit ID of the head commit in the branch where you want to add or update
        /// the file. If this is an empty repository, no commit ID is required. If this is not
        /// an empty repository, a commit ID is required. </para><para>The commit ID must match the ID of the head commit at the time of the operation. Otherwise,
        /// an error occurs, and the file is not added or updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentCommitId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where you want to add or update the file.</para>
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
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.PutFileResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.PutFileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RepositoryName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RepositoryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CCFile (PutFile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.PutFileResponse, WriteCCFileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RepositoryName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BranchName = this.BranchName;
            #if MODULAR
            if (this.BranchName == null && ParameterWasBound(nameof(this.BranchName)))
            {
                WriteWarning("You are passing $null as a value for parameter BranchName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CommitMessage = this.CommitMessage;
            context.Email = this.Email;
            context.FileContent = this.FileContent;
            #if MODULAR
            if (this.FileContent == null && ParameterWasBound(nameof(this.FileContent)))
            {
                WriteWarning("You are passing $null as a value for parameter FileContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileMode = this.FileMode;
            context.FilePath = this.FilePath;
            #if MODULAR
            if (this.FilePath == null && ParameterWasBound(nameof(this.FilePath)))
            {
                WriteWarning("You are passing $null as a value for parameter FilePath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.ParentCommitId = this.ParentCommitId;
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _FileContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.CodeCommit.Model.PutFileRequest();
                
                if (cmdletContext.BranchName != null)
                {
                    request.BranchName = cmdletContext.BranchName;
                }
                if (cmdletContext.CommitMessage != null)
                {
                    request.CommitMessage = cmdletContext.CommitMessage;
                }
                if (cmdletContext.Email != null)
                {
                    request.Email = cmdletContext.Email;
                }
                if (cmdletContext.FileContent != null)
                {
                    _FileContentStream = new System.IO.MemoryStream(cmdletContext.FileContent);
                    request.FileContent = _FileContentStream;
                }
                if (cmdletContext.FileMode != null)
                {
                    request.FileMode = cmdletContext.FileMode;
                }
                if (cmdletContext.FilePath != null)
                {
                    request.FilePath = cmdletContext.FilePath;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.ParentCommitId != null)
                {
                    request.ParentCommitId = cmdletContext.ParentCommitId;
                }
                if (cmdletContext.RepositoryName != null)
                {
                    request.RepositoryName = cmdletContext.RepositoryName;
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
            finally
            {
                if( _FileContentStream != null)
                {
                    _FileContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CodeCommit.Model.PutFileResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.PutFileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "PutFile");
            try
            {
                #if DESKTOP
                return client.PutFile(request);
                #elif CORECLR
                return client.PutFileAsync(request).GetAwaiter().GetResult();
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
            public System.String BranchName { get; set; }
            public System.String CommitMessage { get; set; }
            public System.String Email { get; set; }
            public byte[] FileContent { get; set; }
            public Amazon.CodeCommit.FileModeTypeEnum FileMode { get; set; }
            public System.String FilePath { get; set; }
            public System.String Name { get; set; }
            public System.String ParentCommitId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.Func<Amazon.CodeCommit.Model.PutFileResponse, WriteCCFileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
