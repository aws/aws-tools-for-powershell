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
    /// Begins setup of time-based one-time password (TOTP) multi-factor authentication (MFA)
    /// for a user, with a unique private key that Amazon Cognito generates and returns in
    /// the API response. You can authorize an <c>AssociateSoftwareToken</c> request with
    /// either the user's access token, or a session string from a challenge response that
    /// you received from Amazon Cognito.
    /// 
    ///  <note><para>
    /// Amazon Cognito disassociates an existing software token when you verify the new token
    /// in a <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_VerifySoftwareToken.html">
    /// VerifySoftwareToken</a> API request. If you don't verify the software token and your
    /// user pool doesn't require MFA, the user can then authenticate with user name and password
    /// credentials alone. If your user pool requires TOTP MFA, Amazon Cognito generates an
    /// <c>MFA_SETUP</c> or <c>SOFTWARE_TOKEN_SETUP</c> challenge each time your user signs
    /// in. Complete setup with <c>AssociateSoftwareToken</c> and <c>VerifySoftwareToken</c>.
    /// </para><para>
    /// After you set up software token MFA for your user, Amazon Cognito generates a <c>SOFTWARE_TOKEN_MFA</c>
    /// challenge when they authenticate. Respond to this challenge with your user's TOTP.
    /// </para></note><note><para>
    /// Amazon Cognito doesn't evaluate Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you can't use IAM credentials to authorize
    /// requests, and you can't grant IAM permissions in policies. For more information about
    /// authorization models in Amazon Cognito, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a>.
    /// </para></note><para>
    /// Authorize this action with a signed-in user's access token. It must include the scope
    /// <c>aws.cognito.signin.user.admin</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "CGIPSoftwareToken", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AssociateSoftwareToken API operation.", Operation = new[] {"AssociateSoftwareToken"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenResponse object containing multiple properties."
    )]
    public partial class AddCGIPSoftwareTokenCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessToken
        /// <summary>
        /// <para>
        /// <para>A valid access token that Amazon Cognito issued to the user whose software token you
        /// want to generate. You can provide either an access token or a session ID in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessToken { get; set; }
        #endregion
        
        #region Parameter Session
        /// <summary>
        /// <para>
        /// <para>The session identifier that maintains the state of authentication requests and challenge
        /// responses. In <c>AssociateSoftwareToken</c>, this is the session ID from a successful
        /// sign-in. You can provide either an access token or a session ID in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Session { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-CGIPSoftwareToken (AssociateSoftwareToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenResponse, AddCGIPSoftwareTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessToken = this.AccessToken;
            context.Session = this.Session;
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenRequest();
            
            if (cmdletContext.AccessToken != null)
            {
                request.AccessToken = cmdletContext.AccessToken;
            }
            if (cmdletContext.Session != null)
            {
                request.Session = cmdletContext.Session;
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
        
        private Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AssociateSoftwareToken");
            try
            {
                #if DESKTOP
                return client.AssociateSoftwareToken(request);
                #elif CORECLR
                return client.AssociateSoftwareTokenAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessToken { get; set; }
            public System.String Session { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.AssociateSoftwareTokenResponse, AddCGIPSoftwareTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
