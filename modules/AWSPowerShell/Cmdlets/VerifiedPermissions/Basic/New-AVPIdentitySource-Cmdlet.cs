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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Adds an identity source to a policy store–an Amazon Cognito user pool or OpenID Connect
    /// (OIDC) identity provider (IdP). 
    /// 
    ///  
    /// <para>
    /// After you create an identity source, you can use the identities provided by the IdP
    /// as proxies for the principal in authorization queries that use the <a href="https://docs.aws.amazon.com/verifiedpermissions/latest/apireference/API_IsAuthorizedWithToken.html">IsAuthorizedWithToken</a>
    /// or <a href="https://docs.aws.amazon.com/verifiedpermissions/latest/apireference/API_BatchIsAuthorizedWithToken.html">BatchIsAuthorizedWithToken</a>
    /// API operations. These identities take the form of tokens that contain claims about
    /// the user, such as IDs, attributes and group memberships. Identity sources provide
    /// identity (ID) tokens and access tokens. Verified Permissions derives information about
    /// your user and session from token claims. Access tokens provide action <c>context</c>
    /// to your policies, and ID tokens provide principal <c>Attributes</c>.
    /// </para><important><para>
    /// Tokens from an identity source user continue to be usable until they expire. Token
    /// revocation and resource deletion have no effect on the validity of a token in your
    /// policy store
    /// </para></important><note><para>
    /// To reference a user from this identity source in your Cedar policies, refer to the
    /// following syntax examples.
    /// </para><ul><li><para>
    /// Amazon Cognito user pool: <c>Namespace::[Entity type]::[User pool ID]|[user principal
    /// attribute]</c>, for example <c>MyCorp::User::us-east-1_EXAMPLE|a1b2c3d4-5678-90ab-cdef-EXAMPLE11111</c>.
    /// </para></li><li><para>
    /// OpenID Connect (OIDC) provider: <c>Namespace::[Entity type]::[principalIdClaim]|[user
    /// principal attribute]</c>, for example <c>MyCorp::User::MyOIDCProvider|a1b2c3d4-5678-90ab-cdef-EXAMPLE22222</c>.
    /// </para></li></ul></note><note><para>
    /// Verified Permissions is <i><a href="https://wikipedia.org/wiki/Eventual_consistency">eventually
    /// consistent</a></i>. It can take a few seconds for a new or changed element to propagate
    /// through the service and be visible in the results of other Verified Permissions operations.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "AVPIdentitySource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions CreateIdentitySource API operation.", Operation = new[] {"CreateIdentitySource"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAVPIdentitySourceCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessTokenOnly_Audience
        /// <summary>
        /// <para>
        /// <para>The access token <c>aud</c> claim values that you want to accept in your policy store.
        /// For example, <c>https://myapp.example.com, https://myapp2.example.com</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_Audiences")]
        public System.String[] AccessTokenOnly_Audience { get; set; }
        #endregion
        
        #region Parameter CognitoUserPoolConfiguration_ClientId
        /// <summary>
        /// <para>
        /// <para>The unique application client IDs that are associated with the specified Amazon Cognito
        /// user pool.</para><para>Example: <c>"ClientIds": ["&amp;ExampleCogClientId;"]</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CognitoUserPoolConfiguration_ClientIds")]
        public System.String[] CognitoUserPoolConfiguration_ClientId { get; set; }
        #endregion
        
        #region Parameter IdentityTokenOnly_ClientId
        /// <summary>
        /// <para>
        /// <para>The ID token audience, or client ID, claim values that you want to accept in your
        /// policy store from an OIDC identity provider. For example, <c>1example23456789, 2example10111213</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_ClientIds")]
        public System.String[] IdentityTokenOnly_ClientId { get; set; }
        #endregion
        
        #region Parameter OpenIdConnectConfiguration_EntityIdPrefix
        /// <summary>
        /// <para>
        /// <para>A descriptive string that you want to prefix to user entities from your OIDC identity
        /// provider. For example, if you set an <c>entityIdPrefix</c> of <c>MyOIDCProvider</c>,
        /// you can reference principals in your policies in the format <c>MyCorp::User::MyOIDCProvider|Carlos</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OpenIdConnectConfiguration_EntityIdPrefix")]
        public System.String OpenIdConnectConfiguration_EntityIdPrefix { get; set; }
        #endregion
        
        #region Parameter OpenIdConnectConfiguration_GroupClaim
        /// <summary>
        /// <para>
        /// <para>The token claim that you want Verified Permissions to interpret as group membership.
        /// For example, <c>groups</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OpenIdConnectConfiguration_GroupConfiguration_GroupClaim")]
        public System.String OpenIdConnectConfiguration_GroupClaim { get; set; }
        #endregion
        
        #region Parameter GroupConfiguration_GroupEntityType
        /// <summary>
        /// <para>
        /// <para>The name of the schema entity type that's mapped to the user pool group. Defaults
        /// to <c>AWS::CognitoGroup</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CognitoUserPoolConfiguration_GroupConfiguration_GroupEntityType")]
        public System.String GroupConfiguration_GroupEntityType { get; set; }
        #endregion
        
        #region Parameter OpenIdConnectConfiguration_GroupEntityType
        /// <summary>
        /// <para>
        /// <para>The policy store entity type that you want to map your users' group claim to. For
        /// example, <c>MyCorp::UserGroup</c>. A group entity type is an entity that can have
        /// a user entity type as a member.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OpenIdConnectConfiguration_GroupConfiguration_GroupEntityType")]
        public System.String OpenIdConnectConfiguration_GroupEntityType { get; set; }
        #endregion
        
        #region Parameter OpenIdConnectConfiguration_Issuer
        /// <summary>
        /// <para>
        /// <para>The issuer URL of an OIDC identity provider. This URL must have an OIDC discovery
        /// endpoint at the path <c>.well-known/openid-configuration</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OpenIdConnectConfiguration_Issuer")]
        public System.String OpenIdConnectConfiguration_Issuer { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store in which you want to store this identity source.
        /// Only policies and requests made using this policy store can reference identities from
        /// the identity provider configured in the new identity source.</para>
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
        public System.String PolicyStoreId { get; set; }
        #endregion
        
        #region Parameter PrincipalEntityType
        /// <summary>
        /// <para>
        /// <para>Specifies the namespace and data type of the principals generated for identities authenticated
        /// by the new identity source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrincipalEntityType { get; set; }
        #endregion
        
        #region Parameter AccessTokenOnly_PrincipalIdClaim
        /// <summary>
        /// <para>
        /// <para>The claim that determines the principal in OIDC access tokens. For example, <c>sub</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_PrincipalIdClaim")]
        public System.String AccessTokenOnly_PrincipalIdClaim { get; set; }
        #endregion
        
        #region Parameter IdentityTokenOnly_PrincipalIdClaim
        /// <summary>
        /// <para>
        /// <para>The claim that determines the principal in OIDC access tokens. For example, <c>sub</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_PrincipalIdClaim")]
        public System.String IdentityTokenOnly_PrincipalIdClaim { get; set; }
        #endregion
        
        #region Parameter CognitoUserPoolConfiguration_UserPoolArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the Amazon Cognito user pool that contains the identities
        /// to be authorized.</para><para>Example: <c>"UserPoolArn": "arn:aws:cognito-idp:us-east-1:123456789012:userpool/us-east-1_1a2b3c4d5"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CognitoUserPoolConfiguration_UserPoolArn")]
        public System.String CognitoUserPoolConfiguration_UserPoolArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive ID that you provide to ensure the idempotency of
        /// the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value.</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>ConflictException</c> error.</para><para>Verified Permissions recognizes a <c>ClientToken</c> for eight hours. After eight
        /// hours, the next request with the same parameters performs the operation again regardless
        /// of the value of <c>ClientToken</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AVPIdentitySource (CreateIdentitySource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse, NewAVPIdentitySourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.CognitoUserPoolConfiguration_ClientId != null)
            {
                context.CognitoUserPoolConfiguration_ClientId = new List<System.String>(this.CognitoUserPoolConfiguration_ClientId);
            }
            context.GroupConfiguration_GroupEntityType = this.GroupConfiguration_GroupEntityType;
            context.CognitoUserPoolConfiguration_UserPoolArn = this.CognitoUserPoolConfiguration_UserPoolArn;
            context.OpenIdConnectConfiguration_EntityIdPrefix = this.OpenIdConnectConfiguration_EntityIdPrefix;
            context.OpenIdConnectConfiguration_GroupClaim = this.OpenIdConnectConfiguration_GroupClaim;
            context.OpenIdConnectConfiguration_GroupEntityType = this.OpenIdConnectConfiguration_GroupEntityType;
            context.OpenIdConnectConfiguration_Issuer = this.OpenIdConnectConfiguration_Issuer;
            if (this.AccessTokenOnly_Audience != null)
            {
                context.AccessTokenOnly_Audience = new List<System.String>(this.AccessTokenOnly_Audience);
            }
            context.AccessTokenOnly_PrincipalIdClaim = this.AccessTokenOnly_PrincipalIdClaim;
            if (this.IdentityTokenOnly_ClientId != null)
            {
                context.IdentityTokenOnly_ClientId = new List<System.String>(this.IdentityTokenOnly_ClientId);
            }
            context.IdentityTokenOnly_PrincipalIdClaim = this.IdentityTokenOnly_PrincipalIdClaim;
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalEntityType = this.PrincipalEntityType;
            
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
            var request = new Amazon.VerifiedPermissions.Model.CreateIdentitySourceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.VerifiedPermissions.Model.Configuration();
            Amazon.VerifiedPermissions.Model.CognitoUserPoolConfiguration requestConfiguration_configuration_CognitoUserPoolConfiguration = null;
            
             // populate CognitoUserPoolConfiguration
            var requestConfiguration_configuration_CognitoUserPoolConfigurationIsNull = true;
            requestConfiguration_configuration_CognitoUserPoolConfiguration = new Amazon.VerifiedPermissions.Model.CognitoUserPoolConfiguration();
            List<System.String> requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId = null;
            if (cmdletContext.CognitoUserPoolConfiguration_ClientId != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId = cmdletContext.CognitoUserPoolConfiguration_ClientId;
            }
            if (requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration.ClientIds = requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId;
                requestConfiguration_configuration_CognitoUserPoolConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn = null;
            if (cmdletContext.CognitoUserPoolConfiguration_UserPoolArn != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn = cmdletContext.CognitoUserPoolConfiguration_UserPoolArn;
            }
            if (requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration.UserPoolArn = requestConfiguration_configuration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn;
                requestConfiguration_configuration_CognitoUserPoolConfigurationIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.CognitoGroupConfiguration requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration = null;
            
             // populate GroupConfiguration
            var requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfigurationIsNull = true;
            requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration = new Amazon.VerifiedPermissions.Model.CognitoGroupConfiguration();
            System.String requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration_groupConfiguration_GroupEntityType = null;
            if (cmdletContext.GroupConfiguration_GroupEntityType != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration_groupConfiguration_GroupEntityType = cmdletContext.GroupConfiguration_GroupEntityType;
            }
            if (requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration_groupConfiguration_GroupEntityType != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration.GroupEntityType = requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration_groupConfiguration_GroupEntityType;
                requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration should be set to null
            if (requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfigurationIsNull)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration = null;
            }
            if (requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration != null)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration.GroupConfiguration = requestConfiguration_configuration_CognitoUserPoolConfiguration_configuration_CognitoUserPoolConfiguration_GroupConfiguration;
                requestConfiguration_configuration_CognitoUserPoolConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_CognitoUserPoolConfiguration should be set to null
            if (requestConfiguration_configuration_CognitoUserPoolConfigurationIsNull)
            {
                requestConfiguration_configuration_CognitoUserPoolConfiguration = null;
            }
            if (requestConfiguration_configuration_CognitoUserPoolConfiguration != null)
            {
                request.Configuration.CognitoUserPoolConfiguration = requestConfiguration_configuration_CognitoUserPoolConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.OpenIdConnectConfiguration requestConfiguration_configuration_OpenIdConnectConfiguration = null;
            
             // populate OpenIdConnectConfiguration
            var requestConfiguration_configuration_OpenIdConnectConfigurationIsNull = true;
            requestConfiguration_configuration_OpenIdConnectConfiguration = new Amazon.VerifiedPermissions.Model.OpenIdConnectConfiguration();
            System.String requestConfiguration_configuration_OpenIdConnectConfiguration_openIdConnectConfiguration_EntityIdPrefix = null;
            if (cmdletContext.OpenIdConnectConfiguration_EntityIdPrefix != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_openIdConnectConfiguration_EntityIdPrefix = cmdletContext.OpenIdConnectConfiguration_EntityIdPrefix;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_openIdConnectConfiguration_EntityIdPrefix != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration.EntityIdPrefix = requestConfiguration_configuration_OpenIdConnectConfiguration_openIdConnectConfiguration_EntityIdPrefix;
                requestConfiguration_configuration_OpenIdConnectConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_OpenIdConnectConfiguration_openIdConnectConfiguration_Issuer = null;
            if (cmdletContext.OpenIdConnectConfiguration_Issuer != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_openIdConnectConfiguration_Issuer = cmdletContext.OpenIdConnectConfiguration_Issuer;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_openIdConnectConfiguration_Issuer != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration.Issuer = requestConfiguration_configuration_OpenIdConnectConfiguration_openIdConnectConfiguration_Issuer;
                requestConfiguration_configuration_OpenIdConnectConfigurationIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.OpenIdConnectGroupConfiguration requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration = null;
            
             // populate GroupConfiguration
            var requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfigurationIsNull = true;
            requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration = new Amazon.VerifiedPermissions.Model.OpenIdConnectGroupConfiguration();
            System.String requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupClaim = null;
            if (cmdletContext.OpenIdConnectConfiguration_GroupClaim != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupClaim = cmdletContext.OpenIdConnectConfiguration_GroupClaim;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupClaim != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration.GroupClaim = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupClaim;
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupEntityType = null;
            if (cmdletContext.OpenIdConnectConfiguration_GroupEntityType != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupEntityType = cmdletContext.OpenIdConnectConfiguration_GroupEntityType;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupEntityType != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration.GroupEntityType = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupEntityType;
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration should be set to null
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfigurationIsNull)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration = null;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration.GroupConfiguration = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_GroupConfiguration;
                requestConfiguration_configuration_OpenIdConnectConfigurationIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.OpenIdConnectTokenSelection requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection = null;
            
             // populate TokenSelection
            var requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelectionIsNull = true;
            requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection = new Amazon.VerifiedPermissions.Model.OpenIdConnectTokenSelection();
            Amazon.VerifiedPermissions.Model.OpenIdConnectAccessTokenConfiguration requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly = null;
            
             // populate AccessTokenOnly
            var requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnlyIsNull = true;
            requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly = new Amazon.VerifiedPermissions.Model.OpenIdConnectAccessTokenConfiguration();
            List<System.String> requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_Audience = null;
            if (cmdletContext.AccessTokenOnly_Audience != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_Audience = cmdletContext.AccessTokenOnly_Audience;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_Audience != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly.Audiences = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_Audience;
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnlyIsNull = false;
            }
            System.String requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_PrincipalIdClaim = null;
            if (cmdletContext.AccessTokenOnly_PrincipalIdClaim != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_PrincipalIdClaim = cmdletContext.AccessTokenOnly_PrincipalIdClaim;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_PrincipalIdClaim != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly.PrincipalIdClaim = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_PrincipalIdClaim;
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnlyIsNull = false;
            }
             // determine if requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly should be set to null
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnlyIsNull)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly = null;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection.AccessTokenOnly = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly;
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelectionIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.OpenIdConnectIdentityTokenConfiguration requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly = null;
            
             // populate IdentityTokenOnly
            var requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnlyIsNull = true;
            requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly = new Amazon.VerifiedPermissions.Model.OpenIdConnectIdentityTokenConfiguration();
            List<System.String> requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_ClientId = null;
            if (cmdletContext.IdentityTokenOnly_ClientId != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_ClientId = cmdletContext.IdentityTokenOnly_ClientId;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_ClientId != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly.ClientIds = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_ClientId;
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnlyIsNull = false;
            }
            System.String requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_PrincipalIdClaim = null;
            if (cmdletContext.IdentityTokenOnly_PrincipalIdClaim != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_PrincipalIdClaim = cmdletContext.IdentityTokenOnly_PrincipalIdClaim;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_PrincipalIdClaim != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly.PrincipalIdClaim = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_PrincipalIdClaim;
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnlyIsNull = false;
            }
             // determine if requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly should be set to null
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnlyIsNull)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly = null;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection.IdentityTokenOnly = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection_configuration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly;
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelectionIsNull = false;
            }
             // determine if requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection should be set to null
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelectionIsNull)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection = null;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection != null)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration.TokenSelection = requestConfiguration_configuration_OpenIdConnectConfiguration_configuration_OpenIdConnectConfiguration_TokenSelection;
                requestConfiguration_configuration_OpenIdConnectConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_OpenIdConnectConfiguration should be set to null
            if (requestConfiguration_configuration_OpenIdConnectConfigurationIsNull)
            {
                requestConfiguration_configuration_OpenIdConnectConfiguration = null;
            }
            if (requestConfiguration_configuration_OpenIdConnectConfiguration != null)
            {
                request.Configuration.OpenIdConnectConfiguration = requestConfiguration_configuration_OpenIdConnectConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
            }
            if (cmdletContext.PrincipalEntityType != null)
            {
                request.PrincipalEntityType = cmdletContext.PrincipalEntityType;
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
        
        private Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.CreateIdentitySourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "CreateIdentitySource");
            try
            {
                #if DESKTOP
                return client.CreateIdentitySource(request);
                #elif CORECLR
                return client.CreateIdentitySourceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<System.String> CognitoUserPoolConfiguration_ClientId { get; set; }
            public System.String GroupConfiguration_GroupEntityType { get; set; }
            public System.String CognitoUserPoolConfiguration_UserPoolArn { get; set; }
            public System.String OpenIdConnectConfiguration_EntityIdPrefix { get; set; }
            public System.String OpenIdConnectConfiguration_GroupClaim { get; set; }
            public System.String OpenIdConnectConfiguration_GroupEntityType { get; set; }
            public System.String OpenIdConnectConfiguration_Issuer { get; set; }
            public List<System.String> AccessTokenOnly_Audience { get; set; }
            public System.String AccessTokenOnly_PrincipalIdClaim { get; set; }
            public List<System.String> IdentityTokenOnly_ClientId { get; set; }
            public System.String IdentityTokenOnly_PrincipalIdClaim { get; set; }
            public System.String PolicyStoreId { get; set; }
            public System.String PrincipalEntityType { get; set; }
            public System.Func<Amazon.VerifiedPermissions.Model.CreateIdentitySourceResponse, NewAVPIdentitySourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
