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
using Amazon.IdentityStore;
using Amazon.IdentityStore.Model;

namespace Amazon.PowerShell.Cmdlets.IDS
{
    /// <summary>
    /// For the specified member in the specified identity store, returns the list of all
    /// <c>GroupMembership</c> objects and returns results in paginated form.
    /// 
    ///  <note><para>
    /// If you have administrator access to a member account, you can use this API from the
    /// member account. Read about <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts_access.html">member
    /// accounts</a> in the <i>Organizations User Guide</i>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "IDSGroupMembershipsForMemberList")]
    [OutputType("Amazon.IdentityStore.Model.GroupMembership")]
    [AWSCmdlet("Calls the AWS Identity Store ListGroupMembershipsForMember API operation.", Operation = new[] {"ListGroupMembershipsForMember"}, SelectReturnType = typeof(Amazon.IdentityStore.Model.ListGroupMembershipsForMemberResponse))]
    [AWSCmdletOutput("Amazon.IdentityStore.Model.GroupMembership or Amazon.IdentityStore.Model.ListGroupMembershipsForMemberResponse",
        "This cmdlet returns a collection of Amazon.IdentityStore.Model.GroupMembership objects.",
        "The service call response (type Amazon.IdentityStore.Model.ListGroupMembershipsForMemberResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIDSGroupMembershipsForMemberListCmdlet : AmazonIdentityStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdentityStoreId
        /// <summary>
        /// <para>
        /// <para>The globally unique identifier for the identity store.</para>
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
        public System.String IdentityStoreId { get; set; }
        #endregion
        
        #region Parameter MemberId_UserId
        /// <summary>
        /// <para>
        /// <para>An object containing the identifiers of resources that can be members.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MemberId_UserId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned per request. This parameter is used in
        /// the <c>ListUsers</c> and <c>ListGroups</c> requests to specify how many results to
        /// return in one page. The length limit is 50 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token used for the <c>ListUsers</c>, <c>ListGroups</c>, and <c>ListGroupMemberships</c>
        /// API operations. This value is generated by the identity store service. It is returned
        /// in the API response if the total results are more than the size of one page. This
        /// token is also returned when it is used in the API request to search for the next page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GroupMemberships'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityStore.Model.ListGroupMembershipsForMemberResponse).
        /// Specifying the name of a property of type Amazon.IdentityStore.Model.ListGroupMembershipsForMemberResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GroupMemberships";
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
                context.Select = CreateSelectDelegate<Amazon.IdentityStore.Model.ListGroupMembershipsForMemberResponse, GetIDSGroupMembershipsForMemberListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentityStoreId = this.IdentityStoreId;
            #if MODULAR
            if (this.IdentityStoreId == null && ParameterWasBound(nameof(this.IdentityStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.MemberId_UserId = this.MemberId_UserId;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.IdentityStore.Model.ListGroupMembershipsForMemberRequest();
            
            if (cmdletContext.IdentityStoreId != null)
            {
                request.IdentityStoreId = cmdletContext.IdentityStoreId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate MemberId
            var requestMemberIdIsNull = true;
            request.MemberId = new Amazon.IdentityStore.Model.MemberId();
            System.String requestMemberId_memberId_UserId = null;
            if (cmdletContext.MemberId_UserId != null)
            {
                requestMemberId_memberId_UserId = cmdletContext.MemberId_UserId;
            }
            if (requestMemberId_memberId_UserId != null)
            {
                request.MemberId.UserId = requestMemberId_memberId_UserId;
                requestMemberIdIsNull = false;
            }
             // determine if request.MemberId should be set to null
            if (requestMemberIdIsNull)
            {
                request.MemberId = null;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.IdentityStore.Model.ListGroupMembershipsForMemberResponse CallAWSServiceOperation(IAmazonIdentityStore client, Amazon.IdentityStore.Model.ListGroupMembershipsForMemberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity Store", "ListGroupMembershipsForMember");
            try
            {
                return client.ListGroupMembershipsForMemberAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IdentityStoreId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String MemberId_UserId { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IdentityStore.Model.ListGroupMembershipsForMemberResponse, GetIDSGroupMembershipsForMemberListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GroupMemberships;
        }
        
    }
}
