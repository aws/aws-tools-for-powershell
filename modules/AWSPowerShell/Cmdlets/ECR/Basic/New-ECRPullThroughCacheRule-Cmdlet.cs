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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Creates a pull through cache rule. A pull through cache rule provides a way to cache
    /// images from an upstream registry source in your Amazon ECR private registry. For more
    /// information, see <a href="https://docs.aws.amazon.com/AmazonECR/latest/userguide/pull-through-cache.html">Using
    /// pull through cache rules</a> in the <i>Amazon Elastic Container Registry User Guide</i>.
    /// </summary>
    [Cmdlet("New", "ECRPullThroughCacheRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.CreatePullThroughCacheRuleResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry CreatePullThroughCacheRule API operation.", Operation = new[] {"CreatePullThroughCacheRule"}, SelectReturnType = typeof(Amazon.ECR.Model.CreatePullThroughCacheRuleResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.CreatePullThroughCacheRuleResponse",
        "This cmdlet returns an Amazon.ECR.Model.CreatePullThroughCacheRuleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECRPullThroughCacheRuleCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CredentialArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Secrets Manager secret that
        /// identifies the credentials to authenticate to the upstream registry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CredentialArn { get; set; }
        #endregion
        
        #region Parameter EcrRepositoryPrefix
        /// <summary>
        /// <para>
        /// <para>The repository name prefix to use when caching images from the source registry.</para>
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
        public System.String EcrRepositoryPrefix { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the registry to create the pull
        /// through cache rule for. If you do not specify a registry, the default registry is
        /// assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter UpstreamRegistry
        /// <summary>
        /// <para>
        /// <para>The name of the upstream registry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECR.UpstreamRegistry")]
        public Amazon.ECR.UpstreamRegistry UpstreamRegistry { get; set; }
        #endregion
        
        #region Parameter UpstreamRegistryUrl
        /// <summary>
        /// <para>
        /// <para>The registry URL of the upstream public registry to use as the source for the pull
        /// through cache rule. The following is the syntax to use for each supported upstream
        /// registry.</para><ul><li><para>Amazon ECR Public (<c>ecr-public</c>) - <c>public.ecr.aws</c></para></li><li><para>Docker Hub (<c>docker-hub</c>) - <c>registry-1.docker.io</c></para></li><li><para>Quay (<c>quay</c>) - <c>quay.io</c></para></li><li><para>Kubernetes (<c>k8s</c>) - <c>registry.k8s.io</c></para></li><li><para>GitHub Container Registry (<c>github-container-registry</c>) - <c>ghcr.io</c></para></li><li><para>Microsoft Azure Container Registry (<c>azure-container-registry</c>) - <c>&lt;custom&gt;.azurecr.io</c></para></li></ul>
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
        public System.String UpstreamRegistryUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.CreatePullThroughCacheRuleResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.CreatePullThroughCacheRuleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECRPullThroughCacheRule (CreatePullThroughCacheRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.CreatePullThroughCacheRuleResponse, NewECRPullThroughCacheRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CredentialArn = this.CredentialArn;
            context.EcrRepositoryPrefix = this.EcrRepositoryPrefix;
            #if MODULAR
            if (this.EcrRepositoryPrefix == null && ParameterWasBound(nameof(this.EcrRepositoryPrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter EcrRepositoryPrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegistryId = this.RegistryId;
            context.UpstreamRegistry = this.UpstreamRegistry;
            context.UpstreamRegistryUrl = this.UpstreamRegistryUrl;
            #if MODULAR
            if (this.UpstreamRegistryUrl == null && ParameterWasBound(nameof(this.UpstreamRegistryUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter UpstreamRegistryUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECR.Model.CreatePullThroughCacheRuleRequest();
            
            if (cmdletContext.CredentialArn != null)
            {
                request.CredentialArn = cmdletContext.CredentialArn;
            }
            if (cmdletContext.EcrRepositoryPrefix != null)
            {
                request.EcrRepositoryPrefix = cmdletContext.EcrRepositoryPrefix;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            if (cmdletContext.UpstreamRegistry != null)
            {
                request.UpstreamRegistry = cmdletContext.UpstreamRegistry;
            }
            if (cmdletContext.UpstreamRegistryUrl != null)
            {
                request.UpstreamRegistryUrl = cmdletContext.UpstreamRegistryUrl;
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
        
        private Amazon.ECR.Model.CreatePullThroughCacheRuleResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.CreatePullThroughCacheRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "CreatePullThroughCacheRule");
            try
            {
                #if DESKTOP
                return client.CreatePullThroughCacheRule(request);
                #elif CORECLR
                return client.CreatePullThroughCacheRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String CredentialArn { get; set; }
            public System.String EcrRepositoryPrefix { get; set; }
            public System.String RegistryId { get; set; }
            public Amazon.ECR.UpstreamRegistry UpstreamRegistry { get; set; }
            public System.String UpstreamRegistryUrl { get; set; }
            public System.Func<Amazon.ECR.Model.CreatePullThroughCacheRuleResponse, NewECRPullThroughCacheRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
