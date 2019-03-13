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
    /// Deletes a specified file from a specified branch. A commit is created on the branch
    /// that contains the revision. The file will still exist in the commits prior to the
    /// commit that contains the deletion.
    /// </summary>
    [Cmdlet("Remove", "CCFile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.CodeCommit.Model.DeleteFileResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit DeleteFile API operation.", Operation = new[] {"DeleteFile"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.DeleteFileResponse",
        "This cmdlet returns a Amazon.CodeCommit.Model.DeleteFileResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCCFileCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para>The name of the branch where the commit will be made deleting the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BranchName { get; set; }
        #endregion
        
        #region Parameter CommitMessage
        /// <summary>
        /// <para>
        /// <para>The commit message you want to include as part of deleting the file. Commit messages
        /// are limited to 256 KB. If no message is specified, a default message will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CommitMessage { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address for the commit that deletes the file. If no email address is specified,
        /// the email address will be left blank.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter FilePath
        /// <summary>
        /// <para>
        /// <para>The fully-qualified path to the file that will be deleted, including the full name
        /// and extension of that file. For example, /examples/file.md is a fully qualified path
        /// to a file named file.md in a folder named examples.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FilePath { get; set; }
        #endregion
        
        #region Parameter KeepEmptyFolder
        /// <summary>
        /// <para>
        /// <para>Specifies whether to delete the folder or directory that contains the file you want
        /// to delete if that file is the only object in the folder or directory. By default,
        /// empty folders will be deleted. This includes empty folders that are part of the directory
        /// structure. For example, if the path to a file is dir1/dir2/dir3/dir4, and dir2 and
        /// dir3 are empty, deleting the last file in dir4 will also delete the empty folders
        /// dir4, dir3, and dir2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("KeepEmptyFolders")]
        public System.Boolean KeepEmptyFolder { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the author of the commit that deletes the file. If no name is specified,
        /// the user's ARN will be used as the author name and committer name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParentCommitId
        /// <summary>
        /// <para>
        /// <para>The ID of the commit that is the tip of the branch where you want to create the commit
        /// that will delete the file. This must be the HEAD commit for the branch. The commit
        /// that deletes the file will be created from this commit ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ParentCommitId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository that contains the file to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RepositoryName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CCFile (DeleteFile)"))
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
            
            context.BranchName = this.BranchName;
            context.CommitMessage = this.CommitMessage;
            context.Email = this.Email;
            context.FilePath = this.FilePath;
            if (ParameterWasBound("KeepEmptyFolder"))
                context.KeepEmptyFolders = this.KeepEmptyFolder;
            context.Name = this.Name;
            context.ParentCommitId = this.ParentCommitId;
            context.RepositoryName = this.RepositoryName;
            
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
            var request = new Amazon.CodeCommit.Model.DeleteFileRequest();
            
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
            if (cmdletContext.FilePath != null)
            {
                request.FilePath = cmdletContext.FilePath;
            }
            if (cmdletContext.KeepEmptyFolders != null)
            {
                request.KeepEmptyFolders = cmdletContext.KeepEmptyFolders.Value;
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
        
        private Amazon.CodeCommit.Model.DeleteFileResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.DeleteFileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "DeleteFile");
            try
            {
                #if DESKTOP
                return client.DeleteFile(request);
                #elif CORECLR
                return client.DeleteFileAsync(request).GetAwaiter().GetResult();
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
            public System.String FilePath { get; set; }
            public System.Boolean? KeepEmptyFolders { get; set; }
            public System.String Name { get; set; }
            public System.String ParentCommitId { get; set; }
            public System.String RepositoryName { get; set; }
        }
        
    }
}
