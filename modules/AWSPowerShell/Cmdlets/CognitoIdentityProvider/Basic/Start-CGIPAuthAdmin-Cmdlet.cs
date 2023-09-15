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
    /// Initiates the authentication flow, as an administrator.
    /// 
    ///  <note><para>
    /// This action might generate an SMS text message. Starting June 1, 2021, US telecom
    /// carriers require you to register an origination phone number before you can send SMS
    /// messages to US phone numbers. If you use SMS text messages in Amazon Cognito, you
    /// must register a phone number with <a href="https://console.aws.amazon.com/pinpoint/home/">Amazon
    /// Pinpoint</a>. Amazon Cognito uses the registered number automatically. Otherwise,
    /// Amazon Cognito users who must receive SMS messages might not be able to sign up, activate
    /// their accounts, or sign in.
    /// </para><para>
    /// If you have never used SMS text messages with Amazon Cognito or any other Amazon Web
    /// Service, Amazon Simple Notification Service might place your account in the SMS sandbox.
    /// In <i><a href="https://docs.aws.amazon.com/sns/latest/dg/sns-sms-sandbox.html">sandbox
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
    [Cmdlet("Start", "CGIPAuthAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AdminInitiateAuth API operation.", Operation = new[] {"AdminInitiateAuth"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCGIPAuthAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter AnalyticsMetadata_AnalyticsEndpointId
        /// <summary>
        /// <para>
        /// <para>The endpoint ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsMetadata_AnalyticsEndpointId { get; set; }
        #endregion
        
        #region Parameter AuthFlow
        /// <summary>
        /// <para>
        /// <para>The authentication flow for this call to run. The API action will depend on this value.
        /// For example:</para><ul><li><para><code>REFRESH_TOKEN_AUTH</code> will take in a valid refresh token and return new
        /// tokens.</para></li><li><para><code>USER_SRP_AUTH</code> will take in <code>USERNAME</code> and <code>SRP_A</code>
        /// and return the Secure Remote Password (SRP) protocol variables to be used for next
        /// challenge execution.</para></li><li><para><code>ADMIN_USER_PASSWORD_AUTH</code> will take in <code>USERNAME</code> and <code>PASSWORD</code>
        /// and return the next challenge or tokens.</para></li></ul><para>Valid values include:</para><ul><li><para><code>USER_SRP_AUTH</code>: Authentication flow for the Secure Remote Password (SRP)
        /// protocol.</para></li><li><para><code>REFRESH_TOKEN_AUTH</code>/<code>REFRESH_TOKEN</code>: Authentication flow for
        /// refreshing the access token and ID token by supplying a valid refresh token.</para></li><li><para><code>CUSTOM_AUTH</code>: Custom authentication flow.</para></li><li><para><code>ADMIN_NO_SRP_AUTH</code>: Non-SRP authentication flow; you can pass in the
        /// USERNAME and PASSWORD directly if the flow is enabled for calling the app client.</para></li><li><para><code>ADMIN_USER_PASSWORD_AUTH</code>: Admin-based user password authentication.
        /// This replaces the <code>ADMIN_NO_SRP_AUTH</code> authentication flow. In this flow,
        /// Amazon Cognito receives the password in the request instead of using the SRP process
        /// to verify passwords.</para></li></ul>
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
        /// <para>The authentication parameters. These are inputs corresponding to the <code>AuthFlow</code>
        /// that you're invoking. The required values depend on the value of <code>AuthFlow</code>:</para><ul><li><para>For <code>USER_SRP_AUTH</code>: <code>USERNAME</code> (required), <code>SRP_A</code>
        /// (required), <code>SECRET_HASH</code> (required if the app client is configured with
        /// a client secret), <code>DEVICE_KEY</code>.</para></li><li><para>For <code>ADMIN_USER_PASSWORD_AUTH</code>: <code>USERNAME</code> (required), <code>PASSWORD</code>
        /// (required), <code>SECRET_HASH</code> (required if the app client is configured with
        /// a client secret), <code>DEVICE_KEY</code>.</para></li><li><para>For <code>REFRESH_TOKEN_AUTH/REFRESH_TOKEN</code>: <code>REFRESH_TOKEN</code> (required),
        /// <code>SECRET_HASH</code> (required if the app client is configured with a client secret),
        /// <code>DEVICE_KEY</code>.</para></li><li><para>For <code>CUSTOM_AUTH</code>: <code>USERNAME</code> (required), <code>SECRET_HASH</code>
        /// (if app client is configured with client secret), <code>DEVICE_KEY</code>. To start
        /// the authentication flow with password verification, include <code>ChallengeName: SRP_A</code>
        /// and <code>SRP_A: (The SRP_A Value)</code>.</para></li></ul><para>For more information about <code>SECRET_HASH</code>, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/signing-up-users-in-your-app.html#cognito-user-pools-computing-secret-hash">Computing
        /// secret hash values</a>. For information about <code>DEVICE_KEY</code>, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/amazon-cognito-user-pools-device-tracking.html">Working
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
        /// <para>A map of custom key-value pairs that you can provide as input for certain custom workflows
        /// that this action triggers.</para><para>You create custom workflows by assigning Lambda functions to user pool triggers. When
        /// you use the AdminInitiateAuth API action, Amazon Cognito invokes the Lambda functions
        /// that are specified for various triggers. The ClientMetadata value is passed as input
        /// to the functions for only the following triggers:</para><ul><li><para>Pre signup</para></li><li><para>Pre authentication</para></li><li><para>User migration</para></li></ul><para>When Amazon Cognito invokes the functions for these triggers, it passes a JSON payload,
        /// which the function receives as input. This payload contains a <code>validationData</code>
        /// attribute, which provides the data that you assigned to the ClientMetadata parameter
        /// in your AdminInitiateAuth request. In your function code in Lambda, you can process
        /// the <code>validationData</code> value to enhance your workflow for your specific needs.</para><para>When you use the AdminInitiateAuth API action, Amazon Cognito also invokes the functions
        /// for the following triggers, but it doesn't provide the ClientMetadata value as input:</para><ul><li><para>Post authentication</para></li><li><para>Custom message</para></li><li><para>Pre token generation</para></li><li><para>Create auth challenge</para></li><li><para>Define auth challenge</para></li><li><para>Verify auth challenge</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-working-with-aws-lambda-triggers.html">
        /// Customizing user pool Workflows with Lambda Triggers</a> in the <i>Amazon Cognito
        /// Developer Guide</i>.</para><note><para>When you use the ClientMetadata parameter, remember that Amazon Cognito won't do the
        /// following:</para><ul><li><para>Store the ClientMetadata value. This data is available only to Lambda triggers that
        /// are assigned to a user pool to support custom workflows. If your user pool configuration
        /// doesn't include triggers, the ClientMetadata parameter serves no purpose.</para></li><li><para>Validate the ClientMetadata value.</para></li><li><para>Encrypt the ClientMetadata value. Don't use Amazon Cognito to provide sensitive information.</para></li></ul></note>
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
        /// <para>HttpHeaders received on your server in same order.</para>
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
        /// <para>Your server endpoint where this API is invoked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_ServerName { get; set; }
        #endregion
        
        #region Parameter ContextData_ServerPath
        /// <summary>
        /// <para>
        /// <para>Your server path where this API is invoked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_ServerPath { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Cognito user pool.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CGIPAuthAdmin (AdminInitiateAuth)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse, StartCGIPAuthAdminCmdlet>(Select) ??
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
                    context.AuthParameter.Add((String)hashKey, (String)(this.AuthParameter[hashKey]));
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
                    context.ClientMetadata.Add((String)hashKey, (String)(this.ClientMetadata[hashKey]));
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
            var request = new Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthRequest();
            
            
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminInitiateAuth");
            try
            {
                #if DESKTOP
                return client.AdminInitiateAuth(request);
                #elif CORECLR
                return client.AdminInitiateAuthAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CognitoIdentityProvider.AuthFlowType AuthFlow { get; set; }
            public Dictionary<System.String, System.String> AuthParameter { get; set; }
            public System.String ClientId { get; set; }
            public Dictionary<System.String, System.String> ClientMetadata { get; set; }
            public System.String ContextData_EncodedData { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.HttpHeader> ContextData_HttpHeader { get; set; }
            public System.String ContextData_IpAddress { get; set; }
            public System.String ContextData_ServerName { get; set; }
            public System.String ContextData_ServerPath { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse, StartCGIPAuthAdminCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
