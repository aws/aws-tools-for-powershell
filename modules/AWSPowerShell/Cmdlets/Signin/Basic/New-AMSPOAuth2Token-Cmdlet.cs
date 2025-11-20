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
using Amazon.Signin;
using Amazon.Signin.Model;

namespace Amazon.PowerShell.Cmdlets.AMSP
{
    /// <summary>
    /// CreateOAuth2Token API
    /// 
    ///  
    /// <para>
    /// Path: /v1/token Request Method: POST Content-Type: application/json or application/x-www-form-urlencoded
    /// </para><para>
    /// This API implements OAuth 2.0 flows for AWS Sign-In CLI clients, supporting both:
    /// </para><ol><li>Authorization code redemption (grant_type=authorization_code) - NOT idempotent</li><li>Token refresh (grant_type=refresh_token) - Idempotent within token validity window</li></ol><para>
    /// The operation behavior is determined by the grant_type parameter in the request body:
    /// </para><para><strong>Authorization Code Flow (NOT Idempotent):</strong></para><ul><li>JSON or form-encoded body with client_id, grant_type=authorization_code,
    /// code, redirect_uri, code_verifier</li><li>Returns access_token, token_type, expires_in,
    /// refresh_token, and id_token</li><li>Each authorization code can only be used ONCE
    /// for security (prevents replay attacks)</li></ul><para><strong>Token Refresh Flow (Idempotent):</strong></para><ul><li>JSON or form-encoded body with client_id, grant_type=refresh_token, refresh_token</li><li>Returns access_token, token_type, expires_in, and refresh_token (no id_token)</li><li>Multiple calls with same refresh_token return consistent results within validity
    /// window</li></ul><para>
    /// Authentication and authorization:
    /// </para><ul><li>Confidential clients: sigv4 signing required with signin:ExchangeToken permissions</li><li>CLI clients (public): authn/authz skipped based on client_id &amp; grant_type</li></ul><para>
    /// Note: This operation cannot be marked as @idempotent because it handles both idempotent
    /// (token refresh) and non-idempotent (auth code redemption) flows in a single endpoint.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AMSPOAuth2Token", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Signin.Model.CreateOAuth2TokenResponseBody")]
    [AWSCmdlet("Calls the AWS Sign-In Data Plane CreateOAuth2Token API operation.", Operation = new[] {"CreateOAuth2Token"}, SelectReturnType = typeof(Amazon.Signin.Model.CreateOAuth2TokenResponse))]
    [AWSCmdletOutput("Amazon.Signin.Model.CreateOAuth2TokenResponseBody or Amazon.Signin.Model.CreateOAuth2TokenResponse",
        "This cmdlet returns an Amazon.Signin.Model.CreateOAuth2TokenResponseBody object.",
        "The service call response (type Amazon.Signin.Model.CreateOAuth2TokenResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAMSPOAuth2TokenCmdlet : AmazonSigninClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TokenInput_ClientId
        /// <summary>
        /// <para>
        /// <para>The client identifier (ARN) used during Sign-In onboarding Required for both authorization
        /// code and refresh token flows</para>
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
        public System.String TokenInput_ClientId { get; set; }
        #endregion
        
        #region Parameter TokenInput_Code
        /// <summary>
        /// <para>
        /// <para>The authorization code received from /v1/authorize Required only when grant_type=authorization_code</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenInput_Code { get; set; }
        #endregion
        
        #region Parameter TokenInput_CodeVerifier
        /// <summary>
        /// <para>
        /// <para>PKCE code verifier to prove possession of the original code challenge Required only
        /// when grant_type=authorization_code</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenInput_CodeVerifier { get; set; }
        #endregion
        
        #region Parameter TokenInput_GrantType
        /// <summary>
        /// <para>
        /// <para>OAuth 2.0 grant type - determines which flow is used Must be "authorization_code"
        /// or "refresh_token"</para>
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
        public System.String TokenInput_GrantType { get; set; }
        #endregion
        
        #region Parameter TokenInput_RedirectUri
        /// <summary>
        /// <para>
        /// <para>The redirect URI that must match the original authorization request Required only
        /// when grant_type=authorization_code</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenInput_RedirectUri { get; set; }
        #endregion
        
        #region Parameter TokenInput_RefreshToken
        /// <summary>
        /// <para>
        /// <para>The refresh token returned from auth_code redemption Required only when grant_type=refresh_token</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenInput_RefreshToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TokenOutput'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Signin.Model.CreateOAuth2TokenResponse).
        /// Specifying the name of a property of type Amazon.Signin.Model.CreateOAuth2TokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TokenOutput";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TokenInput_ClientId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMSPOAuth2Token (CreateOAuth2Token)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Signin.Model.CreateOAuth2TokenResponse, NewAMSPOAuth2TokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TokenInput_ClientId = this.TokenInput_ClientId;
            #if MODULAR
            if (this.TokenInput_ClientId == null && ParameterWasBound(nameof(this.TokenInput_ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter TokenInput_ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TokenInput_Code = this.TokenInput_Code;
            context.TokenInput_CodeVerifier = this.TokenInput_CodeVerifier;
            context.TokenInput_GrantType = this.TokenInput_GrantType;
            #if MODULAR
            if (this.TokenInput_GrantType == null && ParameterWasBound(nameof(this.TokenInput_GrantType)))
            {
                WriteWarning("You are passing $null as a value for parameter TokenInput_GrantType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TokenInput_RedirectUri = this.TokenInput_RedirectUri;
            context.TokenInput_RefreshToken = this.TokenInput_RefreshToken;
            
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
            var request = new Amazon.Signin.Model.CreateOAuth2TokenRequest();
            
            
             // populate TokenInput
            var requestTokenInputIsNull = true;
            request.TokenInput = new Amazon.Signin.Model.CreateOAuth2TokenRequestBody();
            System.String requestTokenInput_tokenInput_ClientId = null;
            if (cmdletContext.TokenInput_ClientId != null)
            {
                requestTokenInput_tokenInput_ClientId = cmdletContext.TokenInput_ClientId;
            }
            if (requestTokenInput_tokenInput_ClientId != null)
            {
                request.TokenInput.ClientId = requestTokenInput_tokenInput_ClientId;
                requestTokenInputIsNull = false;
            }
            System.String requestTokenInput_tokenInput_Code = null;
            if (cmdletContext.TokenInput_Code != null)
            {
                requestTokenInput_tokenInput_Code = cmdletContext.TokenInput_Code;
            }
            if (requestTokenInput_tokenInput_Code != null)
            {
                request.TokenInput.Code = requestTokenInput_tokenInput_Code;
                requestTokenInputIsNull = false;
            }
            System.String requestTokenInput_tokenInput_CodeVerifier = null;
            if (cmdletContext.TokenInput_CodeVerifier != null)
            {
                requestTokenInput_tokenInput_CodeVerifier = cmdletContext.TokenInput_CodeVerifier;
            }
            if (requestTokenInput_tokenInput_CodeVerifier != null)
            {
                request.TokenInput.CodeVerifier = requestTokenInput_tokenInput_CodeVerifier;
                requestTokenInputIsNull = false;
            }
            System.String requestTokenInput_tokenInput_GrantType = null;
            if (cmdletContext.TokenInput_GrantType != null)
            {
                requestTokenInput_tokenInput_GrantType = cmdletContext.TokenInput_GrantType;
            }
            if (requestTokenInput_tokenInput_GrantType != null)
            {
                request.TokenInput.GrantType = requestTokenInput_tokenInput_GrantType;
                requestTokenInputIsNull = false;
            }
            System.String requestTokenInput_tokenInput_RedirectUri = null;
            if (cmdletContext.TokenInput_RedirectUri != null)
            {
                requestTokenInput_tokenInput_RedirectUri = cmdletContext.TokenInput_RedirectUri;
            }
            if (requestTokenInput_tokenInput_RedirectUri != null)
            {
                request.TokenInput.RedirectUri = requestTokenInput_tokenInput_RedirectUri;
                requestTokenInputIsNull = false;
            }
            System.String requestTokenInput_tokenInput_RefreshToken = null;
            if (cmdletContext.TokenInput_RefreshToken != null)
            {
                requestTokenInput_tokenInput_RefreshToken = cmdletContext.TokenInput_RefreshToken;
            }
            if (requestTokenInput_tokenInput_RefreshToken != null)
            {
                request.TokenInput.RefreshToken = requestTokenInput_tokenInput_RefreshToken;
                requestTokenInputIsNull = false;
            }
             // determine if request.TokenInput should be set to null
            if (requestTokenInputIsNull)
            {
                request.TokenInput = null;
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
        
        private Amazon.Signin.Model.CreateOAuth2TokenResponse CallAWSServiceOperation(IAmazonSignin client, Amazon.Signin.Model.CreateOAuth2TokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Sign-In Data Plane", "CreateOAuth2Token");
            try
            {
                #if DESKTOP
                return client.CreateOAuth2Token(request);
                #elif CORECLR
                return client.CreateOAuth2TokenAsync(request).GetAwaiter().GetResult();
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
            public System.String TokenInput_ClientId { get; set; }
            public System.String TokenInput_Code { get; set; }
            public System.String TokenInput_CodeVerifier { get; set; }
            public System.String TokenInput_GrantType { get; set; }
            public System.String TokenInput_RedirectUri { get; set; }
            public System.String TokenInput_RefreshToken { get; set; }
            public System.Func<Amazon.Signin.Model.CreateOAuth2TokenResponse, NewAMSPOAuth2TokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TokenOutput;
        }
        
    }
}
