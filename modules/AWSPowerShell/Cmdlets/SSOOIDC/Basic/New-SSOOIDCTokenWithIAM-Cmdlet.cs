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
using Amazon.SSOOIDC;
using Amazon.SSOOIDC.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSOOIDC
{
    /// <summary>
    /// Creates and returns access and refresh tokens for authorized client applications that
    /// are authenticated using any IAM entity, such as a service role or user. These tokens
    /// might contain defined scopes that specify permissions such as <c>read:profile</c>
    /// or <c>write:data</c>. Through downscoping, you can use the scopes parameter to request
    /// tokens with reduced permissions compared to the original client application's permissions
    /// or, if applicable, the refresh token's scopes. The access token can be used to fetch
    /// short-lived credentials for the assigned Amazon Web Services accounts or to access
    /// application APIs using <c>bearer</c> authentication.
    /// 
    ///  <note><para>
    /// This API is used with Signature Version 4. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_sigv.html">Amazon
    /// Web Services Signature Version 4 for API Requests</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SSOOIDCTokenWithIAM", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SSOOIDC.Model.CreateTokenWithIAMResponse")]
    [AWSCmdlet("Calls the AWS Single Sign-On OIDC CreateTokenWithIAM API operation.", Operation = new[] {"CreateTokenWithIAM"}, SelectReturnType = typeof(Amazon.SSOOIDC.Model.CreateTokenWithIAMResponse))]
    [AWSCmdletOutput("Amazon.SSOOIDC.Model.CreateTokenWithIAMResponse",
        "This cmdlet returns an Amazon.SSOOIDC.Model.CreateTokenWithIAMResponse object containing multiple properties."
    )]
    public partial class NewSSOOIDCTokenWithIAMCmdlet : AmazonSSOOIDCClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Assertion
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the JWT Bearer grant type. This value specifies
        /// the JSON Web Token (JWT) issued by a trusted token issuer. To authorize a trusted
        /// token issuer, configure the JWT Bearer GrantOptions for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Assertion { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The unique identifier string for the client or application. This value is an application
        /// ARN that has OAuth grants configured.</para>
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
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter Code
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Authorization Code grant type. This short-lived
        /// code is used to identify this authorization request. The code is obtained through
        /// a redirect from IAM Identity Center to a redirect URI persisted in the Authorization
        /// Code GrantOptions for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code { get; set; }
        #endregion
        
        #region Parameter CodeVerifier
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Authorization Code grant type. This value
        /// is generated by the client and presented to validate the original code challenge value
        /// the client passed at authorization time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CodeVerifier { get; set; }
        #endregion
        
        #region Parameter GrantType
        /// <summary>
        /// <para>
        /// <para>Supports the following OAuth grant types: Authorization Code, Refresh Token, JWT Bearer,
        /// and Token Exchange. Specify one of the following values, depending on the grant type
        /// that you want:</para><para>* Authorization Code - <c>authorization_code</c></para><para>* Refresh Token - <c>refresh_token</c></para><para>* JWT Bearer - <c>urn:ietf:params:oauth:grant-type:jwt-bearer</c></para><para>* Token Exchange - <c>urn:ietf:params:oauth:grant-type:token-exchange</c></para>
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
        public System.String GrantType { get; set; }
        #endregion
        
        #region Parameter RedirectUri
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Authorization Code grant type. This value
        /// specifies the location of the client or application that has registered to receive
        /// the authorization code. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedirectUri { get; set; }
        #endregion
        
        #region Parameter RefreshToken
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Refresh Token grant type. This token is used
        /// to refresh short-lived tokens, such as the access token, that might expire.</para><para>For more information about the features and limitations of the current IAM Identity
        /// Center OIDC implementation, see <i>Considerations for Using this Guide</i> in the
        /// <a href="https://docs.aws.amazon.com/singlesignon/latest/OIDCAPIReference/Welcome.html">IAM
        /// Identity Center OIDC API Reference</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RefreshToken { get; set; }
        #endregion
        
        #region Parameter RequestedTokenType
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Token Exchange grant type. This value specifies
        /// the type of token that the requester can receive. The following values are supported:</para><para>* Access Token - <c>urn:ietf:params:oauth:token-type:access_token</c></para><para>* Refresh Token - <c>urn:ietf:params:oauth:token-type:refresh_token</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestedTokenType { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The list of scopes for which authorization is requested. The access token that is
        /// issued is limited to the scopes that are granted. If the value is not specified, IAM
        /// Identity Center authorizes all scopes configured for the application, including the
        /// following default scopes: <c>openid</c>, <c>aws</c>, <c>sts:identity_context</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Scope { get; set; }
        #endregion
        
        #region Parameter SubjectToken
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Token Exchange grant type. This value specifies
        /// the subject of the exchange. The value of the subject token must be an access token
        /// issued by IAM Identity Center to a different client or application. The access token
        /// must have authorized scopes that indicate the requested application as a target audience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubjectToken { get; set; }
        #endregion
        
        #region Parameter SubjectTokenType
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Token Exchange grant type. This value specifies
        /// the type of token that is passed as the subject of the exchange. The following value
        /// is supported:</para><para>* Access Token - <c>urn:ietf:params:oauth:token-type:access_token</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubjectTokenType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOOIDC.Model.CreateTokenWithIAMResponse).
        /// Specifying the name of a property of type Amazon.SSOOIDC.Model.CreateTokenWithIAMResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClientId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSOOIDCTokenWithIAM (CreateTokenWithIAM)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOOIDC.Model.CreateTokenWithIAMResponse, NewSSOOIDCTokenWithIAMCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Assertion = this.Assertion;
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Code = this.Code;
            context.CodeVerifier = this.CodeVerifier;
            context.GrantType = this.GrantType;
            #if MODULAR
            if (this.GrantType == null && ParameterWasBound(nameof(this.GrantType)))
            {
                WriteWarning("You are passing $null as a value for parameter GrantType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RedirectUri = this.RedirectUri;
            context.RefreshToken = this.RefreshToken;
            context.RequestedTokenType = this.RequestedTokenType;
            if (this.Scope != null)
            {
                context.Scope = new List<System.String>(this.Scope);
            }
            context.SubjectToken = this.SubjectToken;
            context.SubjectTokenType = this.SubjectTokenType;
            
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
            var request = new Amazon.SSOOIDC.Model.CreateTokenWithIAMRequest();
            
            if (cmdletContext.Assertion != null)
            {
                request.Assertion = cmdletContext.Assertion;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.Code != null)
            {
                request.Code = cmdletContext.Code;
            }
            if (cmdletContext.CodeVerifier != null)
            {
                request.CodeVerifier = cmdletContext.CodeVerifier;
            }
            if (cmdletContext.GrantType != null)
            {
                request.GrantType = cmdletContext.GrantType;
            }
            if (cmdletContext.RedirectUri != null)
            {
                request.RedirectUri = cmdletContext.RedirectUri;
            }
            if (cmdletContext.RefreshToken != null)
            {
                request.RefreshToken = cmdletContext.RefreshToken;
            }
            if (cmdletContext.RequestedTokenType != null)
            {
                request.RequestedTokenType = cmdletContext.RequestedTokenType;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.SubjectToken != null)
            {
                request.SubjectToken = cmdletContext.SubjectToken;
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
        
        private Amazon.SSOOIDC.Model.CreateTokenWithIAMResponse CallAWSServiceOperation(IAmazonSSOOIDC client, Amazon.SSOOIDC.Model.CreateTokenWithIAMRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On OIDC", "CreateTokenWithIAM");
            try
            {
                return client.CreateTokenWithIAMAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Assertion { get; set; }
            public System.String ClientId { get; set; }
            public System.String Code { get; set; }
            public System.String CodeVerifier { get; set; }
            public System.String GrantType { get; set; }
            public System.String RedirectUri { get; set; }
            public System.String RefreshToken { get; set; }
            public System.String RequestedTokenType { get; set; }
            public List<System.String> Scope { get; set; }
            public System.String SubjectToken { get; set; }
            public System.String SubjectTokenType { get; set; }
            public System.Func<Amazon.SSOOIDC.Model.CreateTokenWithIAMResponse, NewSSOOIDCTokenWithIAMCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
