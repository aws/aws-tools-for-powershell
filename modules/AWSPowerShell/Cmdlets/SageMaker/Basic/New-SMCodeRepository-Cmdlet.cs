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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a Git repository as a resource in your SageMaker AI account. You can associate
    /// the repository with notebook instances so that you can use Git source control for
    /// the notebooks you create. The Git repository is a resource in your SageMaker AI account,
    /// so it can be associated with more than one notebook instance, and it persists independently
    /// from the lifecycle of any notebook instances it is associated with.
    /// 
    ///  
    /// <para>
    /// The repository can be hosted either in <a href="https://docs.aws.amazon.com/codecommit/latest/userguide/welcome.html">Amazon
    /// Web Services CodeCommit</a> or in any other Git repository.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMCodeRepository", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateCodeRepository API operation.", Operation = new[] {"CreateCodeRepository"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateCodeRepositoryResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateCodeRepositoryResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateCodeRepositoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMCodeRepositoryCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GitConfig_Branch
        /// <summary>
        /// <para>
        /// <para>The default branch for the Git repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GitConfig_Branch { get; set; }
        #endregion
        
        #region Parameter CodeRepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the Git repository. The name must have 1 to 63 characters. Valid characters
        /// are a-z, A-Z, 0-9, and - (hyphen).</para>
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
        public System.String CodeRepositoryName { get; set; }
        #endregion
        
        #region Parameter GitConfig_RepositoryUrl
        /// <summary>
        /// <para>
        /// <para>The URL where the Git repository is located.</para>
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
        public System.String GitConfig_RepositoryUrl { get; set; }
        #endregion
        
        #region Parameter GitConfig_SecretArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Secrets Manager secret that
        /// contains the credentials used to access the git repository. The secret must have a
        /// staging label of <c>AWSCURRENT</c> and must be in the following format:</para><para><c>{"username": <i>UserName</i>, "password": <i>Password</i>}</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GitConfig_SecretArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CodeRepositoryArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateCodeRepositoryResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateCodeRepositoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CodeRepositoryArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CodeRepositoryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMCodeRepository (CreateCodeRepository)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateCodeRepositoryResponse, NewSMCodeRepositoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CodeRepositoryName = this.CodeRepositoryName;
            #if MODULAR
            if (this.CodeRepositoryName == null && ParameterWasBound(nameof(this.CodeRepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter CodeRepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GitConfig_Branch = this.GitConfig_Branch;
            context.GitConfig_RepositoryUrl = this.GitConfig_RepositoryUrl;
            #if MODULAR
            if (this.GitConfig_RepositoryUrl == null && ParameterWasBound(nameof(this.GitConfig_RepositoryUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter GitConfig_RepositoryUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GitConfig_SecretArn = this.GitConfig_SecretArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            
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
            var requestGitConfigIsNull = true;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateCodeRepositoryResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateCodeRepositoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateCodeRepository");
            try
            {
                return client.CreateCodeRepositoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateCodeRepositoryResponse, NewSMCodeRepositoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CodeRepositoryArn;
        }
        
    }
}
