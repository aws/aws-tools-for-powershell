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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Attempts to merge the source commit of a pull request into the specified destination
    /// branch for that pull request at the specified commit using the squash merge strategy.
    /// If the merge is successful, it closes the pull request.
    /// </summary>
    [Cmdlet("Merge", "CCPullRequestBySquash", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.PullRequest")]
    [AWSCmdlet("Calls the AWS CodeCommit MergePullRequestBySquash API operation.", Operation = new[] {"MergePullRequestBySquash"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.MergePullRequestBySquashResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.PullRequest or Amazon.CodeCommit.Model.MergePullRequestBySquashResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.PullRequest object.",
        "The service call response (type Amazon.CodeCommit.Model.MergePullRequestBySquashResponse) can be returned by specifying '-Select *'."
    )]
    public partial class MergeCCPullRequestBySquashCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
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
        
        #region Parameter CommitMessage
        /// <summary>
        /// <para>
        /// <para>The commit message to include in the commit information for the merge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommitMessage { get; set; }
        #endregion
        
        #region Parameter ConflictDetailLevel
        /// <summary>
        /// <para>
        /// <para>The level of conflict detail to use. If unspecified, the default FILE_LEVEL is used,
        /// which returns a not-mergeable result if the same file has differences in both branches.
        /// If LINE_LEVEL is specified, a conflict is considered not mergeable if the same file
        /// in both branches has differences on the same line.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeCommit.ConflictDetailLevelTypeEnum")]
        public Amazon.CodeCommit.ConflictDetailLevelTypeEnum ConflictDetailLevel { get; set; }
        #endregion
        
        #region Parameter ConflictResolutionStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies which branch to use when resolving conflicts, or whether to attempt automatically
        /// merging two versions of a file. The default is NONE, which requires any conflicts
        /// to be resolved manually before the merge operation is successful.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeCommit.ConflictResolutionStrategyTypeEnum")]
        public Amazon.CodeCommit.ConflictResolutionStrategyTypeEnum ConflictResolutionStrategy { get; set; }
        #endregion
        
        #region Parameter ConflictResolution_DeleteFile
        /// <summary>
        /// <para>
        /// <para>Files to be deleted as part of the merge conflict resolution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConflictResolution_DeleteFiles")]
        public Amazon.CodeCommit.Model.DeleteFileEntry[] ConflictResolution_DeleteFile { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address of the person merging the branches. This information is used in
        /// the commit information for the merge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter KeepEmptyFolder
        /// <summary>
        /// <para>
        /// <para>If the commit contains deletions, whether to keep a folder or folder structure if
        /// the changes leave the folders empty. If true, a .gitkeep file is created for empty
        /// folders. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeepEmptyFolders")]
        public System.Boolean? KeepEmptyFolder { get; set; }
        #endregion
        
        #region Parameter PullRequestId
        /// <summary>
        /// <para>
        /// <para>The system-generated ID of the pull request. To get this ID, use <a>ListPullRequests</a>.</para>
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
        public System.String PullRequestId { get; set; }
        #endregion
        
        #region Parameter ConflictResolution_ReplaceContent
        /// <summary>
        /// <para>
        /// <para>Files to have content replaced as part of the merge conflict resolution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConflictResolution_ReplaceContents")]
        public Amazon.CodeCommit.Model.ReplaceContentEntry[] ConflictResolution_ReplaceContent { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where the pull request was created.</para>
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
        
        #region Parameter ConflictResolution_SetFileMode
        /// <summary>
        /// <para>
        /// <para>File modes that are set as part of the merge conflict resolution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConflictResolution_SetFileModes")]
        public Amazon.CodeCommit.Model.SetFileModeEntry[] ConflictResolution_SetFileMode { get; set; }
        #endregion
        
        #region Parameter SourceCommitId
        /// <summary>
        /// <para>
        /// <para>The full commit ID of the original or updated commit in the pull request source branch.
        /// Pass this value if you want an exception thrown if the current commit ID of the tip
        /// of the source branch does not match this commit ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceCommitId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PullRequest'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.MergePullRequestBySquashResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.MergePullRequestBySquashResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PullRequest";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Merge-CCPullRequestBySquash (MergePullRequestBySquash)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.MergePullRequestBySquashResponse, MergeCCPullRequestBySquashCmdlet>(Select) ??
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
            context.AuthorName = this.AuthorName;
            context.CommitMessage = this.CommitMessage;
            context.ConflictDetailLevel = this.ConflictDetailLevel;
            if (this.ConflictResolution_DeleteFile != null)
            {
                context.ConflictResolution_DeleteFile = new List<Amazon.CodeCommit.Model.DeleteFileEntry>(this.ConflictResolution_DeleteFile);
            }
            if (this.ConflictResolution_ReplaceContent != null)
            {
                context.ConflictResolution_ReplaceContent = new List<Amazon.CodeCommit.Model.ReplaceContentEntry>(this.ConflictResolution_ReplaceContent);
            }
            if (this.ConflictResolution_SetFileMode != null)
            {
                context.ConflictResolution_SetFileMode = new List<Amazon.CodeCommit.Model.SetFileModeEntry>(this.ConflictResolution_SetFileMode);
            }
            context.ConflictResolutionStrategy = this.ConflictResolutionStrategy;
            context.Email = this.Email;
            context.KeepEmptyFolder = this.KeepEmptyFolder;
            context.PullRequestId = this.PullRequestId;
            #if MODULAR
            if (this.PullRequestId == null && ParameterWasBound(nameof(this.PullRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter PullRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceCommitId = this.SourceCommitId;
            
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
            var request = new Amazon.CodeCommit.Model.MergePullRequestBySquashRequest();
            
            if (cmdletContext.AuthorName != null)
            {
                request.AuthorName = cmdletContext.AuthorName;
            }
            if (cmdletContext.CommitMessage != null)
            {
                request.CommitMessage = cmdletContext.CommitMessage;
            }
            if (cmdletContext.ConflictDetailLevel != null)
            {
                request.ConflictDetailLevel = cmdletContext.ConflictDetailLevel;
            }
            
             // populate ConflictResolution
            var requestConflictResolutionIsNull = true;
            request.ConflictResolution = new Amazon.CodeCommit.Model.ConflictResolution();
            List<Amazon.CodeCommit.Model.DeleteFileEntry> requestConflictResolution_conflictResolution_DeleteFile = null;
            if (cmdletContext.ConflictResolution_DeleteFile != null)
            {
                requestConflictResolution_conflictResolution_DeleteFile = cmdletContext.ConflictResolution_DeleteFile;
            }
            if (requestConflictResolution_conflictResolution_DeleteFile != null)
            {
                request.ConflictResolution.DeleteFiles = requestConflictResolution_conflictResolution_DeleteFile;
                requestConflictResolutionIsNull = false;
            }
            List<Amazon.CodeCommit.Model.ReplaceContentEntry> requestConflictResolution_conflictResolution_ReplaceContent = null;
            if (cmdletContext.ConflictResolution_ReplaceContent != null)
            {
                requestConflictResolution_conflictResolution_ReplaceContent = cmdletContext.ConflictResolution_ReplaceContent;
            }
            if (requestConflictResolution_conflictResolution_ReplaceContent != null)
            {
                request.ConflictResolution.ReplaceContents = requestConflictResolution_conflictResolution_ReplaceContent;
                requestConflictResolutionIsNull = false;
            }
            List<Amazon.CodeCommit.Model.SetFileModeEntry> requestConflictResolution_conflictResolution_SetFileMode = null;
            if (cmdletContext.ConflictResolution_SetFileMode != null)
            {
                requestConflictResolution_conflictResolution_SetFileMode = cmdletContext.ConflictResolution_SetFileMode;
            }
            if (requestConflictResolution_conflictResolution_SetFileMode != null)
            {
                request.ConflictResolution.SetFileModes = requestConflictResolution_conflictResolution_SetFileMode;
                requestConflictResolutionIsNull = false;
            }
             // determine if request.ConflictResolution should be set to null
            if (requestConflictResolutionIsNull)
            {
                request.ConflictResolution = null;
            }
            if (cmdletContext.ConflictResolutionStrategy != null)
            {
                request.ConflictResolutionStrategy = cmdletContext.ConflictResolutionStrategy;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.KeepEmptyFolder != null)
            {
                request.KeepEmptyFolders = cmdletContext.KeepEmptyFolder.Value;
            }
            if (cmdletContext.PullRequestId != null)
            {
                request.PullRequestId = cmdletContext.PullRequestId;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            if (cmdletContext.SourceCommitId != null)
            {
                request.SourceCommitId = cmdletContext.SourceCommitId;
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
        
        private Amazon.CodeCommit.Model.MergePullRequestBySquashResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.MergePullRequestBySquashRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "MergePullRequestBySquash");
            try
            {
                #if DESKTOP
                return client.MergePullRequestBySquash(request);
                #elif CORECLR
                return client.MergePullRequestBySquashAsync(request).GetAwaiter().GetResult();
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
            public System.String CommitMessage { get; set; }
            public Amazon.CodeCommit.ConflictDetailLevelTypeEnum ConflictDetailLevel { get; set; }
            public List<Amazon.CodeCommit.Model.DeleteFileEntry> ConflictResolution_DeleteFile { get; set; }
            public List<Amazon.CodeCommit.Model.ReplaceContentEntry> ConflictResolution_ReplaceContent { get; set; }
            public List<Amazon.CodeCommit.Model.SetFileModeEntry> ConflictResolution_SetFileMode { get; set; }
            public Amazon.CodeCommit.ConflictResolutionStrategyTypeEnum ConflictResolutionStrategy { get; set; }
            public System.String Email { get; set; }
            public System.Boolean? KeepEmptyFolder { get; set; }
            public System.String PullRequestId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.String SourceCommitId { get; set; }
            public System.Func<Amazon.CodeCommit.Model.MergePullRequestBySquashResponse, MergeCCPullRequestBySquashCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PullRequest;
        }
        
    }
}
