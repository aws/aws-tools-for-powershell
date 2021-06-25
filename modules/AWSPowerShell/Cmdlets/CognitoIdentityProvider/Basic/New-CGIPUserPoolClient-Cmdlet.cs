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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Creates the user pool client.
    /// 
    ///  
    /// <para>
    /// When you create a new user pool client, token revocation is automatically enabled.
    /// For more information about revoking tokens, see <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_RevokeToken.html">RevokeToken</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CGIPUserPoolClient", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.UserPoolClientType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider CreateUserPoolClient API operation.", Operation = new[] {"CreateUserPoolClient"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.UserPoolClientType or Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.UserPoolClientType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCGIPUserPoolClientCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter TokenValidityUnits_AccessToken
        /// <summary>
        /// <para>
        /// <para> A time unit in “seconds”, “minutes”, “hours” or “days” for the value in AccessTokenValidity,
        /// defaults to hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TimeUnitsType")]
        public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_AccessToken { get; set; }
        #endregion
        
        #region Parameter AccessTokenValidity
        /// <summary>
        /// <para>
        /// <para>The time limit, between 5 minutes and 1 day, after which the access token is no longer
        /// valid and cannot be used. This value will be overridden if you have entered a value
        /// in TokenValidityUnits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AccessTokenValidity { get; set; }
        #endregion
        
        #region Parameter AllowedOAuthFlow
        /// <summary>
        /// <para>
        /// <para>The allowed OAuth flows.</para><para>Set to <code>code</code> to initiate a code grant flow, which provides an authorization
        /// code as the response. This code can be exchanged for access tokens with the token
        /// endpoint.</para><para>Set to <code>implicit</code> to specify that the client should get the access token
        /// (and, optionally, ID token, based on scopes) directly.</para><para>Set to <code>client_credentials</code> to specify that the client should get the access
        /// token (and, optionally, ID token, based on scopes) from the token endpoint using a
        /// combination of client and client_secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedOAuthFlows")]
        public System.String[] AllowedOAuthFlow { get; set; }
        #endregion
        
        #region Parameter AllowedOAuthFlowsUserPoolClient
        /// <summary>
        /// <para>
        /// <para>Set to true if the client is allowed to follow the OAuth protocol when interacting
        /// with Cognito user pools.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowedOAuthFlowsUserPoolClient { get; set; }
        #endregion
        
        #region Parameter AllowedOAuthScope
        /// <summary>
        /// <para>
        /// <para>The allowed OAuth scopes. Possible values provided by OAuth are: <code>phone</code>,
        /// <code>email</code>, <code>openid</code>, and <code>profile</code>. Possible values
        /// provided by Amazon Web Services are: <code>aws.cognito.signin.user.admin</code>. Custom
        /// scopes created in Resource Servers are also supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedOAuthScopes")]
        public System.String[] AllowedOAuthScope { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_ApplicationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon Pinpoint project. You can use the Amazon
        /// Pinpoint project for Pinpoint integration with the chosen User Pool Client. Amazon
        /// Cognito publishes events to the pinpoint project declared by the app ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsConfiguration_ApplicationArn { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_ApplicationId
        /// <summary>
        /// <para>
        /// <para>The application ID for an Amazon Pinpoint application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsConfiguration_ApplicationId { get; set; }
        #endregion
        
        #region Parameter CallbackURLs
        /// <summary>
        /// <para>
        /// <para>A list of allowed redirect (callback) URLs for the identity providers.</para><para>A redirect URI must:</para><ul><li><para>Be an absolute URI.</para></li><li><para>Be registered with the authorization server.</para></li><li><para>Not include a fragment component.</para></li></ul><para>See <a href="https://tools.ietf.org/html/rfc6749#section-3.1.2">OAuth 2.0 - Redirection
        /// Endpoint</a>.</para><para>Amazon Cognito requires HTTPS over HTTP except for http://localhost for testing purposes
        /// only.</para><para>App callback URLs such as myapp://example are also supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CallbackURLs { get; set; }
        #endregion
        
        #region Parameter ClientName
        /// <summary>
        /// <para>
        /// <para>The client name for the user pool client you would like to create.</para>
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
        public System.String ClientName { get; set; }
        #endregion
        
        #region Parameter DefaultRedirectURI
        /// <summary>
        /// <para>
        /// <para>The default redirect URI. Must be in the <code>CallbackURLs</code> list.</para><para>A redirect URI must:</para><ul><li><para>Be an absolute URI.</para></li><li><para>Be registered with the authorization server.</para></li><li><para>Not include a fragment component.</para></li></ul><para>See <a href="https://tools.ietf.org/html/rfc6749#section-3.1.2">OAuth 2.0 - Redirection
        /// Endpoint</a>.</para><para>Amazon Cognito requires HTTPS over HTTP except for http://localhost for testing purposes
        /// only.</para><para>App callback URLs such as myapp://example are also supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRedirectURI { get; set; }
        #endregion
        
        #region Parameter EnableTokenRevocation
        /// <summary>
        /// <para>
        /// <para>Enables or disables token revocation. For more information about revoking tokens,
        /// see <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_RevokeToken.html">RevokeToken</a>.</para><para>If you don't include this parameter, token revocation is automatically enabled for
        /// the new user pool client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableTokenRevocation { get; set; }
        #endregion
        
        #region Parameter ExplicitAuthFlow
        /// <summary>
        /// <para>
        /// <para>The authentication flows that are supported by the user pool clients. Flow names without
        /// the <code>ALLOW_</code> prefix are deprecated in favor of new names with the <code>ALLOW_</code>
        /// prefix. Note that values with <code>ALLOW_</code> prefix cannot be used along with
        /// values without <code>ALLOW_</code> prefix.</para><para>Valid values include:</para><ul><li><para><code>ALLOW_ADMIN_USER_PASSWORD_AUTH</code>: Enable admin based user password authentication
        /// flow <code>ADMIN_USER_PASSWORD_AUTH</code>. This setting replaces the <code>ADMIN_NO_SRP_AUTH</code>
        /// setting. With this authentication flow, Cognito receives the password in the request
        /// instead of using the SRP (Secure Remote Password protocol) protocol to verify passwords.</para></li><li><para><code>ALLOW_CUSTOM_AUTH</code>: Enable Lambda trigger based authentication.</para></li><li><para><code>ALLOW_USER_PASSWORD_AUTH</code>: Enable user password-based authentication.
        /// In this flow, Cognito receives the password in the request instead of using the SRP
        /// protocol to verify passwords.</para></li><li><para><code>ALLOW_USER_SRP_AUTH</code>: Enable SRP based authentication.</para></li><li><para><code>ALLOW_REFRESH_TOKEN_AUTH</code>: Enable authflow to refresh tokens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplicitAuthFlows")]
        public System.String[] ExplicitAuthFlow { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_ExternalId
        /// <summary>
        /// <para>
        /// <para>The external ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsConfiguration_ExternalId { get; set; }
        #endregion
        
        #region Parameter GenerateSecret
        /// <summary>
        /// <para>
        /// <para>Boolean to specify whether you want to generate a secret for the user pool client
        /// being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? GenerateSecret { get; set; }
        #endregion
        
        #region Parameter TokenValidityUnits_IdToken
        /// <summary>
        /// <para>
        /// <para>A time unit in “seconds”, “minutes”, “hours” or “days” for the value in IdTokenValidity,
        /// defaults to hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TimeUnitsType")]
        public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_IdToken { get; set; }
        #endregion
        
        #region Parameter IdTokenValidity
        /// <summary>
        /// <para>
        /// <para>The time limit, between 5 minutes and 1 day, after which the ID token is no longer
        /// valid and cannot be used. This value will be overridden if you have entered a value
        /// in TokenValidityUnits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IdTokenValidity { get; set; }
        #endregion
        
        #region Parameter LogoutURLs
        /// <summary>
        /// <para>
        /// <para>A list of allowed logout URLs for the identity providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] LogoutURLs { get; set; }
        #endregion
        
        #region Parameter PreventUserExistenceError
        /// <summary>
        /// <para>
        /// <para>Use this setting to choose which errors and responses are returned by Cognito APIs
        /// during authentication, account confirmation, and password recovery when the user does
        /// not exist in the user pool. When set to <code>ENABLED</code> and the user does not
        /// exist, authentication returns an error indicating either the username or password
        /// was incorrect, and account confirmation and password recovery return a response indicating
        /// a code was sent to a simulated destination. When set to <code>LEGACY</code>, those
        /// APIs will return a <code>UserNotFoundException</code> exception if the user does not
        /// exist in the user pool.</para><para>Valid values include:</para><ul><li><para><code>ENABLED</code> - This prevents user existence-related errors.</para></li><li><para><code>LEGACY</code> - This represents the old behavior of Cognito where user existence
        /// related errors are not prevented.</para></li></ul><note><para>After February 15th 2020, the value of <code>PreventUserExistenceErrors</code> will
        /// default to <code>ENABLED</code> for newly created user pool clients if no value is
        /// provided.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PreventUserExistenceErrors")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.PreventUserExistenceErrorTypes")]
        public Amazon.CognitoIdentityProvider.PreventUserExistenceErrorTypes PreventUserExistenceError { get; set; }
        #endregion
        
        #region Parameter ReadAttribute
        /// <summary>
        /// <para>
        /// <para>The read attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReadAttributes")]
        public System.String[] ReadAttribute { get; set; }
        #endregion
        
        #region Parameter TokenValidityUnits_RefreshToken
        /// <summary>
        /// <para>
        /// <para>A time unit in “seconds”, “minutes”, “hours” or “days” for the value in RefreshTokenValidity,
        /// defaults to days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TimeUnitsType")]
        public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_RefreshToken { get; set; }
        #endregion
        
        #region Parameter RefreshTokenValidity
        /// <summary>
        /// <para>
        /// <para>The time limit, in days, after which the refresh token is no longer valid and cannot
        /// be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RefreshTokenValidity { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that authorizes Amazon Cognito to publish events to Amazon
        /// Pinpoint analytics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter SupportedIdentityProvider
        /// <summary>
        /// <para>
        /// <para>A list of provider names for the identity providers that are supported on this client.
        /// The following are supported: <code>COGNITO</code>, <code>Facebook</code>, <code>Google</code>
        /// and <code>LoginWithAmazon</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedIdentityProviders")]
        public System.String[] SupportedIdentityProvider { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_UserDataShared
        /// <summary>
        /// <para>
        /// <para>If <code>UserDataShared</code> is <code>true</code>, Amazon Cognito will include user
        /// data in the events it publishes to Amazon Pinpoint analytics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AnalyticsConfiguration_UserDataShared { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID for the user pool where you want to create a user pool client.</para>
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
        
        #region Parameter WriteAttribute
        /// <summary>
        /// <para>
        /// <para>The user pool attributes that the app client can write to.</para><para>If your app client allows users to sign in through an identity provider, this array
        /// must include all attributes that are mapped to identity provider attributes. Amazon
        /// Cognito updates mapped attributes when users sign in to your application through an
        /// identity provider. If your app client lacks write access to a mapped attribute, Amazon
        /// Cognito throws an error when it attempts to update the attribute. For more information,
        /// see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-specifying-attribute-mapping.html">Specifying
        /// Identity Provider Attribute Mappings for Your User Pool</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteAttributes")]
        public System.String[] WriteAttribute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserPoolClient'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserPoolClient";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserPoolId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGIPUserPoolClient (CreateUserPoolClient)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse, NewCGIPUserPoolClientCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserPoolId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessTokenValidity = this.AccessTokenValidity;
            if (this.AllowedOAuthFlow != null)
            {
                context.AllowedOAuthFlow = new List<System.String>(this.AllowedOAuthFlow);
            }
            context.AllowedOAuthFlowsUserPoolClient = this.AllowedOAuthFlowsUserPoolClient;
            if (this.AllowedOAuthScope != null)
            {
                context.AllowedOAuthScope = new List<System.String>(this.AllowedOAuthScope);
            }
            context.AnalyticsConfiguration_ApplicationArn = this.AnalyticsConfiguration_ApplicationArn;
            context.AnalyticsConfiguration_ApplicationId = this.AnalyticsConfiguration_ApplicationId;
            context.AnalyticsConfiguration_ExternalId = this.AnalyticsConfiguration_ExternalId;
            context.AnalyticsConfiguration_RoleArn = this.AnalyticsConfiguration_RoleArn;
            context.AnalyticsConfiguration_UserDataShared = this.AnalyticsConfiguration_UserDataShared;
            if (this.CallbackURLs != null)
            {
                context.CallbackURLs = new List<System.String>(this.CallbackURLs);
            }
            context.ClientName = this.ClientName;
            #if MODULAR
            if (this.ClientName == null && ParameterWasBound(nameof(this.ClientName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultRedirectURI = this.DefaultRedirectURI;
            context.EnableTokenRevocation = this.EnableTokenRevocation;
            if (this.ExplicitAuthFlow != null)
            {
                context.ExplicitAuthFlow = new List<System.String>(this.ExplicitAuthFlow);
            }
            context.GenerateSecret = this.GenerateSecret;
            context.IdTokenValidity = this.IdTokenValidity;
            if (this.LogoutURLs != null)
            {
                context.LogoutURLs = new List<System.String>(this.LogoutURLs);
            }
            context.PreventUserExistenceError = this.PreventUserExistenceError;
            if (this.ReadAttribute != null)
            {
                context.ReadAttribute = new List<System.String>(this.ReadAttribute);
            }
            context.RefreshTokenValidity = this.RefreshTokenValidity;
            if (this.SupportedIdentityProvider != null)
            {
                context.SupportedIdentityProvider = new List<System.String>(this.SupportedIdentityProvider);
            }
            context.TokenValidityUnits_AccessToken = this.TokenValidityUnits_AccessToken;
            context.TokenValidityUnits_IdToken = this.TokenValidityUnits_IdToken;
            context.TokenValidityUnits_RefreshToken = this.TokenValidityUnits_RefreshToken;
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.WriteAttribute != null)
            {
                context.WriteAttribute = new List<System.String>(this.WriteAttribute);
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
            var request = new Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientRequest();
            
            if (cmdletContext.AccessTokenValidity != null)
            {
                request.AccessTokenValidity = cmdletContext.AccessTokenValidity.Value;
            }
            if (cmdletContext.AllowedOAuthFlow != null)
            {
                request.AllowedOAuthFlows = cmdletContext.AllowedOAuthFlow;
            }
            if (cmdletContext.AllowedOAuthFlowsUserPoolClient != null)
            {
                request.AllowedOAuthFlowsUserPoolClient = cmdletContext.AllowedOAuthFlowsUserPoolClient.Value;
            }
            if (cmdletContext.AllowedOAuthScope != null)
            {
                request.AllowedOAuthScopes = cmdletContext.AllowedOAuthScope;
            }
            
             // populate AnalyticsConfiguration
            var requestAnalyticsConfigurationIsNull = true;
            request.AnalyticsConfiguration = new Amazon.CognitoIdentityProvider.Model.AnalyticsConfigurationType();
            System.String requestAnalyticsConfiguration_analyticsConfiguration_ApplicationArn = null;
            if (cmdletContext.AnalyticsConfiguration_ApplicationArn != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_ApplicationArn = cmdletContext.AnalyticsConfiguration_ApplicationArn;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_ApplicationArn != null)
            {
                request.AnalyticsConfiguration.ApplicationArn = requestAnalyticsConfiguration_analyticsConfiguration_ApplicationArn;
                requestAnalyticsConfigurationIsNull = false;
            }
            System.String requestAnalyticsConfiguration_analyticsConfiguration_ApplicationId = null;
            if (cmdletContext.AnalyticsConfiguration_ApplicationId != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_ApplicationId = cmdletContext.AnalyticsConfiguration_ApplicationId;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_ApplicationId != null)
            {
                request.AnalyticsConfiguration.ApplicationId = requestAnalyticsConfiguration_analyticsConfiguration_ApplicationId;
                requestAnalyticsConfigurationIsNull = false;
            }
            System.String requestAnalyticsConfiguration_analyticsConfiguration_ExternalId = null;
            if (cmdletContext.AnalyticsConfiguration_ExternalId != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_ExternalId = cmdletContext.AnalyticsConfiguration_ExternalId;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_ExternalId != null)
            {
                request.AnalyticsConfiguration.ExternalId = requestAnalyticsConfiguration_analyticsConfiguration_ExternalId;
                requestAnalyticsConfigurationIsNull = false;
            }
            System.String requestAnalyticsConfiguration_analyticsConfiguration_RoleArn = null;
            if (cmdletContext.AnalyticsConfiguration_RoleArn != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_RoleArn = cmdletContext.AnalyticsConfiguration_RoleArn;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_RoleArn != null)
            {
                request.AnalyticsConfiguration.RoleArn = requestAnalyticsConfiguration_analyticsConfiguration_RoleArn;
                requestAnalyticsConfigurationIsNull = false;
            }
            System.Boolean? requestAnalyticsConfiguration_analyticsConfiguration_UserDataShared = null;
            if (cmdletContext.AnalyticsConfiguration_UserDataShared != null)
            {
                requestAnalyticsConfiguration_analyticsConfiguration_UserDataShared = cmdletContext.AnalyticsConfiguration_UserDataShared.Value;
            }
            if (requestAnalyticsConfiguration_analyticsConfiguration_UserDataShared != null)
            {
                request.AnalyticsConfiguration.UserDataShared = requestAnalyticsConfiguration_analyticsConfiguration_UserDataShared.Value;
                requestAnalyticsConfigurationIsNull = false;
            }
             // determine if request.AnalyticsConfiguration should be set to null
            if (requestAnalyticsConfigurationIsNull)
            {
                request.AnalyticsConfiguration = null;
            }
            if (cmdletContext.CallbackURLs != null)
            {
                request.CallbackURLs = cmdletContext.CallbackURLs;
            }
            if (cmdletContext.ClientName != null)
            {
                request.ClientName = cmdletContext.ClientName;
            }
            if (cmdletContext.DefaultRedirectURI != null)
            {
                request.DefaultRedirectURI = cmdletContext.DefaultRedirectURI;
            }
            if (cmdletContext.EnableTokenRevocation != null)
            {
                request.EnableTokenRevocation = cmdletContext.EnableTokenRevocation.Value;
            }
            if (cmdletContext.ExplicitAuthFlow != null)
            {
                request.ExplicitAuthFlows = cmdletContext.ExplicitAuthFlow;
            }
            if (cmdletContext.GenerateSecret != null)
            {
                request.GenerateSecret = cmdletContext.GenerateSecret.Value;
            }
            if (cmdletContext.IdTokenValidity != null)
            {
                request.IdTokenValidity = cmdletContext.IdTokenValidity.Value;
            }
            if (cmdletContext.LogoutURLs != null)
            {
                request.LogoutURLs = cmdletContext.LogoutURLs;
            }
            if (cmdletContext.PreventUserExistenceError != null)
            {
                request.PreventUserExistenceErrors = cmdletContext.PreventUserExistenceError;
            }
            if (cmdletContext.ReadAttribute != null)
            {
                request.ReadAttributes = cmdletContext.ReadAttribute;
            }
            if (cmdletContext.RefreshTokenValidity != null)
            {
                request.RefreshTokenValidity = cmdletContext.RefreshTokenValidity.Value;
            }
            if (cmdletContext.SupportedIdentityProvider != null)
            {
                request.SupportedIdentityProviders = cmdletContext.SupportedIdentityProvider;
            }
            
             // populate TokenValidityUnits
            var requestTokenValidityUnitsIsNull = true;
            request.TokenValidityUnits = new Amazon.CognitoIdentityProvider.Model.TokenValidityUnitsType();
            Amazon.CognitoIdentityProvider.TimeUnitsType requestTokenValidityUnits_tokenValidityUnits_AccessToken = null;
            if (cmdletContext.TokenValidityUnits_AccessToken != null)
            {
                requestTokenValidityUnits_tokenValidityUnits_AccessToken = cmdletContext.TokenValidityUnits_AccessToken;
            }
            if (requestTokenValidityUnits_tokenValidityUnits_AccessToken != null)
            {
                request.TokenValidityUnits.AccessToken = requestTokenValidityUnits_tokenValidityUnits_AccessToken;
                requestTokenValidityUnitsIsNull = false;
            }
            Amazon.CognitoIdentityProvider.TimeUnitsType requestTokenValidityUnits_tokenValidityUnits_IdToken = null;
            if (cmdletContext.TokenValidityUnits_IdToken != null)
            {
                requestTokenValidityUnits_tokenValidityUnits_IdToken = cmdletContext.TokenValidityUnits_IdToken;
            }
            if (requestTokenValidityUnits_tokenValidityUnits_IdToken != null)
            {
                request.TokenValidityUnits.IdToken = requestTokenValidityUnits_tokenValidityUnits_IdToken;
                requestTokenValidityUnitsIsNull = false;
            }
            Amazon.CognitoIdentityProvider.TimeUnitsType requestTokenValidityUnits_tokenValidityUnits_RefreshToken = null;
            if (cmdletContext.TokenValidityUnits_RefreshToken != null)
            {
                requestTokenValidityUnits_tokenValidityUnits_RefreshToken = cmdletContext.TokenValidityUnits_RefreshToken;
            }
            if (requestTokenValidityUnits_tokenValidityUnits_RefreshToken != null)
            {
                request.TokenValidityUnits.RefreshToken = requestTokenValidityUnits_tokenValidityUnits_RefreshToken;
                requestTokenValidityUnitsIsNull = false;
            }
             // determine if request.TokenValidityUnits should be set to null
            if (requestTokenValidityUnitsIsNull)
            {
                request.TokenValidityUnits = null;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            if (cmdletContext.WriteAttribute != null)
            {
                request.WriteAttributes = cmdletContext.WriteAttribute;
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
        
        private Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "CreateUserPoolClient");
            try
            {
                #if DESKTOP
                return client.CreateUserPoolClient(request);
                #elif CORECLR
                return client.CreateUserPoolClientAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? AccessTokenValidity { get; set; }
            public List<System.String> AllowedOAuthFlow { get; set; }
            public System.Boolean? AllowedOAuthFlowsUserPoolClient { get; set; }
            public List<System.String> AllowedOAuthScope { get; set; }
            public System.String AnalyticsConfiguration_ApplicationArn { get; set; }
            public System.String AnalyticsConfiguration_ApplicationId { get; set; }
            public System.String AnalyticsConfiguration_ExternalId { get; set; }
            public System.String AnalyticsConfiguration_RoleArn { get; set; }
            public System.Boolean? AnalyticsConfiguration_UserDataShared { get; set; }
            public List<System.String> CallbackURLs { get; set; }
            public System.String ClientName { get; set; }
            public System.String DefaultRedirectURI { get; set; }
            public System.Boolean? EnableTokenRevocation { get; set; }
            public List<System.String> ExplicitAuthFlow { get; set; }
            public System.Boolean? GenerateSecret { get; set; }
            public System.Int32? IdTokenValidity { get; set; }
            public List<System.String> LogoutURLs { get; set; }
            public Amazon.CognitoIdentityProvider.PreventUserExistenceErrorTypes PreventUserExistenceError { get; set; }
            public List<System.String> ReadAttribute { get; set; }
            public System.Int32? RefreshTokenValidity { get; set; }
            public List<System.String> SupportedIdentityProvider { get; set; }
            public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_AccessToken { get; set; }
            public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_IdToken { get; set; }
            public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_RefreshToken { get; set; }
            public System.String UserPoolId { get; set; }
            public List<System.String> WriteAttribute { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.CreateUserPoolClientResponse, NewCGIPUserPoolClientCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserPoolClient;
        }
        
    }
}
