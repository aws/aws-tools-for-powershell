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
    /// Changes the public visibility for a project. The project's build results, logs, and
    /// artifacts are available to the general public. For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/public-builds.html">Public
    /// build projects</a> in the <i>CodeBuild User Guide</i>.
    /// 
    ///  <important><para>
    /// The following should be kept in mind when making your projects public:
    /// </para><ul><li><para>
    /// All of a project's build results, logs, and artifacts, including builds that were
    /// run when the project was private, are available to the general public.
    /// </para></li><li><para>
    /// All build logs and artifacts are available to the public. Environment variables, source
    /// code, and other sensitive information may have been output to the build logs and artifacts.
    /// You must be careful about what information is output to the build logs. Some best
    /// practice are:
    /// </para><ul><li><para>
    /// Do not store sensitive values, especially Amazon Web Services access key IDs and secret
    /// access keys, in environment variables. We recommend that you use an Amazon EC2 Systems
    /// Manager Parameter Store or Secrets Manager to store sensitive values.
    /// </para></li><li><para>
    /// Follow <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/webhooks.html#webhook-best-practices">Best
    /// practices for using webhooks</a> in the <i>CodeBuild User Guide</i> to limit which
    /// entities can trigger a build, and do not store the buildspec in the project itself,
    /// to ensure that your webhooks are as secure as possible.
    /// </para></li></ul></li><li><para>
    /// A malicious user can use public builds to distribute malicious artifacts. We recommend
    /// that you review all pull requests to verify that the pull request is a legitimate
    /// change. We also recommend that you validate any artifacts with their checksums to
    /// make sure that the correct artifacts are being downloaded.
    /// </para></li></ul></important>
    /// </summary>
    [Cmdlet("Update", "CBProjectVisibility", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.UpdateProjectVisibilityResponse")]
    [AWSCmdlet("Calls the AWS CodeBuild UpdateProjectVisibility API operation.", Operation = new[] {"UpdateProjectVisibility"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.UpdateProjectVisibilityResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.UpdateProjectVisibilityResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.UpdateProjectVisibilityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCBProjectVisibilityCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the build project.</para>
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
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter ProjectVisibility
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ProjectVisibilityType")]
        public Amazon.CodeBuild.ProjectVisibilityType ProjectVisibility { get; set; }
        #endregion
        
        #region Parameter ResourceAccessRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that enables CodeBuild to access the CloudWatch Logs and Amazon
        /// S3 artifacts for the project's builds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceAccessRole { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.UpdateProjectVisibilityResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.UpdateProjectVisibilityResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CBProjectVisibility (UpdateProjectVisibility)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.UpdateProjectVisibilityResponse, UpdateCBProjectVisibilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectVisibility = this.ProjectVisibility;
            #if MODULAR
            if (this.ProjectVisibility == null && ParameterWasBound(nameof(this.ProjectVisibility)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectVisibility which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceAccessRole = this.ResourceAccessRole;
            
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
            var request = new Amazon.CodeBuild.Model.UpdateProjectVisibilityRequest();
            
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            if (cmdletContext.ProjectVisibility != null)
            {
                request.ProjectVisibility = cmdletContext.ProjectVisibility;
            }
            if (cmdletContext.ResourceAccessRole != null)
            {
                request.ResourceAccessRole = cmdletContext.ResourceAccessRole;
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
        
        private Amazon.CodeBuild.Model.UpdateProjectVisibilityResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.UpdateProjectVisibilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "UpdateProjectVisibility");
            try
            {
                #if DESKTOP
                return client.UpdateProjectVisibility(request);
                #elif CORECLR
                return client.UpdateProjectVisibilityAsync(request).GetAwaiter().GetResult();
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
            public System.String ProjectArn { get; set; }
            public Amazon.CodeBuild.ProjectVisibilityType ProjectVisibility { get; set; }
            public System.String ResourceAccessRole { get; set; }
            public System.Func<Amazon.CodeBuild.Model.UpdateProjectVisibilityResponse, UpdateCBProjectVisibilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
