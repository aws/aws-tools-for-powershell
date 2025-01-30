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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Validates an existing pull through cache rule for an upstream registry that requires
    /// authentication. This will retrieve the contents of the Amazon Web Services Secrets
    /// Manager secret, verify the syntax, and then validate that authentication to the upstream
    /// registry is successful.
    /// </summary>
    [Cmdlet("Test", "ECRPullThroughCacheRule")]
    [OutputType("Amazon.ECR.Model.ValidatePullThroughCacheRuleResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry ValidatePullThroughCacheRule API operation.", Operation = new[] {"ValidatePullThroughCacheRule"}, SelectReturnType = typeof(Amazon.ECR.Model.ValidatePullThroughCacheRuleResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.ValidatePullThroughCacheRuleResponse",
        "This cmdlet returns an Amazon.ECR.Model.ValidatePullThroughCacheRuleResponse object containing multiple properties."
    )]
    public partial class TestECRPullThroughCacheRuleCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EcrRepositoryPrefix
        /// <summary>
        /// <para>
        /// <para>The repository name prefix associated with the pull through cache rule.</para>
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
        public System.String EcrRepositoryPrefix { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The registry ID associated with the pull through cache rule. If you do not specify
        /// a registry, the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.ValidatePullThroughCacheRuleResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.ValidatePullThroughCacheRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EcrRepositoryPrefix parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EcrRepositoryPrefix' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EcrRepositoryPrefix' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.ValidatePullThroughCacheRuleResponse, TestECRPullThroughCacheRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EcrRepositoryPrefix;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EcrRepositoryPrefix = this.EcrRepositoryPrefix;
            #if MODULAR
            if (this.EcrRepositoryPrefix == null && ParameterWasBound(nameof(this.EcrRepositoryPrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter EcrRepositoryPrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegistryId = this.RegistryId;
            
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
            var request = new Amazon.ECR.Model.ValidatePullThroughCacheRuleRequest();
            
            if (cmdletContext.EcrRepositoryPrefix != null)
            {
                request.EcrRepositoryPrefix = cmdletContext.EcrRepositoryPrefix;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
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
        
        private Amazon.ECR.Model.ValidatePullThroughCacheRuleResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.ValidatePullThroughCacheRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "ValidatePullThroughCacheRule");
            try
            {
                #if DESKTOP
                return client.ValidatePullThroughCacheRule(request);
                #elif CORECLR
                return client.ValidatePullThroughCacheRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String EcrRepositoryPrefix { get; set; }
            public System.String RegistryId { get; set; }
            public System.Func<Amazon.ECR.Model.ValidatePullThroughCacheRuleResponse, TestECRPullThroughCacheRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
