/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS CodeCommit CreateCommit API operation.", Operation = new[] {"CreateCommit"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.CreateCommitResponse",
        "This cmdlet returns a Amazon.CodeCommit.Model.CreateCommitResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCCCommitCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorName
        /// <summary>
        /// <para>
        /// <para>The name of the author who created the commit. This information will be used as both
        /// the author and committer for the commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthorName { get; set; }
        #endregion
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para>The name of the branch where you will create the commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BranchName { get; set; }
        #endregion
        
        #region Parameter CommitMessage
        /// <summary>
        /// <para>
        /// <para>The commit message you want to include as part of creating the commit. Commit messages
        /// are limited to 256 KB. If no message is specified, a default message will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CommitMessage { get; set; }
        #endregion
        
        #region Parameter DeleteFile
        /// <summary>
        /// <para>
        /// <para>The files to delete in this commit. These files will still exist in prior commits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DeleteFiles")]
        public Amazon.CodeCommit.Model.DeleteFileEntry[] DeleteFile { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address of the person who created the commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter KeepEmptyFolder
        /// <summary>
        /// <para>
        /// <para>If the commit contains deletions, whether to keep a folder or folder structure if
        /// the changes leave the folders empty. If this is specified as true, a .gitkeep file
        /// will be created for empty folders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("KeepEmptyFolders")]
        public System.Boolean KeepEmptyFolder { get; set; }
        #endregion
        
        #region Parameter ParentCommitId
        /// <summary>
        /// <para>
        /// <para>The ID of the commit that is the parent of the commit you will create. If this is
        /// an empty repository, this is not required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ParentCommitId { get; set; }
        #endregion
        
        #region Parameter PutFile
        /// <summary>
        /// <para>
        /// <para>The files to add or update in this commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PutFiles")]
        public Amazon.CodeCommit.Model.PutFileEntry[] PutFile { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where you will create the commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter SetFileMode
        /// <summary>
        /// <para>
        /// <para>The file modes to update for files in this commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SetFileModes")]
        public Amazon.CodeCommit.Model.SetFileModeEntry[] SetFileMode { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RepositoryName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCCommit (CreateCommit)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AuthorName = this.AuthorName;
            context.BranchName = this.BranchName;
            context.CommitMessage = this.CommitMessage;
            if (this.DeleteFile != null)
            {
                context.DeleteFiles = new List<Amazon.CodeCommit.Model.DeleteFileEntry>(this.DeleteFile);
            }
            context.Email = this.Email;
            if (ParameterWasBound("KeepEmptyFolder"))
                context.KeepEmptyFolders = this.KeepEmptyFolder;
            context.ParentCommitId = this.ParentCommitId;
            if (this.PutFile != null)
            {
                context.PutFiles = new List<Amazon.CodeCommit.Model.PutFileEntry>(this.PutFile);
            }
            context.RepositoryName = this.RepositoryName;
            if (this.SetFileMode != null)
            {
                context.SetFileModes = new List<Amazon.CodeCommit.Model.SetFileModeEntry>(this.SetFileMode);
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
            if (cmdletContext.DeleteFiles != null)
            {
                request.DeleteFiles = cmdletContext.DeleteFiles;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.KeepEmptyFolders != null)
            {
                request.KeepEmptyFolders = cmdletContext.KeepEmptyFolders.Value;
            }
            if (cmdletContext.ParentCommitId != null)
            {
                request.ParentCommitId = cmdletContext.ParentCommitId;
            }
            if (cmdletContext.PutFiles != null)
            {
                request.PutFiles = cmdletContext.PutFiles;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            if (cmdletContext.SetFileModes != null)
            {
                request.SetFileModes = cmdletContext.SetFileModes;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            public List<Amazon.CodeCommit.Model.DeleteFileEntry> DeleteFiles { get; set; }
            public System.String Email { get; set; }
            public System.Boolean? KeepEmptyFolders { get; set; }
            public System.String ParentCommitId { get; set; }
            public List<Amazon.CodeCommit.Model.PutFileEntry> PutFiles { get; set; }
            public System.String RepositoryName { get; set; }
            public List<Amazon.CodeCommit.Model.SetFileModeEntry> SetFileModes { get; set; }
        }
        
    }
}
