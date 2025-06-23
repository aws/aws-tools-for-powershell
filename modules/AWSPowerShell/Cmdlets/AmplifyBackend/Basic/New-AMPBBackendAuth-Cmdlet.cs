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
using Amazon.AmplifyBackend;
using Amazon.AmplifyBackend.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMPB
{
    /// <summary>
    /// Creates a new backend authentication resource.
    /// </summary>
    [Cmdlet("New", "AMPBBackendAuth", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyBackend.Model.CreateBackendAuthResponse")]
    [AWSCmdlet("Calls the Amplify Backend CreateBackendAuth API operation.", Operation = new[] {"CreateBackendAuth"}, SelectReturnType = typeof(Amazon.AmplifyBackend.Model.CreateBackendAuthResponse))]
    [AWSCmdletOutput("Amazon.AmplifyBackend.Model.CreateBackendAuthResponse",
        "This cmdlet returns an Amazon.AmplifyBackend.Model.CreateBackendAuthResponse object containing multiple properties."
    )]
    public partial class NewAMPBBackendAuthCmdlet : AmazonAmplifyBackendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PasswordPolicy_AdditionalConstraint
        /// <summary>
        /// <para>
        /// <para>Additional constraints for the password used to access the backend of your Amplify
        /// project.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_PasswordPolicy_AdditionalConstraints")]
        public System.String[] PasswordPolicy_AdditionalConstraint { get; set; }
        #endregion
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The app ID.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_AuthResource
        /// <summary>
        /// <para>
        /// <para>Defines whether you want to configure only authentication or both authentication and
        /// authorization settings.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ResourceConfig_AuthResources")]
        [AWSConstantClassSource("Amazon.AmplifyBackend.AuthResources")]
        public Amazon.AmplifyBackend.AuthResources ResourceConfig_AuthResource { get; set; }
        #endregion
        
        #region Parameter BackendEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the backend environment.</para>
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
        public System.String BackendEnvironmentName { get; set; }
        #endregion
        
        #region Parameter Facebook_ClientId
        /// <summary>
        /// <para>
        /// <para>Describes the client_id, which can be obtained from the third-party social federation
        /// provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_ClientId")]
        public System.String Facebook_ClientId { get; set; }
        #endregion
        
        #region Parameter Google_ClientId
        /// <summary>
        /// <para>
        /// <para>Describes the client_id, which can be obtained from the third-party social federation
        /// provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_ClientId")]
        public System.String Google_ClientId { get; set; }
        #endregion
        
        #region Parameter LoginWithAmazon_ClientId
        /// <summary>
        /// <para>
        /// <para>Describes the client_id, which can be obtained from the third-party social federation
        /// provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_ClientId")]
        public System.String LoginWithAmazon_ClientId { get; set; }
        #endregion
        
        #region Parameter SignInWithApple_ClientId
        /// <summary>
        /// <para>
        /// <para>Describes the client_id (also called Services ID) that comes from Apple.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_ClientId")]
        public System.String SignInWithApple_ClientId { get; set; }
        #endregion
        
        #region Parameter Facebook_ClientSecret
        /// <summary>
        /// <para>
        /// <para>Describes the client_secret, which can be obtained from third-party social federation
        /// providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_ClientSecret")]
        public System.String Facebook_ClientSecret { get; set; }
        #endregion
        
        #region Parameter Google_ClientSecret
        /// <summary>
        /// <para>
        /// <para>Describes the client_secret, which can be obtained from third-party social federation
        /// providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_ClientSecret")]
        public System.String Google_ClientSecret { get; set; }
        #endregion
        
        #region Parameter LoginWithAmazon_ClientSecret
        /// <summary>
        /// <para>
        /// <para>Describes the client_secret, which can be obtained from third-party social federation
        /// providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_ClientSecret")]
        public System.String LoginWithAmazon_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ForgotPassword_DeliveryMethod
        /// <summary>
        /// <para>
        /// <para><b>(DEPRECATED)</b> Describes which mode to use (either SMS or email) to deliver messages
        /// to app users who want to recover their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_ForgotPassword_DeliveryMethod")]
        [AWSConstantClassSource("Amazon.AmplifyBackend.DeliveryMethod")]
        public Amazon.AmplifyBackend.DeliveryMethod ForgotPassword_DeliveryMethod { get; set; }
        #endregion
        
        #region Parameter VerificationMessage_DeliveryMethod
        /// <summary>
        /// <para>
        /// <para>The type of verification message to send.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_VerificationMessage_DeliveryMethod")]
        [AWSConstantClassSource("Amazon.AmplifyBackend.DeliveryMethod")]
        public Amazon.AmplifyBackend.DeliveryMethod VerificationMessage_DeliveryMethod { get; set; }
        #endregion
        
        #region Parameter OAuth_DomainPrefix
        /// <summary>
        /// <para>
        /// <para>The domain prefix for your Amplify app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_DomainPrefix")]
        public System.String OAuth_DomainPrefix { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage
        /// <summary>
        /// <para>
        /// <para>The contents of the email message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage { get; set; }
        #endregion
        
        #region Parameter EmailSettings_EmailMessage
        /// <summary>
        /// <para>
        /// <para>The contents of the email message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_EmailMessage")]
        public System.String EmailSettings_EmailMessage { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject
        /// <summary>
        /// <para>
        /// <para>The contents of the subject line of the email message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject { get; set; }
        #endregion
        
        #region Parameter EmailSettings_EmailSubject
        /// <summary>
        /// <para>
        /// <para>The contents of the subject line of the email message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_EmailSubject")]
        public System.String EmailSettings_EmailSubject { get; set; }
        #endregion
        
        #region Parameter IdentityPoolConfigs_IdentityPoolName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon Cognito identity pool used for authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_IdentityPoolConfigs_IdentityPoolName")]
        public System.String IdentityPoolConfigs_IdentityPoolName { get; set; }
        #endregion
        
        #region Parameter SignInWithApple_KeyId
        /// <summary>
        /// <para>
        /// <para>Describes the key_id that comes from Apple.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_KeyId")]
        public System.String SignInWithApple_KeyId { get; set; }
        #endregion
        
        #region Parameter Mfa_MFAMode
        /// <summary>
        /// <para>
        /// <para>Describes whether MFA should be [ON, OFF, or OPTIONAL] for authentication in your
        /// Amplify project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_Mfa_MFAMode")]
        [AWSConstantClassSource("Amazon.AmplifyBackend.MFAMode")]
        public Amazon.AmplifyBackend.MFAMode Mfa_MFAMode { get; set; }
        #endregion
        
        #region Parameter Settings_MfaType
        /// <summary>
        /// <para>
        /// <para>The supported MFA types.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_Mfa_Settings_MfaTypes")]
        public System.String[] Settings_MfaType { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_MinimumLength
        /// <summary>
        /// <para>
        /// <para>The minimum length of the password used to access the backend of your Amplify project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_PasswordPolicy_MinimumLength")]
        public System.Double? PasswordPolicy_MinimumLength { get; set; }
        #endregion
        
        #region Parameter OAuth_OAuthGrantType
        /// <summary>
        /// <para>
        /// <para>The OAuth grant type that you use to allow app users to authenticate from your Amplify
        /// app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_OAuthGrantType")]
        [AWSConstantClassSource("Amazon.AmplifyBackend.OAuthGrantType")]
        public Amazon.AmplifyBackend.OAuthGrantType OAuth_OAuthGrantType { get; set; }
        #endregion
        
        #region Parameter OAuth_OAuthScope
        /// <summary>
        /// <para>
        /// <para>List of OAuth-related flows used to allow your app users to authenticate from your
        /// Amplify app.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_OAuthScopes")]
        public System.String[] OAuth_OAuthScope { get; set; }
        #endregion
        
        #region Parameter SignInWithApple_PrivateKey
        /// <summary>
        /// <para>
        /// <para>Describes the private_key that comes from Apple.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_PrivateKey")]
        public System.String SignInWithApple_PrivateKey { get; set; }
        #endregion
        
        #region Parameter OAuth_RedirectSignInURIs
        /// <summary>
        /// <para>
        /// <para>The redirected URI for signing in to your Amplify app.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_RedirectSignInURIs")]
        public System.String[] OAuth_RedirectSignInURIs { get; set; }
        #endregion
        
        #region Parameter OAuth_RedirectSignOutURIs
        /// <summary>
        /// <para>
        /// <para>Redirect URLs that OAuth uses when a user signs out of an Amplify app.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_RedirectSignOutURIs")]
        public System.String[] OAuth_RedirectSignOutURIs { get; set; }
        #endregion
        
        #region Parameter UserPoolConfigs_RequiredSignUpAttribute
        /// <summary>
        /// <para>
        /// <para>The required attributes to sign up new users in the user pool.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("ResourceConfig_UserPoolConfigs_RequiredSignUpAttributes")]
        public System.String[] UserPoolConfigs_RequiredSignUpAttribute { get; set; }
        #endregion
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of this resource.</para>
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
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_Service
        /// <summary>
        /// <para>
        /// <para>Defines the service name to use when configuring an authentication resource in your
        /// Amplify project.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AmplifyBackend.Service")]
        public Amazon.AmplifyBackend.Service ResourceConfig_Service { get; set; }
        #endregion
        
        #region Parameter UserPoolConfigs_SignInMethod
        /// <summary>
        /// <para>
        /// <para>Describes the sign-in methods that your Amplify app users use to log in using the
        /// Amazon Cognito user pool, configured as a part of your Amplify project.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ResourceConfig_UserPoolConfigs_SignInMethod")]
        [AWSConstantClassSource("Amazon.AmplifyBackend.SignInMethod")]
        public Amazon.AmplifyBackend.SignInMethod UserPoolConfigs_SignInMethod { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage
        /// <summary>
        /// <para>
        /// <para>The contents of the SMS message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage { get; set; }
        #endregion
        
        #region Parameter Settings_SmsMessage
        /// <summary>
        /// <para>
        /// <para>The body of the SMS message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_Mfa_Settings_SmsMessage")]
        public System.String Settings_SmsMessage { get; set; }
        #endregion
        
        #region Parameter SmsSettings_SmsMessage
        /// <summary>
        /// <para>
        /// <para>The contents of the SMS message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings_SmsMessage")]
        public System.String SmsSettings_SmsMessage { get; set; }
        #endregion
        
        #region Parameter SignInWithApple_TeamId
        /// <summary>
        /// <para>
        /// <para>Describes the team_id that comes from Apple.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_TeamId")]
        public System.String SignInWithApple_TeamId { get; set; }
        #endregion
        
        #region Parameter IdentityPoolConfigs_UnauthenticatedLogin
        /// <summary>
        /// <para>
        /// <para>Set to true or false based on whether you want to enable guest authorization to your
        /// Amplify app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_IdentityPoolConfigs_UnauthenticatedLogin")]
        public System.Boolean? IdentityPoolConfigs_UnauthenticatedLogin { get; set; }
        #endregion
        
        #region Parameter UserPoolConfigs_UserPoolName
        /// <summary>
        /// <para>
        /// <para>The Amazon Cognito user pool name.</para>
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
        [Alias("ResourceConfig_UserPoolConfigs_UserPoolName")]
        public System.String UserPoolConfigs_UserPoolName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyBackend.Model.CreateBackendAuthResponse).
        /// Specifying the name of a property of type Amazon.AmplifyBackend.Model.CreateBackendAuthResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPBBackendAuth (CreateBackendAuth)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyBackend.Model.CreateBackendAuthResponse, NewAMPBBackendAuthCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BackendEnvironmentName = this.BackendEnvironmentName;
            #if MODULAR
            if (this.BackendEnvironmentName == null && ParameterWasBound(nameof(this.BackendEnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter BackendEnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceConfig_AuthResource = this.ResourceConfig_AuthResource;
            #if MODULAR
            if (this.ResourceConfig_AuthResource == null && ParameterWasBound(nameof(this.ResourceConfig_AuthResource)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceConfig_AuthResource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityPoolConfigs_IdentityPoolName = this.IdentityPoolConfigs_IdentityPoolName;
            context.IdentityPoolConfigs_UnauthenticatedLogin = this.IdentityPoolConfigs_UnauthenticatedLogin;
            context.ResourceConfig_Service = this.ResourceConfig_Service;
            #if MODULAR
            if (this.ResourceConfig_Service == null && ParameterWasBound(nameof(this.ResourceConfig_Service)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceConfig_Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForgotPassword_DeliveryMethod = this.ForgotPassword_DeliveryMethod;
            context.ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage = this.ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage;
            context.ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject = this.ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject;
            context.ResourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage = this.ResourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage;
            context.Mfa_MFAMode = this.Mfa_MFAMode;
            if (this.Settings_MfaType != null)
            {
                context.Settings_MfaType = new List<System.String>(this.Settings_MfaType);
            }
            context.Settings_SmsMessage = this.Settings_SmsMessage;
            context.OAuth_DomainPrefix = this.OAuth_DomainPrefix;
            context.OAuth_OAuthGrantType = this.OAuth_OAuthGrantType;
            if (this.OAuth_OAuthScope != null)
            {
                context.OAuth_OAuthScope = new List<System.String>(this.OAuth_OAuthScope);
            }
            if (this.OAuth_RedirectSignInURIs != null)
            {
                context.OAuth_RedirectSignInURIs = new List<System.String>(this.OAuth_RedirectSignInURIs);
            }
            if (this.OAuth_RedirectSignOutURIs != null)
            {
                context.OAuth_RedirectSignOutURIs = new List<System.String>(this.OAuth_RedirectSignOutURIs);
            }
            context.Facebook_ClientId = this.Facebook_ClientId;
            context.Facebook_ClientSecret = this.Facebook_ClientSecret;
            context.Google_ClientId = this.Google_ClientId;
            context.Google_ClientSecret = this.Google_ClientSecret;
            context.LoginWithAmazon_ClientId = this.LoginWithAmazon_ClientId;
            context.LoginWithAmazon_ClientSecret = this.LoginWithAmazon_ClientSecret;
            context.SignInWithApple_ClientId = this.SignInWithApple_ClientId;
            context.SignInWithApple_KeyId = this.SignInWithApple_KeyId;
            context.SignInWithApple_PrivateKey = this.SignInWithApple_PrivateKey;
            context.SignInWithApple_TeamId = this.SignInWithApple_TeamId;
            if (this.PasswordPolicy_AdditionalConstraint != null)
            {
                context.PasswordPolicy_AdditionalConstraint = new List<System.String>(this.PasswordPolicy_AdditionalConstraint);
            }
            context.PasswordPolicy_MinimumLength = this.PasswordPolicy_MinimumLength;
            if (this.UserPoolConfigs_RequiredSignUpAttribute != null)
            {
                context.UserPoolConfigs_RequiredSignUpAttribute = new List<System.String>(this.UserPoolConfigs_RequiredSignUpAttribute);
            }
            #if MODULAR
            if (this.UserPoolConfigs_RequiredSignUpAttribute == null && ParameterWasBound(nameof(this.UserPoolConfigs_RequiredSignUpAttribute)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolConfigs_RequiredSignUpAttribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserPoolConfigs_SignInMethod = this.UserPoolConfigs_SignInMethod;
            #if MODULAR
            if (this.UserPoolConfigs_SignInMethod == null && ParameterWasBound(nameof(this.UserPoolConfigs_SignInMethod)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolConfigs_SignInMethod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserPoolConfigs_UserPoolName = this.UserPoolConfigs_UserPoolName;
            #if MODULAR
            if (this.UserPoolConfigs_UserPoolName == null && ParameterWasBound(nameof(this.UserPoolConfigs_UserPoolName)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolConfigs_UserPoolName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VerificationMessage_DeliveryMethod = this.VerificationMessage_DeliveryMethod;
            context.EmailSettings_EmailMessage = this.EmailSettings_EmailMessage;
            context.EmailSettings_EmailSubject = this.EmailSettings_EmailSubject;
            context.SmsSettings_SmsMessage = this.SmsSettings_SmsMessage;
            context.ResourceName = this.ResourceName;
            #if MODULAR
            if (this.ResourceName == null && ParameterWasBound(nameof(this.ResourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AmplifyBackend.Model.CreateBackendAuthRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.BackendEnvironmentName != null)
            {
                request.BackendEnvironmentName = cmdletContext.BackendEnvironmentName;
            }
            
             // populate ResourceConfig
            var requestResourceConfigIsNull = true;
            request.ResourceConfig = new Amazon.AmplifyBackend.Model.CreateBackendAuthResourceConfig();
            Amazon.AmplifyBackend.AuthResources requestResourceConfig_resourceConfig_AuthResource = null;
            if (cmdletContext.ResourceConfig_AuthResource != null)
            {
                requestResourceConfig_resourceConfig_AuthResource = cmdletContext.ResourceConfig_AuthResource;
            }
            if (requestResourceConfig_resourceConfig_AuthResource != null)
            {
                request.ResourceConfig.AuthResources = requestResourceConfig_resourceConfig_AuthResource;
                requestResourceConfigIsNull = false;
            }
            Amazon.AmplifyBackend.Service requestResourceConfig_resourceConfig_Service = null;
            if (cmdletContext.ResourceConfig_Service != null)
            {
                requestResourceConfig_resourceConfig_Service = cmdletContext.ResourceConfig_Service;
            }
            if (requestResourceConfig_resourceConfig_Service != null)
            {
                request.ResourceConfig.Service = requestResourceConfig_resourceConfig_Service;
                requestResourceConfigIsNull = false;
            }
            Amazon.AmplifyBackend.Model.CreateBackendAuthIdentityPoolConfig requestResourceConfig_resourceConfig_IdentityPoolConfigs = null;
            
             // populate IdentityPoolConfigs
            var requestResourceConfig_resourceConfig_IdentityPoolConfigsIsNull = true;
            requestResourceConfig_resourceConfig_IdentityPoolConfigs = new Amazon.AmplifyBackend.Model.CreateBackendAuthIdentityPoolConfig();
            System.String requestResourceConfig_resourceConfig_IdentityPoolConfigs_identityPoolConfigs_IdentityPoolName = null;
            if (cmdletContext.IdentityPoolConfigs_IdentityPoolName != null)
            {
                requestResourceConfig_resourceConfig_IdentityPoolConfigs_identityPoolConfigs_IdentityPoolName = cmdletContext.IdentityPoolConfigs_IdentityPoolName;
            }
            if (requestResourceConfig_resourceConfig_IdentityPoolConfigs_identityPoolConfigs_IdentityPoolName != null)
            {
                requestResourceConfig_resourceConfig_IdentityPoolConfigs.IdentityPoolName = requestResourceConfig_resourceConfig_IdentityPoolConfigs_identityPoolConfigs_IdentityPoolName;
                requestResourceConfig_resourceConfig_IdentityPoolConfigsIsNull = false;
            }
            System.Boolean? requestResourceConfig_resourceConfig_IdentityPoolConfigs_identityPoolConfigs_UnauthenticatedLogin = null;
            if (cmdletContext.IdentityPoolConfigs_UnauthenticatedLogin != null)
            {
                requestResourceConfig_resourceConfig_IdentityPoolConfigs_identityPoolConfigs_UnauthenticatedLogin = cmdletContext.IdentityPoolConfigs_UnauthenticatedLogin.Value;
            }
            if (requestResourceConfig_resourceConfig_IdentityPoolConfigs_identityPoolConfigs_UnauthenticatedLogin != null)
            {
                requestResourceConfig_resourceConfig_IdentityPoolConfigs.UnauthenticatedLogin = requestResourceConfig_resourceConfig_IdentityPoolConfigs_identityPoolConfigs_UnauthenticatedLogin.Value;
                requestResourceConfig_resourceConfig_IdentityPoolConfigsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_IdentityPoolConfigs should be set to null
            if (requestResourceConfig_resourceConfig_IdentityPoolConfigsIsNull)
            {
                requestResourceConfig_resourceConfig_IdentityPoolConfigs = null;
            }
            if (requestResourceConfig_resourceConfig_IdentityPoolConfigs != null)
            {
                request.ResourceConfig.IdentityPoolConfigs = requestResourceConfig_resourceConfig_IdentityPoolConfigs;
                requestResourceConfigIsNull = false;
            }
            Amazon.AmplifyBackend.Model.CreateBackendAuthUserPoolConfig requestResourceConfig_resourceConfig_UserPoolConfigs = null;
            
             // populate UserPoolConfigs
            var requestResourceConfig_resourceConfig_UserPoolConfigsIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs = new Amazon.AmplifyBackend.Model.CreateBackendAuthUserPoolConfig();
            List<System.String> requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_RequiredSignUpAttribute = null;
            if (cmdletContext.UserPoolConfigs_RequiredSignUpAttribute != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_RequiredSignUpAttribute = cmdletContext.UserPoolConfigs_RequiredSignUpAttribute;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_RequiredSignUpAttribute != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs.RequiredSignUpAttributes = requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_RequiredSignUpAttribute;
                requestResourceConfig_resourceConfig_UserPoolConfigsIsNull = false;
            }
            Amazon.AmplifyBackend.SignInMethod requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_SignInMethod = null;
            if (cmdletContext.UserPoolConfigs_SignInMethod != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_SignInMethod = cmdletContext.UserPoolConfigs_SignInMethod;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_SignInMethod != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs.SignInMethod = requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_SignInMethod;
                requestResourceConfig_resourceConfig_UserPoolConfigsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_UserPoolName = null;
            if (cmdletContext.UserPoolConfigs_UserPoolName != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_UserPoolName = cmdletContext.UserPoolConfigs_UserPoolName;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_UserPoolName != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs.UserPoolName = requestResourceConfig_resourceConfig_UserPoolConfigs_userPoolConfigs_UserPoolName;
                requestResourceConfig_resourceConfig_UserPoolConfigsIsNull = false;
            }
            Amazon.AmplifyBackend.Model.CreateBackendAuthMFAConfig requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa = null;
            
             // populate Mfa
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_MfaIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa = new Amazon.AmplifyBackend.Model.CreateBackendAuthMFAConfig();
            Amazon.AmplifyBackend.MFAMode requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_mfa_MFAMode = null;
            if (cmdletContext.Mfa_MFAMode != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_mfa_MFAMode = cmdletContext.Mfa_MFAMode;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_mfa_MFAMode != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa.MFAMode = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_mfa_MFAMode;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_MfaIsNull = false;
            }
            Amazon.AmplifyBackend.Model.Settings requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings = null;
            
             // populate Settings
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_SettingsIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings = new Amazon.AmplifyBackend.Model.Settings();
            List<System.String> requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings_settings_MfaType = null;
            if (cmdletContext.Settings_MfaType != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings_settings_MfaType = cmdletContext.Settings_MfaType;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings_settings_MfaType != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings.MfaTypes = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings_settings_MfaType;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_SettingsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings_settings_SmsMessage = null;
            if (cmdletContext.Settings_SmsMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings_settings_SmsMessage = cmdletContext.Settings_SmsMessage;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings_settings_SmsMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings.SmsMessage = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings_settings_SmsMessage;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_SettingsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_SettingsIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa.Settings = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa_resourceConfig_UserPoolConfigs_Mfa_Settings;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_MfaIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_MfaIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs.Mfa = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_Mfa;
                requestResourceConfig_resourceConfig_UserPoolConfigsIsNull = false;
            }
            Amazon.AmplifyBackend.Model.CreateBackendAuthPasswordPolicyConfig requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy = null;
            
             // populate PasswordPolicy
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicyIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy = new Amazon.AmplifyBackend.Model.CreateBackendAuthPasswordPolicyConfig();
            List<System.String> requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy_passwordPolicy_AdditionalConstraint = null;
            if (cmdletContext.PasswordPolicy_AdditionalConstraint != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy_passwordPolicy_AdditionalConstraint = cmdletContext.PasswordPolicy_AdditionalConstraint;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy_passwordPolicy_AdditionalConstraint != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy.AdditionalConstraints = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy_passwordPolicy_AdditionalConstraint;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicyIsNull = false;
            }
            System.Double? requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy_passwordPolicy_MinimumLength = null;
            if (cmdletContext.PasswordPolicy_MinimumLength != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy_passwordPolicy_MinimumLength = cmdletContext.PasswordPolicy_MinimumLength.Value;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy_passwordPolicy_MinimumLength != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy.MinimumLength = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy_passwordPolicy_MinimumLength.Value;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicyIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicyIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs.PasswordPolicy = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_PasswordPolicy;
                requestResourceConfig_resourceConfig_UserPoolConfigsIsNull = false;
            }
            Amazon.AmplifyBackend.Model.CreateBackendAuthForgotPasswordConfig requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword = null;
            
             // populate ForgotPassword
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPasswordIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword = new Amazon.AmplifyBackend.Model.CreateBackendAuthForgotPasswordConfig();
            Amazon.AmplifyBackend.DeliveryMethod requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_forgotPassword_DeliveryMethod = null;
            if (cmdletContext.ForgotPassword_DeliveryMethod != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_forgotPassword_DeliveryMethod = cmdletContext.ForgotPassword_DeliveryMethod;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_forgotPassword_DeliveryMethod != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword.DeliveryMethod = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_forgotPassword_DeliveryMethod;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPasswordIsNull = false;
            }
            Amazon.AmplifyBackend.Model.SmsSettings requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings = null;
            
             // populate SmsSettings
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettingsIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings = new Amazon.AmplifyBackend.Model.SmsSettings();
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage = null;
            if (cmdletContext.ResourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage = cmdletContext.ResourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings.SmsMessage = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettingsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettingsIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword.SmsSettings = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPasswordIsNull = false;
            }
            Amazon.AmplifyBackend.Model.EmailSettings requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings = null;
            
             // populate EmailSettings
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettingsIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings = new Amazon.AmplifyBackend.Model.EmailSettings();
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage = null;
            if (cmdletContext.ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage = cmdletContext.ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings.EmailMessage = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettingsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject = null;
            if (cmdletContext.ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject = cmdletContext.ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings.EmailSubject = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettingsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettingsIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword.EmailSettings = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword_resourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPasswordIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPasswordIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs.ForgotPassword = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_ForgotPassword;
                requestResourceConfig_resourceConfig_UserPoolConfigsIsNull = false;
            }
            Amazon.AmplifyBackend.Model.CreateBackendAuthVerificationMessageConfig requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage = null;
            
             // populate VerificationMessage
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessageIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage = new Amazon.AmplifyBackend.Model.CreateBackendAuthVerificationMessageConfig();
            Amazon.AmplifyBackend.DeliveryMethod requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_verificationMessage_DeliveryMethod = null;
            if (cmdletContext.VerificationMessage_DeliveryMethod != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_verificationMessage_DeliveryMethod = cmdletContext.VerificationMessage_DeliveryMethod;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_verificationMessage_DeliveryMethod != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage.DeliveryMethod = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_verificationMessage_DeliveryMethod;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessageIsNull = false;
            }
            Amazon.AmplifyBackend.Model.SmsSettings requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings = null;
            
             // populate SmsSettings
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettingsIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings = new Amazon.AmplifyBackend.Model.SmsSettings();
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings_smsSettings_SmsMessage = null;
            if (cmdletContext.SmsSettings_SmsMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings_smsSettings_SmsMessage = cmdletContext.SmsSettings_SmsMessage;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings_smsSettings_SmsMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings.SmsMessage = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings_smsSettings_SmsMessage;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettingsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettingsIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage.SmsSettings = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_SmsSettings;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessageIsNull = false;
            }
            Amazon.AmplifyBackend.Model.EmailSettings requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings = null;
            
             // populate EmailSettings
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettingsIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings = new Amazon.AmplifyBackend.Model.EmailSettings();
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_emailSettings_EmailMessage = null;
            if (cmdletContext.EmailSettings_EmailMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_emailSettings_EmailMessage = cmdletContext.EmailSettings_EmailMessage;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_emailSettings_EmailMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings.EmailMessage = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_emailSettings_EmailMessage;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettingsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_emailSettings_EmailSubject = null;
            if (cmdletContext.EmailSettings_EmailSubject != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_emailSettings_EmailSubject = cmdletContext.EmailSettings_EmailSubject;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_emailSettings_EmailSubject != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings.EmailSubject = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings_emailSettings_EmailSubject;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettingsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettingsIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage.EmailSettings = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage_resourceConfig_UserPoolConfigs_VerificationMessage_EmailSettings;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessageIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessageIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs.VerificationMessage = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_VerificationMessage;
                requestResourceConfig_resourceConfig_UserPoolConfigsIsNull = false;
            }
            Amazon.AmplifyBackend.Model.CreateBackendAuthOAuthConfig requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth = null;
            
             // populate OAuth
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuthIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth = new Amazon.AmplifyBackend.Model.CreateBackendAuthOAuthConfig();
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_DomainPrefix = null;
            if (cmdletContext.OAuth_DomainPrefix != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_DomainPrefix = cmdletContext.OAuth_DomainPrefix;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_DomainPrefix != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth.DomainPrefix = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_DomainPrefix;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuthIsNull = false;
            }
            Amazon.AmplifyBackend.OAuthGrantType requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_OAuthGrantType = null;
            if (cmdletContext.OAuth_OAuthGrantType != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_OAuthGrantType = cmdletContext.OAuth_OAuthGrantType;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_OAuthGrantType != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth.OAuthGrantType = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_OAuthGrantType;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuthIsNull = false;
            }
            List<System.String> requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_OAuthScope = null;
            if (cmdletContext.OAuth_OAuthScope != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_OAuthScope = cmdletContext.OAuth_OAuthScope;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_OAuthScope != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth.OAuthScopes = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_OAuthScope;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuthIsNull = false;
            }
            List<System.String> requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_RedirectSignInURIs = null;
            if (cmdletContext.OAuth_RedirectSignInURIs != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_RedirectSignInURIs = cmdletContext.OAuth_RedirectSignInURIs;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_RedirectSignInURIs != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth.RedirectSignInURIs = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_RedirectSignInURIs;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuthIsNull = false;
            }
            List<System.String> requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_RedirectSignOutURIs = null;
            if (cmdletContext.OAuth_RedirectSignOutURIs != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_RedirectSignOutURIs = cmdletContext.OAuth_RedirectSignOutURIs;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_RedirectSignOutURIs != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth.RedirectSignOutURIs = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_oAuth_RedirectSignOutURIs;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuthIsNull = false;
            }
            Amazon.AmplifyBackend.Model.SocialProviderSettings requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings = null;
            
             // populate SocialProviderSettings
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettingsIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings = new Amazon.AmplifyBackend.Model.SocialProviderSettings();
            Amazon.AmplifyBackend.Model.BackendAuthSocialProviderConfig requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook = null;
            
             // populate Facebook
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_FacebookIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook = new Amazon.AmplifyBackend.Model.BackendAuthSocialProviderConfig();
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_facebook_ClientId = null;
            if (cmdletContext.Facebook_ClientId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_facebook_ClientId = cmdletContext.Facebook_ClientId;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_facebook_ClientId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook.ClientId = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_facebook_ClientId;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_FacebookIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_facebook_ClientSecret = null;
            if (cmdletContext.Facebook_ClientSecret != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_facebook_ClientSecret = cmdletContext.Facebook_ClientSecret;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_facebook_ClientSecret != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook.ClientSecret = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook_facebook_ClientSecret;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_FacebookIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_FacebookIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings.Facebook = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Facebook;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettingsIsNull = false;
            }
            Amazon.AmplifyBackend.Model.BackendAuthSocialProviderConfig requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google = null;
            
             // populate Google
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_GoogleIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google = new Amazon.AmplifyBackend.Model.BackendAuthSocialProviderConfig();
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_google_ClientId = null;
            if (cmdletContext.Google_ClientId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_google_ClientId = cmdletContext.Google_ClientId;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_google_ClientId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google.ClientId = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_google_ClientId;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_GoogleIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_google_ClientSecret = null;
            if (cmdletContext.Google_ClientSecret != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_google_ClientSecret = cmdletContext.Google_ClientSecret;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_google_ClientSecret != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google.ClientSecret = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google_google_ClientSecret;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_GoogleIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_GoogleIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings.Google = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_Google;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettingsIsNull = false;
            }
            Amazon.AmplifyBackend.Model.BackendAuthSocialProviderConfig requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon = null;
            
             // populate LoginWithAmazon
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazonIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon = new Amazon.AmplifyBackend.Model.BackendAuthSocialProviderConfig();
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_loginWithAmazon_ClientId = null;
            if (cmdletContext.LoginWithAmazon_ClientId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_loginWithAmazon_ClientId = cmdletContext.LoginWithAmazon_ClientId;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_loginWithAmazon_ClientId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon.ClientId = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_loginWithAmazon_ClientId;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazonIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_loginWithAmazon_ClientSecret = null;
            if (cmdletContext.LoginWithAmazon_ClientSecret != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_loginWithAmazon_ClientSecret = cmdletContext.LoginWithAmazon_ClientSecret;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_loginWithAmazon_ClientSecret != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon.ClientSecret = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon_loginWithAmazon_ClientSecret;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazonIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazonIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings.LoginWithAmazon = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_LoginWithAmazon;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettingsIsNull = false;
            }
            Amazon.AmplifyBackend.Model.BackendAuthAppleProviderConfig requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple = null;
            
             // populate SignInWithApple
            var requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithAppleIsNull = true;
            requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple = new Amazon.AmplifyBackend.Model.BackendAuthAppleProviderConfig();
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_ClientId = null;
            if (cmdletContext.SignInWithApple_ClientId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_ClientId = cmdletContext.SignInWithApple_ClientId;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_ClientId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple.ClientId = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_ClientId;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithAppleIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_KeyId = null;
            if (cmdletContext.SignInWithApple_KeyId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_KeyId = cmdletContext.SignInWithApple_KeyId;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_KeyId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple.KeyId = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_KeyId;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithAppleIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_PrivateKey = null;
            if (cmdletContext.SignInWithApple_PrivateKey != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_PrivateKey = cmdletContext.SignInWithApple_PrivateKey;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_PrivateKey != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple.PrivateKey = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_PrivateKey;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithAppleIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_TeamId = null;
            if (cmdletContext.SignInWithApple_TeamId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_TeamId = cmdletContext.SignInWithApple_TeamId;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_TeamId != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple.TeamId = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple_signInWithApple_TeamId;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithAppleIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithAppleIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings.SignInWithApple = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings_SignInWithApple;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettingsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettingsIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth.SocialProviderSettings = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth_resourceConfig_UserPoolConfigs_OAuth_SocialProviderSettings;
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuthIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuthIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth != null)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs.OAuth = requestResourceConfig_resourceConfig_UserPoolConfigs_resourceConfig_UserPoolConfigs_OAuth;
                requestResourceConfig_resourceConfig_UserPoolConfigsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_UserPoolConfigs should be set to null
            if (requestResourceConfig_resourceConfig_UserPoolConfigsIsNull)
            {
                requestResourceConfig_resourceConfig_UserPoolConfigs = null;
            }
            if (requestResourceConfig_resourceConfig_UserPoolConfigs != null)
            {
                request.ResourceConfig.UserPoolConfigs = requestResourceConfig_resourceConfig_UserPoolConfigs;
                requestResourceConfigIsNull = false;
            }
             // determine if request.ResourceConfig should be set to null
            if (requestResourceConfigIsNull)
            {
                request.ResourceConfig = null;
            }
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
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
        
        private Amazon.AmplifyBackend.Model.CreateBackendAuthResponse CallAWSServiceOperation(IAmazonAmplifyBackend client, Amazon.AmplifyBackend.Model.CreateBackendAuthRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amplify Backend", "CreateBackendAuth");
            try
            {
                return client.CreateBackendAuthAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String BackendEnvironmentName { get; set; }
            public Amazon.AmplifyBackend.AuthResources ResourceConfig_AuthResource { get; set; }
            public System.String IdentityPoolConfigs_IdentityPoolName { get; set; }
            public System.Boolean? IdentityPoolConfigs_UnauthenticatedLogin { get; set; }
            public Amazon.AmplifyBackend.Service ResourceConfig_Service { get; set; }
            public Amazon.AmplifyBackend.DeliveryMethod ForgotPassword_DeliveryMethod { get; set; }
            public System.String ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailMessage { get; set; }
            public System.String ResourceConfig_UserPoolConfigs_ForgotPassword_EmailSettings_EmailSubject { get; set; }
            public System.String ResourceConfig_UserPoolConfigs_ForgotPassword_SmsSettings_SmsMessage { get; set; }
            public Amazon.AmplifyBackend.MFAMode Mfa_MFAMode { get; set; }
            public List<System.String> Settings_MfaType { get; set; }
            public System.String Settings_SmsMessage { get; set; }
            public System.String OAuth_DomainPrefix { get; set; }
            public Amazon.AmplifyBackend.OAuthGrantType OAuth_OAuthGrantType { get; set; }
            public List<System.String> OAuth_OAuthScope { get; set; }
            public List<System.String> OAuth_RedirectSignInURIs { get; set; }
            public List<System.String> OAuth_RedirectSignOutURIs { get; set; }
            public System.String Facebook_ClientId { get; set; }
            public System.String Facebook_ClientSecret { get; set; }
            public System.String Google_ClientId { get; set; }
            public System.String Google_ClientSecret { get; set; }
            public System.String LoginWithAmazon_ClientId { get; set; }
            public System.String LoginWithAmazon_ClientSecret { get; set; }
            public System.String SignInWithApple_ClientId { get; set; }
            public System.String SignInWithApple_KeyId { get; set; }
            public System.String SignInWithApple_PrivateKey { get; set; }
            public System.String SignInWithApple_TeamId { get; set; }
            public List<System.String> PasswordPolicy_AdditionalConstraint { get; set; }
            public System.Double? PasswordPolicy_MinimumLength { get; set; }
            public List<System.String> UserPoolConfigs_RequiredSignUpAttribute { get; set; }
            public Amazon.AmplifyBackend.SignInMethod UserPoolConfigs_SignInMethod { get; set; }
            public System.String UserPoolConfigs_UserPoolName { get; set; }
            public Amazon.AmplifyBackend.DeliveryMethod VerificationMessage_DeliveryMethod { get; set; }
            public System.String EmailSettings_EmailMessage { get; set; }
            public System.String EmailSettings_EmailSubject { get; set; }
            public System.String SmsSettings_SmsMessage { get; set; }
            public System.String ResourceName { get; set; }
            public System.Func<Amazon.AmplifyBackend.Model.CreateBackendAuthResponse, NewAMPBBackendAuthCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
