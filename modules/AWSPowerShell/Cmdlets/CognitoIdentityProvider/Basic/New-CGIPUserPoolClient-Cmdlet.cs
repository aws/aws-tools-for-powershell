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
    /// When you create a new user pool client, token revocation is automatically activated.
    /// For more information about revoking tokens, see <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_RevokeToken.html">RevokeToken</a>.
    /// </para><important><para>
    /// If you don't provide a value for an attribute, Amazon Cognito sets it to its default
    /// value.
    /// </para></important><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
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
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TokenValidityUnits_AccessToken
        /// <summary>
        /// <para>
        /// <para> A time unit of <c>seconds</c>, <c>minutes</c>, <c>hours</c>, or <c>days</c> for the
        /// value that you set in the <c>AccessTokenValidity</c> parameter. The default <c>AccessTokenValidity</c>
        /// time unit is hours. <c>AccessTokenValidity</c> duration can range from five minutes
        /// to one day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TimeUnitsType")]
        public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_AccessToken { get; set; }
        #endregion
        
        #region Parameter AccessTokenValidity
        /// <summary>
        /// <para>
        /// <para>The access token time limit. After this limit expires, your user can't use their access
        /// token. To specify the time unit for <c>AccessTokenValidity</c> as <c>seconds</c>,
        /// <c>minutes</c>, <c>hours</c>, or <c>days</c>, set a <c>TokenValidityUnits</c> value
        /// in your API request.</para><para>For example, when you set <c>AccessTokenValidity</c> to <c>10</c> and <c>TokenValidityUnits</c>
        /// to <c>hours</c>, your user can authorize access with their access token for 10 hours.</para><para>The default time unit for <c>AccessTokenValidity</c> in an API request is hours. <i>Valid
        /// range</i> is displayed below in seconds.</para><para>If you don't specify otherwise in the configuration of your app client, your access
        /// tokens are valid for one hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AccessTokenValidity { get; set; }
        #endregion
        
        #region Parameter AllowedOAuthFlow
        /// <summary>
        /// <para>
        /// <para>The allowed OAuth flows.</para><dl><dt>code</dt><dd><para>Use a code grant flow, which provides an authorization code as the response. This
        /// code can be exchanged for access tokens with the <c>/oauth2/token</c> endpoint.</para></dd><dt>implicit</dt><dd><para>Issue the access token (and, optionally, ID token, based on scopes) directly to your
        /// user.</para></dd><dt>client_credentials</dt><dd><para>Issue the access token from the <c>/oauth2/token</c> endpoint directly to a non-person
        /// user using a combination of the client ID and client secret.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedOAuthFlows")]
        public System.String[] AllowedOAuthFlow { get; set; }
        #endregion
        
        #region Parameter AllowedOAuthFlowsUserPoolClient
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to use OAuth 2.0 features in your user pool app client.</para><para><c>AllowedOAuthFlowsUserPoolClient</c> must be <c>true</c> before you can configure
        /// the following features in your app client.</para><ul><li><para><c>CallBackURLs</c>: Callback URLs.</para></li><li><para><c>LogoutURLs</c>: Sign-out redirect URLs.</para></li><li><para><c>AllowedOAuthScopes</c>: OAuth 2.0 scopes.</para></li><li><para><c>AllowedOAuthFlows</c>: Support for authorization code, implicit, and client credentials
        /// OAuth 2.0 grants.</para></li></ul><para>To use OAuth 2.0 features, configure one of these features in the Amazon Cognito console
        /// or set <c>AllowedOAuthFlowsUserPoolClient</c> to <c>true</c> in a <c>CreateUserPoolClient</c>
        /// or <c>UpdateUserPoolClient</c> API request. If you don't set a value for <c>AllowedOAuthFlowsUserPoolClient</c>
        /// in a request with the CLI or SDKs, it defaults to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowedOAuthFlowsUserPoolClient { get; set; }
        #endregion
        
        #region Parameter AllowedOAuthScope
        /// <summary>
        /// <para>
        /// <para>The allowed OAuth scopes. Possible values provided by OAuth are <c>phone</c>, <c>email</c>,
        /// <c>openid</c>, and <c>profile</c>. Possible values provided by Amazon Web Services
        /// are <c>aws.cognito.signin.user.admin</c>. Custom scopes created in Resource Servers
        /// are also supported.</para>
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
        /// Pinpoint project to integrate with the chosen user pool Client. Amazon Cognito publishes
        /// events to the Amazon Pinpoint project that the app ARN declares.</para>
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
        
        #region Parameter AuthSessionValidity
        /// <summary>
        /// <para>
        /// <para>Amazon Cognito creates a session token for each API request in an authentication flow.
        /// <c>AuthSessionValidity</c> is the duration, in minutes, of that session token. Your
        /// user pool native user must respond to each authentication challenge before the session
        /// expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AuthSessionValidity { get; set; }
        #endregion
        
        #region Parameter CallbackURLs
        /// <summary>
        /// <para>
        /// <para>A list of allowed redirect (callback) URLs for the IdPs.</para><para>A redirect URI must:</para><ul><li><para>Be an absolute URI.</para></li><li><para>Be registered with the authorization server.</para></li><li><para>Not include a fragment component.</para></li></ul><para>See <a href="https://tools.ietf.org/html/rfc6749#section-3.1.2">OAuth 2.0 - Redirection
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
        /// <para>The default redirect URI. Must be in the <c>CallbackURLs</c> list.</para><para>A redirect URI must:</para><ul><li><para>Be an absolute URI.</para></li><li><para>Be registered with the authorization server.</para></li><li><para>Not include a fragment component.</para></li></ul><para>See <a href="https://tools.ietf.org/html/rfc6749#section-3.1.2">OAuth 2.0 - Redirection
        /// Endpoint</a>.</para><para>Amazon Cognito requires HTTPS over HTTP except for http://localhost for testing purposes
        /// only.</para><para>App callback URLs such as myapp://example are also supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRedirectURI { get; set; }
        #endregion
        
        #region Parameter EnablePropagateAdditionalUserContextData
        /// <summary>
        /// <para>
        /// <para>Activates the propagation of additional user context data. For more information about
        /// propagation of user context data, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pool-settings-advanced-security.html">
        /// Adding advanced security to a user pool</a>. If you don’t include this parameter,
        /// you can't send device fingerprint information, including source IP address, to Amazon
        /// Cognito advanced security. You can only activate <c>EnablePropagateAdditionalUserContextData</c>
        /// in an app client that has a client secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePropagateAdditionalUserContextData { get; set; }
        #endregion
        
        #region Parameter EnableTokenRevocation
        /// <summary>
        /// <para>
        /// <para>Activates or deactivates token revocation. For more information about revoking tokens,
        /// see <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_RevokeToken.html">RevokeToken</a>.</para><para>If you don't include this parameter, token revocation is automatically activated for
        /// the new user pool client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableTokenRevocation { get; set; }
        #endregion
        
        #region Parameter ExplicitAuthFlow
        /// <summary>
        /// <para>
        /// <para>The authentication flows that you want your user pool client to support. For each
        /// app client in your user pool, you can sign in your users with any combination of one
        /// or more flows, including with a user name and Secure Remote Password (SRP), a user
        /// name and password, or a custom authentication process that you define with Lambda
        /// functions.</para><note><para>If you don't specify a value for <c>ExplicitAuthFlows</c>, your user client supports
        /// <c>ALLOW_REFRESH_TOKEN_AUTH</c>, <c>ALLOW_USER_SRP_AUTH</c>, and <c>ALLOW_CUSTOM_AUTH</c>.</para></note><para>Valid values include:</para><ul><li><para><c>ALLOW_ADMIN_USER_PASSWORD_AUTH</c>: Enable admin based user password authentication
        /// flow <c>ADMIN_USER_PASSWORD_AUTH</c>. This setting replaces the <c>ADMIN_NO_SRP_AUTH</c>
        /// setting. With this authentication flow, your app passes a user name and password to
        /// Amazon Cognito in the request, instead of using the Secure Remote Password (SRP) protocol
        /// to securely transmit the password.</para></li><li><para><c>ALLOW_CUSTOM_AUTH</c>: Enable Lambda trigger based authentication.</para></li><li><para><c>ALLOW_USER_PASSWORD_AUTH</c>: Enable user password-based authentication. In this
        /// flow, Amazon Cognito receives the password in the request instead of using the SRP
        /// protocol to verify passwords.</para></li><li><para><c>ALLOW_USER_SRP_AUTH</c>: Enable SRP-based authentication.</para></li><li><para><c>ALLOW_REFRESH_TOKEN_AUTH</c>: Enable authflow to refresh tokens.</para></li></ul><para>In some environments, you will see the values <c>ADMIN_NO_SRP_AUTH</c>, <c>CUSTOM_AUTH_FLOW_ONLY</c>,
        /// or <c>USER_PASSWORD_AUTH</c>. You can't assign these legacy <c>ExplicitAuthFlows</c>
        /// values to user pool clients at the same time as values that begin with <c>ALLOW_</c>,
        /// like <c>ALLOW_USER_SRP_AUTH</c>.</para>
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
        /// <para>A time unit of <c>seconds</c>, <c>minutes</c>, <c>hours</c>, or <c>days</c> for the
        /// value that you set in the <c>IdTokenValidity</c> parameter. The default <c>IdTokenValidity</c>
        /// time unit is hours. <c>IdTokenValidity</c> duration can range from five minutes to
        /// one day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TimeUnitsType")]
        public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_IdToken { get; set; }
        #endregion
        
        #region Parameter IdTokenValidity
        /// <summary>
        /// <para>
        /// <para>The ID token time limit. After this limit expires, your user can't use their ID token.
        /// To specify the time unit for <c>IdTokenValidity</c> as <c>seconds</c>, <c>minutes</c>,
        /// <c>hours</c>, or <c>days</c>, set a <c>TokenValidityUnits</c> value in your API request.</para><para>For example, when you set <c>IdTokenValidity</c> as <c>10</c> and <c>TokenValidityUnits</c>
        /// as <c>hours</c>, your user can authenticate their session with their ID token for
        /// 10 hours.</para><para>The default time unit for <c>IdTokenValidity</c> in an API request is hours. <i>Valid
        /// range</i> is displayed below in seconds.</para><para>If you don't specify otherwise in the configuration of your app client, your ID tokens
        /// are valid for one hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IdTokenValidity { get; set; }
        #endregion
        
        #region Parameter LogoutURLs
        /// <summary>
        /// <para>
        /// <para>A list of allowed logout URLs for the IdPs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] LogoutURLs { get; set; }
        #endregion
        
        #region Parameter PreventUserExistenceError
        /// <summary>
        /// <para>
        /// <para>Errors and responses that you want Amazon Cognito APIs to return during authentication,
        /// account confirmation, and password recovery when the user doesn't exist in the user
        /// pool. When set to <c>ENABLED</c> and the user doesn't exist, authentication returns
        /// an error indicating either the username or password was incorrect. Account confirmation
        /// and password recovery return a response indicating a code was sent to a simulated
        /// destination. When set to <c>LEGACY</c>, those APIs return a <c>UserNotFoundException</c>
        /// exception if the user doesn't exist in the user pool.</para><para>Valid values include:</para><ul><li><para><c>ENABLED</c> - This prevents user existence-related errors.</para></li><li><para><c>LEGACY</c> - This represents the early behavior of Amazon Cognito where user existence
        /// related errors aren't prevented.</para></li></ul>
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
        /// <para>The list of user attributes that you want your app client to have read-only access
        /// to. After your user authenticates in your app, their access token authorizes them
        /// to read their own attribute value for any attribute in this list. An example of this
        /// kind of activity is when your user selects a link to view their profile information.
        /// Your app makes a <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_GetUser.html">GetUser</a>
        /// API request to retrieve and display your user's profile data.</para><para>When you don't specify the <c>ReadAttributes</c> for your app client, your app can
        /// read the values of <c>email_verified</c>, <c>phone_number_verified</c>, and the Standard
        /// attributes of your user pool. When your user pool has read access to these default
        /// attributes, <c>ReadAttributes</c> doesn't return any information. Amazon Cognito only
        /// populates <c>ReadAttributes</c> in the API response if you have specified your own
        /// custom set of read attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReadAttributes")]
        public System.String[] ReadAttribute { get; set; }
        #endregion
        
        #region Parameter TokenValidityUnits_RefreshToken
        /// <summary>
        /// <para>
        /// <para>A time unit of <c>seconds</c>, <c>minutes</c>, <c>hours</c>, or <c>days</c> for the
        /// value that you set in the <c>RefreshTokenValidity</c> parameter. The default <c>RefreshTokenValidity</c>
        /// time unit is days. <c>RefreshTokenValidity</c> duration can range from 60 minutes
        /// to 10 years.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TimeUnitsType")]
        public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_RefreshToken { get; set; }
        #endregion
        
        #region Parameter RefreshTokenValidity
        /// <summary>
        /// <para>
        /// <para>The refresh token time limit. After this limit expires, your user can't use their
        /// refresh token. To specify the time unit for <c>RefreshTokenValidity</c> as <c>seconds</c>,
        /// <c>minutes</c>, <c>hours</c>, or <c>days</c>, set a <c>TokenValidityUnits</c> value
        /// in your API request.</para><para>For example, when you set <c>RefreshTokenValidity</c> as <c>10</c> and <c>TokenValidityUnits</c>
        /// as <c>days</c>, your user can refresh their session and retrieve new access and ID
        /// tokens for 10 days.</para><para>The default time unit for <c>RefreshTokenValidity</c> in an API request is days. You
        /// can't set <c>RefreshTokenValidity</c> to 0. If you do, Amazon Cognito overrides the
        /// value with the default value of 30 days. <i>Valid range</i> is displayed below in
        /// seconds.</para><para>If you don't specify otherwise in the configuration of your app client, your refresh
        /// tokens are valid for 30 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RefreshTokenValidity { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an Identity and Access Management role that authorizes Amazon Cognito to
        /// publish events to Amazon Pinpoint analytics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter SupportedIdentityProvider
        /// <summary>
        /// <para>
        /// <para>A list of provider names for the identity providers (IdPs) that are supported on this
        /// client. The following are supported: <c>COGNITO</c>, <c>Facebook</c>, <c>Google</c>,
        /// <c>SignInWithApple</c>, and <c>LoginWithAmazon</c>. You can also specify the names
        /// that you configured for the SAML and OIDC IdPs in your user pool, for example <c>MySAMLIdP</c>
        /// or <c>MyOIDCIdP</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedIdentityProviders")]
        public System.String[] SupportedIdentityProvider { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_UserDataShared
        /// <summary>
        /// <para>
        /// <para>If <c>UserDataShared</c> is <c>true</c>, Amazon Cognito includes user data in the
        /// events that it publishes to Amazon Pinpoint analytics.</para>
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
        /// <para>The list of user attributes that you want your app client to have write access to.
        /// After your user authenticates in your app, their access token authorizes them to set
        /// or modify their own attribute value for any attribute in this list. An example of
        /// this kind of activity is when you present your user with a form to update their profile
        /// information and they change their last name. Your app then makes an <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_UpdateUserAttributes.html">UpdateUserAttributes</a>
        /// API request and sets <c>family_name</c> to the new value. </para><para>When you don't specify the <c>WriteAttributes</c> for your app client, your app can
        /// write the values of the Standard attributes of your user pool. When your user pool
        /// has write access to these default attributes, <c>WriteAttributes</c> doesn't return
        /// any information. Amazon Cognito only populates <c>WriteAttributes</c> in the API response
        /// if you have specified your own custom set of write attributes.</para><para>If your app client allows users to sign in through an IdP, this array must include
        /// all attributes that you have mapped to IdP attributes. Amazon Cognito updates mapped
        /// attributes when users sign in to your application through an IdP. If your app client
        /// does not have write access to a mapped attribute, Amazon Cognito throws an error when
        /// it tries to update the attribute. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-specifying-attribute-mapping.html">Specifying
        /// IdP Attribute Mappings for Your user pool</a>.</para>
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
            this._AWSSignerType = "v4";
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
            context.AuthSessionValidity = this.AuthSessionValidity;
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
            context.EnablePropagateAdditionalUserContextData = this.EnablePropagateAdditionalUserContextData;
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
            if (cmdletContext.AuthSessionValidity != null)
            {
                request.AuthSessionValidity = cmdletContext.AuthSessionValidity.Value;
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
            if (cmdletContext.EnablePropagateAdditionalUserContextData != null)
            {
                request.EnablePropagateAdditionalUserContextData = cmdletContext.EnablePropagateAdditionalUserContextData.Value;
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
            public System.Int32? AuthSessionValidity { get; set; }
            public List<System.String> CallbackURLs { get; set; }
            public System.String ClientName { get; set; }
            public System.String DefaultRedirectURI { get; set; }
            public System.Boolean? EnablePropagateAdditionalUserContextData { get; set; }
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
