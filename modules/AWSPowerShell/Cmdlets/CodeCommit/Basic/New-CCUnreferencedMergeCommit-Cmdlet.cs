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
    /// Creates an unreferenced commit that represents the result of merging two branches
    /// using a specified merge strategy. This can help you determine the outcome of a potential
    /// merge. This API cannot be used with the fast-forward merge strategy because that strategy
    /// does not create a merge commit.
    /// 
    ///  <note><para>
    /// This unreferenced merge commit can only be accessed using the GetCommit API or through
    /// git commands such as git fetch. To retrieve this commit, you must specify its commit
    /// ID or otherwise reference it.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CCUnreferencedMergeCommit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitResponse")]
    [AWSCmdlet("Calls the AWS CodeCommit CreateUnreferencedMergeCommit API operation.", Operation = new[] {"CreateUnreferencedMergeCommit"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCCUnreferencedMergeCommitCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorName
        /// <summary>
        /// <para>
        /// <para>The name of the author who created the unreferenced commit. This information is used
        /// as both the author and committer for the commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorName { get; set; }
        #endregion
        
        #region Parameter CommitMessage
        /// <summary>
        /// <para>
        /// <para>The commit message for the unreferenced commit.</para>
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
        
        #region Parameter DestinationCommitSpecifier
        /// <summary>
        /// <para>
        /// <para>The branch, tag, HEAD, or other fully qualified reference used to identify a commit
        /// (for example, a branch name or a full commit ID).</para>
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
        public System.String DestinationCommitSpecifier { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address for the person who created the unreferenced commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter KeepEmptyFolder
        /// <summary>
        /// <para>
        /// <para>If the commit contains deletions, whether to keep a folder or folder structure if
        /// the changes leave the folders empty. If this is specified as true, a .gitkeep file
        /// is created for empty folders. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeepEmptyFolders")]
        public System.Boolean? KeepEmptyFolder { get; set; }
        #endregion
        
        #region Parameter MergeOption
        /// <summary>
        /// <para>
        /// <para>The merge option or strategy you want to use to merge the code.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeCommit.MergeOptionTypeEnum")]
        public Amazon.CodeCommit.MergeOptionTypeEnum MergeOption { get; set; }
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
        /// <para>The name of the repository where you want to create the unreferenced merge commit.</para>
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
        
        #region Parameter SourceCommitSpecifier
        /// <summary>
        /// <para>
        /// <para>The branch, tag, HEAD, or other fully qualified reference used to identify a commit
        /// (for example, a branch name or a full commit ID).</para>
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
        public System.String SourceCommitSpecifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RepositoryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCUnreferencedMergeCommit (CreateUnreferencedMergeCommit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitResponse, NewCCUnreferencedMergeCommitCmdlet>(Select) ??
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
            context.DestinationCommitSpecifier = this.DestinationCommitSpecifier;
            #if MODULAR
            if (this.DestinationCommitSpecifier == null && ParameterWasBound(nameof(this.DestinationCommitSpecifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationCommitSpecifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Email = this.Email;
            context.KeepEmptyFolder = this.KeepEmptyFolder;
            context.MergeOption = this.MergeOption;
            #if MODULAR
            if (this.MergeOption == null && ParameterWasBound(nameof(this.MergeOption)))
            {
                WriteWarning("You are passing $null as a value for parameter MergeOption which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceCommitSpecifier = this.SourceCommitSpecifier;
            #if MODULAR
            if (this.SourceCommitSpecifier == null && ParameterWasBound(nameof(this.SourceCommitSpecifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceCommitSpecifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitRequest();
            
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
            if (cmdletContext.DestinationCommitSpecifier != null)
            {
                request.DestinationCommitSpecifier = cmdletContext.DestinationCommitSpecifier;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.KeepEmptyFolder != null)
            {
                request.KeepEmptyFolders = cmdletContext.KeepEmptyFolder.Value;
            }
            if (cmdletContext.MergeOption != null)
            {
                request.MergeOption = cmdletContext.MergeOption;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            if (cmdletContext.SourceCommitSpecifier != null)
            {
                request.SourceCommitSpecifier = cmdletContext.SourceCommitSpecifier;
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
        
        private Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "CreateUnreferencedMergeCommit");
            try
            {
                #if DESKTOP
                return client.CreateUnreferencedMergeCommit(request);
                #elif CORECLR
                return client.CreateUnreferencedMergeCommitAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationCommitSpecifier { get; set; }
            public System.String Email { get; set; }
            public System.Boolean? KeepEmptyFolder { get; set; }
            public Amazon.CodeCommit.MergeOptionTypeEnum MergeOption { get; set; }
            public System.String RepositoryName { get; set; }
            public System.String SourceCommitSpecifier { get; set; }
            public System.Func<Amazon.CodeCommit.Model.CreateUnreferencedMergeCommitResponse, NewCCUnreferencedMergeCommitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
