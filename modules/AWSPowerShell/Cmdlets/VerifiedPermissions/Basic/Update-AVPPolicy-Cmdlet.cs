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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Modifies a Cedar static policy in the specified policy store. You can change only
    /// certain elements of the <a href="https://docs.aws.amazon.com/verifiedpermissions/latest/apireference/API_UpdatePolicyInput.html#amazonverifiedpermissions-UpdatePolicy-request-UpdatePolicyDefinition">UpdatePolicyDefinition</a>
    /// parameter. You can directly update only static policies. To change a template-linked
    /// policy, you must update the template instead, using <a href="https://docs.aws.amazon.com/verifiedpermissions/latest/apireference/API_UpdatePolicyTemplate.html">UpdatePolicyTemplate</a>.
    /// 
    ///  <note><ul><li><para>
    /// If policy validation is enabled in the policy store, then updating a static policy
    /// causes Verified Permissions to validate the policy against the schema in the policy
    /// store. If the updated static policy doesn't pass validation, the operation fails and
    /// the update isn't stored.
    /// </para></li><li><para>
    /// When you edit a static policy, you can change only certain elements of a static policy:
    /// </para><ul><li><para>
    /// The action referenced by the policy. 
    /// </para></li><li><para>
    /// A condition clause, such as when and unless. 
    /// </para></li></ul><para>
    /// You can't change these elements of a static policy: 
    /// </para><ul><li><para>
    /// Changing a policy from a static policy to a template-linked policy. 
    /// </para></li><li><para>
    /// Changing the effect of a static policy from permit or forbid. 
    /// </para></li><li><para>
    /// The principal referenced by a static policy. 
    /// </para></li><li><para>
    /// The resource referenced by a static policy. 
    /// </para></li></ul></li><li><para>
    /// To update a template-linked policy, you must update the template instead. 
    /// </para></li></ul></note><note><para>
    /// Verified Permissions is <i><a href="https://wikipedia.org/wiki/Eventual_consistency">eventually
    /// consistent</a></i>. It can take a few seconds for a new or changed element to propagate
    /// through the service and be visible in the results of other Verified Permissions operations.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "AVPPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.UpdatePolicyResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions UpdatePolicy API operation.", Operation = new[] {"UpdatePolicy"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.UpdatePolicyResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.UpdatePolicyResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.UpdatePolicyResponse object containing multiple properties."
    )]
    public partial class UpdateAVPPolicyCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Static_Description
        /// <summary>
        /// <para>
        /// <para>Specifies the description to be added to or replaced on the static policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Static_Description")]
        public System.String Static_Description { get; set; }
        #endregion
        
        #region Parameter PolicyId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy that you want to update. To find this value, you can
        /// use <a href="https://docs.aws.amazon.com/verifiedpermissions/latest/apireference/API_ListPolicies.html">ListPolicies</a>.</para>
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
        public System.String PolicyId { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store that contains the policy that you want to update.</para>
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
        public System.String PolicyStoreId { get; set; }
        #endregion
        
        #region Parameter Static_Statement
        /// <summary>
        /// <para>
        /// <para>Specifies the Cedar policy language text to be added to or replaced on the static
        /// policy.</para><important><para>You can change only the following elements from the original content:</para><ul><li><para>The <c>action</c> referenced by the policy.</para></li><li><para>Any conditional clauses, such as <c>when</c> or <c>unless</c> clauses.</para></li></ul><para>You <b>can't</b> change the following elements:</para><ul><li><para>Changing from <c>StaticPolicy</c> to <c>TemplateLinkedPolicy</c>.</para></li><li><para>The effect (<c>permit</c> or <c>forbid</c>) of the policy.</para></li><li><para>The <c>principal</c> referenced by the policy.</para></li><li><para>The <c>resource</c> referenced by the policy.</para></li></ul></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Static_Statement")]
        public System.String Static_Statement { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.UpdatePolicyResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.UpdatePolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AVPPolicy (UpdatePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.UpdatePolicyResponse, UpdateAVPPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Static_Description = this.Static_Description;
            context.Static_Statement = this.Static_Statement;
            context.PolicyId = this.PolicyId;
            #if MODULAR
            if (this.PolicyId == null && ParameterWasBound(nameof(this.PolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VerifiedPermissions.Model.UpdatePolicyRequest();
            
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.VerifiedPermissions.Model.UpdatePolicyDefinition();
            Amazon.VerifiedPermissions.Model.UpdateStaticPolicyDefinition requestDefinition_definition_Static = null;
            
             // populate Static
            var requestDefinition_definition_StaticIsNull = true;
            requestDefinition_definition_Static = new Amazon.VerifiedPermissions.Model.UpdateStaticPolicyDefinition();
            System.String requestDefinition_definition_Static_static_Description = null;
            if (cmdletContext.Static_Description != null)
            {
                requestDefinition_definition_Static_static_Description = cmdletContext.Static_Description;
            }
            if (requestDefinition_definition_Static_static_Description != null)
            {
                requestDefinition_definition_Static.Description = requestDefinition_definition_Static_static_Description;
                requestDefinition_definition_StaticIsNull = false;
            }
            System.String requestDefinition_definition_Static_static_Statement = null;
            if (cmdletContext.Static_Statement != null)
            {
                requestDefinition_definition_Static_static_Statement = cmdletContext.Static_Statement;
            }
            if (requestDefinition_definition_Static_static_Statement != null)
            {
                requestDefinition_definition_Static.Statement = requestDefinition_definition_Static_static_Statement;
                requestDefinition_definition_StaticIsNull = false;
            }
             // determine if requestDefinition_definition_Static should be set to null
            if (requestDefinition_definition_StaticIsNull)
            {
                requestDefinition_definition_Static = null;
            }
            if (requestDefinition_definition_Static != null)
            {
                request.Definition.Static = requestDefinition_definition_Static;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
            }
            if (cmdletContext.PolicyId != null)
            {
                request.PolicyId = cmdletContext.PolicyId;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
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
        
        private Amazon.VerifiedPermissions.Model.UpdatePolicyResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.UpdatePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "UpdatePolicy");
            try
            {
                #if DESKTOP
                return client.UpdatePolicy(request);
                #elif CORECLR
                return client.UpdatePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Static_Description { get; set; }
            public System.String Static_Statement { get; set; }
            public System.String PolicyId { get; set; }
            public System.String PolicyStoreId { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.UpdatePolicyResponse, UpdateAVPPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
