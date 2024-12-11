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
    /// Makes a series of decisions about multiple authorization requests for one principal
    /// or resource. Each request contains the equivalent content of an <c>IsAuthorized</c>
    /// request: principal, action, resource, and context. Either the <c>principal</c> or
    /// the <c>resource</c> parameter must be identical across all requests. For example,
    /// Verified Permissions won't evaluate a pair of requests where <c>bob</c> views <c>photo1</c>
    /// and <c>alice</c> views <c>photo2</c>. Authorization of <c>bob</c> to view <c>photo1</c>
    /// and <c>photo2</c>, or <c>bob</c> and <c>alice</c> to view <c>photo1</c>, are valid
    /// batches. 
    /// 
    ///  
    /// <para>
    /// The request is evaluated against all policies in the specified policy store that match
    /// the entities that you declare. The result of the decisions is a series of <c>Allow</c>
    /// or <c>Deny</c> responses, along with the IDs of the policies that produced each decision.
    /// </para><para>
    /// The <c>entities</c> of a <c>BatchIsAuthorized</c> API request can contain up to 100
    /// principals and up to 100 resources. The <c>requests</c> of a <c>BatchIsAuthorized</c>
    /// API request can contain up to 30 requests.
    /// </para><note><para>
    /// The <c>BatchIsAuthorized</c> operation doesn't have its own IAM permission. To authorize
    /// this operation for Amazon Web Services principals, include the permission <c>verifiedpermissions:IsAuthorized</c>
    /// in their IAM policies.
    /// </para></note>
    /// </summary>
    [Cmdlet("Test", "AVPBatchAuthorization")]
    [OutputType("Amazon.VerifiedPermissions.Model.BatchIsAuthorizedOutputItem")]
    [AWSCmdlet("Calls the Amazon Verified Permissions BatchIsAuthorized API operation.", Operation = new[] {"BatchIsAuthorized"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.BatchIsAuthorizedResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.BatchIsAuthorizedOutputItem or Amazon.VerifiedPermissions.Model.BatchIsAuthorizedResponse",
        "This cmdlet returns a collection of Amazon.VerifiedPermissions.Model.BatchIsAuthorizedOutputItem objects.",
        "The service call response (type Amazon.VerifiedPermissions.Model.BatchIsAuthorizedResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestAVPBatchAuthorizationCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Entities_EntityList
        /// <summary>
        /// <para>
        /// <para>An array of entities that are needed to successfully evaluate an authorization request.
        /// Each entity in this array must include an identifier for the entity, the attributes
        /// of the entity, and a list of any parent entities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.VerifiedPermissions.Model.EntityItem[] Entities_EntityList { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store. Policies in this policy store will be used to
        /// make the authorization decisions for the input.</para>
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
        public Amazon.VerifiedPermissions.Model.BatchIsAuthorizedInputItem[] Request { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.BatchIsAuthorizedResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.BatchIsAuthorizedResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.BatchIsAuthorizedResponse, TestAVPBatchAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            if (this.Request != null)
            {
                context.Request = new List<Amazon.VerifiedPermissions.Model.BatchIsAuthorizedInputItem>(this.Request);
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
            var request = new Amazon.VerifiedPermissions.Model.BatchIsAuthorizedRequest();
            
            
             // populate Entities
            var requestEntitiesIsNull = true;
            request.Entities = new Amazon.VerifiedPermissions.Model.EntitiesDefinition();
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
        
        private Amazon.VerifiedPermissions.Model.BatchIsAuthorizedResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.BatchIsAuthorizedRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "BatchIsAuthorized");
            try
            {
                #if DESKTOP
                return client.BatchIsAuthorized(request);
                #elif CORECLR
                return client.BatchIsAuthorizedAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.VerifiedPermissions.Model.EntityItem> Entities_EntityList { get; set; }
            public System.String PolicyStoreId { get; set; }
            public List<Amazon.VerifiedPermissions.Model.BatchIsAuthorizedInputItem> Request { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.BatchIsAuthorizedResponse, TestAVPBatchAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
