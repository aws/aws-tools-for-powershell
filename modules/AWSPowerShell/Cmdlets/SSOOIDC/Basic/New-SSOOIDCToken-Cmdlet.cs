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
using Amazon.SSOOIDC;
using Amazon.SSOOIDC.Model;

namespace Amazon.PowerShell.Cmdlets.SSOOIDC
{
    /// <summary>
    /// Creates and returns access and refresh tokens for clients that are authenticated using
    /// client secrets. The access token can be used to fetch short-term credentials for the
    /// assigned AWS accounts or to access application APIs using <c>bearer</c> authentication.
    /// </summary>
    [Cmdlet("New", "SSOOIDCToken", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SSOOIDC.Model.CreateTokenResponse")]
    [AWSCmdlet("Calls the AWS Single Sign-On OIDC CreateToken API operation.", Operation = new[] {"CreateToken"}, SelectReturnType = typeof(Amazon.SSOOIDC.Model.CreateTokenResponse))]
    [AWSCmdletOutput("Amazon.SSOOIDC.Model.CreateTokenResponse",
        "This cmdlet returns an Amazon.SSOOIDC.Model.CreateTokenResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSOOIDCTokenCmdlet : AmazonSSOOIDCClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The unique identifier string for the client or application. This value comes from
        /// the result of the <a>RegisterClient</a> API.</para>
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
        
        #region Parameter ClientSecret
        /// <summary>
        /// <para>
        /// <para>A secret string generated for the client. This value should come from the persisted
        /// result of the <a>RegisterClient</a> API.</para>
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
        public System.String ClientSecret { get; set; }
        #endregion
        
        #region Parameter Code
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Authorization Code grant type. The short-term
        /// code is used to identify this authorization request. This grant type is currently
        /// unsupported for the <a>CreateToken</a> API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code { get; set; }
        #endregion
        
        #region Parameter DeviceCode
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Device Code grant type. This short-term code
        /// is used to identify this authorization request. This comes from the result of the
        /// <a>StartDeviceAuthorization</a> API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceCode { get; set; }
        #endregion
        
        #region Parameter GrantType
        /// <summary>
        /// <para>
        /// <para>Supports the following OAuth grant types: Device Code and Refresh Token. Specify either
        /// of the following values, depending on the grant type that you want:</para><para>* Device Code - <c>urn:ietf:params:oauth:grant-type:device_code</c></para><para>* Refresh Token - <c>refresh_token</c></para><para>For information about how to obtain the device code, see the <a>StartDeviceAuthorization</a>
        /// topic.</para>
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
        /// the authorization code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedirectUri { get; set; }
        #endregion
        
        #region Parameter RefreshToken
        /// <summary>
        /// <para>
        /// <para>Used only when calling this API for the Refresh Token grant type. This token is used
        /// to refresh short-term tokens, such as the access token, that might expire.</para><para>For more information about the features and limitations of the current IAM Identity
        /// Center OIDC implementation, see <i>Considerations for Using this Guide</i> in the
        /// <a href="https://docs.aws.amazon.com/singlesignon/latest/OIDCAPIReference/Welcome.html">IAM
        /// Identity Center OIDC API Reference</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RefreshToken { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The list of scopes for which authorization is requested. The access token that is
        /// issued is limited to the scopes that are granted. If this value is not specified,
        /// IAM Identity Center authorizes all scopes that are configured for the client during
        /// the call to <a>RegisterClient</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Scope { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOOIDC.Model.CreateTokenResponse).
        /// Specifying the name of a property of type Amazon.SSOOIDC.Model.CreateTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClientId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClientId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClientId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClientId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSOOIDCToken (CreateToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOOIDC.Model.CreateTokenResponse, NewSSOOIDCTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClientId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientSecret = this.ClientSecret;
            #if MODULAR
            if (this.ClientSecret == null && ParameterWasBound(nameof(this.ClientSecret)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientSecret which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Code = this.Code;
            context.DeviceCode = this.DeviceCode;
            context.GrantType = this.GrantType;
            #if MODULAR
            if (this.GrantType == null && ParameterWasBound(nameof(this.GrantType)))
            {
                WriteWarning("You are passing $null as a value for parameter GrantType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RedirectUri = this.RedirectUri;
            context.RefreshToken = this.RefreshToken;
            if (this.Scope != null)
            {
                context.Scope = new List<System.String>(this.Scope);
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
            var request = new Amazon.SSOOIDC.Model.CreateTokenRequest();
            
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.ClientSecret != null)
            {
                request.ClientSecret = cmdletContext.ClientSecret;
            }
            if (cmdletContext.Code != null)
            {
                request.Code = cmdletContext.Code;
            }
            if (cmdletContext.DeviceCode != null)
            {
                request.DeviceCode = cmdletContext.DeviceCode;
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
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
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
        
        private Amazon.SSOOIDC.Model.CreateTokenResponse CallAWSServiceOperation(IAmazonSSOOIDC client, Amazon.SSOOIDC.Model.CreateTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On OIDC", "CreateToken");
            try
            {
                #if DESKTOP
                return client.CreateToken(request);
                #elif CORECLR
                return client.CreateTokenAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientId { get; set; }
            public System.String ClientSecret { get; set; }
            public System.String Code { get; set; }
            public System.String DeviceCode { get; set; }
            public System.String GrantType { get; set; }
            public System.String RedirectUri { get; set; }
            public System.String RefreshToken { get; set; }
            public List<System.String> Scope { get; set; }
            public System.Func<Amazon.SSOOIDC.Model.CreateTokenResponse, NewSSOOIDCTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
