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
    /// Makes an authorization decision about a service request described in the parameters.
    /// The information in the parameters can also define additional context that Verified
    /// Permissions can include in the evaluation. The request is evaluated against all matching
    /// policies in the specified policy store. The result of the decision is either <c>Allow</c>
    /// or <c>Deny</c>, along with a list of the policies that resulted in the decision.
    /// </summary>
    [Cmdlet("Test", "AVPAuthorization")]
    [OutputType("Amazon.VerifiedPermissions.Model.IsAuthorizedResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions IsAuthorized API operation.", Operation = new[] {"IsAuthorized"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.IsAuthorizedResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.IsAuthorizedResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.IsAuthorizedResponse object containing multiple properties."
    )]
    public partial class TestAVPAuthorizationCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action_ActionId
        /// <summary>
        /// <para>
        /// <para>The ID of an action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Action_ActionId { get; set; }
        #endregion
        
        #region Parameter Action_ActionType
        /// <summary>
        /// <para>
        /// <para>The type of an action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Action_ActionType { get; set; }
        #endregion
        
        #region Parameter Context_CedarJson
        /// <summary>
        /// <para>
        /// <para>A Cedar JSON string representation of the context needed to successfully evaluate
        /// an authorization request.</para><para>Example: <c>{"cedarJson":"{\"&lt;KeyName1&gt;\": true, \"&lt;KeyName2&gt;\": 1234}"
        /// }</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context_CedarJson { get; set; }
        #endregion
        
        #region Parameter Entities_CedarJson
        /// <summary>
        /// <para>
        /// <para>A Cedar JSON string representation of the entities needed to successfully evaluate
        /// an authorization request.</para><para>Example: <c>{"cedarJson": "[{\"uid\":{\"type\":\"Photo\",\"id\":\"VacationPhoto94.jpg\"},\"attrs\":{\"accessLevel\":\"public\"},\"parents\":[]}]"}</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Entities_CedarJson { get; set; }
        #endregion
        
        #region Parameter Context_ContextMap
        /// <summary>
        /// <para>
        /// <para>An list of attributes that are needed to successfully evaluate an authorization request.
        /// Each attribute in this array must include a map of a data type and its value.</para><para>Example: <c>"contextMap":{"&lt;KeyName1&gt;":{"boolean":true},"&lt;KeyName2&gt;":{"long":1234}}</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Context_ContextMap { get; set; }
        #endregion
        
        #region Parameter Principal_EntityId
        /// <summary>
        /// <para>
        /// <para>The identifier of an entity.</para><para><c>"entityId":"<i>identifier</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Principal_EntityId { get; set; }
        #endregion
        
        #region Parameter Resource_EntityId
        /// <summary>
        /// <para>
        /// <para>The identifier of an entity.</para><para><c>"entityId":"<i>identifier</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_EntityId { get; set; }
        #endregion
        
        #region Parameter Entities_EntityList
        /// <summary>
        /// <para>
        /// <para>An array of entities that are needed to successfully evaluate an authorization request.
        /// Each entity in this array must include an identifier for the entity, the attributes
        /// of the entity, and a list of any parent entities.</para><note><para>If you include multiple entities with the same <c>identifier</c>, only the last one
        /// is processed in the request.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.VerifiedPermissions.Model.EntityItem[] Entities_EntityList { get; set; }
        #endregion
        
        #region Parameter Principal_EntityType
        /// <summary>
        /// <para>
        /// <para>The type of an entity.</para><para>Example: <c>"entityType":"<i>typeName</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Principal_EntityType { get; set; }
        #endregion
        
        #region Parameter Resource_EntityType
        /// <summary>
        /// <para>
        /// <para>The type of an entity.</para><para>Example: <c>"entityType":"<i>typeName</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_EntityType { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store. Policies in this policy store will be used to
        /// make an authorization decision for the input.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.IsAuthorizedResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.IsAuthorizedResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyStoreId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.IsAuthorizedResponse, TestAVPAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Action_ActionId = this.Action_ActionId;
            context.Action_ActionType = this.Action_ActionType;
            context.Context_CedarJson = this.Context_CedarJson;
            if (this.Context_ContextMap != null)
            {
                context.Context_ContextMap = new Dictionary<System.String, Amazon.VerifiedPermissions.Model.AttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.Context_ContextMap.Keys)
                {
                    context.Context_ContextMap.Add((String)hashKey, (Amazon.VerifiedPermissions.Model.AttributeValue)(this.Context_ContextMap[hashKey]));
                }
            }
            context.Entities_CedarJson = this.Entities_CedarJson;
            if (this.Entities_EntityList != null)
            {
                context.Entities_EntityList = new List<Amazon.VerifiedPermissions.Model.EntityItem>(this.Entities_EntityList);
            }
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Principal_EntityId = this.Principal_EntityId;
            context.Principal_EntityType = this.Principal_EntityType;
            context.Resource_EntityId = this.Resource_EntityId;
            context.Resource_EntityType = this.Resource_EntityType;
            
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
            var request = new Amazon.VerifiedPermissions.Model.IsAuthorizedRequest();
            
            
             // populate Action
            var requestActionIsNull = true;
            request.Action = new Amazon.VerifiedPermissions.Model.ActionIdentifier();
            System.String requestAction_action_ActionId = null;
            if (cmdletContext.Action_ActionId != null)
            {
                requestAction_action_ActionId = cmdletContext.Action_ActionId;
            }
            if (requestAction_action_ActionId != null)
            {
                request.Action.ActionId = requestAction_action_ActionId;
                requestActionIsNull = false;
            }
            System.String requestAction_action_ActionType = null;
            if (cmdletContext.Action_ActionType != null)
            {
                requestAction_action_ActionType = cmdletContext.Action_ActionType;
            }
            if (requestAction_action_ActionType != null)
            {
                request.Action.ActionType = requestAction_action_ActionType;
                requestActionIsNull = false;
            }
             // determine if request.Action should be set to null
            if (requestActionIsNull)
            {
                request.Action = null;
            }
            
             // populate Context
            var requestContextIsNull = true;
            request.Context = new Amazon.VerifiedPermissions.Model.ContextDefinition();
            System.String requestContext_context_CedarJson = null;
            if (cmdletContext.Context_CedarJson != null)
            {
                requestContext_context_CedarJson = cmdletContext.Context_CedarJson;
            }
            if (requestContext_context_CedarJson != null)
            {
                request.Context.CedarJson = requestContext_context_CedarJson;
                requestContextIsNull = false;
            }
            Dictionary<System.String, Amazon.VerifiedPermissions.Model.AttributeValue> requestContext_context_ContextMap = null;
            if (cmdletContext.Context_ContextMap != null)
            {
                requestContext_context_ContextMap = cmdletContext.Context_ContextMap;
            }
            if (requestContext_context_ContextMap != null)
            {
                request.Context.ContextMap = requestContext_context_ContextMap;
                requestContextIsNull = false;
            }
             // determine if request.Context should be set to null
            if (requestContextIsNull)
            {
                request.Context = null;
            }
            
             // populate Entities
            var requestEntitiesIsNull = true;
            request.Entities = new Amazon.VerifiedPermissions.Model.EntitiesDefinition();
            System.String requestEntities_entities_CedarJson = null;
            if (cmdletContext.Entities_CedarJson != null)
            {
                requestEntities_entities_CedarJson = cmdletContext.Entities_CedarJson;
            }
            if (requestEntities_entities_CedarJson != null)
            {
                request.Entities.CedarJson = requestEntities_entities_CedarJson;
                requestEntitiesIsNull = false;
            }
            List<Amazon.VerifiedPermissions.Model.EntityItem> requestEntities_entities_EntityList = null;
            if (cmdletContext.Entities_EntityList != null)
            {
                requestEntities_entities_EntityList = cmdletContext.Entities_EntityList;
            }
            if (requestEntities_entities_EntityList != null)
            {
                request.Entities.EntityList = requestEntities_entities_EntityList;
                requestEntitiesIsNull = false;
            }
             // determine if request.Entities should be set to null
            if (requestEntitiesIsNull)
            {
                request.Entities = null;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
            }
            
             // populate Principal
            var requestPrincipalIsNull = true;
            request.Principal = new Amazon.VerifiedPermissions.Model.EntityIdentifier();
            System.String requestPrincipal_principal_EntityId = null;
            if (cmdletContext.Principal_EntityId != null)
            {
                requestPrincipal_principal_EntityId = cmdletContext.Principal_EntityId;
            }
            if (requestPrincipal_principal_EntityId != null)
            {
                request.Principal.EntityId = requestPrincipal_principal_EntityId;
                requestPrincipalIsNull = false;
            }
            System.String requestPrincipal_principal_EntityType = null;
            if (cmdletContext.Principal_EntityType != null)
            {
                requestPrincipal_principal_EntityType = cmdletContext.Principal_EntityType;
            }
            if (requestPrincipal_principal_EntityType != null)
            {
                request.Principal.EntityType = requestPrincipal_principal_EntityType;
                requestPrincipalIsNull = false;
            }
             // determine if request.Principal should be set to null
            if (requestPrincipalIsNull)
            {
                request.Principal = null;
            }
            
             // populate Resource
            var requestResourceIsNull = true;
            request.Resource = new Amazon.VerifiedPermissions.Model.EntityIdentifier();
            System.String requestResource_resource_EntityId = null;
            if (cmdletContext.Resource_EntityId != null)
            {
                requestResource_resource_EntityId = cmdletContext.Resource_EntityId;
            }
            if (requestResource_resource_EntityId != null)
            {
                request.Resource.EntityId = requestResource_resource_EntityId;
                requestResourceIsNull = false;
            }
            System.String requestResource_resource_EntityType = null;
            if (cmdletContext.Resource_EntityType != null)
            {
                requestResource_resource_EntityType = cmdletContext.Resource_EntityType;
            }
            if (requestResource_resource_EntityType != null)
            {
                request.Resource.EntityType = requestResource_resource_EntityType;
                requestResourceIsNull = false;
            }
             // determine if request.Resource should be set to null
            if (requestResourceIsNull)
            {
                request.Resource = null;
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
        
        private Amazon.VerifiedPermissions.Model.IsAuthorizedResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.IsAuthorizedRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "IsAuthorized");
            try
            {
                #if DESKTOP
                return client.IsAuthorized(request);
                #elif CORECLR
                return client.IsAuthorizedAsync(request).GetAwaiter().GetResult();
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
            public System.String Action_ActionId { get; set; }
            public System.String Action_ActionType { get; set; }
            public System.String Context_CedarJson { get; set; }
            public Dictionary<System.String, Amazon.VerifiedPermissions.Model.AttributeValue> Context_ContextMap { get; set; }
            public System.String Entities_CedarJson { get; set; }
            public List<Amazon.VerifiedPermissions.Model.EntityItem> Entities_EntityList { get; set; }
            public System.String PolicyStoreId { get; set; }
            public System.String Principal_EntityId { get; set; }
            public System.String Principal_EntityType { get; set; }
            public System.String Resource_EntityId { get; set; }
            public System.String Resource_EntityType { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.IsAuthorizedResponse, TestAVPAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
