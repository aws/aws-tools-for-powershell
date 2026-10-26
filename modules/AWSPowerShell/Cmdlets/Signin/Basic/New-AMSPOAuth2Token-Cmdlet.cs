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
using Amazon.Signin;
using Amazon.Signin.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMSP
{
    /// <summary>
    /// Exchanges an authorization code or refresh token for an OAuth 2.0 access token and
    /// refresh token.
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
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TokenInput_ClientId
        /// <summary>
        /// <para>
        /// The OAuth 2.0 client identifier. Expected values:
        /// "arn:aws:signin:::devtools/same-device" or "arn:aws:signin:::devtools/cross-device".
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
        /// The authorization code received from the "/v1/authorize"
        /// endpoint. Required when "grant_type=authorization_code".
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenInput_Code { get; set; }
        #endregion
        
        #region Parameter TokenInput_CodeVerifier
        /// <summary>
        /// <para>
        /// The PKCE code verifier that proves possession
        /// of the original code challenge. Required when "grant_type=authorization_code".
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenInput_CodeVerifier { get; set; }
        #endregion
        
        #region Parameter TokenInput_GrantType
        /// <summary>
        /// <para>
        /// The OAuth 2.0 grant type. Supported values:
        /// - "authorization_code" - Exchange an authorization code for tokens. - "refresh_token"
        /// - Use a refresh token to obtain a new access token.
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
        /// The redirect URI that was used in the original
        /// authorization request. Must match exactly. Required when "grant_type=authorization_code".
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TokenInput_RedirectUri { get; set; }
        #endregion
        
        #region Parameter TokenInput_RefreshToken
        /// <summary>
        /// <para>
        /// The refresh token issued by a previous token
        /// response. Required when "grant_type=refresh_token".
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
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
                return client.CreateOAuth2TokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
