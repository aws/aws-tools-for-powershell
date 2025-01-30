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
    /// Some API operations in a user pool generate a challenge, like a prompt for an MFA
    /// code, for device authentication that bypasses MFA, or for a custom authentication
    /// challenge. An <c>AdminRespondToAuthChallenge</c> API request provides the answer to
    /// that challenge, like a code or a secure remote password (SRP). The parameters of a
    /// response to an authentication challenge vary with the type of challenge.
    /// 
    ///  
    /// <para>
    /// For more information about custom authentication challenges, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-lambda-challenge.html">Custom
    /// authentication challenge Lambda triggers</a>.
    /// </para><note><para>
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
    /// </para></note><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Send", "CGIPAuthChallengeResponseAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AdminRespondToAuthChallenge API operation.", Operation = new[] {"AdminRespondToAuthChallenge"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse object containing multiple properties."
    )]
    public partial class SendCGIPAuthChallengeResponseAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
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
        /// <para>The name of the challenge that you are responding to. You can find more information
        /// about values for <c>ChallengeName</c> in the response parameters of <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_AdminInitiateAuth.html#CognitoUserPools-AdminInitiateAuth-response-ChallengeName">AdminInitiateAuth</a>.</para>
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
        /// <para>The ID of the app client where you initiated sign-in.</para>
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
        /// you use the AdminRespondToAuthChallenge API action, Amazon Cognito invokes any functions
        /// that you have assigned to the following triggers: </para><ul><li><para>Pre sign-up</para></li><li><para>custom message</para></li><li><para>Post authentication</para></li><li><para>User migration</para></li><li><para>Pre token generation</para></li><li><para>Define auth challenge</para></li><li><para>Create auth challenge</para></li><li><para>Verify auth challenge response</para></li></ul><para>When Amazon Cognito invokes any of these functions, it passes a JSON payload, which
        /// the function receives as input. This payload contains a <c>clientMetadata</c> attribute
        /// that provides the data that you assigned to the ClientMetadata parameter in your AdminRespondToAuthChallenge
        /// request. In your function code in Lambda, you can process the <c>clientMetadata</c>
        /// value to enhance your workflow for your specific needs.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-working-with-aws-lambda-triggers.html">
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
        
        #region Parameter ContextData_EncodedData
        /// <summary>
        /// <para>
        /// <para>Encoded device-fingerprint details that your app collected with the Amazon Cognito
        /// context data collection library. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pool-settings-adaptive-authentication.html#user-pool-settings-adaptive-authentication-device-fingerprint">Adding
        /// user device and session data to API requests</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_EncodedData { get; set; }
        #endregion
        
        #region Parameter ContextData_HttpHeader
        /// <summary>
        /// <para>
        /// <para>The HTTP headers from your user's authentication request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContextData_HttpHeaders")]
        public Amazon.CognitoIdentityProvider.Model.HttpHeader[] ContextData_HttpHeader { get; set; }
        #endregion
        
        #region Parameter ContextData_IpAddress
        /// <summary>
        /// <para>
        /// <para>The source IP address of your user's device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_IpAddress { get; set; }
        #endregion
        
        #region Parameter ContextData_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of your application's service endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_ServerName { get; set; }
        #endregion
        
        #region Parameter ContextData_ServerPath
        /// <summary>
        /// <para>
        /// <para>The path of your application's service endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_ServerPath { get; set; }
        #endregion
        
        #region Parameter Session
        /// <summary>
        /// <para>
        /// <para>The session identifier that maintains the state of authentication requests and challenge
        /// responses. If an <c>AdminInitiateAuth</c> or <c>AdminRespondToAuthChallenge</c> API
        /// request results in a determination that your application must pass another challenge,
        /// Amazon Cognito returns a session with other challenge parameters. Send this session
        /// identifier, unmodified, to the next <c>AdminRespondToAuthChallenge</c> request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Session { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool where you want to respond to an authentication challenge.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CGIPAuthChallengeResponseAdmin (AdminRespondToAuthChallenge)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse, SendCGIPAuthChallengeResponseAdminCmdlet>(Select) ??
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
            context.ContextData_EncodedData = this.ContextData_EncodedData;
            if (this.ContextData_HttpHeader != null)
            {
                context.ContextData_HttpHeader = new List<Amazon.CognitoIdentityProvider.Model.HttpHeader>(this.ContextData_HttpHeader);
            }
            context.ContextData_IpAddress = this.ContextData_IpAddress;
            context.ContextData_ServerName = this.ContextData_ServerName;
            context.ContextData_ServerPath = this.ContextData_ServerPath;
            context.Session = this.Session;
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
            var request = new Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeRequest();
            
            
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
            
             // populate ContextData
            var requestContextDataIsNull = true;
            request.ContextData = new Amazon.CognitoIdentityProvider.Model.ContextDataType();
            System.String requestContextData_contextData_EncodedData = null;
            if (cmdletContext.ContextData_EncodedData != null)
            {
                requestContextData_contextData_EncodedData = cmdletContext.ContextData_EncodedData;
            }
            if (requestContextData_contextData_EncodedData != null)
            {
                request.ContextData.EncodedData = requestContextData_contextData_EncodedData;
                requestContextDataIsNull = false;
            }
            List<Amazon.CognitoIdentityProvider.Model.HttpHeader> requestContextData_contextData_HttpHeader = null;
            if (cmdletContext.ContextData_HttpHeader != null)
            {
                requestContextData_contextData_HttpHeader = cmdletContext.ContextData_HttpHeader;
            }
            if (requestContextData_contextData_HttpHeader != null)
            {
                request.ContextData.HttpHeaders = requestContextData_contextData_HttpHeader;
                requestContextDataIsNull = false;
            }
            System.String requestContextData_contextData_IpAddress = null;
            if (cmdletContext.ContextData_IpAddress != null)
            {
                requestContextData_contextData_IpAddress = cmdletContext.ContextData_IpAddress;
            }
            if (requestContextData_contextData_IpAddress != null)
            {
                request.ContextData.IpAddress = requestContextData_contextData_IpAddress;
                requestContextDataIsNull = false;
            }
            System.String requestContextData_contextData_ServerName = null;
            if (cmdletContext.ContextData_ServerName != null)
            {
                requestContextData_contextData_ServerName = cmdletContext.ContextData_ServerName;
            }
            if (requestContextData_contextData_ServerName != null)
            {
                request.ContextData.ServerName = requestContextData_contextData_ServerName;
                requestContextDataIsNull = false;
            }
            System.String requestContextData_contextData_ServerPath = null;
            if (cmdletContext.ContextData_ServerPath != null)
            {
                requestContextData_contextData_ServerPath = cmdletContext.ContextData_ServerPath;
            }
            if (requestContextData_contextData_ServerPath != null)
            {
                request.ContextData.ServerPath = requestContextData_contextData_ServerPath;
                requestContextDataIsNull = false;
            }
             // determine if request.ContextData should be set to null
            if (requestContextDataIsNull)
            {
                request.ContextData = null;
            }
            if (cmdletContext.Session != null)
            {
                request.Session = cmdletContext.Session;
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminRespondToAuthChallenge");
            try
            {
                #if DESKTOP
                return client.AdminRespondToAuthChallenge(request);
                #elif CORECLR
                return client.AdminRespondToAuthChallengeAsync(request).GetAwaiter().GetResult();
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
            public System.String ContextData_EncodedData { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.HttpHeader> ContextData_HttpHeader { get; set; }
            public System.String ContextData_IpAddress { get; set; }
            public System.String ContextData_ServerName { get; set; }
            public System.String ContextData_ServerPath { get; set; }
            public System.String Session { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse, SendCGIPAuthChallengeResponseAdminCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
