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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates an Amazon QuickSight user whose identity is associated with the Identity and
    /// Access Management (IAM) identity or role specified in the request. When you register
    /// a new user from the Amazon QuickSight API, Amazon QuickSight generates a registration
    /// URL. The user accesses this registration URL to create their account. Amazon QuickSight
    /// doesn't send a registration email to users who are registered from the Amazon QuickSight
    /// API. If you want new users to receive a registration email, then add those users in
    /// the Amazon QuickSight console. For more information on registering a new user in the
    /// Amazon QuickSight console, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/managing-users.html#inviting-users">
    /// Inviting users to access Amazon QuickSight</a>.
    /// </summary>
    [Cmdlet("Register", "QSUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.RegisterUserResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight RegisterUser API operation.", Operation = new[] {"RegisterUser"}, SelectReturnType = typeof(Amazon.QuickSight.Model.RegisterUserResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.RegisterUserResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.RegisterUserResponse object containing multiple properties."
    )]
    public partial class RegisterQSUserCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that the user is in. Currently, you use
        /// the ID for the Amazon Web Services account that contains your Amazon QuickSight account.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter CustomFederationProviderUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the custom OpenID Connect (OIDC) provider that provides identity to let
        /// a user federate into Amazon QuickSight with an associated Identity and Access Management(IAM)
        /// role. This parameter should only be used when <c>ExternalLoginFederationProviderType</c>
        /// parameter is set to <c>CUSTOM_OIDC</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomFederationProviderUrl { get; set; }
        #endregion
        
        #region Parameter CustomPermissionsName
        /// <summary>
        /// <para>
        /// <para>(Enterprise edition only) The name of the custom permissions profile that you want
        /// to assign to this user. Customized permissions allows you to control a user's access
        /// by restricting access the following operations:</para><ul><li><para>Create and update data sources</para></li><li><para>Create and update datasets</para></li><li><para>Create and update email reports</para></li><li><para>Subscribe to email reports</para></li></ul><para>To add custom permissions to an existing user, use <c><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_UpdateUser.html">UpdateUser</a></c> instead.</para><para>A set of custom permissions includes any combination of these restrictions. Currently,
        /// you need to create the profile names for custom permission sets by using the Amazon
        /// QuickSight console. Then, you use the <c>RegisterUser</c> API operation to assign
        /// the named set of permissions to a Amazon QuickSight user. </para><para>Amazon QuickSight custom permissions are applied through IAM policies. Therefore,
        /// they override the permissions typically granted by assigning Amazon QuickSight users
        /// to one of the default security cohorts in Amazon QuickSight (admin, author, reader,
        /// admin pro, author pro, reader pro).</para><para>This feature is available only to Amazon QuickSight Enterprise edition subscriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPermissionsName { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address of the user that you want to register.</para>
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
        
        #region Parameter ExternalLoginFederationProviderType
        /// <summary>
        /// <para>
        /// <para>The type of supported external login provider that provides identity to let a user
        /// federate into Amazon QuickSight with an associated Identity and Access Management(IAM)
        /// role. The type of supported external login provider can be one of the following.</para><ul><li><para><c>COGNITO</c>: Amazon Cognito. The provider URL is cognito-identity.amazonaws.com.
        /// When choosing the <c>COGNITO</c> provider type, don’t use the "CustomFederationProviderUrl"
        /// parameter which is only needed when the external provider is custom.</para></li><li><para><c>CUSTOM_OIDC</c>: Custom OpenID Connect (OIDC) provider. When choosing <c>CUSTOM_OIDC</c>
        /// type, use the <c>CustomFederationProviderUrl</c> parameter to provide the custom OIDC
        /// provider URL.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalLoginFederationProviderType { get; set; }
        #endregion
        
        #region Parameter ExternalLoginId
        /// <summary>
        /// <para>
        /// <para>The identity ID for a user in the external login provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalLoginId { get; set; }
        #endregion
        
        #region Parameter IamArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM user or role that you are registering with Amazon QuickSight. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamArn { get; set; }
        #endregion
        
        #region Parameter IdentityType
        /// <summary>
        /// <para>
        /// <para>The identity type that your Amazon QuickSight account uses to manage the identity
        /// of users.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.IdentityType")]
        public Amazon.QuickSight.IdentityType IdentityType { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace. Currently, you should set this to <c>default</c>.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter SessionName
        /// <summary>
        /// <para>
        /// <para>You need to use this parameter only when you register one or more users using an assumed
        /// IAM role. You don't need to provide the session name for other scenarios, for example
        /// when you are registering an IAM user or an Amazon QuickSight user. You can register
        /// multiple users using the same IAM role if each user has a different session name.
        /// For more information on assuming IAM roles, see <a href="https://docs.aws.amazon.com/cli/latest/reference/sts/assume-role.html"><c>assume-role</c></a> in the <i>CLI Reference.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the user.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight user name that you want to create for the user you are registering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter UserRole
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight role for the user. The user role can be one of the following:</para><ul><li><para><c>READER</c>: A user who has read-only access to dashboards.</para></li><li><para><c>AUTHOR</c>: A user who can create data sources, datasets, analyses, and dashboards.</para></li><li><para><c>ADMIN</c>: A user who is an author, who can also manage Amazon QuickSight settings.</para></li><li><para><c>READER_PRO</c>: Reader Pro adds Generative BI capabilities to the Reader role.
        /// Reader Pros have access to Amazon Q in Amazon QuickSight, can build stories with Amazon
        /// Q, and can generate executive summaries from dashboards.</para></li><li><para><c>AUTHOR_PRO</c>: Author Pro adds Generative BI capabilities to the Author role.
        /// Author Pros can author dashboards with natural language with Amazon Q, build stories
        /// with Amazon Q, create Topics for Q&amp;A, and generate executive summaries from dashboards.</para></li><li><para><c>ADMIN_PRO</c>: Admin Pros are Author Pros who can also manage Amazon QuickSight
        /// administrative settings. Admin Pro users are billed at Author Pro pricing.</para></li><li><para><c>RESTRICTED_READER</c>: This role isn't currently available for use.</para></li><li><para><c>RESTRICTED_AUTHOR</c>: This role isn't currently available for use.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.UserRole")]
        public Amazon.QuickSight.UserRole UserRole { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.RegisterUserResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.RegisterUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-QSUser (RegisterUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.RegisterUserResponse, RegisterQSUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomFederationProviderUrl = this.CustomFederationProviderUrl;
            context.CustomPermissionsName = this.CustomPermissionsName;
            context.Email = this.Email;
            #if MODULAR
            if (this.Email == null && ParameterWasBound(nameof(this.Email)))
            {
                WriteWarning("You are passing $null as a value for parameter Email which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExternalLoginFederationProviderType = this.ExternalLoginFederationProviderType;
            context.ExternalLoginId = this.ExternalLoginId;
            context.IamArn = this.IamArn;
            context.IdentityType = this.IdentityType;
            #if MODULAR
            if (this.IdentityType == null && ParameterWasBound(nameof(this.IdentityType)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionName = this.SessionName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            context.UserName = this.UserName;
            context.UserRole = this.UserRole;
            #if MODULAR
            if (this.UserRole == null && ParameterWasBound(nameof(this.UserRole)))
            {
                WriteWarning("You are passing $null as a value for parameter UserRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.RegisterUserRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.CustomFederationProviderUrl != null)
            {
                request.CustomFederationProviderUrl = cmdletContext.CustomFederationProviderUrl;
            }
            if (cmdletContext.CustomPermissionsName != null)
            {
                request.CustomPermissionsName = cmdletContext.CustomPermissionsName;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.ExternalLoginFederationProviderType != null)
            {
                request.ExternalLoginFederationProviderType = cmdletContext.ExternalLoginFederationProviderType;
            }
            if (cmdletContext.ExternalLoginId != null)
            {
                request.ExternalLoginId = cmdletContext.ExternalLoginId;
            }
            if (cmdletContext.IamArn != null)
            {
                request.IamArn = cmdletContext.IamArn;
            }
            if (cmdletContext.IdentityType != null)
            {
                request.IdentityType = cmdletContext.IdentityType;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.SessionName != null)
            {
                request.SessionName = cmdletContext.SessionName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            if (cmdletContext.UserRole != null)
            {
                request.UserRole = cmdletContext.UserRole;
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
        
        private Amazon.QuickSight.Model.RegisterUserResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.RegisterUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "RegisterUser");
            try
            {
                return client.RegisterUserAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String CustomFederationProviderUrl { get; set; }
            public System.String CustomPermissionsName { get; set; }
            public System.String Email { get; set; }
            public System.String ExternalLoginFederationProviderType { get; set; }
            public System.String ExternalLoginId { get; set; }
            public System.String IamArn { get; set; }
            public Amazon.QuickSight.IdentityType IdentityType { get; set; }
            public System.String Namespace { get; set; }
            public System.String SessionName { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public System.String UserName { get; set; }
            public Amazon.QuickSight.UserRole UserRole { get; set; }
            public System.Func<Amazon.QuickSight.Model.RegisterUserResponse, RegisterQSUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
