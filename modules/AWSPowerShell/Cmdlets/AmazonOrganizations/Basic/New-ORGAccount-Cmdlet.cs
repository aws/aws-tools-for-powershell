/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Organizations;
using Amazon.Organizations.Model;

namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// Creates an AWS account that is automatically a member of the organization whose credentials
    /// made the request. This is an asynchronous request that AWS performs in the background.
    /// If you want to check the status of the request later, you need the <code>OperationId</code>
    /// response element from this operation to provide as a parameter to the <a>DescribeCreateAccountStatus</a>
    /// operation.
    /// 
    ///  
    /// <para>
    /// AWS Organizations preconfigures the new member account with a role (named <code>OrganizationAccountAccessRole</code>
    /// by default) that grants administrator permissions to the new account. Principals in
    /// the master account can assume the role. AWS Organizations clones the company name
    /// and address information for the new account from the organization's master account.
    /// </para><para>
    /// For more information about creating accounts, see <a href="http://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts_create.html">Creating
    /// an AWS Account in Your Organization</a> in the <i>AWS Organizations User Guide</i>.
    /// </para><important><para>
    /// When you create an account in an organization using the AWS Organizations console,
    /// API, or CLI commands, the information required for the account to operate as a standalone
    /// account, such as a payment method and signing the End User Licence Agreement (EULA)
    /// is <i>not</i> automatically collected. If you must remove an account from your organization
    /// later, you can do so only after you provide the missing information. Follow the steps
    /// at <a href="http://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts_remove.html#leave-without-all-info">
    /// To leave an organization when all required account information has not yet been provided</a>
    /// in the <i>AWS Organizations User Guide</i>.
    /// </para></important><note><para>
    /// When you create a member account with this operation, you can choose whether to create
    /// the account with the <b>IAM User and Role Access to Billing Information</b> switch
    /// enabled. If you enable it, IAM users and roles that have appropriate permissions can
    /// view billing information for the account. If you disable this, then only the account
    /// root user can access billing information. For information about how to disable this
    /// for an account, see <a href="http://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/grantaccess.html">Granting
    /// Access to Your Billing Information and Tools</a>.
    /// </para></note><para>
    /// This operation can be called only from the organization's master account.
    /// </para><important><para>
    /// If you get an exception that indicates that you exceeded your account limits for the
    /// organization or that you can"t add an account because your organization is still initializing,
    /// please contact <a href="https://console.aws.amazon.com/support/home#/"> AWS Customer
    /// Support</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "ORGAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.CreateAccountStatus")]
    [AWSCmdlet("Invokes the CreateAccount operation against AWS Organizations.", Operation = new[] {"CreateAccount"})]
    [AWSCmdletOutput("Amazon.Organizations.Model.CreateAccountStatus",
        "This cmdlet returns a CreateAccountStatus object.",
        "The service call response (type Amazon.Organizations.Model.CreateAccountResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewORGAccountCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        #region Parameter AccountName
        /// <summary>
        /// <para>
        /// <para>The friendly name of the member account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String AccountName { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address of the owner to assign to the new member account. This email address
        /// must not already be associated with another AWS account. You must use a valid email
        /// address to complete account creation. You cannot access the root user of the account
        /// or remove an account that was created with an invalid email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter IamUserAccessToBilling
        /// <summary>
        /// <para>
        /// <para>If set to <code>ALLOW</code>, the new account enables IAM users to access account
        /// billing information <i>if</i> they have the required permissions. If set to <code>DENY</code>,
        /// then only the root user of the new account can access account billing information.
        /// For more information, see <a href="http://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/grantaccess.html#ControllingAccessWebsite-Activate">Activating
        /// Access to the Billing and Cost Management Console</a> in the <i>AWS Billing and Cost
        /// Management User Guide</i>.</para><para>If you do not specify this parameter, the value defaults to ALLOW, and IAM users and
        /// roles with the required permissions can access billing information for the new account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Organizations.IAMUserAccessToBilling")]
        public Amazon.Organizations.IAMUserAccessToBilling IamUserAccessToBilling { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>(Optional)</para><para>The name of an IAM role that Organizations automatically preconfigures in the new
        /// member account. This role trusts the master account, allowing users in the master
        /// account to assume the role, as permitted by the master account administrator. The
        /// role has administrator permissions in the new member account.</para><para>If you do not specify this parameter, the role name defaults to <code>OrganizationAccountAccessRole</code>.</para><para>For more information about how to use this role to access the member account, see
        /// <a href="http://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts_access.html#orgs_manage_accounts_create-cross-account-role">Accessing
        /// and Administering the Member Accounts in Your Organization</a> in the <i>AWS Organizations
        /// User Guide</i>, and steps 2 and 3 in <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/tutorial_cross-account-with-roles.html">Tutorial:
        /// Delegate Access Across AWS Accounts Using IAM Roles</a> in the <i>IAM User Guide</i>.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> that is used to validate
        /// this parameter is a string of characters that can consist of uppercase letters, lowercase
        /// letters, digits with no spaces, and any of the following characters: =,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AccountName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ORGAccount (CreateAccount)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AccountName = this.AccountName;
            context.Email = this.Email;
            context.IamUserAccessToBilling = this.IamUserAccessToBilling;
            context.RoleName = this.RoleName;
            
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
            var request = new Amazon.Organizations.Model.CreateAccountRequest();
            
            if (cmdletContext.AccountName != null)
            {
                request.AccountName = cmdletContext.AccountName;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.IamUserAccessToBilling != null)
            {
                request.IamUserAccessToBilling = cmdletContext.IamUserAccessToBilling;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CreateAccountStatus;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Organizations.Model.CreateAccountResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.CreateAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "CreateAccount");
            try
            {
                #if DESKTOP
                return client.CreateAccount(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateAccountAsync(request);
                return task.Result;
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
            public System.String AccountName { get; set; }
            public System.String Email { get; set; }
            public Amazon.Organizations.IAMUserAccessToBilling IamUserAccessToBilling { get; set; }
            public System.String RoleName { get; set; }
        }
        
    }
}
