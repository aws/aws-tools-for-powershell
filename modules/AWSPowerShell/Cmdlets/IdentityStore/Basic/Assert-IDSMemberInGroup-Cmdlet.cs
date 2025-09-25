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
using Amazon.IdentityStore;
using Amazon.IdentityStore.Model;

namespace Amazon.PowerShell.Cmdlets.IDS
{
    /// <summary>
    /// Checks the user's membership in all requested groups and returns if the member exists
    /// in all queried groups.
    /// 
    ///  <note><para>
    /// If you have administrator access to a member account, you can use this API from the
    /// member account. Read about <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts_access.html">member
    /// accounts</a> in the <i>Organizations User Guide</i>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Assert", "IDSMemberInGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityStore.Model.GroupMembershipExistenceResult")]
    [AWSCmdlet("Calls the AWS Identity Store IsMemberInGroups API operation.", Operation = new[] {"IsMemberInGroups"}, SelectReturnType = typeof(Amazon.IdentityStore.Model.IsMemberInGroupsResponse))]
    [AWSCmdletOutput("Amazon.IdentityStore.Model.GroupMembershipExistenceResult or Amazon.IdentityStore.Model.IsMemberInGroupsResponse",
        "This cmdlet returns a collection of Amazon.IdentityStore.Model.GroupMembershipExistenceResult objects.",
        "The service call response (type Amazon.IdentityStore.Model.IsMemberInGroupsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AssertIDSMemberInGroupCmdlet : AmazonIdentityStoreClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>A list of identifiers for groups in the identity store.</para>
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
        [Alias("GroupIds")]
        public System.String[] GroupId { get; set; }
        #endregion
        
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityStore.Model.IsMemberInGroupsResponse).
        /// Specifying the name of a property of type Amazon.IdentityStore.Model.IsMemberInGroupsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IdentityStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IdentityStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IdentityStoreId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentityStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Assert-IDSMemberInGroup (IsMemberInGroups)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityStore.Model.IsMemberInGroupsResponse, AssertIDSMemberInGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IdentityStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.GroupId != null)
            {
                context.GroupId = new List<System.String>(this.GroupId);
            }
            #if MODULAR
            if (this.GroupId == null && ParameterWasBound(nameof(this.GroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityStoreId = this.IdentityStoreId;
            #if MODULAR
            if (this.IdentityStoreId == null && ParameterWasBound(nameof(this.IdentityStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MemberId_UserId = this.MemberId_UserId;
            
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
            var request = new Amazon.IdentityStore.Model.IsMemberInGroupsRequest();
            
            if (cmdletContext.GroupId != null)
            {
                request.GroupIds = cmdletContext.GroupId;
            }
            if (cmdletContext.IdentityStoreId != null)
            {
                request.IdentityStoreId = cmdletContext.IdentityStoreId;
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
        
        private Amazon.IdentityStore.Model.IsMemberInGroupsResponse CallAWSServiceOperation(IAmazonIdentityStore client, Amazon.IdentityStore.Model.IsMemberInGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity Store", "IsMemberInGroups");
            try
            {
                #if DESKTOP
                return client.IsMemberInGroups(request);
                #elif CORECLR
                return client.IsMemberInGroupsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> GroupId { get; set; }
            public System.String IdentityStoreId { get; set; }
            public System.String MemberId_UserId { get; set; }
            public System.Func<Amazon.IdentityStore.Model.IsMemberInGroupsResponse, AssertIDSMemberInGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
