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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Creates a member association in Security Hub between the specified accounts and the
    /// account used to make the request, which is the master account. To successfully create
    /// a member, you must use this action from an account that already has Security Hub enabled.
    /// To enable Security Hub, you can use the <code><a>EnableSecurityHub</a></code> operation.
    /// 
    ///  
    /// <para>
    /// After you use <code>CreateMembers</code> to create member account associations in
    /// Security Hub, you must use the <code><a>InviteMembers</a></code> operation to invite
    /// the accounts to enable Security Hub and become member accounts in Security Hub.
    /// </para><para>
    /// If the account owner accepts the invitation, the account becomes a member account
    /// in Security Hub, and a permission policy is added that permits the master account
    /// to view the findings generated in the member account. When Security Hub is enabled
    /// in the invited account, findings start to be sent to both the member and master accounts.
    /// </para><para>
    /// To remove the association between the master and member accounts, use the <code><a>DisassociateFromMasterAccount</a></code> or <code><a>DisassociateMembers</a></code> operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SHUBMember", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.Result")]
    [AWSCmdlet("Calls the AWS Security Hub CreateMembers API operation.", Operation = new[] {"CreateMembers"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.CreateMembersResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.Result or Amazon.SecurityHub.Model.CreateMembersResponse",
        "This cmdlet returns a collection of Amazon.SecurityHub.Model.Result objects.",
        "The service call response (type Amazon.SecurityHub.Model.CreateMembersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSHUBMemberCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        #region Parameter AccountDetail
        /// <summary>
        /// <para>
        /// <para>The list of accounts to associate with the Security Hub master account. For each account,
        /// the list includes the account ID and the email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("AccountDetails")]
        public Amazon.SecurityHub.Model.AccountDetails[] AccountDetail { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UnprocessedAccounts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.CreateMembersResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.CreateMembersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UnprocessedAccounts";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountDetail parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountDetail' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountDetail' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountDetail), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SHUBMember (CreateMembers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.CreateMembersResponse, NewSHUBMemberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountDetail;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccountDetail != null)
            {
                context.AccountDetail = new List<Amazon.SecurityHub.Model.AccountDetails>(this.AccountDetail);
            }
            
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
            var request = new Amazon.SecurityHub.Model.CreateMembersRequest();
            
            if (cmdletContext.AccountDetail != null)
            {
                request.AccountDetails = cmdletContext.AccountDetail;
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
        
        private Amazon.SecurityHub.Model.CreateMembersResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.CreateMembersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "CreateMembers");
            try
            {
                #if DESKTOP
                return client.CreateMembers(request);
                #elif CORECLR
                return client.CreateMembersAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.AccountDetails> AccountDetail { get; set; }
            public System.Func<Amazon.SecurityHub.Model.CreateMembersResponse, NewSHUBMemberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UnprocessedAccounts;
        }
        
    }
}
