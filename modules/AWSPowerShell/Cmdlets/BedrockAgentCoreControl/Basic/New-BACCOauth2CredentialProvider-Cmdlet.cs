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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Creates a new OAuth2 credential provider.
    /// </summary>
    [Cmdlet("New", "BACCOauth2CredentialProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateOauth2CredentialProvider API operation.", Operation = new[] {"CreateOauth2CredentialProvider"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse object containing multiple properties."
    )]
    public partial class NewBACCOauth2CredentialProviderCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent
        /// <summary>
        /// <para>
        /// <para>The content type for the actor token in the token exchange.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.ActorTokenContentType")]
        public Amazon.BedrockAgentCoreControl.ActorTokenContentType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope
        /// <summary>
        /// <para>
        /// <para>The scopes for the actor token. Only valid when actorTokenContent is M2M.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScopes")]
        public System.String[] Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope { get; set; }
        #endregion
        
        #region Parameter AuthorizationServerMetadata_AuthorizationEndpoint
        /// <summary>
        /// <para>
        /// <para>The authorization endpoint URL for the OAuth2 authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_AuthorizationEndpoint")]
        public System.String AuthorizationServerMetadata_AuthorizationEndpoint { get; set; }
        #endregion
        
        #region Parameter IncludedOauth2ProviderConfig_AuthorizationEndpoint
        /// <summary>
        /// <para>
        /// <para>OAuth2 authorization endpoint for your isolated OAuth2 application tenant. This is
        /// where users are redirected to authenticate and authorize access to their resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_AuthorizationEndpoint")]
        public System.String IncludedOauth2ProviderConfig_AuthorizationEndpoint { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>The client authentication method to use when authenticating with the token endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.ClientAuthenticationMethodType")]
        public Amazon.BedrockAgentCoreControl.ClientAuthenticationMethodType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter AtlassianOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the Atlassian OAuth2 provider. This identifier is assigned by Atlassian
        /// when you register your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientId")]
        public System.String AtlassianOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter CustomOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the custom OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientId")]
        public System.String CustomOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter GithubOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the GitHub OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientId")]
        public System.String GithubOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter GoogleOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the Google OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientId")]
        public System.String GoogleOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter IncludedOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the supported OAuth2 provider. This identifier is assigned by the
        /// OAuth2 provider when you register your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientId")]
        public System.String IncludedOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter LinkedinOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the LinkedIn OAuth2 provider. This identifier is assigned by LinkedIn
        /// when you register your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientId")]
        public System.String LinkedinOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter MicrosoftOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the Microsoft OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientId")]
        public System.String MicrosoftOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter SalesforceOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the Salesforce OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientId")]
        public System.String SalesforceOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter SlackOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the Slack OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientId")]
        public System.String SlackOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter AtlassianOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the Atlassian OAuth2 provider. This secret is assigned by Atlassian
        /// and used along with the client ID to authenticate your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecret")]
        public System.String AtlassianOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter CustomOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the custom OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecret")]
        public System.String CustomOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter GithubOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the GitHub OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecret")]
        public System.String GithubOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter GoogleOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the Google OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecret")]
        public System.String GoogleOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter IncludedOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the supported OAuth2 provider. This secret is assigned by the
        /// OAuth2 provider and used along with the client ID to authenticate your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecret")]
        public System.String IncludedOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter LinkedinOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the LinkedIn OAuth2 provider. This secret is assigned by LinkedIn
        /// and used along with the client ID to authenticate your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecret")]
        public System.String LinkedinOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter MicrosoftOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the Microsoft OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecret")]
        public System.String MicrosoftOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter SalesforceOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the Salesforce OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecret")]
        public System.String SalesforceOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter SlackOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the Slack OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecret")]
        public System.String SlackOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the client secret for the Atlassian OAuth2 provider. Use <c>MANAGED</c>
        /// if the secret is managed by the service, or <c>EXTERNAL</c> if you manage the secret
        /// yourself in AWS Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the client secret. Use <c>MANAGED</c> if the secret is managed
        /// by the service, or <c>EXTERNAL</c> if you manage the secret yourself in AWS Secrets
        /// Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the client secret. Use <c>MANAGED</c> if the secret is managed
        /// by the service, or <c>EXTERNAL</c> if you manage the secret yourself in AWS Secrets
        /// Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the client secret. Use <c>MANAGED</c> if the secret is managed
        /// by the service, or <c>EXTERNAL</c> if you manage the secret yourself in AWS Secrets
        /// Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the client secret. Use <c>MANAGED</c> if the secret is managed
        /// by the service, or <c>EXTERNAL</c> if you manage the secret yourself in AWS Secrets
        /// Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the client secret. Use <c>MANAGED</c> if the secret is managed
        /// by the service, or <c>EXTERNAL</c> if you manage the secret yourself in AWS Secrets
        /// Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the client secret. Use <c>MANAGED</c> if the secret is managed
        /// by the service, or <c>EXTERNAL</c> if you manage the secret yourself in AWS Secrets
        /// Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the client secret. Use <c>MANAGED</c> if the secret is managed
        /// by the service, or <c>EXTERNAL</c> if you manage the secret yourself in AWS Secrets
        /// Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the client secret. Use <c>MANAGED</c> if the secret is managed
        /// by the service, or <c>EXTERNAL</c> if you manage the secret yourself in AWS Secrets
        /// Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource { get; set; }
        #endregion
        
        #region Parameter CredentialProviderVendor
        /// <summary>
        /// <para>
        /// <para>The vendor of the OAuth2 credential provider. This specifies which OAuth2 implementation
        /// to use.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.CredentialProviderVendorType")]
        public Amazon.BedrockAgentCoreControl.CredentialProviderVendorType CredentialProviderVendor { get; set; }
        #endregion
        
        #region Parameter OauthDiscovery_DiscoveryUrl
        /// <summary>
        /// <para>
        /// <para>The discovery URL for the OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_DiscoveryUrl")]
        public System.String OauthDiscovery_DiscoveryUrl { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type for the resource configuration endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.EndpointIpAddressType")]
        public Amazon.BedrockAgentCoreControl.EndpointIpAddressType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType
        /// <summary>
        /// <para>
        /// <para>The grant type for the on-behalf-of token exchange.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.OnBehalfOfTokenExchangeGrantTypeType")]
        public Amazon.BedrockAgentCoreControl.OnBehalfOfTokenExchangeGrantTypeType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType { get; set; }
        #endregion
        
        #region Parameter AuthorizationServerMetadata_Issuer
        /// <summary>
        /// <para>
        /// <para>The issuer URL for the OAuth2 authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_Issuer")]
        public System.String AuthorizationServerMetadata_Issuer { get; set; }
        #endregion
        
        #region Parameter IncludedOauth2ProviderConfig_Issuer
        /// <summary>
        /// <para>
        /// <para>Token issuer of your isolated OAuth2 application tenant. This URL identifies the authorization
        /// server that issues tokens for this provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_Issuer")]
        public System.String IncludedOauth2ProviderConfig_Issuer { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the OAuth2 credential provider. The name must be unique within your account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride
        /// <summary>
        /// <para>
        /// <para>The private endpoint overrides for the custom OAuth2 provider configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverrides")]
        public Amazon.BedrockAgentCoreControl.Model.PrivateEndpointOverride[] Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN or ID of the VPC Lattice resource configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter AuthorizationServerMetadata_ResponseType
        /// <summary>
        /// <para>
        /// <para>The supported response types for the OAuth2 authorization server.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_ResponseTypes")]
        public System.String[] AuthorizationServerMetadata_ResponseType { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain
        /// <summary>
        /// <para>
        /// <para>An intermediate domain to use as the resource configuration endpoint instead of the
        /// actual target domain. Use this when you want to route traffic through an intermediate
        /// component such as a VPC endpoint or internal load balancer. For more information,
        /// see xref:lattice-vpc-egress-routing-domain[Route traffic through an intermediate domain].</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The security group IDs to associate with the VPC Lattice resource gateway. If not
        /// specified, the default security group for the VPC is used.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupIds")]
        public System.String[] Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId
        /// <summary>
        /// <para>
        /// <para>The subnet IDs within the VPC where the VPC Lattice resource gateway is placed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetIds")]
        public System.String[] Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag
        /// <summary>
        /// <para>
        /// <para>Tags to apply to the managed VPC Lattice resource gateway.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tags")]
        public System.Collections.Hashtable Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tag keys and values to assign to the OAuth2 credential provider. Tags enable
        /// you to categorize your resources in different ways, for example, by purpose, owner,
        /// or environment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter MicrosoftOauth2ProviderConfig_TenantId
        /// <summary>
        /// <para>
        /// <para>The Microsoft Entra ID (formerly Azure AD) tenant ID for your organization. This identifies
        /// the specific tenant within Microsoft's identity platform where your application is
        /// registered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_TenantId")]
        public System.String MicrosoftOauth2ProviderConfig_TenantId { get; set; }
        #endregion
        
        #region Parameter AuthorizationServerMetadata_TokenEndpoint
        /// <summary>
        /// <para>
        /// <para>The token endpoint URL for the OAuth2 authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_TokenEndpoint")]
        public System.String AuthorizationServerMetadata_TokenEndpoint { get; set; }
        #endregion
        
        #region Parameter IncludedOauth2ProviderConfig_TokenEndpoint
        /// <summary>
        /// <para>
        /// <para>OAuth2 token endpoint for your isolated OAuth2 application tenant. This is where authorization
        /// codes are exchanged for access tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_TokenEndpoint")]
        public System.String IncludedOauth2ProviderConfig_TokenEndpoint { get; set; }
        #endregion
        
        #region Parameter AuthorizationServerMetadata_TokenEndpointAuthMethod
        /// <summary>
        /// <para>
        /// <para>The authentication methods supported by the token endpoint. This specifies how clients
        /// can authenticate when requesting tokens from the authorization server.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_TokenEndpointAuthMethods")]
        public System.String[] AuthorizationServerMetadata_TokenEndpointAuthMethod { get; set; }
        #endregion
        
        #region Parameter Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC that contains your private resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCOauth2CredentialProvider (CreateOauth2CredentialProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse, NewBACCOauth2CredentialProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CredentialProviderVendor = this.CredentialProviderVendor;
            #if MODULAR
            if (this.CredentialProviderVendor == null && ParameterWasBound(nameof(this.CredentialProviderVendor)))
            {
                WriteWarning("You are passing $null as a value for parameter CredentialProviderVendor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AtlassianOauth2ProviderConfig_ClientId = this.AtlassianOauth2ProviderConfig_ClientId;
            context.AtlassianOauth2ProviderConfig_ClientSecret = this.AtlassianOauth2ProviderConfig_ClientSecret;
            context.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey = this.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            context.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId = this.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId;
            context.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource = this.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource;
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod;
            context.CustomOauth2ProviderConfig_ClientId = this.CustomOauth2ProviderConfig_ClientId;
            context.CustomOauth2ProviderConfig_ClientSecret = this.CustomOauth2ProviderConfig_ClientSecret;
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId;
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource;
            context.AuthorizationServerMetadata_AuthorizationEndpoint = this.AuthorizationServerMetadata_AuthorizationEndpoint;
            context.AuthorizationServerMetadata_Issuer = this.AuthorizationServerMetadata_Issuer;
            if (this.AuthorizationServerMetadata_ResponseType != null)
            {
                context.AuthorizationServerMetadata_ResponseType = new List<System.String>(this.AuthorizationServerMetadata_ResponseType);
            }
            context.AuthorizationServerMetadata_TokenEndpoint = this.AuthorizationServerMetadata_TokenEndpoint;
            if (this.AuthorizationServerMetadata_TokenEndpointAuthMethod != null)
            {
                context.AuthorizationServerMetadata_TokenEndpointAuthMethod = new List<System.String>(this.AuthorizationServerMetadata_TokenEndpointAuthMethod);
            }
            context.OauthDiscovery_DiscoveryUrl = this.OauthDiscovery_DiscoveryUrl;
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType;
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent;
            if (this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope != null)
            {
                context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope = new List<System.String>(this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope);
            }
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType;
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain;
            if (this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId != null)
            {
                context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId = new List<System.String>(this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId);
            }
            if (this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId != null)
            {
                context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId = new List<System.String>(this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId);
            }
            if (this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag != null)
            {
                context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag.Keys)
                {
                    context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag.Add((String)hashKey, (System.String)(this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag[hashKey]));
                }
            }
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier;
            context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier = this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier;
            if (this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride != null)
            {
                context.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride = new List<Amazon.BedrockAgentCoreControl.Model.PrivateEndpointOverride>(this.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride);
            }
            context.GithubOauth2ProviderConfig_ClientId = this.GithubOauth2ProviderConfig_ClientId;
            context.GithubOauth2ProviderConfig_ClientSecret = this.GithubOauth2ProviderConfig_ClientSecret;
            context.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey = this.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            context.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId = this.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId;
            context.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource = this.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource;
            context.GoogleOauth2ProviderConfig_ClientId = this.GoogleOauth2ProviderConfig_ClientId;
            context.GoogleOauth2ProviderConfig_ClientSecret = this.GoogleOauth2ProviderConfig_ClientSecret;
            context.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey = this.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            context.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId = this.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId;
            context.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource = this.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource;
            context.IncludedOauth2ProviderConfig_AuthorizationEndpoint = this.IncludedOauth2ProviderConfig_AuthorizationEndpoint;
            context.IncludedOauth2ProviderConfig_ClientId = this.IncludedOauth2ProviderConfig_ClientId;
            context.IncludedOauth2ProviderConfig_ClientSecret = this.IncludedOauth2ProviderConfig_ClientSecret;
            context.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey = this.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            context.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId = this.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId;
            context.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource = this.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource;
            context.IncludedOauth2ProviderConfig_Issuer = this.IncludedOauth2ProviderConfig_Issuer;
            context.IncludedOauth2ProviderConfig_TokenEndpoint = this.IncludedOauth2ProviderConfig_TokenEndpoint;
            context.LinkedinOauth2ProviderConfig_ClientId = this.LinkedinOauth2ProviderConfig_ClientId;
            context.LinkedinOauth2ProviderConfig_ClientSecret = this.LinkedinOauth2ProviderConfig_ClientSecret;
            context.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey = this.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            context.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId = this.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId;
            context.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource = this.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource;
            context.MicrosoftOauth2ProviderConfig_ClientId = this.MicrosoftOauth2ProviderConfig_ClientId;
            context.MicrosoftOauth2ProviderConfig_ClientSecret = this.MicrosoftOauth2ProviderConfig_ClientSecret;
            context.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey = this.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            context.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId = this.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId;
            context.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource = this.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource;
            context.MicrosoftOauth2ProviderConfig_TenantId = this.MicrosoftOauth2ProviderConfig_TenantId;
            context.SalesforceOauth2ProviderConfig_ClientId = this.SalesforceOauth2ProviderConfig_ClientId;
            context.SalesforceOauth2ProviderConfig_ClientSecret = this.SalesforceOauth2ProviderConfig_ClientSecret;
            context.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey = this.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            context.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId = this.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId;
            context.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource = this.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource;
            context.SlackOauth2ProviderConfig_ClientId = this.SlackOauth2ProviderConfig_ClientId;
            context.SlackOauth2ProviderConfig_ClientSecret = this.SlackOauth2ProviderConfig_ClientSecret;
            context.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey = this.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            context.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId = this.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId;
            context.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource = this.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderRequest();
            
            if (cmdletContext.CredentialProviderVendor != null)
            {
                request.CredentialProviderVendor = cmdletContext.CredentialProviderVendor;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Oauth2ProviderConfigInput
            var requestOauth2ProviderConfigInputIsNull = true;
            request.Oauth2ProviderConfigInput = new Amazon.BedrockAgentCoreControl.Model.Oauth2ProviderConfigInput();
            Amazon.BedrockAgentCoreControl.Model.AtlassianOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig = null;
            
             // populate AtlassianOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.AtlassianOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_atlassianOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.AtlassianOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_atlassianOauth2ProviderConfig_ClientId = cmdletContext.AtlassianOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_atlassianOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_atlassianOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_atlassianOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.AtlassianOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_atlassianOauth2ProviderConfig_ClientSecret = cmdletContext.AtlassianOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_atlassianOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_atlassianOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource = null;
            if (cmdletContext.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource = cmdletContext.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig.ClientSecretSource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig = null;
            
             // populate ClientSecretConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey = null;
            if (cmdletContext.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey = cmdletContext.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig.JsonKey = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId = cmdletContext.Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig.SecretId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig.ClientSecretConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.AtlassianOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.GithubOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig = null;
            
             // populate GithubOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.GithubOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.GithubOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientId = cmdletContext.GithubOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.GithubOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientSecret = cmdletContext.GithubOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource = null;
            if (cmdletContext.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource = cmdletContext.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig.ClientSecretSource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig = null;
            
             // populate ClientSecretConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey = null;
            if (cmdletContext.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey = cmdletContext.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig.JsonKey = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId = cmdletContext.Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig.SecretId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig.ClientSecretConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.GithubOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.GoogleOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig = null;
            
             // populate GoogleOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.GoogleOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.GoogleOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientId = cmdletContext.GoogleOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.GoogleOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientSecret = cmdletContext.GoogleOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource = null;
            if (cmdletContext.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource = cmdletContext.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig.ClientSecretSource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig = null;
            
             // populate ClientSecretConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey = null;
            if (cmdletContext.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey = cmdletContext.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig.JsonKey = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId = cmdletContext.Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig.SecretId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig.ClientSecretConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.GoogleOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.LinkedinOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig = null;
            
             // populate LinkedinOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.LinkedinOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_linkedinOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.LinkedinOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_linkedinOauth2ProviderConfig_ClientId = cmdletContext.LinkedinOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_linkedinOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_linkedinOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_linkedinOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.LinkedinOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_linkedinOauth2ProviderConfig_ClientSecret = cmdletContext.LinkedinOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_linkedinOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_linkedinOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource = null;
            if (cmdletContext.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource = cmdletContext.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig.ClientSecretSource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig = null;
            
             // populate ClientSecretConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey = null;
            if (cmdletContext.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey = cmdletContext.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig.JsonKey = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId = cmdletContext.Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig.SecretId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig.ClientSecretConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.LinkedinOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SalesforceOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig = null;
            
             // populate SalesforceOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.SalesforceOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.SalesforceOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientId = cmdletContext.SalesforceOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.SalesforceOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientSecret = cmdletContext.SalesforceOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource = null;
            if (cmdletContext.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource = cmdletContext.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig.ClientSecretSource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig = null;
            
             // populate ClientSecretConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey = null;
            if (cmdletContext.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey = cmdletContext.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig.JsonKey = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId = cmdletContext.Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig.SecretId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig.ClientSecretConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.SalesforceOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SlackOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig = null;
            
             // populate SlackOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.SlackOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.SlackOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientId = cmdletContext.SlackOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.SlackOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientSecret = cmdletContext.SlackOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource = null;
            if (cmdletContext.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource = cmdletContext.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig.ClientSecretSource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig = null;
            
             // populate ClientSecretConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey = null;
            if (cmdletContext.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey = cmdletContext.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig.JsonKey = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId = cmdletContext.Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig.SecretId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig.ClientSecretConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.SlackOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.MicrosoftOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig = null;
            
             // populate MicrosoftOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.MicrosoftOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.MicrosoftOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientId = cmdletContext.MicrosoftOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.MicrosoftOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientSecret = cmdletContext.MicrosoftOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource = null;
            if (cmdletContext.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource = cmdletContext.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig.ClientSecretSource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_TenantId = null;
            if (cmdletContext.MicrosoftOauth2ProviderConfig_TenantId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_TenantId = cmdletContext.MicrosoftOauth2ProviderConfig_TenantId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_TenantId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig.TenantId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_TenantId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig = null;
            
             // populate ClientSecretConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey = null;
            if (cmdletContext.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey = cmdletContext.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig.JsonKey = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId = cmdletContext.Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig.SecretId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig.ClientSecretConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.MicrosoftOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.IncludedOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig = null;
            
             // populate IncludedOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.IncludedOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_AuthorizationEndpoint = null;
            if (cmdletContext.IncludedOauth2ProviderConfig_AuthorizationEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_AuthorizationEndpoint = cmdletContext.IncludedOauth2ProviderConfig_AuthorizationEndpoint;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_AuthorizationEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig.AuthorizationEndpoint = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_AuthorizationEndpoint;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.IncludedOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_ClientId = cmdletContext.IncludedOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.IncludedOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_ClientSecret = cmdletContext.IncludedOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource = null;
            if (cmdletContext.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource = cmdletContext.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig.ClientSecretSource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_Issuer = null;
            if (cmdletContext.IncludedOauth2ProviderConfig_Issuer != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_Issuer = cmdletContext.IncludedOauth2ProviderConfig_Issuer;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_Issuer != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig.Issuer = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_Issuer;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_TokenEndpoint = null;
            if (cmdletContext.IncludedOauth2ProviderConfig_TokenEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_TokenEndpoint = cmdletContext.IncludedOauth2ProviderConfig_TokenEndpoint;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_TokenEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig.TokenEndpoint = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_includedOauth2ProviderConfig_TokenEndpoint;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig = null;
            
             // populate ClientSecretConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey = null;
            if (cmdletContext.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey = cmdletContext.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig.JsonKey = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId = cmdletContext.Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig.SecretId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig.ClientSecretConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.IncludedOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_IncludedOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.CustomOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig = null;
            
             // populate CustomOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.CustomOauth2ProviderConfigInput();
            Amazon.BedrockAgentCoreControl.ClientAuthenticationMethodType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.ClientAuthenticationMethod = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.CustomOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientId = cmdletContext.CustomOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.CustomOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientSecret = cmdletContext.CustomOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.ClientSecretSource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.PrivateEndpointOverride> requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.PrivateEndpointOverrides = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig = null;
            
             // populate ClientSecretConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig.JsonKey = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig.SecretId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.ClientSecretConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.Oauth2Discovery requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery = null;
            
             // populate OauthDiscovery
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscoveryIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery = new Amazon.BedrockAgentCoreControl.Model.Oauth2Discovery();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauthDiscovery_DiscoveryUrl = null;
            if (cmdletContext.OauthDiscovery_DiscoveryUrl != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauthDiscovery_DiscoveryUrl = cmdletContext.OauthDiscovery_DiscoveryUrl;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauthDiscovery_DiscoveryUrl != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery.DiscoveryUrl = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauthDiscovery_DiscoveryUrl;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscoveryIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.Oauth2AuthorizationServerMetadata requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata = null;
            
             // populate AuthorizationServerMetadata
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata = new Amazon.BedrockAgentCoreControl.Model.Oauth2AuthorizationServerMetadata();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_AuthorizationEndpoint = null;
            if (cmdletContext.AuthorizationServerMetadata_AuthorizationEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_AuthorizationEndpoint = cmdletContext.AuthorizationServerMetadata_AuthorizationEndpoint;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_AuthorizationEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata.AuthorizationEndpoint = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_AuthorizationEndpoint;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_Issuer = null;
            if (cmdletContext.AuthorizationServerMetadata_Issuer != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_Issuer = cmdletContext.AuthorizationServerMetadata_Issuer;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_Issuer != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata.Issuer = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_Issuer;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = false;
            }
            List<System.String> requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_ResponseType = null;
            if (cmdletContext.AuthorizationServerMetadata_ResponseType != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_ResponseType = cmdletContext.AuthorizationServerMetadata_ResponseType;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_ResponseType != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata.ResponseTypes = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_ResponseType;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpoint = null;
            if (cmdletContext.AuthorizationServerMetadata_TokenEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpoint = cmdletContext.AuthorizationServerMetadata_TokenEndpoint;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata.TokenEndpoint = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpoint;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = false;
            }
            List<System.String> requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpointAuthMethod = null;
            if (cmdletContext.AuthorizationServerMetadata_TokenEndpointAuthMethod != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpointAuthMethod = cmdletContext.AuthorizationServerMetadata_TokenEndpointAuthMethod;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpointAuthMethod != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata.TokenEndpointAuthMethods = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpointAuthMethod;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery.AuthorizationServerMetadata = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscoveryIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscoveryIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.OauthDiscovery = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.OnBehalfOfTokenExchangeConfigType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig = null;
            
             // populate OnBehalfOfTokenExchangeConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig = new Amazon.BedrockAgentCoreControl.Model.OnBehalfOfTokenExchangeConfigType();
            Amazon.BedrockAgentCoreControl.OnBehalfOfTokenExchangeGrantTypeType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig.GrantType = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.TokenExchangeGrantTypeConfigType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig = null;
            
             // populate TokenExchangeGrantTypeConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig = new Amazon.BedrockAgentCoreControl.Model.TokenExchangeGrantTypeConfigType();
            Amazon.BedrockAgentCoreControl.ActorTokenContentType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig.ActorTokenContent = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfigIsNull = false;
            }
            List<System.String> requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig.ActorTokenScopes = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig.TokenExchangeGrantTypeConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.OnBehalfOfTokenExchangeConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.PrivateEndpoint requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint = null;
            
             // populate PrivateEndpoint
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint = new Amazon.BedrockAgentCoreControl.Model.PrivateEndpoint();
            Amazon.BedrockAgentCoreControl.Model.SelfManagedLatticeResource requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource = null;
            
             // populate SelfManagedLatticeResource
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResourceIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource = new Amazon.BedrockAgentCoreControl.Model.SelfManagedLatticeResource();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource.ResourceConfigurationIdentifier = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResourceIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResourceIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint.SelfManagedLatticeResource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.ManagedVpcResource requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource = null;
            
             // populate ManagedVpcResource
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResourceIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource = new Amazon.BedrockAgentCoreControl.Model.ManagedVpcResource();
            Amazon.BedrockAgentCoreControl.EndpointIpAddressType requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource.EndpointIpAddressType = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource.RoutingDomain = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            List<System.String> requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource.SecurityGroupIds = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            List<System.String> requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource.SubnetIds = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            Dictionary<System.String, System.String> requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource.Tags = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier = null;
            if (cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier = cmdletContext.Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource.VpcIdentifier = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResourceIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResourceIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint.ManagedVpcResource = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.PrivateEndpoint = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.CustomOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
             // determine if request.Oauth2ProviderConfigInput should be set to null
            if (requestOauth2ProviderConfigInputIsNull)
            {
                request.Oauth2ProviderConfigInput = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateOauth2CredentialProvider");
            try
            {
                return client.CreateOauth2CredentialProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.BedrockAgentCoreControl.CredentialProviderVendorType CredentialProviderVendor { get; set; }
            public System.String Name { get; set; }
            public System.String AtlassianOauth2ProviderConfig_ClientId { get; set; }
            public System.String AtlassianOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
            public System.String Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_AtlassianOauth2ProviderConfig_ClientSecretSource { get; set; }
            public Amazon.BedrockAgentCoreControl.ClientAuthenticationMethodType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod { get; set; }
            public System.String CustomOauth2ProviderConfig_ClientId { get; set; }
            public System.String CustomOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
            public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecretSource { get; set; }
            public System.String AuthorizationServerMetadata_AuthorizationEndpoint { get; set; }
            public System.String AuthorizationServerMetadata_Issuer { get; set; }
            public List<System.String> AuthorizationServerMetadata_ResponseType { get; set; }
            public System.String AuthorizationServerMetadata_TokenEndpoint { get; set; }
            public List<System.String> AuthorizationServerMetadata_TokenEndpointAuthMethod { get; set; }
            public System.String OauthDiscovery_DiscoveryUrl { get; set; }
            public Amazon.BedrockAgentCoreControl.OnBehalfOfTokenExchangeGrantTypeType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType { get; set; }
            public Amazon.BedrockAgentCoreControl.ActorTokenContentType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent { get; set; }
            public List<System.String> Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenScope { get; set; }
            public Amazon.BedrockAgentCoreControl.EndpointIpAddressType Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType { get; set; }
            public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_RoutingDomain { get; set; }
            public List<System.String> Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SecurityGroupId { get; set; }
            public List<System.String> Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_SubnetId { get; set; }
            public Dictionary<System.String, System.String> Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_Tag { get; set; }
            public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_VpcIdentifier { get; set; }
            public System.String Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.PrivateEndpointOverride> Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpointOverride { get; set; }
            public System.String GithubOauth2ProviderConfig_ClientId { get; set; }
            public System.String GithubOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
            public System.String Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecretSource { get; set; }
            public System.String GoogleOauth2ProviderConfig_ClientId { get; set; }
            public System.String GoogleOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
            public System.String Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecretSource { get; set; }
            public System.String IncludedOauth2ProviderConfig_AuthorizationEndpoint { get; set; }
            public System.String IncludedOauth2ProviderConfig_ClientId { get; set; }
            public System.String IncludedOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
            public System.String Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_IncludedOauth2ProviderConfig_ClientSecretSource { get; set; }
            public System.String IncludedOauth2ProviderConfig_Issuer { get; set; }
            public System.String IncludedOauth2ProviderConfig_TokenEndpoint { get; set; }
            public System.String LinkedinOauth2ProviderConfig_ClientId { get; set; }
            public System.String LinkedinOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
            public System.String Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_LinkedinOauth2ProviderConfig_ClientSecretSource { get; set; }
            public System.String MicrosoftOauth2ProviderConfig_ClientId { get; set; }
            public System.String MicrosoftOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
            public System.String Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecretSource { get; set; }
            public System.String MicrosoftOauth2ProviderConfig_TenantId { get; set; }
            public System.String SalesforceOauth2ProviderConfig_ClientId { get; set; }
            public System.String SalesforceOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
            public System.String Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecretSource { get; set; }
            public System.String SlackOauth2ProviderConfig_ClientId { get; set; }
            public System.String SlackOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_JsonKey { get; set; }
            public System.String Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecretSource { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse, NewBACCOauth2CredentialProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
