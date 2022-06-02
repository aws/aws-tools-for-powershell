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
using Amazon.CodeArtifact;
using Amazon.CodeArtifact.Model;

namespace Amazon.PowerShell.Cmdlets.CA
{
    /// <summary>
    /// Update the properties of a repository.
    /// </summary>
    [Cmdlet("Update", "CARepository", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeArtifact.Model.RepositoryDescription")]
    [AWSCmdlet("Calls the AWS CodeArtifact UpdateRepository API operation.", Operation = new[] {"UpdateRepository"}, SelectReturnType = typeof(Amazon.CodeArtifact.Model.UpdateRepositoryResponse))]
    [AWSCmdletOutput("Amazon.CodeArtifact.Model.RepositoryDescription or Amazon.CodeArtifact.Model.UpdateRepositoryResponse",
        "This cmdlet returns an Amazon.CodeArtifact.Model.RepositoryDescription object.",
        "The service call response (type Amazon.CodeArtifact.Model.UpdateRepositoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCARepositoryCmdlet : AmazonCodeArtifactClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> An updated repository description. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para> The name of the domain associated with the repository to update. </para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainOwner
        /// <summary>
        /// <para>
        /// <para> The 12-digit account number of the Amazon Web Services account that owns the domain.
        /// It does not include dashes or spaces. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainOwner { get; set; }
        #endregion
        
        #region Parameter Repository
        /// <summary>
        /// <para>
        /// <para> The name of the repository to update. </para>
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
        public System.String Repository { get; set; }
        #endregion
        
        #region Parameter Upstream
        /// <summary>
        /// <para>
        /// <para> A list of upstream repositories to associate with the repository. The order of the
        /// upstream repositories in the list determines their priority order when CodeArtifact
        /// looks for a requested package version. For more information, see <a href="https://docs.aws.amazon.com/codeartifact/latest/ug/repos-upstream.html">Working
        /// with upstream repositories</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Upstreams")]
        public Amazon.CodeArtifact.Model.UpstreamRepository[] Upstream { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Repository'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeArtifact.Model.UpdateRepositoryResponse).
        /// Specifying the name of a property of type Amazon.CodeArtifact.Model.UpdateRepositoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Repository";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Repository), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CARepository (UpdateRepository)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeArtifact.Model.UpdateRepositoryResponse, UpdateCARepositoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainOwner = this.DomainOwner;
            context.Repository = this.Repository;
            #if MODULAR
            if (this.Repository == null && ParameterWasBound(nameof(this.Repository)))
            {
                WriteWarning("You are passing $null as a value for parameter Repository which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Upstream != null)
            {
                context.Upstream = new List<Amazon.CodeArtifact.Model.UpstreamRepository>(this.Upstream);
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
            var request = new Amazon.CodeArtifact.Model.UpdateRepositoryRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.DomainOwner != null)
            {
                request.DomainOwner = cmdletContext.DomainOwner;
            }
            if (cmdletContext.Repository != null)
            {
                request.Repository = cmdletContext.Repository;
            }
            if (cmdletContext.Upstream != null)
            {
                request.Upstreams = cmdletContext.Upstream;
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
        
        private Amazon.CodeArtifact.Model.UpdateRepositoryResponse CallAWSServiceOperation(IAmazonCodeArtifact client, Amazon.CodeArtifact.Model.UpdateRepositoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeArtifact", "UpdateRepository");
            try
            {
                #if DESKTOP
                return client.UpdateRepository(request);
                #elif CORECLR
                return client.UpdateRepositoryAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainOwner { get; set; }
            public System.String Repository { get; set; }
            public List<Amazon.CodeArtifact.Model.UpstreamRepository> Upstream { get; set; }
            public System.Func<Amazon.CodeArtifact.Model.UpdateRepositoryResponse, UpdateCARepositoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Repository;
        }
        
    }
}
