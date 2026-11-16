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
    /// Exchanges an existing token for a new token that is scoped and audience-bound for
    /// a specific downstream service, following the OAuth 2.0 Token Exchange grant type.
    /// For more information about the OAuth 2.0 Token Exchange grant type, see <a href="https://tools.ietf.org/html/rfc8693">RFC
    /// 8693 - OAuth 2.0 Token Exchange</a> on the IETF website. Present a <c>SubjectToken</c>,
    /// the credential that you already hold, to receive a new token appropriate for calling
    /// a specific resource server or audience.
    /// 
    ///  
    /// <para>
    /// If you also present an <c>ActorToken</c> that identifies an intermediary service,
    /// the issued token carries an <c>act</c> claim that identifies the intermediary, and
    /// downstream services can distinguish a user acting directly from an intermediary acting
    /// on the user's behalf. If you don't present an <c>ActorToken</c>, the issued token
    /// appears as if the user acted directly.
    /// </para><para>
    /// To use this operation, you must have IAM credentials, or you must present the requesting
    /// app client's <c>ClientId</c> and, if the client has a secret, <c>ClientSecret</c>,
    /// in the request.
    /// </para><para>
    /// The requesting app client must have <c>ALLOW_TOKEN_EXCHANGE_IMPERSONATION</c> or <c>ALLOW_TOKEN_EXCHANGE_DELEGATION</c>
    /// in its <c>ExplicitAuthFlows</c> (depending on whether you include an <c>ActorToken</c>),
    /// or the request fails.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CGIPDerivedToken")]
    [OutputType("Amazon.CognitoIdentityProvider.Model.GetDerivedTokenResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider GetDerivedToken API operation.", Operation = new[] {"GetDerivedToken"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.GetDerivedTokenResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.GetDerivedTokenResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.GetDerivedTokenResponse object containing multiple properties."
    )]
    public partial class GetCGIPDerivedTokenCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActorToken
        /// <summary>
        /// <para>
        /// <para>A token that identifies the intermediary service that is exchanging the token on behalf
        /// of the user. When you provide an <c>ActorToken</c>, the token that Amazon Cognito
        /// issues carries an <c>act</c> claim that identifies the intermediary, so that downstream
        /// services can distinguish a user acting directly from an intermediary acting on the
        /// user's behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActorToken { get; set; }
        #endregion
        
        #region Parameter ActorTokenProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the third-party identity provider that issued the <c>ActorToken</c>, if
        /// the actor token isn't a Amazon Cognito token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActorTokenProviderName { get; set; }
        #endregion
        
        #region Parameter ActorTokenType
        /// <summary>
        /// <para>
        /// <para>The type of the <c>ActorToken</c> that you provide. Required when you provide an <c>ActorToken</c>.
        /// Valid values:</para><ul><li><para><c>ACCESS_TOKEN</c> – The actor token is an access token.</para></li><li><para><c>ID_TOKEN</c> – The actor token is an ID token.</para></li><li><para><c>SAML2</c> – The actor token is a SAML 2.0 assertion.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TokenTypeIdentifierType")]
        public Amazon.CognitoIdentityProvider.TokenTypeIdentifierType ActorTokenType { get; set; }
        #endregion
        
        #region Parameter Audience
        /// <summary>
        /// <para>
        /// <para>The logical name of the target service where you intend to use the issued token. You
        /// can't request both <c>Audiences</c> and <c>Resources</c> in the same request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Audiences")]
        public System.String[] Audience { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The ID of the app client that requests the token exchange.</para>
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
        
        #region Parameter ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret of the requested app client, if the client has a secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientSecret { get; set; }
        #endregion
        
        #region Parameter RequestedTokenType
        /// <summary>
        /// <para>
        /// <para>The type of token that you want Amazon Cognito to issue. Valid values:</para><ul><li><para><c>ACCESS_TOKEN</c> – Issues an access token.</para></li><li><para><c>ID_TOKEN</c> – Issues an ID token.</para></li></ul><para>Amazon Cognito can't issue a SAML assertion, so <c>SAML2</c> isn't a valid value for
        /// this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.IssuedTokenTypeIdentifierType")]
        public Amazon.CognitoIdentityProvider.IssuedTokenTypeIdentifierType RequestedTokenType { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The identifier of a resource server in your user pool where you intend to use the
        /// issued token. You can't request both <c>Resources</c> and <c>Audiences</c> in the
        /// same request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resources")]
        public System.String[] Resource { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The scopes that you want the new token to have. Amazon Cognito issues a token with
        /// the intersection of these requested scopes, the scopes of your <c>SubjectToken</c>,
        /// and the scopes that are allowed for the requesting app client. If you don't specify
        /// any scopes, Amazon Cognito issues a token with the same scopes as your <c>SubjectToken</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scopes")]
        public System.String[] Scope { get; set; }
        #endregion
        
        #region Parameter SubjectToken
        /// <summary>
        /// <para>
        /// <para>The token that you want to exchange for a new token. This is the credential that represents
        /// the identity of the party on behalf of whom the request is being made.</para>
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
        public System.String SubjectToken { get; set; }
        #endregion
        
        #region Parameter SubjectTokenProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the third-party identity provider that issued the <c>SubjectToken</c>,
        /// if the subject token isn't a Amazon Cognito token. Provide this value when your <c>SubjectToken</c>
        /// came from a SAML or OIDC provider that you registered with your user pool, so that
        /// Amazon Cognito can validate it against that provider's configuration. Omit this parameter
        /// for a Amazon Cognito ID or access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubjectTokenProviderName { get; set; }
        #endregion
        
        #region Parameter SubjectTokenType
        /// <summary>
        /// <para>
        /// <para>The type of the <c>SubjectToken</c> that you want to exchange. Valid values:</para><ul><li><para><c>ACCESS_TOKEN</c> – The subject token is an access token.</para></li><li><para><c>ID_TOKEN</c> – The subject token is an ID token.</para></li><li><para><c>SAML2</c> – The subject token is a SAML 2.0 assertion.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.TokenTypeIdentifierType")]
        public Amazon.CognitoIdentityProvider.TokenTypeIdentifierType SubjectTokenType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.GetDerivedTokenResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.GetDerivedTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.GetDerivedTokenResponse, GetCGIPDerivedTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActorToken = this.ActorToken;
            context.ActorTokenProviderName = this.ActorTokenProviderName;
            context.ActorTokenType = this.ActorTokenType;
            if (this.Audience != null)
            {
                context.Audience = new List<System.String>(this.Audience);
            }
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientSecret = this.ClientSecret;
            context.RequestedTokenType = this.RequestedTokenType;
            if (this.Resource != null)
            {
                context.Resource = new List<System.String>(this.Resource);
            }
            if (this.Scope != null)
            {
                context.Scope = new List<System.String>(this.Scope);
            }
            context.SubjectToken = this.SubjectToken;
            #if MODULAR
            if (this.SubjectToken == null && ParameterWasBound(nameof(this.SubjectToken)))
            {
                WriteWarning("You are passing $null as a value for parameter SubjectToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubjectTokenProviderName = this.SubjectTokenProviderName;
            context.SubjectTokenType = this.SubjectTokenType;
            #if MODULAR
            if (this.SubjectTokenType == null && ParameterWasBound(nameof(this.SubjectTokenType)))
            {
                WriteWarning("You are passing $null as a value for parameter SubjectTokenType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.GetDerivedTokenRequest();
            
            if (cmdletContext.ActorToken != null)
            {
                request.ActorToken = cmdletContext.ActorToken;
            }
            if (cmdletContext.ActorTokenProviderName != null)
            {
                request.ActorTokenProviderName = cmdletContext.ActorTokenProviderName;
            }
            if (cmdletContext.ActorTokenType != null)
            {
                request.ActorTokenType = cmdletContext.ActorTokenType;
            }
            if (cmdletContext.Audience != null)
            {
                request.Audiences = cmdletContext.Audience;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.ClientSecret != null)
            {
                request.ClientSecret = cmdletContext.ClientSecret;
            }
            if (cmdletContext.RequestedTokenType != null)
            {
                request.RequestedTokenType = cmdletContext.RequestedTokenType;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resources = cmdletContext.Resource;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scopes = cmdletContext.Scope;
            }
            if (cmdletContext.SubjectToken != null)
            {
                request.SubjectToken = cmdletContext.SubjectToken;
            }
            if (cmdletContext.SubjectTokenProviderName != null)
            {
                request.SubjectTokenProviderName = cmdletContext.SubjectTokenProviderName;
            }
            if (cmdletContext.SubjectTokenType != null)
            {
                request.SubjectTokenType = cmdletContext.SubjectTokenType;
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
        
        private Amazon.CognitoIdentityProvider.Model.GetDerivedTokenResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.GetDerivedTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "GetDerivedToken");
            try
            {
                return client.GetDerivedTokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActorToken { get; set; }
            public System.String ActorTokenProviderName { get; set; }
            public Amazon.CognitoIdentityProvider.TokenTypeIdentifierType ActorTokenType { get; set; }
            public List<System.String> Audience { get; set; }
            public System.String ClientId { get; set; }
            public System.String ClientSecret { get; set; }
            public Amazon.CognitoIdentityProvider.IssuedTokenTypeIdentifierType RequestedTokenType { get; set; }
            public List<System.String> Resource { get; set; }
            public List<System.String> Scope { get; set; }
            public System.String SubjectToken { get; set; }
            public System.String SubjectTokenProviderName { get; set; }
            public Amazon.CognitoIdentityProvider.TokenTypeIdentifierType SubjectTokenType { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.GetDerivedTokenResponse, GetCGIPDerivedTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
