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
using Amazon.VerifiedPermissions;
using Amazon.VerifiedPermissions.Model;

namespace Amazon.PowerShell.Cmdlets.AVP
{
    /// <summary>
    /// Updates the specified identity source to use a new identity provider (IdP), or to
    /// change the mapping of identities from the IdP to a different principal entity type.
    /// 
    ///  <note><para>
    /// Verified Permissions is <i><a href="https://wikipedia.org/wiki/Eventual_consistency">eventually
    /// consistent</a></i>. It can take a few seconds for a new or changed element to propagate
    /// through the service and be visible in the results of other Verified Permissions operations.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "AVPIdentitySource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse")]
    [AWSCmdlet("Calls the Amazon Verified Permissions UpdateIdentitySource API operation.", Operation = new[] {"UpdateIdentitySource"}, SelectReturnType = typeof(Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse))]
    [AWSCmdletOutput("Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse",
        "This cmdlet returns an Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse object containing multiple properties."
    )]
    public partial class UpdateAVPIdentitySourceCmdlet : AmazonVerifiedPermissionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessTokenOnly_Audience
        /// <summary>
        /// <para>
        /// <para>The access token <c>aud</c> claim values that you want to accept in your policy store.
        /// For example, <c>https://myapp.example.com, https://myapp2.example.com</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_Audiences")]
        public System.String[] AccessTokenOnly_Audience { get; set; }
        #endregion
        
        #region Parameter CognitoUserPoolConfiguration_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID of an app client that is configured for the specified Amazon Cognito
        /// user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateConfiguration_CognitoUserPoolConfiguration_ClientIds")]
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
        [Alias("UpdateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_ClientIds")]
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
        [Alias("UpdateConfiguration_OpenIdConnectConfiguration_EntityIdPrefix")]
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
        [Alias("UpdateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_GroupClaim")]
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
        [Alias("UpdateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration_GroupEntityType")]
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
        [Alias("UpdateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_GroupEntityType")]
        public System.String OpenIdConnectConfiguration_GroupEntityType { get; set; }
        #endregion
        
        #region Parameter IdentitySourceId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the identity source that you want to update.</para>
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
        public System.String IdentitySourceId { get; set; }
        #endregion
        
        #region Parameter OpenIdConnectConfiguration_Issuer
        /// <summary>
        /// <para>
        /// <para>The issuer URL of an OIDC identity provider. This URL must have an OIDC discovery
        /// endpoint at the path <c>.well-known/openid-configuration</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateConfiguration_OpenIdConnectConfiguration_Issuer")]
        public System.String OpenIdConnectConfiguration_Issuer { get; set; }
        #endregion
        
        #region Parameter PolicyStoreId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the policy store that contains the identity source that you want
        /// to update.</para>
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
        public System.String PolicyStoreId { get; set; }
        #endregion
        
        #region Parameter PrincipalEntityType
        /// <summary>
        /// <para>
        /// <para>Specifies the data type of principals generated for identities authenticated by the
        /// identity source.</para>
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
        [Alias("UpdateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_PrincipalIdClaim")]
        public System.String AccessTokenOnly_PrincipalIdClaim { get; set; }
        #endregion
        
        #region Parameter IdentityTokenOnly_PrincipalIdClaim
        /// <summary>
        /// <para>
        /// <para>The claim that determines the principal in OIDC access tokens. For example, <c>sub</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_PrincipalIdClaim")]
        public System.String IdentityTokenOnly_PrincipalIdClaim { get; set; }
        #endregion
        
