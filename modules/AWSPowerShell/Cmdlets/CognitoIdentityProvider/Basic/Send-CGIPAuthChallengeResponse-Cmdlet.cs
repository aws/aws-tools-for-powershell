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
    /// Some API operations in a user pool generate a challenge, like a prompt for an MFA
    /// code, for device authentication that bypasses MFA, or for a custom authentication
    /// challenge. A <c>RespondToAuthChallenge</c> API request provides the answer to that
    /// challenge, like a code or a secure remote password (SRP). The parameters of a response
    /// to an authentication challenge vary with the type of challenge.
    /// 
    ///  
    /// <para>
    /// For more information about custom authentication challenges, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-lambda-challenge.html">Custom
    /// authentication challenge Lambda triggers</a>.
    /// </para><note><para>
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
    [Cmdlet("Send", "CGIPAuthChallengeResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider RespondToAuthChallenge API operation.", Operation = new[] {"RespondToAuthChallenge"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse object containing multiple properties."
    )]
    public partial class SendCGIPAuthChallengeResponseCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter ChallengeName
        /// <summary>
        /// <para>
        /// <para>The challenge name. For more information, see <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_InitiateAuth.html">InitiateAuth</a>.</para><para><c>ADMIN_NO_SRP_AUTH</c> isn't a valid value.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.ChallengeNameType")]
        public Amazon.CognitoIdentityProvider.ChallengeNameType ChallengeName { get; set; }
        #endregion
        
        #region Parameter ChallengeResponse
        /// <summary>
        /// <para>
        /// <para>The responses to the challenge that you received in the previous request. Each challenge
        /// has its own required response parameters. The following examples are partial JSON
        /// request bodies that highlight challenge-response parameters.</para><important><para>You must provide a SECRET_HASH parameter in all challenge responses to an app client
        /// that has a client secret. Include a <c>DEVICE_KEY</c> for device authentication.</para></important><dl><dt>SELECT_CHALLENGE</dt><dd><para><c>"ChallengeName": "SELECT_CHALLENGE", "ChallengeResponses": { "USERNAME": "[username]",
        /// "ANSWER": "[Challenge name]"}</c></para><para>Available challenges are <c>PASSWORD</c>, <c>PASSWORD_SRP</c>, <c>EMAIL_OTP</c>, <c>SMS_OTP</c>,
        /// and <c>WEB_AUTHN</c>.</para><para>Complete authentication in the <c>SELECT_CHALLENGE</c> response for <c>PASSWORD</c>,
        /// <c>PASSWORD_SRP</c>, and <c>WEB_AUTHN</c>:</para><ul><li><para><c>"ChallengeName": "SELECT_CHALLENGE", "ChallengeResponses": { "ANSWER": "WEB_AUTHN",
        /// "USERNAME": "[username]", "CREDENTIAL": "[AuthenticationResponseJSON]"}</c></para><para>See <a href="https://www.w3.org/TR/webauthn-3/#dictdef-authenticationresponsejson">
        /// AuthenticationResponseJSON</a>.</para></li><li><para><c>"ChallengeName": "SELECT_CHALLENGE", "ChallengeResponses": { "ANSWER": "PASSWORD",
        /// "USERNAME": "[username]", "PASSWORD": "[password]"}</c></para></li><li><para><c>"ChallengeName": "SELECT_CHALLENGE", "ChallengeResponses": { "ANSWER": "PASSWORD_SRP",
        /// "USERNAME": "[username]", "SRP_A": "[SRP_A]"}</c></para></li></ul><para>For <c>SMS_OTP</c> and <c>EMAIL_OTP</c>, respond with the username and answer. Your
        /// user pool will send a code for the user to submit in the next challenge response.</para><ul><li><para><c>"ChallengeName": "SELECT_CHALLENGE", "ChallengeResponses": { "ANSWER": "SMS_OTP",
        /// "USERNAME": "[username]"}</c></para></li><li><para><c>"ChallengeName": "SELECT_CHALLENGE", "ChallengeResponses": { "ANSWER": "EMAIL_OTP",
        /// "USERNAME": "[username]"}</c></para></li></ul></dd><dt>SMS_OTP</dt><dd><para><c>"ChallengeName": "SMS_OTP", "ChallengeResponses": {"SMS_OTP_CODE": "[code]", "USERNAME":
        /// "[username]"}</c></para></dd><dt>EMAIL_OTP</dt><dd><para><c>"ChallengeName": "EMAIL_OTP", "ChallengeResponses": {"EMAIL_OTP_CODE": "[code]",
        /// "USERNAME": "[username]"}</c></para></dd><dt>SMS_MFA</dt><dd><para><c>"ChallengeName": "SMS_MFA", "ChallengeResponses": {"SMS_MFA_CODE": "[code]", "USERNAME":
        /// "[username]"}</c></para></dd><dt>PASSWORD_VERIFIER</dt><dd><para>This challenge response is part of the SRP flow. Amazon Cognito requires that your
        /// application respond to this challenge within a few seconds. When the response time
        /// exceeds this period, your user pool returns a <c>NotAuthorizedException</c> error.</para><para><c>"ChallengeName": "PASSWORD_VERIFIER", "ChallengeResponses": {"PASSWORD_CLAIM_SIGNATURE":
        /// "[claim_signature]", "PASSWORD_CLAIM_SECRET_BLOCK": "[secret_block]", "TIMESTAMP":
        /// [timestamp], "USERNAME": "[username]"}</c></para><para>Add <c>"DEVICE_KEY"</c> when you sign in with a remembered device.</para></dd><dt>CUSTOM_CHALLENGE</dt><dd><para><c>"ChallengeName": "CUSTOM_CHALLENGE", "ChallengeResponses": {"USERNAME": "[username]",
        /// "ANSWER": "[challenge_answer]"}</c></para><para>Add <c>"DEVICE_KEY"</c> when you sign in with a remembered device.</para></dd><dt>NEW_PASSWORD_REQUIRED</dt><dd><para><c>"ChallengeName": "NEW_PASSWORD_REQUIRED", "ChallengeResponses": {"NEW_PASSWORD":
        /// "[new_password]", "USERNAME": "[username]"}</c></para><para>To set any required attributes that <c>InitiateAuth</c> returned in an <c>requiredAttributes</c>
        /// parameter, add <c>"userAttributes.[attribute_name]": "[attribute_value]"</c>. This
        /// parameter can also set values for writable attributes that aren't required by your
        /// user pool.</para><note><para>In a <c>NEW_PASSWORD_REQUIRED</c> challenge response, you can't modify a required
        /// attribute that already has a value. In <c>RespondToAuthChallenge</c>, set a value
        /// for any keys that Amazon Cognito returned in the <c>requiredAttributes</c> parameter,
        /// then use the <c>UpdateUserAttributes</c> API operation to modify the value of any
        /// additional attributes.</para></note></dd><dt>SOFTWARE_TOKEN_MFA</dt><dd><para><c>"ChallengeName": "SOFTWARE_TOKEN_MFA", "ChallengeResponses": {"USERNAME": "[username]",
        /// "SOFTWARE_TOKEN_MFA_CODE": [authenticator_code]}</c></para></dd><dt>DEVICE_SRP_AUTH</dt><dd><para><c>"ChallengeName": "DEVICE_SRP_AUTH", "ChallengeResponses": {"USERNAME": "[username]",
        /// "DEVICE_KEY": "[device_key]", "SRP_A": "[srp_a]"}</c></para></dd><dt>DEVICE_PASSWORD_VERIFIER</dt><dd><para><c>"ChallengeName": "DEVICE_PASSWORD_VERIFIER", "ChallengeResponses": {"DEVICE_KEY":
        /// "[device_key]", "PASSWORD_CLAIM_SIGNATURE": "[claim_signature]", "PASSWORD_CLAIM_SECRET_BLOCK":
        /// "[secret_block]", "TIMESTAMP": [timestamp], "USERNAME": "[username]"}</c></para></dd><dt>MFA_SETUP</dt><dd><para><c>"ChallengeName": "MFA_SETUP", "ChallengeResponses": {"USERNAME": "[username]"},
        /// "SESSION": "[Session ID from VerifySoftwareToken]"</c></para></dd><dt>SELECT_MFA_TYPE</dt><dd><para><c>"ChallengeName": "SELECT_MFA_TYPE", "ChallengeResponses": {"USERNAME": "[username]",
        /// "ANSWER": "[SMS_MFA or SOFTWARE_TOKEN_MFA]"}</c></para></dd></dl><para>For more information about <c>SECRET_HASH</c>, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/signing-up-users-in-your-app.html#cognito-user-pools-computing-secret-hash">Computing
        /// secret hash values</a>. For information about <c>DEVICE_KEY</c>, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-device-tracking.html">Working
        /// with user devices in your user pool</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChallengeResponses")]
        public System.Collections.Hashtable ChallengeResponse { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The app client ID.</para>
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
        /// <para>A map of custom key-value pairs that you can provide as input for any custom workflows
        /// that this action triggers.</para><para>You create custom workflows by assigning Lambda functions to user pool triggers. When
        /// you use the RespondToAuthChallenge API action, Amazon Cognito invokes any functions
        /// that are assigned to the following triggers: <i>post authentication</i>, <i>pre token
        /// generation</i>, <i>define auth challenge</i>, <i>create auth challenge</i>, and <i>verify
        /// auth challenge</i>. When Amazon Cognito invokes any of these functions, it passes
        /// a JSON payload, which the function receives as input. This payload contains a <c>clientMetadata</c>
        /// attribute, which provides the data that you assigned to the ClientMetadata parameter
        /// in your RespondToAuthChallenge request. In your function code in Lambda, you can process
        /// the <c>clientMetadata</c> value to enhance your workflow for your specific needs.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-working-with-aws-lambda-triggers.html">
        /// Customizing user pool Workflows with Lambda Triggers</a> in the <i>Amazon Cognito
        /// Developer Guide</i>.</para><note><para>When you use the <c>ClientMetadata</c> parameter, note that Amazon Cognito won't do
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
        /// <para>The session that should be passed both ways in challenge-response calls to the service.
        /// If <c>InitiateAuth</c> or <c>RespondToAuthChallenge</c> API call determines that the
        /// caller must pass another challenge, they return a session with other challenge parameters.
        /// This session should be passed as it is to the next <c>RespondToAuthChallenge</c> API
        /// call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Session { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClientId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CGIPAuthChallengeResponse (RespondToAuthChallenge)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse, SendCGIPAuthChallengeResponseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnalyticsMetadata_AnalyticsEndpointId = this.AnalyticsMetadata_AnalyticsEndpointId;
            context.ChallengeName = this.ChallengeName;
            #if MODULAR
            if (this.ChallengeName == null && ParameterWasBound(nameof(this.ChallengeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChallengeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ChallengeResponse != null)
            {
                context.ChallengeResponse = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ChallengeResponse.Keys)
                {
                    context.ChallengeResponse.Add((String)hashKey, (System.String)(this.ChallengeResponse[hashKey]));
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
            var request = new Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeRequest();
            
            
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
            if (cmdletContext.ChallengeName != null)
            {
                request.ChallengeName = cmdletContext.ChallengeName;
            }
            if (cmdletContext.ChallengeResponse != null)
            {
                request.ChallengeResponses = cmdletContext.ChallengeResponse;
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
        
        private Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "RespondToAuthChallenge");
            try
            {
                #if DESKTOP
                return client.RespondToAuthChallenge(request);
                #elif CORECLR
                return client.RespondToAuthChallengeAsync(request).GetAwaiter().GetResult();
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
            public System.String AnalyticsMetadata_AnalyticsEndpointId { get; set; }
            public Amazon.CognitoIdentityProvider.ChallengeNameType ChallengeName { get; set; }
            public Dictionary<System.String, System.String> ChallengeResponse { get; set; }
            public System.String ClientId { get; set; }
            public Dictionary<System.String, System.String> ClientMetadata { get; set; }
            public System.String Session { get; set; }
            public System.String UserContextData_EncodedData { get; set; }
            public System.String UserContextData_IpAddress { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse, SendCGIPAuthChallengeResponseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
