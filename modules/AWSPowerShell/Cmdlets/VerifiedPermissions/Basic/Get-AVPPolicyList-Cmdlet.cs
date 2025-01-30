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
    /// Returns a paginated list of all policies stored in the specified policy store.
    /// </summary>
    [Cmdlet("Get", "AVPPolicyList")]
    [OutputType("Amazon.VerifiedPermissions.Model.PolicyItem")]
    [AWSCmdlet("Calls the Amazon Verified Permissions ListPolicies API operation.", Operation = new[] {"ListPolicies"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.ListPoliciesResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.PolicyItem or Amazon.VerifiedPermissions.Model.ListPoliciesResponse",
        "This cmdlet returns a collection of Amazon.VerifiedPermissions.Model.PolicyItem objects.",
        "The service call response (type Amazon.VerifiedPermissions.Model.ListPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAVPPolicyListCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_Principal_Identifier_EntityId
        /// <summary>
        /// <para>
        /// <para>The identifier of an entity.</para><para><c>"entityId":"<i>identifier</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_EntityId")]
        public System.String Filter_Principal_Identifier_EntityId { get; set; }
        #endregion
        
        #region Parameter Filter_Resource_Identifier_EntityId
        /// <summary>
        /// <para>
        /// <para>The identifier of an entity.</para><para><c>"entityId":"<i>identifier</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_EntityId")]
        public System.String Filter_Resource_Identifier_EntityId { get; set; }
        #endregion
        
        #region Parameter Filter_Principal_Identifier_EntityType
        /// <summary>
        /// <para>
        /// <para>The type of an entity.</para><para>Example: <c>"entityType":"<i>typeName</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_EntityType")]
        public System.String Filter_Principal_Identifier_EntityType { get; set; }
        #endregion
        
        #region Parameter Filter_Resource_Identifier_EntityType
        /// <summary>
        /// <para>
        /// <para>The type of an entity.</para><para>Example: <c>"entityType":"<i>typeName</i>"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resource_EntityType")]
        public System.String Filter_Resource_Identifier_EntityType { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store you want to list policies from.</para>
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
        
        #region Parameter Filter_PolicyTemplateId
        /// <summary>
        /// <para>
        /// <para>Filters the output to only template-linked policies that were instantiated from the
        /// specified policy template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_PolicyTemplateId { get; set; }
        #endregion
        
        #region Parameter Filter_PolicyType
        /// <summary>
        /// <para>
        /// <para>Filters the output to only policies of the specified type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VerifiedPermissions.PolicyType")]
        public Amazon.VerifiedPermissions.PolicyType Filter_PolicyType { get; set; }
        #endregion
        
        #region Parameter Principal_Unspecified
        /// <summary>
        /// <para>
        /// <para>Used to indicate that a principal or resource is not specified. This can be used to
        /// search for policies that are not associated with a specific principal or resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Principal_Unspecified")]
        public System.Boolean? Principal_Unspecified { get; set; }
        #endregion
        
        #region Parameter Resource_Unspecified
        /// <summary>
        /// <para>
        /// <para>Used to indicate that a principal or resource is not specified. This can be used to
        /// search for policies that are not associated with a specific principal or resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Resource_Unspecified")]
        public System.Boolean? Resource_Unspecified { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the total number of results that you want included in each response. If
        /// additional items exist beyond the number you specify, the <c>NextToken</c> response
        /// element is returned with a value (not null). Include the specified value as the <c>NextToken</c>
        /// request parameter in the next call to the operation to get the next set of results.
        /// Note that the service might return fewer results than the maximum even when there
        /// are more results available. You should check <c>NextToken</c> after every operation
        /// to ensure that you receive all of the results.</para><para>If you do not specify this parameter, the operation defaults to 10 policies per response.
        /// You can specify a maximum of 50 policies per response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specifies that you want to receive the next page of results. Valid only if you received
        /// a <c>NextToken</c> response in the previous request. If you did, it indicates that
        /// more output is available. Set this parameter to the value provided by the previous
        /// call's <c>NextToken</c> response to request the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Policies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.ListPoliciesResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.ListPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Policies";
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
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.ListPoliciesResponse, GetAVPPolicyListCmdlet>(Select) ??
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
            context.Filter_PolicyTemplateId = this.Filter_PolicyTemplateId;
            context.Filter_PolicyType = this.Filter_PolicyType;
            context.Filter_Principal_Identifier_EntityId = this.Filter_Principal_Identifier_EntityId;
            context.Filter_Principal_Identifier_EntityType = this.Filter_Principal_Identifier_EntityType;
            context.Principal_Unspecified = this.Principal_Unspecified;
            context.Filter_Resource_Identifier_EntityId = this.Filter_Resource_Identifier_EntityId;
            context.Filter_Resource_Identifier_EntityType = this.Filter_Resource_Identifier_EntityType;
            context.Resource_Unspecified = this.Resource_Unspecified;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
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
            var request = new Amazon.VerifiedPermissions.Model.ListPoliciesRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.VerifiedPermissions.Model.PolicyFilter();
            System.String requestFilter_filter_PolicyTemplateId = null;
            if (cmdletContext.Filter_PolicyTemplateId != null)
            {
                requestFilter_filter_PolicyTemplateId = cmdletContext.Filter_PolicyTemplateId;
            }
            if (requestFilter_filter_PolicyTemplateId != null)
            {
                request.Filter.PolicyTemplateId = requestFilter_filter_PolicyTemplateId;
                requestFilterIsNull = false;
            }
            Amazon.VerifiedPermissions.PolicyType requestFilter_filter_PolicyType = null;
            if (cmdletContext.Filter_PolicyType != null)
            {
                requestFilter_filter_PolicyType = cmdletContext.Filter_PolicyType;
            }
            if (requestFilter_filter_PolicyType != null)
            {
                request.Filter.PolicyType = requestFilter_filter_PolicyType;
                requestFilterIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.EntityReference requestFilter_filter_Principal = null;
            
             // populate Principal
            var requestFilter_filter_PrincipalIsNull = true;
            requestFilter_filter_Principal = new Amazon.VerifiedPermissions.Model.EntityReference();
            System.Boolean? requestFilter_filter_Principal_principal_Unspecified = null;
            if (cmdletContext.Principal_Unspecified != null)
            {
                requestFilter_filter_Principal_principal_Unspecified = cmdletContext.Principal_Unspecified.Value;
            }
            if (requestFilter_filter_Principal_principal_Unspecified != null)
            {
                requestFilter_filter_Principal.Unspecified = requestFilter_filter_Principal_principal_Unspecified.Value;
                requestFilter_filter_PrincipalIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.EntityIdentifier requestFilter_filter_Principal_filter_Principal_Identifier = null;
            
             // populate Identifier
            var requestFilter_filter_Principal_filter_Principal_IdentifierIsNull = true;
            requestFilter_filter_Principal_filter_Principal_Identifier = new Amazon.VerifiedPermissions.Model.EntityIdentifier();
            System.String requestFilter_filter_Principal_filter_Principal_Identifier_filter_Principal_Identifier_EntityId = null;
            if (cmdletContext.Filter_Principal_Identifier_EntityId != null)
            {
                requestFilter_filter_Principal_filter_Principal_Identifier_filter_Principal_Identifier_EntityId = cmdletContext.Filter_Principal_Identifier_EntityId;
            }
            if (requestFilter_filter_Principal_filter_Principal_Identifier_filter_Principal_Identifier_EntityId != null)
            {
                requestFilter_filter_Principal_filter_Principal_Identifier.EntityId = requestFilter_filter_Principal_filter_Principal_Identifier_filter_Principal_Identifier_EntityId;
                requestFilter_filter_Principal_filter_Principal_IdentifierIsNull = false;
            }
            System.String requestFilter_filter_Principal_filter_Principal_Identifier_filter_Principal_Identifier_EntityType = null;
            if (cmdletContext.Filter_Principal_Identifier_EntityType != null)
            {
                requestFilter_filter_Principal_filter_Principal_Identifier_filter_Principal_Identifier_EntityType = cmdletContext.Filter_Principal_Identifier_EntityType;
            }
            if (requestFilter_filter_Principal_filter_Principal_Identifier_filter_Principal_Identifier_EntityType != null)
            {
                requestFilter_filter_Principal_filter_Principal_Identifier.EntityType = requestFilter_filter_Principal_filter_Principal_Identifier_filter_Principal_Identifier_EntityType;
                requestFilter_filter_Principal_filter_Principal_IdentifierIsNull = false;
            }
             // determine if requestFilter_filter_Principal_filter_Principal_Identifier should be set to null
            if (requestFilter_filter_Principal_filter_Principal_IdentifierIsNull)
            {
                requestFilter_filter_Principal_filter_Principal_Identifier = null;
            }
            if (requestFilter_filter_Principal_filter_Principal_Identifier != null)
            {
                requestFilter_filter_Principal.Identifier = requestFilter_filter_Principal_filter_Principal_Identifier;
                requestFilter_filter_PrincipalIsNull = false;
            }
             // determine if requestFilter_filter_Principal should be set to null
            if (requestFilter_filter_PrincipalIsNull)
            {
                requestFilter_filter_Principal = null;
            }
            if (requestFilter_filter_Principal != null)
            {
                request.Filter.Principal = requestFilter_filter_Principal;
                requestFilterIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.EntityReference requestFilter_filter_Resource = null;
            
             // populate Resource
            var requestFilter_filter_ResourceIsNull = true;
            requestFilter_filter_Resource = new Amazon.VerifiedPermissions.Model.EntityReference();
            System.Boolean? requestFilter_filter_Resource_resource_Unspecified = null;
            if (cmdletContext.Resource_Unspecified != null)
            {
                requestFilter_filter_Resource_resource_Unspecified = cmdletContext.Resource_Unspecified.Value;
            }
            if (requestFilter_filter_Resource_resource_Unspecified != null)
            {
                requestFilter_filter_Resource.Unspecified = requestFilter_filter_Resource_resource_Unspecified.Value;
                requestFilter_filter_ResourceIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.EntityIdentifier requestFilter_filter_Resource_filter_Resource_Identifier = null;
            
             // populate Identifier
            var requestFilter_filter_Resource_filter_Resource_IdentifierIsNull = true;
            requestFilter_filter_Resource_filter_Resource_Identifier = new Amazon.VerifiedPermissions.Model.EntityIdentifier();
            System.String requestFilter_filter_Resource_filter_Resource_Identifier_filter_Resource_Identifier_EntityId = null;
            if (cmdletContext.Filter_Resource_Identifier_EntityId != null)
            {
                requestFilter_filter_Resource_filter_Resource_Identifier_filter_Resource_Identifier_EntityId = cmdletContext.Filter_Resource_Identifier_EntityId;
            }
            if (requestFilter_filter_Resource_filter_Resource_Identifier_filter_Resource_Identifier_EntityId != null)
            {
                requestFilter_filter_Resource_filter_Resource_Identifier.EntityId = requestFilter_filter_Resource_filter_Resource_Identifier_filter_Resource_Identifier_EntityId;
                requestFilter_filter_Resource_filter_Resource_IdentifierIsNull = false;
            }
            System.String requestFilter_filter_Resource_filter_Resource_Identifier_filter_Resource_Identifier_EntityType = null;
            if (cmdletContext.Filter_Resource_Identifier_EntityType != null)
            {
                requestFilter_filter_Resource_filter_Resource_Identifier_filter_Resource_Identifier_EntityType = cmdletContext.Filter_Resource_Identifier_EntityType;
            }
            if (requestFilter_filter_Resource_filter_Resource_Identifier_filter_Resource_Identifier_EntityType != null)
            {
                requestFilter_filter_Resource_filter_Resource_Identifier.EntityType = requestFilter_filter_Resource_filter_Resource_Identifier_filter_Resource_Identifier_EntityType;
                requestFilter_filter_Resource_filter_Resource_IdentifierIsNull = false;
            }
             // determine if requestFilter_filter_Resource_filter_Resource_Identifier should be set to null
            if (requestFilter_filter_Resource_filter_Resource_IdentifierIsNull)
            {
                requestFilter_filter_Resource_filter_Resource_Identifier = null;
            }
            if (requestFilter_filter_Resource_filter_Resource_Identifier != null)
            {
                requestFilter_filter_Resource.Identifier = requestFilter_filter_Resource_filter_Resource_Identifier;
                requestFilter_filter_ResourceIsNull = false;
            }
             // determine if requestFilter_filter_Resource should be set to null
            if (requestFilter_filter_ResourceIsNull)
            {
                requestFilter_filter_Resource = null;
            }
            if (requestFilter_filter_Resource != null)
            {
                request.Filter.Resource = requestFilter_filter_Resource;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.VerifiedPermissions.Model.ListPoliciesResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.ListPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "ListPolicies");
            try
            {
                #if DESKTOP
                return client.ListPolicies(request);
                #elif CORECLR
                return client.ListPoliciesAsync(request).GetAwaiter().GetResult();
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
            public System.String Filter_PolicyTemplateId { get; set; }
            public Amazon.VerifiedPermissions.PolicyType Filter_PolicyType { get; set; }
            public System.String Filter_Principal_Identifier_EntityId { get; set; }
            public System.String Filter_Principal_Identifier_EntityType { get; set; }
            public System.Boolean? Principal_Unspecified { get; set; }
            public System.String Filter_Resource_Identifier_EntityId { get; set; }
            public System.String Filter_Resource_Identifier_EntityType { get; set; }
            public System.Boolean? Resource_Unspecified { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PolicyStoreId { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.ListPoliciesResponse, GetAVPPolicyListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policies;
        }
        
    }
}
