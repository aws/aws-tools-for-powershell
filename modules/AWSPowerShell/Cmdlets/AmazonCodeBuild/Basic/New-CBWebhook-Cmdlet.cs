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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// For an existing AWS CodeBuild build project that has its source code stored in a GitHub
    /// repository, enables AWS CodeBuild to begin automatically rebuilding the source code
    /// every time a code change is pushed to the repository.
    /// 
    ///  <important><para>
    /// If you enable webhooks for an AWS CodeBuild project, and the project is used as a
    /// build step in AWS CodePipeline, then two identical builds will be created for each
    /// commit. One build is triggered through webhooks, and one through AWS CodePipeline.
    /// Because billing is on a per-build basis, you will be billed for both builds. Therefore,
    /// if you are using AWS CodePipeline, we recommend that you disable webhooks in CodeBuild.
    /// In the AWS CodeBuild console, clear the Webhook box. For more information, see step
    /// 9 in <a href="http://docs.aws.amazon.com/codebuild/latest/userguide/change-project.html#change-project-console">Change
    /// a Build Project's Settings</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "CBWebhook", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.Webhook")]
    [AWSCmdlet("Calls the AWS CodeBuild CreateWebhook API operation.", Operation = new[] {"CreateWebhook"})]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.Webhook",
        "This cmdlet returns a Webhook object.",
        "The service call response (type Amazon.CodeBuild.Model.CreateWebhookResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCBWebhookCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        #region Parameter BranchFilter
        /// <summary>
        /// <para>
        /// <para>A regular expression used to determine which branches in a repository are built when
        /// a webhook is triggered. If the name of a branch matches the regular expression, then
        /// it is built. If it doesn't match, then it is not. If branchFilter is empty, then all
        /// branches are built.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BranchFilter { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the AWS CodeBuild project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProjectName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProjectName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CBWebhook (CreateWebhook)"))
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
            
            context.BranchFilter = this.BranchFilter;
            context.ProjectName = this.ProjectName;
            
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
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Webhook;
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
        
        private Amazon.CodeBuild.Model.CreateWebhookResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.CreateWebhookRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "CreateWebhook");
            try
            {
                #if DESKTOP
                return client.CreateWebhook(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateWebhookAsync(request);
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
            public System.String BranchFilter { get; set; }
            public System.String ProjectName { get; set; }
        }
        
    }
}
