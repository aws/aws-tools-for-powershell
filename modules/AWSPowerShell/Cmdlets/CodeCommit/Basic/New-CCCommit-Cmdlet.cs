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
    /// Creates a commit for a repository on the tip of a specified branch.
    /// </summary>
    [Cmdlet("New", "CCCommit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.CreateCommitResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit CreateCommit API operation.", Operation = new[] {"CreateCommit"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.CreateCommitResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.CreateCommitResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.CreateCommitResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCCCommitCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthorName
        /// <summary>
        /// <para>
        /// <para>The name of the author who created the commit. This information is used as both the
        /// author and committer for the commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorName { get; set; }
        #endregion
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para>The name of the branch where you create the commit.</para>
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
        /// <para>The commit message you want to include in the commit. Commit messages are limited
        /// to 256 KB. If no message is specified, a default message is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommitMessage { get; set; }
        #endregion
        
        #region Parameter DeleteFile
        /// <summary>
        /// <para>
        /// <para>The files to delete in this commit. These files still exist in earlier commits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteFiles")]
        public Amazon.CodeCommit.Model.DeleteFileEntry[] DeleteFile { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address of the person who created the commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter KeepEmptyFolder
        /// <summary>
        /// <para>
        /// <para>If the commit contains deletions, whether to keep a folder or folder structure if
        /// the changes leave the folders empty. If true, a ..gitkeep file is created for empty
        /// folders. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeepEmptyFolders")]
        public System.Boolean? KeepEmptyFolder { get; set; }
        #endregion
        
        #region Parameter ParentCommitId
        /// <summary>
        /// <para>
        /// <para>The ID of the commit that is the parent of the commit you create. Not required if
        /// this is an empty repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentCommitId { get; set; }
        #endregion
        
        #region Parameter PutFile
        /// <summary>
        /// <para>
        /// <para>The files to add or update in this commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PutFiles")]
        public Amazon.CodeCommit.Model.PutFileEntry[] PutFile { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where you create the commit.</para>
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
        
        #region Parameter SetFileMode
        /// <summary>
        /// <para>
        /// <para>The file modes to update for files in this commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SetFileModes")]
        public Amazon.CodeCommit.Model.SetFileModeEntry[] SetFileMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.CreateCommitResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.CreateCommitResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RepositoryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCCommit (CreateCommit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.CreateCommitResponse, NewCCCommitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthorName = this.AuthorName;
            context.BranchName = this.BranchName;
            #if MODULAR
            if (this.BranchName == null && ParameterWasBound(nameof(this.BranchName)))
            {
                WriteWarning("You are passing $null as a value for parameter BranchName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CommitMessage = this.CommitMessage;
            if (this.DeleteFile != null)
            {
                context.DeleteFile = new List<Amazon.CodeCommit.Model.DeleteFileEntry>(this.DeleteFile);
            }
            context.Email = this.Email;
            context.KeepEmptyFolder = this.KeepEmptyFolder;
            context.ParentCommitId = this.ParentCommitId;
            if (this.PutFile != null)
            {
                context.PutFile = new List<Amazon.CodeCommit.Model.PutFileEntry>(this.PutFile);
            }
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SetFileMode != null)
            {
                context.SetFileMode = new List<Amazon.CodeCommit.Model.SetFileModeEntry>(this.SetFileMode);
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
            var request = new Amazon.CodeCommit.Model.CreateCommitRequest();
            
            if (cmdletContext.AuthorName != null)
            {
                request.AuthorName = cmdletContext.AuthorName;
            }
            if (cmdletContext.BranchName != null)
            {
                request.BranchName = cmdletContext.BranchName;
            }
            if (cmdletContext.CommitMessage != null)
            {
                request.CommitMessage = cmdletContext.CommitMessage;
            }
            if (cmdletContext.DeleteFile != null)
            {
                request.DeleteFiles = cmdletContext.DeleteFile;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.KeepEmptyFolder != null)
            {
                request.KeepEmptyFolders = cmdletContext.KeepEmptyFolder.Value;
            }
            if (cmdletContext.ParentCommitId != null)
            {
                request.ParentCommitId = cmdletContext.ParentCommitId;
            }
            if (cmdletContext.PutFile != null)
            {
                request.PutFiles = cmdletContext.PutFile;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            if (cmdletContext.SetFileMode != null)
            {
                request.SetFileModes = cmdletContext.SetFileMode;
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
        
        private Amazon.CodeCommit.Model.CreateCommitResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.CreateCommitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "CreateCommit");
            try
            {
                #if DESKTOP
                return client.CreateCommit(request);
                #elif CORECLR
                return client.CreateCommitAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthorName { get; set; }
            public System.String BranchName { get; set; }
            public System.String CommitMessage { get; set; }
            public List<Amazon.CodeCommit.Model.DeleteFileEntry> DeleteFile { get; set; }
            public System.String Email { get; set; }
            public System.Boolean? KeepEmptyFolder { get; set; }
            public System.String ParentCommitId { get; set; }
            public List<Amazon.CodeCommit.Model.PutFileEntry> PutFile { get; set; }
            public System.String RepositoryName { get; set; }
            public List<Amazon.CodeCommit.Model.SetFileModeEntry> SetFileMode { get; set; }
            public System.Func<Amazon.CodeCommit.Model.CreateCommitResponse, NewCCCommitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
