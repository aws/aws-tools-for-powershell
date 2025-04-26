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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Given a refresh token, issues new ID, access, and optionally refresh tokens for the
    /// user who owns the submitted token. This operation issues a new refresh token and invalidates
    /// the original refresh token after an optional grace period when refresh token rotation
    /// is enabled. If refresh token rotation is disabled, issues new ID and access tokens
    /// only.
    /// </summary>
    [Cmdlet("Get", "CGIPTokensFromRefreshToken")]
    [OutputType("Amazon.CognitoIdentityProvider.Model.AuthenticationResultType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider GetTokensFromRefreshToken API operation.", Operation = new[] {"GetTokensFromRefreshToken"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.AuthenticationResultType or Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.AuthenticationResultType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCGIPTokensFromRefreshTokenCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The app client that issued the refresh token to the user who wants to request new
        /// tokens.</para>
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
        
        #region Parameter ClientMetadata
        /// <summary>
        /// <para>
        /// <para>A map of custom key-value pairs that you can provide as input for certain custom workflows
        /// that this action triggers.</para><para>You create custom workflows by assigning Lambda functions to user pool triggers. When
        /// you use the <c>GetTokensFromRefreshToken</c> API action, Amazon Cognito invokes the
        /// Lambda function the pre token generation trigger.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-working-with-aws-lambda-triggers.html">
        /// Using Lambda triggers</a> in the <i>Amazon Cognito Developer Guide</i>.</para><note><para>When you use the <c>ClientMetadata</c> parameter, note that Amazon Cognito won't do
        /// the following:</para><ul><li><para>Store the <c>ClientMetadata</c> value. This data is available only to Lambda triggers
        /// that are assigned to a user pool to support custom workflows. If your user pool configuration
        /// doesn't include triggers, the <c>ClientMetadata</c> parameter serves no purpose.</para></li><li><para>Validate the <c>ClientMetadata</c> value.</para></li><li><para>Encrypt the <c>ClientMetadata</c> value. Don't send sensitive information in this
        /// parameter.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ClientMetadata { get; set; }
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
        
        #region Parameter DeviceKey
        /// <summary>
        /// <para>
        /// <para>When you enable device remembering, Amazon Cognito issues a device key that you can
        /// use for device authentication that bypasses multi-factor authentication (MFA). To
        /// implement <c>GetTokensFromRefreshToken</c> in a user pool with device remembering,
        /// you must capture the device key from the initial authentication request. If your application
        /// doesn't provide the key of a registered device, Amazon Cognito issues a new one. You
        /// must provide the confirmed device key in this request if device remembering is enabled
        /// in your user pool.</para><para>For more information about device remembering, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-device-tracking.html">Working
        /// with devices</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceKey { get; set; }
        #endregion
        
        #region Parameter RefreshToken
        /// <summary>
        /// <para>
        /// <para>A valid refresh token that can authorize the request for new tokens. When refresh
        /// token rotation is active in the requested app client, this token is invalidated after
        /// the request is complete.</para>
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
        public System.String RefreshToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthenticationResult'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthenticationResult";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RefreshToken parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RefreshToken' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RefreshToken' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenResponse, GetCGIPTokensFromRefreshTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RefreshToken;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ClientMetadata != null)
            {
                context.ClientMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ClientMetadata.Keys)
                {
                    context.ClientMetadata.Add((String)hashKey, (System.String)(this.ClientMetadata[hashKey]));
                }
            }
            context.ClientSecret = this.ClientSecret;
            context.DeviceKey = this.DeviceKey;
            context.RefreshToken = this.RefreshToken;
            #if MODULAR
            if (this.RefreshToken == null && ParameterWasBound(nameof(this.RefreshToken)))
            {
                WriteWarning("You are passing $null as a value for parameter RefreshToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenRequest();
            
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.ClientMetadata != null)
            {
                request.ClientMetadata = cmdletContext.ClientMetadata;
            }
            if (cmdletContext.ClientSecret != null)
            {
                request.ClientSecret = cmdletContext.ClientSecret;
            }
            if (cmdletContext.DeviceKey != null)
            {
                request.DeviceKey = cmdletContext.DeviceKey;
            }
            if (cmdletContext.RefreshToken != null)
            {
                request.RefreshToken = cmdletContext.RefreshToken;
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
        
        private Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "GetTokensFromRefreshToken");
            try
            {
                #if DESKTOP
                return client.GetTokensFromRefreshToken(request);
                #elif CORECLR
                return client.GetTokensFromRefreshTokenAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> ClientMetadata { get; set; }
            public System.String ClientSecret { get; set; }
            public System.String DeviceKey { get; set; }
            public System.String RefreshToken { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.GetTokensFromRefreshTokenResponse, GetCGIPTokensFromRefreshTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthenticationResult;
        }
        
    }
}
