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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Given a user pool app client ID, updates the configuration. To avoid setting parameters
    /// to Amazon Cognito defaults, construct this API request to pass the existing configuration
    /// of your app client, modified to include the changes that you want to make.
    /// 
    ///  <important><para>
    /// If you don't provide a value for an attribute, Amazon Cognito sets it to its default
    /// value.
    /// </para></important><para>
    /// Unlike app clients created in the console, Amazon Cognito doesn't automatically assign
    /// a branding style to app clients that you configure with this API operation. Managed
    /// login and classic hosted UI pages aren't available for your client until after you
    /// apply a branding style.
    /// </para><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Update", "CGIPUserPoolClient", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.UserPoolClientType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider UpdateUserPoolClient API operation.", Operation = new[] {"UpdateUserPoolClient"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.UserPoolClientType or Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.UserPoolClientType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCGIPUserPoolClientCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TokenValidityUnits_AccessToken
        /// <summary>
        /// <para>
        /// <para> A time unit for the value that you set in the <c>AccessTokenValidity</c> parameter.
        /// The default <c>AccessTokenValidity</c> time unit is <c>hours</c>. <c>AccessTokenValidity</c>
        /// duration can range from five minutes to one day.</para>
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
        /// <para>The OAuth grant types that you want your app client to generate. To create an app
        /// client that generates client credentials grants, you must add <c>client_credentials</c>
        /// as the only allowed OAuth flow.</para><dl><dt>code</dt><dd><para>Use a code grant flow, which provides an authorization code as the response. This
        /// code can be exchanged for access tokens with the <c>/oauth2/token</c> endpoint.</para></dd><dt>implicit</dt><dd><para>Issue the access token (and, optionally, ID token, based on scopes) directly to your
        /// user.</para></dd><dt>client_credentials</dt><dd><para>Issue the access token from the <c>/oauth2/token</c> endpoint directly to a non-person
        /// user using a combination of the client ID and client secret.</para></dd></dl><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedOAuthFlows")]
        public System.String[] AllowedOAuthFlow { get; set; }
        #endregion
        
        #region Parameter AllowedOAuthFlowsUserPoolClient
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to use OAuth 2.0 authorization server features in your app client.</para><para>This parameter must have a value of <c>true</c> before you can configure the following
        /// features in your app client.</para><ul><li><para><c>CallBackURLs</c>: Callback URLs.</para></li><li><para><c>LogoutURLs</c>: Sign-out redirect URLs.</para></li><li><para><c>AllowedOAuthScopes</c>: OAuth 2.0 scopes.</para></li><li><para><c>AllowedOAuthFlows</c>: Support for authorization code, implicit, and client credentials
        /// OAuth 2.0 grants.</para></li></ul><para>To use authorization server features, configure one of these features in the Amazon
        /// Cognito console or set <c>AllowedOAuthFlowsUserPoolClient</c> to <c>true</c> in a
        /// <c>CreateUserPoolClient</c> or <c>UpdateUserPoolClient</c> API request. If you don't
        /// set a value for <c>AllowedOAuthFlowsUserPoolClient</c> in a request with the CLI or
        /// SDKs, it defaults to <c>false</c>. When <c>false</c>, only SDK-based API sign-in is
        /// permitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowedOAuthFlowsUserPoolClient { get; set; }
        #endregion
        
        #region Parameter AllowedOAuthScope
        /// <summary>
        /// <para>
        /// <para>The OAuth, OpenID Connect (OIDC), and custom scopes that you want to permit your app
        /// client to authorize access with. Scopes govern access control to user pool self-service
        /// API operations, user data from the <c>userInfo</c> endpoint, and third-party APIs.
        /// Scope values include <c>phone</c>, <c>email</c>, <c>openid</c>, and <c>profile</c>.
        /// The <c>aws.cognito.signin.user.admin</c> scope authorizes user self-service operations.
        /// Custom scopes with resource servers authorize access to external APIs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedOAuthScopes")]
        public System.String[] AllowedOAuthScope { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_ApplicationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon Pinpoint project that you want to connect
        /// to your user pool app client. Amazon Cognito publishes events to the Amazon Pinpoint
        /// project that <c>ApplicationArn</c> declares. You can also configure your application
        /// to pass an endpoint ID in the <c>AnalyticsMetadata</c> parameter of sign-in operations.
        /// The endpoint ID is information about the destination for push notifications</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsConfiguration_ApplicationArn { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_ApplicationId
        /// <summary>
        /// <para>
        /// <para>Your Amazon Pinpoint project ID.</para>
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
        /// <para>A list of allowed redirect, or callback, URLs for managed login authentication. These
        /// URLs are the paths where you want to send your users' browsers after they complete
        /// authentication with managed login or a third-party IdP. Typically, callback URLs are
        /// the home of an application that uses OAuth or OIDC libraries to process authentication
        /// outcomes.</para><para>A redirect URI must meet the following requirements:</para><ul><li><para>Be an absolute URI.</para></li><li><para>Be registered with the authorization server. Amazon Cognito doesn't accept authorization
        /// requests with <c>redirect_uri</c> values that aren't in the list of <c>CallbackURLs</c>
        /// that you provide in this parameter.</para></li><li><para>Not include a fragment component.</para></li></ul><para>See <a href="https://tools.ietf.org/html/rfc6749#section-3.1.2">OAuth 2.0 - Redirection
        /// Endpoint</a>.</para><para>Amazon Cognito requires HTTPS over HTTP except for http://localhost for testing purposes
        /// only.</para><para>App callback URLs such as <c>myapp://example</c> are also supported.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CallbackURLs { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The ID of the app client that you want to update.</para>
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
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter ClientName
        /// <summary>
        /// <para>
        /// <para>A friendly name for the app client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientName { get; set; }
        #endregion
        
        #region Parameter DefaultRedirectURI
        /// <summary>
        /// <para>
        /// <para>The default redirect URI. In app clients with one assigned IdP, replaces <c>redirect_uri</c>
        /// in authentication requests. Must be in the <c>CallbackURLs</c> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultRedirectURI { get; set; }
        #endregion
        
        #region Parameter EnablePropagateAdditionalUserContextData
        /// <summary>
        /// <para>
        /// <para>When <c>true</c>, your application can include additional <c>UserContextData</c> in
        /// authentication requests. This data includes the IP address, and contributes to analysis
        /// by threat protection features. For more information about propagation of user context
        /// data, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pool-settings-adaptive-authentication.html#user-pool-settings-adaptive-authentication-device-fingerprint">Adding
        /// session data to API requests</a>. If you don’t include this parameter, you can't send
        /// the source IP address to Amazon Cognito threat protection features. You can only activate
        /// <c>EnablePropagateAdditionalUserContextData</c> in an app client that has a client
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePropagateAdditionalUserContextData { get; set; }
        #endregion
        
        #region Parameter EnableTokenRevocation
        /// <summary>
        /// <para>
        /// <para>Activates or deactivates <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/token-revocation.html">token
        /// revocation</a> in the target app client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableTokenRevocation { get; set; }
        #endregion
        
        #region Parameter ExplicitAuthFlow
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-authentication-flow-methods.html">authentication
        /// flows</a> that you want your user pool client to support. For each app client in your
        /// user pool, you can sign in your users with any combination of one or more flows, including
        /// with a user name and Secure Remote Password (SRP), a user name and password, or a
        /// custom authentication process that you define with Lambda functions.</para><note><para>If you don't specify a value for <c>ExplicitAuthFlows</c>, your app client supports
        /// <c>ALLOW_REFRESH_TOKEN_AUTH</c>, <c>ALLOW_USER_SRP_AUTH</c>, and <c>ALLOW_CUSTOM_AUTH</c>.
        /// </para></note><para>The values for authentication flow options include the following.</para><ul><li><para><c>ALLOW_USER_AUTH</c>: Enable selection-based sign-in with <c>USER_AUTH</c>. This
        /// setting covers username-password, secure remote password (SRP), passwordless, and
        /// passkey authentication. This authentiation flow can do username-password and SRP authentication
        /// without other <c>ExplicitAuthFlows</c> permitting them. For example users can complete
        /// an SRP challenge through <c>USER_AUTH</c> without the flow <c>USER_SRP_AUTH</c> being
        /// active for the app client. This flow doesn't include <c>CUSTOM_AUTH</c>. </para><para>To activate this setting, your user pool must be in the <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/feature-plans-features-essentials.html">
        /// Essentials tier</a> or higher.</para></li><li><para><c>ALLOW_ADMIN_USER_PASSWORD_AUTH</c>: Enable admin based user password authentication
        /// flow <c>ADMIN_USER_PASSWORD_AUTH</c>. This setting replaces the <c>ADMIN_NO_SRP_AUTH</c>
        /// setting. With this authentication flow, your app passes a user name and password to
        /// Amazon Cognito in the request, instead of using the Secure Remote Password (SRP) protocol
        /// to securely transmit the password.</para></li><li><para><c>ALLOW_CUSTOM_AUTH</c>: Enable Lambda trigger based authentication.</para></li><li><para><c>ALLOW_USER_PASSWORD_AUTH</c>: Enable user password-based authentication. In this
        /// flow, Amazon Cognito receives the password in the request instead of using the SRP
        /// protocol to verify passwords.</para></li><li><para><c>ALLOW_USER_SRP_AUTH</c>: Enable SRP-based authentication.</para></li><li><para><c>ALLOW_REFRESH_TOKEN_AUTH</c>: Enable authflow to refresh tokens.</para></li></ul><para>In some environments, you will see the values <c>ADMIN_NO_SRP_AUTH</c>, <c>CUSTOM_AUTH_FLOW_ONLY</c>,
        /// or <c>USER_PASSWORD_AUTH</c>. You can't assign these legacy <c>ExplicitAuthFlows</c>
        /// values to user pool clients at the same time as values that begin with <c>ALLOW_</c>,
        /// like <c>ALLOW_USER_SRP_AUTH</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExplicitAuthFlows")]
        public System.String[] ExplicitAuthFlow { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_ExternalId
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_create_for-user_externalid.html">external
        /// ID</a> of the role that Amazon Cognito assumes to send analytics data to Amazon Pinpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsConfiguration_ExternalId { get; set; }
        #endregion
        
        #region Parameter RefreshTokenRotation_Feature
        /// <summary>
        /// <para>
        /// <para>The state of refresh token rotation for the current app client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.FeatureType")]
        public Amazon.CognitoIdentityProvider.FeatureType RefreshTokenRotation_Feature { get; set; }
        #endregion
        
        #region Parameter TokenValidityUnits_IdToken
        /// <summary>
        /// <para>
        /// <para>A time unit for the value that you set in the <c>IdTokenValidity</c> parameter. The
        /// default <c>IdTokenValidity</c> time unit is <c>hours</c>. <c>IdTokenValidity</c> duration
        /// can range from five minutes to one day.</para>
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
        /// <para>A list of allowed logout URLs for managed login authentication. When you pass <c>logout_uri</c>
        /// and <c>client_id</c> parameters to <c>/logout</c>, Amazon Cognito signs out your user
        /// and redirects them to the logout URL. This parameter describes the URLs that you want
        /// to be the permitted targets of <c>logout_uri</c>. A typical use of these URLs is when
        /// a user selects "Sign out" and you redirect them to your public homepage. For more
        /// information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/logout-endpoint.html">Logout
        /// endpoint</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] LogoutURLs { get; set; }
        #endregion
        
        #region Parameter PreventUserExistenceError
        /// <summary>
        /// <para>
        /// <para>When <c>ENABLED</c>, suppresses messages that might indicate a valid user exists when
        /// someone attempts sign-in. This parameters sets your preference for the errors and
        /// responses that you want Amazon Cognito APIs to return during authentication, account
        /// confirmation, and password recovery when the user doesn't exist in the user pool.
        /// When set to <c>ENABLED</c> and the user doesn't exist, authentication returns an error
        /// indicating either the username or password was incorrect. Account confirmation and
        /// password recovery return a response indicating a code was sent to a simulated destination.
        /// When set to <c>LEGACY</c>, those APIs return a <c>UserNotFoundException</c> exception
        /// if the user doesn't exist in the user pool.</para><para>Defaults to <c>LEGACY</c>.</para>
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
        /// <para>The list of user attributes that you want your app client to have read access to.
        /// After your user authenticates in your app, their access token authorizes them to read
        /// their own attribute value for any attribute in this list.</para><para>When you don't specify the <c>ReadAttributes</c> for your app client, your app can
        /// read the values of <c>email_verified</c>, <c>phone_number_verified</c>, and the standard
        /// attributes of your user pool. When your user pool app client has read access to these
        /// default attributes, <c>ReadAttributes</c> doesn't return any information. Amazon Cognito
        /// only populates <c>ReadAttributes</c> in the API response if you have specified your
        /// own custom set of read attributes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReadAttributes")]
        public System.String[] ReadAttribute { get; set; }
        #endregion
        
        #region Parameter TokenValidityUnits_RefreshToken
        /// <summary>
        /// <para>
        /// <para>A time unit for the value that you set in the <c>RefreshTokenValidity</c> parameter.
        /// The default <c>RefreshTokenValidity</c> time unit is <c>days</c>. <c>RefreshTokenValidity</c>
        /// duration can range from 60 minutes to 10 years.</para>
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
        
        #region Parameter RefreshTokenRotation_RetryGracePeriodSecond
        /// <summary>
        /// <para>
        /// <para>When you request a token refresh with <c>GetTokensFromRefreshToken</c>, the original
        /// refresh token that you're rotating out can remain valid for a period of time of up
        /// to 60 seconds. This allows for client-side retries. When <c>RetryGracePeriodSeconds</c>
        /// is <c>0</c>, the grace period is disabled and a successful request immediately invalidates
        /// the submitted refresh token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RefreshTokenRotation_RetryGracePeriodSeconds")]
        public System.Int32? RefreshTokenRotation_RetryGracePeriodSecond { get; set; }
        #endregion
        
        #region Parameter AnalyticsConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an Identity and Access Management role that has the permissions required
        /// for Amazon Cognito to publish events to Amazon Pinpoint analytics.</para>
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
        /// or <c>MyOIDCIdP</c>.</para><para>This parameter sets the IdPs that <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-managed-login.html">managed
        /// login</a> will display on the login page for your app client. The removal of <c>COGNITO</c>
        /// from this list doesn't prevent authentication operations for local users with the
        /// user pools API in an Amazon Web Services SDK. The only way to prevent SDK-based authentication
        /// is to block access with a <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-waf.html">WAF
        /// rule</a>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>The ID of the user pool where you want to update the app client.</para>
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
        /// or modify their own attribute value for any attribute in this list.</para><para>When you don't specify the <c>WriteAttributes</c> for your app client, your app can
        /// write the values of the Standard attributes of your user pool. When your user pool
        /// has write access to these default attributes, <c>WriteAttributes</c> doesn't return
        /// any information. Amazon Cognito only populates <c>WriteAttributes</c> in the API response
        /// if you have specified your own custom set of write attributes.</para><para>If your app client allows users to sign in through an IdP, this array must include
        /// all attributes that you have mapped to IdP attributes. Amazon Cognito updates mapped
        /// attributes when users sign in to your application through an IdP. If your app client
        /// does not have write access to a mapped attribute, Amazon Cognito throws an error when
        /// it tries to update the attribute. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-specifying-attribute-mapping.html">Specifying
        /// IdP Attribute Mappings for Your user pool</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WriteAttributes")]
        public System.String[] WriteAttribute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserPoolClient'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserPoolClient";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIPUserPoolClient (UpdateUserPoolClient)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientResponse, UpdateCGIPUserPoolClientCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientName = this.ClientName;
            context.DefaultRedirectURI = this.DefaultRedirectURI;
            context.EnablePropagateAdditionalUserContextData = this.EnablePropagateAdditionalUserContextData;
            context.EnableTokenRevocation = this.EnableTokenRevocation;
            if (this.ExplicitAuthFlow != null)
            {
                context.ExplicitAuthFlow = new List<System.String>(this.ExplicitAuthFlow);
            }
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
            context.RefreshTokenRotation_Feature = this.RefreshTokenRotation_Feature;
            context.RefreshTokenRotation_RetryGracePeriodSecond = this.RefreshTokenRotation_RetryGracePeriodSecond;
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
            var request = new Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientRequest();
            
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
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
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
            
             // populate RefreshTokenRotation
            var requestRefreshTokenRotationIsNull = true;
            request.RefreshTokenRotation = new Amazon.CognitoIdentityProvider.Model.RefreshTokenRotationType();
            Amazon.CognitoIdentityProvider.FeatureType requestRefreshTokenRotation_refreshTokenRotation_Feature = null;
            if (cmdletContext.RefreshTokenRotation_Feature != null)
            {
                requestRefreshTokenRotation_refreshTokenRotation_Feature = cmdletContext.RefreshTokenRotation_Feature;
            }
            if (requestRefreshTokenRotation_refreshTokenRotation_Feature != null)
            {
                request.RefreshTokenRotation.Feature = requestRefreshTokenRotation_refreshTokenRotation_Feature;
                requestRefreshTokenRotationIsNull = false;
            }
            System.Int32? requestRefreshTokenRotation_refreshTokenRotation_RetryGracePeriodSecond = null;
            if (cmdletContext.RefreshTokenRotation_RetryGracePeriodSecond != null)
            {
                requestRefreshTokenRotation_refreshTokenRotation_RetryGracePeriodSecond = cmdletContext.RefreshTokenRotation_RetryGracePeriodSecond.Value;
            }
            if (requestRefreshTokenRotation_refreshTokenRotation_RetryGracePeriodSecond != null)
            {
                request.RefreshTokenRotation.RetryGracePeriodSeconds = requestRefreshTokenRotation_refreshTokenRotation_RetryGracePeriodSecond.Value;
                requestRefreshTokenRotationIsNull = false;
            }
             // determine if request.RefreshTokenRotation should be set to null
            if (requestRefreshTokenRotationIsNull)
            {
                request.RefreshTokenRotation = null;
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
        
        private Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "UpdateUserPoolClient");
            try
            {
                return client.UpdateUserPoolClientAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientId { get; set; }
            public System.String ClientName { get; set; }
            public System.String DefaultRedirectURI { get; set; }
            public System.Boolean? EnablePropagateAdditionalUserContextData { get; set; }
            public System.Boolean? EnableTokenRevocation { get; set; }
            public List<System.String> ExplicitAuthFlow { get; set; }
            public System.Int32? IdTokenValidity { get; set; }
            public List<System.String> LogoutURLs { get; set; }
            public Amazon.CognitoIdentityProvider.PreventUserExistenceErrorTypes PreventUserExistenceError { get; set; }
            public List<System.String> ReadAttribute { get; set; }
            public Amazon.CognitoIdentityProvider.FeatureType RefreshTokenRotation_Feature { get; set; }
            public System.Int32? RefreshTokenRotation_RetryGracePeriodSecond { get; set; }
            public System.Int32? RefreshTokenValidity { get; set; }
            public List<System.String> SupportedIdentityProvider { get; set; }
            public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_AccessToken { get; set; }
            public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_IdToken { get; set; }
            public Amazon.CognitoIdentityProvider.TimeUnitsType TokenValidityUnits_RefreshToken { get; set; }
            public System.String UserPoolId { get; set; }
            public List<System.String> WriteAttribute { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.UpdateUserPoolClientResponse, UpdateCGIPUserPoolClientCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserPoolClient;
        }
        
    }
}
