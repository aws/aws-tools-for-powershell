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
using Amazon.Organizations;
using Amazon.Organizations.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ORG
{
    /// <summary>
    /// This action is available if all of the following are true:
    /// 
    ///  <ul><li><para>
    /// You're authorized to create accounts in the Amazon Web Services GovCloud (US) Region.
    /// For more information on the Amazon Web Services GovCloud (US) Region, see the <a href="https://docs.aws.amazon.com/govcloud-us/latest/UserGuide/welcome.html"><i>Amazon Web Services GovCloud User Guide</i>.</a></para></li><li><para>
    /// You already have an account in the Amazon Web Services GovCloud (US) Region that is
    /// paired with a management account of an organization in the commercial Region.
    /// </para></li><li><para>
    /// You call this action from the management account of your organization in the commercial
    /// Region.
    /// </para></li><li><para>
    /// You have the <c>organizations:CreateGovCloudAccount</c> permission. 
    /// </para></li></ul><para>
    /// Organizations automatically creates the required service-linked role named <c>AWSServiceRoleForOrganizations</c>.
    /// For more information, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_integrate_services.html#orgs_integrate_services-using_slrs">Organizations
    /// and service-linked roles</a> in the <i>Organizations User Guide</i>.
    /// </para><para>
    /// Amazon Web Services automatically enables CloudTrail for Amazon Web Services GovCloud
    /// (US) accounts, but you should also do the following:
    /// </para><ul><li><para>
    /// Verify that CloudTrail is enabled to store logs.
    /// </para></li><li><para>
    /// Create an Amazon S3 bucket for CloudTrail log storage.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/govcloud-us/latest/UserGuide/verifying-cloudtrail.html">Verifying
    /// CloudTrail Is Enabled</a> in the <i>Amazon Web Services GovCloud User Guide</i>. 
    /// </para></li></ul><para>
    /// If the request includes tags, then the requester must have the <c>organizations:TagResource</c>
    /// permission. The tags are attached to the commercial account associated with the GovCloud
    /// account, rather than the GovCloud account itself. To add tags to the GovCloud account,
    /// call the <a>TagResource</a> operation in the GovCloud Region after the new GovCloud
    /// account exists.
    /// </para><para>
    /// You call this action from the management account of your organization in the commercial
    /// Region to create a standalone Amazon Web Services account in the Amazon Web Services
    /// GovCloud (US) Region. After the account is created, the management account of an organization
    /// in the Amazon Web Services GovCloud (US) Region can invite it to that organization.
    /// For more information on inviting standalone accounts in the Amazon Web Services GovCloud
    /// (US) to join an organization, see <a href="https://docs.aws.amazon.com/govcloud-us/latest/UserGuide/govcloud-organizations.html">Organizations</a>
    /// in the <i>Amazon Web Services GovCloud User Guide</i>.
    /// </para><para>
    /// Calling <c>CreateGovCloudAccount</c> is an asynchronous request that Amazon Web Services
    /// performs in the background. Because <c>CreateGovCloudAccount</c> operates asynchronously,
    /// it can return a successful completion message even though account initialization might
    /// still be in progress. You might need to wait a few minutes before you can successfully
    /// access the account. To check the status of the request, do one of the following:
    /// </para><ul><li><para>
    /// Use the <c>OperationId</c> response element from this operation to provide as a parameter
    /// to the <a>DescribeCreateAccountStatus</a> operation.
    /// </para></li><li><para>
    /// Check the CloudTrail log for the <c>CreateAccountResult</c> event. For information
    /// on using CloudTrail with Organizations, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_security_incident-response.html">Logging
    /// and monitoring in Organizations</a> in the <i>Organizations User Guide</i>.
    /// </para></li></ul><para>
    /// When you call the <c>CreateGovCloudAccount</c> action, you create two accounts: a
    /// standalone account in the Amazon Web Services GovCloud (US) Region and an associated
    /// account in the commercial Region for billing and support purposes. The account in
    /// the commercial Region is automatically a member of the organization whose credentials
    /// made the request. Both accounts are associated with the same email address.
    /// </para><para>
    /// A role is created in the new account in the commercial Region that allows the management
    /// account in the organization in the commercial Region to assume it. An Amazon Web Services
    /// GovCloud (US) account is then created and associated with the commercial account that
    /// you just created. A role is also created in the new Amazon Web Services GovCloud (US)
    /// account that can be assumed by the Amazon Web Services GovCloud (US) account that
    /// is associated with the management account of the commercial organization. For more
    /// information and to view a diagram that explains how account access works, see <a href="https://docs.aws.amazon.com/govcloud-us/latest/UserGuide/govcloud-organizations.html">Organizations</a>
    /// in the <i>Amazon Web Services GovCloud User Guide</i>.
    /// </para><para>
    /// For more information about creating accounts, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts_create.html">Creating
    /// a member account in your organization</a> in the <i>Organizations User Guide</i>.
    /// </para><important><ul><li><para>
    /// When you create an account in an organization using the Organizations console, API,
    /// or CLI commands, the information required for the account to operate as a standalone
    /// account is <i>not</i> automatically collected. This includes a payment method and
    /// signing the end user license agreement (EULA). If you must remove an account from
    /// your organization later, you can do so only after you provide the missing information.
    /// For more information, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_account-before-remove.html">Considerations
    /// before removing an account from an organization</a> in the <i>Organizations User Guide</i>.
    /// </para></li><li><para>
    /// If you get an exception that indicates that you exceeded your account limits for the
    /// organization, contact <a href="https://console.aws.amazon.com/support/home#/">Amazon
    /// Web Services Support</a>.
    /// </para></li><li><para>
    /// If you get an exception that indicates that the operation failed because your organization
    /// is still initializing, wait one hour and then try again. If the error persists, contact
    /// <a href="https://console.aws.amazon.com/support/home#/">Amazon Web Services Support</a>.
    /// </para></li><li><para>
    /// Using <c>CreateGovCloudAccount</c> to create multiple temporary accounts isn't recommended.
    /// You can only close an account from the Amazon Web Services Billing and Cost Management
    /// console, and you must be signed in as the root user. For information on the requirements
    /// and process for closing an account, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts_close.html">Closing
    /// a member account in your organization</a> in the <i>Organizations User Guide</i>.
    /// </para></li></ul></important><note><para>
    /// When you create a member account with this operation, you can choose whether to create
    /// the account with the <b>IAM User and Role Access to Billing Information</b> switch
    /// enabled. If you enable it, IAM users and roles that have appropriate permissions can
    /// view billing information for the account. If you disable it, only the account root
    /// user can access billing information. For information about how to disable this switch
    /// for an account, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/grantaccess.html">Granting
    /// access to your billing information and tools</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "ORGGovCloudAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Organizations.Model.CreateAccountStatus")]
    [AWSCmdlet("Calls the AWS Organizations CreateGovCloudAccount API operation.", Operation = new[] {"CreateGovCloudAccount"}, SelectReturnType = typeof(Amazon.Organizations.Model.CreateGovCloudAccountResponse))]
    [AWSCmdletOutput("Amazon.Organizations.Model.CreateAccountStatus or Amazon.Organizations.Model.CreateGovCloudAccountResponse",
        "This cmdlet returns an Amazon.Organizations.Model.CreateAccountStatus object.",
        "The service call response (type Amazon.Organizations.Model.CreateGovCloudAccountResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewORGGovCloudAccountCmdlet : AmazonOrganizationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountName
        /// <summary>
        /// <para>
        /// <para>The friendly name of the member account. </para><para>The account name can consist of only the characters [a-z],[A-Z],[0-9], hyphen (-),
        /// or dot (.) You can't separate characters with a dash (–).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AccountName { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>Specifies the email address of the owner to assign to the new member account in the
        /// commercial Region. This email address must not already be associated with another
        /// Amazon Web Services account. You must use a valid email address to complete account
        /// creation.</para><para>The rules for a valid email address:</para><ul><li><para>The address must be a minimum of 6 and a maximum of 64 characters long.</para></li><li><para>All characters must be 7-bit ASCII characters.</para></li><li><para>There must be one and only one @ symbol, which separates the local name from the domain
        /// name.</para></li><li><para>The local name can't contain any of the following characters:</para><para>whitespace, " ' ( ) &lt; &gt; [ ] : ; , \ | % &amp;</para></li><li><para>The local name can't begin with a dot (.)</para></li><li><para>The domain name can consist of only the characters [a-z],[A-Z],[0-9], hyphen (-),
        /// or dot (.)</para></li><li><para>The domain name can't begin or end with a hyphen (-) or dot (.)</para></li><li><para>The domain name must contain at least one dot</para></li></ul><para>You can't access the root user of the account or remove an account that was created
        /// with an invalid email address. Like all request parameters for <c>CreateGovCloudAccount</c>,
        /// the request for the email address for the Amazon Web Services GovCloud (US) account
        /// originates from the commercial Region, not from the Amazon Web Services GovCloud (US)
        /// Region.</para>
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
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter IamUserAccessToBilling
        /// <summary>
        /// <para>
        /// <para>If set to <c>ALLOW</c>, the new linked account in the commercial Region enables IAM
        /// users to access account billing information <i>if</i> they have the required permissions.
        /// If set to <c>DENY</c>, only the root user of the new account can access account billing
        /// information. For more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/grantaccess.html#ControllingAccessWebsite-Activate">About
        /// IAM access to the Billing and Cost Management console</a> in the <i>Amazon Web Services
        /// Billing and Cost Management User Guide</i>.</para><para>If you don't specify this parameter, the value defaults to <c>ALLOW</c>, and IAM users
        /// and roles with the required permissions can access billing information for the new
        /// account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Organizations.IAMUserAccessToBilling")]
        public Amazon.Organizations.IAMUserAccessToBilling IamUserAccessToBilling { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>(Optional)</para><para>The name of an IAM role that Organizations automatically preconfigures in the new
        /// member accounts in both the Amazon Web Services GovCloud (US) Region and in the commercial
        /// Region. This role trusts the management account, allowing users in the management
        /// account to assume the role, as permitted by the management account administrator.
        /// The role has administrator permissions in the new member account.</para><para>If you don't specify this parameter, the role name defaults to <c>OrganizationAccountAccessRole</c>.</para><para>For more information about how to use this role to access the member account, see
        /// the following links:</para><ul><li><para><a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts_access.html#orgs_manage_accounts_create-cross-account-role">Creating
        /// the OrganizationAccountAccessRole in an invited member account</a> in the <i>Organizations
        /// User Guide</i></para></li><li><para>Steps 2 and 3 in <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/tutorial_cross-account-with-roles.html">IAM
        /// Tutorial: Delegate access across Amazon Web Services accounts using IAM roles</a>
        /// in the <i>IAM User Guide</i></para></li></ul><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> that is used to validate
        /// this parameter. The pattern can include uppercase letters, lowercase letters, digits
        /// with no spaces, and any of the following characters: =,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags that you want to attach to the newly created account. These tags are
        /// attached to the commercial account associated with the GovCloud account, and not to
        /// the GovCloud account itself. To add tags to the actual GovCloud account, call the
        /// <a>TagResource</a> operation in the GovCloud region after the new GovCloud account
        /// exists.</para><para>For each tag in the list, you must specify both a tag key and a value. You can set
        /// the value to an empty string, but you can't set it to <c>null</c>. For more information
        /// about tagging, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_tagging.html">Tagging
        /// Organizations resources</a> in the Organizations User Guide.</para><note><para>If any one of the tags is not valid or if you exceed the maximum allowed number of
        /// tags for an account, then the entire request fails and the account is not created.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Organizations.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CreateAccountStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Organizations.Model.CreateGovCloudAccountResponse).
        /// Specifying the name of a property of type Amazon.Organizations.Model.CreateGovCloudAccountResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CreateAccountStatus";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Email), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ORGGovCloudAccount (CreateGovCloudAccount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Organizations.Model.CreateGovCloudAccountResponse, NewORGGovCloudAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountName = this.AccountName;
            #if MODULAR
            if (this.AccountName == null && ParameterWasBound(nameof(this.AccountName)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Email = this.Email;
            #if MODULAR
            if (this.Email == null && ParameterWasBound(nameof(this.Email)))
            {
                WriteWarning("You are passing $null as a value for parameter Email which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IamUserAccessToBilling = this.IamUserAccessToBilling;
            context.RoleName = this.RoleName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Organizations.Model.Tag>(this.Tag);
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
            var request = new Amazon.Organizations.Model.CreateGovCloudAccountRequest();
            
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Organizations.Model.CreateGovCloudAccountResponse CallAWSServiceOperation(IAmazonOrganizations client, Amazon.Organizations.Model.CreateGovCloudAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Organizations", "CreateGovCloudAccount");
            try
            {
                return client.CreateGovCloudAccountAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Organizations.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Organizations.Model.CreateGovCloudAccountResponse, NewORGGovCloudAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CreateAccountStatus;
        }
        
    }
}
