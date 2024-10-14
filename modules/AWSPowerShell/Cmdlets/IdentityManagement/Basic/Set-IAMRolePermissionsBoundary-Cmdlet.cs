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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Adds or updates the policy that is specified as the IAM role's permissions boundary.
    /// You can use an Amazon Web Services managed policy or a customer managed policy to
    /// set the boundary for a role. Use the boundary to control the maximum permissions that
    /// the role can have. Setting a permissions boundary is an advanced feature that can
    /// affect the permissions for the role.
    /// 
    ///  
    /// <para>
    /// You cannot set the boundary for a service-linked role.
    /// </para><important><para>
    /// Policies used as permissions boundaries do not provide permissions. You must also
    /// attach a permissions policy to the role. To learn how the effective permissions for
    /// a role are evaluated, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_evaluation-logic.html">IAM
    /// JSON policy evaluation logic</a> in the IAM User Guide. 
    /// </para></important>
    /// </summary>
    [Cmdlet("Set", "IAMRolePermissionsBoundary", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management PutRolePermissionsBoundary API operation.", Operation = new[] {"PutRolePermissionsBoundary"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.PutRolePermissionsBoundaryResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityManagement.Model.PutRolePermissionsBoundaryResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityManagement.Model.PutRolePermissionsBoundaryResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetIAMRolePermissionsBoundaryCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PermissionsBoundary
        /// <summary>
        /// <para>
        /// <para>The ARN of the managed policy that is used to set the permissions boundary for the
        /// role.</para><para>A permissions boundary policy defines the maximum permissions that identity-based
        /// policies can grant to an entity, but does not grant permissions. Permissions boundaries
        /// do not define the maximum permissions that a resource-based policy can grant to an
        /// entity. To learn more, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_boundaries.html">Permissions
        /// boundaries for IAM entities</a> in the <i>IAM User Guide</i>.</para><para>For more information about policy types, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies.html#access_policy-types">Policy
        /// types </a> in the <i>IAM User Guide</i>.</para>
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
        public System.String PermissionsBoundary { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name (friendly name, not ARN) of the IAM role for which you want to set the permissions
        /// boundary.</para>
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
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.PutRolePermissionsBoundaryResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RoleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RoleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RoleName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IAMRolePermissionsBoundary (PutRolePermissionsBoundary)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.PutRolePermissionsBoundaryResponse, SetIAMRolePermissionsBoundaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RoleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PermissionsBoundary = this.PermissionsBoundary;
            #if MODULAR
            if (this.PermissionsBoundary == null && ParameterWasBound(nameof(this.PermissionsBoundary)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionsBoundary which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleName = this.RoleName;
            #if MODULAR
            if (this.RoleName == null && ParameterWasBound(nameof(this.RoleName)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.PutRolePermissionsBoundaryRequest();
            
            if (cmdletContext.PermissionsBoundary != null)
            {
                request.PermissionsBoundary = cmdletContext.PermissionsBoundary;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
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
        
        private Amazon.IdentityManagement.Model.PutRolePermissionsBoundaryResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.PutRolePermissionsBoundaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "PutRolePermissionsBoundary");
            try
            {
                #if DESKTOP
                return client.PutRolePermissionsBoundary(request);
                #elif CORECLR
                return client.PutRolePermissionsBoundaryAsync(request).GetAwaiter().GetResult();
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
            public System.String PermissionsBoundary { get; set; }
            public System.String RoleName { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.PutRolePermissionsBoundaryResponse, SetIAMRolePermissionsBoundaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
