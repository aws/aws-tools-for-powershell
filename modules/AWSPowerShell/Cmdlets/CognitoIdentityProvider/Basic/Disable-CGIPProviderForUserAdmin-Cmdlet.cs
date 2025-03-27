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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Prevents the user from signing in with the specified external (SAML or social) identity
    /// provider (IdP). If the user that you want to deactivate is a Amazon Cognito user pools
    /// native username + password user, they can't use their password to sign in. If the
    /// user to deactivate is a linked external IdP user, any link between that user and an
    /// existing user is removed. When the external user signs in again, and the user is no
    /// longer attached to the previously linked <c>DestinationUser</c>, the user must create
    /// a new user account.
    /// 
    ///  
    /// <para>
    /// The value of <c>ProviderName</c> must match the name of a user pool IdP.
    /// </para><para>
    /// To deactivate a local user, set <c>ProviderName</c> to <c>Cognito</c> and the <c>ProviderAttributeName</c>
    /// to <c>Cognito_Subject</c>. The <c>ProviderAttributeValue</c> must be user's local
    /// username.
    /// </para><para>
    /// The <c>ProviderAttributeName</c> must always be <c>Cognito_Subject</c> for social
    /// IdPs. The <c>ProviderAttributeValue</c> must always be the exact subject that was
    /// used when the user was originally linked as a source user.
    /// </para><para>
    /// For de-linking a SAML identity, there are two scenarios. If the linked identity has
    /// not yet been used to sign in, the <c>ProviderAttributeName</c> and <c>ProviderAttributeValue</c>
    /// must be the same values that were used for the <c>SourceUser</c> when the identities
    /// were originally linked using <c> AdminLinkProviderForUser</c> call. This is also true
    /// if the linking was done with <c>ProviderAttributeName</c> set to <c>Cognito_Subject</c>.
    /// If the user has already signed in, the <c>ProviderAttributeName</c> must be <c>Cognito_Subject</c>
    /// and <c>ProviderAttributeValue</c> must be the <c>NameID</c> from their SAML assertion.
    /// </para><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Disable", "CGIPProviderForUserAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AdminDisableProviderForUser API operation.", Operation = new[] {"AdminDisableProviderForUser"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserResponse))]
    [AWSCmdletOutput("None or Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserResponse) be returned by specifying '-Select *'."
    )]
    public partial class DisableCGIPProviderForUserAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter User_ProviderAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the provider attribute to link to, such as <c>NameID</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String User_ProviderAttributeName { get; set; }
        #endregion
        
        #region Parameter User_ProviderAttributeValue
        /// <summary>
        /// <para>
        /// <para>The value of the provider attribute to link to, such as <c>xxxxx_account</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String User_ProviderAttributeValue { get; set; }
        #endregion
        
        #region Parameter User_ProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the provider, such as Facebook, Google, or Login with Amazon.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String User_ProviderName { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool where you want to delete the user's linked identities.</para>
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
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-CGIPProviderForUserAdmin (AdminDisableProviderForUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserResponse, DisableCGIPProviderForUserAdminCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.User_ProviderAttributeName = this.User_ProviderAttributeName;
            context.User_ProviderAttributeValue = this.User_ProviderAttributeValue;
            context.User_ProviderName = this.User_ProviderName;
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserRequest();
            
            
             // populate User
            var requestUserIsNull = true;
            request.User = new Amazon.CognitoIdentityProvider.Model.ProviderUserIdentifierType();
            System.String requestUser_user_ProviderAttributeName = null;
            if (cmdletContext.User_ProviderAttributeName != null)
            {
                requestUser_user_ProviderAttributeName = cmdletContext.User_ProviderAttributeName;
            }
            if (requestUser_user_ProviderAttributeName != null)
            {
                request.User.ProviderAttributeName = requestUser_user_ProviderAttributeName;
                requestUserIsNull = false;
            }
            System.String requestUser_user_ProviderAttributeValue = null;
            if (cmdletContext.User_ProviderAttributeValue != null)
            {
                requestUser_user_ProviderAttributeValue = cmdletContext.User_ProviderAttributeValue;
            }
            if (requestUser_user_ProviderAttributeValue != null)
            {
                request.User.ProviderAttributeValue = requestUser_user_ProviderAttributeValue;
                requestUserIsNull = false;
            }
            System.String requestUser_user_ProviderName = null;
            if (cmdletContext.User_ProviderName != null)
            {
                requestUser_user_ProviderName = cmdletContext.User_ProviderName;
            }
            if (requestUser_user_ProviderName != null)
            {
                request.User.ProviderName = requestUser_user_ProviderName;
                requestUserIsNull = false;
            }
             // determine if request.User should be set to null
            if (requestUserIsNull)
            {
                request.User = null;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminDisableProviderForUser");
            try
            {
                return client.AdminDisableProviderForUserAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String User_ProviderAttributeName { get; set; }
            public System.String User_ProviderAttributeValue { get; set; }
            public System.String User_ProviderName { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserResponse, DisableCGIPProviderForUserAdminCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
