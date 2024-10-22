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
    /// account used to make the request, which is the administrator account. If you are integrated
    /// with Organizations, then the administrator account is designated by the organization
    /// management account.
    /// 
    ///  
    /// <para><c>CreateMembers</c> is always used to add accounts that are not organization members.
    /// </para><para>
    /// For accounts that are managed using Organizations, <c>CreateMembers</c> is only used
    /// in the following cases:
    /// </para><ul><li><para>
    /// Security Hub is not configured to automatically add new organization accounts.
    /// </para></li><li><para>
    /// The account was disassociated or deleted in Security Hub.
    /// </para></li></ul><para>
    /// This action can only be used by an account that has Security Hub enabled. To enable
    /// Security Hub, you can use the <c>EnableSecurityHub</c> operation.
    /// </para><para>
    /// For accounts that are not organization members, you create the account association
    /// and then send an invitation to the member account. To send the invitation, you use
    /// the <c>InviteMembers</c> operation. If the account owner accepts the invitation, the
    /// account becomes a member account in Security Hub.
    /// </para><para>
    /// Accounts that are managed using Organizations don't receive an invitation. They automatically
    /// become a member account in Security Hub.
    /// </para><ul><li><para>
    /// If the organization account does not have Security Hub enabled, then Security Hub
    /// and the default standards are automatically enabled. Note that Security Hub cannot
    /// be enabled automatically for the organization management account. The organization
    /// management account must enable Security Hub before the administrator account enables
    /// it as a member account.
    /// </para></li><li><para>
    /// For organization accounts that already have Security Hub enabled, Security Hub does
    /// not make any other changes to those accounts. It does not change their enabled standards
    /// or controls.
    /// </para></li></ul><para>
    /// A permissions policy is added that permits the administrator account to view the findings
    /// generated in the member account.
    /// </para><para>
    /// To remove the association between the administrator and member accounts, use the <c>DisassociateFromMasterAccount</c>
    /// or <c>DisassociateMembers</c> operation.
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
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountDetail
        /// <summary>
        /// <para>
        /// <para>The list of accounts to associate with the Security Hub administrator account. For
        /// each account, the list includes the account ID and optionally the email address.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountDetail), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SHUBMember (CreateMembers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.CreateMembersResponse, NewSHUBMemberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountDetail != null)
            {
                context.AccountDetail = new List<Amazon.SecurityHub.Model.AccountDetails>(this.AccountDetail);
            }
            #if MODULAR
            if (this.AccountDetail == null && ParameterWasBound(nameof(this.AccountDetail)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountDetail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
