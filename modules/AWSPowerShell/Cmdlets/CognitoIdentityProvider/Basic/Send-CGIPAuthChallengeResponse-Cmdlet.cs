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
    /// Responds to the authentication challenge.
    /// 
    ///  <note><para>
    /// This action might generate an SMS text message. Starting June 1, 2021, U.S. telecom
    /// carriers require that you register an origination phone number before you can send
    /// SMS messages to U.S. phone numbers. If you use SMS text messages in Amazon Cognito,
    /// you must register a phone number with <a href="https://console.aws.amazon.com/pinpoint/home/">Amazon
    /// Pinpoint</a>. Cognito will use the the registered number automatically. Otherwise,
    /// Cognito users that must receive SMS messages might be unable to sign up, activate
    /// their accounts, or sign in.
    /// </para><para>
    /// If you have never used SMS text messages with Amazon Cognito or any other AWS service,
    /// Amazon SNS might place your account in SMS sandbox. In <i><a href="https://docs.aws.amazon.com/sns/latest/dg/sns-sms-sandbox.html">sandbox
    /// mode</a></i>, you’ll have limitations, such as sending messages to only verified
    /// phone numbers. After testing in the sandbox environment, you can move out of the SMS
    /// sandbox and into production. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-sms-userpool-settings.html">
    /// SMS message settings for Cognito User Pools</a> in the <i>Amazon Cognito Developer
    /// Guide</i>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Send", "CGIPAuthChallengeResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider RespondToAuthChallenge API operation.", Operation = new[] {"RespondToAuthChallenge"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendCGIPAuthChallengeResponseCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter AnalyticsMetadata_AnalyticsEndpointId
        /// <summary>
        /// <para>
        /// <para>The endpoint ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsMetadata_AnalyticsEndpointId { get; set; }
        #endregion
        
        #region Parameter ChallengeName
        /// <summary>
        /// <para>
        /// <para>The challenge name. For more information, see <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_InitiateAuth.html">InitiateAuth</a>.</para><para><code>ADMIN_NO_SRP_AUTH</code> is not a valid value.</para>
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
        /// <para>The challenge responses. These are inputs corresponding to the value of <code>ChallengeName</code>,
        /// for example:</para><note><para><code>SECRET_HASH</code> (if app client is configured with client secret) applies
        /// to all inputs below (including <code>SOFTWARE_TOKEN_MFA</code>).</para></note><ul><li><para><code>SMS_MFA</code>: <code>SMS_MFA_CODE</code>, <code>USERNAME</code>.</para></li><li><para><code>PASSWORD_VERIFIER</code>: <code>PASSWORD_CLAIM_SIGNATURE</code>, <code>PASSWORD_CLAIM_SECRET_BLOCK</code>,
        /// <code>TIMESTAMP</code>, <code>USERNAME</code>.</para></li><li><para><code>NEW_PASSWORD_REQUIRED</code>: <code>NEW_PASSWORD</code>, any other required
        /// attributes, <code>USERNAME</code>. </para></li><li><para><code>SOFTWARE_TOKEN_MFA</code>: <code>USERNAME</code> and <code>SOFTWARE_TOKEN_MFA_CODE</code>
        /// are required attributes.</para></li><li><para><code>DEVICE_SRP_AUTH</code> requires <code>USERNAME</code>, <code>DEVICE_KEY</code>,
        /// <code>SRP_A</code> (and <code>SECRET_HASH</code>).</para></li><li><para><code>DEVICE_PASSWORD_VERIFIER</code> requires everything that <code>PASSWORD_VERIFIER</code>
        /// requires plus <code>DEVICE_KEY</code>.</para></li><li><para><code>MFA_SETUP</code> requires <code>USERNAME</code>, plus you need to use the session
        /// value returned by <code>VerifySoftwareToken</code> in the <code>Session</code> parameter.</para></li></ul>
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
        /// that this action triggers. </para><para>You create custom workflows by assigning AWS Lambda functions to user pool triggers.
        /// When you use the RespondToAuthChallenge API action, Amazon Cognito invokes any functions
        /// that are assigned to the following triggers: <i>post authentication</i>, <i>pre token
        /// generation</i>, <i>define auth challenge</i>, <i>create auth challenge</i>, and <i>verify
        /// auth challenge</i>. When Amazon Cognito invokes any of these functions, it passes
        /// a JSON payload, which the function receives as input. This payload contains a <code>clientMetadata</code>
        /// attribute, which provides the data that you assigned to the ClientMetadata parameter
        /// in your RespondToAuthChallenge request. In your function code in AWS Lambda, you can
        /// process the <code>clientMetadata</code> value to enhance your workflow for your specific
        /// needs.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-working-with-aws-lambda-triggers.html">Customizing
        /// User Pool Workflows with Lambda Triggers</a> in the <i>Amazon Cognito Developer Guide</i>.</para><note><para>Take the following limitations into consideration when you use the ClientMetadata
        /// parameter:</para><ul><li><para>Amazon Cognito does not store the ClientMetadata value. This data is available only
        /// to AWS Lambda triggers that are assigned to a user pool to support custom workflows.
        /// If your user pool configuration does not include triggers, the ClientMetadata parameter
        /// serves no purpose.</para></li><li><para>Amazon Cognito does not validate the ClientMetadata value.</para></li><li><para>Amazon Cognito does not encrypt the the ClientMetadata value, so don't use it to provide
        /// sensitive information.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ClientMetadata { get; set; }
        #endregion
        
        #region Parameter UserContextData_EncodedData
        /// <summary>
        /// <para>
        /// <para>Contextual data such as the user's device fingerprint, IP address, or location used
        /// for evaluating the risk of an unexpected event by Amazon Cognito advanced security.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserContextData_EncodedData { get; set; }
        #endregion
        
        #region Parameter Session
        /// <summary>
        /// <para>
        /// <para>The session which should be passed both ways in challenge-response calls to the service.
        /// If <code>InitiateAuth</code> or <code>RespondToAuthChallenge</code> API call determines
        /// that the caller needs to go through another challenge, they return a session with
        /// other challenge parameters. This session should be passed as it is to the next <code>RespondToAuthChallenge</code>
        /// API call.</para>
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClientId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CGIPAuthChallengeResponse (RespondToAuthChallenge)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse, SendCGIPAuthChallengeResponseCmdlet>(Select) ??
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
                    context.ChallengeResponse.Add((String)hashKey, (String)(this.ChallengeResponse[hashKey]));
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
            context.Session = this.Session;
            context.UserContextData_EncodedData = this.UserContextData_EncodedData;
            
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
            public System.Func<Amazon.CognitoIdentityProvider.Model.RespondToAuthChallengeResponse, SendCGIPAuthChallengeResponseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
