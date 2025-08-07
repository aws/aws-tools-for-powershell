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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Updates the webhook associated with an CodeBuild build project. 
    /// 
    ///  <note><para>
    ///  If you use Bitbucket for your repository, <c>rotateSecret</c> is ignored. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "CBWebhook", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.Webhook")]
    [AWSCmdlet("Calls the AWS CodeBuild UpdateWebhook API operation.", Operation = new[] {"UpdateWebhook"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.UpdateWebhookResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.Webhook or Amazon.CodeBuild.Model.UpdateWebhookResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.Webhook object.",
        "The service call response (type Amazon.CodeBuild.Model.UpdateWebhookResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCBWebhookCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PullRequestBuildPolicy_ApproverRole
        /// <summary>
        /// <para>
        /// <para>List of repository roles that have approval privileges for pull request builds when
        /// comment approval is required. Only users with these roles can provide valid comment
        /// approvals. If a pull request contributor is one of these roles, their pull request
        /// builds will trigger automatically. This field is only applicable when <c>requiresCommentApproval</c>
        /// is not <i>DISABLED</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PullRequestBuildPolicy_ApproverRoles")]
        public System.String[] PullRequestBuildPolicy_ApproverRole { get; set; }
        #endregion
        
        #region Parameter BranchFilter
        /// <summary>
        /// <para>
        /// <para>A regular expression used to determine which repository branches are built when a
        /// webhook is triggered. If the name of a branch matches the regular expression, then
        /// it is built. If <c>branchFilter</c> is empty, then all branches are built.</para><note><para> It is recommended that you use <c>filterGroups</c> instead of <c>branchFilter</c>.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BranchFilter { get; set; }
        #endregion
        
        #region Parameter BuildType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of build this webhook will trigger.</para><note><para><c>RUNNER_BUILDKITE_BUILD</c> is only available for <c>NO_SOURCE</c> source type
        /// projects configured for Buildkite runner builds. For more information about CodeBuild-hosted
        /// Buildkite runner builds, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/sample-runner-buildkite.html">Tutorial:
        /// Configure a CodeBuild-hosted Buildkite runner</a> in the <i>CodeBuild user guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.WebhookBuildType")]
        public Amazon.CodeBuild.WebhookBuildType BuildType { get; set; }
        #endregion
        
        #region Parameter FilterGroup
        /// <summary>
        /// <para>
        /// <para> An array of arrays of <c>WebhookFilter</c> objects used to determine if a webhook
        /// event can trigger a build. A filter group must contain at least one <c>EVENT</c><c>WebhookFilter</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterGroups")]
        public Amazon.CodeBuild.Model.WebhookFilter[][] FilterGroup { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the CodeBuild project.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter PullRequestBuildPolicy_RequiresCommentApproval
        /// <summary>
        /// <para>
        /// <para>Specifies when comment-based approval is required before triggering a build on pull
        /// requests. This setting determines whether builds run automatically or require explicit
        /// approval through comments.</para><ul><li><para><i>DISABLED</i>: Builds trigger automatically without requiring comment approval</para></li><li><para><i>ALL_PULL_REQUESTS</i>: All pull requests require comment approval before builds
        /// execute (unless contributor is one of the approver roles)</para></li><li><para><i>FORK_PULL_REQUESTS</i>: Only pull requests from forked repositories require comment
        /// approval (unless contributor is one of the approver roles)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.PullRequestBuildCommentApproval")]
        public Amazon.CodeBuild.PullRequestBuildCommentApproval PullRequestBuildPolicy_RequiresCommentApproval { get; set; }
        #endregion
        
        #region Parameter RotateSecret
        /// <summary>
        /// <para>
        /// <para> A boolean value that specifies whether the associated GitHub repository's secret
        /// token should be updated. If you use Bitbucket for your repository, <c>rotateSecret</c>
        /// is ignored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RotateSecret { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Webhook'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.UpdateWebhookResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.UpdateWebhookResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Webhook";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CBWebhook (UpdateWebhook)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.UpdateWebhookResponse, UpdateCBWebhookCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BranchFilter = this.BranchFilter;
            context.BuildType = this.BuildType;
            if (this.FilterGroup != null)
            {
                context.FilterGroup = new List<List<Amazon.CodeBuild.Model.WebhookFilter>>();
                foreach (var innerList in this.FilterGroup)
                {
                    context.FilterGroup.Add(new List<Amazon.CodeBuild.Model.WebhookFilter>(innerList));
                }
            }
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PullRequestBuildPolicy_ApproverRole != null)
            {
                context.PullRequestBuildPolicy_ApproverRole = new List<System.String>(this.PullRequestBuildPolicy_ApproverRole);
            }
            context.PullRequestBuildPolicy_RequiresCommentApproval = this.PullRequestBuildPolicy_RequiresCommentApproval;
            context.RotateSecret = this.RotateSecret;
            
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
            var request = new Amazon.CodeBuild.Model.UpdateWebhookRequest();
            
            if (cmdletContext.BranchFilter != null)
            {
                request.BranchFilter = cmdletContext.BranchFilter;
            }
            if (cmdletContext.BuildType != null)
            {
                request.BuildType = cmdletContext.BuildType;
            }
            if (cmdletContext.FilterGroup != null)
            {
                request.FilterGroups = cmdletContext.FilterGroup;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            
             // populate PullRequestBuildPolicy
            var requestPullRequestBuildPolicyIsNull = true;
            request.PullRequestBuildPolicy = new Amazon.CodeBuild.Model.PullRequestBuildPolicy();
            List<System.String> requestPullRequestBuildPolicy_pullRequestBuildPolicy_ApproverRole = null;
            if (cmdletContext.PullRequestBuildPolicy_ApproverRole != null)
            {
                requestPullRequestBuildPolicy_pullRequestBuildPolicy_ApproverRole = cmdletContext.PullRequestBuildPolicy_ApproverRole;
            }
            if (requestPullRequestBuildPolicy_pullRequestBuildPolicy_ApproverRole != null)
            {
                request.PullRequestBuildPolicy.ApproverRoles = requestPullRequestBuildPolicy_pullRequestBuildPolicy_ApproverRole;
                requestPullRequestBuildPolicyIsNull = false;
            }
            Amazon.CodeBuild.PullRequestBuildCommentApproval requestPullRequestBuildPolicy_pullRequestBuildPolicy_RequiresCommentApproval = null;
            if (cmdletContext.PullRequestBuildPolicy_RequiresCommentApproval != null)
            {
                requestPullRequestBuildPolicy_pullRequestBuildPolicy_RequiresCommentApproval = cmdletContext.PullRequestBuildPolicy_RequiresCommentApproval;
            }
            if (requestPullRequestBuildPolicy_pullRequestBuildPolicy_RequiresCommentApproval != null)
            {
                request.PullRequestBuildPolicy.RequiresCommentApproval = requestPullRequestBuildPolicy_pullRequestBuildPolicy_RequiresCommentApproval;
                requestPullRequestBuildPolicyIsNull = false;
            }
             // determine if request.PullRequestBuildPolicy should be set to null
            if (requestPullRequestBuildPolicyIsNull)
            {
                request.PullRequestBuildPolicy = null;
            }
            if (cmdletContext.RotateSecret != null)
            {
                request.RotateSecret = cmdletContext.RotateSecret.Value;
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
        
        private Amazon.CodeBuild.Model.UpdateWebhookResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.UpdateWebhookRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "UpdateWebhook");
            try
            {
                #if DESKTOP
                return client.UpdateWebhook(request);
                #elif CORECLR
                return client.UpdateWebhookAsync(request).GetAwaiter().GetResult();
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
            public System.String BranchFilter { get; set; }
            public Amazon.CodeBuild.WebhookBuildType BuildType { get; set; }
            public List<List<Amazon.CodeBuild.Model.WebhookFilter>> FilterGroup { get; set; }
            public System.String ProjectName { get; set; }
            public List<System.String> PullRequestBuildPolicy_ApproverRole { get; set; }
            public Amazon.CodeBuild.PullRequestBuildCommentApproval PullRequestBuildPolicy_RequiresCommentApproval { get; set; }
            public System.Boolean? RotateSecret { get; set; }
            public System.Func<Amazon.CodeBuild.Model.UpdateWebhookResponse, UpdateCBWebhookCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Webhook;
        }
        
    }
}
