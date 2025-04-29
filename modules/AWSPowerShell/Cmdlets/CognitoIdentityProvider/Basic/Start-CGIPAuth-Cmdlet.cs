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
    /// Declares an authentication flow and initiates sign-in for a user in the Amazon Cognito
    /// user directory. Amazon Cognito might respond with an additional challenge or an <c>AuthenticationResult</c>
    /// that contains the outcome of a successful authentication. You can't sign in a user
    /// with a federated IdP with <c>InitiateAuth</c>. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/authentication.html">Authentication</a>.
    /// 
    ///  <note><para>
    /// Amazon Cognito doesn't evaluate Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you can't use IAM credentials to authorize
    /// requests, and you can't grant IAM permissions in policies. For more information about
    /// authorization models in Amazon Cognito, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a>.
    /// </para></note><note><para>
    /// This action might generate an SMS text message. Starting June 1, 2021, US telecom
    /// carriers require you to register an origination phone number before you can send SMS
    /// messages to US phone numbers. If you use SMS text messages in Amazon Cognito, you
    /// must register a phone number with <a href="https://console.aws.amazon.com/pinpoint/home/">Amazon
    /// Pinpoint</a>. Amazon Cognito uses the registered number automatically. Otherwise,
    /// Amazon Cognito users who must receive SMS messages might not be able to sign up, activate
    /// their accounts, or sign in.
    /// </para><para>
    /// If you have never used SMS text messages with Amazon Cognito or any other Amazon Web
    /// Services service, Amazon Simple Notification Service might place your account in the
    /// SMS sandbox. In <i><a href="https://docs.aws.amazon.com/sns/latest/dg/sns-sms-sandbox.html">sandbox
    /// mode</a></i>, you can send messages only to verified phone numbers. After you test
    /// your app while in the sandbox environment, you can move out of the sandbox and into
    /// production. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-sms-settings.html">
    /// SMS message settings for Amazon Cognito user pools</a> in the <i>Amazon Cognito Developer
    /// Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "CGIPAuth", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.InitiateAuthResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider InitiateAuth API operation.", Operation = new[] {"InitiateAuth"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.InitiateAuthResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.InitiateAuthResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.InitiateAuthResponse object containing multiple properties."
    )]
    public partial class StartCGIPAuthCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnalyticsMetadata_AnalyticsEndpointId
        /// <summary>
        /// <para>
        /// <para>The endpoint ID. Information that you want to pass to Amazon Pinpoint about where
        /// to send notifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsMetadata_AnalyticsEndpointId { get; set; }
        #endregion
        
        #region Parameter AuthFlow
        /// <summary>
        /// <para>
        /// <para>The authentication flow that you want to initiate. Each <c>AuthFlow</c> has linked
        /// <c>AuthParameters</c> that you must submit. The following are some example flows.</para><dl><dt>USER_AUTH</dt><dd><para>The entry point for <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/authentication-flows-selection-sdk.html#authentication-flows-selection-choice">choice-based
        /// authentication</a> with passwords, one-time passwords, and WebAuthn authenticators.
        /// Request a preferred authentication type or review available authentication types.
        /// From the offered authentication types, select one in a challenge response and then
        /// authenticate with that method in an additional challenge response. To activate this
        /// setting, your user pool must be in the <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/feature-plans-features-essentials.html">
        /// Essentials tier</a> or higher.</para></dd><dt>USER_SRP_AUTH</dt><dd><para>Username-password authentication with the Secure Remote Password (SRP) protocol. For
        /// more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-authentication-flow.html#Using-SRP-password-verification-in-custom-authentication-flow">Use
        /// SRP password verification in custom authentication flow</a>.</para></dd><dt>REFRESH_TOKEN_AUTH and REFRESH_TOKEN</dt><dd><para>Receive new ID and access tokens when you pass a <c>REFRESH_TOKEN</c> parameter with
        /// a valid refresh token as the value. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-using-the-refresh-token.html">Using
        /// the refresh token</a>.</para></dd><dt>CUSTOM_AUTH</dt><dd><para>Custom authentication with Lambda triggers. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-lambda-challenge.html">Custom
        /// authentication challenge Lambda triggers</a>.</para></dd><dt>USER_PASSWORD_AUTH</dt><dd><para>Client-side username-password authentication with the password sent directly in the
        /// request. For more information about client-side and server-side authentication, see
        /// <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/authentication-flows-public-server-side.html">SDK
        /// authorization models</a>.</para></dd></dl><para><c>ADMIN_USER_PASSWORD_AUTH</c> is a flow type of <c>AdminInitiateAuth</c> and isn't
        /// valid for InitiateAuth. <c>ADMIN_NO_SRP_AUTH</c> is a legacy server-side username-password
        /// flow and isn't valid for InitiateAuth.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AuthFlowType")]
        public Amazon.CognitoIdentityProvider.AuthFlowType AuthFlow { get; set; }
        #endregion
        
        #region Parameter AuthParameter
        /// <summary>
        /// <para>
        /// <para>The authentication parameters. These are inputs corresponding to the <c>AuthFlow</c>
        /// that you're invoking.</para><para>The required values are specific to the <a>InitiateAuthRequest$AuthFlow</a>.</para><para>The following are some authentication flows and their parameters. Add a <c>SECRET_HASH</c>
        /// parameter if your app client has a client secret.</para><ul><li><para><c>USER_AUTH</c>: <c>USERNAME</c> (required), <c>PREFERRED_CHALLENGE</c>. If you
        /// don't provide a value for <c>PREFERRED_CHALLENGE</c>, Amazon Cognito responds with
        /// the <c>AvailableChallenges</c> parameter that specifies the available sign-in methods.</para></li><li><para><c>USER_SRP_AUTH</c>: <c>USERNAME</c> (required), <c>SRP_A</c> (required), <c>DEVICE_KEY</c>.</para></li><li><para><c>USER_PASSWORD_AUTH</c>: <c>USERNAME</c> (required), <c>PASSWORD</c> (required),
        /// <c>DEVICE_KEY</c>.</para></li><li><para><c>REFRESH_TOKEN_AUTH/REFRESH_TOKEN</c>: <c>REFRESH_TOKEN</c> (required), <c>DEVICE_KEY</c>.</para></li><li><para><c>CUSTOM_AUTH</c>: <c>USERNAME</c> (required), <c>SECRET_HASH</c> (if app client
        /// is configured with client secret), <c>DEVICE_KEY</c>. To start the authentication
        /// flow with password verification, include <c>ChallengeName: SRP_A</c> and <c>SRP_A:
        /// (The SRP_A Value)</c>.</para></li></ul><para>For more information about <c>SECRET_HASH</c>, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/signing-up-users-in-your-app.html#cognito-user-pools-computing-secret-hash">Computing
        /// secret hash values</a>. For information about <c>DEVICE_KEY</c>, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-device-tracking.html">Working
        /// with user devices in your user pool</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters")]
        public System.Collections.Hashtable AuthParameter { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The ID of the app client that your user wants to sign in to.</para>
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
        
        #region Parameter ClientMetadata
        /// <summary>
        /// <para>
        /// <para>A map of custom key-value pairs that you can provide as input for certain custom workflows
        /// that this action triggers.</para><para>You create custom workflows by assigning Lambda functions to user pool triggers. When
        /// you send an <c>InitiateAuth</c> request, Amazon Cognito invokes the Lambda functions
        /// that are specified for various triggers. The <c>ClientMetadata</c> value is passed
        /// as input to the functions for only the following triggers.</para><ul><li><para>Pre sign-up</para></li><li><para>Pre authentication</para></li><li><para>User migration</para></li></ul><para>When Amazon Cognito invokes the functions for these triggers, it passes a JSON payload
        /// as input to the function. This payload contains a <c>validationData</c> attribute
        /// with the data that you assigned to the <c>ClientMetadata</c> parameter in your <c>InitiateAuth</c>
        /// request. In your function, <c>validationData</c> can contribute to operations that
        /// require data that isn't in the default payload.</para><para><c>InitiateAuth</c> requests invokes the following triggers without <c>ClientMetadata</c>
        /// as input.</para><ul><li><para>Post authentication</para></li><li><para>Custom message</para></li><li><para>Pre token generation</para></li><li><para>Create auth challenge</para></li><li><para>Define auth challenge</para></li><li><para>Custom email sender</para></li><li><para>Custom SMS sender</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-working-with-aws-lambda-triggers.html">
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
        
        #region Parameter UserContextData_EncodedData
        /// <summary>
        /// <para>
        /// <para>Encoded device-fingerprint details that your app collected with the Amazon Cognito
        /// context data collection library. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pool-settings-adaptive-authentication.html#user-pool-settings-adaptive-authentication-device-fingerprint">Adding
        /// user device and session data to API requests</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserContextData_EncodedData { get; set; }
        #endregion
        
        #region Parameter UserContextData_IpAddress
        /// <summary>
        /// <para>
        /// <para>The source IP address of your user's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserContextData_IpAddress { get; set; }
        #endregion
        
        #region Parameter Session
        /// <summary>
        /// <para>
        /// <para>The optional session ID from a <c>ConfirmSignUp</c> API request. You can sign in a
        /// user directly from the sign-up process with the <c>USER_AUTH</c> authentication flow.
        /// When you pass the session ID to <c>InitiateAuth</c>, Amazon Cognito assumes the SMS
        /// or email message one-time verification password from <c>ConfirmSignUp</c> as the primary
        /// authentication factor. You're not required to submit this code a second time. This
        /// option is only valid for users who have confirmed their sign-up and are signing in
        /// for the first time within the authentication flow session duration of the session
        /// ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Session { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.InitiateAuthResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.InitiateAuthResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CGIPAuth (InitiateAuth)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.InitiateAuthResponse, StartCGIPAuthCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnalyticsMetadata_AnalyticsEndpointId = this.AnalyticsMetadata_AnalyticsEndpointId;
            context.AuthFlow = this.AuthFlow;
            #if MODULAR
            if (this.AuthFlow == null && ParameterWasBound(nameof(this.AuthFlow)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthFlow which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AuthParameter != null)
            {
                context.AuthParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuthParameter.Keys)
                {
                    context.AuthParameter.Add((String)hashKey, (System.String)(this.AuthParameter[hashKey]));
                }
            }
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
            context.Session = this.Session;
            context.UserContextData_EncodedData = this.UserContextData_EncodedData;
            context.UserContextData_IpAddress = this.UserContextData_IpAddress;
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.InitiateAuthRequest();
            
            
             // populate AnalyticsMetadata
            var requestAnalyticsMetadataIsNull = true;
            request.AnalyticsMetadata = new Amazon.CognitoIdentityProvider.Model.AnalyticsMetadataType();
            System.String requestAnalyticsMetadata_analyticsMetadata_AnalyticsEndpointId = null;
            if (cmdletContext.AnalyticsMetadata_AnalyticsEndpointId != null)
            {
                requestAnalyticsMetadata_analyticsMetadata_AnalyticsEndpointId = cmdletContext.AnalyticsMetadata_AnalyticsEndpointId;
            }
            if (requestAnalyticsMetadata_analyticsMetadata_AnalyticsEndpointId != null)
            {
                request.AnalyticsMetadata.AnalyticsEndpointId = requestAnalyticsMetadata_analyticsMetadata_AnalyticsEndpointId;
                requestAnalyticsMetadataIsNull = false;
            }
             // determine if request.AnalyticsMetadata should be set to null
            if (requestAnalyticsMetadataIsNull)
            {
                request.AnalyticsMetadata = null;
            }
            if (cmdletContext.AuthFlow != null)
            {
                request.AuthFlow = cmdletContext.AuthFlow;
            }
            if (cmdletContext.AuthParameter != null)
            {
                request.AuthParameters = cmdletContext.AuthParameter;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.ClientMetadata != null)
            {
                request.ClientMetadata = cmdletContext.ClientMetadata;
            }
            if (cmdletContext.Session != null)
            {
                request.Session = cmdletContext.Session;
            }
            
             // populate UserContextData
            var requestUserContextDataIsNull = true;
            request.UserContextData = new Amazon.CognitoIdentityProvider.Model.UserContextDataType();
            System.String requestUserContextData_userContextData_EncodedData = null;
            if (cmdletContext.UserContextData_EncodedData != null)
            {
                requestUserContextData_userContextData_EncodedData = cmdletContext.UserContextData_EncodedData;
            }
            if (requestUserContextData_userContextData_EncodedData != null)
            {
                request.UserContextData.EncodedData = requestUserContextData_userContextData_EncodedData;
                requestUserContextDataIsNull = false;
            }
            System.String requestUserContextData_userContextData_IpAddress = null;
            if (cmdletContext.UserContextData_IpAddress != null)
            {
                requestUserContextData_userContextData_IpAddress = cmdletContext.UserContextData_IpAddress;
            }
            if (requestUserContextData_userContextData_IpAddress != null)
            {
                request.UserContextData.IpAddress = requestUserContextData_userContextData_IpAddress;
                requestUserContextDataIsNull = false;
            }
             // determine if request.UserContextData should be set to null
            if (requestUserContextDataIsNull)
            {
                request.UserContextData = null;
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
        
        private Amazon.CognitoIdentityProvider.Model.InitiateAuthResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.InitiateAuthRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "InitiateAuth");
            try
            {
                return client.InitiateAuthAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AnalyticsMetadata_AnalyticsEndpointId { get; set; }
            public Amazon.CognitoIdentityProvider.AuthFlowType AuthFlow { get; set; }
            public Dictionary<System.String, System.String> AuthParameter { get; set; }
            public System.String ClientId { get; set; }
            public Dictionary<System.String, System.String> ClientMetadata { get; set; }
            public System.String Session { get; set; }
            public System.String UserContextData_EncodedData { get; set; }
            public System.String UserContextData_IpAddress { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.InitiateAuthResponse, StartCGIPAuthCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
