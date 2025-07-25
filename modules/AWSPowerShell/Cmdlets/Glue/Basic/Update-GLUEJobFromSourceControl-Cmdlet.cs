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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Synchronizes a job from the source control repository. This operation takes the job
    /// artifacts that are located in the remote repository and updates the Glue internal
    /// stores with these artifacts.
    /// 
    ///  
    /// <para>
    /// This API supports optional parameters which take in the repository information.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GLUEJobFromSourceControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue UpdateJobFromSourceControl API operation.", Operation = new[] {"UpdateJobFromSourceControl"}, SelectReturnType = typeof(Amazon.Glue.Model.UpdateJobFromSourceControlResponse))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.UpdateJobFromSourceControlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.UpdateJobFromSourceControlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGLUEJobFromSourceControlCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuthStrategy
        /// <summary>
        /// <para>
        /// <para>The type of authentication, which can be an authentication token stored in Amazon
        /// Web Services Secrets Manager, or a personal access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.SourceControlAuthStrategy")]
        public Amazon.Glue.SourceControlAuthStrategy AuthStrategy { get; set; }
        #endregion
        
        #region Parameter AuthToken
        /// <summary>
        /// <para>
        /// <para>The value of the authorization token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthToken { get; set; }
        #endregion
        
        #region Parameter BranchName
        /// <summary>
        /// <para>
        /// <para>An optional branch in the remote repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BranchName { get; set; }
        #endregion
        
        #region Parameter CommitId
        /// <summary>
        /// <para>
        /// <para>A commit ID for a commit in the remote repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommitId { get; set; }
        #endregion
        
        #region Parameter Folder
        /// <summary>
        /// <para>
        /// <para>An optional folder in the remote repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Folder { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the Glue job to be synchronized to or from the remote repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para> The provider for the remote repository. Possible values: GITHUB, AWS_CODE_COMMIT,
        /// GITLAB, BITBUCKET. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.SourceControlProvider")]
        public Amazon.Glue.SourceControlProvider Provider { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the remote repository that contains the job artifacts. For BitBucket providers,
        /// <c>RepositoryName</c> should include <c>WorkspaceName</c>. Use the format <c>&lt;WorkspaceName&gt;/&lt;RepositoryName&gt;</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter RepositoryOwner
        /// <summary>
        /// <para>
        /// <para>The owner of the remote repository that contains the job artifacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RepositoryOwner { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobName'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.UpdateJobFromSourceControlResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.UpdateJobFromSourceControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobName";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GLUEJobFromSourceControl (UpdateJobFromSourceControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.UpdateJobFromSourceControlResponse, UpdateGLUEJobFromSourceControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthStrategy = this.AuthStrategy;
            context.AuthToken = this.AuthToken;
            context.BranchName = this.BranchName;
            context.CommitId = this.CommitId;
            context.Folder = this.Folder;
            context.JobName = this.JobName;
            context.Provider = this.Provider;
            context.RepositoryName = this.RepositoryName;
            context.RepositoryOwner = this.RepositoryOwner;
            
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
            var request = new Amazon.Glue.Model.UpdateJobFromSourceControlRequest();
            
            if (cmdletContext.AuthStrategy != null)
            {
                request.AuthStrategy = cmdletContext.AuthStrategy;
            }
            if (cmdletContext.AuthToken != null)
            {
                request.AuthToken = cmdletContext.AuthToken;
            }
            if (cmdletContext.BranchName != null)
            {
                request.BranchName = cmdletContext.BranchName;
            }
            if (cmdletContext.CommitId != null)
            {
                request.CommitId = cmdletContext.CommitId;
            }
            if (cmdletContext.Folder != null)
            {
                request.Folder = cmdletContext.Folder;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            if (cmdletContext.RepositoryOwner != null)
            {
                request.RepositoryOwner = cmdletContext.RepositoryOwner;
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
        
        private Amazon.Glue.Model.UpdateJobFromSourceControlResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.UpdateJobFromSourceControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "UpdateJobFromSourceControl");
            try
            {
                return client.UpdateJobFromSourceControlAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Glue.SourceControlAuthStrategy AuthStrategy { get; set; }
            public System.String AuthToken { get; set; }
            public System.String BranchName { get; set; }
            public System.String CommitId { get; set; }
            public System.String Folder { get; set; }
            public System.String JobName { get; set; }
            public Amazon.Glue.SourceControlProvider Provider { get; set; }
            public System.String RepositoryName { get; set; }
            public System.String RepositoryOwner { get; set; }
            public System.Func<Amazon.Glue.Model.UpdateJobFromSourceControlResponse, UpdateGLUEJobFromSourceControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobName;
        }
        
    }
}
