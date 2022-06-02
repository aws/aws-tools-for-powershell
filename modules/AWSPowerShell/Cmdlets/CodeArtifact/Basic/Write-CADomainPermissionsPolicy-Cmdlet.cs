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
    /// Sets a resource policy on a domain that specifies permissions to access it. 
    /// 
    ///  
    /// <para>
    ///  When you call <code>PutDomainPermissionsPolicy</code>, the resource policy on the
    /// domain is ignored when evaluting permissions. This ensures that the owner of a domain
    /// cannot lock themselves out of the domain, which would prevent them from being able
    /// to update the resource policy. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CADomainPermissionsPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeArtifact.Model.ResourcePolicy")]
    [AWSCmdlet("Calls the AWS CodeArtifact PutDomainPermissionsPolicy API operation.", Operation = new[] {"PutDomainPermissionsPolicy"}, SelectReturnType = typeof(Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyResponse))]
    [AWSCmdletOutput("Amazon.CodeArtifact.Model.ResourcePolicy or Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyResponse",
        "This cmdlet returns an Amazon.CodeArtifact.Model.ResourcePolicy object.",
        "The service call response (type Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCADomainPermissionsPolicyCmdlet : AmazonCodeArtifactClientCmdlet, IExecutor
    {
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para> The name of the domain on which to set the resource policy. </para>
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
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para> A valid displayable JSON Aspen policy string to be set as the access control resource
        /// policy on the provided domain. </para>
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
        public System.String PolicyDocument { get; set; }
        #endregion
        
        #region Parameter PolicyRevision
        /// <summary>
        /// <para>
        /// <para> The current revision of the resource policy to be set. This revision is used for
        /// optimistic locking, which prevents others from overwriting your changes to the domain's
        /// resource policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyRevision { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Policy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyResponse).
        /// Specifying the name of a property of type Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Domain), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CADomainPermissionsPolicy (PutDomainPermissionsPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyResponse, WriteCADomainPermissionsPolicyCmdlet>(Select) ??
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
            context.PolicyDocument = this.PolicyDocument;
            #if MODULAR
            if (this.PolicyDocument == null && ParameterWasBound(nameof(this.PolicyDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyRevision = this.PolicyRevision;
            
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
            var request = new Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.DomainOwner != null)
            {
                request.DomainOwner = cmdletContext.DomainOwner;
            }
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
            }
            if (cmdletContext.PolicyRevision != null)
            {
                request.PolicyRevision = cmdletContext.PolicyRevision;
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
        
        private Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyResponse CallAWSServiceOperation(IAmazonCodeArtifact client, Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeArtifact", "PutDomainPermissionsPolicy");
            try
            {
                #if DESKTOP
                return client.PutDomainPermissionsPolicy(request);
                #elif CORECLR
                return client.PutDomainPermissionsPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String PolicyDocument { get; set; }
            public System.String PolicyRevision { get; set; }
            public System.Func<Amazon.CodeArtifact.Model.PutDomainPermissionsPolicyResponse, WriteCADomainPermissionsPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policy;
        }
        
    }
}
