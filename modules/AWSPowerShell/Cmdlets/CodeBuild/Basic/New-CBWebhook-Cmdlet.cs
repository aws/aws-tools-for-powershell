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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// For an existing AWS CodeBuild build project that has its source code stored in a GitHub
    /// or Bitbucket repository, enables AWS CodeBuild to start rebuilding the source code
    /// every time a code change is pushed to the repository.
    /// 
    ///  <important><para>
    /// If you enable webhooks for an AWS CodeBuild project, and the project is used as a
    /// build step in AWS CodePipeline, then two identical builds are created for each commit.
    /// One build is triggered through webhooks, and one through AWS CodePipeline. Because
    /// billing is on a per-build basis, you are billed for both builds. Therefore, if you
    /// are using AWS CodePipeline, we recommend that you disable webhooks in AWS CodeBuild.
    /// In the AWS CodeBuild console, clear the Webhook box. For more information, see step
    /// 5 in <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/change-project.html#change-project-console">Change
    /// a Build Project's Settings</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "CBWebhook", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.Webhook")]
    [AWSCmdlet("Calls the AWS CodeBuild CreateWebhook API operation.", Operation = new[] {"CreateWebhook"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.CreateWebhookResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.Webhook or Amazon.CodeBuild.Model.CreateWebhookResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.Webhook object.",
        "The service call response (type Amazon.CodeBuild.Model.CreateWebhookResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCBWebhookCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        #region Parameter BranchFilter
        /// <summary>
        /// <para>
        /// <para>A regular expression used to determine which repository branches are built when a
        /// webhook is triggered. If the name of a branch matches the regular expression, then
        /// it is built. If <code>branchFilter</code> is empty, then all branches are built.</para><note><para>It is recommended that you use <code>filterGroups</code> instead of <code>branchFilter</code>.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BranchFilter { get; set; }
        #endregion
        
        #region Parameter BuildType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of build this webhook will trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.WebhookBuildType")]
        public Amazon.CodeBuild.WebhookBuildType BuildType { get; set; }
        #endregion
        
        #region Parameter FilterGroup
        /// <summary>
        /// <para>
        /// <para>An array of arrays of <code>WebhookFilter</code> objects used to determine which webhooks
        /// are triggered. At least one <code>WebhookFilter</code> in the array must specify <code>EVENT</code>
        /// as its <code>type</code>. </para><para>For a build to be triggered, at least one filter group in the <code>filterGroups</code>
        /// array must pass. For a filter group to pass, each of its filters must pass. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterGroups")]
        public Amazon.CodeBuild.Model.WebhookFilter[][] FilterGroup { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the AWS CodeBuild project.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Webhook'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.CreateWebhookResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.CreateWebhookResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CBWebhook (CreateWebhook)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.CreateWebhookResponse, NewCBWebhookCmdlet>(Select) ??
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
            var request = new Amazon.CodeBuild.Model.CreateWebhookRequest();
            
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
        
        private Amazon.CodeBuild.Model.CreateWebhookResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.CreateWebhookRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "CreateWebhook");
            try
            {
                #if DESKTOP
                return client.CreateWebhook(request);
                #elif CORECLR
                return client.CreateWebhookAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.CodeBuild.Model.CreateWebhookResponse, NewCBWebhookCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Webhook;
        }
        
    }
}
