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
    /// Creates a pull request in the specified repository.
    /// </summary>
    [Cmdlet("New", "CCPullRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeCommit.Model.PullRequest")]
    [AWSCmdlet("Calls the AWS CodeCommit CreatePullRequest API operation.", Operation = new[] {"CreatePullRequest"}, SelectReturnType = typeof(Amazon.CodeCommit.Model.CreatePullRequestResponse))]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.PullRequest or Amazon.CodeCommit.Model.CreatePullRequestResponse",
        "This cmdlet returns an Amazon.CodeCommit.Model.PullRequest object.",
        "The service call response (type Amazon.CodeCommit.Model.CreatePullRequestResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCCPullRequestCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, client-generated idempotency token that, when provided in a request, ensures
        /// the request cannot be repeated with a changed parameter. If a request is received
        /// with the same parameters and a token is included, the request returns information
        /// about the initial request that used that token.</para><note><para>The Amazon Web ServicesSDKs prepopulate client request tokens. If you are using an
        /// Amazon Web ServicesSDK, an idempotency token is created for you.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the pull request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets for the pull request, including the source of the code to be reviewed
        /// (the source branch) and the destination where the creator of the pull request intends
        /// the code to be merged after the pull request is closed (the destination branch).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Targets")]
        public Amazon.CodeCommit.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>The title of the pull request. This title is used to identify the pull request to
        /// other users in the repository.</para>
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
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PullRequest'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCommit.Model.CreatePullRequestResponse).
        /// Specifying the name of a property of type Amazon.CodeCommit.Model.CreatePullRequestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PullRequest";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Title), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCPullRequest (CreatePullRequest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCommit.Model.CreatePullRequestResponse, NewCCPullRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            if (this.Target != null)
            {
                context.Target = new List<Amazon.CodeCommit.Model.Target>(this.Target);
            }
            #if MODULAR
            if (this.Target == null && ParameterWasBound(nameof(this.Target)))
            {
                WriteWarning("You are passing $null as a value for parameter Target which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeCommit.Model.CreatePullRequestRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.CodeCommit.Model.CreatePullRequestResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.CreatePullRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "CreatePullRequest");
            try
            {
                #if DESKTOP
                return client.CreatePullRequest(request);
                #elif CORECLR
                return client.CreatePullRequestAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.CodeCommit.Model.Target> Target { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.CodeCommit.Model.CreatePullRequestResponse, NewCCPullRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PullRequest;
        }
        
    }
}
