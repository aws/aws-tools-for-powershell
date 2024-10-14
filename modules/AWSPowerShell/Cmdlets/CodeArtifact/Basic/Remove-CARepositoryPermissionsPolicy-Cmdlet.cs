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
    /// Deletes the resource policy that is set on a repository. After a resource policy
    /// is deleted, the permissions allowed and denied by the deleted policy are removed.
    /// The effect of deleting a resource policy might not be immediate. 
    /// 
    ///  <important><para>
    ///  Use <c>DeleteRepositoryPermissionsPolicy</c> with caution. After a policy is deleted,
    /// Amazon Web Services users, roles, and accounts lose permissions to perform the repository
    /// actions granted by the deleted policy. 
    /// </para></important>
    /// </summary>
    [Cmdlet("Remove", "CARepositoryPermissionsPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.CodeArtifact.Model.ResourcePolicy")]
    [AWSCmdlet("Calls the AWS CodeArtifact DeleteRepositoryPermissionsPolicy API operation.", Operation = new[] {"DeleteRepositoryPermissionsPolicy"}, SelectReturnType = typeof(Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyResponse))]
    [AWSCmdletOutput("Amazon.CodeArtifact.Model.ResourcePolicy or Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyResponse",
        "This cmdlet returns an Amazon.CodeArtifact.Model.ResourcePolicy object.",
        "The service call response (type Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveCARepositoryPermissionsPolicyCmdlet : AmazonCodeArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para> The name of the domain that contains the repository associated with the resource
        /// policy to be deleted. </para>
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
        
        #region Parameter PolicyRevision
        /// <summary>
        /// <para>
        /// <para> The revision of the repository's resource policy to be deleted. This revision is
        /// used for optimistic locking, which prevents others from accidentally overwriting your
        /// changes to the repository's resource policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyRevision { get; set; }
        #endregion
        
        #region Parameter Repository
        /// <summary>
        /// <para>
        /// <para> The name of the repository that is associated with the resource policy to be deleted
        /// </para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Policy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyResponse).
        /// Specifying the name of a property of type Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Policy";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Repository), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CARepositoryPermissionsPolicy (DeleteRepositoryPermissionsPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyResponse, RemoveCARepositoryPermissionsPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainOwner = this.DomainOwner;
            context.PolicyRevision = this.PolicyRevision;
            context.Repository = this.Repository;
            #if MODULAR
            if (this.Repository == null && ParameterWasBound(nameof(this.Repository)))
            {
                WriteWarning("You are passing $null as a value for parameter Repository which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.DomainOwner != null)
            {
                request.DomainOwner = cmdletContext.DomainOwner;
            }
            if (cmdletContext.PolicyRevision != null)
            {
                request.PolicyRevision = cmdletContext.PolicyRevision;
            }
            if (cmdletContext.Repository != null)
            {
                request.Repository = cmdletContext.Repository;
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
        
        private Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyResponse CallAWSServiceOperation(IAmazonCodeArtifact client, Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeArtifact", "DeleteRepositoryPermissionsPolicy");
            try
            {
                #if DESKTOP
                return client.DeleteRepositoryPermissionsPolicy(request);
                #elif CORECLR
                return client.DeleteRepositoryPermissionsPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Domain { get; set; }
            public System.String DomainOwner { get; set; }
            public System.String PolicyRevision { get; set; }
            public System.String Repository { get; set; }
            public System.Func<Amazon.CodeArtifact.Model.DeleteRepositoryPermissionsPolicyResponse, RemoveCARepositoryPermissionsPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policy;
        }
        
    }
}
