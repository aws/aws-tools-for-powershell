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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Creates a Cedar policy and saves it in the specified policy store. You can create
    /// either a static policy or a policy linked to a policy template.
    /// 
    ///  <ul><li><para>
    /// To create a static policy, provide the Cedar policy text in the <c>StaticPolicy</c>
    /// section of the <c>PolicyDefinition</c>.
    /// </para></li><li><para>
    /// To create a policy that is dynamically linked to a policy template, specify the policy
    /// template ID and the principal and resource to associate with this policy in the <c>templateLinked</c>
    /// section of the <c>PolicyDefinition</c>. If the policy template is ever updated, any
    /// policies linked to the policy template automatically use the updated template.
    /// </para></li></ul><note><para>
    /// Creating a policy causes it to be validated against the schema in the policy store.
    /// If the policy doesn't pass validation, the operation fails and the policy isn't stored.
    /// </para></note><note><para>
    /// Verified Permissions is <i><a href="https://wikipedia.org/wiki/Eventual_consistency">eventually
    /// consistent</a></i>. It can take a few seconds for a new or changed element to propagate
    /// through the service and be visible in the results of other Verified Permissions operations.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "AVPPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.CreatePolicyResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions CreatePolicy API operation.", Operation = new[] {"CreatePolicy"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.CreatePolicyResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.CreatePolicyResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.CreatePolicyResponse object containing multiple properties."
    )]
    public partial class NewAVPPolicyCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Static_Description
        /// <summary>
        /// <para>
        /// <para>The description of the static policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Static_Description")]
        public System.String Static_Description { get; set; }
        #endregion
        
        #region Parameter Principal_EntityId
        /// <summary>
        /// <para>
        /// <para>The identifier of an entity.</para><para><c>"entityId":"<i>identifier</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_TemplateLinked_Principal_EntityId")]
        public System.String Principal_EntityId { get; set; }
        #endregion
        
        #region Parameter Resource_EntityId
        /// <summary>
        /// <para>
        /// <para>The identifier of an entity.</para><para><c>"entityId":"<i>identifier</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_TemplateLinked_Resource_EntityId")]
        public System.String Resource_EntityId { get; set; }
        #endregion
        
        #region Parameter Principal_EntityType
        /// <summary>
        /// <para>
        /// <para>The type of an entity.</para><para>Example: <c>"entityType":"<i>typeName</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_TemplateLinked_Principal_EntityType")]
        public System.String Principal_EntityType { get; set; }
        #endregion
        
        #region Parameter Resource_EntityType
        /// <summary>
        /// <para>
        /// <para>The type of an entity.</para><para>Example: <c>"entityType":"<i>typeName</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_TemplateLinked_Resource_EntityType")]
        public System.String Resource_EntityType { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the <c>PolicyStoreId</c> of the policy store you want to store the policy
        /// in.</para>
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
        public System.String PolicyStoreId { get; set; }
        #endregion
        
        #region Parameter TemplateLinked_PolicyTemplateId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the policy template used to create this policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_TemplateLinked_PolicyTemplateId")]
        public System.String TemplateLinked_PolicyTemplateId { get; set; }
        #endregion
        
        #region Parameter Static_Statement
        /// <summary>
        /// <para>
        /// <para>The policy content of the static policy, written in the Cedar policy language.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Static_Statement")]
        public System.String Static_Statement { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive ID that you provide to ensure the idempotency of
        /// the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value.</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>ConflictException</c> error.</para><para>Verified Permissions recognizes a <c>ClientToken</c> for eight hours. After eight
        /// hours, the next request with the same parameters performs the operation again regardless
        /// of the value of <c>ClientToken</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.CreatePolicyResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.CreatePolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AVPPolicy (CreatePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.CreatePolicyResponse, NewAVPPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Static_Description = this.Static_Description;
            context.Static_Statement = this.Static_Statement;
            context.TemplateLinked_PolicyTemplateId = this.TemplateLinked_PolicyTemplateId;
            context.Principal_EntityId = this.Principal_EntityId;
            context.Principal_EntityType = this.Principal_EntityType;
            context.Resource_EntityId = this.Resource_EntityId;
            context.Resource_EntityType = this.Resource_EntityType;
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
            var request = new Amazon.VerifiedPermissions.Model.CreatePolicyRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.VerifiedPermissions.Model.PolicyDefinition();
            Amazon.VerifiedPermissions.Model.StaticPolicyDefinition requestDefinition_definition_Static = null;
            
             // populate Static
            var requestDefinition_definition_StaticIsNull = true;
            requestDefinition_definition_Static = new Amazon.VerifiedPermissions.Model.StaticPolicyDefinition();
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
            Amazon.VerifiedPermissions.Model.TemplateLinkedPolicyDefinition requestDefinition_definition_TemplateLinked = null;
            
             // populate TemplateLinked
            var requestDefinition_definition_TemplateLinkedIsNull = true;
            requestDefinition_definition_TemplateLinked = new Amazon.VerifiedPermissions.Model.TemplateLinkedPolicyDefinition();
            System.String requestDefinition_definition_TemplateLinked_templateLinked_PolicyTemplateId = null;
            if (cmdletContext.TemplateLinked_PolicyTemplateId != null)
            {
                requestDefinition_definition_TemplateLinked_templateLinked_PolicyTemplateId = cmdletContext.TemplateLinked_PolicyTemplateId;
            }
            if (requestDefinition_definition_TemplateLinked_templateLinked_PolicyTemplateId != null)
            {
                requestDefinition_definition_TemplateLinked.PolicyTemplateId = requestDefinition_definition_TemplateLinked_templateLinked_PolicyTemplateId;
                requestDefinition_definition_TemplateLinkedIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.EntityIdentifier requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal = null;
            
             // populate Principal
            var requestDefinition_definition_TemplateLinked_definition_TemplateLinked_PrincipalIsNull = true;
            requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal = new Amazon.VerifiedPermissions.Model.EntityIdentifier();
            System.String requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal_principal_EntityId = null;
            if (cmdletContext.Principal_EntityId != null)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal_principal_EntityId = cmdletContext.Principal_EntityId;
            }
            if (requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal_principal_EntityId != null)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal.EntityId = requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal_principal_EntityId;
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_PrincipalIsNull = false;
            }
            System.String requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal_principal_EntityType = null;
            if (cmdletContext.Principal_EntityType != null)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal_principal_EntityType = cmdletContext.Principal_EntityType;
            }
            if (requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal_principal_EntityType != null)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal.EntityType = requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal_principal_EntityType;
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_PrincipalIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal should be set to null
            if (requestDefinition_definition_TemplateLinked_definition_TemplateLinked_PrincipalIsNull)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal = null;
            }
            if (requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal != null)
            {
                requestDefinition_definition_TemplateLinked.Principal = requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Principal;
                requestDefinition_definition_TemplateLinkedIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.EntityIdentifier requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource = null;
            
             // populate Resource
            var requestDefinition_definition_TemplateLinked_definition_TemplateLinked_ResourceIsNull = true;
            requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource = new Amazon.VerifiedPermissions.Model.EntityIdentifier();
            System.String requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource_resource_EntityId = null;
            if (cmdletContext.Resource_EntityId != null)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource_resource_EntityId = cmdletContext.Resource_EntityId;
            }
            if (requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource_resource_EntityId != null)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource.EntityId = requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource_resource_EntityId;
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_ResourceIsNull = false;
            }
            System.String requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource_resource_EntityType = null;
            if (cmdletContext.Resource_EntityType != null)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource_resource_EntityType = cmdletContext.Resource_EntityType;
            }
            if (requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource_resource_EntityType != null)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource.EntityType = requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource_resource_EntityType;
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_ResourceIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource should be set to null
            if (requestDefinition_definition_TemplateLinked_definition_TemplateLinked_ResourceIsNull)
            {
                requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource = null;
            }
            if (requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource != null)
            {
                requestDefinition_definition_TemplateLinked.Resource = requestDefinition_definition_TemplateLinked_definition_TemplateLinked_Resource;
                requestDefinition_definition_TemplateLinkedIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateLinked should be set to null
            if (requestDefinition_definition_TemplateLinkedIsNull)
            {
                requestDefinition_definition_TemplateLinked = null;
            }
            if (requestDefinition_definition_TemplateLinked != null)
            {
                request.Definition.TemplateLinked = requestDefinition_definition_TemplateLinked;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
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
        
        private Amazon.VerifiedPermissions.Model.CreatePolicyResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.CreatePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "CreatePolicy");
            try
            {
                #if DESKTOP
                return client.CreatePolicy(request);
                #elif CORECLR
                return client.CreatePolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Static_Description { get; set; }
            public System.String Static_Statement { get; set; }
            public System.String TemplateLinked_PolicyTemplateId { get; set; }
            public System.String Principal_EntityId { get; set; }
            public System.String Principal_EntityType { get; set; }
            public System.String Resource_EntityId { get; set; }
            public System.String Resource_EntityType { get; set; }
            public System.String PolicyStoreId { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.CreatePolicyResponse, NewAVPPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