        #region Parameter CognitoUserPoolConfiguration_UserPoolArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of the Amazon Cognito user pool associated with this identity
        /// source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateConfiguration_CognitoUserPoolConfiguration_UserPoolArn")]
        public System.String CognitoUserPoolConfiguration_UserPoolArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse).
        /// Specifying the name of a property of type Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentitySourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AVPIdentitySource (UpdateIdentitySource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse, UpdateAVPIdentitySourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdentitySourceId = this.IdentitySourceId;
            #if MODULAR
            if (this.IdentitySourceId == null && ParameterWasBound(nameof(this.IdentitySourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentitySourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyStoreId = this.PolicyStoreId;
            #if MODULAR
            if (this.PolicyStoreId == null && ParameterWasBound(nameof(this.PolicyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalEntityType = this.PrincipalEntityType;
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
            var request = new Amazon.VerifiedPermissions.Model.UpdateIdentitySourceRequest();
            
            if (cmdletContext.IdentitySourceId != null)
            {
                request.IdentitySourceId = cmdletContext.IdentitySourceId;
            }
            if (cmdletContext.PolicyStoreId != null)
            {
                request.PolicyStoreId = cmdletContext.PolicyStoreId;
            }
            if (cmdletContext.PrincipalEntityType != null)
            {
                request.PrincipalEntityType = cmdletContext.PrincipalEntityType;
            }
            
             // populate UpdateConfiguration
            var requestUpdateConfigurationIsNull = true;
            request.UpdateConfiguration = new Amazon.VerifiedPermissions.Model.UpdateConfiguration();
            Amazon.VerifiedPermissions.Model.UpdateCognitoUserPoolConfiguration requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration = null;
            
             // populate CognitoUserPoolConfiguration
            var requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfigurationIsNull = true;
            requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration = new Amazon.VerifiedPermissions.Model.UpdateCognitoUserPoolConfiguration();
            List<System.String> requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId = null;
            if (cmdletContext.CognitoUserPoolConfiguration_ClientId != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId = cmdletContext.CognitoUserPoolConfiguration_ClientId;
            }
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration.ClientIds = requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_ClientId;
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfigurationIsNull = false;
            }
            System.String requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn = null;
            if (cmdletContext.CognitoUserPoolConfiguration_UserPoolArn != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn = cmdletContext.CognitoUserPoolConfiguration_UserPoolArn;
            }
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration.UserPoolArn = requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_cognitoUserPoolConfiguration_UserPoolArn;
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfigurationIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.UpdateCognitoGroupConfiguration requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration = null;
            
             // populate GroupConfiguration
            var requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfigurationIsNull = true;
            requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration = new Amazon.VerifiedPermissions.Model.UpdateCognitoGroupConfiguration();
            System.String requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration_groupConfiguration_GroupEntityType = null;
            if (cmdletContext.GroupConfiguration_GroupEntityType != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration_groupConfiguration_GroupEntityType = cmdletContext.GroupConfiguration_GroupEntityType;
            }
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration_groupConfiguration_GroupEntityType != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration.GroupEntityType = requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration_groupConfiguration_GroupEntityType;
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfigurationIsNull = false;
            }
             // determine if requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration should be set to null
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfigurationIsNull)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration = null;
            }
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration != null)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration.GroupConfiguration = requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration_updateConfiguration_CognitoUserPoolConfiguration_GroupConfiguration;
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfigurationIsNull = false;
            }
             // determine if requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration should be set to null
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfigurationIsNull)
            {
                requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration = null;
            }
            if (requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration != null)
            {
                request.UpdateConfiguration.CognitoUserPoolConfiguration = requestUpdateConfiguration_updateConfiguration_CognitoUserPoolConfiguration;
                requestUpdateConfigurationIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectConfiguration requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration = null;
            
             // populate OpenIdConnectConfiguration
            var requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfigurationIsNull = true;
            requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration = new Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectConfiguration();
            System.String requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_openIdConnectConfiguration_EntityIdPrefix = null;
            if (cmdletContext.OpenIdConnectConfiguration_EntityIdPrefix != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_openIdConnectConfiguration_EntityIdPrefix = cmdletContext.OpenIdConnectConfiguration_EntityIdPrefix;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_openIdConnectConfiguration_EntityIdPrefix != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration.EntityIdPrefix = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_openIdConnectConfiguration_EntityIdPrefix;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfigurationIsNull = false;
            }
            System.String requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_openIdConnectConfiguration_Issuer = null;
            if (cmdletContext.OpenIdConnectConfiguration_Issuer != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_openIdConnectConfiguration_Issuer = cmdletContext.OpenIdConnectConfiguration_Issuer;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_openIdConnectConfiguration_Issuer != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration.Issuer = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_openIdConnectConfiguration_Issuer;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfigurationIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectGroupConfiguration requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration = null;
            
             // populate GroupConfiguration
            var requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfigurationIsNull = true;
            requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration = new Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectGroupConfiguration();
            System.String requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupClaim = null;
            if (cmdletContext.OpenIdConnectConfiguration_GroupClaim != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupClaim = cmdletContext.OpenIdConnectConfiguration_GroupClaim;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupClaim != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration.GroupClaim = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupClaim;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfigurationIsNull = false;
            }
            System.String requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupEntityType = null;
            if (cmdletContext.OpenIdConnectConfiguration_GroupEntityType != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupEntityType = cmdletContext.OpenIdConnectConfiguration_GroupEntityType;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupEntityType != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration.GroupEntityType = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration_openIdConnectConfiguration_GroupEntityType;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfigurationIsNull = false;
            }
             // determine if requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration should be set to null
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfigurationIsNull)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration = null;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration.GroupConfiguration = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_GroupConfiguration;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfigurationIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectTokenSelection requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection = null;
            
             // populate TokenSelection
            var requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelectionIsNull = true;
            requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection = new Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectTokenSelection();
            Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectAccessTokenConfiguration requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly = null;
            
             // populate AccessTokenOnly
            var requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnlyIsNull = true;
            requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly = new Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectAccessTokenConfiguration();
            List<System.String> requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_Audience = null;
            if (cmdletContext.AccessTokenOnly_Audience != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_Audience = cmdletContext.AccessTokenOnly_Audience;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_Audience != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly.Audiences = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_Audience;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnlyIsNull = false;
            }
            System.String requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_PrincipalIdClaim = null;
            if (cmdletContext.AccessTokenOnly_PrincipalIdClaim != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_PrincipalIdClaim = cmdletContext.AccessTokenOnly_PrincipalIdClaim;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_PrincipalIdClaim != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly.PrincipalIdClaim = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly_accessTokenOnly_PrincipalIdClaim;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnlyIsNull = false;
            }
             // determine if requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly should be set to null
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnlyIsNull)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly = null;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection.AccessTokenOnly = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_AccessTokenOnly;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelectionIsNull = false;
            }
            Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectIdentityTokenConfiguration requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly = null;
            
             // populate IdentityTokenOnly
            var requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnlyIsNull = true;
            requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly = new Amazon.VerifiedPermissions.Model.UpdateOpenIdConnectIdentityTokenConfiguration();
            List<System.String> requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_ClientId = null;
            if (cmdletContext.IdentityTokenOnly_ClientId != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_ClientId = cmdletContext.IdentityTokenOnly_ClientId;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_ClientId != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly.ClientIds = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_ClientId;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnlyIsNull = false;
            }
            System.String requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_PrincipalIdClaim = null;
            if (cmdletContext.IdentityTokenOnly_PrincipalIdClaim != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_PrincipalIdClaim = cmdletContext.IdentityTokenOnly_PrincipalIdClaim;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_PrincipalIdClaim != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly.PrincipalIdClaim = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly_identityTokenOnly_PrincipalIdClaim;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnlyIsNull = false;
            }
             // determine if requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly should be set to null
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnlyIsNull)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly = null;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection.IdentityTokenOnly = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_updateConfiguration_OpenIdConnectConfiguration_TokenSelection_IdentityTokenOnly;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelectionIsNull = false;
            }
             // determine if requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection should be set to null
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelectionIsNull)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection = null;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection != null)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration.TokenSelection = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration_updateConfiguration_OpenIdConnectConfiguration_TokenSelection;
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfigurationIsNull = false;
            }
             // determine if requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration should be set to null
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfigurationIsNull)
            {
                requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration = null;
            }
            if (requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration != null)
            {
                request.UpdateConfiguration.OpenIdConnectConfiguration = requestUpdateConfiguration_updateConfiguration_OpenIdConnectConfiguration;
                requestUpdateConfigurationIsNull = false;
            }
             // determine if request.UpdateConfiguration should be set to null
            if (requestUpdateConfigurationIsNull)
            {
                request.UpdateConfiguration = null;
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
        
        private Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse CallAWSServiceOperation(IAmazonVerifiedPermissions client, Amazon.VerifiedPermissions.Model.UpdateIdentitySourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Verified Permissions", "UpdateIdentitySource");
            try
            {
                #if DESKTOP
                return client.UpdateIdentitySource(request);
                #elif CORECLR
                return client.UpdateIdentitySourceAsync(request).GetAwaiter().GetResult();
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
            public System.String IdentitySourceId { get; set; }
            public System.String PolicyStoreId { get; set; }
            public System.String PrincipalEntityType { get; set; }
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
            public System.Func<Amazon.VerifiedPermissions.Model.UpdateIdentitySourceResponse, UpdateAVPIdentitySourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
