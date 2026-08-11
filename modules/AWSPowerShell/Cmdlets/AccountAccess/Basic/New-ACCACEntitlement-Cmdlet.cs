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
using Amazon.AccountAccess;
using Amazon.AccountAccess.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACCAC
{
    /// <summary>
    /// Creates an entitlement (assignment) in account access manager. An entitlement (assignment)
    /// grants a principal (IAM Identity Center user or group) permission to assume a specified
    /// IAM role in an Amazon Web Services account. This operation is idempotent.
    /// </summary>
    [Cmdlet("New", "ACCACEntitlement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Account Access CreateEntitlement API operation.", Operation = new[] {"CreateEntitlement"}, SelectReturnType = typeof(Amazon.AccountAccess.Model.CreateEntitlementResponse))]
    [AWSCmdletOutput("System.String or Amazon.AccountAccess.Model.CreateEntitlementResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AccountAccess.Model.CreateEntitlementResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewACCACEntitlementCmdlet : AmazonAccountAccessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the application to create the entitlement for.</para>
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
        public System.String ApplicationArn { get; set; }
        #endregion
        
        #region Parameter Entitlement_PrincipalRole_Principal_IdentityCenter_GroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a group in IAM Identity Center.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Entitlement_PrincipalRole_Principal_IdentityCenter_GroupId { get; set; }
        #endregion
        
        #region Parameter Entitlement_PrincipalRole_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that the principal can assume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Entitlement_PrincipalRole_RoleArn { get; set; }
        #endregion
        
        #region Parameter Entitlement_PrincipalRole_Principal_IdentityCenter_UserId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a user in IAM Identity Center.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Entitlement_PrincipalRole_Principal_IdentityCenter_UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EntitlementId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccountAccess.Model.CreateEntitlementResponse).
        /// Specifying the name of a property of type Amazon.AccountAccess.Model.CreateEntitlementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EntitlementId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ACCACEntitlement (CreateEntitlement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AccountAccess.Model.CreateEntitlementResponse, NewACCACEntitlementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationArn = this.ApplicationArn;
            #if MODULAR
            if (this.ApplicationArn == null && ParameterWasBound(nameof(this.ApplicationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Entitlement_PrincipalRole_Principal_IdentityCenter_GroupId = this.Entitlement_PrincipalRole_Principal_IdentityCenter_GroupId;
            context.Entitlement_PrincipalRole_Principal_IdentityCenter_UserId = this.Entitlement_PrincipalRole_Principal_IdentityCenter_UserId;
            context.Entitlement_PrincipalRole_RoleArn = this.Entitlement_PrincipalRole_RoleArn;
            
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
            var request = new Amazon.AccountAccess.Model.CreateEntitlementRequest();
            
            if (cmdletContext.ApplicationArn != null)
            {
                request.ApplicationArn = cmdletContext.ApplicationArn;
            }
            
             // populate Entitlement
            var requestEntitlementIsNull = true;
            request.Entitlement = new Amazon.AccountAccess.Model.Entitlement();
            Amazon.AccountAccess.Model.PrincipalRoleEntitlement requestEntitlement_entitlement_PrincipalRole = null;
            
             // populate PrincipalRole
            var requestEntitlement_entitlement_PrincipalRoleIsNull = true;
            requestEntitlement_entitlement_PrincipalRole = new Amazon.AccountAccess.Model.PrincipalRoleEntitlement();
            System.String requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_RoleArn = null;
            if (cmdletContext.Entitlement_PrincipalRole_RoleArn != null)
            {
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_RoleArn = cmdletContext.Entitlement_PrincipalRole_RoleArn;
            }
            if (requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_RoleArn != null)
            {
                requestEntitlement_entitlement_PrincipalRole.RoleArn = requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_RoleArn;
                requestEntitlement_entitlement_PrincipalRoleIsNull = false;
            }
            Amazon.AccountAccess.Model.Principal requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal = null;
            
             // populate Principal
            var requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_PrincipalIsNull = true;
            requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal = new Amazon.AccountAccess.Model.Principal();
            Amazon.AccountAccess.Model.IdentityCenterPrincipal requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter = null;
            
             // populate IdentityCenter
            var requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenterIsNull = true;
            requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter = new Amazon.AccountAccess.Model.IdentityCenterPrincipal();
            System.String requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter_entitlement_PrincipalRole_Principal_IdentityCenter_GroupId = null;
            if (cmdletContext.Entitlement_PrincipalRole_Principal_IdentityCenter_GroupId != null)
            {
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter_entitlement_PrincipalRole_Principal_IdentityCenter_GroupId = cmdletContext.Entitlement_PrincipalRole_Principal_IdentityCenter_GroupId;
            }
            if (requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter_entitlement_PrincipalRole_Principal_IdentityCenter_GroupId != null)
            {
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter.GroupId = requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter_entitlement_PrincipalRole_Principal_IdentityCenter_GroupId;
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenterIsNull = false;
            }
            System.String requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter_entitlement_PrincipalRole_Principal_IdentityCenter_UserId = null;
            if (cmdletContext.Entitlement_PrincipalRole_Principal_IdentityCenter_UserId != null)
            {
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter_entitlement_PrincipalRole_Principal_IdentityCenter_UserId = cmdletContext.Entitlement_PrincipalRole_Principal_IdentityCenter_UserId;
            }
            if (requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter_entitlement_PrincipalRole_Principal_IdentityCenter_UserId != null)
            {
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter.UserId = requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter_entitlement_PrincipalRole_Principal_IdentityCenter_UserId;
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenterIsNull = false;
            }
             // determine if requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter should be set to null
            if (requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenterIsNull)
            {
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter = null;
            }
            if (requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter != null)
            {
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal.IdentityCenter = requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal_entitlement_PrincipalRole_Principal_IdentityCenter;
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_PrincipalIsNull = false;
            }
             // determine if requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal should be set to null
            if (requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_PrincipalIsNull)
            {
                requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal = null;
            }
            if (requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal != null)
            {
                requestEntitlement_entitlement_PrincipalRole.Principal = requestEntitlement_entitlement_PrincipalRole_entitlement_PrincipalRole_Principal;
                requestEntitlement_entitlement_PrincipalRoleIsNull = false;
            }
             // determine if requestEntitlement_entitlement_PrincipalRole should be set to null
            if (requestEntitlement_entitlement_PrincipalRoleIsNull)
            {
                requestEntitlement_entitlement_PrincipalRole = null;
            }
            if (requestEntitlement_entitlement_PrincipalRole != null)
            {
                request.Entitlement.PrincipalRole = requestEntitlement_entitlement_PrincipalRole;
                requestEntitlementIsNull = false;
            }
             // determine if request.Entitlement should be set to null
            if (requestEntitlementIsNull)
            {
                request.Entitlement = null;
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
        
        private Amazon.AccountAccess.Model.CreateEntitlementResponse CallAWSServiceOperation(IAmazonAccountAccess client, Amazon.AccountAccess.Model.CreateEntitlementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Account Access", "CreateEntitlement");
            try
            {
                return client.CreateEntitlementAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationArn { get; set; }
            public System.String Entitlement_PrincipalRole_Principal_IdentityCenter_GroupId { get; set; }
            public System.String Entitlement_PrincipalRole_Principal_IdentityCenter_UserId { get; set; }
            public System.String Entitlement_PrincipalRole_RoleArn { get; set; }
            public System.Func<Amazon.AccountAccess.Model.CreateEntitlementResponse, NewACCACEntitlementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EntitlementId;
        }
        
    }
}
