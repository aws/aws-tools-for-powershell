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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a Git repository as a resource in your Amazon SageMaker account. You can associate
    /// the repository with notebook instances so that you can use Git source control for
    /// the notebooks you create. The Git repository is a resource in your Amazon SageMaker
    /// account, so it can be associated with more than one notebook instance, and it persists
    /// independently from the lifecycle of any notebook instances it is associated with.
    /// 
    ///  
    /// <para>
    /// The repository can be hosted either in <a href="http://docs.aws.amazon.com/codecommit/latest/userguide/welcome.html">AWS
    /// CodeCommit</a> or in any other Git repository.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMCodeRepository", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateCodeRepository API operation.", Operation = new[] {"CreateCodeRepository"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateCodeRepositoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMCodeRepositoryCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter GitConfig_Branch
        /// <summary>
        /// <para>
        /// <para>The default branch for the Git repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GitConfig_Branch { get; set; }
        #endregion
        
        #region Parameter CodeRepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the Git repository. The name must have 1 to 63 characters. Valid characters
        /// are a-z, A-Z, 0-9, and - (hyphen).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CodeRepositoryName { get; set; }
        #endregion
        
        #region Parameter GitConfig_RepositoryUrl
        /// <summary>
        /// <para>
        /// <para>The URL where the Git repository is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GitConfig_RepositoryUrl { get; set; }
        #endregion
        
        #region Parameter GitConfig_SecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Secrets Manager secret that contains the
        /// credentials used to access the git repository. The secret must have a staging label
        /// of <code>AWSCURRENT</code> and must be in the following format:</para><para><code>{"username": <i>UserName</i>, "password": <i>Password</i>}</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GitConfig_SecretArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CodeRepositoryName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMCodeRepository (CreateCodeRepository)"))
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
            
            context.CodeRepositoryName = this.CodeRepositoryName;
            context.GitConfig_Branch = this.GitConfig_Branch;
            context.GitConfig_RepositoryUrl = this.GitConfig_RepositoryUrl;
            context.GitConfig_SecretArn = this.GitConfig_SecretArn;
            
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
            var request = new Amazon.SageMaker.Model.CreateCodeRepositoryRequest();
            
            if (cmdletContext.CodeRepositoryName != null)
            {
                request.CodeRepositoryName = cmdletContext.CodeRepositoryName;
            }
            
             // populate GitConfig
            bool requestGitConfigIsNull = true;
            request.GitConfig = new Amazon.SageMaker.Model.GitConfig();
            System.String requestGitConfig_gitConfig_Branch = null;
            if (cmdletContext.GitConfig_Branch != null)
            {
                requestGitConfig_gitConfig_Branch = cmdletContext.GitConfig_Branch;
            }
            if (requestGitConfig_gitConfig_Branch != null)
            {
                request.GitConfig.Branch = requestGitConfig_gitConfig_Branch;
                requestGitConfigIsNull = false;
            }
            System.String requestGitConfig_gitConfig_RepositoryUrl = null;
            if (cmdletContext.GitConfig_RepositoryUrl != null)
            {
                requestGitConfig_gitConfig_RepositoryUrl = cmdletContext.GitConfig_RepositoryUrl;
            }
            if (requestGitConfig_gitConfig_RepositoryUrl != null)
            {
                request.GitConfig.RepositoryUrl = requestGitConfig_gitConfig_RepositoryUrl;
                requestGitConfigIsNull = false;
            }
            System.String requestGitConfig_gitConfig_SecretArn = null;
            if (cmdletContext.GitConfig_SecretArn != null)
            {
                requestGitConfig_gitConfig_SecretArn = cmdletContext.GitConfig_SecretArn;
            }
            if (requestGitConfig_gitConfig_SecretArn != null)
            {
                request.GitConfig.SecretArn = requestGitConfig_gitConfig_SecretArn;
                requestGitConfigIsNull = false;
            }
             // determine if request.GitConfig should be set to null
            if (requestGitConfigIsNull)
            {
                request.GitConfig = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CodeRepositoryArn;
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
        
        private Amazon.SageMaker.Model.CreateCodeRepositoryResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateCodeRepositoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateCodeRepository");
            try
            {
                #if DESKTOP
                return client.CreateCodeRepository(request);
                #elif CORECLR
                return client.CreateCodeRepositoryAsync(request).GetAwaiter().GetResult();
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
            public System.String CodeRepositoryName { get; set; }
            public System.String GitConfig_Branch { get; set; }
            public System.String GitConfig_RepositoryUrl { get; set; }
            public System.String GitConfig_SecretArn { get; set; }
        }
        
    }
}
