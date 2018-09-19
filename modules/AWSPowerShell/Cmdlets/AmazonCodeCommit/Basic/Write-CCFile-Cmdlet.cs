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
    /// Adds or updates a file in a branch in an AWS CodeCommit repository, and generates
    /// a commit for the addition in the specified branch.
    /// </summary>
    [Cmdlet("Write", "CCFile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.PutFileResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit PutFile API operation.", Operation = new[] {"PutFile"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.PutFileResponse",
        "This cmdlet returns a Amazon.CodeCommit.Model.PutFileResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCCFileCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para>The name of the branch where you want to add or update the file. If this is an empty
        /// repository, this branch will be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BranchName { get; set; }
        #endregion
        
        #region Parameter CommitMessage
        /// <summary>
        /// <para>
        /// <para>A message about why this file was added or updated. While optional, adding a message
        /// is strongly encouraged in order to provide a more useful commit history for your repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CommitMessage { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>An email address for the person adding or updating the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter FileContent
        /// <summary>
        /// <para>
        /// <para>The content of the file, in binary object format. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] FileContent { get; set; }
        #endregion
        
        #region Parameter FileMode
        /// <summary>
        /// <para>
        /// <para>The file mode permissions of the blob. Valid file mode permissions are listed below.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeCommit.FileModeTypeEnum")]
        public Amazon.CodeCommit.FileModeTypeEnum FileMode { get; set; }
        #endregion
        
        #region Parameter FilePath
        /// <summary>
        /// <para>
        /// <para>The name of the file you want to add or update, including the relative path to the
        /// file in the repository.</para><note><para>If the path does not currently exist in the repository, the path will be created as
        /// part of adding the file.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FilePath { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the person adding or updating the file. While optional, adding a name
        /// is strongly encouraged in order to provide a more useful commit history for your repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParentCommitId
        /// <summary>
        /// <para>
        /// <para>The full commit ID of the head commit in the branch where you want to add or update
        /// the file. If this is an empty repository, no commit ID is required. If this is not
        /// an empty repository, a commit ID is required. </para><para>The commit ID must match the ID of the head commit at the time of the operation, or
        /// an error will occur, and the file will not be added or updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ParentCommitId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where you want to add or update the file.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CCFile (PutFile)"))
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
            context.FileContent = this.FileContent;
            context.FileMode = this.FileMode;
            context.FilePath = this.FilePath;
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutFileAsync(request);
                return task.Result;
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
        }
        
    }
}
