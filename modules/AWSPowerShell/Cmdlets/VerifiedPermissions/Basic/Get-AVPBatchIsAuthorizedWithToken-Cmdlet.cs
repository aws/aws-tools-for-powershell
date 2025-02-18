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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Makes a series of decisions about multiple authorization requests for one token. The
    /// principal in this request comes from an external identity source in the form of an
    /// identity or access token, formatted as a <a href="https://wikipedia.org/wiki/JSON_Web_Token">JSON
    /// web token (JWT)</a>. The information in the parameters can also define additional
    /// context that Verified Permissions can include in the evaluations.
    /// 
    ///  
    /// <para>
    /// The request is evaluated against all policies in the specified policy store that match
    /// the entities that you provide in the entities declaration and in the token. The result
    /// of the decisions is a series of <c>Allow</c> or <c>Deny</c> responses, along with
    /// the IDs of the policies that produced each decision.
    /// </para><para>
    /// The <c>entities</c> of a <c>BatchIsAuthorizedWithToken</c> API request can contain
    /// up to 100 resources and up to 99 user groups. The <c>requests</c> of a <c>BatchIsAuthorizedWithToken</c>
    /// API request can contain up to 30 requests.
    /// </para><note><para>
    /// The <c>BatchIsAuthorizedWithToken</c> operation doesn't have its own IAM permission.
    /// To authorize this operation for Amazon Web Services principals, include the permission
    /// <c>verifiedpermissions:IsAuthorizedWithToken</c> in their IAM policies.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "AVPBatchIsAuthorizedWithToken")]
    [OutputType("Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions BatchIsAuthorizedWithToken API operation.", Operation = new[] {"BatchIsAuthorizedWithToken"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenResponse object containing multiple properties."
    )]
    public partial class GetAVPBatchIsAuthorizedWithTokenCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessToken
        /// <summary>
        /// <para>
        /// <para>Specifies an access token for the principal that you want to authorize in each request.
        /// This token is provided to you by the identity provider (IdP) associated with the specified
        /// identity source. You must specify either an <c>accessToken</c>, an <c>identityToken</c>,
        /// or both.</para><para>Must be an access token. Verified Permissions returns an error if the <c>token_use</c>
        /// claim in the submitted token isn't <c>access</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessToken { get; set; }
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
        
        #region Parameter IdentityToken
        /// <summary>
        /// <para>
        /// <para>Specifies an identity (ID) token for the principal that you want to authorize in each
        /// request. This token is provided to you by the identity provider (IdP) associated with
        /// the specified identity source. You must specify either an <c>accessToken</c>, an <c>identityToken</c>,
        /// or both.</para><para>Must be an ID token. Verified Permissions returns an error if the <c>token_use</c>
        /// claim in the submitted token isn't <c>id</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityToken { get; set; }
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
        
        #region Parameter Request
        /// <summary>
        /// <para>
        /// <para>An array of up to 30 requests that you want Verified Permissions to evaluate.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Requests")]
        public Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenInputItem[] Request { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenResponse, GetAVPBatchIsAuthorizedWithTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessToken = this.AccessToken;
            context.Entities_CedarJson = this.Entities_CedarJson;
            if (this.Entities_EntityList != null)
            {
                context.Entities_EntityList = new List<Amazon.VerifiedPermissions.Model.EntityItem>(this.Entities_EntityList);
            }
            context.IdentityToken = this.IdentityToken;
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Request != null)
            {
                context.Request = new List<Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenInputItem>(this.Request);
            }
            #if MODULAR
            if (this.Request == null && ParameterWasBound(nameof(this.Request)))
            {
                WriteWarning("You are passing $null as a value for parameter Request which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenRequest();
            
            if (cmdletContext.AccessToken != null)
            {
                request.AccessToken = cmdletContext.AccessToken;
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
            if (cmdletContext.IdentityToken != null)
            {
                request.IdentityToken = cmdletContext.IdentityToken;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
            }
            if (cmdletContext.Request != null)
            {
                request.Requests = cmdletContext.Request;
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
        
        private Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "BatchIsAuthorizedWithToken");
            try
            {
                return client.BatchIsAuthorizedWithTokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccessToken { get; set; }
            public System.String Entities_CedarJson { get; set; }
            public List<Amazon.VerifiedPermissions.Model.EntityItem> Entities_EntityList { get; set; }
            public System.String IdentityToken { get; set; }
            public System.String PolicyStoreId { get; set; }
            public List<Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenInputItem> Request { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.BatchIsAuthorizedWithTokenResponse, GetAVPBatchIsAuthorizedWithTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
