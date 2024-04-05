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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates an Amazon QuickSight account, or subscribes to Amazon QuickSight Q.
    /// 
    ///  
    /// <para>
    /// The Amazon Web Services Region for the account is derived from what is configured
    /// in the CLI or SDK.
    /// </para><para>
    /// Before you use this operation, make sure that you can connect to an existing Amazon
    /// Web Services account. If you don't have an Amazon Web Services account, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/setting-up-aws-sign-up.html">Sign
    /// up for Amazon Web Services</a> in the <i>Amazon QuickSight User Guide</i>. The person
    /// who signs up for Amazon QuickSight needs to have the correct Identity and Access Management
    /// (IAM) permissions. For more information, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/iam-policy-examples.html">IAM
    /// Policy Examples for Amazon QuickSight</a> in the <i>Amazon QuickSight User Guide</i>.
    /// </para><para>
    /// If your IAM policy includes both the <c>Subscribe</c> and <c>CreateAccountSubscription</c>
    /// actions, make sure that both actions are set to <c>Allow</c>. If either action is
    /// set to <c>Deny</c>, the <c>Deny</c> action prevails and your API call fails.
    /// </para><para>
    /// You can't pass an existing IAM role to access other Amazon Web Services services using
    /// this API operation. To pass your existing IAM role to Amazon QuickSight, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/security_iam_service-with-iam.html#security-create-iam-role">Passing
    /// IAM roles to Amazon QuickSight</a> in the <i>Amazon QuickSight User Guide</i>.
    /// </para><para>
    /// You can't set default resource access on the new account from the Amazon QuickSight
    /// API. Instead, add default resource access from the Amazon QuickSight console. For
    /// more information about setting default resource access to Amazon Web Services services,
    /// see <a href="https://docs.aws.amazon.com/quicksight/latest/user/scoping-policies-defaults.html">Setting
    /// default resource access to Amazon Web Services services</a> in the <i>Amazon QuickSight
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSAccountSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateAccountSubscriptionResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateAccountSubscription API operation.", Operation = new[] {"CreateAccountSubscription"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateAccountSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateAccountSubscriptionResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateAccountSubscriptionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQSAccountSubscriptionCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountName
        /// <summary>
        /// <para>
        /// <para>The name of your Amazon QuickSight account. This name is unique over all of Amazon
        /// Web Services, and it appears only when users sign in. You can't change <c>AccountName</c>
        /// value after the Amazon QuickSight account is created.</para>
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
        
        #region Parameter ActiveDirectoryName
        /// <summary>
        /// <para>
        /// <para>The name of your Active Directory. This field is required if <c>ACTIVE_DIRECTORY</c>
        /// is the selected authentication method of the new Amazon QuickSight account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActiveDirectoryName { get; set; }
        #endregion
        
        #region Parameter AdminGroup
        /// <summary>
        /// <para>
        /// <para>The admin group associated with your Active Directory or IAM Identity Center account.
        /// This field is required if <c>ACTIVE_DIRECTORY</c> or <c>IAM_IDENTITY_CENTER</c> is
        /// the selected authentication method of the new Amazon QuickSight account.</para><para>For more information about using IAM Identity Center in Amazon QuickSight, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/sec-identity-management-identity-center.html">Using
        /// IAM Identity Center with Amazon QuickSight Enterprise Edition</a> in the Amazon QuickSight
        /// User Guide. For more information about using Active Directory in Amazon QuickSight,
        /// see <a href="https://docs.aws.amazon.com/quicksight/latest/user/aws-directory-service.html">Using
        /// Active Directory with Amazon QuickSight Enterprise Edition</a> in the Amazon QuickSight
        /// User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AdminGroup { get; set; }
        #endregion
        
        #region Parameter AuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>The method that you want to use to authenticate your Amazon QuickSight account.</para><para>If you choose <c>ACTIVE_DIRECTORY</c>, provide an <c>ActiveDirectoryName</c> and an
        /// <c>AdminGroup</c> associated with your Active Directory.</para><para>If you choose <c>IAM_IDENTITY_CENTER</c>, provide an <c>AdminGroup</c> associated
        /// with your IAM Identity Center account.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.AuthenticationMethodOption")]
        public Amazon.QuickSight.AuthenticationMethodOption AuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter AuthorGroup
        /// <summary>
        /// <para>
        /// <para>The author group associated with your Active Directory or IAM Identity Center account.</para><para>For more information about using IAM Identity Center in Amazon QuickSight, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/sec-identity-management-identity-center.html">Using
        /// IAM Identity Center with Amazon QuickSight Enterprise Edition</a> in the Amazon QuickSight
        /// User Guide. For more information about using Active Directory in Amazon QuickSight,
        /// see <a href="https://docs.aws.amazon.com/quicksight/latest/user/aws-directory-service.html">Using
        /// Active Directory with Amazon QuickSight Enterprise Edition</a> in the Amazon QuickSight
        /// User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AuthorGroup { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the account that you're using to create your
        /// Amazon QuickSight account.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter ContactNumber
        /// <summary>
        /// <para>
        /// <para>A 10-digit phone number for the author of the Amazon QuickSight account to use for
        /// future communications. This field is required if <c>ENTERPPRISE_AND_Q</c> is the selected
        /// edition of the new Amazon QuickSight account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactNumber { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The ID of the Active Directory that is associated with your Amazon QuickSight account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter Edition
        /// <summary>
        /// <para>
        /// <para>The edition of Amazon QuickSight that you want your account to have. Currently, you
        /// can choose from <c>ENTERPRISE</c> or <c>ENTERPRISE_AND_Q</c>.</para><para>If you choose <c>ENTERPRISE_AND_Q</c>, the following parameters are required:</para><ul><li><para><c>FirstName</c></para></li><li><para><c>LastName</c></para></li><li><para><c>EmailAddress</c></para></li><li><para><c>ContactNumber</c></para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.Edition")]
        public Amazon.QuickSight.Edition Edition { get; set; }
        #endregion
        
        #region Parameter EmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address of the author of the Amazon QuickSight account to use for future
        /// communications. This field is required if <c>ENTERPPRISE_AND_Q</c> is the selected
        /// edition of the new Amazon QuickSight account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailAddress { get; set; }
        #endregion
        
        #region Parameter FirstName
        /// <summary>
        /// <para>
        /// <para>The first name of the author of the Amazon QuickSight account to use for future communications.
        /// This field is required if <c>ENTERPPRISE_AND_Q</c> is the selected edition of the
        /// new Amazon QuickSight account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirstName { get; set; }
        #endregion
        
        #region Parameter IAMIdentityCenterInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the IAM Identity Center instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IAMIdentityCenterInstanceArn { get; set; }
        #endregion
        
        #region Parameter LastName
        /// <summary>
        /// <para>
        /// <para>The last name of the author of the Amazon QuickSight account to use for future communications.
        /// This field is required if <c>ENTERPPRISE_AND_Q</c> is the selected edition of the
        /// new Amazon QuickSight account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LastName { get; set; }
        #endregion
        
        #region Parameter NotificationEmail
        /// <summary>
        /// <para>
        /// <para>The email address that you want Amazon QuickSight to send notifications to regarding
        /// your Amazon QuickSight account or Amazon QuickSight subscription.</para>
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
        public System.String NotificationEmail { get; set; }
        #endregion
        
        #region Parameter ReaderGroup
        /// <summary>
        /// <para>
        /// <para>The reader group associated with your Active Directory or IAM Identity Center account.</para><para>For more information about using IAM Identity Center in Amazon QuickSight, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/sec-identity-management-identity-center.html">Using
        /// IAM Identity Center with Amazon QuickSight Enterprise Edition</a> in the Amazon QuickSight
        /// User Guide. For more information about using Active Directory in Amazon QuickSight,
        /// see <a href="https://docs.aws.amazon.com/quicksight/latest/user/aws-directory-service.html">Using
        /// Active Directory with Amazon QuickSight Enterprise Edition</a> in the Amazon QuickSight
        /// User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ReaderGroup { get; set; }
        #endregion
        
        #region Parameter Realm
        /// <summary>
        /// <para>
        /// <para>The realm of the Active Directory that is associated with your Amazon QuickSight account.
        /// This field is required if <c>ACTIVE_DIRECTORY</c> is the selected authentication method
        /// of the new Amazon QuickSight account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Realm { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateAccountSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateAccountSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSAccountSubscription (CreateAccountSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateAccountSubscriptionResponse, NewQSAccountSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountName = this.AccountName;
            #if MODULAR
            if (this.AccountName == null && ParameterWasBound(nameof(this.AccountName)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActiveDirectoryName = this.ActiveDirectoryName;
            if (this.AdminGroup != null)
            {
                context.AdminGroup = new List<System.String>(this.AdminGroup);
            }
            context.AuthenticationMethod = this.AuthenticationMethod;
            #if MODULAR
            if (this.AuthenticationMethod == null && ParameterWasBound(nameof(this.AuthenticationMethod)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationMethod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AuthorGroup != null)
            {
                context.AuthorGroup = new List<System.String>(this.AuthorGroup);
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactNumber = this.ContactNumber;
            context.DirectoryId = this.DirectoryId;
            context.Edition = this.Edition;
            #if MODULAR
            if (this.Edition == null && ParameterWasBound(nameof(this.Edition)))
            {
                WriteWarning("You are passing $null as a value for parameter Edition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailAddress = this.EmailAddress;
            context.FirstName = this.FirstName;
            context.IAMIdentityCenterInstanceArn = this.IAMIdentityCenterInstanceArn;
            context.LastName = this.LastName;
            context.NotificationEmail = this.NotificationEmail;
            #if MODULAR
            if (this.NotificationEmail == null && ParameterWasBound(nameof(this.NotificationEmail)))
            {
                WriteWarning("You are passing $null as a value for parameter NotificationEmail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReaderGroup != null)
            {
                context.ReaderGroup = new List<System.String>(this.ReaderGroup);
            }
            context.Realm = this.Realm;
            
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
            var request = new Amazon.QuickSight.Model.CreateAccountSubscriptionRequest();
            
            if (cmdletContext.AccountName != null)
            {
                request.AccountName = cmdletContext.AccountName;
            }
            if (cmdletContext.ActiveDirectoryName != null)
            {
                request.ActiveDirectoryName = cmdletContext.ActiveDirectoryName;
            }
            if (cmdletContext.AdminGroup != null)
            {
                request.AdminGroup = cmdletContext.AdminGroup;
            }
            if (cmdletContext.AuthenticationMethod != null)
            {
                request.AuthenticationMethod = cmdletContext.AuthenticationMethod;
            }
            if (cmdletContext.AuthorGroup != null)
            {
                request.AuthorGroup = cmdletContext.AuthorGroup;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.ContactNumber != null)
            {
                request.ContactNumber = cmdletContext.ContactNumber;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.Edition != null)
            {
                request.Edition = cmdletContext.Edition;
            }
            if (cmdletContext.EmailAddress != null)
            {
                request.EmailAddress = cmdletContext.EmailAddress;
            }
            if (cmdletContext.FirstName != null)
            {
                request.FirstName = cmdletContext.FirstName;
            }
            if (cmdletContext.IAMIdentityCenterInstanceArn != null)
            {
                request.IAMIdentityCenterInstanceArn = cmdletContext.IAMIdentityCenterInstanceArn;
            }
            if (cmdletContext.LastName != null)
            {
                request.LastName = cmdletContext.LastName;
            }
            if (cmdletContext.NotificationEmail != null)
            {
                request.NotificationEmail = cmdletContext.NotificationEmail;
            }
            if (cmdletContext.ReaderGroup != null)
            {
                request.ReaderGroup = cmdletContext.ReaderGroup;
            }
            if (cmdletContext.Realm != null)
            {
                request.Realm = cmdletContext.Realm;
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
        
        private Amazon.QuickSight.Model.CreateAccountSubscriptionResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateAccountSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateAccountSubscription");
            try
            {
                #if DESKTOP
                return client.CreateAccountSubscription(request);
                #elif CORECLR
                return client.CreateAccountSubscriptionAsync(request).GetAwaiter().GetResult();
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
            public System.String ActiveDirectoryName { get; set; }
            public List<System.String> AdminGroup { get; set; }
            public Amazon.QuickSight.AuthenticationMethodOption AuthenticationMethod { get; set; }
            public List<System.String> AuthorGroup { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String ContactNumber { get; set; }
            public System.String DirectoryId { get; set; }
            public Amazon.QuickSight.Edition Edition { get; set; }
            public System.String EmailAddress { get; set; }
            public System.String FirstName { get; set; }
            public System.String IAMIdentityCenterInstanceArn { get; set; }
            public System.String LastName { get; set; }
            public System.String NotificationEmail { get; set; }
            public List<System.String> ReaderGroup { get; set; }
            public System.String Realm { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateAccountSubscriptionResponse, NewQSAccountSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
