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
    /// Adds a configuration and trust relationship between a third-party identity provider
    /// (IdP) and a user pool. Amazon Cognito accepts sign-in with third-party identity providers
    /// through managed login and OIDC relying-party libraries. For more information, see
    /// <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-identity-federation.html">Third-party
    /// IdP sign-in</a>.
    /// 
    ///  <note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("New", "CGIPIdentityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.IdentityProviderType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider CreateIdentityProvider API operation.", Operation = new[] {"CreateIdentityProvider"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.IdentityProviderType or Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.IdentityProviderType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCGIPIdentityProviderCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeMapping
        /// <summary>
        /// <para>
        /// <para>A mapping of IdP attributes to standard and custom user pool attributes. Specify a
        /// user pool attribute as the key of the key-value pair, and the IdP attribute claim
        /// name as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AttributeMapping { get; set; }
        #endregion
        
        #region Parameter IdpIdentifier
        /// <summary>
        /// <para>
        /// <para>An array of IdP identifiers, for example <c>"IdPIdentifiers": [ "MyIdP", "MyIdP2"
        /// ]</c>. Identifiers are friendly names that you can pass in the <c>idp_identifier</c>
        /// query parameter of requests to the <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/authorization-endpoint.html">Authorize
        /// endpoint</a> to silently redirect to sign-in with the associated IdP. Identifiers
        /// in a domain format also enable the use of <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-managing-saml-idp-naming.html">email-address
        /// matching with SAML providers</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdpIdentifiers")]
        public System.String[] IdpIdentifier { get; set; }
        #endregion
        
        #region Parameter ProviderDetail
        /// <summary>
        /// <para>
        /// <para>The scopes, URLs, and identifiers for your external identity provider. The following
        /// examples describe the provider detail keys for each IdP type. These values and their
        /// schema are subject to change. Social IdP <c>authorize_scopes</c> values must match
        /// the values listed here.</para><dl><dt>OpenID Connect (OIDC)</dt><dd><para>Amazon Cognito accepts the following elements when it can't discover endpoint URLs
        /// from <c>oidc_issuer</c>: <c>attributes_url</c>, <c>authorize_url</c>, <c>jwks_uri</c>,
        /// <c>token_url</c>.</para><para>Create or update request: <c>"ProviderDetails": { "attributes_request_method": "GET",
        /// "attributes_url": "https://auth.example.com/userInfo", "authorize_scopes": "openid
        /// profile email", "authorize_url": "https://auth.example.com/authorize", "client_id":
        /// "1example23456789", "client_secret": "provider-app-client-secret", "jwks_uri": "https://auth.example.com/.well-known/jwks.json",
        /// "oidc_issuer": "https://auth.example.com", "token_url": "https://example.com/token"
        /// }</c></para><para>Describe response: <c>"ProviderDetails": { "attributes_request_method": "GET", "attributes_url":
        /// "https://auth.example.com/userInfo", "attributes_url_add_attributes": "false", "authorize_scopes":
        /// "openid profile email", "authorize_url": "https://auth.example.com/authorize", "client_id":
        /// "1example23456789", "client_secret": "provider-app-client-secret", "jwks_uri": "https://auth.example.com/.well-known/jwks.json",
        /// "oidc_issuer": "https://auth.example.com", "token_url": "https://example.com/token"
        /// }</c></para></dd><dt>SAML</dt><dd><para>Create or update request with Metadata URL: <c>"ProviderDetails": { "IDPInit": "true",
        /// "IDPSignout": "true", "EncryptedResponses" : "true", "MetadataURL": "https://auth.example.com/sso/saml/metadata",
        /// "RequestSigningAlgorithm": "rsa-sha256" }</c></para><para>Create or update request with Metadata file: <c>"ProviderDetails": { "IDPInit": "true",
        /// "IDPSignout": "true", "EncryptedResponses" : "true", "MetadataFile": "[metadata XML]",
        /// "RequestSigningAlgorithm": "rsa-sha256" }</c></para><para>The value of <c>MetadataFile</c> must be the plaintext metadata document with all
        /// quote (") characters escaped by backslashes.</para><para>Describe response: <c>"ProviderDetails": { "IDPInit": "true", "IDPSignout": "true",
        /// "EncryptedResponses" : "true", "ActiveEncryptionCertificate": "[certificate]", "MetadataURL":
        /// "https://auth.example.com/sso/saml/metadata", "RequestSigningAlgorithm": "rsa-sha256",
        /// "SLORedirectBindingURI": "https://auth.example.com/slo/saml", "SSORedirectBindingURI":
        /// "https://auth.example.com/sso/saml" }</c></para></dd><dt>LoginWithAmazon</dt><dd><para>Create or update request: <c>"ProviderDetails": { "authorize_scopes": "profile postal_code",
        /// "client_id": "amzn1.application-oa2-client.1example23456789", "client_secret": "provider-app-client-secret"</c></para><para>Describe response: <c>"ProviderDetails": { "attributes_url": "https://api.amazon.com/user/profile",
        /// "attributes_url_add_attributes": "false", "authorize_scopes": "profile postal_code",
        /// "authorize_url": "https://www.amazon.com/ap/oa", "client_id": "amzn1.application-oa2-client.1example23456789",
        /// "client_secret": "provider-app-client-secret", "token_request_method": "POST", "token_url":
        /// "https://api.amazon.com/auth/o2/token" }</c></para></dd><dt>Google</dt><dd><para>Create or update request: <c>"ProviderDetails": { "authorize_scopes": "email profile
        /// openid", "client_id": "1example23456789.apps.googleusercontent.com", "client_secret":
        /// "provider-app-client-secret" }</c></para><para>Describe response: <c>"ProviderDetails": { "attributes_url": "https://people.googleapis.com/v1/people/me?personFields=",
        /// "attributes_url_add_attributes": "true", "authorize_scopes": "email profile openid",
        /// "authorize_url": "https://accounts.google.com/o/oauth2/v2/auth", "client_id": "1example23456789.apps.googleusercontent.com",
        /// "client_secret": "provider-app-client-secret", "oidc_issuer": "https://accounts.google.com",
        /// "token_request_method": "POST", "token_url": "https://www.googleapis.com/oauth2/v4/token"
        /// }</c></para></dd><dt>SignInWithApple</dt><dd><para>Create or update request: <c>"ProviderDetails": { "authorize_scopes": "email name",
        /// "client_id": "com.example.cognito", "private_key": "1EXAMPLE", "key_id": "2EXAMPLE",
        /// "team_id": "3EXAMPLE" }</c></para><para>Describe response: <c>"ProviderDetails": { "attributes_url_add_attributes": "false",
        /// "authorize_scopes": "email name", "authorize_url": "https://appleid.apple.com/auth/authorize",
        /// "client_id": "com.example.cognito", "key_id": "1EXAMPLE", "oidc_issuer": "https://appleid.apple.com",
        /// "team_id": "2EXAMPLE", "token_request_method": "POST", "token_url": "https://appleid.apple.com/auth/token"
        /// }</c></para></dd><dt>Facebook</dt><dd><para>Create or update request: <c>"ProviderDetails": { "api_version": "v17.0", "authorize_scopes":
        /// "public_profile, email", "client_id": "1example23456789", "client_secret": "provider-app-client-secret"
        /// }</c></para><para>Describe response: <c>"ProviderDetails": { "api_version": "v17.0", "attributes_url":
        /// "https://graph.facebook.com/v17.0/me?fields=", "attributes_url_add_attributes": "true",
        /// "authorize_scopes": "public_profile, email", "authorize_url": "https://www.facebook.com/v17.0/dialog/oauth",
        /// "client_id": "1example23456789", "client_secret": "provider-app-client-secret", "token_request_method":
        /// "GET", "token_url": "https://graph.facebook.com/v17.0/oauth/access_token" }</c></para></dd></dl>
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
        [Alias("ProviderDetails")]
        public System.Collections.Hashtable ProviderDetail { get; set; }
        #endregion
        
        #region Parameter ProviderName
        /// <summary>
        /// <para>
        /// <para>The name that you want to assign to the IdP. You can pass the identity provider name
        /// in the <c>identity_provider</c> query parameter of requests to the <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/authorization-endpoint.html">Authorize
        /// endpoint</a> to silently redirect to sign-in with the associated IdP.</para>
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
        public System.String ProviderName { get; set; }
        #endregion
        
        #region Parameter ProviderType
        /// <summary>
        /// <para>
        /// <para>The type of IdP that you want to add. Amazon Cognito supports OIDC, SAML 2.0, Login
        /// With Amazon, Sign In With Apple, Google, and Facebook IdPs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.IdentityProviderTypeType")]
        public Amazon.CognitoIdentityProvider.IdentityProviderTypeType ProviderType { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The Id of the user pool where you want to create an IdP.</para>
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
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdentityProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdentityProvider";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProviderName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGIPIdentityProvider (CreateIdentityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse, NewCGIPIdentityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AttributeMapping != null)
            {
                context.AttributeMapping = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AttributeMapping.Keys)
                {
                    context.AttributeMapping.Add((String)hashKey, (System.String)(this.AttributeMapping[hashKey]));
                }
            }
            if (this.IdpIdentifier != null)
            {
                context.IdpIdentifier = new List<System.String>(this.IdpIdentifier);
            }
            if (this.ProviderDetail != null)
            {
                context.ProviderDetail = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ProviderDetail.Keys)
                {
                    context.ProviderDetail.Add((String)hashKey, (System.String)(this.ProviderDetail[hashKey]));
                }
            }
            #if MODULAR
            if (this.ProviderDetail == null && ParameterWasBound(nameof(this.ProviderDetail)))
            {
                WriteWarning("You are passing $null as a value for parameter ProviderDetail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderName = this.ProviderName;
            #if MODULAR
            if (this.ProviderName == null && ParameterWasBound(nameof(this.ProviderName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProviderName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderType = this.ProviderType;
            #if MODULAR
            if (this.ProviderType == null && ParameterWasBound(nameof(this.ProviderType)))
            {
                WriteWarning("You are passing $null as a value for parameter ProviderType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderRequest();
            
            if (cmdletContext.AttributeMapping != null)
            {
                request.AttributeMapping = cmdletContext.AttributeMapping;
            }
            if (cmdletContext.IdpIdentifier != null)
            {
                request.IdpIdentifiers = cmdletContext.IdpIdentifier;
            }
            if (cmdletContext.ProviderDetail != null)
            {
                request.ProviderDetails = cmdletContext.ProviderDetail;
            }
            if (cmdletContext.ProviderName != null)
            {
                request.ProviderName = cmdletContext.ProviderName;
            }
            if (cmdletContext.ProviderType != null)
            {
                request.ProviderType = cmdletContext.ProviderType;
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
        
        private Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "CreateIdentityProvider");
            try
            {
                #if DESKTOP
                return client.CreateIdentityProvider(request);
                #elif CORECLR
                return client.CreateIdentityProviderAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AttributeMapping { get; set; }
            public List<System.String> IdpIdentifier { get; set; }
            public Dictionary<System.String, System.String> ProviderDetail { get; set; }
            public System.String ProviderName { get; set; }
            public Amazon.CognitoIdentityProvider.IdentityProviderTypeType ProviderType { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.CreateIdentityProviderResponse, NewCGIPIdentityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdentityProvider;
        }
        
    }
}
