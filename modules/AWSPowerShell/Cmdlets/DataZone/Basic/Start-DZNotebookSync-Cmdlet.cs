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
using Amazon.DataZone;
using Amazon.DataZone.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Starts a notebook sync in Amazon SageMaker Unified Studio. This operation syncs a
    /// notebook from a Git repository into a project.
    /// </summary>
    [Cmdlet("Start", "DZNotebookSync", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.StartNotebookSyncResponse")]
    [AWSCmdlet("Calls the Amazon DataZone StartNotebookSync API operation.", Operation = new[] {"StartNotebookSync"}, SelectReturnType = typeof(Amazon.DataZone.Model.StartNotebookSyncResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.StartNotebookSyncResponse",
        "This cmdlet returns an Amazon.DataZone.Model.StartNotebookSyncResponse object containing multiple properties."
    )]
    public partial class StartDZNotebookSyncCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GitMetadata_Branch
        /// <summary>
        /// <para>
        /// <para>The name of the Git branch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GitMetadata_Branch { get; set; }
        #endregion
        
        #region Parameter GitMetadata_CommitHash
        /// <summary>
        /// <para>
        /// <para>The commit hash in the Git repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GitMetadata_CommitHash { get; set; }
        #endregion
        
        #region Parameter GitMetadata_CommitMessage
        /// <summary>
        /// <para>
        /// <para>The commit message associated with the Git commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GitMetadata_CommitMessage { get; set; }
        #endregion
        
        #region Parameter GitMetadata_CommittedAt
        /// <summary>
        /// <para>
        /// <para>The timestamp of when the commit was made.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? GitMetadata_CommittedAt { get; set; }
        #endregion
        
        #region Parameter GitMetadata_ConnectionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Git connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GitMetadata_ConnectionId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the notebook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon SageMaker Unified Studio domain in which to sync the
        /// notebook.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter GitMetadata_FileName
        /// <summary>
        /// <para>
        /// <para>The name of the file in the Git repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GitMetadata_FileName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the notebook. The name must be between 1 and 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NotebookId
        /// <summary>
        /// <para>
        /// <para>The identifier of an existing notebook to sync. If not specified, a new notebook is
        /// created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotebookId { get; set; }
        #endregion
        
        #region Parameter OwningProjectIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the project that will own the synced notebook.</para>
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
        public System.String OwningProjectIdentifier { get; set; }
        #endregion
        
        #region Parameter GitMetadata_Repository
        /// <summary>
        /// <para>
        /// <para>The name of the Git repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GitMetadata_Repository { get; set; }
        #endregion
        
        #region Parameter SourceLocation_S3
        /// <summary>
        /// <para>
        /// <para>The Amazon Simple Storage Service URI of the notebook source file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceLocation_S3 { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request. This field
        /// is automatically populated if not provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.StartNotebookSyncResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.StartNotebookSyncResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.DomainIdentifier),
                nameof(this.OwningProjectIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DZNotebookSync (StartNotebookSync)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.StartNotebookSyncResponse, StartDZNotebookSyncCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GitMetadata_Branch = this.GitMetadata_Branch;
            context.GitMetadata_CommitHash = this.GitMetadata_CommitHash;
            context.GitMetadata_CommitMessage = this.GitMetadata_CommitMessage;
            context.GitMetadata_CommittedAt = this.GitMetadata_CommittedAt;
            context.GitMetadata_ConnectionId = this.GitMetadata_ConnectionId;
            context.GitMetadata_FileName = this.GitMetadata_FileName;
            context.GitMetadata_Repository = this.GitMetadata_Repository;
            context.Name = this.Name;
            context.NotebookId = this.NotebookId;
            context.OwningProjectIdentifier = this.OwningProjectIdentifier;
            #if MODULAR
            if (this.OwningProjectIdentifier == null && ParameterWasBound(nameof(this.OwningProjectIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OwningProjectIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceLocation_S3 = this.SourceLocation_S3;
            
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
            var request = new Amazon.DataZone.Model.StartNotebookSyncRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            
             // populate GitMetadata
            var requestGitMetadataIsNull = true;
            request.GitMetadata = new Amazon.DataZone.Model.GitMetadata();
            System.String requestGitMetadata_gitMetadata_Branch = null;
            if (cmdletContext.GitMetadata_Branch != null)
            {
                requestGitMetadata_gitMetadata_Branch = cmdletContext.GitMetadata_Branch;
            }
            if (requestGitMetadata_gitMetadata_Branch != null)
            {
                request.GitMetadata.Branch = requestGitMetadata_gitMetadata_Branch;
                requestGitMetadataIsNull = false;
            }
            System.String requestGitMetadata_gitMetadata_CommitHash = null;
            if (cmdletContext.GitMetadata_CommitHash != null)
            {
                requestGitMetadata_gitMetadata_CommitHash = cmdletContext.GitMetadata_CommitHash;
            }
            if (requestGitMetadata_gitMetadata_CommitHash != null)
            {
                request.GitMetadata.CommitHash = requestGitMetadata_gitMetadata_CommitHash;
                requestGitMetadataIsNull = false;
            }
            System.String requestGitMetadata_gitMetadata_CommitMessage = null;
            if (cmdletContext.GitMetadata_CommitMessage != null)
            {
                requestGitMetadata_gitMetadata_CommitMessage = cmdletContext.GitMetadata_CommitMessage;
            }
            if (requestGitMetadata_gitMetadata_CommitMessage != null)
            {
                request.GitMetadata.CommitMessage = requestGitMetadata_gitMetadata_CommitMessage;
                requestGitMetadataIsNull = false;
            }
            System.DateTime? requestGitMetadata_gitMetadata_CommittedAt = null;
            if (cmdletContext.GitMetadata_CommittedAt != null)
            {
                requestGitMetadata_gitMetadata_CommittedAt = cmdletContext.GitMetadata_CommittedAt.Value;
            }
            if (requestGitMetadata_gitMetadata_CommittedAt != null)
            {
                request.GitMetadata.CommittedAt = requestGitMetadata_gitMetadata_CommittedAt.Value;
                requestGitMetadataIsNull = false;
            }
            System.String requestGitMetadata_gitMetadata_ConnectionId = null;
            if (cmdletContext.GitMetadata_ConnectionId != null)
            {
                requestGitMetadata_gitMetadata_ConnectionId = cmdletContext.GitMetadata_ConnectionId;
            }
            if (requestGitMetadata_gitMetadata_ConnectionId != null)
            {
                request.GitMetadata.ConnectionId = requestGitMetadata_gitMetadata_ConnectionId;
                requestGitMetadataIsNull = false;
            }
            System.String requestGitMetadata_gitMetadata_FileName = null;
            if (cmdletContext.GitMetadata_FileName != null)
            {
                requestGitMetadata_gitMetadata_FileName = cmdletContext.GitMetadata_FileName;
            }
            if (requestGitMetadata_gitMetadata_FileName != null)
            {
                request.GitMetadata.FileName = requestGitMetadata_gitMetadata_FileName;
                requestGitMetadataIsNull = false;
            }
            System.String requestGitMetadata_gitMetadata_Repository = null;
            if (cmdletContext.GitMetadata_Repository != null)
            {
                requestGitMetadata_gitMetadata_Repository = cmdletContext.GitMetadata_Repository;
            }
            if (requestGitMetadata_gitMetadata_Repository != null)
            {
                request.GitMetadata.Repository = requestGitMetadata_gitMetadata_Repository;
                requestGitMetadataIsNull = false;
            }
             // determine if request.GitMetadata should be set to null
            if (requestGitMetadataIsNull)
            {
                request.GitMetadata = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NotebookId != null)
            {
                request.NotebookId = cmdletContext.NotebookId;
            }
            if (cmdletContext.OwningProjectIdentifier != null)
            {
                request.OwningProjectIdentifier = cmdletContext.OwningProjectIdentifier;
            }
            
             // populate SourceLocation
            var requestSourceLocationIsNull = true;
            request.SourceLocation = new Amazon.DataZone.Model.SourceLocation();
            System.String requestSourceLocation_sourceLocation_S3 = null;
            if (cmdletContext.SourceLocation_S3 != null)
            {
                requestSourceLocation_sourceLocation_S3 = cmdletContext.SourceLocation_S3;
            }
            if (requestSourceLocation_sourceLocation_S3 != null)
            {
                request.SourceLocation.S3 = requestSourceLocation_sourceLocation_S3;
                requestSourceLocationIsNull = false;
            }
             // determine if request.SourceLocation should be set to null
            if (requestSourceLocationIsNull)
            {
                request.SourceLocation = null;
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
        
        private Amazon.DataZone.Model.StartNotebookSyncResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.StartNotebookSyncRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "StartNotebookSync");
            try
            {
                return client.StartNotebookSyncAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String GitMetadata_Branch { get; set; }
            public System.String GitMetadata_CommitHash { get; set; }
            public System.String GitMetadata_CommitMessage { get; set; }
            public System.DateTime? GitMetadata_CommittedAt { get; set; }
            public System.String GitMetadata_ConnectionId { get; set; }
            public System.String GitMetadata_FileName { get; set; }
            public System.String GitMetadata_Repository { get; set; }
            public System.String Name { get; set; }
            public System.String NotebookId { get; set; }
            public System.String OwningProjectIdentifier { get; set; }
            public System.String SourceLocation_S3 { get; set; }
            public System.Func<Amazon.DataZone.Model.StartNotebookSyncResponse, StartDZNotebookSyncCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
